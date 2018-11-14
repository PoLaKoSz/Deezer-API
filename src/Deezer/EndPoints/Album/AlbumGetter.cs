using Newtonsoft.Json;
using PoLaKoSz.Deezer.DataAccessLayer.Web;
using PoLaKoSz.Deezer.Models;
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



        public async Task<Album> Info()
        {
            RequestParameters parameters = new RequestParameters(_id);

            string response = await base.GetAsync(parameters);

            return JsonConvert.DeserializeObject<Album>(response);
        }

        public async Task<List<Comment>> Comments()
        {
            RequestParameters parameters = new RequestParameters(_id);
            parameters.AddSegment("comments");

            string response = await base.GetAsync(parameters);

            return JsonConvert.DeserializeObject<List<Comment>>(response);
        }

        public async Task<List<User>> Fans()
        {
            RequestParameters parameters = new RequestParameters(_id);
            parameters.AddSegment("fans");

            string response = await base.GetAsync(parameters);

            return JsonConvert.DeserializeObject<List<User>>(response);
        }
    }
}
