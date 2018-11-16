using PoLaKoSz.Deezer;

namespace PoLaKoSz.Samples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var logintype = new ClientSideLogin("frmOFT1pdkIbo5fOuqM3WEg3WtinUxfI3PA0jopzwDOsdEWmNt");
            var deezer = new DeezerClient(logintype);

            //var albumModel = deezer.Album(302127).Get.Info().GetAwaiter().GetResult();

            var fans = deezer.Album(302127).Get.Fans().GetAwaiter().GetResult();

            var isSuccess = deezer.Album(302127).Set.Rate(3).GetAwaiter().GetResult();
        }
    }
}
