using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public string GenerateHash(string rawValue)
        {
            return BCrypt.Net.BCrypt.HashPassword(rawValue, costParam);
        }

        public async Task<string> GenerateHashAsync(string rawValue)
        {
            return await Task.FromResult<string>(GenerateHash(rawValue));
        }

        public bool ValidateHash(string rawValue, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(rawValue, correctHash);
        }

        public async Task<bool> ValidateHashAsync(string rawValue, string correctHash)
        {
            return await Task.FromResult<bool>(ValidateHash(rawValue, correctHash));
        }
    }
}