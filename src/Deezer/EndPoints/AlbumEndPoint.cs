using Newtonsoft.Json;
using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using PoLaKoSz.Deezer.Models.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class AlbumEndPoint
    {
        private readonly string _endPointName;



        public AlbumEndPoint()
        {
            _endPointName = "album";
        }



        /// <summary>
        /// Select which <see cref="Album"/> You want to interact.
        /// Available methods:
        ///     Get(<id>).Info()
        ///     Get(<id>).Comments()
        ///     Get(<id>).Fans()
        /// </summary>
        /// <param name="id">ID of the <see cref="Album"/>.</param>
        public AlbumGetter Get(int id)
        {
            return new AlbumGetter(_endPointName, id);
        }

        /// <summary>
        /// Select which <see cref="Album"/> You want to interact.
        /// Available methods:
        ///     Set(<id>).Rate()
        ///     Set(<id>).Comments()
        /// </summary>
        /// <param name="id">ID of the <see cref="Album"/>.</param>
        public AlbumSetter Set(int id)
        {
            return new AlbumSetter(_endPointName, id);
        }
    }

    public class AlbumGetter : EndPoint
    {
        private readonly RequestParameters _parameters;



        public AlbumGetter(string endPoint, int id)
            : base(endPoint)
        {
            _parameters = new RequestParameters(id);
        }



        public async Task<Album> Info()
        {
            string response = await base.GetAsync(_parameters);

            return JsonConvert.DeserializeObject<Album>(response);
        }

        public async Task<List<Comment>> Comments()
        {
            _parameters.AddSegment("comments");

            string response = await base.GetAsync(_parameters);

            return JsonConvert.DeserializeObject<List<Comment>>(response);
        }

        public async Task<List<User>> Fans()
        {
            _parameters.AddSegment("fans");

            string response = await base.GetAsync(_parameters);

            return JsonConvert.DeserializeObject<List<User>>(response);
        }
    }

    public class AlbumSetter : SecureEndPoint
    {
        private readonly RequestParameters _parameters;
        private readonly List<IPermission> _reqPermissions;



        public AlbumSetter(string endPoint, int id)
            : base(endPoint)
        {
            _parameters = new RequestParameters(id);
            _reqPermissions = new List<IPermission>()
            {
                new BasicPermission()
            };
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
            _parameters.Add("note", rating);

            string response = await base.PostAsync(_parameters, _reqPermissions);

            return bool.Parse(response);
        }

        /// <summary>
        /// Comment on an <see cref="Album"/>.
        /// </summary>
        /// <param name="comment">The content of the comment.</param>
        public async Task<bool> Comment(string comment)
        {
            _parameters.Add("comment", comment);

            string response = await base.PostAsync(_parameters, _reqPermissions);

            return bool.Parse(response);
        }
    }
}
