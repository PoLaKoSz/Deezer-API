using System;

namespace PoLaKoSz.Deezer.Models
{
    public class Picture
    {
        public Uri Default { get; }
        public Uri Small { get; }
        public Uri Medium { get; }
        public Uri Big { get; }
        public Uri XL { get; }



        public Picture(Uri defaultUrl, Uri smallUrl, Uri mediumUrl, Uri bigUrl,  Uri xlUrl)
        {
            Default = defaultUrl;
            Small = smallUrl;
            Medium = mediumUrl;
            Big = bigUrl;
            XL = xlUrl;
        }
    }
}
