using PoLaKoSz.Deezer.Exceptions;
using PoLaKoSz.Deezer.Models;
using PoLaKoSz.Deezer.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.DataAccessLayer.Web
{
    public class SecureEndPoint : EndPoint
    {
        internal static string AccessToken;
        internal static List<IPermission> UserPermissions;



        public SecureEndPoint(string endPoint, IHttpClient httpClient)
            : base(endPoint, httpClient)
        {
            if (AccessToken == null)
            {
                AccessToken = "";
            }

            UserPermissions = new List<IPermission>();
        }



        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="reqPermissions">List of required permissions to access the given EndPoint</param>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue
        /// such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        /// <exception cref="QuotaException">Too much API call sent in a time frame.</exception>
        /// <exception cref="ItemsLimitExceededException"></exception>
        /// <exception cref="MissingPermissionException">The API token hasn't got permission(s) which required for the operation.</exception>
        /// <exception cref="InvalidTokenException">The API token is invalid.</exception>
        /// <exception cref="InvalidParameterException">The passed parameter(s) contain(s) invalid values.</exception>
        /// <exception cref="MissingParameterException">Passed parameter not contains required parameters.</exception>
        /// <exception cref="InvalidQueryException">The requested query invalid.</exception>
        /// <exception cref="BusyServiceException">Deezer service busy.</exception>
        /// <exception cref="DataNotFoundException">Data not found on the server.</exception>
        /// <exception cref="InvalidCastException">An unknown Exception received from the server.</exception>
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
        /// <exception cref="QuotaException">Too much API call sent in a time frame.</exception>
        /// <exception cref="ItemsLimitExceededException"></exception>
        /// <exception cref="MissingPermissionException">The API token hasn't got permission(s) which required for the operation.</exception>
        /// <exception cref="InvalidTokenException">The API token is invalid.</exception>
        /// <exception cref="InvalidParameterException">The passed parameter(s) contain(s) invalid values.</exception>
        /// <exception cref="MissingParameterException">Passed parameter not contains required parameters.</exception>
        /// <exception cref="InvalidQueryException">The requested query invalid.</exception>
        /// <exception cref="BusyServiceException">Deezer service busy.</exception>
        /// <exception cref="DataNotFoundException">Data not found on the server.</exception>
        /// <exception cref="InvalidCastException">An unknown Exception received from the server.</exception>
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
        /// <exception cref="QuotaException">Too much API call sent in a time frame.</exception>
        /// <exception cref="ItemsLimitExceededException"></exception>
        /// <exception cref="MissingPermissionException">The API token hasn't got permission(s) which required for the operation.</exception>
        /// <exception cref="InvalidTokenException">The API token is invalid.</exception>
        /// <exception cref="InvalidParameterException">The passed parameter(s) contain(s) invalid values.</exception>
        /// <exception cref="MissingParameterException">Passed parameter not contains required parameters.</exception>
        /// <exception cref="InvalidQueryException">The requested query invalid.</exception>
        /// <exception cref="BusyServiceException">Deezer service busy.</exception>
        /// <exception cref="DataNotFoundException">Data not found on the server.</exception>
        /// <exception cref="InvalidCastException">An unknown Exception received from the server.</exception>
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
