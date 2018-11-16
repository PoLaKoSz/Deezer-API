using NUnit.Framework;
using PoLaKoSz.Deezer.EndPoints;
using System;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.Tests.Integration.EndPoints
{
    class AlbumEndPointTests : BaseEndPoint
    {
        private AlbumEndPoint _endPoint;
        private HttpClientMock _clientMock;



        public AlbumEndPointTests()
            : base("Album")
        { }

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

        [Test]
        public async Task Can_Deserialize_Saved_Fans_Response()
        {
            string json = base.GetData("fans.json");
            _clientMock.ResponseFromServer = json;

            var fans = await _endPoint.Get.Fans();

            Assert.That(fans,            Is.Not.Null,    "fans");
            Assert.That(fans.Data.Count, Is.EqualTo(25), "fans.Data.Count");
            Assert.That(fans.Total,      Is.EqualTo(100), "fans.Total");
            Assert.That(fans.NextPage,   Is.EqualTo(new Uri("https://api.deezer.com/album/302127/fans/?index=25")), "fans.NextPage");

            var oneFan = fans.Data[2];
            Assert.That(oneFan.ID,          Is.EqualTo(1631), "oneFan.ID");
            Assert.That(oneFan.Link,        Is.EqualTo(new Uri("https://www.deezer.com/profile/1631")), "oneFan.Link");
            Assert.That(oneFan.Name,        Is.EqualTo("cmallemanche"), "oneFan.Name");
            Assert.That(oneFan.TrackListURL,Is.EqualTo(new Uri("https://api.deezer.com/user/1631/flow")), "oneFan.TrackListURL");
            Assert.That(oneFan.Type,        Is.EqualTo("user"), "oneFan.Type");

            var fanPicture = oneFan.Picture;

            Assert.That(fanPicture.Default, Is.EqualTo(new Uri("https://api.deezer.com/user/1631/image")), "fanPicture.Default");
            Assert.That(fanPicture.Small,   Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/user/0e7793583e83016958e9811290c57bcd/56x56-000000-80-0-0.jpg")), "fanPicture.Small");
            Assert.That(fanPicture.Medium,  Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/user/0e7793583e83016958e9811290c57bcd/250x250-000000-80-0-0.jpg")), "fanPicture.Medium");
            Assert.That(fanPicture.Big,     Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/user/0e7793583e83016958e9811290c57bcd/500x500-000000-80-0-0.jpg")), "fanPicture.Big");
            Assert.That(fanPicture.XL,      Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/user/0e7793583e83016958e9811290c57bcd/1000x1000-000000-80-0-0.jpg")), "fanPicture.XL");
        }
    }
}
