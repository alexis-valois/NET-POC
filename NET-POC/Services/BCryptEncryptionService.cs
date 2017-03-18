using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_POC.Services
{
    public class BCryptEncryptionService : IEncryptionService
    {
        private int costParam;

        public BCryptEncryptionService(int costParam)
        {
            this.costParam = costParam;
        }

        public BCryptEncryptionService()
        {
            this.costParam = 12;
        }

        public string GenerateHash(string rawValue)
        {
            return BCrypt.Net.BCrypt.HashPassword(rawValue, costParam);
        }

        public bool ValidateHash(string rawValue, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(rawValue, correctHash);
        }
    }
}