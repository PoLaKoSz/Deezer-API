using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class AlbumGenre
    {
        public int ID { get; }
        public string Name { get; }
        public Uri PictureURL { get; }
        public string Type { get; }



        public AlbumGenre(
            [JsonProperty("id")] int id,
            [JsonProperty("name")] string name,
            [JsonProperty("picture")] Uri pictureURL,
            [JsonProperty("type")] string objectType)
        {
            ID = id;
            Name = name;
            PictureURL = pictureURL;
            Type = objectType;
        }
    }
}
