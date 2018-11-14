using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using PoLaKoSz.Deezer.Models.Permissions;
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
        public async Task<bool> Rate(int rating)
        {
            RequestParameters parameters = new RequestParameters(_id);
            parameters.Add("note", rating);

            string response = await base.PostAsync(parameters, _reqPermissions);

            return bool.Parse(response);
        }

        /// <summary>
        /// Comment on an <see cref="Album"/>.
        /// </summary>
        /// <param name="comment">The content of the comment.</param>
        public async Task<bool> Comment(string comment)
        {
            RequestParameters parameters = new RequestParameters(_id);
            parameters.Add("comment", comment);

            string response = await base.PostAsync(parameters, _reqPermissions);

            return bool.Parse(response);
        }
    }
}
