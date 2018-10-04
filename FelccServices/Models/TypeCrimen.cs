using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HamDataTransactions;
using System.Data.SqlClient;

namespace FelccServices.Models
{
    public class TypeCrimen
    {
        public int TypeCrimenId { get; set; }
        public string Crimen { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public static DataTable GetTypeCrimen()
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("@TypeCrimenId", 1));
            dt = db.GetStoreProcedure("den.GetTypeCrimen", ls);
            return dt;
        }
    }
}