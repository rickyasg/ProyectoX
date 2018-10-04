using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Configuration;

namespace HamSiteModel
{
    public class PushNotifications
    {
        public string Title { get; set; }
        public string Body { get; set; }

        PushNotifications()
        {
        }

        public static bool SendPush(PushNotifications push)
        {

            var request = WebRequest.Create(ConfigurationManager.AppSettings["ApiOnesignal"]) as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic " + ConfigurationManager.AppSettings["OnesignalKey"]);

            byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                        + "\"app_id\": \"" + ConfigurationManager.AppSettings["AppId"] + "\","
                                        + "\"contents\": {\"en\": \"" + push.Body + "\"},"
                                        + "\"headings\": {\"en\": \"" + push.Title + "\"},"
                                        + "\"included_segments\": [\"All\"]}");

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                return false;
            }

            System.Diagnostics.Debug.WriteLine(responseContent);            

            return true;
        }
    }
}
