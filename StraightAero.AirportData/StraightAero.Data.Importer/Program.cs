using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FlatFiles;
using FlatFiles.TypeMapping;
using Microsoft.Azure.Cosmos;
using StraightAero.AirportData.Main;
using StraightAero.AirportData.Main.Mappers;
using CoordinateSharp;
using Microsoft.Azure.Cosmos.Spatial;
using System.Net;

namespace StraightAero.Data.Importer
{
    static class Program
    {
        async static Task Main(string[] args)
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

            var client = new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            var database = await client.CreateDatabaseIfNotExistsAsync("StraightAero");
            var container = await database.Database.CreateContainerIfNotExistsAsync(
                "FAAData",
                "/RecordTypeIndicator",
                400);

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
                            if (Coordinate.TryParse($"{airport.AirportReferencePointLongitudeFormatted} {airport.AirportReferencePointLatitudeFormatted}", out Coordinate c))
                            {
                                airport.Location = new Point(c.Longitude.DecimalDegree, c.Latitude.DecimalDegree);
                            }

                            airport.id = $"{airport.LandingFacilitySiteNumber}|{airport.LandingFacilityType}";

                            try
                            {
                                var readResponse = await container.Container.ReadItemAsync<LandingFacilityData>(airport.id, new PartitionKey(airport.RecordTypeIndicator));
                                var replaceResponse = await container.Container.ReplaceItemAsync<LandingFacilityData>(airport, airport.id, new PartitionKey(airport.RecordTypeIndicator));

                                Console.WriteLine($"Replaced {airport.LocationIdentifier}");
                            }
                            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
                            {
                                // Save the record to the DB
                                var airportResponse = await container.Container.CreateItemAsync<LandingFacilityData>(airport, new PartitionKey(airport.RecordTypeIndicator));

                                Console.WriteLine($"Created {airport.LocationIdentifier}");
                            }


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
