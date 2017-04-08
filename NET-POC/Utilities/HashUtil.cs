using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace NET_POC.Utilities
{
    public class HashUtil : IHashUtil
    {
        private int workFactor;

        public HashUtil(int workFactor)
        {
            this.workFactor = workFactor;
        }

        private string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(this.workFactor);
        }
    
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }

        public bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}