using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamSetModel
{
    public class Planilla
    {
        #region Propiedades
        public int PlanillaId { get; set; }
        public int CronogramaId { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string SistemaEquipoA { get; set; }
        public string SistemaEquipoB { get; set; }
        public int Estado { get; set; }
        #endregion
        #region Metodos DML
        public int Save()
        {
            bool result = false;
            int res = 0;
            if (PlanillaId > 0)
            {
                result = Update();
            }
            else
            {
                result = Insert();
            }
            if (result)
            {
                if(PlanillaId > 0)
                {
                    res = PlanillaId;
                }
                else
                {
                    DBTransaction db = new DBTransaction();
                    res = db.GetIdentity("[conj].[Planillas]");
                }
            }
            return res;
        }
        public static int UpdateHoraInicio(int planillaId, string horaInicio)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PlanillaId", planillaId ));
            ps.Add(new SqlParameter("HoraInicio", horaInicio));
            return Convert.ToInt32(ExecuteTransactionData("[conj].[pSetHoraInicioPlanilla]", ps).Rows[0]["Resultado"]);
        }
        public static int UpdateHoraFin(int planillaId, string horaFin)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PlanillaId", planillaId));
            ps.Add(new SqlParameter("HoraFin", horaFin));
            return Convert.ToInt32(ExecuteTransactionData("[conj].[pSetHoraFinPlanilla]", ps).Rows[0]["Resultado"]);
        }
        #endregion
        #region Metodod Get
        public static List<Planilla> GetPlanilla(int cronogramaId)
        {
            List<Planilla> p = new List<Planilla>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[conj].[fGetPlanilla] ({0})", cronogramaId));
            foreach (DataRow item in dt.Rows)
            {
                Planilla pla = ConvertToPlanilla(item);
                p.Add(pla);
            }
            return p;
        }
        #endregion
        #region Private
        private bool Insert()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = LoadParameters();
            return ExecuteTransaction("[conj].[pInsPlanillas]", ps);
        }
        private bool Update()
        {
            List<SqlParameter> ps = LoadParameters();
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));
            return ExecuteTransaction("[conj].[pUpdPlanillas]", ps);
        }
        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            //DataTable dt = db.GetStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CronogramaId", CronogramaId));
            ps.Add(new SqlParameter("Fecha", Fecha));
            ps.Add(new SqlParameter("HoraInicio", HoraInicio));
            ps.Add(new SqlParameter("HoraFin", HoraFin));
            ps.Add(new SqlParameter("SistemaEquipoA", SistemaEquipoA));
            ps.Add(new SqlParameter("SistemaEquipoB", SistemaEquipoB));
            ps.Add(new SqlParameter("Estado", Estado));
            return ps;
        }
        private static Planilla ConvertToPlanilla(DataRow dr)
        {
            Planilla pla = new Planilla();
            if (dr != null)
            {
                pla.PlanillaId = Convert.ToInt32(dr["PlanillaId"]);
                pla.CronogramaId = Convert.ToInt32(dr["CronogramaId"]);
                pla.Fecha = Convert.ToDateTime(dr["Fecha"]);
                pla.HoraInicio = Convert.ToString(dr["HoraInicio"]);
                pla.HoraFin = Convert.ToString(dr["HoraFin"]);
                pla.SistemaEquipoA = Convert.ToString(dr["SistemaEquipoA"]);
                pla.SistemaEquipoB = Convert.ToString(dr["SistemaEquipoB"]);
                pla.Estado = Convert.ToInt32(dr["Estado"]);
            }
            return pla;
        }
        private static DataTable ExecuteTransactionData(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure(procedureName, ps);

            return dt;
        }
        #endregion
    }
}
