using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Xml;

namespace HamServicesSecurity
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static string ApplicationResources = ConfigurationManager.AppSettings["ApplicationResources"];
        public static string ApplicationMaster = ConfigurationManager.AppSettings["ApplicationMaster"];

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            string xml = string.Format(@"<dir name='{0}'> " +
                                    @"    <dir name='{0}\Images'> " +
                                    @"        <dir name='{0}\Images\erpDeportes' />" +
                                    @"    </dir> " +
                                    @"    <dir name='{0}\Reportes'> " +
                                    @"        <dir name='{0}\Reportes\temp' />" +
                                    @"    </dir> " +
                                    @"    <dir name='{0}\TOCs' /> " +
                                    @"    <dir name='{0}\Logs' /> " +
                                    @"    <dir name='{0}\RutaImagenes' /> " +
                                    @"    <dir name='{0}\HamSecurityModel' /> " +
                                    @"</dir> ", ApplicationResources,ApplicationMaster);
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xml);
            XmlNode node = xd.DocumentElement;
            CreateDirOrFile(node);
        }

        private static void CreateDirOrFile(XmlNode node)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                string path = node.Attributes["name"].Value;
                if ((node.Name == "dir") && (!(Directory.Exists(path))))
                {
                    Directory.CreateDirectory(path);
                }
            }

            if (node.HasChildNodes)
            {
                XmlNode xnodWorking;
                xnodWorking = node.FirstChild;
                while (xnodWorking != null)
                {
                    CreateDirOrFile(xnodWorking);
                    xnodWorking = xnodWorking.NextSibling;
                }
            }
        }
    }
}
