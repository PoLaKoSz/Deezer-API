using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class Artist
    {
        public int ID { get; }
        public string Name { get; }
        public Picture Picture { get; }
        public Uri TrackListURL { get; }
        public string Type { get; }



        public Artist(
            [JsonProperty("id")] int id,
            [JsonProperty("name")] string name,
            [JsonProperty("link")] Uri url,
            [JsonProperty("picture")] Uri defaultUrl,
            [JsonProperty("picture_small")] Uri smallUrl,
            [JsonProperty("picture_medium")] Uri mediumUrl,
            [JsonProperty("picture_big")] Uri bigUrl,
            [JsonProperty("picture_xl")] Uri xlUrl,
            [JsonProperty("tracklist")] Uri trackListUrl,
            [JsonProperty("type")] string objectType)
        {
            ID = id;
            Name = name;
            Picture = new Picture(defaultUrl, smallUrl, mediumUrl, bigUrl, xlUrl);
            TrackListURL = trackListUrl;
            Type = objectType;
        }
    }
}
