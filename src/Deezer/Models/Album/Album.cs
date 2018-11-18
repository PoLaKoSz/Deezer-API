using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models
{
    public partial class Album
    {
        public int ID { get; }
        public string Title { get; }
        public ulong UPC { get; }
        public Uri URL { get; }
        public Uri ShareURL { get; }
        public Picture Cover { get; }

        [Obsolete("Use the Genres property instead", error: false)]
        public int GenreID { get; }
        public List<AlbumGenre> Genres { get; }

        public string Label { get; }
        public int TrackCount { get; }
        public int Duration { get; }
        public int FansCount { get; }
        public int Rating { get; }
        public DateTime ReleaseDate { get; }
        public string RecordType { get; }
        public bool IsAvailable { get; }
        public Uri TracklistURL { get; }
        public bool HasExplicitLyrics { get; }
        public List<Contributor> Contributors { get; }
        public AlbumArtist Artist { get; }
        public string Type { get; }
        public List<AlbumTrack> Tracks { get; }



        public Album(
            [JsonProperty("id")] int id,
            [JsonProperty("title")] string title,
            [JsonProperty("upc")] ulong upc,
            [JsonProperty("link")] Uri url,
            [JsonProperty("share")] Uri shareURL,
            [JsonProperty("cover")] Uri defaultURL,
            [JsonProperty("cover_small")] Uri smallURL,
            [JsonProperty("cover_medium")] Uri mediumURL,
            [JsonProperty("cover_big")] Uri bigURL,
            [JsonProperty("cover_xl")] Uri xlURL,
            [JsonProperty("genre_id")] int genreID,
            [JsonProperty("genres")] DataClass<AlbumGenre> genres,
            [JsonProperty("label")] string label,
            [JsonProperty("nb_tracks")] int trackCount,
            [JsonProperty("duration")] int duration,
            [JsonProperty("fans")] int fansCount,
            [JsonProperty("rationg")] int rating,
            [JsonProperty("release_date")] DateTime releaseDate,
            [JsonProperty("record_type")] string recordType,
            [JsonProperty("available")] bool isAvailable,
            [JsonProperty("tracklist")] Uri tracklistURL,
            [JsonProperty("explicit_lyrics")] bool hasExplicitLyrics,
            [JsonProperty("contributors")] List<Contributor> contributors,
            [JsonProperty("artist")] AlbumArtist artist,
            [JsonProperty("type")] string objectType,
            [JsonProperty("tracks")] DataClass<AlbumTrack> tracks)
        {
            ID = id;
            Title = title;
            UPC = upc;
            URL = url;
            ShareURL = shareURL;
            Cover = new Picture(defaultURL, smallURL, mediumURL, bigURL, xlURL);
            GenreID = genreID;
            Genres = genres.Data;
            Label = label;
            TrackCount = trackCount;
            Duration = duration;
            FansCount = fansCount;
            Rating = rating;
            ReleaseDate = releaseDate;
            RecordType = recordType;
            IsAvailable = isAvailable;
            TracklistURL = tracklistURL;
            HasExplicitLyrics = hasExplicitLyrics;
            Contributors = contributors;
            Artist = artist;
            Type = objectType;
            Tracks = tracks.Data;
        }
    }
}
