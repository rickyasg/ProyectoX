using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HamServicesSecurity.Models;

namespace HamServicesSecurity.Controllers
{
    public class GenericController : ApiController
    {
        [HttpGet]
        public List<Parameters> getParameters(int groupId)
        {
            List<Parameters> dt = Parameters.GetParameters(groupId);
            return dt;
        }
        [HttpGet]
        public List<Zoning> getZoning(int level=0, int dependentId=0)
        {
            List<Zoning> lz = Zoning.GetZoning(level, dependentId);
            return lz;
        }
        [HttpGet]
        public List<Office> getOffice(int level = 0, int dependentId = 0)
        {
            List<Office> lo = Office.GetOffices(level, dependentId);
            return lo;
        }

    }
}
