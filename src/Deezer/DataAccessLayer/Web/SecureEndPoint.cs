using PoLaKoSz.Deezer.Exceptions;
using PoLaKoSz.Deezer.Models;
using PoLaKoSz.Deezer.Models.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.DataAccessLayer.Web
{
    public class SecureEndPoint : EndPoint
    {
        internal static string AccessToken;
        internal static List<IPermission> UserPermissions;



        public SecureEndPoint(string endPoint)
            : base(endPoint)
        {
            AccessToken = "";
            UserPermissions = new List<IPermission>();
        }



        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="reqPermissions">List of required permissions to access the given EndPoint</param>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue
        /// such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        protected async Task<string> GetAsync(RequestParameters parameters, List<IPermission> reqPermissions)
        {
            if (!HasPermission(reqPermissions))
                throw new MissingPermissionException();

            AppendAccessToken(parameters);

            return await base.GetAsync(parameters);
        }

        /// <summary>
        /// Send a POST request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue
        /// such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        protected async Task<string> PostAsync(RequestParameters parameters, List<IPermission> reqPermissions)
        {
            if (!HasPermission(reqPermissions))
                throw new MissingPermissionException();

            AppendAccessToken(parameters);

            return await PostAsync(parameters);
        }

        /// <summary>
        /// Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue
        /// such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        protected async Task<string> DeleteAsync(RequestParameters parameters, List<IPermission> reqPermissions)
        {
            if (!HasPermission(reqPermissions))
                throw new MissingPermissionException();

            AppendAccessToken(parameters);

            return await DeleteAsync(parameters);
        }


        private bool HasPermission(List<IPermission> reqPermissions)
        {
            return !UserPermissions.Except(reqPermissions).Any();
        }

        private void AppendAccessToken(RequestParameters parameters)
        {
            parameters.Add("access_token", AccessToken);
        }
    }
}
