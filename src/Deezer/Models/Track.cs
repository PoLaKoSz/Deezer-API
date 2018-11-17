using Newtonsoft.Json;

namespace PoLaKoSz.Deezer.Models
{
    public class Track
    {
        public string id { get; }
        public bool readable { get; }
        public string title { get; }
        public string title_short { get; }
        public string title_version { get; }
        public string link { get; }
        public string duration { get; }
        public string rank { get; }
        public bool explicit_lyrics { get; }
        public string preview { get; }
        public AlbumTrackArtist artist { get; }
        public string type { get; }



        public Track(
            [JsonProperty("id")] int id,
            [JsonProperty("readable")] bool isReadable,
            [JsonProperty("title")] string title,
            [JsonProperty("title_short")] string shortTitle,
            [JsonProperty("title_version")] string titleVersion)
        {

        }
    }
}
