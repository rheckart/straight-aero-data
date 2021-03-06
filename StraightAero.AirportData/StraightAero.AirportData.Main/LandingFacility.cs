using System;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Spatial;

namespace StraightAero.AirportData.Main
{
	public class LandingFacilityData
	{
        public string id { get; set; }
        public string RecordTypeIndicator { get; set; }
		public string LandingFacilitySiteNumber { get; set; }
		public string LandingFacilityType { get; set; }
		public string LocationIdentifier { get; set; }
		public DateTime InformationEffectiveDate { get; set; }
		public string FaaRegionCode { get; set; }
		public string FaaDistrictOrFieldOfficeCode { get; set; }
		public string AssociatedStatePostOfficeCode { get; set; }
		public string AssociatedStateName { get; set; }
		public string AssociatedCountyOrParishName { get; set; }
		public string AssociatedCountysStatePostOfficeCode { get; set; }
		public string AssociatedCityName { get; set; }
		public string OfficialFacilityName { get; set; }
		public string AirportOwnershipType { get; set; }
		public string FacilityUse { get; set; }
		public string FacilityOwnersName { get; set; }
		public string OwnersAddress { get; set; }
		public string OwnersCityStateAndZipCode { get; set; }
		public string OwnersPhoneNumber { get; set; }
		public string FacilityManagersName { get; set; }
		public string ManagersAddress { get; set; }
		public string ManagersCityStateAndZipCode { get; set; }
		public string ManagersPhoneNumber { get; set; }
		public string AirportReferencePointLatitudeFormatted { get; set; }
		public string AirportReferencePointLatitudeSeconds { get; set; }
		public string AirportReferencePointLongitudeFormatted { get; set; }
		public string AirportReferencePointLongitudeSeconds { get; set; }
		public string AirportReferencePointDeterminationMethod { get; set; }
		public string AirportElevationNearestTenthOfAFootMsl { get; set; }
		public string AirportElevationDeterminationMethod { get; set; }
		public string MagneticVariationAndDirection { get; set; }
		public string MagneticVariationEpochYear { get; set; }
		public string TrafficPatternAltitudeWholeFeetAgl { get; set; }
		public string AeronauticalSectionalChartOnWhichFacility { get; set; }
		public string DistanceFromCentralBusinessDistrictOf { get; set; }
		public string DirectionOfAirportFromCentralBusiness { get; set; }
		public string LandAreaCoveredByAirportAcres { get; set; }
		public string BoundaryArtccIdentifier { get; set; }
		public string BoundaryArtccFaaComputerIdentifier { get; set; }
		public string BoundaryArtccName { get; set; }
		public string ResponsibleArtccIdentifier { get; set; }
		public string ResponsibleArtccFaaComputerIdentifier { get; set; }
		public string ResponsibleArtccName { get; set; }
		public string TieinFssPhysicallyLocatedOnFacility { get; set; }
		public string TieinFlightServiceStationFssIdentifier { get; set; }
		public string TieinFssName { get; set; }
		public string LocalPhoneNumberFromAirportToFss { get; set; }
		public string TollFreePhoneNumberFromAirportToFss { get; set; }
		public string AlternateFssIdentifier { get; set; }
		public string AlternateFssName { get; set; }
		public string TollFreePhoneNumberFromAirportTo { get; set; }
		public string IdentifierOfTheFacilityResponsibleFor { get; set; }
		public string AvailabilityOfNotamDServiceAtAirport { get; set; }
		public DateTime? AirportActivationDateMmyyyy { get; set; }
		public string AirportStatusCode { get; set; }
		public string AirportArffCertificationTypeAndDate { get; set; }
		public string NpiasfederalAgreementsCode { get; set; }
		public string AirportAirspaceAnalysisDetermination { get; set; }
		public string FacilityHasBeenDesignatedByTheUsDepartment { get; set; }
		public string FacilityHasBeenDesignatedByTheUsDepartment1 { get; set; }
		public string FacilityHasMilitarycivilJointUseAgreement { get; set; }
		public string AirportHasEnteredIntoAnAgreementThat { get; set; }
		public string AirportInspectionMethod { get; set; }
		public string AgencygroupPerformingPhysicalInspection { get; set; }
		public DateTime? LastPhysicalInspectionDate { get; set; }
		public DateTime? LastDateInformationRequestWasCompleted { get; set; }
		public string FuelTypesAvailableForPublicUseAtThe { get; set; }
		public string AirframeRepairServiceAvailabilitytype { get; set; }
		public string PowerPlantEngineRepairAvailabilitytype { get; set; }
		public string TypeOfBottledOxygenAvailableValueRepresents { get; set; }
		public string TypeOfBulkOxygenAvailableValueRepresents { get; set; }
		public string AirportLightingSchedule { get; set; }
		public string BeaconLightingSchedule { get; set; }
		public string AirTrafficControlTowerLocatedOnAirport { get; set; }
		public string UnicomFrequencyAvailableAtTheAirport { get; set; }
		public string CommonTrafficAdvisoryFrequencyCtaf { get; set; }
		public string SegmentedCircleAirportMarkerSystemOnTheAirport { get; set; }
		public string LensColorOfOperableBeaconLocatedOnTheAirport { get; set; }
		public string LandingFeeChargedToNoncommercialUsersOf { get; set; }
		public string AYInThisFieldIndicatesThatTheLanding { get; set; }
		public int? SingleEngineGeneralAviationAircraft { get; set; }
		public int? MultiEngineGeneralAviationAircraft { get; set; }
		public int? JetEngineGeneralAviationAircraft { get; set; }
		public int? GeneralAviationHelicopter { get; set; }
		public int? OperationalGliders { get; set; }
		public int? OperationalMilitaryAircraftIncludingHelicopters { get; set; }
		public int? UltralightAircraft { get; set; }
		public int? CommercialServices { get; set; }
		public int? CommuterServices { get; set; }
		public int? AirTaxi { get; set; }
		public int? GeneralAviationLocalOperations { get; set; }
		public int? GeneralAviationItinerantOperations { get; set; }
		public int? MilitaryAircraftOperations { get; set; }
		public DateTime? TwelveMonthEndingDateOnWhichAnnualOperationsData { get; set; }
		public string AirportPositionSource { get; set; }
		public DateTime? AirportPositionSourceDate { get; set; }
		public string AirportElevationSource { get; set; }
		public DateTime? AirportElevationSourceDate { get; set; }
		public string ContractFuelAvailable { get; set; }
		public string TransientStorageFacilities { get; set; }
		public string OtherAirportServicesAvailable { get; set; }
		public string WindIndicator { get; set; }
		public string IcaoIdentifier { get; set; }
		public string MinimumOperationalNetworkmon { get; set; }
		public string AirportRecordFillerBlank { get; set; }

