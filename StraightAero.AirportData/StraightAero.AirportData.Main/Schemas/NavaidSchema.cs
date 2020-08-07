using FlatFiles.TypeMapping;

namespace StraightAero.AirportData.Main.Mappers
{
    public static class NavaidMapper
    {
        public static IFixedLengthTypeMapper<Navaid> GetNavaidMapper()
        {
            var mapper = FixedLengthTypeMapper.Define(() => new Navaid());
            //
            //                                NAVAID
            //                        DATA BASE RECORD LAYOUT
            //                             (NAV-FILE)
            //
            //INFORMATION EFFECTIVE DATE: 02/06/2014
            //
            //    RECORD FORMAT: FIXED
            //    LOGICAL RECORD LENGTH: 802
            //
            //
            //FILE STRUCTURE DESCRIPTION:
            //--------------------------
            //    THERE ARE A VARIABLE NUMBER OF FIXED LENGTH RECORDS FOR
            //    A SINGLE NAVIGATIONAL AID (NAVAID). THE NUMBER OF RECORDS IS
            //    DETERMINED BY THE REMARKS, AIRSPACE FIXES, HOLDING PATTERNS, AND
            //    FAN MARKERS RELATED TO EACH NAVAID.
            //    THE RECORDS ARE IDENTIFIABLE BY A RECORD TYPE INDICATOR - (NAV1,
            //    NAV2, NAV3, NAV4, NAV5, NAV6), THE NAVAID FACILITY
            //    LOCATION IDENTIFIER, AND THE NAVAID FACILITY TYPE.
            //
            //    EACH RECORD ENDS WITH A CARRIAGE RETURN CHARACTER AND LINE FEED
            //    CHARACTER (CR/LF). THIS LINE TERMINATOR IS NOT INCLUDED IN THE
            //    LOGICAL RECORD LENGTH.
            //
            //    THE FILE IS SORTED BY STATE, CITY, NAVAID NAME, AND FACILITY
            //    LOCATION IDENTIFIER.
            //
            //
            //DESCRIPTION OF THE RECORD TYPES:
            //-------------------------------
            //    THE 'NAV1' RECORD TYPE CONTAINS BASIC NAVAID INFORMATION.
            //    THERE IS ALWAYS A NAV1 RECORD.
            //
            //    THE 'NAV2' RECORD WILL CONTAINS ONE 600 CHARACTER REMARK
            //    PERTAINING TO THE PRECEEDING NAV1 RECORD.
            //
            //    THE 'NAV3' RECORD WILL CONTAIN THE COMPULSORY AND NON-COMPULSORY
            //    AIRSPACE FIXES ASSOCIATED WITH THE PRECEDING
            //    NAV1 RECORD.  THE RECORD IS PADDED TO ALLOW FOR A MAXIMUM
            //    OF 18 - 35 CHARACTER FIX ENTRIES.
            //
            //    THE 'NAV4' RECORD TYPE CONTAINS THE HOLDING PATTERN ASSOCIATED
            //    WITH THE PRECEDING NAV1 RECORD. WHEN MORE THAN 9 HOLDING PATTERNS
            //    EXIST, TWO OR MORE NAV4 RECORDS ARE CREATED FOR ONE PRECEDING
            //    NAV1 RECORD.
            //
            //    THE 'NAV5' RECORD TYPE CONTAINS THE FAN MARKERS ASSOCIATED WITH
            //    THE PRECEDING NAV1 RECORD.  THE RECORD IS PADDED TO ALLOW FOR A
            //    MAXIMUM OF 23 - 26 CHARACTER FAN MARKER ENTRIES.
            //
            //    THE 'NAV6' RECORD TYPE CONTAINS THE CHECKPOINTS ASSOCIATED WITH
            //    THE PRECEDING NAV1 RECORD.
            //
            //    EACH NAV1 RECORD MAY HAVE NONE, ONE OR MANY ASSOCIATED NAV2,
            //    NAV3, NAV4, NAV5 OR NAV6 RECORDS.  EACH NAV1, NAV2, NAV3, NAV4,
            //    NAV5, AND NAV6 RECORD CONTAINS THE BASIC NAVAID IDENTIFYING
            //    INFORMATION.
            //
            //(NAVAID FACILITY LOCATION IDENTIFIER AND THE NAVAID FACILITY TYPE).
            //
            //GENERAL INFORMATION:
            //-------------------
            //    1.  LEFT JUSTIFIED FIELDS HAVE TRAILING BLANKS
            //    2.  RIGHT JUSTIFIED FIELDS HAVE LEADING BLANKS
            //    3.  ELEMENT NUMBER IS FOR TERMINAL REFERENCE ONLY
            //        AND NOT IN THE RECORD.
            //    4.  THE UNIQUE NAV ID (ELEMENT NUMBER: DLID) IS MADE UP OF
            //        THE FACILITY IDENT, THE FACILITY TYPE CODE, AND THE CITY.
            //    5.  LATITUDE AND LONGITUDE INFORMATION IS REPRESENTED
            //        IN TWO WAYS:
            //        A.  FORMATTED:
            //           -----------
            //            LATITUDE     DD-MM-SS.SSSH
            //            LONGITUDE    DDD-MM-SS.SSSH
            //
            //        WHERE:           DD IS DEGREES
            //                         MM IS MINUTES
            //                         SS.SSS IS SECONDS
            //                         H IS DECLINATION
            //            EXAMPLE:     LAT-    39-06-51.070N
            //                         LONG-   075-27-54.660W
            //
            //        B.  IN ALL SECONDS :
            //            ----------------
            //            LATITUDE AND LONGITUDE       SSSSSS.SSSH
            //            WHERE    SSSSSS.SSS IS THE DEG/MIN/SEC CONVERTED
            //                     TO ALL SECONDS
            //                     H IS THE DECLINATION
            //
            //            EXAMPLE: LAT-     140811.070N
            //                     LONG-    27164.66W
            //
            //
            //****************************************************************
            //
            //             'NAV1' RECORD TYPE - BASE DATA
            //
            //****************************************************************
            //
            //J  T   L   S L   E N
            //U  Y   E   T O   L U
            //S  P   N   A C   E M
            //T  E   G   R A   M B
            //       T   T T   E E
            //       H     I   N R
            //             O   T
            //             N           FIELD DESCRIPTION
            //
            mapper.Property(x => x.RecordTypeIndicator, 4);
            //                         NAV1: BASIC NAVAID INFORMATION
            mapper.Property(x => x.NavaidFacilityIdentifier, 4);
            //****************NOTE:  Current unique key for this file is:
            //                         3 letter id + type + city
            mapper.Property(x => x.NavaidFacilityType, 20);
            //                         (EX: VOR/DME)
            //                 NAVAID           NAVAID
            //
            //                           TYPE          DESCRIPTION
            //                           ----          ------------
            //                           VORTAC        A FACILITY CONSISTING OF TWO
            //                                         COMPONENTS, VOR AND TACAN,
            //                                         WHICH PROVIDES THREE INDIVIDUAL
            //                                         SERVICES: VOR AZIMUTH, TACAN
            //                                         AZIMUTH AND TACAN DISTANCE(DME)
            //                                         AT ONE SITE.
            //
            //                           VOR/DME       VHF OMNI-DIRECTIONAL RANGE WITH
            //                                         ASSOCIATED DISTANCE MEASURING
            //                                         EQUIPMENT
            //
            //                           FAN MARKER    THERE ARE 3 TYPES OF EN ROUTE
            //                                         MARKER BEACONS. FAN MARKER
            //                                         LOW POWERED FAN MARKERS AND
            //                                         Z MARKERS.
            //                                         A FAN MARKER IS USED TO PROVIDE
            //                                         A POSITIVE IDENTIFICATION OF
            //                                         POSITIONS AT DEFINITE POINTS
            //                                         ALONG THE AIRWAYS.
            //
            //                           CONSOLAN      A LOW FREQUENCY, LONG-DISTANCE
            //                                         NAVAID USED PRINCIPALLY FOR
            //                                         TRANSOCEANIC NAVIGATION.
            //
            //                           MARINE NDB    A NON DIRECTIONAL BEACON
            //                                         USED PRIMARILY FOR MARINE
            //                                         (SURFACE) NAVIGATION.
            //
            //                           MARINE NDB/DME A NON DIRECTINAL BEACON
            //                                          WITH ASSOCIATED DISTANCE
            //                                          MEASURING EQUIPMENT; USED
            //                                          PRIMARILY FOR MARINE (SURFACE)
            //                                          NAVIGATION.
            //
            //                           VOT           A FAA VOR TEST FACILITY
            //
            //                           NDB           A NONDIRECTIONAL BEACON
            //
            //                           NDB/DME       NON DIRECTIONAL BEACON WITH
            //                                         ASSOCIATED DISTANCE MEASURING
            //                                         EQUIPMENT.
            //
            //                           TACAN         A TACTICAL AIR NAVIGATION
            //                                         SYSTEM PROVIDING ASIMUTH AND
            //                                         SLANT RANGE DISTANCE.
            //
            //                           UHF/NDB       ULTRA HIGH FREQUENCY/
            //                                         NON DIRECTIONAL BEACON
            //
            //                           VOR           A VHF OMNI-DIRECTIONAL RANGE
            //                                         PROVIDENCE ASIMUTH ONLY
            //
            //			   DME           DISTANCE MEASURING EQUIPMENT ONLY
            //
            mapper.Property(x => x.OfficialNavaidFacilityIdentifier, 4);
            //
            //                         -----------------------------------------------
            //                                    ADMINISTRATIVE   DATA
            //                         -----------------------------------------------
            mapper.Property(x => x.EffectiveDateThisDateCoincidesWith, 10).InputFormat("MM/dd/yyyy");
            //                         THE 56-DAY CHARTING AND PUBLICATION CYCLE
            //                         EFFECTIVE DATE.
            mapper.Property(x => x.NameOfNavaidexWashington, 30);
            mapper.Property(x => x.CityAssociatedWithTheNavaid, 40);
            //                         (EX: WASHINGTON)
            mapper.Property(x => x.StateNameWhereAssociatedCityIsLocated, 30);
            //                          (MAY NOT BE SAME STATE WHERE NAVAID IS
            //                           LOCATED) (EX: DC)
            mapper.Property(x => x.StatePostOfficeCodeWhereAssociated, 2);
            //                         CITY IS LOCATED.
            //                         (MAY NOT BE SAME STATE WHERE NAVAID IS
            //                          LOCATED) (EX: DC)
            mapper.Property(x => x.FaaRegionResponsibleForNavaidCode, 3);
            //                         (EX: AEA)
            //
            //                           REGION
            //                            CODES          REGION NAME
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
            //
            mapper.Property(x => x.CountryNavaidLocatedIfOtherThanUs, 30);
            //                         (NAME) (EX: CANADA)
            mapper.Property(x => x.CountryPostOfficeCodeNavaid, 2);
            //                         LOCATED IF OTHER THAN U.S. (EX: CA)
            mapper.Property(x => x.NavaidOwnerNameExUsNavy, 50);
            mapper.Property(x => x.NavaidOperatorNameExUsNavy, 50);
            mapper.Property(x => x.CommonSystemUsageYOrN, 1);
            //                         DEFINES HOW THE NAVAID IS USED.
            mapper.Property(x => x.NavaidPublicUseYOrN, 1);
            //                         DEFINES BY WHOM THE NAVAID IS USED
            mapper.Property(x => x.ClassOfNavaid, 11);
            //                         THE NAVAID CLASS DESIGNATOR MAY BE COMPRISED
            //                         OF AN ALTITUDE CODE (VOR, VORTAC, VOR/DME, AND
            //                         TACAN FACILITIES ONLY), AND/OR A COMBINATION
            //                         OF CLASS CODES.
            //
            //
            //                                   _______________________
            //
            //                         ALTITUDE CODE      ALTITUDE DESCRIPTION
            //                         -------------      --------------------
            //                         H                  HIGH
            //                         L                  LOW
            //                         T                  TERMINAL
            //
            //                          SEPARATOR CHARACTER:  - (DASH)
            //                          -------------------
            //
            //                              CLASS CODE/DESCRIPTION
            //                              ----------------------
            //                         AB     AUTOMATIC WEATHER BROADCAST.
            //
            //                         DME    UHF STANDARD (TACAN COMPATIBLE) DISTANCE
            //                                MEASURING EQUIPMENT.
            //
            //                         DME(Y) UHF STANDARD (TACAN COMPATIBLE) DISTANCE
            //                                MEASURING EQUIPMENT THAT REQUIRES TACAN
            //                                RECEIVERS TO BE PLACED IN THE 'Y' MODE
            //                                TO RECEIVE DME
            //
            //                         H      NON-DIRECTIONAL RADIO BEACON (NDB),
            //                                (HOMING), POWER 50 WATTS TO LESS THAN
            //                                2000 WATTS (50 NM AT ALL ALTITUDES).
            //
            //                         HH     NON-DIRECTIONAL RADIO BEACON (NDB),
            //                                (HOMING), POWER 2000 WATTS OR MORE
            //                                (75 NM AT ALL ALTITUDES)
            //
            //                         H-SAB  NON-DIRECTIONAL RADIO BEACON PROVIDING
            //                                AUTOMATIC TRANSCRIBED WEATHER SERVICE.
            //
            //                         LMM    COMPASS LOCATOR STATION WHEN INSTALLED
            //                                AT MIDDLE MARKER SITE (15 NM AT ALL
            //                                ALTITUDES).
            //
            //                         LOM    COMPASS LOCATOR STATION WHEN INSTALLED
            //                                AT OUTER MARKER SITE (15 NM AT ALL
            //                                ALTITUDES).
            //
            //                         MH     NON-DIRECTIONAL RADIO BEACON (NDB)
            //                                (HOMING), POWER LESS THAN 50 WATTS
            //                                (25 NM AT ALL ALTITUDES)
            //
            //                         S      SIMULTANEOUS RANGE HOMING SIGNAL AND/OR
            //                                VOICE
            //
            //                         SABH   NON-DIRECTIONAL RADIO BEACON (NDB) NOT
            //                                AUTHORIZED FOR IFR OR ATC. PROVIDES
            //                                AUTOMATIC WEATHER BROADCASTS.
            //
            //                         TACAN  UHF NAVIGATIONAL FACILITY-OMNIDIREC-
            //                                TIONAL COURSE AND DISTANCE INFORMATION.
            //
            //                         VOR    VHF NAVIGATIONAL FACILITY-OMNIDIREC-
            //                                TIONAL COURSE ONLY.
            //
            //                         VOR/DME COLLOCATED VOR NAVIGATIONAL FACILITY
            //                                 AND UHF STANDARD DISTANCE MEASURING
            //                                 EQUIPMENT.
            //
            //                         VORTAC  COLLOCATED VOR AND TACAN NAVIGATIONAL
            //                                 FACILITIES.
            //
            //                         W       WITHOUT VOICE ON RADIO FACILITY
            //                                 FREQUENCY.
            //
            //                         Z       VHF STATION LOCATION MARKER AT A LF
            //                                 RADIO FACILITY.
            //
            //                         EXAMPLES:   H-ABVORTAC, L-VOR, H, HH, MH-SAB,
            //                                     MHW/LOM, H-SAB/LOM
            //
            //                         NOTE:       MULTIPLE CLASS CODE TYPES MAY BE
            //                                     SEPARATED BY A / (SLANT) OR A - (DASH)
            //
            //                         **** AUXILIARY CANADA CLASS CODES   ****
            //                                   --------------------
            //
            //                         THESE CODES MAY APPEAR SINGLY, IN
            //                         MULTIPLES, OR COMBINED WITH THE CODES LISTED
            //                         ABOVE:
            //
            //                                CLASS CODE/DESCRIPTION
            //                                ----------------------
            //
            //                         A       ATIS(AUTOMATIC TERMINAL INFORMATION
            //                                      SERVICE)
            //
            //                         C       TRANSCRIBED WEATHER BROADCAST STATION
            //
            //                         B       SCHEDULED WEATHER BROADCAST
            //
            //                         T       FSS OR OTHER ATC AGENCY (EXCEPT PAR)
            //                                 CAN TRANSMIT ON THIS NAVIGATION FRE-
            //                                 QUENCY BUT NOT RECEIVE
            //
            //                         P       PRECISION APPROACH RADAR BACK-UP FRE-
            //                                 QUENCY
            //
            //                         L       NDB POWER OUTPUT LESS THAN 50 WATTS
            //
            //                         M       NDB POWER OUTPUT 50 TO LESS THAN 2000
            //                                 WATTS
            //
            //                         H       NDB POWER OUTPUT 2000 WATTS OR MORE
            //
            //                         Z       75 MHZ STATION LOCATION MARKER OR FAN
            //                                 MARKER
            //
            //                         EXAMPLE: M,L,CTMZ,TPM,MZ,LZ,TMZ,BT,
            //                                  TACAN,VOR/DME,VOR
            //
            //                                  ------ END OF N28 DESCRIPTION -----
            //
            //
            mapper.Property(x => x.HoursOfOperationOfNavaid, 11);
            //                          (EX:  0800-2400)
            mapper.Property(x => x.IdentifierOfArtccWithHighAltitudeBoundaryThatTheNavaid, 4);
            //                         FALLS WITHIN.
            mapper.Property(x => x.NameOfArtccWithHighAltitudeBoundaryThatTheNavaid, 30);
            //                         FALLS WITHIN.
            mapper.Property(x => x.IdentifierOfArtccWithLowAltitudeBoundaryThatTheNavaid, 4);
            //                         FALLS WITHIN.
            mapper.Property(x => x.NameOfArtccWithLowAltitudeBoundaryThatTheNavaid, 30);
            //                         FALLS WITHIN.
            //                         -----------------------------------------------
            //                                   GEOGRAPHICAL POSITION DATA
            //                         -----------------------------------------------
            //
            mapper.Property(x => x.NavaidLatitudeFormatted, 14);
            mapper.Property(x => x.NavaidLatitudeAllSeconds, 11);
            mapper.Property(x => x.NavaidLongitudeFormatted, 14);
            mapper.Property(x => x.NavaidLongitudeAllSeconds, 11);
            mapper.Property(x => x.LatitudelongitudeSurveryAccuracyCode, 1);
            //
            //                           (N38) SURVERY ACCURACY CODE/DESCRIPTION
            //                                 ---------------------------------
            //                                          0  =  UNKNOWN
            //                                          1  =  DEGREE
            //                                          2  =  10 MINUTES
            //                                          3  =   1 MINUTE
            //                                          4  =  10 SECONDS
            //                                          5  =   1 SECOND OR BETTER
            //                                          6  =     NOS
            //                                          7  =  3RD ORDER TRIANGULATION
            //
            mapper.Property(x => x.LatitudeOfTacanPortionOfVortacWhenTacan, 14);
            //                          IS NOT SITED WITH VOR (FORMATTED)
            mapper.Property(x => x.LatitudeOfTacanPortionOfVortacWhenTacan1, 11);
            //                          IS NOT SITED WITH VOR (ALL SECONDS)
            mapper.Property(x => x.LongitudeOfTacanPortionOfVortacWhenTacan, 14);
            //                          IS NOT SITED WITH VOR (FORMATTED)
            mapper.Property(x => x.LongitudeOfTacanPortionOfVortacWhenTacan1, 11);
            //                          IS NOT SITED WITH VOR (ALL SECONDS)
            mapper.Property(x => x.ElevationInTenthOfAFootMsl, 7);
            //                         (N45) MAGNETIC VARIATION
            //                               ------------------
            mapper.Property(x => x.MagneticVariationDegrees0099, 5);
            //                          FOLLOWED BY MAGNETIC VARIATION
            //                          DIRECTION (E,W)
            //                           (EX: 8080W)
            mapper.Property(x => x.MagneticVariationEpochYear0099, 4);
            //                            --- END OF N45 DESCRIPTION ---
            //
            //                         -----------------------------------------------
            //                                 FACILITIES/FEATURES OF NAVAID
            //                         -----------------------------------------------
            //
            mapper.Property(x => x.SimultaneousVoiceFeatureYnOrNull, 3);
            mapper.Property(x => x.PowerOutputInWatts, 4);
            mapper.Property(x => x.AutomaticVoiceIdentificationFeature, 3);
            //                         (Y, N, OR NULL)
            mapper.Property(x => x.MonitoringCategory, 1);
            //
            //                         (N36) MONITORING CATEGORY (1,2,3,4)
            //                               -----------------------------
            //                          1-INTERNAL MONITORING PLUS A STATUS INDICATOR
            //                            INSTALLED AT CONTROL POINT. (REVERTS TO A
            //                            TEMPORARY CATEGORY 3 STATUS WHEN THE CONTROL
            //                            POINT IS NOT MANNED.)
            //
            //                          2-INTERNAL MONITORING WITH STATUS INDICATOR AT
            //                            CONTROL POINT INOPERATIVE BUT PILOT REPORTS
            //                            INDICATE FACILITY IS OPERATING NORMALLY.
            //                             (THIS IS A TEMPORARY SITUATION THAT
            //                              REQUIRES NO PROCEDURAL ACTION.)
            //
            //                          3-INTERNAL MONITORING ONLY. STATUS INDICATOR
            //                            NON INSTALLED AT CONTROL POINT.
            //
            //                          4-INTERNAL MONITOR NOT INSTALLED. REMOTE
            //                            STATUS INDICATOR PROVIDED AT CONTROL POINT.
            //                            THIS CATEGORY IS APPLICABLE ONLY TO
            //                            NON-DIRECTIONAL  BEACONS.
            //                                   ---- END OF N36 DESCRIPTION ----
            //
            mapper.Property(x => x.RadioVoiceCallName, 30);
            //                         (EX: WASHINGTON RADIO)
            mapper.Property(x => x.ChannelTacanNavaidTransmitsOn, 4);
            //                         (EX : 051X)
            mapper.Property(x => x.FrequencyTheNavaidTransmitsOn, 6);
            //                         (EXCEPT TACAN)
            //                         (EX:  110.60 298)
            mapper.Property(x => x.TransmittedFanMarkermarineRadioBeacon, 24);
            //                          IDENTIFIER  EX: (DOT,DASH SEQUENCE USED)
            mapper.Property(x => x.FanMarkerTypeBoneOrElliptical, 10);
            mapper.Property(x => x.TrueBearingOfMajorAxisOfFanMarker, 3);
            //                           EX: IN WHOLE DEGREES (001-360)
            mapper.Property(x => x.ProtectedFrequencyAltitude, 1);
            //                          H=HIGH, L=LOW, T=TERMINAL
            //
            //
            //
            //                          CLASS     ALTITIUDE            MILES
            //                          -----     ---------            -----
            //                          T         12,000' AND BELOW      25
            //                          L         BELOW 18,000'          40
            //                          H         BELOW 18,000'          40
            //                          H         WITHIN THE CONTER-     100
            //                                    MINOUS 48 STATES
            //                                    ONLY BETWEEN 14,500'
            //                                    AND 17,999'
            //                          H         18,000' FL 450         130
            //                          H         ABOVE FL 450           100
            //
            mapper.Property(x => x.LowAltitudeFacilityUsedInHighStructure, 3);
            //                         (Y, N, OR NULL)
            mapper.Property(x => x.NavaidZMarkerAvailableYNOrNull, 3);
            mapper.Property(x => x.TranscribedWeatherBroadcastHoursTweb, 9);
            //                         (EX: 0500-2200)
            mapper.Property(x => x.TranscribedWeatherBroadcastPhoneNumber, 20);
            mapper.Property(x => x.AssociatedControllingFssIdent, 4);
            mapper.Property(x => x.AssociatedControllingFssName, 30);
            mapper.Property(x => x.HoursOfOperationOfControllingFss, 100);
            //                          (EX: 0800-2400)
            mapper.Property(x => x.NotamAccountabilityCodeIdent, 4);
            //
            //                        -----------------------------------------------
            //                                   CHARTING  DATA
            //                        -----------------------------------------------
            //
            mapper.Property(x => x.QuadrantIdentificationAndRangeLegBearing, 16);
            //                         (LFR ONLY) (EX: 151N190A311N036A)
            //
            //                        -----------------------------------------------
            //                                   NAVAID STATUS
            //                        -----------------------------------------------
            //
            mapper.Property(x => x.NavigationAidStatus, 30);
            //                 N42
            //
            //                         -----------------------------------------------
            //                             PITCH, CATCH, AND SUA/ATCAA FLAGS
            //                         -----------------------------------------------
            //
            mapper.Property(x => x.PitchFlagYOrN, 1);
            //
            mapper.Property(x => x.CatchFlagYOrN, 1);
            //
            mapper.Property(x => x.SuaatcaaFlagYOrN, 1);
            //
            mapper.Property(x => x.NavaidRestrictionFlag, 1);
            //			(Y, N, OR NULL)
            mapper.Property(x => x.HiwasFlag, 1);
            //                        (Y, N, OR NULL)
            mapper.Property(x => x.TranscribedWeatherBroadcastTwebRestriction, 1);
            //  			(Y, N, OR NULL)
            //
            //
            return mapper;
        }

