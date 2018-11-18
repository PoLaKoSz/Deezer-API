using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models
{
    public class RootObjectAlbumTracks<T> : DataClass<T>
    {
        public int Total { get; }



        public RootObjectAlbumTracks(List<T> data, int total)
            : base(data)
        {
            Total = total;
        }
    }
}
