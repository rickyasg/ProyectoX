using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HamDataTransactions;
using System.Data;

namespace HamServicesSecurity.Models
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int DependentId { get; set; }
        public string Address { get; set; }

        public static List<Office> GetOffices(int level, int dependentId)
        {
            List<Office> zn = new List<Office>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("rrhh.getOffices({0},{1})", level, dependentId));
            foreach (DataRow dr in dt.Rows)
            {
                Office z = ConvertToOffice(dr);
                zn.Add(z);
            }
            return zn;
        }
        private static Office ConvertToOffice(DataRow dr)
        {
            Office z = new Office();
            if (dr != null)
            {
                z.OfficeId = Convert.ToInt32(dr["OfficeId"]);
                z.DependentId = Convert.ToInt32(dr["DependentId"]);
                z.Name = dr["Name"].ToString();
                z.Address = dr["Address"].ToString();
                z.Level = Convert.ToInt32(dr["Level"]);
                z.DependentId = Convert.ToInt32(dr["DependentId"]);
            }
            return z;
        }
    }
}