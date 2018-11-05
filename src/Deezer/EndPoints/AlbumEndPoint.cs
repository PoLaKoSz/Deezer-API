using Newtonsoft.Json;
using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using PoLaKoSz.Deezer.Models.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class AlbumEndPoint : SecureEndPoint
    {
        public AlbumEndPoint()
            : base("album") { }



        /// <summary>
        /// Select which <see cref="Album"/> You want to interact.
        /// Available methods:
        ///     Get(<id>).Info()
        ///     Get(<id>).Comments()
        /// </summary>
        /// <param name="id">ID of the <see cref="Album"/>.</param>
        public AlbumMethods Get(int id)
        {
            return new AlbumMethods("album", id);
        }

        /// <summary>
        /// Rate the album.
        /// </summary>
        /// <param name="id">ID of the <see cref="Album"/>.</param>
        /// <param name="rating">Number between 1 and 5 (inclusive).</param>
        /// <returns><c><TRUE</c> when the operation completed successfully,
        /// <c>FALSE</c> otherwise.</returns>
        public async Task<bool> Rate(int id, int rating)
        {
            List<IPermission> reqPermissions = new List<IPermission>()
            {
                new BasicPermission()
            };

            var parameters = new RequestParameters(id);
            parameters.Add("note", rating);

            string response = await base.PostAsync(parameters, reqPermissions);

            return bool.Parse(response);
        }
    }

    public class AlbumMethods : EndPoint
    {
        private readonly int _id;



        public AlbumMethods(string endPoint, int id)
            : base(endPoint)
        {
            _id = id;
        }



        public async Task<Album> Info()
        {
            string response = await base.GetAsync(new RequestParameters(_id));

            return JsonConvert.DeserializeObject<Album>(response);
        }

        public async Task<List<Comment>> Comments()
        {
            var parameters = new RequestParameters(_id);
            parameters.AddSegment("comments");

            string response = await base.GetAsync(parameters);

            return JsonConvert.DeserializeObject<List<Comment>>(response);
        }
    }
}
