using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class User
    {
        public int ID { get; }
        public string Name { get; }
        public Uri Link { get; }
        public Picture Picture { get; }



        public User(
            [JsonProperty("id")] int id,
            [JsonProperty("name")] string name,
            [JsonProperty("link")] Uri url,
            [JsonProperty("picture")] Uri defaultUrl,
            [JsonProperty("picture_small")] Uri smallUrl,
            [JsonProperty("picture_medium")] Uri mediumUrl,
            [JsonProperty("picture_big")] Uri bigUrl,
            [JsonProperty("picture_xl")] Uri xlUrl)
        {
            ID = id;
            Name = name;
            Link = url;
            Picture = new Picture(defaultUrl, smallUrl, mediumUrl, bigUrl, xlUrl);
        }
    }
}
