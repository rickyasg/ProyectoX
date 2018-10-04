using System;
using System.Collections.Generic;
using System.Linq;
using HamDataTransactions;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace HamServicesSecurity.Models
{
    public class Complaints
    {
        public int ComplaintId { get; set; }
        public string FiscalCase { get; set; }
        public int OfficeId { get; set; }
        public int OrganizationId { get; set; }
        public int ZoningId { get; set; }
        public int ParameterTypeViaId { get; set; }
        public string NameStreet { get; set; }
        public string DetailAddrees { get; set; }
        public DateTime DateFact { get; set; }
        public DateTime HourFact { get; set; }
        public String Detail { get; set; }
        public Complainant Denunciante { get; set; }


        public static DataTable getDenuncias()
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("den.Denuncias");
            return dt;
        }

        public int Save()
        {
            if (ComplaintId==0)
            {
                return InsDelito();
            }
            else
            {
                return InsDenunciante();
            }

            

        }
       public int InsDelito()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            DBTransaction db = new DBTransaction();

            ps.Add(new SqlParameter("@FiscalCase", this.FiscalCase));
            ps.Add(new SqlParameter("@OfficeId", this.OfficeId));
            ps.Add(new SqlParameter("@OrganizationId", this.OrganizationId));

            DataTable dt = db.GetStoreProcedure("den.InsComplaints", ps);
            return Convert.ToInt32(dt.Rows[0]["ComplaintId"]);
        }
        public int InsDenunciante()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            DBTransaction db = new DBTransaction();

            ps.Add(new SqlParameter("@ComplaintId", this.ComplaintId));
            ps.Add(new SqlParameter("@Name", this.Denunciante.Name));
            ps.Add(new SqlParameter("@SecondName", this.Denunciante.SecondName));
            ps.Add(new SqlParameter("@LastName", this.Denunciante.LastName));
            ps.Add(new SqlParameter("@SecondLastName", this.Denunciante.SecondLastName));
            ps.Add(new SqlParameter("@NroDocument", this.Denunciante.NroDocument));
            ps.Add(new SqlParameter("@ParameterExtent", this.Denunciante.ParameterExtent));
            ps.Add(new SqlParameter("@ParameterGender", this.Denunciante.ParameterGender));
            ps.Add(new SqlParameter("@BirthDate", this.Denunciante.BirthDate));
            ps.Add(new SqlParameter("@ParameterCivilStatus", this.Denunciante.ParameterCivilStatus));
            ps.Add(new SqlParameter("@ParameterNationality", this.Denunciante.ParameterNationality));
            ps.Add(new SqlParameter("@Address", this.Denunciante.Address));
            ps.Add(new SqlParameter("@Phone", this.Denunciante.Phone));
            ps.Add(new SqlParameter("@Occupation", this.Denunciante.Occupation));
            ps.Add(new SqlParameter("@Workplace", this.Denunciante.Workplace));
            ps.Add(new SqlParameter("@WPhone", this.Denunciante.wPhone));
            ps.Add(new SqlParameter("@WAddress", this.Denunciante.wAddress));

            DataTable dt = db.GetStoreProcedure("den.InsDenunciante", ps);
            return Convert.ToInt32(dt.Rows[0]["ComplainantId"]);
        }
        public  int UpHechos()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            DBTransaction db = new DBTransaction();

            ps.Add(new SqlParameter("@ComplaintId", this.ComplaintId));
            ps.Add(new SqlParameter("@FiscalCase", this.FiscalCase));
            ps.Add(new SqlParameter("@OfficeId", this.OfficeId));
            ps.Add(new SqlParameter("@OrganizationId", this.OrganizationId));
            ps.Add(new SqlParameter("@ZoningId", this.ZoningId));
            ps.Add(new SqlParameter("@ParameterTypeViaId", this.ParameterTypeViaId));
            ps.Add(new SqlParameter("@NameStreet", this.NameStreet));
            ps.Add(new SqlParameter("@DetailAddrees", this.DetailAddrees));
            ps.Add(new SqlParameter("@DateFact", this.DateFact));
            ps.Add(new SqlParameter("@HourFact", this.HourFact));
            ps.Add(new SqlParameter("@Detail", this.Detail));


            DataTable dt = db.GetStoreProcedure("den.UpComplaints", ps);
            return Convert.ToInt32(dt.Rows[0]["ComplaintId"]);
        }
    }
}