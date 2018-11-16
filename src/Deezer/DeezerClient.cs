using PoLaKoSz.Deezer.Converters;
using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.EndPoints;

namespace PoLaKoSz.Deezer
{
    /// <summary>
    /// This class will be the main entry point to the library.
    /// Currently no need to initialize this.
    /// </summary>
    public class DeezerClient
    {
        private readonly ClientSideLogin _clientSideLogin;
        private readonly IHttpClient _httpClient;



        public DeezerClient(ClientSideLogin clientSideLogin)
            : this(clientSideLogin, new HttpClient()) { }

        public DeezerClient(ClientSideLogin clientSideLogin, IHttpClient httpClient)
        {
            _clientSideLogin = clientSideLogin;
            _httpClient = httpClient;

            // TODO : Write UnitTest, because this line should be here after the EndPoints are initialized
            SecureEndPoint.AccessToken = clientSideLogin.AccessToken;
        }



        public AlbumEndPoint Album(int id)
        {
            return new AlbumEndPoint(id, _httpClient);
        }

        public ArtistEndPoint Artist(int id)
        {
            return new ArtistEndPoint(id, _httpClient);
        }

        /// <summary>
        /// Start the authentication process.
        /// </summary>
        private void Authenticate()
        {
            string url = string.Format("https://connect.deezer.com/oauth/auth.php?app_id={0}&redirect_uri={1}",
                _clientSideLogin.AppID,
                _clientSideLogin.RedirectUri);

            string perms = PermissionConverter.Convert(_clientSideLogin.GrantedPermissions);

            if (0 < perms.Length)
                url += perms;

            // TODO : Somehow the library needs to receive the "code" value sent by Deezer
        }
    }
}
