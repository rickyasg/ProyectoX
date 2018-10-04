using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FelccServices.Models;
namespace FelccServices.Controllers
{
    public class FelccController : ApiController
    {
        [HttpGet]
        public DataTable getTypeCrimen()
        {
            DataTable dt = TypeCrimen.GetTypeCrimen();
            return dt;
        }
    }
}
