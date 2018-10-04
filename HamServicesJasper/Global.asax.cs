using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace HamServicesJasper
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static string ApplicationResources = ConfigurationManager.AppSettings["ApplicationResources"];
        public static string ApplicationName = ConfigurationManager.AppSettings["ApplicationName"];
        public static string ApplicationResourcesImages = ConfigurationManager.AppSettings["ApplicationResourcesImages"];
        public static string JasperUser = ConfigurationManager.AppSettings["JasperUser"];
        public static string JasperPassword = ConfigurationManager.AppSettings["JasperPassword"];
        public static string JasperServer = ConfigurationManager.AppSettings["JasperServer"];
        public static string JasperPuerto = ConfigurationManager.AppSettings["JasperPuerto"];
        public static string JasperUrlReport = ConfigurationManager.AppSettings["JasperUrlReport"];

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
