using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HamDataTransactions;
using System.Data;

namespace HamServicesSecurity.Models
{
    public class Zoning
    {
        public int ZoningId { get; set; }
        public int Department { get; set; }
        public int Province { get; set; }
        public int Municipality { get; set; }
        public int Zone { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int DependentId { get; set; }

        public static List<Zoning> GetZoning(int level, int dependentId)
        {
            List<Zoning> zn = new List<Zoning>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("erp.getZoning({0},{1})", level, dependentId));
            foreach (DataRow dr in dt.Rows)
            {
                Zoning z = ConvertToZoning(dr);
                zn.Add(z);
            }
            return zn;
        }

        private static Zoning ConvertToZoning(DataRow dr)
        {
            Zoning z = new Zoning();
            if (dr != null)
            {
                z.ZoningId = Convert.ToInt32(dr["ZoningId"]);
                z.DependentId = Convert.ToInt32(dr["DependentId"]);
                z.Province = Convert.ToInt32(dr["Province"]);
                z.Municipality = Convert.ToInt32(dr["Municipality"]);
                z.Zone = Convert.ToInt32(dr["Zone"]);
                z.Description =  dr["Description"].ToString();
                z.Level = Convert.ToInt32(dr["Level"]);
                z.DependentId = Convert.ToInt32(dr["DependentId"]);
            }
            return z;
        }
    }
}