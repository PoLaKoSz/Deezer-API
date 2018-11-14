using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using PoLaKoSz.Deezer.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class AlbumSetter : SecureEndPoint
    {
        private readonly List<IPermission> _reqPermissions;
        private readonly int _id;



        public AlbumSetter(int id, string endPoint, IHttpClient httpClient)
            : base(endPoint, httpClient)
        {
            _reqPermissions = new List<IPermission>()
            {
                new BasicPermission()
            };
            _id = id;
        }



        /// <summary>
        /// Rate the <see cref="Album"/>.
        /// </summary>
        /// <param name="id">ID of the <see cref="Album"/>.</param>
        /// <param name="rating">Number between 1 and 5 (inclusive).</param>
        /// <returns><c><TRUE</c> when the operation completed successfully,
        /// <c>FALSE</c> otherwise.</returns>
        /// <exception cref="Exception">See the InnerException for more
        /// information about the exception.</exception>
        public async Task<bool> Rate(int rating)
        {
            try
            {
                RequestParameters parameters = new RequestParameters(_id);
                parameters.Add("note", rating);

                string response = await base.PostAsync(parameters, _reqPermissions);

                return bool.Parse(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured while rating Album with ID: {_id}. See the InnerException for more details.", ex);
            }
        }
    }
}