        //*********************************************************************
        //*
        //*            'NAV2' RECORD TYPE - NAVAID REMARKS
        //*
        //*********************************************************************
        //
        //J  T   L   S L   E N
        //U  Y   E   T O   L U
        //S  P   N   A C   E M
        //T  E   G   R A   M B
        //       T   T T   E E
        //       H     I   N R
        //             O   T
        public static IFixedLengthTypeMapper<NavaidRemark> GetNavaidRemarksMapper()
        {
            var mapper = FixedLengthTypeMapper.Define(() => new NavaidRemark());
            //             N           FIELD DESCRIPTION
            //
            mapper.Property(x => x.RecordTypeIndicator, 4);
            //                         NAV2: NAVAID REMARKS
            mapper.Property(x => x.NavaidFacilityIdentifier, 4);
            mapper.Property(x => x.NavaidFacitityTypeExVordme, 20);
            //                         (SEE NAV1 RECORD FOR DESCRIPTION)
            mapper.Property(x => x.NavaidRemarksFreeFormText, 600);
            mapper.Property(x => x.Filler, 174);
            return mapper;
        }
        //
        //*********************************************************************
        //*
        //*            'NAV3' RECORD TYPE - COMPULSORY AND NON-COMPULSORY
        //*                                 AIRSPACE FIXES ASSOCIATED WITH NAVAID
        //*
        //*********************************************************************
        //
        //J  T   L   S L   E N
        //U  Y   E   T O   L U
        //S  P   N   A C   E M
        //T  E   G   R A   M B
        //       T   T T   E E
        //       H     I   N R
        //             O   T

