# FAA Aeronautical Data
This project takes FAA Aeronautical Data from the [28-day NASR Subscription](https://www.faa.gov/air_traffic/flight_info/aeronav/aero_data/NASR_Subscription/) and:

- Inside the StraightAero.AirportData.Schema.Importer project, the Layouts in the Layout_Data folder are used to:
   - Generate schemas for import using the [FlatFiles Nuget package](https://github.com/jehugaleahsa/FlatFiles),
   - Generate classes for import using FlatFiles.
- Inside the StraightAero.Data.Importer project, the schema files and classes are used to write data into a CosmosDB database.
   - This uses the [CoordinateSharp Nuget package](https://github.com/Tronald/CoordinateSharp) to take the lat/long for an airport and make CosmosDB Geography Points for them

The Schema Importer is a console app that takes 3 command-line arguments:

- path: the path to the downloaded & extracted FAA files,
- schema: where the generated schema files should be written to,
- classes: where the generated schema files should be written to.
