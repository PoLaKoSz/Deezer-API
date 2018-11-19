using PoLaKoSz.Deezer;

namespace PoLaKoSz.Samples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var offlineAccess = new ClientSideLogin("frmOFT1pdkIbo5fOuqM3WEg3WtinUxfI3PA0jopzwDOsdEWmNt");
            var fullAccess    = new ClientSideLogin("frl3JM62gjOKPcKAuQdXBJ3omejtQPxoGsMfgcrUfattZrSvfg");

            var deezer = new DeezerClient(fullAccess);

            //var album    = deezer.Album(302127).Get.Info().GetAwaiter().GetResult();
            //var comments = deezer.Album(302127).Get.Comments().GetAwaiter().GetResult();
            //var fans     = deezer.Album(302127).Get.Fans().GetAwaiter().GetResult();
            //var tracks   = deezer.Album(302127).Get.Tracks().GetAwaiter().GetResult();

            //var canRate = deezer.Album(302127).Set.Rate(3).GetAwaiter().GetResult();

            //var currentUserTracks = deezer.CurrentUser().Get.Tracks().GetAwaiter().GetResult();
            //var anotherUserTracks = deezer.User(1518367622).Get.Tracks().GetAwaiter().GetResult();

            var currentUserAddFavTrack = deezer.CurrentUser().Add.Track(565423972).GetAwaiter().GetResult();
        }
    }
}
