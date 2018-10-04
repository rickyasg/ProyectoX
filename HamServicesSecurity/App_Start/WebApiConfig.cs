﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HamServicesSecurity
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            string port = ConfigurationManager.AppSettings["App_Ports"];
            // Web API configuration and services
            var cors = new EnableCorsAttribute(port, "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
