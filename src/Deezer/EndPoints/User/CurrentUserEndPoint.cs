using PoLaKoSz.Deezer.DataAccessLayer.Web;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class CurrentUserEndPoint
    {
        public CurrentUserGetter Get { get; }
        public CurrentUserSetter Add { get; }



        public CurrentUserEndPoint(IHttpClient httpClient)
        {
            string endPointName = "user/me/";

            Get = new CurrentUserGetter(endPointName, httpClient);
            Add = new CurrentUserSetter(endPointName, httpClient);
        }
    }
}