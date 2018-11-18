using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class Contributor
    {
        public int ID { get; }
        public string Name { get; }
        public Uri URL { get; }
        public Uri ShareURL { get; }
        public Picture Picture { get; }
        public bool HasRadio { get; }
        public Uri TracklistURL { get; }
        public string Type { get; }
        public string Role { get; }



        public Contributor(
            [JsonProperty("id")] int id,
            [JsonProperty("name")] string name,
            [JsonProperty("link")] Uri url,
            [JsonProperty("share")] Uri shareURL,
            [JsonProperty("picture")] Uri defaultURL,
            [JsonProperty("picture_small")] Uri smallURL,
            [JsonProperty("picture_medium")] Uri mediumURL,
            [JsonProperty("picture_big")] Uri bigURL,
            [JsonProperty("picture_xl")] Uri xlURL,
            [JsonProperty("radio")] bool hasRadio,
            [JsonProperty("tracklist")] Uri tracklistURL,
            [JsonProperty("type")] string objectType,
            [JsonProperty("role")] string role)
        {
            ID = id;
            Name = name;
            URL = url;
            ShareURL = shareURL;
            Picture = new Picture(defaultURL, smallURL, mediumURL, bigURL, xlURL);
            HasRadio = hasRadio;
            TracklistURL = tracklistURL;
            Type = objectType;
            Role = role;
        }
    }
}
