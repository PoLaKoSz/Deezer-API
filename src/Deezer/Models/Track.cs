using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class Track
    {
        public int Id { get; }
        public bool IsReadable { get; }
        public string Title { get; }
        public Uri URL { get; }
        public int Duration { get; }
        public int Rank { get; }
        public bool HasExplicitLyrics { get; }
        public DateTime AddedDate { get; }
        public UserTracksAlbum Album { get; }
        public Artist Artist { get; }
        public string Type { get; }



        public Track(
            [JsonProperty("id")] int id,
            [JsonProperty("readable")] bool isReadable,
            [JsonProperty("title")] string title,
            [JsonProperty("link")] Uri url,
            [JsonProperty("duration")] int duration,
            [JsonProperty("rank")] int rank,
            [JsonProperty("explicit_lyrics")] bool hasExplicitLyrics,
            [JsonProperty("time_add")] long addedDate,
            [JsonProperty("album")] UserTracksAlbum album,
            [JsonProperty("artist")] Artist artist,
            [JsonProperty("type")] string objectType)
        {
            Id = id;
            IsReadable = isReadable;
            Title = title;
            URL = url;
            Duration = duration;
            Rank = rank;
            HasExplicitLyrics = hasExplicitLyrics;
            AddedDate = DateTimeOffset.FromUnixTimeSeconds(addedDate).DateTime;
            Album = album;
            Artist = artist;
            Type = objectType;
        }
    }
}