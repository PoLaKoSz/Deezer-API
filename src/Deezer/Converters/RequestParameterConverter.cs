using PoLaKoSz.Deezer.Models;
using System;
using System.Web;

namespace PoLaKoSz.Deezer.Converters
{
    public class RequestParameterConverter
    {
        public Uri Convert(Uri baseAddress, RequestParameters parameters)
        {
            return new Uri("");

            /*var uriBuilder = new UriBuilder(baseAddress);
            var param = HttpUtility.ParseQueryString(string.Empty);

            foreach (var parameter in parameters.Parameters)
            {
                param[parameter.Key] = parameter.Value;
            }

            uriBuilder.Query = param.ToString();

            return uriBuilder.Uri;*/
        }
    }
}
