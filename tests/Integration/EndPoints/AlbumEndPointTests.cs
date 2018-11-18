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
        public async Task Can_Deserialize_Saved_Info_Response()
        {
            string json = base.GetData("info.json");
            _clientMock.ResponseFromServer = json;

            var album = await _endPoint.Get.Info();

            Assert.That(album, Is.Not.Null, "album");

            Assert.That(album.ID, Is.EqualTo(302127), "album.ID");
            Assert.That(album.Title, Is.EqualTo("Discovery"), "album.Title");
            Assert.That(album.UPC, Is.EqualTo(724384960650), "album.UPC");
            Assert.That(album.URL, Is.EqualTo(new Uri("https://www.deezer.com/album/302127")), "album.URL");
            Assert.That(album.ShareURL, Is.EqualTo(new Uri("https://www.deezer.com/album/302127?utm_source=deezer&utm_content=album-302127&utm_term=0_1542185532&utm_medium=web")), "album.Share");

            Assert.That(album.Cover.Default, Is.EqualTo(new Uri("https://api.deezer.com/album/302127/image")), "album.Cover.");
            Assert.That(album.Cover.Small, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/cover/2e018122cb56986277102d2041a592c8/56x56-000000-80-0-0.jpg")), "album.Cover.Small");
            Assert.That(album.Cover.Medium, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/cover/2e018122cb56986277102d2041a592c8/250x250-000000-80-0-0.jpg")), "album.Cover.Medium");
            Assert.That(album.Cover.Big, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/cover/2e018122cb56986277102d2041a592c8/500x500-000000-80-0-0.jpg")), "album.Cover.Big");
            Assert.That(album.Cover.XL, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/cover/2e018122cb56986277102d2041a592c8/1000x1000-000000-80-0-0.jpg")), "album.Cover.XL");

            Assert.That(album.GenreID, Is.EqualTo(113), "album.GenreID");

            Assert.That(album.Genres.Count, Is.EqualTo(1), "album.Genres.Count");
            Assert.That(album.Genres[0].ID, Is.EqualTo(113), "album.Genres[0].ID");
            Assert.That(album.Genres[0].Name, Is.EqualTo("Dance"), "album.Genres[0].Name");
            Assert.That(album.Genres[0].PictureURL, Is.EqualTo(new Uri("https://api.deezer.com/genre/113/image")), "album.Genres[0].PictureURL");
            Assert.That(album.Genres[0].Type, Is.EqualTo("genre"), "album.Genres[0].Type");

            Assert.That(album.Label, Is.EqualTo("Parlophone France"), "album.Label");
            Assert.That(album.TrackCount, Is.EqualTo(14), "album.TrackCount");
            Assert.That(album.Duration, Is.EqualTo(3660), "album.Duration");
            Assert.That(album.FansCount, Is.EqualTo(187302), "album.FansCount");
            Assert.That(album.Rating, Is.EqualTo(0), "album.Rating");
            Assert.That(album.ReleaseDate, Is.EqualTo(DateTime.Parse("2001-03-07")), "album.ReleaseDate");
            Assert.That(album.RecordType, Is.EqualTo("album"), "album.RecordType");
            Assert.That(album.IsAvailable, Is.EqualTo(true), "album.IsAvailable");
            Assert.That(album.TracklistURL, Is.EqualTo(new Uri("https://api.deezer.com/album/302127/tracks")), "album.TracklistURL");
            Assert.That(album.HasExplicitLyrics, Is.EqualTo(false), "album.HasExplicitLyrics");


            Assert.That(album.Contributors, Is.Not.Null, "album.Contributors");
            Assert.That(album.Contributors.Count, Is.EqualTo(1), "album.Contributors.Count");
            Assert.That(album.Contributors[0].ID, Is.EqualTo(27), "album.Contributors[0].ID");
            Assert.That(album.Contributors[0].Name, Is.EqualTo("Daft Punk"), "album.Contributors[0].Name");
            Assert.That(album.Contributors[0].URL, Is.EqualTo(new Uri("https://www.deezer.com/artist/27")), "album.Contributors[0].URL");
            Assert.That(album.Contributors[0].ShareURL, Is.EqualTo(new Uri("https://www.deezer.com/artist/27?utm_source=deezer&utm_content=artist-27&utm_term=0_1542185532&utm_medium=web")), "album.Contributors[0].ShareURL");

            Assert.That(album.Contributors[0].Picture.Default, Is.EqualTo(new Uri("https://api.deezer.com/artist/27/image")), "album.Contributors[0].Pciture.Default");
            Assert.That(album.Contributors[0].Picture.Small, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/artist/f2bc007e9133c946ac3c3907ddc5d2ea/56x56-000000-80-0-0.jpg")), "album.Contributors[0].Pciture.Small");
            Assert.That(album.Contributors[0].Picture.Medium, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/artist/f2bc007e9133c946ac3c3907ddc5d2ea/250x250-000000-80-0-0.jpg")), "album.Contributors[0].Pciture.Medium");
            Assert.That(album.Contributors[0].Picture.Big, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/artist/f2bc007e9133c946ac3c3907ddc5d2ea/500x500-000000-80-0-0.jpg")), "album.Contributors[0].Pciture.Big");
            Assert.That(album.Contributors[0].Picture.XL, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/artist/f2bc007e9133c946ac3c3907ddc5d2ea/1000x1000-000000-80-0-0.jpg")), "album.Contributors[0].Pciture.XL");

            Assert.That(album.Contributors[0].HasRadio, Is.EqualTo(true), "album.Contributors[0].HasRadio");
            Assert.That(album.Contributors[0].TracklistURL, Is.EqualTo(new Uri("https://api.deezer.com/artist/27/top?limit=50")), "album.Contributors[0].TracklistURL");
            Assert.That(album.Contributors[0].Type, Is.EqualTo("artist"), "album.Contributors[0].Type");
            Assert.That(album.Contributors[0].Role, Is.EqualTo("Main"), "album.Contributors[0].Role");


            Assert.That(album.Artist, Is.Not.Null, "album.Artist");
            Assert.That(album.Artist.ID, Is.EqualTo(27), "album.Artist.ID");


            Assert.That(album.Type, Is.EqualTo("album"), "album.Type");
        }

        [Test]
        public async Task Can_Deserialize_Saved_Fans_Response()
        {
            string json = base.GetData("fans.json");
            _clientMock.ResponseFromServer = json;

            var fans = await _endPoint.Get.Fans();

            Assert.That(fans, Is.Not.Null, "fans");
            Assert.That(fans.Data.Count, Is.EqualTo(25), "fans.Data.Count");
            Assert.That(fans.Total, Is.EqualTo(100), "fans.Total");
            Assert.That(fans.NextPage, Is.EqualTo(new Uri("https://api.deezer.com/album/302127/fans/?index=25")), "fans.NextPage");

            var oneFan = fans.Data[2];
            Assert.That(oneFan.ID, Is.EqualTo(1631), "oneFan.ID");
            Assert.That(oneFan.Link, Is.EqualTo(new Uri("https://www.deezer.com/profile/1631")), "oneFan.Link");
            Assert.That(oneFan.Name, Is.EqualTo("cmallemanche"), "oneFan.Name");
            Assert.That(oneFan.TrackListURL, Is.EqualTo(new Uri("https://api.deezer.com/user/1631/flow")), "oneFan.TrackListURL");
            Assert.That(oneFan.Type, Is.EqualTo("user"), "oneFan.Type");

            var fanPicture = oneFan.Picture;

            Assert.That(fanPicture.Default, Is.EqualTo(new Uri("https://api.deezer.com/user/1631/image")), "fanPicture.Default");
            Assert.That(fanPicture.Small, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/user/0e7793583e83016958e9811290c57bcd/56x56-000000-80-0-0.jpg")), "fanPicture.Small");
            Assert.That(fanPicture.Medium, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/user/0e7793583e83016958e9811290c57bcd/250x250-000000-80-0-0.jpg")), "fanPicture.Medium");
            Assert.That(fanPicture.Big, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/user/0e7793583e83016958e9811290c57bcd/500x500-000000-80-0-0.jpg")), "fanPicture.Big");
            Assert.That(fanPicture.XL, Is.EqualTo(new Uri("https://e-cdns-images.dzcdn.net/images/user/0e7793583e83016958e9811290c57bcd/1000x1000-000000-80-0-0.jpg")), "fanPicture.XL");
        }
    }
}
