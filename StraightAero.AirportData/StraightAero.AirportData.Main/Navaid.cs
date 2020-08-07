using Microsoft.Azure.Cosmos.Spatial;
using System;
using System.Collections.Generic;

namespace StraightAero.AirportData.Main
{
	public class Navaid
	{
		public string id { get; set; }
		public string RecordTypeIndicator { get; set; }
		public string NavaidFacilityIdentifier { get; set; }
		public string NavaidFacilityType { get; set; }
		public string OfficialNavaidFacilityIdentifier { get; set; }
		public DateTime? EffectiveDateThisDateCoincidesWith { get; set; }
		public string NameOfNavaidexWashington { get; set; }
		public string CityAssociatedWithTheNavaid { get; set; }
		public string StateNameWhereAssociatedCityIsLocated { get; set; }
		public string StatePostOfficeCodeWhereAssociated { get; set; }
		public string FaaRegionResponsibleForNavaidCode { get; set; }
		public string CountryNavaidLocatedIfOtherThanUs { get; set; }
		public string CountryPostOfficeCodeNavaid { get; set; }
		public string NavaidOwnerNameExUsNavy { get; set; }
		public string NavaidOperatorNameExUsNavy { get; set; }
		public string CommonSystemUsageYOrN { get; set; }
		public string NavaidPublicUseYOrN { get; set; }
		public string ClassOfNavaid { get; set; }
		public string HoursOfOperationOfNavaid { get; set; }
		public string IdentifierOfArtccWithHighAltitudeBoundaryThatTheNavaid { get; set; }
		public string NameOfArtccWithHighAltitudeBoundaryThatTheNavaid { get; set; }
		public string IdentifierOfArtccWithLowAltitudeBoundaryThatTheNavaid { get; set; }
		public string NameOfArtccWithLowAltitudeBoundaryThatTheNavaid { get; set; }
		public string NavaidLatitudeFormatted { get; set; }
		public string NavaidLatitudeAllSeconds { get; set; }
		public string NavaidLongitudeFormatted { get; set; }
		public string NavaidLongitudeAllSeconds { get; set; }
		public string LatitudelongitudeSurveryAccuracyCode { get; set; }
		public string LatitudeOfTacanPortionOfVortacWhenTacan { get; set; }
		public string LatitudeOfTacanPortionOfVortacWhenTacan1 { get; set; }
		public string LongitudeOfTacanPortionOfVortacWhenTacan { get; set; }
		public string LongitudeOfTacanPortionOfVortacWhenTacan1 { get; set; }
		public string ElevationInTenthOfAFootMsl { get; set; }
		public string MagneticVariationDegrees0099 { get; set; }
		public string MagneticVariationEpochYear0099 { get; set; }
		public string SimultaneousVoiceFeatureYnOrNull { get; set; }
		public int? PowerOutputInWatts { get; set; }
		public string AutomaticVoiceIdentificationFeature { get; set; }
		public string MonitoringCategory { get; set; }
		public string RadioVoiceCallName { get; set; }
		public string ChannelTacanNavaidTransmitsOn { get; set; }
		public decimal? FrequencyTheNavaidTransmitsOn { get; set; }
		public int? TransmittedFanMarkermarineRadioBeacon { get; set; }
		public string FanMarkerTypeBoneOrElliptical { get; set; }
		public string TrueBearingOfMajorAxisOfFanMarker { get; set; }
		public string ProtectedFrequencyAltitude { get; set; }
		public string LowAltitudeFacilityUsedInHighStructure { get; set; }
		public string NavaidZMarkerAvailableYNOrNull { get; set; }
		public string TranscribedWeatherBroadcastHoursTweb { get; set; }
		public string TranscribedWeatherBroadcastPhoneNumber { get; set; }
		public string AssociatedControllingFssIdent { get; set; }
		public string AssociatedControllingFssName { get; set; }
		public string HoursOfOperationOfControllingFss { get; set; }
		public string NotamAccountabilityCodeIdent { get; set; }
		public string QuadrantIdentificationAndRangeLegBearing { get; set; }
		public string NavigationAidStatus { get; set; }
		public string PitchFlagYOrN { get; set; }
		public string CatchFlagYOrN { get; set; }
		public string SuaatcaaFlagYOrN { get; set; }
		public string NavaidRestrictionFlag { get; set; }
		public string HiwasFlag { get; set; }
		public string TranscribedWeatherBroadcastTwebRestriction { get; set; }
		public List<NavaidRemark> Remarks { get; set; }
		public List<HoldingPattern> HoldingPatterns { get; set; }
		public List<FanMarkerAssociatedwithnavaid> FanMarkers { get; set; }
		public List<AirspaceFixAssociatedWithNavaid> AirspaceFixes { get; set; }
		public List<VorReceiverCheckpointAssociatedWithNavaid> VorReceivers { get; set; }
		public Point Location { get; set; }
	}

	public class NavaidRemark
	{
		public string RecordTypeIndicator { get; set; }
		public string NavaidFacilityIdentifier { get; set; }
		public string NavaidFacitityTypeExVordme { get; set; }
		public string NavaidRemarksFreeFormText { get; set; }
		public string Filler { get; set; }
	}

	public class AirspaceFixAssociatedWithNavaid
	{
		public string RecordTypeIndicator { get; set; }
		public string NavaidFacilityIdentifier { get; set; }
		public string NavaidFacitityTypeExVordme { get; set; }
		public string NamesOfFixesFixfileTheIdsOf { get; set; }
		public string SpaceAllocatedFor20MoreFixes { get; set; }
		public string Blanks { get; set; }
	}

	public class HoldingPattern
	{
		public string RecordTypeIndicator { get; set; }
		public string NavaidFacilityIdentifier { get; set; }
		public string NavaidFacitityTypeExVordme { get; set; }
		public string NamesOfHoldingPatterns { get; set; }
		public int PatternNumberOfTheHoldingPattern { get; set; }
		public string SpaceAllocatedFor8MoreHoldingPatterns { get; set; }
		public string Blanks { get; set; }
	}

	public class FanMarkerAssociatedwithnavaid
	{
		public string RecordTypeIndicator { get; set; }
		public string NavaidFacilityIdentifier { get; set; }
		public string NavaidFacitityTypeExVordme { get; set; }
		public string NamesOfFanMarkers { get; set; }
		public string SpaceAllocatedFor23MoreFanMarkers { get; set; }
		public string Blanks { get; set; }
	}

	public class VorReceiverCheckpointAssociatedWithNavaid
	{
		public string RecordTypeIndicator { get; set; }
		public string NavaidFacilityIdentifier { get; set; }
		public string NavaidFacitityTypeExVordme { get; set; }
		public string AirgroundCode { get; set; }
		public int BearingOfCheckpoint { get; set; }
		public int AltitudeOnlyWhenCheckpointIsInAir { get; set; }
		public string AirportId { get; set; }
		public string StateCodeInWhichAssociatedCityIsLocated { get; set; }
		public string NarrativeDescriptionAssociatedWith { get; set; }
		public string NarrativeDescriptionAssociatedWith1 { get; set; }
		public string Blanks { get; set; }
	}
}
