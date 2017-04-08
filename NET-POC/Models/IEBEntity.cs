using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_POC.Models
{
    public interface IEBEntity
    {
        BaseEBEntity BaseEntity { get; }
        bool IsEmpty { get; }
    }
}
