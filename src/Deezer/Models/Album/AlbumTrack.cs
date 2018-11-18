using Newtonsoft.Json;
using System;

namespace PoLaKoSz.Deezer.Models
{
    public class AlbumTrack
    {
        public int ID { get; }
        public bool IsReadable { get; }
        public string Title { get; }
        public string ShortTitle { get; }
        public string TitleVersion { get; }
        public string ISRC { get; }
        public Uri URL { get; }
        public int Duration { get; }
        public int TrackPosition { get; }
        public int DiskNumber { get; }
        public int Rank { get; }
        public bool HasExplicitLyrics { get; }
        public Uri PreviewURL { get; }
        public AlbumTrackArtist Artist { get; }
        public string Type { get; }



        public AlbumTrack(
            [JsonProperty("id")] int id,
            [JsonProperty("readable")] bool isReadable,
            [JsonProperty("title")] string title,
            [JsonProperty("title_short")] string shortTitle,
            [JsonProperty("title_version")] string titleVersion,
            [JsonProperty("isrc")] string isrc,
            [JsonProperty("link")] Uri url,
            [JsonProperty("duration")] int duration,
            [JsonProperty("track_position")] int trackPosition,
            [JsonProperty("disk_number")] int diskNumber,
            [JsonProperty("rank")] int rank,
            [JsonProperty("explicit_lyrics")] bool hasExplicitLyrics,
            [JsonProperty("preview")] Uri previewURL,
            [JsonProperty("artist")] AlbumTrackArtist artist,
            [JsonProperty("type")] string objectType)
        {
            ID = id;
            IsReadable = isReadable;
            Title = title;
            ShortTitle = shortTitle;
            TitleVersion = titleVersion;
            ISRC = isrc;
            URL = url;
            Duration = duration;
            TrackPosition = trackPosition;
            DiskNumber = diskNumber;
            Rank = rank;
            HasExplicitLyrics = hasExplicitLyrics;
            PreviewURL = previewURL;
            Artist = artist;
            Type = objectType;
        }
    }
}
