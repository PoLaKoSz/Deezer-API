using PoLaKoSz.Deezer.Converters;
using PoLaKoSz.Deezer.Models;
using System;
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



        static EndPoint()
        {
            _parameterConverter = new RequestParameterConverter();
        }

        public EndPoint(string endPoint)
            : this(endPoint + "/", _client) { }

        /// <summary>
        /// This ctor only for UnitTesting!
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="httpClient"></param>
        public EndPoint(string endPoint, IHttpClient httpClient)
        {
            _baseAddress = new Uri("https://api.deezer.com/" + endPoint);

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
        protected async Task<string> GetAsync(RequestParameters parameters)
        {
            Uri uri = new Uri(_baseAddress, parameters.Slug);

            var response = await _client.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Send a POST request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue
        /// such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
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