        public static IFixedLengthTypeMapper<AirspaceFixAssociatedWithNavaid> GetAirspaceFixesAssociatedWithNavaidMapper()
        {
            var mapper = FixedLengthTypeMapper.Define(() => new AirspaceFixAssociatedWithNavaid());
            mapper.Property(x => x.RecordTypeIndicator, 4);
            //                         NAV3: CUMPULSORY AND NON-CUMPULSORY AIRSPACE
            //                               FIXES ASSOCIATED WITH NAVAID
            mapper.Property(x => x.NavaidFacilityIdentifier, 4);
            mapper.Property(x => x.NavaidFacitityTypeExVordme, 20);
            //                         (SEE NAV1 RECORD FOR NAVAID FACILITY TYPE)
            mapper.Property(x => x.NamesOfFixesFixfileTheIdsOf, 36);
            //                         THE STATE IN WHICH THE FIX IS LOCATED, AND
            //                         THE ASSOCIATED ICAO REGION CODE.
            //                         (EX: FIX NAME*FIX STATE*ICAO REGION CODE -
            //                          WHITE*TX*K1; ORICH*LA*K2)
            mapper.Property(x => x.SpaceAllocatedFor20MoreFixes, 720);
            //                         (NOTE:  THIS RECORD MAY CONTAIN UP TO
            //                                 21 FIX DATA)
            mapper.Property(x => x.Blanks, 18);

            return mapper;
        }
        //
        //
        //*********************************************************************
        //*
        //*            'NAV4' RECORD TYPE - HOLDING PATTERNs (HPF) ASSOCIATED
        //*                                 WITH NAVAID
        //*
        //*********************************************************************
        //
        //J  T   L   S L   E N
        //U  Y   E   T O   L U
        //S  P   N   A C   E M
        //T  E   G   R A   M B
        //       T   T T   E E
        //       H     I   N R
        //             O   T
        public static IFixedLengthTypeMapper<HoldingPattern> GetHoldingPatternMapper()
        {
            var mapper = FixedLengthTypeMapper.Define(() => new HoldingPattern());
            mapper.Property(x => x.RecordTypeIndicator, 4);
            //                         NAV4: HOLDING PATTERNS ASSOCIATED WITH NAVAID
            mapper.Property(x => x.NavaidFacilityIdentifier, 4);
            mapper.Property(x => x.NavaidFacitityTypeExVordme, 20);
            //                         (SEE 'NAV1' RECORD FOR DESCRIPTION)
            //
            mapper.Property(x => x.NamesOfHoldingPatterns, 80);
            //                         AND THE STATE IN WHICH THE
            //                         HOLDING PATTERN(S) IS (ARE) LOCATED.
            //                          (EX: NAVAID NAME & FAC TYPE*NAV STATE-
            //                                  GEORGETOWN NDB*TX)
            mapper.Property(x => x.PatternNumberOfTheHoldingPattern, 3);
            mapper.Property(x => x.SpaceAllocatedFor8MoreHoldingPatterns, 664);
            //                         EACH HOLDING PATTERN HAS 80 CHARACTER NAME
            //                         AND 3 FOR PATTERN (NUMBER).
            mapper.Property(x => x.Blanks, 27);
            return mapper;
        }


