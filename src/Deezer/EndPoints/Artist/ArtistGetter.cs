using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class ArtistGetter : EndPoint
    {
        private readonly int _id;



        public ArtistGetter(int id, string endPoint, IHttpClient httpClient)
            : base(endPoint, httpClient)
        {
            _id = id;
        }
        


        public async Task<AlbumArtist> Info()
        {
            throw new System.Exception();
        }
    }
}
