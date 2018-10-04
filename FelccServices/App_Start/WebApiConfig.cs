using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FelccServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //// Web API routes
            //string port = ConfigurationManager.AppSettings["App_Ports"];
            //// Web API configuration and services
            //var cors = new EnableCorsAttribute(port, "*", "*");
            //config.EnableCors(cors);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
