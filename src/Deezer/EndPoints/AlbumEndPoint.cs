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
        /// Get information about a specific <see cref="Album"/>.
        /// </summary>
        /// <param name="id">ID of the <see cref="Album"/>.</param>
        public async Task<Album> Get(int id)
        {
            string response = await base.GetAsync(new RequestParameters(id));

            return JsonConvert.DeserializeObject<Album>(response);
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
}
