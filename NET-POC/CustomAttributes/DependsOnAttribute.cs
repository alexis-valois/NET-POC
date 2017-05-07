using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_POC.Migrations
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class DependsOnAttribute : Attribute
    {
        public Type DependingType { get; private set; }

        public DependsOnAttribute(Type dependingType)
        {
            if (!(typeof(ISeed).IsAssignableFrom(dependingType)))
                throw new ArgumentException("dependingType should implement ISeed", "dependingType");

            DependingType = dependingType;
        }
    }
}