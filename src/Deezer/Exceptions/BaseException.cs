using System;

namespace PoLaKoSz.Deezer.Exceptions
{
    public class BaseException : Exception
    {
        public new string Message { get; set; }
    }
}
