using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HamDataTransactions;
using System.Data;

namespace HamServicesSecurity.Models
{
    public class Parameters
    {
        public int GroupId { get; set; }
        public int ParameterId { get; set; }
        public string Parameter { get; set; }
        public string Short { get; set; }
        public string Description { get; set; }
        public Boolean Hidden { get; set; }
        
        public  static List<Parameters> GetParameters(int groupId)
        {
            List<Parameters> lp = new List<Parameters>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("erp.GetParameters({0})", groupId));
            foreach (DataRow dr in dt.Rows)
            {
                Parameters pa = ConvertToParametros(dr);
                lp.Add(pa);
            }
            return lp;
        }
        public static Parameters ConvertToParametros(DataRow dr)
        {
            Parameters pa = new Parameters();
            if (dr != null)
            {
                pa.ParameterId = Convert.ToInt32(dr["ParameterId"]);
                pa.GroupId = dr.Table.Columns.Contains("GroupId") ? Convert.ToInt32(dr["GroupId"]) : 0;
                pa.Parameter = dr.Table.Columns.Contains("Parameter") ? Convert.ToString(dr["Parameter"]) : "";
                pa.Short = dr.Table.Columns.Contains("Short") ? Convert.ToString(dr["Short"]) : "";
                pa.Description = dr.Table.Columns.Contains("Description") ? Convert.ToString(dr["Description"]) : "";
                pa.Hidden = dr.Table.Columns.Contains("Hidden") ? Convert.ToBoolean(dr["Hidden"]) : false;
            }
            return pa;
        }
    }
}