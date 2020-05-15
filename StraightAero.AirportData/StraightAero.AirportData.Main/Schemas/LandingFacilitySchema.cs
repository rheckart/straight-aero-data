using FlatFiles;

namespace StraightAero.AirportData.Main.Schemas
{
	public class LandingFacilitySchema
	{
		public static FixedLengthSchema GetSchema()
		{
			var schema = new FixedLengthSchema();
			//                             LANDING FACILITY
			//                         DATA BASE RECORD LAYOUT
			//                               (APT-FILE)
			//
			//
			//
			//INFORMATION EFFECTIVE DATE: 07/19/2018 CHARTING CYCLE
			//
			//    RECORD FORMAT: FIXED
			//    LOGICAL RECORD LENGTH: 1529
			//
			//
			//
			//FILE STRUCTURE DESCRIPTION:
			//---------------------------
			//
			//    THERE ARE A VARIABLE NUMBER OF FIXED-LENGTH RECORDS FOR
			//    EACH LANDING FACILITY.  THE NUMBER OF RECORDS IS DETERMINED
			//    BY THE NUMBER OF RUNWAYS AND REMARKS ASSOCIATED WITH THE FACILITY.
			//    THE RECORDS ARE IDENTIFIABLE BY A RECORD TYPE INDICATOR
			//    (APT, ATT, RWY, ARS, OR RMK), AND LANDING FACILITY SITE NUMBER.
			//
			//    THE FILE IS SORTED BY STATE, SITE NUMBER (IMPLIES CITY AND
			//    STATE), AND RECORD TYPE (APT THEN ATT THEN RWY THEN ARS THEN RMK).
			//    RUNWAY RECORDS ARE FURTHER SORTED BY THE RUNWAY DESIGNATION.
			//    ARRESTING SYSTEM RECORDS ARE FURTHER SORTED BY THE RUNWAY
			//    DESIGNATION AND THE RUNWAY END DESIGNATION.
			//    REMARK RECORDS ARE FURTHER SORTED BY REMARK ELEMENT NAME.
			//
			//    EACH RECORD ENDS WITH A CARRIAGE RETURN CHARACTER AND LINE FEED
			//    CHARACTER (CR/LF). THIS LINE TERMINATOR IS NOT INCLUDED IN THE
			//    LOGICAL RECORD LENGTH.
			//
			//DESCRIPTION OF THE RECORD TYPES:
			//--------------------------------
			//
			//    'APT' RECORDS CONTAIN THE BASIC LANDING FACILITY INFORMATION.
			//    IT DESCRIBES LOCATION, OWNERSHIP, FACILITIES, SERVICES, AND
			//    ACTIVITIES INFORMATION RELATED TO THE LANDING FACILITY. THERE
			//    IS ALWAYS ONE 'APT' RECORD FOR A LANDING FACILITY.
			//
			//    'ATT' RECORDS CONTAIN TEXT DESCRIBING THE AIRPORT ATTENDANCE SCHEDULE
			//    WHEN MINIMUM SERVICES ARE AVAILABLE.  EACH 'ATT' RECORD CONTAINS ONE
			//    SET OF MONTHS, DAYS, AND HOURS WHEN THE AIRPORT IS ATTENDED.
			//    THERE MAY BE NONE, ONE, OR MANY ATTENDANCE SCHEDULE RECORDS FOR
			//    A LANDING FACILITY.
			//
			//    'RWY' RECORDS CONTAIN INFORMATION RELATED TO ONE RUNWAY AT THE
			//    LANDING FACILITY (AIRPORT SITE) IDENTIFIED IN THE PREVIOUS 'APT'
			//    RECORD.  ALL INFORMATION FOR A RUNWAY IS IN ONE 'RWY' RECORD.
			//    INFORMATION IS CATEGORIZED BY THAT WHICH APPLIES TO THE ENTIRE
			//    RUNWAY AND THAT WHICH APPLIES TO THE BASE AND RECIPROCAL ENDS
			//    OF THE RUNWAY. THERE IS ONE 'RWY' RECORD FOR EACH RUNWAY AT
			//    THE LANDING FACILITY. THERE WILL ALWAYS BE AT LEAST ONE 'RWY'
			//    RECORD FOR A LANDING FACILITY.
			//
			//    'ARS' RECORDS CONTAIN INFORMATION RELATED TO ONE ARRESTING SYSTEM
			//    LOCATED AT A PARTICULAR RUNWAY END AT THE LANDING FACILITY IDENTIFIED
			//    IN THE PREVIOUS 'APT' RECORD.  THERE MAY BE NONE, ONE, OR MANY
			//    ARRESTING SYSTEM RECORDS FOR A LANDING FACILITY AND ANY OF ITS
			//    RUNWAYS.
			//
			//    'RMK' RECORDS CONTAIN TEXTUAL REMARKS PERTAINING TO THE LANDING
			//    FACILITY OR ITS RUNWAYS. REMARKS CAN BE GENERAL IN NATURE OR
			//    RELATE TO SPECIFIC AIRPORT OR RUNWAY DATA ITEMS. EACH 'RMK'
			//    RECORD CONTAINS ONE TEXTUAL REMARK. THERE MAY BE NONE, ONE,
			//    OR MANY REMARK RECORDS FOR A LANDING FACILITY.
			//
			//
			//GENERAL INFORMATION:
			//--------------------
			//
			//    1.  LEFT JUSTIFIED FIELDS HAVE TRAILING BLANKS
			//
			//    2.  RIGHT JUSTIFIED (R AN) FIELDS HAVE LEADING BLANKS
			//
			//    3.  RIGHT JUSTIFIED NUMERIC (R N) FIELDS HAVE LEADING ZEROS
			//        WHEN DATA IS AVAILABLE. OTHERWISE, THE FIELD IS BLANK.
			//
			//    4.  ELEMENT NUMBER IS FOR INTERNAL REFERENCE ONLY AND IS NOT
			//        IN THE RECORD.
			//
			//    5.  THE TERMS 'AIRPORT' AND 'LANDING FACILITY' ARE USED
			//        SYNONYMOUSLY IN THIS DOCUMENT.
			//
			//    6.  LATITUDE AND LONGITUDE INFORMATION IS REPRESENTED IN
			//         TWO WAYS:
			//         A. A19,A20,E68,E69,E161,E162,E164,E165 ARE FORMATTED
			//            LAT/LONG VALUES AND ARE REPRESENTED AS FOLLOWS:
			//
			//            LATITUDE    DD-MM-SS.SSSSH
			//            LONGITUDE   DDD-MM-SS.SSSSH
			//
			//            WHERE :     DD IS DEGREES
			//                        MM IS MINUTES
			//                        SS.SSSS IS SECONDS, AND TEN THOUSANDTHS OF SECONDS-
			//                        H IS DECLINATION
			//
			//            EXAMPLE :   LAT-   39-06-51.0701N
			//                        LONG-  075-27-54.6601W
			//
			//          B. A19S,A20S,E68S,E69S,E161S,E162S,E164S,E165S
			//             ARE LAT/LONG VALUES CONVERTED TO ALL SECONDS AS FOLLOWS:
			//
			//             LATITUDE AND LONGITUDE     SSSSSS.SSSSH
			//             WHERE :    SSSSSS.SSSS IS THE DEG/MIN/SEC CONVERTED
			//                                   TO ALL SECONDS
			//                        H IS THE DECLINATION
			//
			//      EXAMPLE:  LAT-   140811.0701N
			//                LONG-  271674.6601W
			//
			//    7.  A LIMITED NUMBER OF NON-US LANDING FACILITIES ARE INCLUDED IN THIS
			//        FILE. SOME OF THESE, IN PARTICULAR THE CANADIAN FACILITIES, ARE
			//        INCLUDED TO FACILITATE CARTOGRAPHIC REQUIREMENTS IN BORDER REGIONS.
			//        THESE RECORDS ARE NOT GUARANTEED TO BE COMPLETE AND ARE NOT INCLUSIVE
			//        OF ALL CANADIAN FACILITIES. THIS FILE SHOULD NOT BE CONSIDERED OFFICIAL
			//        SOURCE FOR NON-US FACILITIES.
			//
			//
			//
			//J  T   L   S L   E N
			//U  Y   E   T O   L U
			//S  P   N   A C   E M
			//T  E   G   R A   M B
			//       T   T T   E E
			//       H     I   N R
			//             O   T


			//             N           FIELD DESCRIPTION
			//************************************************************************
			//*          L A N D I N G   F A C I L I T Y   D A T A                   *
			//************************************************************************
			//
			schema.AddColumn(new StringColumn("RecordTypeIndicator"), 3);
			//                            APT: BASIC LANDING FACILITY DATA
			//
			schema.AddColumn(new StringColumn("LandingFacilitySiteNumber"), 11);
			//                            A UNIQUE IDENTIFYING NUMBER WHICH,
			//                            TOGETHER WITH THE LANDING FACILITY TYPE CODE,
			//                            FORMS THE KEY TO THE AIRPORT RECORD.
			//                            FILE.  EXAMPLE: 04508.*A
			//
			//
			//
			schema.AddColumn(new StringColumn("LandingFacilityType"), 13);
			//
			//                            AIRPORT
			//                            BALLOONPORT
			//                            SEAPLANE BASE
			//                            GLIDERPORT
			//                            HELIPORT
			//                            ULTRALIGHT
			//
			schema.AddColumn(new StringColumn("LocationIdentifier"), 4);
			//                            UNIQUE 3-4 CHARACTER ALPHANUMERIC IDENTIFIER
			//                            ASSIGNED TO THE LANDING FACILITY.
			//                            (EX. 'ORD' FOR CHICAGO O'HARE)
			schema.AddColumn(new DateTimeColumn("InformationEffectiveDate") { InputFormat = "MM/dd/yyyy" }, 10);
			//                            THIS DATE COINCIDES WITH THE 56-DAY
			//                            CHARTING AND PUBLICATION CYCLE DATE.
			//
			//                         -----------------------------------------------
			//                                    DEMOGRAPHIC DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("FaaRegionCode"), 3);
			//                            CODE           REGION NAME
			//                            ----           -----------
			//                            AAL            ALASKA
			//                            ACE            CENTRAL
			//                            AEA            EASTERN
			//                            AGL            GREAT LAKES
			//                            AIN            INTERNATIONAL
			//                            ANE            NEW ENGLAND
			//                            ANM            NORTHWEST MOUNTAIN
			//                            ASO            SOUTHERN
			//                            ASW            SOUTHWEST
			//                            AWP            WESTERN-PACIFIC
			//
			schema.AddColumn(new StringColumn("FaaDistrictOrFieldOfficeCode"), 4);
			//                            (EX. CHI)
			schema.AddColumn(new StringColumn("AssociatedStatePostOfficeCode"), 2);
			//                            STANDARD TWO LETTER ABBREVIATION
			//                            FOR U.S. STATES AND TERRITORIES
			//                            (EX. IL,PR,CQ)
			schema.AddColumn(new StringColumn("AssociatedStateName"), 20);
			//                            (EX. ILLINOIS)
			schema.AddColumn(new StringColumn("AssociatedCountyOrParishName"), 21);
			//                            (EX. COOK)
			//                            (FOR NON-US AREODROMES THIS MAY BE
			//                            TERRITORY OR PROVINCE NAME)
			schema.AddColumn(new StringColumn("AssociatedCountysStatePostOfficeCode"), 2);
			//                            STATE WHERE THE ASSOCIATED COUNTY IS
			//                            LOCATED; MAY NOT BE THE SAME AS THE
			//                            ASSOCIATED CITY'S STATE CODE.
			//                            (EX. IL)
			//
			//                            FOR NON-US AERODROME FACILITIES, THESE
			//                            "STATE" CODES ARE INTERNAL TO THIS SYSTEM AND MAY
			//                            NOT CORRESPOND TO STANDARD STATE OR COUNTRY CODES
			//                            IN USE ELSEWHERE. NONSTANDARD
			//                            "COUNTY_ASSOCIATED_STATE" AND "COUNTY" NAMES
			//                            CURRENTLY IN USE INCLUDE:
			//
			//                               COUNTY_ASSOC_STATE  COUNTY NAME
			//                               ------------------  ---------------------
			//                               AI                  ANGUILLA
			//                               AN                  NETHERLANDS ANTILLES
			//                               AS                  AMERICAN SAMOA
			//                               BL                  SAINT BARTHELEMY     
			//                               BM                  BERMUDA
			//                               BS                  BAHAMAS
			//                               CN                  B.C., CANADA
			//                               CN                  QUEBEC, CANADA
			//                               CN                  P.E.I., CANADA
			//                               CN                  ALBERTA, CANADA
			//                               CN                  ONTARIO, CANADA
			//                               CN                  NUNAVUT, CANADA
			//                               CN                  MANITOBA, CANADA
			//                               CN                  YUKON TERR, CANADA
			//                               CN                  NOVA SCOTIA, CANADA
			//                               CN                  SASKATCHEWAN, CANADA
			//                               CN                  NEWFOUNDLAND, CANADA
			//                               CN                  NORTHWEST TERR,CANADA
			//                               CN                  NEW BRUNSWICK, CANADA
			//                               FM                  FED STS MICRONESIA
			//                               GL                  GREENLAND
			//                               GP                  GUADELOUPE
			//                               GU                  GUAM
			//                               IO                  BRITISH INDIAN OCEAN
			//                               IQ                  US MISC PACIFIC IS
			//                               MF                  SAINT MARTIN
			//                               MH                  MARSHALL ISLANDS
			//                               MP                  N MARIANA ISLANDS
			//                               MQ                  MIDWAY ISLANDS
			//                               PW                  PALAU
			//                               SH                  SAINT HELENA
			//                               TC                  TURKS AND CAICOS
			//                               TQ                  -TRUST TERR. OF PAC-
			//                               VG                  VIRGIN ISLANDS, BRIT
			//                               VI                  VIRGIN ISLANDS
			//                               WQ                  WAKE ISLAND
			//
			//
			schema.AddColumn(new StringColumn("AssociatedCityName"), 40);
			//                            (EX. CHICAGO)
			schema.AddColumn(new StringColumn("OfficialFacilityName"), 50);
			//                            (EX. CHICAGO O'HARE INTL)
			//
			//                         -----------------------------------------------
			//                                    OWNERSHIP DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("AirportOwnershipType"), 2);
			//                            PU - PUBLICLY OWNED
			//                            PR - PRIVATELY OWNED
			//                            MA - AIR FORCE OWNED
			//                            MN - NAVY OWNED
			//                            MR - ARMY OWNED
			//                            CG - COAST GUARD OWNED
			schema.AddColumn(new StringColumn("FacilityUse"), 2);
			//                            PU - OPEN TO THE PUBLIC
			//                            PR - PRIVATE
			schema.AddColumn(new StringColumn("FacilityOwnersName"), 35);
			schema.AddColumn(new StringColumn("OwnersAddress"), 72);
			schema.AddColumn(new StringColumn("OwnersCityStateAndZipCode"), 45);
			schema.AddColumn(new StringColumn("OwnersPhoneNumber"), 16);
			//                           DATA FORMATS:
			//                             NNN-NNN-NNNN  (AREA CODE + PHONE NUMBER)
			//                             1-NNN-NNNN    (DIAL 1-800 THEN NUMBER)
			//                             8-NNN-NNNN    (DIAL 800 THEN NUMBER)
			//
			schema.AddColumn(new StringColumn("FacilityManagersName"), 35);
			schema.AddColumn(new StringColumn("ManagersAddress"), 72);
			schema.AddColumn(new StringColumn("ManagersCityStateAndZipCode"), 45);
			schema.AddColumn(new StringColumn("ManagersPhoneNumber"), 16);
			//                           DATA FORMATS:
			//                             NNN-NNN-NNNN  (AREA CODE + PHONE NUMBER)
			//                             1-NNN-NNNN    (DIAL 1-800 THEN NUMBER)
			//                             8-NNN-NNNN    (DIAL 800 THEN NUMBER)
			//
			//                         -----------------------------------------------
			//
			//                                         GEOGRAPHIC DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("AirportReferencePointLatitudeFormatted"), 15);
			schema.AddColumn(new StringColumn("AirportReferencePointLatitudeSeconds"), 12);
			schema.AddColumn(new StringColumn("AirportReferencePointLongitudeFormatted"), 15);
			schema.AddColumn(new StringColumn("AirportReferencePointLongitudeSeconds"), 12);
			schema.AddColumn(new StringColumn("AirportReferencePointDeterminationMethod"), 1);
			//                            E - ESTIMATED
			//                            S - SURVEYED
			schema.AddColumn(new StringColumn("AirportElevationNearestTenthOfAFootMsl"), 7);
			//                            ELEVATION IS MEASURED AT THE HIGHEST POINT
			//                            ON THE CENTERLINE OF THE USABLE LANDING
			//                            SURFACE
			//                            (EX. 1200.5; -10.0 FOR 10 FEET BELOW SEA LEVEL)
			schema.AddColumn(new StringColumn("AirportElevationDeterminationMethod"), 1);
			//                            E - ESTIMATED
			//                            S - SURVEYED
			schema.AddColumn(new StringColumn("MagneticVariationAndDirection"), 3);
			//                            MAGNETIC VARIATION TO NEAREST DEGREE
			//                            (EX. 03W)
			schema.AddColumn(new StringColumn("MagneticVariationEpochYear"), 4);
			//                            (EX. 1985)
			schema.AddColumn(new StringColumn("TrafficPatternAltitudeWholeFeetAgl"), 4);
			//                            (EX. 1000)
			schema.AddColumn(new StringColumn("AeronauticalSectionalChartOnWhichFacility"), 30);
			//                         APPEARS. (EX. WASHINGTON)
			schema.AddColumn(new StringColumn("DistanceFromCentralBusinessDistrictOf"), 2);
			//                         THE ASSOCIATED CITY TO THE AIRPORT
			//                            (NEAREST NAUTICAL MILE - EX. 08)
			schema.AddColumn(new StringColumn("DirectionOfAirportFromCentralBusiness"), 3);
			//                         DISTRICT OF ASSOCIATED CITY
			//                            (NEAREST 1/8 COMPASS POINT - EX. NE)
			schema.AddColumn(new StringColumn("LandAreaCoveredByAirportAcres"), 5);
			//
			//                         -----------------------------------------------
			//                                   FAA SERVICES
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("BoundaryArtccIdentifier"), 4);
			//                            THE BOUNDARY ARTCC IS THE FAA AIR ROUTE
			//                            TRAFFIC CONTROL CENTER WITHIN WHOSE
			//                            PUBLISHED BOUNDARIES THE AIRPORT LIES.
			//                            IT MAY NOT BE THE RESPONSIBLE ARTCC.
			//                            (EX. ZDC FOR WASHINGTON ARTCC)
			schema.AddColumn(new StringColumn("BoundaryArtccFaaComputerIdentifier"), 3);
			//                            (EX. ZCW FOR WASHINGTON ARTCC)
			schema.AddColumn(new StringColumn("BoundaryArtccName"), 30);
			//                            (EX. WASHINGTON)
			schema.AddColumn(new StringColumn("ResponsibleArtccIdentifier"), 4);
			//                            THE RESPONSIBLE ARTCC IS THE FAA AIR ROUTE
			//                            TRAFFIC CONTROL CENTER WHO HAS CONTROL
			//                            OVER THE AIRPORT.
			//                            (EX. ZDC FOR WASHINGTON ARTCC)
			schema.AddColumn(new StringColumn("ResponsibleArtccFaaComputerIdentifier"), 3);
			//                            (EX. ZCW FOR WASHINGTON ARTCC)
			schema.AddColumn(new StringColumn("ResponsibleArtccName"), 30);
			//                            (EX. WASHINGTON)
			schema.AddColumn(new StringColumn("TieinFssPhysicallyLocatedOnFacility"), 1);
			//                            Y - TIE-IN FSS IS ON THE AIRPORT
			//                            N - TIE-IN FSS IS NOT ON AIRPORT
			schema.AddColumn(new StringColumn("TieinFlightServiceStationFssIdentifier"), 4);
			//                            (EX. DCA FOR WASHINGTON FSS)
			schema.AddColumn(new StringColumn("TieinFssName"), 30);
			//                            (EX. WASHINGTON)
			schema.AddColumn(new StringColumn("LocalPhoneNumberFromAirportToFss"), 16);
			//                         FOR ADMINISTRATIVE SERVICES
			schema.AddColumn(new StringColumn("TollFreePhoneNumberFromAirportToFss"), 16);
			//                         FOR PILOT BRIEFING SERVICES
			schema.AddColumn(new StringColumn("AlternateFssIdentifier"), 4);
			//                            PROVIDES THE IDENTIFIER OF A FULL-TIME
			//                            FLIGHT SERVICE STATION THAT ASSUMES
			//                            RESPONSIBILITY FOR THE AIRPORT DURING THE OFF
			//                            HOURS OF A PART-TIME PRIMARY FSS.
			//                            (EX. 'DCA' FOR WASHINGTON FSS)
			schema.AddColumn(new StringColumn("AlternateFssName"), 30);
			//                            (EX. 'WASHINGTON' FOR WASHINGTON FSS)
			schema.AddColumn(new StringColumn("TollFreePhoneNumberFromAirportTo"), 16);
			//                         ALTERNATE FSS FOR PILOT BRIEFING SERVICES
			schema.AddColumn(new StringColumn("IdentifierOfTheFacilityResponsibleFor"), 4);
			//                         ISSUING NOTICES TO AIRMEN (NOTAMS) AND
			//                         WEATHER INFORMATION FOR THE AIRPORT
			//                            (EX. ORD)
			schema.AddColumn(new StringColumn("AvailabilityOfNotamDServiceAtAirport"), 1);
			//                            Y - YES
			//                            N - NO
			//
			//                         -----------------------------------------------
			//                                 FEDERAL STATUS
			//                         -----------------------------------------------
			//
			schema.AddColumn(new DateTimeColumn("AirportActivationDateMmyyyy") { InputFormat = "MM/yyyy" }, 7);
			//                            PROVIDES THE MONTH AND YEAR THAT THE
			//                            FACILITY WAS ADDED TO THE NFDC AIRPORT
			//                            DATABASE.   NOTE: THIS INFORMATION
			//                            IS ONLY AVAILABLE FOR THOSE
			//                            FACILITIES OPENED SINCE 1981.
			//                            (EX. 06/1981)
			//
			schema.AddColumn(new StringColumn("AirportStatusCode"), 2);
			//                            CI - CLOSED INDEFINITELY
			//                            CP - CLOSED PERMANENTLY
			//                            O  - OPERATIONAL
			//
			schema.AddColumn(new StringColumn("AirportArffCertificationTypeAndDate"), 15);
			//                            FORMAT IS THE CLASS CODE ('I', 'II', 'III',
			//                            OR 'IV') FOLLOWED BY A ONE CHARACTER CODE
			//                            A, B, C, D, E, OR L, FOLLOWED BY A
			//                            ONE CHARACTER CODE S OR U, FOLLOWED
			//                            BY THE MONTH/YEAR OF CERTIFICATION.
			//                            (EX. 'I A S 07/1980'   'I C S 01/1983'
			//                            'II A U 09/1983')
			//
			//                            CODES A,B,C,D,E ARE FOR AIRPORTS
			//                            HAVING A FULL CERTIFICATE UNDER CFR PART
			//                            139, AND IDENTIFIES THE AIRCRAFT RESCUE
			//                            AND FIREFIGHTING INDEX FOR THE AIRPORT.
			//                            CODE L IS FOR AIRPORTS HAVING LIMITED
			//                            CERTIFICATION UNDER CFR PART 139.
			//
			//                            CODE S IS FOR AIRPORTS RECEIVING SCHEDULED
			//                            AIR CARRIER SERVICE FROM CARRIERS
			//                            CERTIFICATED BY THE CIVIL AERONAUTICS BOARD.
			//                            CODE U IS FOR AIRPORTS NOT RECEIVING THIS
			//                            SCHEDULED SERVICE.
			//
			//                            BLANK INDICATES THE FACILITY IS NOT CERTIFICATED.
			//
			schema.AddColumn(new StringColumn("NpiasfederalAgreementsCode"), 7);
			//                            A COMBINATION OF 1 TO 7 CODES THAT
			//                            INDICATE THE TYPE OF FEDERAL AGREEMENTS
			//                            EXISTING AT THE AIRPORT (EX. NGH)
			//
			//                            N - NATIONAL PLAN OF INTEGRATED AIRPORT
			//                                SYSTEMS (NPIAS)
			//                            B - INSTALLATION OF NAVIGATIONAL FACILITIES
			//                                ON PRIVATELY OWNED AIRPORTS UNDER F&E PROGRAM
			//                            G - GRANT AGREEMENTS UNDER FAAP/ADAP/AIP
			//                            H - COMPLIANCE WITH ACCESSIBILITY TO THE
			//                                HANDICAPPED
			//                            P - SURPLUS PROPERTY AGREEMENT UNDER
			//                                PUBLIC LAW 289
			//                            R - SURPLUS PROPERTY AGREEMENT UNDER
			//                                REGULATION 16-WAA
			//                            S - CONVEYANCE UNDER SECTION 16, FEDERAL
			//                                AIRPORT ACT OF 1946 OR SECTION 23,
			//                                AIRPORT AND AIRWAY DEVELOPMENT ACT OF 1970
			//                            V - ADVANCE PLANNING AGREEMENT UNDER FAAP
			//                            X - OBLIGATIONS ASSUMED BY TRANSFER
			//                            Y - ASSURANCES PURSUANT TO TITLE VI,
			//                                CIVIL RIGHTS ACT OF 1964
			//                            Z - CONVEYANCE UNDER SECTION 303(C),
			//                                FEDERAL AVIATION ACT OF 1958
			//                            1 - GRANT AGREEMENT HAS EXPIRED; HOWEVER,
			//                                AGREEMENT REMAINS IN EFFECT FOR THIS
			//                                FACILITY AS LONG AS IT IS PUBLIC USE.
			//                            2 - SECTION 303(C) AUTHORITY FROM FAA ACT
			//                                OF 1958 HAS EXPIRED; HOWEVER, AGREE-
			//                                MENT REMAINS IN EFFECT FOR THIS
			//                                FACILITY AS LONG AS IT IS PUBLIC USE.
			//                            3 - AP-4 AGREEMENT UNDER DLAND OR DCLA
			//                                HAS EXPIRED
			//                         NONE - NO GRANT AGREEMENT EXISTS
			//                         BLANK- NO GRANT AGREEMENT EXISTS
			//
			schema.AddColumn(new StringColumn("AirportAirspaceAnalysisDetermination"), 13);
			//                            CONDL  (CONDITIONAL)
			//                            NOT ANALYZED
			//                            NO OBJECTION
			//                            OBJECTIONABLE
			//
			schema.AddColumn(new StringColumn("FacilityHasBeenDesignatedByTheUsDepartment"), 1);
			//                         OF HOMELAND SECURITY AS AN INTERNATIONAL AIRPORT OF 
			//                         ENTRY FOR CUSTOMS
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("FacilityHasBeenDesignatedByTheUsDepartment1"), 1);
			//                         OF HOMELAND SECURITY AS A CUSTOMS LANDING RIGHTS 
			//                         AIRPORT. (USER FEE AIRPORTS WILL BE DESIGNATED
			//                         WITH AN E80 OR E80A REFERENCED REMARK "US CUSTOMS 
			//                         USER FEE ARPT.")
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("FacilityHasMilitarycivilJointUseAgreement"), 1);
			//                         THAT ALLOWS CIVIL OPERATIONS AT A MILITARY AIRPORT
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("AirportHasEnteredIntoAnAgreementThat"), 1);
			//                         GRANTS LANDING RIGHTS TO THE MILITARY
			//                           Y - YES
			//                           N - NO
			//
			//                         -----------------------------------------------
			//                                 AIRPORT INSPECTION DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("AirportInspectionMethod"), 2);
			//                            F - FEDERAL
			//                            S - STATE
			//                            C - CONTRACTOR
			//                            1 - 5010-1 PUBLIC USE MAILOUT PROGRAM
			//                            2 - 5010-2 PRIVATE USE MAILOUT PROGRAM
			schema.AddColumn(new StringColumn("AgencygroupPerformingPhysicalInspection"), 1);
			//                            F - FAA AIRPORTS FIELD PERSONNEL
			//                            S - STATE AERONAUTICAL PERSONNEL
			//                            C - PRIVATE CONTRACT PERSONNEL
			//                            N - OWNER
			schema.AddColumn(new DateTimeColumn("LastPhysicalInspectionDate") { InputFormat = "MMddyyyy" }, 8);
			schema.AddColumn(new DateTimeColumn("LastDateInformationRequestWasCompleted") { InputFormat = "MMddyyyy" }, 8);
			//                         BY FACILITY OWNER OR MANAGER  (MMDDYYYY)
			//
			//                         -----------------------------------------------
			//                                 AIRPORT SERVICES
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("FuelTypesAvailableForPublicUseAtThe"), 40);
			//                         AIRPORT. THERE CAN BE UP TO 8 OCCURENCES
			//                         OF A FIXED 5 CHARACTER FIELD.
			//                         (EX. 80___100__100LL115__)
			//
			//                         80        Grade 80 gasoline (Red)         
			//                         100       Grade 100 gasoline (Green)               
			//                         100LL     100LL gasoline (low lead) (Blue)                           
			//                         115       Grade 115 gasoline (115/145 military 
			//                                       specification) (Purple)            
			//                         A         Jet A, Kerosene, without FS�II*, 
			//                                       FP** minus 40� C.          
			//                         A+        Jet A, Kerosene, with FS�II*, 
			//                                       FP** minus 40�C.                     
			//                         A++       Jet A, Kerosene, with FS�II*, CI/LI#, 
			//                                       SDA##, FP** minus 40�C.            
			//                         A++10     (A++100) Jet A, Kerosene, with FS�II*, 
			//                                       CI/LI#, SDA##, FP** minus 40�C, with 
			//                                       +100 fuel additive that improves 
			//                                       thermal stability characteristics of 
			//                                       kerosene jet fuels.            
			//                         A1        Jet A�1, Kerosene, without FS�II*, 
			//                                       FP** minus 47�C.                
			//                         A1+       Jet A�1, Kerosene with FS�II*, 
			//                                       FP** minus 47� C.
			//                         B         Jet B, Wide�cut, turbine fuel 
			//                                       without FS�II*, FP** minus 50� C.
			//                         B+        Jet B, Wide�cut, turbine fuel 
			//                                       with FS�II*, FP** minus 50� C.
			//                         J4        (JP4)(JP�4 military specification) 
			//                                       FP** minus 58� C.
			//                         J5        (JP5)(JP�5 military specification) Kerosene 
			//                                       with FS�II, FP** minus 46�C.
			//                         J8        (JP8)(JP�8 military specification) Jet A�1, 
			//                                       Kerosene with FS�II*, CI/LI#, SDA##, 
			//                                       FP** minus 47�C.
			//                         J8+10     (J8+100) (JP�8 military specification) Jet 
			//                                       A�1, Kerosene with FS�II*, CI/LI#, 
			//                                       SDA##, FP** minus 47�C, with +100 fuel 
			//                                       additive that improves thermal 
			//                                       stability characteristics of kerosene 
			//                                       jet fuels. 
			//                         J         (Jet Fuel Type Unknown) 
			//                         MOGAS     Automobile gasoline which is to be used 
			//                                       as aircraft fuel. 
			//                         UL91      Unleaded Grade 91 gasoline 
			//                         UL94      Unleaded Grade 94 gasoline
			//
			//                         *(Fuel System Icing Inhibitor) 
			//                         **(Freeze Point) 
			//                         # (Corrosion Inhibitors/Lubricity Improvers) 
			//                         ## (Static Dissipator Additive)
			//                            
			//
			schema.AddColumn(new StringColumn("AirframeRepairServiceAvailabilitytype"), 5);
			//                            MAJOR
			//                            MINOR
			//                            NONE
			schema.AddColumn(new StringColumn("PowerPlantEngineRepairAvailabilitytype"), 5);
			//                            MAJOR
			//                            MINOR
			//                            NONE
			schema.AddColumn(new StringColumn("TypeOfBottledOxygenAvailableValueRepresents"), 8);
			//                         HIGH AND/OR LOW PRESSURE REPLACEMENT BOTTLE)
			//                            HIGH
			//                            LOW
			//                            HIGH/LOW
			//                            NONE
			schema.AddColumn(new StringColumn("TypeOfBulkOxygenAvailableValueRepresents"), 8);
			//                         HIGH AND/OR LOW PRESSURE CYLINDERS)
			//                            HIGH
			//                            LOW
			//                            HIGH/LOW
			//                            NONE
			//
			//                         -----------------------------------------------
			//                                 AIRPORT FACILITIES
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("AirportLightingSchedule"), 7);
			//                            VALUE IS THE BEGINNING-ENDING TIMES (LOCAL TIME)
			//                            THAT THE STANDARD AIRPORT LIGHTS ARE OPERATED.
			//                            VALUE CAN BE "SS-SR" (INDICATING SUNSET-SUNRISE),
			//                            BLANK, OR "SEE RMK", INDICATING THAT THE DETAILS
			//                            ARE IN A FACILITY REMARK DATA ENTRY.
			schema.AddColumn(new StringColumn("BeaconLightingSchedule"), 7);
			//                            VALUE IS THE BEGINNING-ENDING TIMES (LOCAL TIME)
			//                            THAT THE ROTATING AIRPORT BEACON LIGHT IS OPERATED.
			//                            VALUE CAN BE "SS-SR" (INDICATING SUNSET-SUNRISE),
			//                            BLANK, OR "SEE RMK", INDICATING THAT THE DETAILS
			//                            ARE IN A FACILITY REMARK DATA ENTRY.
			schema.AddColumn(new StringColumn("AirTrafficControlTowerLocatedOnAirport"), 1);
			//                            Y - YES
			//                            N - NO
			schema.AddColumn(new StringColumn("UnicomFrequencyAvailableAtTheAirport"), 7);
			schema.AddColumn(new StringColumn("CommonTrafficAdvisoryFrequencyCtaf"), 7);
			//                            (EX. 122.800)
			schema.AddColumn(new StringColumn("SegmentedCircleAirportMarkerSystemOnTheAirport"), 4);
			//                            Y - YES
			//                            N - NO
			//                            NONE
			//                            Y-L - YES, LIGHTED
			schema.AddColumn(new StringColumn("LensColorOfOperableBeaconLocatedOnTheAirport"), 3);
			//                            CG    CLEAR-GREEN (LIGHTED LAND AIRPORT)
			//                            CY    CLEAR-YELLOW (LIGHTED SEAPLANE BASE)
			//                            CGY   CLEAR-GREEN-YELLOW (HELIPORT)
			//                            SCG   SPLIT-CLEAR-GREEN (LIGHTED MILITARY AIRPORT)
			//                            C     CLEAR (UNLIGHTED LAND AIRPORT)
			//                            Y     YELLOW (UNLIGHTED SEAPLANE BASE)
			//                            G     GREEN  (LIGHTED LAND AIRPORT)
			//                            N     NONE
			schema.AddColumn(new StringColumn("LandingFeeChargedToNoncommercialUsersOf"), 1);
			//                         AIRPORT
			//                            Y - YES
			//                            N - NO
			schema.AddColumn(new StringColumn("AYInThisFieldIndicatesThatTheLanding"), 1);
			//                         FACILITY IS USED FOR MEDICAL PURPOSES
			//
			//                         -----------------------------------------------
			//                                  BASED AIRCRAFT
			//                         -----------------------------------------------
			//
			schema.AddColumn(new Int32Column("SingleEngineGeneralAviationAircraft"), 3);
			schema.AddColumn(new Int32Column("MultiEngineGeneralAviationAircraft"), 3);
			schema.AddColumn(new Int32Column("JetEngineGeneralAviationAircraft"), 3);
			schema.AddColumn(new Int32Column("GeneralAviationHelicopter"), 3);
			schema.AddColumn(new Int32Column("OperationalGliders"), 3);
			schema.AddColumn(new Int32Column("OperationalMilitaryAircraftIncludingHelicopters"), 3);
			schema.AddColumn(new Int32Column("UltralightAircraft"), 3);
			//
			//                         -----------------------------------------------
			//                                 ANNUAL OPERATIONS
			//                         -----------------------------------------------
			//
			schema.AddColumn(new Int32Column("CommercialServices"), 6);
			//                            SCHEDULED OPERATIONS BY CAB-CERTIFICATED CARRIERS
			//                            OR INTRASTATE CARRIERS
			schema.AddColumn(new Int32Column("CommuterServices"), 6);
			//                            SCHEDULED COMMUTER/CARGO CARRIERS
			schema.AddColumn(new Int32Column("AirTaxi"), 6);
			//                            AIR TAXI OPERATORS CARRYING PASSENGERS, MAIL, OR
			//                            MAIL FOR REVENUE
			schema.AddColumn(new Int32Column("GeneralAviationLocalOperations"), 6);
			//                            THOSE OPERATING IN THE LOCAL TRAFFIC PATTERN OR
			//                            WITHIN A 20-MILE RADIUS OF THE AIRPORT
			schema.AddColumn(new Int32Column("GeneralAviationItinerantOperations"), 6);
			//                            THOSE GENERAL AVIATION OPERATIONS (EXCLUDING
			//                            COMMUTER OR AIR TAXI) NOT QUALIFYING AS LOCAL
			schema.AddColumn(new Int32Column("MilitaryAircraftOperations"), 6);
			schema.AddColumn(new DateTimeColumn("12MonthEndingDateOnWhichAnnualOperationsData") { InputFormat = "MM/dd/yyyy" }, 10);
			//                         IN ABOVE SIX FIELDS IS BASED (MM/DD/YYYY)
			//
			//                         -----------------------------------------------
			//                                 ADDITIONAL AIRPORT DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("AirportPositionSource"), 16);
			schema.AddColumn(new DateTimeColumn("AirportPositionSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("AirportElevationSource"), 16);
			schema.AddColumn(new DateTimeColumn("AirportElevationSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("ContractFuelAvailable"), 1);
			//                            Y - YES
			//                            N - NO
			schema.AddColumn(new StringColumn("TransientStorageFacilities"), 12);
			//                         A COMMA-SEPARATED LIST OF TRANSIENT STORAGE
			//                         FACILITY TYPES AVAILABLE AT THE AIRPORT.  THERE
			//                         ARE THREE POSSIBLE SUCH FACILITIES:
			//                            BUOY - INDICATES BUOY STORAGE FACILITIES
			//                            HGR  - INDICATES HANGAR STORAGE FACILITIES
			//                            TIE  - INDICATES TIE-DOWN STORAGE FACILITIES
			schema.AddColumn(new StringColumn("OtherAirportServicesAvailable"), 71);
			//                         A COMMA-SEPARATED LIST OF OTHER AIRPORT SERVICES
			//                         AVAILABLE AT THE AIRPORT, WHICH INCLUDE:
			//                            AFRT  - AIR FREIGHT SERVICES
			//                            AGRI  - CROP DUSTING SERVICES
			//                            AMB   - AIR AMBULANCE SERVICES
			//                            AVNCS - AVIONICS
			//                            BCHGR - BEACHING GEAR
			//                            CARGO - CARGO HANDLING SERVICES
			//                            CHTR  - CHARTER SERVICE
			//                            GLD   - GLIDER SERVICE
			//                            INSTR - PILOT INSTRUCTION
			//                            PAJA  - PARACHUTE JUMP ACTIVITY
			//                            RNTL  - AIRCRAFT RENTAL
			//                            SALES - AIRCRAFT SALES
			//                            SURV  - ANNUAL SURVEYING
			//                            TOW   - GLIDER TOWING SERVICES
			schema.AddColumn(new StringColumn("WindIndicator"), 3);
			//                         SHOWS WHETHER A WIND INDICATOR EXISTS AT THE
			//                         AIRPORT
			//                           N   - NO WIND INDICATOR
			//                           Y   - UNLIGHTED WIND INDICATOR EXISTS
			//                           Y-L - LIGHTED WIND INDICATOR EXISTS
			schema.AddColumn(new StringColumn("IcaoIdentifier"), 7);
			//                         INTERNATIONAL CODING FOR AIRPORT 
			schema.AddColumn(new StringColumn("MinimumOperationalNetworkmon"), 1);
			schema.AddColumn(new StringColumn("AirportRecordFillerBlank"), 311);

			return schema;
		}

		public static FixedLengthSchema GetFacilityAttendanceScheduleSchema()
		{
			var schema = new FixedLengthSchema();
			//
			//
			//J  T   L   S L   E N
			//U  Y   E   T O   L U
			//S  P   N   A C   E M
			//T  E   G   R A   M B
			//       T   T T   E E
			//       H     I   N R
			//             O   T


			//             N           FIELD DESCRIPTION
			//************************************************************************
			//*  F A C I L I T Y   A T T E N D A N C E   S C H E D U L E   D A T A   *
			//************************************************************************
			//
			schema.AddColumn(new StringColumn("RecordTypeIndicator"), 3);
			//                           ATT:  ATTENDANCE SCHEDULE RECORD FOR THE
			//                           LANDING FACILITY.
			schema.AddColumn(new StringColumn("LandingFacilitySiteNumber"), 11);
			//                            THE UNIQUE IDENTIFYING NUMBER OF THE
			//                            AIRPORT WHOSE ATTENDANCE SCHEDULE IS
			//                            BEING DESCRIBED.
			schema.AddColumn(new StringColumn("LandingFacilityStatePostOfficeCode"), 2);
			//                            THE STATE WHERE THE LANDING FACILITY IS
			//                            LOCATED. THIS IS USED IN SORTING THE
			//                            ENTIRE FILE BY STATE AND SITE NUMBER.
			schema.AddColumn(new StringColumn("AttendanceScheduleSequenceNumber"), 2);
			//                           A NUMBER WHICH, TOGETHER WITH THE
			//                           SITE NUMBER, UNIQUELY IDENTIFIES THE
			//                           ATTENDANCE SCHEDULE COMPONENT.
			schema.AddColumn(new StringColumn("AirportAttendanceScheduleWhenMinimum"), 108);
			//                         SERVICES ARE AVAILABLE)
			//                            FORMAT IS  MONTHS/DAYS/HOURS WHERE
			//                            THE FIRST PART DESCRIBES THE MONTHS THAT
			//                            THE FACILITY IS ATTENDED, THEN THE DAYS
			//                            OF THE WEEK THAT THE FACILITY IS OPEN, AND
			//                            FINALLY THE HOURS WITHIN THE DAY THAT IT
			//                            IS ATTENDED. THIS FIELD MAY ALSO CONTAIN
			//                            'UNATNDD' FOR UNATTENDED FACILITIES. IF
			//                            THERE ARE DIFFERENT SCHEDULES FOR DIFFERENT
			//                            TIMES OF THE YEAR OR DIFFERENT DAYS OF THE WEEK
			//                            THERE WILL BE SEPARATE "ATT" RECORDS FOR EACH
			//                            SET OF MONTHS, DAYS, AND HOURS OF ATTENDANCE.
			//                            (EX. 'ALL/MON-FRI/SR-SS' MEANS THE FACILITY
			//                            IS OPEN YEAR-ROUND, MONDAY THRU FRIDAY,
			//                            FROM SUNRISE TO SUNSET).
			schema.AddColumn(new StringColumn("AttendanceScheduleRecordFillerBlank"), 1403);

			return schema;
		}

		public static FixedLengthSchema GetRunwaySchema()
		{
			var schema = new FixedLengthSchema();
			//
			//
			//J  T   L   S L   E N
			//U  Y   E   T O   L U
			//S  P   N   A C   E M
			//T  E   G   R A   M B
			//       T   T T   E E
			//       H     I   N R
			//             O   T


			//             N           FIELD DESCRIPTION
			//************************************************************************
			//*          F A C I L I T Y   R U N W A Y   D A T A                     *
			//************************************************************************
			//
			schema.AddColumn(new StringColumn("RecordTypeIndicator"), 3);
			//                            RWY: RUNWAY DATA FOR RESPECTIVE FACILITY
			//                                 RUNWAYS.
			schema.AddColumn(new StringColumn("LandingFacilitySiteNumber"), 11);
			//                            THE UNIQUE IDENTIFYING NUMBER OF THE
			//                            AIRPORT WHOSE RUNWAY IS BEING DESCRIBED.
			//                            TOGETHER WITH THE RUNWAY ID FIELD, THIS
			//                            PROVIDES THE UNIQUE KEY TO A RUNWAY RECORD.
			schema.AddColumn(new StringColumn("RunwayStatePostOfficeCode"), 2);
			//                            THE STATE WHERE THE LANDING FACILITY IS
			//                            LOCATED. THIS WAS USED IN SORTING THE
			//                            ENTIRE FILE BY STATE AND SITE NUMBER.
			schema.AddColumn(new StringColumn("RunwayIdentification"), 7);
			//                            EX. 01/19; 18L/36R (PARALLEL RUNWAYS);
			//                                H1 (HELIPAD); N/S (NORTH/SOUTH);
			//                                ALL/WAY (SEALANE); B1 (BALLOONPORT)
			//
			//                         -----------------------------------------------
			//                                 COMMON RUNWAY DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("PhysicalRunwayLengthNearestFoot"), 5);
			//                           (EX. 3500)
			schema.AddColumn(new StringColumn("PhysicalRunwayWidthNearestFoot"), 4);
			//                           (EX. 100)
			schema.AddColumn(new StringColumn("RunwaySurfaceTypeAndCondition"), 12);
			//                           CONC    - PORTLAND CEMENT CONCRETE
			//                           ASPH    - ASPHALT OR BITUMINOUS CONCRETE
			//                           SNOW    - SNOW
			//                           ICE     - ICE
			//                           MATS    - PIERCED STEEL PLANKING; LANDING
			//                                     MATS; MEMBRANES
			//                           TREATED - OILED; SOIL CEMENT OR LIME
			//                                     STABILIZED
			//                           GRAVEL  - GRAVEL; CINDERS; CRUSHED ROCK;
			//                                     CORAL OR SHELLS; SLAG
			//                           TURF    - GRASS; SOD
			//                           DIRT    - NATURAL SOIL
			//                           WATER   - WATER
			//                           E       - EXCELLENT CONDITION
			//                           G       - GOOD CONDITION
			//                           F       - FAIR CONDITION
			//                           P       - POOR CONDITION
			//                           L       - FAILED CONDITION
			//
			//                         THE VALUE CAN BE ANY ONE OF THOSE DESCRIBED
			//                         ABOVE OR A COMBINATION OF TWO TYPES WHEN
			//                         THE RUNWAY IS COMPOSED OF DISTINCT SECTIONS.
			//
			//                         THE SURFACE TYPE IS OPTIONALLY FOLLOWED BY
			//                         A CONDITION INDICATOR.
			//                         (EX. ASPH-CONC TURF-GRVL ASPH-F ASPH-CONC-G)
			schema.AddColumn(new StringColumn("RunwaySurfaceTreatment"), 5);
			//                           GRVD - SAW-CUT OR PLASTIC GROOVED
			//                           PFC  - POROUS FRICTION COURSE
			//                           AFSC - AGGREGATE FRICTION SEAL COAT
			//                           RFSC - RUBBERIZED FRICTION SEAL COAT
			//                           WC   - WIRE COMB OR WIRE TINE
			//                           NONE - NO SPECIAL SURFACE TREATMENT
			schema.AddColumn(new StringColumn("PavementClassificationNumberPcn"), 11);
			//                           A RATING SYSTEM THAT EXPRESSES THE RELATIVE
			//                           LOAD CARRYING CAPACITY OF A PAVEMENT IN TERMS
			//                           OF A STANDARD SINGLE WHEEL LOAD. THE RATING
			//                           IS STRUCTURED SO THAT A PAVEMENT WITH A
			//                           PARTICULAR PCN VALUE CAN SUPPORT, WITHOUT
			//                           WEIGHT RESTRICTIONS, AN AIRCRAFT WHICH HAS
			//                           AN AIRCRAFT CLASSIFICATION NUMBER (ACN) EQUAL
			//                           TO OR LESS THAN THE PAVEMENT'S PCN VALUE.
			//                           (EX. 61/F/B/X/T)
			//                           THE DATA FORMAT IS PCN/PAVEMENT TYPE/SUBGRADE
			//                           STRENGTH/TIRE PRESSURE/DETERMINATION METHOD
			//                           WHERE:
			//                             PCN: A NUMERICAL VALUE
			//                             PAVEMENT TYPE:  R - RIGID   F - FLEXIBLE
			//                             SUBGRADE STRENGTH: LETTERS A-F
			//                             TIRE PRESSURE CODE: LETTERS W-Z
			//                             DETERMINATION METHOD: T - TECHNICAL
			//                               U - USING AIRCRAFT
			//                           SEE FAA ADVISORY CIRCULAR 150/5335-5 FOR
			//                           CODE DEFINITIONS AND PCN DETERMINATION FORMULA.
			//
			schema.AddColumn(new StringColumn("RunwayLightsEdgeIntensity"), 5);
			//                           HIGH - HIGH
			//                           MED  - MEDIUM
			//                           LOW  - LOW
			//                           NSTD - NON-STANDARD LIGHTING SYSTEM
			//                           NONE - NO EDGE LIGHTING SYSTEM
			//
			//                         -----------------------------------------------
			//                                 BASE END INFORMATION
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("BaseEndIdentifier"), 3);
			//                           THE RUNWAY END DESCRIBED BY THE FOLLOWING
			//                           INFORMATION. RELATES TO THE FIRST
			//                           PART OF THE RUNWAY IDENTIFICATION.
			//                           (EX. FOR RUNWAY 18/36 THE BASE END IS 18)
			schema.AddColumn(new StringColumn("RunwayEndTrueAlignment"), 3);
			//                           TRUE HEADING OF THE RUNWAY - TO
			//                           THE NEAREST DEGREE.
			//                           (EX. FOR RUNWAY END 18, COULD BE 184)
			schema.AddColumn(new StringColumn("InstrumentLandingSystemIlsType"), 10);
			//                           ILS       - INSTRUMENT LANDING SYSTEM
			//                           MLS       - MICROWAVE LANDING SYSTEM
			//                           SDF       - SIMPLIFIED DIRECTIONAL FACILITY
			//                           LOCALIZER - LOCALIZER
			//                           LDA       - LOCALIZER-TYPE DIRECTIONAL AID
			//                           ISMLS     - INTERIM STANDARD MICROWAVE
			//                                       LANDING SYSTEM
			//                           ILS/DME   - INSTRUMENT LANDING SYSTEM/
			//                                       DISTANCE MEASURING EQUIPMENT
			//                           SDF/DME   - SIMPLIFIED DIRECTIONAL FACILITY
			//                                       DISTANCE MEASURING EQUIPMENT
			//                           LOC/DME   - LOCALIZER/
			//                                       DISTANCE MEASURING EQUIPMENT
			//                           LOC/GS    - LOCALIZER/GLIDE SLOPE
			//                           LDA/DME   - LOCALIZER-TYPE DIRECTIONAL AID
			//                                       DISTANCE MEASURING EQUIPMENT
			//
			schema.AddColumn(new StringColumn("RightHandTrafficPatternForLandingAircraft"), 1);
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("RunwayMarkingsType"), 5);
			//                           PIR  - PRECISION INSTRUMENT
			//                           NPI  - NONPRECISION INSTRUMENT
			//                           BSC  - BASIC
			//                           NRS  - NUMBERS ONLY
			//                           NSTD - NONSTANDARD (OTHER THAN NUMBERS ONLY)
			//                           BUOY - BUOYS (SEAPLANE BASE)
			//                           STOL - SHORT TAKEOFF AND LANDING
			//                           NONE - NONE
			//
			schema.AddColumn(new StringColumn("RunwayMarkingsCondition"), 1);
			//                           G - GOOD
			//                           F - FAIR
			//                           P - POOR
			//                         -----------------------------------------------
			//                                 BASE END GEOGRAPHIC DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("LatitudeOfPhysicalRunwayEndFormatted"), 15);
			schema.AddColumn(new StringColumn("LatitudeOfPhysicalRunwayEndSeconds"), 12);
			schema.AddColumn(new StringColumn("LongitudeOfPhysicalRunwayEndFormatted"), 15);
			schema.AddColumn(new StringColumn("LongitudeOfPhysicalRunwayEndSeconds"), 12);
			schema.AddColumn(new StringColumn("ElevationFeetMslAtPhysicalRunwayEnd"), 7);
			//                           (EX. 58  120.5  13.0)
			schema.AddColumn(new StringColumn("ThresholdCrossingHeightFeetAgl"), 3);
			//                           HEIGHT THAT THE EFFECTIVE VISUAL
			//                           GLIDE PATH CROSSES ABOVE THE RUNWAY THRESHOLD
			//                           (EX. 32)
			schema.AddColumn(new StringColumn("VisualGlidePathAngleHundredthsOfDegrees"), 4);
			//                           (EX. 3.00)
			schema.AddColumn(new StringColumn("LatitudeAtDisplacedThresholdFormatted"), 15);
			schema.AddColumn(new StringColumn("LatitudeAtDisplacedThresholdSeconds"), 12);
			schema.AddColumn(new StringColumn("LongitudeAtDisplacedThresholdFormatted"), 15);
			schema.AddColumn(new StringColumn("LongitudeAtDisplacedThresholdSeconds"), 12);
			schema.AddColumn(new StringColumn("ElevationAtDisplacedThresholdFeetMsl"), 7);
			//                           (EX. 1200.1  187.1  200)
			schema.AddColumn(new StringColumn("DisplacedThresholdLengthInFeetFrom"), 4);
			//                           RUNWAY END  (EX. 120 OR NONE)
			schema.AddColumn(new StringColumn("ElevationAtTouchdownZoneFeetMsl"), 7);
			//                           (EX. 1200  187.5)
			//
			//                         -----------------------------------------------
			//                               BASE END LIGHTING DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("VisualGlideSlopeIndicators"), 5);
			//                           ACRONYMS: SAVASI - SIMPLIFIED ABBREVIATED
			//                                              VISUAL APPROACH SLOPE
			//                                              INDICATOR
			//                                     VASI   - VISUAL APPROACH SLOPE
			//                                              INDICATOR
			//                                     PAPI   - PRECISION APPROACH PATH
			//                                              INDICATOR
			//                                     TRI    - TRI-COLOR VISUAL APPROACH
			//                                              SLOPE INDICATOR
			//                                     PSI    - PULSATING/STEADY BURNING
			//                                              VISUAL APPROACH SLOPE
			//                                              INDICATOR
			//                                     PNI    - A SYSTEM OF PANELS USED
			//                                              FOR ALIGNMENT OF APPROACH
			//                                              SLOPE INDICATOR
			//                           S2L   2-BOX SAVASI ON LEFT SIDE OF RUNWAY
			//                           S2R   2-BOX SAVASI ON RIGHT SIDE OF RUNWAY
			//                           V2L   2-BOX VASI ON LEFT SIDE OF RUNWAY
			//                           V2R   2-BOX VASI ON RIGHT SIDE OF RUNWAY
			//                           V4L   4-BOX VASI ON LEFT SIDE OF RUNWAY
			//                           V4R   4-BOX VASI ON RIGHT SIDE OF RUNWAY
			//                           V6L   6-BOX VASI ON LEFT SIDE OF RUNWAY
			//                           V6R   6-BOX VASI ON RIGHT SIDE OF RUNWAY
			//                           V12   12-BOX VASI ON BOTH SIDES OF RUNWAY
			//                           V16   16-BOX VASI ON BOTH SIDES OF RUNWAY
			//                           P2L   2-LGT PAPI ON LEFT SIDE OF RUNWAY
			//                           P2R   2-LGT PAPI ON RIGHT SIDE OF RUNWAY
			//                           P4L   4-LGT PAPI ON LEFT SIDE OF RUNWAY
			//                           P4R   4-LGT PAPI ON RIGHT SIDE OF RUNWAY
			//                           NSTD  NONSTANDARD VASI SYSTEM
			//                           PVT   PRIVATELY OWNED APPROACH SLOPE
			//                                 INDICATOR LIGHT SYSTEM ON A PUBLIC
			//                                 USE AIRPORT THAT IS INTENDED FOR
			//                                 PRIVATE USE ONLY
			//                           VAS   NON-SPECIFIC VASI SYSTEM
			//                           NONE  NO APPROACH SLOPE LIGHT SYSTEM
			//                           N     NO APPROACH SLOPE LIGHT SYSTEM
			//                           TRIL  TRI-COLOR VASI ON LEFT SIDE OF RUNWAY
			//                           TRIR  TRI-COLOR VASI ON RIGHT SIDE OF RUNWAY
			//                           PSIL  PULSATING/STEADY BURNING VASI ON LEFT SIDE
			//                                 OF RUNWAY
			//                           PSIR  PULSATING/STEADY BURNING VASI ON RIGHT SIDE
			//                                 OF RUNWAY
			//                           PNIL  SYSTEM OF PANELS ON LEFT SIDE OF RUNWAY THAT
			//                                 MAY OR MAY NOT BE LIGHTED
			//                           PNIR  SYSTEM OF PANELS ON RIGHT SIDE OF RUNWAY
			//                                 THAT MAY OR MAY NOT BE LIGHTED
			//
			schema.AddColumn(new StringColumn("RunwayVisualRangeEquipmentRvr"), 3);
			//                           INDICATES LOCATION(S) AT WHICH RVR
			//                           EQUIPMENT IS INSTALLED. CAN BE ANY ONE
			//                           OR A COMBINATION OF THE FOLLOWING THREE
			//                           ONE LETTER CODES:
			//                             T - TOUCHDOWN
			//                             M - MIDFIELD
			//                             R - ROLLOUT
			//                             N - NO RVR AVAILABLE
			//                           POSSIBLE VALUES: T,M,R,N,TM,TR,MR,TMR
			//
			schema.AddColumn(new StringColumn("RunwayVisibilityValueEquipmentRvv"), 1);
			//                           INDICATES PRESENCE OF RVV EQUIPMENT
			//                             Y - YES
			//                             N - NO
			schema.AddColumn(new StringColumn("ApproachLightSystem"), 8);
			//
			//                         ALSAF - 3,000 FOOT HIGH INTENSITY APPROACH
			//                                 LIGHTING SYSTEM WITH CENTERLINE
			//                                 SEQUENCE FLASHERS.
			//                         ALSF1 - STANDARD 2,400 FOOT HIGH INTENSITY
			//                                 APPROACH LIGHTING SYSTEM WITH
			//                                 SEQUENCED FLASHERS, CATEGORY I CONFIG.
			//                         ALSF2 - STANDARD 2,400 FOOT HIGH INTENSITY
			//                                 APPROACH LIGHTING SYSTEM WITH
			//                                 SEQUENCED FLASHERS, CATEGORY II OR III
			//                                 CONFIGURATION
			//                         MALS  - 1,400 FOOT MEDIUM INTENSITY APPROACH
			//                                 LIGHTING SYSTEM
			//                         MALSF - 1,400 FOOT MEDIUM INTENSITY APPROACH
			//                                 LIGHTING SYSTEM WITH SEQUENCED FLASHERS
			//                         MALSR - 1,400 FOOT MEDIUM INTENSITY APPROACH
			//                                 LIGHTING SYSTEM WITH RUNWAY ALIGNMENT
			//                                 INDICATOR LIGHTS
			//                         SSALS - SIMPLIFIED SHORT APPROACH LIGHTING SYSTEM
			//                         SSALF - SIMPLIFIED SHORT APPROACH LIGHTING SYSTEM
			//                                 WITH SEQUENCED FLASHERS
			//                         SSALR - SIMPLIFIED SHORT APPROACH LIGHTING SYSTEM
			//                                 WITH RUWNAY ALIGNMENT INDICATOR LIGHTS
			//                         NEON  - NEON LADDER SYSTEM
			//                         ODALS - OMNIDIRECTIONAL APPROACH LIGHTING SYSTEM
			//                         RLLS  - RUNWAY LEAD-IN LIGHT SYSTEM
			//                         MIL OVRN - MILITARY OVERRUN
			//                         NSTD  - ALL OTHERS
			//                         NONE  - NO APPROACH LIGHTING IS AVAILABLE
			//
			schema.AddColumn(new StringColumn("RunwayEndIdentifierLightsReilAvailability"), 1);
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("RunwayCenterlineLightsAvailability"), 1);
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("RunwayEndTouchdownLightsAvailability"), 1);
			//                           Y - YES
			//                           N - NO
			//
			//                         -----------------------------------------------
			//                               BASE END OBJECT DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("ControllingObjectDescription"), 11);
			//                           (EX. TREES,BLDG,PLINE,FENCE,NONE)
			schema.AddColumn(new StringColumn("ControllingObjectMarkedlighted"), 4);
			//                           M  - MARKED
			//                           L  - LIGHTED
			//                           ML - MARKED AND LIGHTED
			//                           NONE
			schema.AddColumn(new StringColumn("FaaCfrPart77ObjectsAffectingNavigableAirspace"), 5);
			//                         RUNWAY CATEGORY
			//                           A(V)  - UTILITY RUNWAY WITH A VISUAL APPROACH
			//                           B(V)  - OTHER THAN UTILITY RUNWAY WITH A VISUAL
			//                                   APPROACH
			//                           A(NP) - UTILITY RUNWAY WITH A NONPRECISION APPROACH
			//                           C     - OTHER THAN UTILITY RUNWAY WITH A
			//                                   NONPRECISION APPROACH HAVING VISIBILITY
			//                                   MINIMUMS GREATER THAN 3/4 MILE
			//                           PIR   - PRECISION INSTRUMENT RUNWAY
			//
			schema.AddColumn(new StringColumn("ControllingObjectClearanceSlope"), 2);
			//                           VALUE, EXPRESSED AS A RATIO OF N:1, OF THE
			//                           CLEARANCE THAT IS AVAILABLE TO APPROACHING
			//                           AIRCRAFT. IF THE CLEARANCE SLOPE IS GREATER THAN
			//                           50:1,THEN 50 OR 50+ WILL BE ENTERED.
			//                           (EX.  8,22,50)
			schema.AddColumn(new StringColumn("ControllingObjectHeightAboveRunway"), 5);
			//                           HEIGHT, IN FEET AGL, THE OBJECT IS ABOVE
			//                           THE PHYSICAL RUNWAY END.
			//                           (EX. 100)
			schema.AddColumn(new StringColumn("ControllingObjectDistanceFromRunwayEnd"), 5);
			//                           DISTANCE, IN FEET, FROM THE PHYSICAL RUNWAY END
			//                           TO THE CONTROLLING OBJECT. THIS IS MEASURED
			//                           USING THE EXTENDED RUNWAY CENTERLINE TO A POINT
			//                           ABEAM THE OBJECT.
			//                           (EX. 800  0  NONE)
			schema.AddColumn(new StringColumn("ControllingObjectCenterlineOffset"), 7);
			//                           DISTANCE, IN FEET, THAT THE CONTROLLING OBJECT
			//                           IS LOCATED AWAY FROM THE EXTENDED RUNWAY CENTERLINE
			//                           AS MEASURED HORIZONTALLY ON A LINE PERPENDICULAR
			//
			//
			//
			//
			//                           TO THE EXTENDED RUNWAY CENTERLINE. ALSO, INDICATES
			//                           THE DIRECTION (LEFT OR RIGHT) TO THE OBJECT
			//                           FROM THE CENTERLINE AS SEEN BY AN APPROACHING
			//                           PILOT.
			//                           (EX. 50R, 75L, NONE)
			//
			//                         -----------------------------------------------
			//                                 RECIPROCAL END INFORMATION
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("ReciprocalEndIdentifier"), 3);
			//                           THE RUNWAY END DESCRIBED BY THE FOLLOWING
			//                           INFORMATION. RELATES TO THE SECOND
			//                           PART OF THE RUNWAY IDENTIFICATION.
			//                           (EX. FOR RUNWAY 18/36 THE RECIPROCAL END IS 36;
			//                                FOR HELIPADS, E.G. RUNWAY H1, THIS
			//                                INFORMATION IS BLANK)
			schema.AddColumn(new StringColumn("RunwayEndTrueAlignment1"), 3);
			//                           TRUE HEADING OF THE RUNWAY - TO
			//                           THE NEAREST DEGREE.
			//                           (EX. FOR RUNWAY END 18, COULD BE 184)
			schema.AddColumn(new StringColumn("InstrumentLandingSystemIlsType1"), 10);
			//                           ILS       - INSTRUMENT LANDING SYSTEM
			//                           MLS       - MICROWAVE LANDING SYSTEM
			//                           SDF       - SIMPLIFIED DIRECTIONAL FACILITY
			//                           LOCALIZER - LOCALIZER
			//                           LDA       - LOCALIZER-TYPE DIRECTIONAL AID
			//                           ISMLS     - INTERIM STANDARD MICROWAVE
			//                                       LANDING SYSTEM
			//                           ILS/DME   - INSTRUMENT LANDING SYSTEM/
			//                                       DISTANCE MEASURING EQUIPMENT
			//                           SDF/DME   - SIMPLIFIED DIRECTIONAL FACILITY
			//                                       DISTANCE MEASURING EQUIPMENT
			//                           LOC/DME   - LOCALIZER/
			//                                       DISTANCE MEASURING EQUIPMENT
			//                           LOC/GS    - LOCALIZER/GLIDE SLOPE
			//                           LDA/DME   - LOCALIZER-TYPE DIRECTIONAL AID
			//                                       DISTANCE MEASURING EQUIPMENT
			//
			schema.AddColumn(new StringColumn("RightHandTrafficPatternForLandingAircraft1"), 1);
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("RunwayMarkingsType1"), 5);
			//                           PIR  - PRECISION INSTRUMENT
			//                           NPI  - NONPRECISION INSTRUMENT
			//                           BSC  - BASIC
			//                           NRS  - NUMBERS ONLY
			//                           NSTD - NONSTANDARD (OTHER THAN NUMBERS ONLY)
			//                           BUOY - BUOYS (SEAPLANE BASE)
			//                           STOL - SHORT TAKEOFF AND LANDING
			//                           NONE - NONE
			//
			schema.AddColumn(new StringColumn("RunwayMarkingsCondition1"), 1);
			//                           G - GOOD
			//                           F - FAIR
			//                           P - POOR
			//
			//                         -----------------------------------------------
			//                                 RECIPROCAL END GEOGRAPHIC DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("LatitudeOfPhysicalRunwayEndFormatted1"), 15);
			schema.AddColumn(new StringColumn("LatitudeOfPhysicalRunwayEndSeconds1"), 12);
			schema.AddColumn(new StringColumn("LongitudeOfPhysicalRunwayEndFormatted1"), 15);
			schema.AddColumn(new StringColumn("LongitudeOfPhysicalRunwayEndSeconds1"), 12);
			schema.AddColumn(new StringColumn("ElevationFeetMslAtPhysicalRunwayEnd1"), 7);
			//                           (EX. 58  120.5  13.0)
			schema.AddColumn(new StringColumn("ThresholdCrossingHeightFeetAgl1"), 3);
			//                           HEIGHT THAT THE EFFECTIVE VISUAL
			//                           GLIDE PATH CROSSES ABOVE THE RUNWAY THRESHOLD
			//                           (EX. 32)
			schema.AddColumn(new StringColumn("VisualGlidePathAngleHundredthsOfDegrees1"), 4);
			//                           (EX. 3.00)
			schema.AddColumn(new StringColumn("LatitudeAtDisplacedThresholdFormatted1"), 15);
			schema.AddColumn(new StringColumn("LatitudeAtDisplacedThresholdSeconds1"), 12);
			schema.AddColumn(new StringColumn("LongitudeAtDisplacedThresholdFormatted1"), 15);
			schema.AddColumn(new StringColumn("LongitudeAtDisplacedThresholdSeconds1"), 12);
			schema.AddColumn(new StringColumn("ElevationAtDisplacedThresholdFeetMsl1"), 7);
			//                           (EX. 1200.1  187.1  200)
			schema.AddColumn(new StringColumn("DisplacedThresholdLengthInFeetFrom1"), 4);
			//                           RUNWAY END  (EX. 120 OR NONE)
			schema.AddColumn(new StringColumn("ElevationAtTouchdownZoneFeetMsl1"), 7);
			//                           (EX. 1200  187.5)
			//
			//                         -----------------------------------------------
			//                               RECIPROCAL END LIGHTING DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("VisualGlideSlopeIndicators1"), 5);
			//                           ACRONYMS: SAVASI - SIMPLIFIED ABBREVIATED
			//                                              VISUAL APPROACH SLOPE
			//                                              INDICATOR
			//                                     VASI   - VISUAL APPROACH SLOPE
			//                                              INDICATOR
			//                                     PAPI   - PRECISION APPROACH SLOPE
			//                                              INDICATOR
			//                                     TRI    - TRI-COLOR VISUAL APPROACH
			//                                              SLOPE INDICATOR
			//                                     PSI    - PULSATING/STEADY BURNING
			//                                              VISUAL APPROACH SLOPE
			//                                              INDICATOR
			//                                     PNI    - A SYSTEM OF PANELS USED
			//                                              FOR ALIGNMENT OF APPROACH
			//                                              SLOPE INDICATOR
			//                           S2L   2-BOX SAVASI ON LEFT SIDE OF RUNWAY
			//                           S2R   2-BOX SAVASI ON RIGHT SIDE OF RUNWAY
			//                           V2L   2-BOX VASI ON LEFT SIDE OF RUNWAY
			//                           V2R   2-BOX VASI ON RIGHT SIDE OF RUNWAY
			//                           V4L   4-BOX VASI ON LEFT SIDE OF RUNWAY
			//                           V4R   4-BOX VASI ON RIGHT SIDE OF RUNWAY
			//                           V6L   6-BOX VASI ON LEFT SIDE OF RUNWAY
			//                           V6R   6-BOX VASI ON RIGHT SIDE OF RUNWAY
			//                           V12   12-BOX VASI ON BOTH SIDES OF RUNWAY
			//                           V16   16-BOX VASI ON BOTH SIDES OF RUNWAY
			//                           P2L   2-LGT PAPI ON LEFT SIDE OF RUNWAY
			//                           P2R   2-LGT PAPI ON RIGHT SIDE OF RUNWAY
			//                           P4L   4-LGT PAPI ON LEFT SIDE OF RUNWAY
			//                           P4R   4-LGT PAPI ON RIGHT SIDE OF RUNWAY
			//                           NSTD  NONSTANDARD VASI SYSTEM
			//                           PVT   PRIVATELY OWNED APPROACH SLOPE
			//                                 INDICATOR LIGHT SYSTEM ON A PUBLIC
			//                                 USE AIRPORT THAT IS INTENDED FOR
			//                                 PRIVATE USE ONLY
			//                           VAS   NON-SPECIFIC VASI SYSTEM
			//                           NONE  NO APPROACH SLOPE LIGHT SYSTEM
			//                           N     NO APPROACH SLOPE LIGHT SYSTEM
			//                           TRIL  TRI-COLOR VASI ON LEFT SIDE OF RUNWAY
			//                           TRIR  TRI-COLOR VASI ON RIGHT SIDE OF RUNWAY
			//                           PSIL  PULSATING/STEADY BURNING VASI ON LEFT SIDE
			//                                 OF RUNWAY
			//                           PSIR  PULSATING/STEADY BURNING VASI ON RIGHT SIDE
			//                                 OF RUNWAY
			//                           PNIL  SYSTEM OF PANELS ON LEFT SIDE OF RUNWAY THAT
			//                                 MAY OR MAY NOT BE LIGHTED
			//                           PNIR  SYSTEM OF PANELS ON RIGHT SIDE OF RUNWAY
			//                                 THAT MAY OR MAY NOT BE LIGHTED
			//
			schema.AddColumn(new StringColumn("RunwayVisualRangeEquipmentRvr1"), 3);
			//                           INDICATES LOCATION(S) AT WHICH RVR
			//                           EQUIPMENT IS INSTALLED. CAN BE ANY ONE
			//                           OR A COMBINATION OF THE FOLLOWING THREE
			//                           ONE LETTER CODES:
			//                             T - TOUCHDOWN
			//                             M - MIDFIELD
			//                             R - ROLLOUT
			//                             N - NO RVR AVAILABLE
			//                           POSSIBLE VALUES: T,M,R,N,TM,TR,MR,TMR
			//
			schema.AddColumn(new StringColumn("RunwayVisibilityValueEquipmentRvv1"), 1);
			//                           INDICATES PRESENCE OF RVV EQUIPMENT
			//                             Y - YES
			//                             N - NO
			schema.AddColumn(new StringColumn("ApproachLightSystem1"), 8);
			//
			//                         ALSAF - 3,000 FOOT HIGH INTENSITY APPROACH
			//                                 LIGHTING SYSTEM WITH CENTERLINE
			//                                 SEQUENCE FLASHERS.
			//                         ALSF1 - STANDARD 2,400 FOOT HIGH INTENSITY
			//                                 APPROACH LIGHTING SYSTEM WITH
			//                                 SEQUENCED FLASHERS, CATEGORY I CONFIG.
			//                         ALSF2 - STANDARD 2,400 FOOT HIGH INTENSITY
			//                                 APPROACH LIGHTING SYSTEM WITH
			//                                 SEQUENCED FLASHERS, CATEGORY II OR III
			//                                 CONFIGURATION
			//                         MALS  - 1,400 FOOT MEDIUM INTENSITY APPROACH
			//                                 LIGHTING SYSTEM
			//                         MALSF - 1,400 FOOT MEDIUM INTENSITY APPROACH
			//                                 LIGHTING SYSTEM WITH SEQUENCED FLASHERS
			//                         MALSR - 1,400 FOOT MEDIUM INTENSITY APPROACH
			//                                 LIGHTING SYSTEM WITH RUNWAY ALIGNMENT
			//                                 INDICATOR LIGHTS
			//                         SSALS - SIMPLIFIED SHORT APPROACH LIGHTING SYSTEM
			//                         SSALF - SIMPLIFIED SHORT APPROACH LIGHTING SYSTEM
			//                                 WITH SEQUENCED FLASHERS
			//                         SSALR - SIMPLIFIED SHORT APPROACH LIGHTING SYSTEM
			//                                 WITH RUWNAY ALIGNMENT INDICATOR LIGHTS
			//                         NEON  - NEON LADDER SYSTEM
			//                         ODALS - OMNIDIRECTIONAL APPROACH LIGHTING SYSTEM
			//                         RLLS  - RUNWAY LEAD-IN LIGHT SYSTEM
			//                         MIL OVRN - MILITARY OVERRUN
			//                         NSTD  - ALL OTHERS
			//                         NONE  - NO APPROACH LIGHTING IS AVAILABLE
			//
			schema.AddColumn(new StringColumn("RunwayEndIdentifierLightsReilAvailability1"), 1);
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("RunwayCenterlineLightsAvailability1"), 1);
			//                           Y - YES
			//                           N - NO
			schema.AddColumn(new StringColumn("RunwayEndTouchdownLightsAvailability1"), 1);
			//                           Y - YES
			//                           N - NO
			//
			//                         -----------------------------------------------
			//                               RECIPROCAL END OBJECT DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("ControllingObjectDescription1"), 11);
			//                           (EX. TREES,BLDG,PLINE,FENCE,NONE)
			schema.AddColumn(new StringColumn("ControllingObjectMarkedlighted1"), 4);
			//                           M  - MARKED
			//                           L  - LIGHTED
			//                           ML - MARKED AND LIGHTED
			//                           NONE
			schema.AddColumn(new StringColumn("FaaCfrPart77ObjectsAffectingNavigableAirspace1"), 5);
			//                         RUNWAY CATEGORY
			//                           A(V)  - UTILITY RUNWAY WITH A VISUAL APPROACH
			//                           B(V)  - OTHER THAN UTILITY RUNWAY WITH A VISUAL
			//                                   APPROACH
			//                           A(NP) - UTILITY RUNWAY WITH A NONPRECISION APPROACH
			//                           C     - OTHER THAN UTILITY RUNWAY WITH A
			//                                   NONPRECISION APPROACH HAVING VISIBILITY
			//                                   MINIMUMS GREATER THAN 3/4 MILE
			//                           PIR   - PRECISION INSTRUMENT RUNWAY
			//
			schema.AddColumn(new StringColumn("ControllingObjectClearanceSlope1"), 2);
			//                           VALUE, EXPRESSED AS A RATIO OF N:1, OF THE
			//                           CLEARANCE THAT IS AVAILABLE TO APPROACHING
			//                           AIRCRAFT. IF THE CLEARANCE SLOPE IS GREATER THAN
			//                           50:1,THEN 50 OR 50+ WILL BE ENTERED.
			//                           (EX.  8,22,50)
			schema.AddColumn(new StringColumn("ControllingObjectHeightAboveRunway1"), 5);
			//                           HEIGHT, IN FEET AGL, THE OBJECT IS ABOVE
			//                           THE PHYSICAL RUNWAY END.
			//                           (EX. 100)
			schema.AddColumn(new StringColumn("ControllingObjectDistanceFromRunwayEnd1"), 5);
			//                           DISTANCE, IN FEET, FROM THE PHYSICAL RUNWAY END
			//                           TO THE CONTROLLING OBJECT. THIS IS MEASURED
			//                           USING THE EXTENDED RUNWAY CENTERLINE TO A POINT
			//                           ABEAM THE OBJECT.
			//                           (EX. 800  0  NONE)
			schema.AddColumn(new StringColumn("ControllingObjectCenterlineOffset1"), 7);
			//                           DISTANCE, IN FEET, THAT THE CONTROLLING OBJECT
			//                           IS LOCATED AWAY FROM THE EXTENDED RUNWAY CENTERLINE
			//                           AS MEASURED HORIZONTALLY ON A LINE PERPENDICULAR
			//                           TO THE EXTENDED RUNWAY CENTERLINE. ALSO, INDICATES
			//                           THE DIRECTION (LEFT OR RIGHT) TO THE OBJECT
			//                           FROM THE CENTERLINE AS SEEN BY AN APPROACHING
			//                           PILOT.
			//                           (EX. 50R, 75L, NONE)
			//
			//                         -----------------------------------------------
			//                               ADDITIONAL COMMON RUNWAY DATA
			//                         -----------------------------------------------
			schema.AddColumn(new StringColumn("RunwayLengthSource"), 16);
			schema.AddColumn(new DateTimeColumn("RunwayLengthSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("RunwayWeightbearingCapacityForS"), 6);
			//                         type landing gear (DC3), (C47), (F15), etc.
			schema.AddColumn(new StringColumn("RunwayWeightbearingCapacityForD"), 6);
			//                         type landing gear (BE1900), (B737), (A319), etc.
			schema.AddColumn(new StringColumn("RunwayWeightbearingCapacityForT"), 6);
			//                         in tandem type landing gear (B707), etc.
			schema.AddColumn(new StringColumn("RunwayWeightbearingCapacityForT1"), 6);
			//                         in tandem/two dual wheels in double tandem body gear
			//                         type landing gear (B747, E4).
			//
			//                         -----------------------------------------------
			//                               ADDITIONAL BASE END DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("RunwayEndGradient"), 5);
			schema.AddColumn(new StringColumn("RunwayEndGradientDirectionUpOrDown"), 4);
			schema.AddColumn(new StringColumn("RunwayEndPositionSource"), 16);
			schema.AddColumn(new DateTimeColumn("RunwayEndPositionSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("RunwayEndElevationSource"), 16);
			schema.AddColumn(new DateTimeColumn("RunwayEndElevationSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("DisplacedThesholdPositionSource"), 16);
			schema.AddColumn(new DateTimeColumn("DisplacedThesholdPositionSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("DisplacedThesholdElevationSource"), 16);
			schema.AddColumn(new DateTimeColumn("DisplacedThesholdElevationSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("TouchdownZoneElevationSource"), 16);
			schema.AddColumn(new DateTimeColumn("TouchdownZoneElevationSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("TakeoffRunAvailableToraInFeet"), 5);
			schema.AddColumn(new StringColumn("TakeoffDistanceAvailableTodaInFeet"), 5);
			schema.AddColumn(new StringColumn("AcltStopDistanceAvailableAsdaInFeet"), 5);
			schema.AddColumn(new StringColumn("LandingDistanceAvailableLdaInFeet"), 5);
			schema.AddColumn(new StringColumn("AvailableLandingDistanceForLandAndHoldShort"), 5);
			//                         OPERATIONS (LAHSO)
			schema.AddColumn(new StringColumn("IdOfIntersectingRunwayDefiningHoldShortPoint"), 7);
			schema.AddColumn(new StringColumn("DescriptionOfEntityDefiningHoldShortPointIf"), 40);
			//                         NOT AN INTERSECTING RUNWAY (E.G., AN INTERSECTING
			//                         TAXIWAY).
			schema.AddColumn(new StringColumn("LatitudeOfLahsoHoldShortPointFormatted"), 15);
			schema.AddColumn(new StringColumn("LatitudeOfLahsoHoldShortPointSeconds"), 12);
			schema.AddColumn(new StringColumn("LongitudeOfLahsoHoldShortPointFormatted"), 15);
			schema.AddColumn(new StringColumn("LongitudeOfLahsoHoldShortPointSeconds"), 12);
			schema.AddColumn(new StringColumn("LahsoHoldShortPointLatlongSource"), 16);
			schema.AddColumn(new DateTimeColumn("HoldShortPointLatlongSourceDate") { InputFormat = "MM/dd/yyyy" }, 10);
			//
			//                         -----------------------------------------------
			//                               ADDITIONAL RECIPROCAL END DATA
			//                         -----------------------------------------------
			//
			schema.AddColumn(new StringColumn("RunwayEndGradient1"), 5);
			schema.AddColumn(new StringColumn("RunwayEndGradientDirectionUpOrDown1"), 4);
			schema.AddColumn(new StringColumn("RunwayEndPositionSource1"), 16);
			schema.AddColumn(new DateTimeColumn("RunwayEndPositionSourceDate1") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("RunwayEndElevationSource1"), 16);
			schema.AddColumn(new DateTimeColumn("RunwayEndElevationSourceDate1") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("DisplacedThesholdPositionSource1"), 16);
			schema.AddColumn(new DateTimeColumn("DisplacedThesholdPositionSourceDate1") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("DisplacedThesholdElevationSource1"), 16);
			schema.AddColumn(new DateTimeColumn("DisplacedThesholdElevationSourceDate1") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("TouchdownZoneElevationSource1"), 16);
			schema.AddColumn(new DateTimeColumn("TouchdownZoneElevationSourceDate1") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("TakeoffRunAvailableToraInFeet1"), 5);
			schema.AddColumn(new StringColumn("TakeoffDistanceAvailableTodaInFeet1"), 5);
			schema.AddColumn(new StringColumn("AcltStopDistanceAvailableAsdaInFeet1"), 5);
			schema.AddColumn(new StringColumn("LandingDistanceAvailableLdaInFeet1"), 5);
			schema.AddColumn(new StringColumn("AvailableLandingDistanceForLandAndHoldShort1"), 5);
			//                         OPERATIONS (LAHSO)
			schema.AddColumn(new StringColumn("IdOfIntersectingRunwayDefiningHoldShortPoint1"), 7);
			schema.AddColumn(new StringColumn("DescriptionOfEntityDefiningHoldShortPointIf1"), 40);
			//                         NOT AN INTERSECTING RUNWAY (E.G., AN INTERSECTING
			//                         TAXIWAY).
			schema.AddColumn(new StringColumn("LatitudeOfLahsoHoldShortPointFormatted1"), 15);
			schema.AddColumn(new StringColumn("LatitudeOfLahsoHoldShortPointSeconds1"), 12);
			schema.AddColumn(new StringColumn("LongitudeOfLahsoHoldShortPointFormatted1"), 15);
			schema.AddColumn(new StringColumn("LongitudeOfLahsoHoldShortPointSeconds1"), 12);
			schema.AddColumn(new StringColumn("LahsoHoldShortPointLatlongSource1"), 16);
			schema.AddColumn(new DateTimeColumn("HoldShortPointLatlongSourceDate1") { InputFormat = "MM/dd/yyyy" }, 10);
			schema.AddColumn(new StringColumn("RunwayRecordFillerBlank"), 388);

			return schema;
		}

		public static FixedLengthSchema GetRunwayArrestingSystemSchema()
		{
			var schema = new FixedLengthSchema();
			//
			//
			//J  T   L   S L   E N
			//U  Y   E   T O   L U
			//S  P   N   A C   E M
			//T  E   G   R A   M B
			//       T   T T   E E
			//       H     I   N R
			//             O   T


			//             N           FIELD DESCRIPTION
			//************************************************************************
			//*       R U N W A Y   A R R E S T I N G   S Y S T E M   D A T A        *
			//************************************************************************
			//
			schema.AddColumn(new StringColumn("RecordTypeIndicator"), 3);
			//                            ARS:  ARRESTING SYSTEM RECORD FOR A RUNWAY
			//                            END AT THE LANDING FACILITY.
			schema.AddColumn(new StringColumn("LandingFacilitySiteNumber"), 11);
			//                            THE UNIQUE IDENTIFYING NUMBER OF THE
			//                            AIRPORT WHOSE ARRESTING SYSTEM IS
			//                            BEING DESCRIBED.
			schema.AddColumn(new StringColumn("LandingFacilityStatePostOfficeCode"), 2);
			//                            THE STATE WHERE THE LANDING FACILITY IS
			//                            LOCATED. THIS IS USED IN SORTING THE
			//                            ENTIRE FILE BY STATE AND SITE NUMBER.
			schema.AddColumn(new StringColumn("RunwayIdentification"), 7);
			//                            EX. 01/19; 18L/36R (PARALLEL RUNWAYS);
			//                                N/S (NORTH/SOUTH); ALL/WAY (SEALANE)
			schema.AddColumn(new StringColumn("RunwayEndIdentifier"), 3);
			//                           THE RUNWAY END DESCRIBED BY THE ARRESTING
			//                           SYSTEM INFORMATION.
			schema.AddColumn(new StringColumn("TypeOfAircraftArrestingDevice"), 9);
			//                           INDICATES TYPE OF JET ARRESTING BARRIER
			//                           INSTALLED AT THE FAR END.  POSSIBLE VALUES:
			//                           BAK-6
			//                           BAK-9
			//                           BAK-12
			//                           BAK-12B
			//                           BAK-13
			//                           BAK-14
			//                           E5
			//                           E5-1
			//                           E27
			//                           E27B
			//                           E28
			//                           E28B
			//                           EMAS
			//                           M21
			//                           MA-1
			//                           MA-1A
			//                           MA-1A MOD
			schema.AddColumn(new StringColumn("ArrestingSystemRecordFillerBlank"), 1494);

			return schema;
		}

		public static FixedLengthSchema GetRemarkSchema()
		{
			var schema = new FixedLengthSchema();

			//
			//
			//J  T   L   S L   E N
			//U  Y   E   T O   L U
			//S  P   N   A C   E M
			//T  E   G   R A   M B
			//       T   T T   E E
			//       H     I   N R
			//             O   T


			//             N           FIELD DESCRIPTION
			//************************************************************************
			//*          F A C I L I T Y   R E M A R K   D A T A                     *
			//************************************************************************
			//
			schema.AddColumn(new StringColumn("RecordTypeIndicator"), 3);
//                            RMK: REMARK TEXT FOR THE LANDING FACILITY
			schema.AddColumn(new StringColumn("LandingFacilitySiteNumber"), 11);
//                            THE UNIQUE IDENTIFYING NUMBER OF THE
//                            AIRPORT WHOSE ASSOCIATED REMARKS ARE
//                            BEING DESCRIBED. TOGETHER WITH THE
//                            REMARK ELEMENT NAME FIELD, THIS PROVIDES
//                            THE UNIQUE KEY TO A REMARK RECORD.
			schema.AddColumn(new StringColumn("LandingFacilityStatePostOfficeCode"), 2);
//                            THE STATE WHERE THE LANDING FACILITY IS
//                            LOCATED. THIS IS USED IN SORTING THE
//                            ENTIRE FILE BY STATE AND SITE NUMBER.
			schema.AddColumn(new StringColumn("RemarkElementName"), 13);
//                            THIS INFORMATION RELATES A REMARK TO ONE
//                            OF THE PREVIOUSLY DESCRIBED DATA ELEMENTS.
//                            FOR SPECIFIC REMARKS RELATED TO AN AIRPORT OR
//                            COMMON RUNWAY DATA, THE VALUE WILL BE JUST
//                            THE DATA ELEMENT NAME.  FOR DATA ELEMENT A81
//                            (LIGHTING SCHEDULE), THE NAME WILL BE FOLLOWED
//                            BY "-APT" OR "-BCN" TO DISTINGUISH BETWEEN
//                            AIRPORT LIGHTING SCHEDULE AND BEACON LIGHTING
//                            SCHEDULE.
//                            FOR SPECIFIC REMARKS PERTAINING TO A RUNWAY
//                            END THE FORMAT WILL BE THE DATA ELEMENT NAME
//                            FOLLOWED BY THE RUNWAY END.
//                            FOR SPECIFIC REMARKS PERTAINING TO A RUNWAY
//                            THE FORMAT WILL BE THE DATA ELEMENT NAME
//                            FOLLOWED BY THE RUNWAY ID.
//                            FOR NON-SPECIFIC OR GENERAL REMARKS, THIS
//                            FIELD WILL BE A110-N WHERE N IS A SEQUENTIAL
//                            NUMBER.
//                            (EX. E111  A81-APT  A110-3  A42-18  A55-H1)
//
			schema.AddColumn(new StringColumn("RemarkText"), 1500);
//                            FREE FORM TEXT THAT FURTHER DESCRIBES A
//                            SPECIFIC INFORMATION ITEM OR MAY BE GENERAL
//                            IN NATURE.
//
//
			return schema;
		}
	}
}
