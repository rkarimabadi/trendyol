using System.Net;

namespace trendyol.Shared.Models
{
    public class GenericResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T? Result { get; set; }
    }
}
