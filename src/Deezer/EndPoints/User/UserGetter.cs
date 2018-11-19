using Newtonsoft.Json;
using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using System;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class UserGetter : EndPoint
    {
        private readonly int _userID;



        public UserGetter(int userID, string endPoint, IHttpClient httpClient)
            : base(endPoint, httpClient)
        {
            _userID = userID;
        }



        public async Task<RootObjectUserTracks<Track>> Tracks()
        {
            try
            {
                var parameters = new RequestParameters();
                parameters.AddSegment("tracks");

                string response = await base.GetAsync(parameters);

                return JsonConvert.DeserializeObject<RootObjectUserTracks<Track>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured while getting info about the User with ID: {_userID} tracks . See the InnerException for more details.", ex);
            }
        }
    }
}