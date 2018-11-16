using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models
{
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string type { get; set; }
    }

    public class Genres
    {
        public List<Genre> data { get; set; }
    }

    public class Contributor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string share { get; set; }
        public string picture { get; set; }
        public string picture_small { get; set; }
        public string picture_medium { get; set; }
        public string picture_big { get; set; }
        public string picture_xl { get; set; }
        public bool radio { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
        public string role { get; set; }
    }

    public class MinimalistArtist
    {
        public string id { get; set; }
        public string name { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }

    public class Track
    {
        public string id { get; set; }
        public bool readable { get; set; }
        public string title { get; set; }
        public string title_short { get; set; }
        public string title_version { get; set; }
        public string link { get; set; }
        public string duration { get; set; }
        public string rank { get; set; }
        public bool explicit_lyrics { get; set; }
        public string preview { get; set; }
        public MinimalistArtist artist { get; set; }
        public string type { get; set; }
    }

    public class Tracks
    {
        public List<Track> data { get; set; }
    }

    public class Album
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("upc")]
        public string upc { get; set; }

        [JsonProperty("link")]
        public string link { get; set; }

        [JsonProperty("share")]
        public string share { get; set; }

        [JsonProperty("cover")]
        public string cover { get; set; }

        [JsonProperty("cover_small")]
        public string cover_small { get; set; }

        [JsonProperty("cover_medium")]
        public string cover_medium { get; set; }

        [JsonProperty("____")]
        public string cover_big { get; set; }
        public string cover_xl { get; set; }
        public int genre_id { get; set; }
        public Genres genres { get; set; }
        public string label { get; set; }
        public int nb_tracks { get; set; }
        public int duration { get; set; }
        public int fans { get; set; }
        public int rating { get; set; }
        public string release_date { get; set; }
        public string record_type { get; set; }
        public bool available { get; set; }
        public string tracklist { get; set; }
        public bool explicit_lyrics { get; set; }
        public List<Contributor> contributors { get; set; }
        public AlbumArtist artist { get; set; }
        public string type { get; set; }
        public Tracks tracks { get; set; }
    }
}
