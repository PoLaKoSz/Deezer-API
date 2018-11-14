using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class AlbumEndPoint
    {
        public AlbumGetter Get { get; }

        /// <summary>
        /// Select <see cref="Album"/> You want to interact.
        /// Available methods:
        ///     Set().Rate()
        ///     Set().Comment()
        /// </summary>
        public AlbumSetter Set { get; }



        /// <summary>
        /// Initialize a new <see cref="Album"/> endpoint.
        /// </summary>
        /// <param name="id">ID of the <see cref="Album"/>.</param>
        /// <param name="httpClient"></param>
        public AlbumEndPoint(int id, IHttpClient httpClient)
        {
            string endPointName = "album";

            Get = new AlbumGetter(id, endPointName, httpClient);
            Set = new AlbumSetter(id, endPointName, httpClient);
        }
    }
}
