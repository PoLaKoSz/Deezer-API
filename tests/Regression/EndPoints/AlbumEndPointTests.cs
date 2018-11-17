using NUnit.Framework;
using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.EndPoints;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.Tests.Regression.EndPoints
{
    public class AlbumEndPointTests
    {
        private AlbumEndPoint _endPoint;



        [OneTimeSetUp]
        public void ClassInit()
        {
            _endPoint = new AlbumEndPoint(302127, new HttpClient());
        }



        [Test]
        public async Task Call_Get_Info_Should_Not_Return_Exception()
        {
            await _endPoint.Get.Info();
        }

        [Test]
        public async Task Call_Get_Comments_Should_Not_Return_Exception()
        {
            await _endPoint.Get.Comments();
        }

        [Test]
        public async Task Call_Get_Fans_EndPoint_Should_Not_Return_Exception()
        {
            await _endPoint.Get.Fans();
        }

        [Test]
        public async Task Call_Get_Tracks_EndPoint_Should_Not_Return_Exception()
        {
            await _endPoint.Get.Tracks();
        }
    }
}
