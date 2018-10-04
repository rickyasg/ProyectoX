using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(HamServicesSocket.Startup))]

namespace HamServicesSocket
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {                
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    // EnableJSONP = true
                };                
                map.RunSignalR(hubConfiguration);
            });            
        }
    }
}
