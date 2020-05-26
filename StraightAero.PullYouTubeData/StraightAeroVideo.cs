using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeDataPuller
{
    public class StraightAeroVideo : PlaylistItem
    {
        [JsonProperty("departureAirport")]
        public string DepartureAirport { get; set; }

        [JsonProperty("arrivalAirport")]
        public string ArrivalAirport { get; set; }
    }
}
