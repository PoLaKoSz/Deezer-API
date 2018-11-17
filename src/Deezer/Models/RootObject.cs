using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models
{
    public class RootObject<T> : RootObjectAlbumTracks<T>
    {
        public Uri NextPage { get; }



        public RootObject(
            [JsonProperty("data")] List<T> data,
            [JsonProperty("total")] int total,
            [JsonProperty("next")] Uri nextPage)
            : base(data, total)
        {
            NextPage = nextPage;
        }
    }
}