        //
        //********************************************************************
        //*
        //*            'NAV5' RECORD TYPE - FAN MARKERS ASSOCIATED WITH NAVAID
        //*
        //********************************************************************
        //
        //J  T   L   S L   E N
        //U  Y   E   T O   L U
        //S  P   N   A C   E M
        //T  E   G   R A   M B
        //       T   T T   E E
        //       H     I   N R
        //             O   T
        public static IFixedLengthTypeMapper<FanMarkerAssociatedwithnavaid> GetFanmarkerMapper()
        {
            var mapper = FixedLengthTypeMapper.Define(() => new FanMarkerAssociatedwithnavaid());
            mapper.Property(x => x.RecordTypeIndicator, 4);
            //                         NAV5: FAN MARKER ASSOCIATED WITH NAVAID
            mapper.Property(x => x.NavaidFacilityIdentifier, 4);
            mapper.Property(x => x.NavaidFacitityTypeExVordme, 20);
            //                         (SEE NAV1 RECORD DESCRIPTION)
            mapper.Property(x => x.NamesOfFanMarkers, 30);
            mapper.Property(x => x.SpaceAllocatedFor23MoreFanMarkers, 690);
            //                         (NOTE:  THIS RECORD MAY CONTAIN UP TO
            //                                 24 FAN MARKERS)
            mapper.Property(x => x.Blanks, 54);
            return mapper;
        }

