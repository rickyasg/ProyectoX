using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HamDataTransactions;
using System.Data.SqlClient;

namespace HamServicesSecurity.Models
{
    public class TypeCrimen
    {
        public int TypeCrimenId { get; set; }
        public string Crimen { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Article { get; set; }
        public int OrganizationId { get; set; }

        public static DataTable GetTypeCrimen()
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("@TypeCrimenId", 1));
            dt = db.GetStoreProcedure("den.GetTypeCrimen", ls);
            return dt;
        }
        public List<TypeCrimen>  getTypeCrimeByOrganization(int organizationId,string search="")
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<TypeCrimen> lc = new List<TypeCrimen>();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("@OrganizationId", organizationId));
            dt = db.GetStoreProcedure("[den].[GetTypeCrimenByOrganization]", lp);
            foreach (DataRow dr in dt.Rows)
            {
                lc.Add(this.ConvertToTypeCrimen(dr));
            }

            return lc;
        }
        private TypeCrimen ConvertToTypeCrimen(DataRow dr)
        {
            TypeCrimen z = new TypeCrimen();
            if (dr != null)
            {
                z.TypeCrimenId = Convert.ToInt32(dr["TypeCrimeId"]);
                z.Crimen = Convert.ToString(dr["Crime"]);
                z.Description = dr["Description"].ToString();
                z.Code = dr["Code"].ToString();
                z.Article = Convert.ToString(dr["Article"]);
                z.OrganizationId = Convert.ToInt32(dr["OrganizationId"]);
            }
            return z;
        }
    }
}