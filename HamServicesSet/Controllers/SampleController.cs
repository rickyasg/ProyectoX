using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HamServicesSet.Controllers
{
    public class SampleController : ApiController
    {
        [HttpGet]
        public string Saludo(string name)
        {
            return string.Format("Hola {0}, como estas?", name);
        }
    }
}