		public List<FacilityAttendanceScheduleData> AttendanceSchedule { get; set; }
		public List<FacilityRunwayData> Runways { get; set; }

		public List<RunwayArrestingSystemData> ArrestingSystems { get; set; }
		public List<FacilityRemarkData> Remarks { get; set; }

		public Point Location { get; set; }
	}

	public class FacilityAttendanceScheduleData
	{
		public string RecordTypeIndicator { get; set; }
		public string LandingFacilitySiteNumber { get; set; }
		public string LandingFacilityStatePostOfficeCode { get; set; }
		public string AttendanceScheduleSequenceNumber { get; set; }
		public string AirportAttendanceScheduleWhenMinimum { get; set; }
		public string AttendanceScheduleRecordFillerBlank { get; set; }
	}

	public class FacilityRunwayData
	{
		public string RecordTypeIndicator { get; set; }
		public string LandingFacilitySiteNumber { get; set; }
		public string RunwayStatePostOfficeCode { get; set; }
		public string RunwayIdentification { get; set; }
		public string PhysicalRunwayLengthNearestFoot { get; set; }
		public string PhysicalRunwayWidthNearestFoot { get; set; }
		public string RunwaySurfaceTypeAndCondition { get; set; }
		public string RunwaySurfaceTreatment { get; set; }
		public string PavementClassificationNumberPcn { get; set; }
		public string RunwayLightsEdgeIntensity { get; set; }
		public string BaseEndIdentifier { get; set; }
		public string RunwayEndTrueAlignment { get; set; }
		public string InstrumentLandingSystemIlsType { get; set; }
		public string RightHandTrafficPatternForLandingAircraft { get; set; }
		public string RunwayMarkingsType { get; set; }
		public string RunwayMarkingsCondition { get; set; }
		public string LatitudeOfPhysicalRunwayEndFormatted { get; set; }
		public string LatitudeOfPhysicalRunwayEndSeconds { get; set; }
		public string LongitudeOfPhysicalRunwayEndFormatted { get; set; }
		public string LongitudeOfPhysicalRunwayEndSeconds { get; set; }
		public string ElevationFeetMslAtPhysicalRunwayEnd { get; set; }
		public string ThresholdCrossingHeightFeetAgl { get; set; }
		public string VisualGlidePathAngleHundredthsOfDegrees { get; set; }
		public string LatitudeAtDisplacedThresholdFormatted { get; set; }
		public string LatitudeAtDisplacedThresholdSeconds { get; set; }
		public string LongitudeAtDisplacedThresholdFormatted { get; set; }
		public string LongitudeAtDisplacedThresholdSeconds { get; set; }
		public string ElevationAtDisplacedThresholdFeetMsl { get; set; }
		public string DisplacedThresholdLengthInFeetFrom { get; set; }
		public string ElevationAtTouchdownZoneFeetMsl { get; set; }
		public string VisualGlideSlopeIndicators { get; set; }
		public string RunwayVisualRangeEquipmentRvr { get; set; }
		public string RunwayVisibilityValueEquipmentRvv { get; set; }
		public string ApproachLightSystem { get; set; }
		public string RunwayEndIdentifierLightsReilAvailability { get; set; }
		public string RunwayCenterlineLightsAvailability { get; set; }
		public string RunwayEndTouchdownLightsAvailability { get; set; }
		public string ControllingObjectDescription { get; set; }
		public string ControllingObjectMarkedlighted { get; set; }
		public string FaaCfrPart77ObjectsAffectingNavigableAirspace { get; set; }
		public string ControllingObjectClearanceSlope { get; set; }
		public string ControllingObjectHeightAboveRunway { get; set; }
		public string ControllingObjectDistanceFromRunwayEnd { get; set; }
		public string ControllingObjectCenterlineOffset { get; set; }
		public string ReciprocalEndIdentifier { get; set; }
		public string RunwayEndTrueAlignment1 { get; set; }
		public string InstrumentLandingSystemIlsType1 { get; set; }
		public string RightHandTrafficPatternForLandingAircraft1 { get; set; }
		public string RunwayMarkingsType1 { get; set; }
		public string RunwayMarkingsCondition1 { get; set; }
		public string LatitudeOfPhysicalRunwayEndFormatted1 { get; set; }
		public string LatitudeOfPhysicalRunwayEndSeconds1 { get; set; }
		public string LongitudeOfPhysicalRunwayEndFormatted1 { get; set; }
		public string LongitudeOfPhysicalRunwayEndSeconds1 { get; set; }
		public string ElevationFeetMslAtPhysicalRunwayEnd1 { get; set; }
		public string ThresholdCrossingHeightFeetAgl1 { get; set; }
		public string VisualGlidePathAngleHundredthsOfDegrees1 { get; set; }
		public string LatitudeAtDisplacedThresholdFormatted1 { get; set; }
		public string LatitudeAtDisplacedThresholdSeconds1 { get; set; }
		public string LongitudeAtDisplacedThresholdFormatted1 { get; set; }
		public string LongitudeAtDisplacedThresholdSeconds1 { get; set; }
		public string ElevationAtDisplacedThresholdFeetMsl1 { get; set; }
		public string DisplacedThresholdLengthInFeetFrom1 { get; set; }
		public string ElevationAtTouchdownZoneFeetMsl1 { get; set; }
		public string VisualGlideSlopeIndicators1 { get; set; }
		public string RunwayVisualRangeEquipmentRvr1 { get; set; }
		public string RunwayVisibilityValueEquipmentRvv1 { get; set; }
		public string ApproachLightSystem1 { get; set; }
		public string RunwayEndIdentifierLightsReilAvailability1 { get; set; }
		public string RunwayCenterlineLightsAvailability1 { get; set; }
		public string RunwayEndTouchdownLightsAvailability1 { get; set; }
		public string ControllingObjectDescription1 { get; set; }
		public string ControllingObjectMarkedlighted1 { get; set; }
		public string FaaCfrPart77ObjectsAffectingNavigableAirspace1 { get; set; }
		public string ControllingObjectClearanceSlope1 { get; set; }
		public string ControllingObjectHeightAboveRunway1 { get; set; }
		public string ControllingObjectDistanceFromRunwayEnd1 { get; set; }
		public string ControllingObjectCenterlineOffset1 { get; set; }
		public string RunwayLengthSource { get; set; }
		public DateTime? RunwayLengthSourceDate { get; set; }
		public string RunwayWeightbearingCapacityForS { get; set; }
		public string RunwayWeightbearingCapacityForD { get; set; }
		public string RunwayWeightbearingCapacityForT { get; set; }
		public string RunwayWeightbearingCapacityForT1 { get; set; }
		public string RunwayEndGradient { get; set; }
		public string RunwayEndGradientDirectionUpOrDown { get; set; }
		public string RunwayEndPositionSource { get; set; }
		public DateTime? RunwayEndPositionSourceDate { get; set; }
		public string RunwayEndElevationSource { get; set; }
		public DateTime? RunwayEndElevationSourceDate { get; set; }
		public string DisplacedThesholdPositionSource { get; set; }
		public DateTime? DisplacedThesholdPositionSourceDate { get; set; }
		public string DisplacedThesholdElevationSource { get; set; }
		public DateTime? DisplacedThesholdElevationSourceDate { get; set; }
		public string TouchdownZoneElevationSource { get; set; }
		public DateTime? TouchdownZoneElevationSourceDate { get; set; }
		public string TakeoffRunAvailableToraInFeet { get; set; }
		public string TakeoffDistanceAvailableTodaInFeet { get; set; }
		public string AcltStopDistanceAvailableAsdaInFeet { get; set; }
		public string LandingDistanceAvailableLdaInFeet { get; set; }
		public string AvailableLandingDistanceForLandAndHoldShort { get; set; }
		public string IdOfIntersectingRunwayDefiningHoldShortPoint { get; set; }
		public string DescriptionOfEntityDefiningHoldShortPointIf { get; set; }
		public string LatitudeOfLahsoHoldShortPointFormatted { get; set; }
		public string LatitudeOfLahsoHoldShortPointSeconds { get; set; }
		public string LongitudeOfLahsoHoldShortPointFormatted { get; set; }
		public string LongitudeOfLahsoHoldShortPointSeconds { get; set; }
		public string LahsoHoldShortPointLatlongSource { get; set; }
		public DateTime? HoldShortPointLatlongSourceDate { get; set; }
		public string RunwayEndGradient1 { get; set; }
		public string RunwayEndGradientDirectionUpOrDown1 { get; set; }
		public string RunwayEndPositionSource1 { get; set; }
		public DateTime? RunwayEndPositionSourceDate1 { get; set; }
		public string RunwayEndElevationSource1 { get; set; }
		public DateTime? RunwayEndElevationSourceDate1 { get; set; }
		public string DisplacedThesholdPositionSource1 { get; set; }
		public DateTime? DisplacedThesholdPositionSourceDate1 { get; set; }
		public string DisplacedThesholdElevationSource1 { get; set; }
		public DateTime? DisplacedThesholdElevationSourceDate1 { get; set; }
		public string TouchdownZoneElevationSource1 { get; set; }
		public DateTime? TouchdownZoneElevationSourceDate1 { get; set; }
		public string TakeoffRunAvailableToraInFeet1 { get; set; }
		public string TakeoffDistanceAvailableTodaInFeet1 { get; set; }
		public string AcltStopDistanceAvailableAsdaInFeet1 { get; set; }
		public string LandingDistanceAvailableLdaInFeet1 { get; set; }
		public string AvailableLandingDistanceForLandAndHoldShort1 { get; set; }
		public string IdOfIntersectingRunwayDefiningHoldShortPoint1 { get; set; }
		public string DescriptionOfEntityDefiningHoldShortPointIf1 { get; set; }
		public string LatitudeOfLahsoHoldShortPointFormatted1 { get; set; }
		public string LatitudeOfLahsoHoldShortPointSeconds1 { get; set; }
		public string LongitudeOfLahsoHoldShortPointFormatted1 { get; set; }
		public string LongitudeOfLahsoHoldShortPointSeconds1 { get; set; }
		public string LahsoHoldShortPointLatlongSource1 { get; set; }
		public DateTime? HoldShortPointLatlongSourceDate1 { get; set; }
		public string RunwayRecordFillerBlank { get; set; }
	}

	public class RunwayArrestingSystemData
	{
		public string RecordTypeIndicator { get; set; }
		public string LandingFacilitySiteNumber { get; set; }
		public string LandingFacilityStatePostOfficeCode { get; set; }
		public string RunwayIdentification { get; set; }
		public string RunwayEndIdentifier { get; set; }
		public string TypeOfAircraftArrestingDevice { get; set; }
		public string ArrestingSystemRecordFillerBlank { get; set; }
	}

	public class FacilityRemarkData
	{
		public string RecordTypeIndicator { get; set; }
		public string LandingFacilitySiteNumber { get; set; }
		public string LandingFacilityStatePostOfficeCode { get; set; }
		public string RemarkElementName { get; set; }
		public string RemarkText { get; set; }
	}
}
