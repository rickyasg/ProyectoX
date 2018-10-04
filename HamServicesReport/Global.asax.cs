using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace HamServicesReport
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static string ApplicationResources = ConfigurationManager.AppSettings["ApplicationResources"];

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
