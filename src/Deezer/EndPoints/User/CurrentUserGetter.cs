using Newtonsoft.Json;
using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using PoLaKoSz.Deezer.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class CurrentUserGetter : SecureEndPoint
    {
        public CurrentUserGetter(string endPoint, IHttpClient httpClient)
            : base(endPoint, httpClient) { }



        public async Task<RootObjectUserTracks<Track>> Tracks()
        {
            try
            {
                var parameters = new RequestParameters();
                parameters.AddSegment("tracks");

                string response = await base.GetAsync(parameters, new List<IPermission>());

                return JsonConvert.DeserializeObject<RootObjectUserTracks<Track>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured while getting info about the current User's tracks. See the InnerException for more details.", ex);
            }
        }
    }
}
