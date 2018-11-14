using NUnit.Framework;
using PoLaKoSz.Deezer.EndPoints;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.Tests.Integration.EndPoints
{
    class AlbumEndPointTests : BaseEndPoint
    {
        private AlbumEndPoint _endPoint;
        private HttpClientMock _clientMock;



        [OneTimeSetUp]
        public void SetUp()
        {
            _clientMock = new HttpClientMock();

            _endPoint = new AlbumEndPoint(32, _clientMock);
        }



        [Test]
        public async Task Check_AlbumGetter_EndPoint_Url()
        {
            await _endPoint.Get.Info();

            Assert.That(_clientMock.LastCalledURL, Is.Not.Null);
            Assert.That(_clientMock.LastCalledURL.AbsolutePath.StartsWith("/album/32/"));
        }

        [Test]
        public async Task Check_AlbumSetter_EndPoint_Url()
        {
            _clientMock.ResponseFromServer = "false";
            await _endPoint.Set.Rate(0);

            Assert.That(_clientMock.LastCalledURL, Is.Not.Null);
            Assert.That(_clientMock.LastCalledURL.AbsolutePath.StartsWith("/album/32/"));
        }
    }
}
