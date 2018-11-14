using PoLaKoSz.Deezer.Converters;
using PoLaKoSz.Deezer.Exceptions;
using PoLaKoSz.Deezer.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.DataAccessLayer.Web
{
    /// <summary>
    /// Simple web access layer only for the bare minimum.
    /// </summary>
    public abstract class EndPoint
    {
        private static IHttpClient _client;
        private readonly Uri _baseAddress;
        private readonly static RequestParameterConverter _parameterConverter;
        private readonly static ExceptionConverter _exceptionConverter;



        static EndPoint()
        {
            _parameterConverter = new RequestParameterConverter();
            _exceptionConverter = new ExceptionConverter();
        }

        /// <summary>
        /// This ctor only for UnitTesting!
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="httpClient"></param>
        public EndPoint(string endPoint, IHttpClient httpClient)
        {
            _baseAddress = new Uri("https://api.deezer.com/" + endPoint + "/");

            if (_client == null)
            {
                _client = httpClient;
            }
        }



        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
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
        protected async Task<string> GetAsync(RequestParameters parameters)
        {
            Uri uri = new Uri(_baseAddress, parameters.Slug);

            var httpResponse = await _client.GetAsync(uri);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            return _exceptionConverter.ThrowExceptionOrContionue(stringResponse);
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
        protected async Task<string> PostAsync(RequestParameters parameters)
        {
            AddRequestMethod(parameters, "POST");

            return await GetAsync(parameters);
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
        protected async Task<string> DeleteAsync(RequestParameters parameters)
        {
            AddRequestMethod(parameters, "DELETE");

            return await GetAsync(parameters);
        }


        private void AddRequestMethod(RequestParameters parameters, string methodType)
        {
            parameters.Add("request_method", methodType);
        }
    }
}
