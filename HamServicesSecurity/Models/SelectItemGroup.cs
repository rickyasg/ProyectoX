using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HamServicesSecurity.Models
{
    public class SelectItemGroup
    {
        public int OrganizationId { get; set; }
        public string label { get; set; }
        public string value { get; set; }
        public List<Item> items { get; set; }
        public static List<SelectItemGroup> getGroupTypeCrimen(string search)
        {
            List<SelectItemGroup> lgp = new List<SelectItemGroup>();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("@Search", search));
            DataTable dt = db.GetStoreProcedure("den.GetOrganization", lp);
            foreach (DataRow dr in dt.Rows)
            {
                SelectItemGroup gp = new SelectItemGroup();
                gp = gp.ConvertToGroupTypeCrimen(dr);
                Item tc = new Item();
                gp.items = tc.getTypeCrimeByOrganization(gp.OrganizationId, search);
                lgp.Add(gp);
            }
            return lgp;
        }

        private SelectItemGroup ConvertToGroupTypeCrimen(DataRow dr)
        {
            SelectItemGroup z = new SelectItemGroup();
            if (dr != null)
            {
                z.OrganizationId = Convert.ToInt32(dr["OrganizationId"]);
                z.label = Convert.ToString(dr["Name"]);
                //z.Level = Convert.ToInt32(dr["level"]);
                //z.DependentId = Convert.ToInt32(dr["DependentId"]);
            }
            return z;
        }
    }
}