using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models
{

    class Genres
    {
        public List<AlbumGenre> Data { get; }
    }

    public class Contributor
    {
        public int id { get; }
        public string name { get; }
        public string link { get; }
        public string share { get; }
        public string picture { get; }
        public string picture_small { get; }
        public string picture_medium { get; }
        public string picture_big { get; }
        public string picture_xl { get; }
        public bool radio { get; }
        public string tracklist { get; }
        public string type { get; }
        public string role { get; }
    }

    public class MinimalistArtist
    {
        public string id { get; }
        public string name { get; }
        public string tracklist { get; }
        public string type { get; }
    }

    public class Tracks
    {
        public List<Track> data { get; }
    }

    public class Album
    {
        [JsonProperty("id")]
        public string id { get; }

        [JsonProperty("title")]
        public string title { get; }

        [JsonProperty("upc")]
        public string upc { get; }

        [JsonProperty("link")]
        public string link { get; }

        [JsonProperty("share")]
        public string share { get; }

        [JsonProperty("cover")]
        public string cover { get; }

        [JsonProperty("cover_small")]
        public string cover_small { get; }

        [JsonProperty("cover_medium")]
        public string cover_medium { get; }

        [JsonProperty("____")]
        public string cover_big { get; }
        public string cover_xl { get; }
        public int genre_id { get; }
        private readonly Genres _genres;
        public List<AlbumGenre> Genres => _genres.Data;
        public string label { get; }
        public int nb_tracks { get; }
        public int duration { get; }
        public int fans { get; }
        public int rating { get; }
        public string release_date { get; }
        public string record_type { get; }
        public bool available { get; }
        public string tracklist { get; }
        public bool explicit_lyrics { get; }
        public List<Contributor> contributors { get; }
        public AlbumArtist artist { get; }
        public string type { get; }
        public Tracks tracks { get; }
    }
}
