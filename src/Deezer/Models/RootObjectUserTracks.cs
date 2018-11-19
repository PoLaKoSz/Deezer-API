using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PoLaKoSz.Deezer.Models
{
    public class RootObjectUserTracks<T> : RootObject<T>
    {
        public string CheckSum { get; }



        public RootObjectUserTracks(
            [JsonProperty("data")] List<T> data,
            [JsonProperty("checksum")] string checksum,
            [JsonProperty("total")] int total,
            [JsonProperty("next")] Uri nextPage)
            : base(data, total, nextPage)
        {
            CheckSum = checksum;
        }
    }
}
