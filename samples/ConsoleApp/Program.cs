using PoLaKoSz.Deezer;
using System.Threading.Tasks;

namespace PoLaKoSz.Samples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var logintype = new ClientSideLogin("frmOFT1pdkIbo5fOuqM3WEg3WtinUxfI3PA0jopzwDOsdEWmNt");
            var deezer = new DeezerClient(logintype);

            var albumModel = deezer.Album.Get(302127).Info().GetAwaiter().GetResult();

            var isSuccess = deezer.Album.Set(302127).Rate(3).GetAwaiter().GetResult();
        }
    }
}
