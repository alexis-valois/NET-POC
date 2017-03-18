using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_POC.Services
{
    public interface IEncryptionService
    {
        string GenerateHash(string rawValue);

        bool ValidateHash(string rawValue, string correctHash);

    }
}
