﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace RacingBattlegrounds.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application Start Event Handler
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
