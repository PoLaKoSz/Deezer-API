using Newtonsoft.Json;

namespace PoLaKoSz.Deezer.Models
{
    public class Error
    {
        public string Type { get; }
        public string Message { get; }
        public int Code { get; }



        public Error(
            [JsonProperty("type")] string type,
            [JsonProperty("message")] string message,
            [JsonProperty("code")] int code)
        {
            Type = type;
            Message = message;
            Code = code;
        }
    }

    public class ErrorRoot
    {
        public Error Error { get; }



        public ErrorRoot([JsonProperty("error")] Error error)
        {
            Error = error;
        }
    }
}
