using System;
using System.IO;
using FlatFiles;
using FlatFiles.TypeMapping;
using StraightAero.AirportData.Main;
using StraightAero.AirportData.Main.Schemas;

namespace StraightAero.Data.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            var selector = new FixedLengthSchemaSelector();
            selector.When(s => s.StartsWith("APT")).Use(LandingFacilitySchema.GetSchema());
            selector.When(s => s.StartsWith("ATT"))
                .Use(LandingFacilitySchema.GetFacilityAttendanceScheduleSchema());
            selector.When(s => s.StartsWith("RWY")).Use(LandingFacilitySchema.GetRunwaySchema());
            selector.When(s => s.StartsWith("ARS"))
                .Use(LandingFacilitySchema.GetRunwayArrestingSystemSchema());
            selector.When(s => s.StartsWith("RMK")).Use(LandingFacilitySchema.GetRemarkSchema());

            using (var reader = new StreamReader(File.OpenRead(@"C:\Users\rheck\Downloads\28DaySubscription_Effective_2020-01-30\APT.txt")))
            {
                var flr = new FixedLengthReader(reader, selector);
                
                while (flr.Read())
                {
                    var values = flr.GetValues();
                    var airport = new LandingFacility();

                    if (values != null)
                    {
                        if ((string)values[0] == "APT")
                        {
                            ProcessAirport(airport, values);                            
                            
                            Console.WriteLine($"New Airport: {(string)values[3]}");
                        }
                    }
                }
            }
        }

        private static void ProcessAirport(LandingFacility airport, object[] values)
        {
            airport.LandingFacilitySiteNumber = (string)values[1];
            airport.LandingFacilityType = (string)values[2];
            airport.LocationIdentifier = (string)values[3];
        }
    }
}
