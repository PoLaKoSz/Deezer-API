using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
using PoLaKoSz.Deezer.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public class CurrentUserSetter : SecureEndPoint
    {
        public CurrentUserSetter(string endPoint, IHttpClient httpClient)
            : base(endPoint, httpClient) { }



        public async Task<bool> Track(int id)
        {
            try
            {
                RequestParameters parameters = new RequestParameters();
                parameters.AddSegment("tracks");
                parameters.Add("track_id", id);

                var reqPermissions = new List<IPermission>()
                {
                    new ManageLibraryPermission()
                };

                string response = await base.PostAsync(parameters, reqPermissions);

                return bool.Parse(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception occured while adding a Track with ID: {id} to the User. See the InnerException for more details.", ex);
            }
        }
    }
}
