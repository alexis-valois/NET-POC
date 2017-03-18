using NET_POC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;

namespace NET_POC.Controllers.Dev
{
    [RoutePrefix("api/Crypto")]
    public class CryptoApiController : ApiController
    {
        private IEncryptionService encryptionService = new BCryptEncryptionService(12);

        [Route("Hash/{rawValue}")]
        [HttpGet]
        public HttpResponseMessage Hash(string rawValue)
        {
            string hashResponse = encryptionService.GenerateHash(rawValue);          
            return Request.CreateResponse(HttpStatusCode.OK, hashResponse); 
        }

        [Route("Verify/{rawValue}")]
        [HttpGet]
        public HttpResponseMessage Verify(string rawValue, string correctHash)
        {
            var valid = encryptionService.ValidateHash(rawValue, correctHash);
            return Request.CreateResponse(HttpStatusCode.OK, valid);
        }
    }
}