using System;
using Newtonsoft.Json;

namespace PoLaKoSz.Deezer.Models
{
    public class AlbumArtist : Artist
    {
        public Uri ShareURL { get; }
        public int AlbumCount { get; }
        public int FanCount { get; }
        public bool HasSmartRadio { get; }


        public AlbumArtist(
            [JsonProperty("id")] int id,
            [JsonProperty("name")] string name,
            [JsonProperty("link")] Uri url,
            [JsonProperty("picture")] Uri defaultUrl,
            [JsonProperty("picture_small")] Uri smallUrl,
            [JsonProperty("picture_medium")] Uri mediumUrl,
            [JsonProperty("picture_big")] Uri bigUrl,
            [JsonProperty("picture_xl")] Uri xlUrl,
            [JsonProperty("tracklist")] Uri trackListUrl,
            [JsonProperty("type")] string objectType,
            [JsonProperty("share")] Uri shareURL,
            [JsonProperty("nb_album")] int albumCount,
            [JsonProperty("nb_fan")] int fanCount,
            [JsonProperty("radio")] bool hasRadio)
            : base(id, name, url, defaultUrl, smallUrl, mediumUrl, bigUrl, xlUrl, trackListUrl, objectType)
        {
            ShareURL = shareURL;
            AlbumCount = AlbumCount;
            FanCount = fanCount;
            HasSmartRadio = hasRadio;
        }
    }
}
