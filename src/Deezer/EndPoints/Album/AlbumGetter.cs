using Newtonsoft.Json;
using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class AlbumGetter : EndPoint
    {
        private readonly int _id;



        public AlbumGetter(int id, string endPoint, IHttpClient httpClient)
            : base(endPoint, httpClient)
        {
            _id = id;
        }



        /// <summary>
        /// Get full details about the <see cref="Album"/>.
        /// </summary>
        /// <exception cref="Exception">See the InnerException for more
        /// information about the exception.</exception>
        public async Task<Album> Info()
        {
            try
            {
                RequestParameters parameters = new RequestParameters(_id);

                string response = await base.GetAsync(parameters);

                return JsonConvert.DeserializeObject<Album>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured while getting info about an Album with ID: {_id}. See the InnerException for more details.", ex);
            }
        }

        /// <summary>
        /// Get every posted comment under the <see cref="Album"/>.
        /// </summary>
        /// <exception cref="Exception">See the InnerException for more
        /// information about the exception.</exception>
        public async Task<List<Comment>> Comments()
        {
            try
            {
                RequestParameters parameters = new RequestParameters(_id);
                parameters.AddSegment("comments");

                string response = await base.GetAsync(parameters);

                return JsonConvert.DeserializeObject<List<Comment>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured while getting comments from Album with ID: {_id}. See the InnerException for more details.", ex);
            }
        }

        /// <summary>
        /// Get the list of fans of this <see cref="Album"/>.
        /// </summary>
        /// <exception cref="Exception">See the InnerException for more
        /// information about the exception.</exception>
        public async Task<RootObject<Fan>> Fans()
        {
            try
            {
                RequestParameters parameters = new RequestParameters(_id);
                parameters.AddSegment("fans");

                string response = await base.GetAsync(parameters);

                return JsonConvert.DeserializeObject<RootObject<Fan>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured while getting fans from Album with ID: {_id}. See the InnerException for more details.", ex);
            }
        }
    }
}
