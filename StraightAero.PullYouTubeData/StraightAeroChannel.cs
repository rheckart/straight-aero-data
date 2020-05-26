using Google.Apis.YouTube.v3.Data;
using Marten.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using YouTubeDataPuller;

namespace YouTubeTest
{
    public class StraightAeroChannel : Channel
    {
        [JsonProperty("channelName"), DuplicateField(PgType = "text")]        
        public string ChannelName { get; set; }

        [JsonProperty("websiteStatus")]
        public StraightAeroChannelStatus WebsiteStatus { get; set; }
    }
}
