using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class AlbumTrackArtist
    {
        public int ID { get; }
        public string Name { get; }
        public Uri TrackListURL { get; }
        public string Type { get; }



        public AlbumTrackArtist(
            [JsonProperty("id")] int id,
            [JsonProperty("name")] string name,
            [JsonProperty("tracklist")] Uri trackListUrl,
            [JsonProperty("type")] string objectType)
        {
            ID = id;
            Name = name;
            TrackListURL = trackListUrl;
            Type = objectType;
        }
    }
}
