using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;

namespace ElasticSearchProduct.API.Dto
{
    public class ProductReponseDTO<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public static ProductReponseDTO<T> Success(T data, HttpStatusCode HttpStatusCode)
        {
            return new ProductReponseDTO<T> { Data = data, HttpStatusCode = HttpStatusCode };
        }

        public static ProductReponseDTO<T> Fail(List<string> errors, HttpStatusCode HttpStatusCode) {  
            return new ProductReponseDTO<T> { Errors = errors, HttpStatusCode = HttpStatusCode};
        }
        public static ProductReponseDTO<T> Fail(string error, HttpStatusCode HttpStatusCode)
        {
            return new ProductReponseDTO<T> { Errors = new List<string> { error }, HttpStatusCode = HttpStatusCode };
        }

    }
}
