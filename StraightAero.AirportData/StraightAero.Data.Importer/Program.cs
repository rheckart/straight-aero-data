using System;
using System.IO;
using System.Reflection;
using System.Text;
using FlatFiles;
using FlatFiles.TypeMapping;
using StraightAero.AirportData.Main;
using StraightAero.AirportData.Main.Mappers;

namespace StraightAero.Data.Importer
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            var selector = new FixedLengthTypeMapperSelector();
            selector.When(s => s.StartsWith("APT")).Use(LandingFacilityMapper.GetLandingFacilityDataMapper());
            selector.When(s => s.StartsWith("ATT"))
                .Use(LandingFacilityMapper.GetFacilityAttendanceScheduleDataMapper());
            selector.When(s => s.StartsWith("RWY")).Use(LandingFacilityMapper.GetFacilityRunwayDataMapper());
            selector.When(s => s.StartsWith("ARS"))
                .Use(LandingFacilityMapper.GetRunwayArrestingSystemDataMapper());
            selector.When(s => s.StartsWith("RMK")).Use(LandingFacilityMapper.GetFacilityRemarkDataMapper());

            var mapit = new StringBuilder();

            using var reader = new StreamReader(File.OpenRead(@"C:\Users\rheck\Downloads\28DaySubscription_Effective_2020-01-30\APT.txt"));
            
            var flr = selector.GetReader(reader);

            LandingFacilityData airport;

            while (flr.Read())
            {
                var test = flr.Current;

                if (test is LandingFacilityData)
                {
                    airport = (LandingFacilityData)test;
                }
                //var values = flr.GetValues();

                //if (values != null)
                //{
                //    if ((string)values[0] == "APT")
                //    {
                //        //var lfMapper = FixedLengthTypeMapper.Define<LandingFacility>();
                //        //var schema = mapper.GetSchema();
                //        //lfMapper.

                //        //ProcessAirport(airport, values);                            

                //        //Console.WriteLine($"New Airport: {(string)values[3]}");
                //    }
                //}
            }
        }

        //private static void ProcessAirport(LandingFacility airport, object[] values)
        //{
        //    airport.LandingFacilitySiteNumber = (string)values[1];
        //    airport.LandingFacilityType = (string)values[2];
        //    airport.LocationIdentifier = (string)values[3];
        //}
    }
}
