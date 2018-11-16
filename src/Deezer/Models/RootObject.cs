using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models
{
    public class RootObject<T>
    {
        public List<T> Data { get; }
        public int Total { get; }
        public Uri NextPage { get; }



        public RootObject(
            [JsonProperty("data")] List<T> data,
            [JsonProperty("total")] int total,
            [JsonProperty("next")] Uri nextPage)
        {
            Data = data;
            Total = total;
            NextPage = nextPage;
        }
    }
}
