using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models
{
    public class DataClass<T>
    {
        public List<T> Data { get; }



        public DataClass(List<T> data)
        {
            Data = data;
        }
    }
}
