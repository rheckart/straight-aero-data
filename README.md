# FAA Aeronautical Data
This project takes FAA Aeronautical Data from the [28-day NASR Subscription](https://www.faa.gov/air_traffic/flight_info/aeronav/aero_data/NASR_Subscription/) and:

- Inside the StraightAero.AirportData.Schema.Importer project, the Layouts in the Layout_Data folder are used to:
   - Generate schemas for import using the [FlatFiles Nuget package](https://github.com/jehugaleahsa/FlatFiles),
   - Generate classes for import using FlatFiles.
- Inside the StraightAero.Data.Importer project, the schema files and classes are used to write data into a CosmosDB database.