        //
        //********************************************************************
        //*
        //* NAV6' RECORD TYPE - VOR RECEIVER CHECKPOINTS ASSOCIATED WITH NAVAID
        //*
        //********************************************************************
        //
        //J  T   L   S L   E N
        //U  Y   E   T O   L U
        //S  P   N   A C   E M
        //T  E   G   R A   M B
        //       T   T T   E E
        //       H     I   N R
        //             O   T
        public static IFixedLengthTypeMapper<VorReceiverCheckpointAssociatedWithNavaid> GetReceiverCheckpointMapper()
        {
            var mapper = FixedLengthTypeMapper.Define(() => new VorReceiverCheckpointAssociatedWithNavaid());
            mapper.Property(x => x.RecordTypeIndicator, 4);
            //                         NAV6: VOR RECEIVER CHECKPOINT ASSOCIATED WITH NAVAID
            mapper.Property(x => x.NavaidFacilityIdentifier, 4);
            mapper.Property(x => x.NavaidFacitityTypeExVordme, 20);
            //                         (SEE NAV1 RECORD DESCRIPTION)
            mapper.Property(x => x.AirgroundCode, 2);
            //                         A=AIR, G=GROUND, G1=GROUND ONE
            mapper.Property(x => x.BearingOfCheckpoint, 3);
            mapper.Property(x => x.AltitudeOnlyWhenCheckpointIsInAir, 5);
            mapper.Property(x => x.AirportId, 4);
            mapper.Property(x => x.StateCodeInWhichAssociatedCityIsLocated, 2);
            mapper.Property(x => x.NarrativeDescriptionAssociatedWith, 75);
            //                         THE CHECKPOINT IN AIR
            mapper.Property(x => x.NarrativeDescriptionAssociatedWith1, 75);
            //                         THE CHECKPOINT ON GROUND
            mapper.Property(x => x.Blanks, 608);
            return mapper;
        }
    }
}
