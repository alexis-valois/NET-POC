using NET_POC.Filters;
using NET_POC.Utilities;
using System.Web.Http;
using System.Web.Http.Results;

namespace NET_POC.Controllers.Api.Dev
{
    [RoutePrefix("api")]
    public class CryptoController : ApiController
    {
        private readonly IHashUtil _hasher;

        public CryptoController(IHashUtil hasher)
        {
            _hasher = hasher;
        }

        //[AllowJsonGet]
        [HttpGet]
        [Route("hash/{rawValue}")]
        public JsonResult<string> Hash(string rawValue)
        {
            return Json(_hasher.HashPassword(rawValue));
        }
    }
}