using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HamServicesSecurity.Models
{
    public class Item
    {
        public string label  { get; set; }
        public string value { get; set; }

        public List<Item> getTypeCrimeByOrganization(int organizationId, string search = "")
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<Item> lc = new List<Item>();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("@OrganizationId", organizationId));
            dt = db.GetStoreProcedure("[den].[GetTypeCrimenByOrganization]", lp);
            foreach (DataRow dr in dt.Rows)
            {
                lc.Add(this.ConvertToTypeCrimen(dr));
            }

            return lc;
        }
        private Item ConvertToTypeCrimen(DataRow dr)
        {
            Item z = new Item();
            if (dr != null)
            {
                z.value = Convert.ToString(dr["TypeCrimeId"]);
                z.label = Convert.ToString(dr["Crime"]);
            }
            return z;
        }
    }
}