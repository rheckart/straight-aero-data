using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Marten;
using Microsoft.Extensions.Configuration;
using YouTubeDataPuller;
using YouTubeTest;
using System.Linq;
using Baseline;

namespace YouTubeDataPuller
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets<UserSecrets>();

            Configuration = builder.Build();
            Configuration.Providers.First().TryGet("UserSecrets:ApiKey", out string apiKey);
            Configuration.Providers.First().TryGet("UserSecrets:ConnectionString", out string connectionString);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Channel, StraightAeroChannel>()
                    .ForMember(dest => dest.ChannelName, opt => opt.MapFrom(src => src.Snippet.Title))
                    .ForMember(dest => dest.WebsiteStatus, opt => opt.MapFrom(src => StraightAeroChannelStatus.NotReady));

                cfg.CreateMap<PlaylistItem, StraightAeroVideo>();
            });

            var mapper = config.CreateMapper();

            var service = new YouTubeService(new BaseClientService.Initializer
            {
                ApplicationName = "Straight Aero-Dev",
                ApiKey = apiKey,
            });

            var store = DocumentStore.For(connectionString);


            var channel = service.Channels.List("snippet,contentDetails,statistics");
            channel.ForUsername = args[0];

            Console.WriteLine("Getting Channel Info");

            var result = await channel.ExecuteAsync();

            if (result != null)
            {
                var straightAeroChannel = mapper.Map<StraightAeroChannel>(result.Items.First());
                Console.WriteLine("Mapped");

                // Get playlist
                var playlistItems = service.PlaylistItems.List("snippet,contentDetails,status");
                playlistItems.PlaylistId = straightAeroChannel.ContentDetails.RelatedPlaylists.Uploads;
                playlistItems.MaxResults = 50;

                var straightAeroVideos = new List<StraightAeroVideo>();

                while (true)
                {
                    var playListItemsData = await playlistItems.ExecuteAsync();

                    playListItemsData.Items.Each(playlistItem =>
                    {
                        var straightAeroVideo = mapper.Map<StraightAeroVideo>(playlistItem);
                        straightAeroVideos.Add(straightAeroVideo);
                    });

                    if (string.IsNullOrEmpty(playListItemsData.NextPageToken)) break;

                    playlistItems.PageToken = playListItemsData.NextPageToken;
                }

                using (var session = store.LightweightSession())
                {
                    session.Store(straightAeroChannel);
                    session.StoreObjects(straightAeroVideos);
                    session.SaveChanges();
                }
            }
            else 
            {
                Console.Write("Channel result was null");
            }
        

        }
    }
}
