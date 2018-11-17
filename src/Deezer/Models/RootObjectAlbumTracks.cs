using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models
{
    public class RootObjectAlbumTracks<T>
    {
        public List<T> Data { get; }
        public int Total { get; }



        public RootObjectAlbumTracks(List<T> data, int total)
        {
            Data = data;
            Total = total;
        }
    }
}
