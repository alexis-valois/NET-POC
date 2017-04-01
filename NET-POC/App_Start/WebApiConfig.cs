﻿using Microsoft.Practices.Unity;
using NET_POC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NET_POC.App_Start
{
    public class WebApiConfig
    {
        internal static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}