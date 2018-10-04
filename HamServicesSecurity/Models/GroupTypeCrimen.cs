using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HamDataTransactions;
using System.Data.SqlClient;
using System.Data;

namespace HamServicesSecurity.Models
{
    public class GroupTypeCrimen
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int DependentId { get; set; }
        public List<TypeCrimen> TypeCrimens { get; set; }

        public static List<GroupTypeCrimen> getGroupTypeCrimen(string search)
        {
            List<GroupTypeCrimen> lgp = new List<GroupTypeCrimen>();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("@Search", search));
            DataTable dt= db.GetStoreProcedure("den.GetOrganization", lp);
            foreach (DataRow dr in dt.Rows)
            {
                GroupTypeCrimen gp= new GroupTypeCrimen();
                gp = gp.ConvertToGroupTypeCrimen(dr);
                TypeCrimen tc = new TypeCrimen();
                gp.TypeCrimens=tc.getTypeCrimeByOrganization(gp.OrganizationId,search);
                lgp.Add(gp);
            }
            return lgp;
        }

        private GroupTypeCrimen ConvertToGroupTypeCrimen(DataRow dr)
        {
            GroupTypeCrimen z = new GroupTypeCrimen();
            if (dr != null)
            {
                z.OrganizationId = Convert.ToInt32(dr["OrganizationId"]);
                z.Name = Convert.ToString(dr["Name"]);
                z.Level = Convert.ToInt32(dr["level"]);
                z.DependentId = Convert.ToInt32(dr["DependentId"]);
            }
            return z;
        }
    }
}