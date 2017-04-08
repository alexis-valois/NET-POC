using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace NET_POC.Utilities
{
    public interface IHashUtil
    {
        string HashPassword(string password);

        bool ValidatePassword(string password, string correctHash);
    }
}