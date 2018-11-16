using PoLaKoSz.Deezer.DataAccessLayer.Web;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class ArtistEndPoint
    {
        public ArtistGetter Get { get; }



        public ArtistEndPoint(int id, IHttpClient httClient)
        {
            Get = new ArtistGetter(id, "artist", httClient);
        }
    }
}
