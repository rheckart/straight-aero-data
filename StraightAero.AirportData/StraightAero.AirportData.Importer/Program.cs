using System;
using System.IO;
using FlatFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;

namespace StraightAero.AirportData.Schema.Importer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var sourceDirectory = string.Empty;
            var outputSchemaFolder = string.Empty;
            var outputClassFolder = string.Empty;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-path":
                        sourceDirectory = args[i + 1];
                        break;

                    case "-schema":
                        outputSchemaFolder = args[i + 1];
                        break;

                    case "-classes":
                        outputClassFolder = args[i + 1];
                        break;
                }
            }

            if (string.IsNullOrEmpty(sourceDirectory))
            {
                Console.WriteLine("No -source provided");
                return;
            }

            if (string.IsNullOrEmpty(outputSchemaFolder))
            {
                Console.WriteLine("No -schema provided");
                return;
            }

            if (string.IsNullOrEmpty(outputClassFolder))
            {
                Console.WriteLine("No -classes provided");
                return;
            }

            Console.WriteLine("Reading Layout Data");

            var directory = new DirectoryInfo(sourceDirectory);
            var layoutFiles = directory.GetFiles("*.txt");
            const Int32 BufferSize = 128;
            var lines = new List<string>();
            var fieldNames = new Dictionary<string, int>();

            foreach (var layoutFile in layoutFiles)
            {
                var fileTitle = string.Empty;
                var outSchemaFileTitle = string.Empty;
                var outClassFileTitle = string.Empty;
                var doNotWriteClassBreak = true;

                Console.WriteLine($"FileName: {layoutFile.FullName}");

                using (var fileStream = layoutFile.OpenRead())
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            lines.Add(streamReader.ReadLine());
                        }
                    }
                }

                ParseTitle(lines, ref fileTitle, ref outSchemaFileTitle, ref outClassFileTitle);
                var sectionNameSchema = $"{fileTitle}Schema";

                var streamSchemaWriter = new StreamWriter($"{outputSchemaFolder}\\{outSchemaFileTitle}", false);
                var streamClassWriter = new StreamWriter($"{outputClassFolder}\\{outClassFileTitle}", false);

                WriteSchemaHeader(streamSchemaWriter, fileTitle);
                WriteClassHeader(streamClassWriter, fileTitle);

                var fieldDescriptionStart = 0;

                for (int i = 0; i < lines.Count; i++)
                {
                    var line = lines[i];

                    if (line.Contains("FIELD DESCRIPTION"))
                    {
                        fieldDescriptionStart = line.IndexOf("FIELD DESCRIPTION");
                        sectionNameSchema = TextToFieldName(lines[i + 2].Replace("*", string.Empty).Replace("Data", string.Empty), true);
                        //Console.WriteLine($"Section: {sectionNameSchema}");

                        WriteSchemaBreak(streamSchemaWriter, sectionNameSchema);
                        WriteClassBreak(streamClassWriter, sectionNameSchema);

                        fieldNames.Clear();
                        //streamSchemaWriter.WriteLine();
                        //streamSchemaWriter.WriteLine();
                    }

                    if (line.StartsWith("* "))
                    {
                        fileTitle = TextToFieldName(line.Replace("*", string.Empty), true);
                    }

                    if (line.StartsWith("L ") || line.StartsWith("R "))
                    {
                        var pieces = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        var justification = pieces[0];
                        var fieldType = string.Empty;
                        var fieldLength = string.Empty;
                        var fieldPosition = 0;
                        var fieldDesc = ParseFieldName(line.Substring(fieldDescriptionStart, line.Length - fieldDescriptionStart));
                        var isDateField = fieldDesc.Contains("date", StringComparison.OrdinalIgnoreCase);                        

                        var numbersOnlyRegex = new Regex(@"^\d+");
                        if (numbersOnlyRegex.IsMatch(fieldDesc))
                        {
                            fieldDesc = fieldDesc.Replace(numbersOnlyRegex.Match(fieldDesc).Value, 
                                NumberToWords.ConvertNumberToWords(int.Parse(numbersOnlyRegex.Match(fieldDesc).Value)));                         
                        }

                        if (pieces[1].Length > 2) // The type and length are smooshed together
                        {
                            fieldType = Regex.Replace(pieces[1], "[^A-Z]+", String.Empty);
                            fieldLength = Regex.Replace(pieces[1], "[^0-9]+", String.Empty);
                            fieldPosition = int.Parse(pieces[2]);
                        }
                        else
                        {
                            fieldType = pieces[1];
                            fieldLength = pieces[2];
                            fieldPosition = int.Parse(pieces[3]);
                        }

                        if (fieldPosition == 1)
                        {
                            if (doNotWriteClassBreak)
                            {
                                doNotWriteClassBreak = false;
                            }
                            else
                            {
                                fieldNames.Clear();
                                WriteClassBreak(streamClassWriter, fileTitle);
                                WriteSchemaBreak(streamSchemaWriter, fileTitle);
                            }
                        }

                        if (fieldNames.ContainsKey(fieldDesc))
                        {
                            var increment = fieldNames[fieldDesc] + 1;
                            fieldNames[fieldDesc] = increment;
                            fieldDesc = $"{fieldDesc}{increment}";
                        }
                        else
                        {
                            fieldNames.Add(fieldDesc, 0);
                        }

                        //if (fieldType.Length > 2)
                        //{
                        //    fieldType = Regex.Replace(pieces[1], @"[^A-Z]+", string.Empty);
                        //    fieldLength = Regex.Replace(pieces[1], @"[^0-9]+", string.Empty);
                        //}

                        var schemaType = string.Empty;
                        var classType = string.Empty;
                        var inputFormat = string.Empty;

                        var mapProperty = string.Empty;

                        switch (fieldType)
                        {
                            case "AN":
                            case "A":
                                schemaType = isDateField ? "DateTimeColumn" : "StringColumn";
                                classType = isDateField ? "DateTime" : "string";
                                inputFormat = isDateField ? " { InputFormat = \"MM/dd/yyyy\" }" : string.Empty;

                                mapProperty = $"mapper.Property(x => x.{fieldDesc}, {int.Parse(fieldLength)})";

                                if (isDateField && Int32.Parse(fieldLength) <= 10)
                                {
                                    mapProperty += ".InputFormat(\"MM/dd/yyyy\")";
                                }

                                break;

                            case "N":
                                schemaType = "Int32Column";
                                classType = "int";

                                mapProperty = $"mapper.Property(x => x.{fieldDesc}, {int.Parse(fieldLength)})";

                                break;

                            default:
                                schemaType = $"WARN: {fieldType}";
                                mapProperty = $"WARN: {fieldType}";
                                break;
                        }

                        //streamSchemaWriter.WriteLine($"\t\t\tschema.AddColumn(new {schemaType}(\"{fieldDesc}\"){inputFormat}, {int.Parse(fieldLength)});");
                        streamSchemaWriter.WriteLine($"{mapProperty};");
                        streamClassWriter.WriteLine($"\t\tpublic {classType} {fieldDesc} {{ get; set; }}");
                    }
                    else
                    {
                        streamSchemaWriter.WriteLine("//{0}", line);
                    }
                }

                WriteSchemaFooter(streamSchemaWriter);
                streamSchemaWriter.Close();
                WriteClassFooter(streamClassWriter);
                streamClassWriter.Close();

                lines.Clear();
                fieldNames.Clear();
            }

            //Console.ReadKey();
        }

        private static void WriteClassHeader(StreamWriter streamClassWriter, string classTitle)
        {
            streamClassWriter.WriteLine("using System;");
            streamClassWriter.WriteLine("");
            streamClassWriter.WriteLine("namespace StraightAero.AirportData.Main");
            streamClassWriter.WriteLine("{");
            streamClassWriter.WriteLine($"\tpublic class {classTitle}");
            streamClassWriter.WriteLine("\t{");
        }

        private static void WriteClassBreak(StreamWriter streamClassWriter, string classTitle)
        {
            streamClassWriter.WriteLine("\t}");
            streamClassWriter.WriteLine("");
            streamClassWriter.WriteLine($"\tpublic class {classTitle}");
            streamClassWriter.WriteLine("\t{");
        }

        private static void WriteClassFooter(StreamWriter streamClassWriter)
        {
            streamClassWriter.WriteLine("\t}");
            streamClassWriter.WriteLine("}");
        }

        private static void WriteSchemaHeader(StreamWriter streamClassWriter, string fileTitle)
        {
            //streamClassWriter.WriteLine("using System;");
            streamClassWriter.WriteLine("using FlatFiles.TypeMapping;");
            streamClassWriter.WriteLine("");
            streamClassWriter.WriteLine("namespace StraightAero.AirportData.Main.Mappers");
            streamClassWriter.WriteLine("{");
            streamClassWriter.WriteLine($"\tpublic static class {fileTitle}Mapper");
            streamClassWriter.WriteLine("\t{");
            streamClassWriter.WriteLine($"\t\tpublic static IFixedLengthTypeMapper<{fileTitle}> Get{fileTitle}Mapper()");
            streamClassWriter.WriteLine("\t\t{");
            streamClassWriter.WriteLine($"\t\t\tvar mapper = FixedLengthTypeMapper.Define(() => new {fileTitle}());");
        }

        private static void WriteSchemaBreak(StreamWriter streamClassWriter, string fileTitle)
        {
            streamClassWriter.WriteLine("\t\t\treturn mapper;");
            streamClassWriter.WriteLine("\t\t}");
            streamClassWriter.WriteLine($"\t\tpublic static IFixedLengthTypeMapper<{fileTitle}> Get{fileTitle}Mapper()");
            streamClassWriter.WriteLine("\t\t{");
            streamClassWriter.WriteLine($"\t\t\tvar mapper = FixedLengthTypeMapper.Define(() => new {fileTitle}());");
        }

        private static void WriteSchemaFooter(StreamWriter streamClassWriter)
        {
            streamClassWriter.WriteLine("\t\t\treturn mapper;");
            streamClassWriter.WriteLine("\t\t}");
            streamClassWriter.WriteLine("\t}");
            streamClassWriter.WriteLine("}");
        }

        public static string TextToFieldName(string description, bool spacesBetweenLetters = false)
        {
            if (spacesBetweenLetters)
            {
                description = description.Replace("  ", "~")
                    .Replace(" ", string.Empty)
                    .Replace("~", " ");
            }

            var textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(description.Trim().ToLower()).Replace(" ", string.Empty);
        }

        public static bool IsAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[\w\s,]+$");
            return rg.IsMatch(strToCheck);
        }

        public static void ParseTitle(List<string> lines, ref string title, ref string outSchemaFileTitle, ref string outClassFileTitle)
        {
            foreach (var line in lines)
            {
                if ((!string.IsNullOrWhiteSpace(line) && IsAlphaNumeric(line)) && string.IsNullOrEmpty(title))
                {
                    title = TextToFieldName(line);
                    outSchemaFileTitle = $"{title}Schema.cs";
                    outClassFileTitle = $"{title}.cs";
                    //Console.WriteLine($"Title: {title}");
                    break;
                }
            }
        }

        public static string ParseFieldName(string description)
        {
            if (!IsAlphaNumeric(description))
            {
                return TextToFieldName(Regex.Replace(description, @"[^A-Z0-9 ]+", String.Empty))
                    .Replace("Mmddyyyy", string.Empty);

                //var re = new Regex("^([a-z ]+)", RegexOptions.IgnoreCase);
                //var m = re.Match(description);

                //if (m.Success)
                //{
                //    description = m.Captures[0].Value;
                //}
                //else
                //{
                //    Console.WriteLine($"FAIL: {description}");
                //    description = ReplaceOddFieldName(description);
                //}
            }

            return TextToFieldName(description);
        }

        public static string ReplaceOddFieldName(string description)
        {
            switch (description)
            {
                case "12-MONTH ENDING DATE ON WHICH ANNUAL OPERATIONS DATA":
                    return "ANNUAL OPERATIONS DATA END DATE";

                case "3 OR 4 LETTER IDENT*FACILITY TYPE*DIRECTION OR":
                    return "FACILITY TYPE DIRECTION IDENT";

                case "3 OR 4 LETTER IDENT*FACILITY TYPE*DIRECTION OR COURSE":
                    return "FACILITY TYPE DIRECTION IDENT OR COURSE";                

                default:
                    if (description.StartsWith("/RADAR/ OR /NON-RADAR/"))
                    {
                        return description.Replace("/", string.Empty).Replace("-", " ");
                    }

                    return string.Empty;
            }
        }
    }
}
