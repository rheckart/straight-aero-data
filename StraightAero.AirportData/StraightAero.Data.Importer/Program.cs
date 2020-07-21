using System;
using System.Collections.Generic;
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

            LandingFacilityData airport = null;

            while (flr.Read())
            {
                switch (flr.Current)
                {
                    case LandingFacilityData landingFacilityData:

                        if (airport != null)
                        {
                            // Save the record to the DB
                            Console.WriteLine($"{airport.LocationIdentifier}");
                        }

                        airport = landingFacilityData;

                        break;

                    case FacilityAttendanceScheduleData fa:

                        airport.AttendanceSchedule ??= new List<FacilityAttendanceScheduleData>();
                        airport.AttendanceSchedule.Add(fa);

                        break;

                    case FacilityRunwayData runway:

                        airport.Runways ??= new List<FacilityRunwayData>();
                        airport.Runways.Add(runway);

                        break;

                    case RunwayArrestingSystemData ras:

                        airport.ArrestingSystems ??= new List<RunwayArrestingSystemData>();
                        airport.ArrestingSystems.Add(ras);

                        break;

                    case FacilityRemarkData remark:

                        airport.Remarks ??= new List<FacilityRemarkData>();
                        airport.Remarks.Add(remark);

                        break;

                    default:

                        throw new Exception("Not found");
                }
            }
        }
    }
}
