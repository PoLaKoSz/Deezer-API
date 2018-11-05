using PoLaKoSz.Deezer;

namespace PoLaKoSz.Samples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var logintype = new ClientSideLogin("frmOFT1pdkIbo5fOuqM3WEg3WtinUxfI3PA0jopzwDOsdEWmNt");
            var deezer = new DeezerClient(logintype);


            var albumModel = deezer.Album.Get(302127).Info().ConfigureAwait(false);

            var isSuccess = deezer.Album.Rate(302127, 3).ConfigureAwait(false);
        }
    }
}
