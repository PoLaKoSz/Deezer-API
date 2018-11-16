using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class Fan : Artist
    {
        public Uri Link { get; }

        // TODO : Undocumented tracklist and type property

        
        
        public Fan(
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
            : base(id, name, url, defaultUrl, smallUrl, mediumUrl, bigUrl, xlUrl, trackListUrl, objectType)
        {
            Link = url;
        }
    }
}
