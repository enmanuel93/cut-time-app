using System.Net;

namespace CutTime.Web.Models
{
    public class ResponseViewModel<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
