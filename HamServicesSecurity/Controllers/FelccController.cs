using HamServicesSecurity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HamServicesSecurity.Controllers
{
    public class FelccController : ApiController
    {
        [HttpGet]
        public DataTable getTypeCrimen()
        {
            DataTable dt = TypeCrimen.GetTypeCrimen();
            return dt;
        }
        [HttpGet]
        public List<SelectItemGroup> getGroupTypeCrimen(string search = "")
        {
            List<SelectItemGroup> lpg = SelectItemGroup.getGroupTypeCrimen(search);
            return lpg;
        }

        [HttpGet]
        public DataTable getDenuncias()
        {
            DataTable dt = Complaints.getDenuncias();
            return dt;
        }

        [HttpPost]
        public int SaveDemanda([FromBody] Complaints data)
        {
            return data.Save();
        }
        [HttpPost]
        public int UpdaDemanda([FromBody] Complaints data)
        {
            return data.UpHechos();
        }
    }

}
