using PoLaKoSz.Deezer.DataAccessLayer.Web;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class UserEndPoint
    {
        public UserGetter Get { get; }



        public UserEndPoint(int id, IHttpClient httpClient)
        {
            Get = new UserGetter(id, "user/" + id, httpClient);
        }
    }
}
