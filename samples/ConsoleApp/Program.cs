using System.Threading.Tasks;
using PoLaKoSz.Deezer;
using PoLaKoSz.Deezer.EndPoints;

namespace PoLaKoSz.Samples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var logintype = new ClientSideLogin("frmOFT1pdkIbo5fOuqM3WEg3WtinUxfI3PA0jopzwDOsdEWmNt");

            var deezer = new DeezerClient(logintype);

            Get(deezer.Album, 302127).Wait();
        }

        private async static Task Get(AlbumEndPoint album, int id)
        {
            //var albumModel = await album.Get(id);

            var isSuccess = await album.Rate(id, 3);
        }
    }
}
