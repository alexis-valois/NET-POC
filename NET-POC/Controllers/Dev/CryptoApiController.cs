using NET_POC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;

namespace NET_POC.Controllers.Dev
{
    [RoutePrefix("api/Crypto")]
    public class CryptoApiController : ApiController
    {
        private IEncryptionService encryptionService;

        public CryptoApiController(IEncryptionService encryptionService)
        {
            this.encryptionService = encryptionService;
        }

        [Route("Hash/{rawValue}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Hash(string rawValue)
        {
            string hashResponse = await encryptionService.GenerateHashAsync(rawValue);          
            return Request.CreateResponse(HttpStatusCode.OK, hashResponse); 
        }

        [Route("Verify/{rawValue}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Verify(string rawValue, string correctHash)
        {
            var valid = await encryptionService.ValidateHashAsync(rawValue, correctHash);
            return Request.CreateResponse(HttpStatusCode.OK, valid);
        }
    }
}