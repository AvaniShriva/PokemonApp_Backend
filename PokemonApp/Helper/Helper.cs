using System.Net;

namespace PokemonApp.Helper
{
    public class Helper
    {
        public class ResponseBody
        {
            public string Message { get; set; }
            public bool Status { get; set; }
            public object Data { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }
    }
}
