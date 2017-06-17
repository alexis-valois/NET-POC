using NET_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_POC.Migrations
{
    interface ISeed
    {
        void SeedData(NET_POC.Models.DataContexts context);
    }
}
