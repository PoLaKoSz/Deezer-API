using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class UserTracksAlbum
    {
        public int ID { get; }
        public string Title { get; }
        public Picture Cover { get; }
        public Uri TracklistURL { get; }
        public string Type { get; }



        public UserTracksAlbum(
            [JsonProperty("id")] int id,
            [JsonProperty("title")] string title,
            [JsonProperty("cover")] Uri defaultURL,
            [JsonProperty("cover_small")] Uri smallURL,
            [JsonProperty("cover_medium")] Uri mediumURL,
            [JsonProperty("cover_big")] Uri bigURL,
            [JsonProperty("cover_xl")] Uri xlURL,
            [JsonProperty("tracklist")] Uri tracklistURL,
            [JsonProperty("type")] string objectType)
        {
            ID = id;
            Title = title;
            Cover = new Picture(defaultURL, smallURL, mediumURL, bigURL, xlURL);
            TracklistURL = tracklistURL;
            Type = objectType;
        }
    }
}
