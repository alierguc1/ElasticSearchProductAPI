using ElasticSearchProduct.API.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElasticSearchProduct.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ProductReponseDTO<T> response)
        {
            if(response.HttpStatusCode == HttpStatusCode.NoContent)
                return new ObjectResult(null) { StatusCode = response.HttpStatusCode.GetHashCode()};
            return new ObjectResult(response) { StatusCode = response.HttpStatusCode.GetHashCode()};   
        }
    }
}
