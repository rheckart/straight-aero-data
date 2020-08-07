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

            var client = new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            var database = await client.CreateDatabaseIfNotExistsAsync("StraightAero");
            var container = await database.Database.CreateContainerIfNotExistsAsync(
                "FAAData",
                "/RecordTypeIndicator",
                400);

            var path = @"C:\Users\rheck\Downloads\28DaySubscription_Effective_2020-01-30";

            Console.WriteLine("Processing LandingFacilityData");
            //await ProcessLandingFacilityData(container, path);

            Console.WriteLine("Processing Navaids");
            await ProcessNavaidData(container, path);
        }

        private static async Task ProcessLandingFacilityData(ContainerResponse container, string path)
        {
            var selector = new FixedLengthTypeMapperSelector();
            selector.When(s => s.StartsWith("APT")).Use(LandingFacilityMapper.GetLandingFacilityDataMapper());
            selector.When(s => s.StartsWith("ATT"))
                .Use(LandingFacilityMapper.GetFacilityAttendanceScheduleDataMapper());
            selector.When(s => s.StartsWith("RWY")).Use(LandingFacilityMapper.GetFacilityRunwayDataMapper());
            selector.When(s => s.StartsWith("ARS"))
                .Use(LandingFacilityMapper.GetRunwayArrestingSystemDataMapper());
            selector.When(s => s.StartsWith("RMK")).Use(LandingFacilityMapper.GetFacilityRemarkDataMapper());

            var mapit = new StringBuilder();
            using var reader = new StreamReader(File.OpenRead($@"{path}\APT.txt"));

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

        private static async Task ProcessNavaidData(ContainerResponse container, string path)
        {
            var selector = new FixedLengthTypeMapperSelector();
            selector.When(s => s.StartsWith("NAV1")).Use(NavaidMapper.GetNavaidMapper());
            selector.When(s => s.StartsWith("NAV2"))
                .Use(NavaidMapper.GetNavaidRemarksMapper());
            selector.When(s => s.StartsWith("NAV3")).Use(NavaidMapper.GetAirspaceFixesAssociatedWithNavaidMapper());
            selector.When(s => s.StartsWith("NAV4"))
                .Use(NavaidMapper.GetHoldingPatternMapper());
            selector.When(s => s.StartsWith("NAV5")).Use(NavaidMapper.GetFanmarkerMapper());
            selector.When(s => s.StartsWith("NAV6")).Use(NavaidMapper.GetReceiverCheckpointMapper());

            var mapit = new StringBuilder();
            using var reader = new StreamReader(File.OpenRead($@"{path}\NAV.txt"));

            var flr = selector.GetReader(reader);

            Navaid navaid = null;

            while (flr.Read())
            {
                switch (flr.Current)
                {
                    case Navaid navaidData:

                        if (navaid != null)
                        {
                            if (Coordinate.TryParse($"{navaid.NavaidLongitudeFormatted} {navaid.NavaidLatitudeFormatted}", out Coordinate c))
                            {
                                navaid.Location = new Point(c.Longitude.DecimalDegree, c.Latitude.DecimalDegree);
                            }

                            navaid.id = $"{navaid.NavaidFacilityIdentifier}|{navaid.NavaidFacilityType.Replace("/", string.Empty)}|{navaid.CityAssociatedWithTheNavaid}";
                            navaid.RecordTypeIndicator = "NAVAID";

                            try
                            {
                                var readResponse = await container.Container.ReadItemAsync<Navaid>(navaid.id, new PartitionKey("NAVAID"));
                                var replaceResponse = await container.Container.ReplaceItemAsync<Navaid>(navaid, navaid.id, new PartitionKey("NAVAID"));

                                Console.WriteLine($"Replaced {navaid.NavaidFacilityIdentifier}");
                            }
                            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
                            {
                                // Save the record to the DB
                                var navaidResponse = await container.Container.CreateItemAsync<Navaid>(navaid, new PartitionKey("NAVAID"));

                                Console.WriteLine($"Created {navaid.NavaidFacilityIdentifier}");
                            }


                        }

                        navaid = navaidData;

                        break;

                    case NavaidRemark remark:

                        navaid.Remarks ??= new List<NavaidRemark>();
                        navaid.Remarks.Add(remark);

                        break;

                    case AirspaceFixAssociatedWithNavaid asf:

                        navaid.AirspaceFixes ??= new List<AirspaceFixAssociatedWithNavaid>();
                        navaid.AirspaceFixes.Add(asf);

                        break;

                    case HoldingPattern holdingPattern:

                        navaid.HoldingPatterns ??= new List<HoldingPattern>();
                        navaid.HoldingPatterns.Add(holdingPattern);

                        break;

                    case FanMarkerAssociatedwithnavaid fanMarker:

                        navaid.FanMarkers ??= new List<FanMarkerAssociatedwithnavaid>();
                        navaid.FanMarkers.Add(fanMarker);

                        break;

                    case VorReceiverCheckpointAssociatedWithNavaid rcvr:

                        navaid.VorReceivers ??= new List<VorReceiverCheckpointAssociatedWithNavaid>();
                        navaid.VorReceivers.Add(rcvr);

                        break;

                    default:

                        throw new Exception("Not found");
                }
            }
        }
    }
}
