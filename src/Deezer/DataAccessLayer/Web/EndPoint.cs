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
        private static readonly HttpClient _client;
        private readonly Uri _baseAddress;



        static EndPoint()
        {
            var handler = new HttpClientHandler();

            _client = new HttpClient(handler, disposeHandler: true);
            _client.DefaultRequestHeaders.Add("Accept", "*/*");
            _client.DefaultRequestHeaders.Add("User-Agent", "https://github.com/PoLaKoSz/Deezer-API");
        }

        public EndPoint(string endPoint)
        {
            _baseAddress = new Uri(new Uri("https://api.deezer.com/"), endPoint);
        }



        /// <summary>
        /// Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue
        /// such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        protected async Task<string> GetAsync(string parameteres)
        {
            var response = await _client.GetAsync(new Uri(_baseAddress, parameteres));

            return await response.Content.ReadAsStringAsync();
        }
    }
}
