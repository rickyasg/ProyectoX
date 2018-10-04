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
    public class ParametrosSuceso
    {
        #region Propiedades
        public  int ParametroSucesoId { get; set; }
        public  string  Parametro { get; set; }
        public  int DeporteId { get; set; }
        public  string Color { get; set; }
        public  int RegistraPersona { get; set; }
        public  int Orden { get; set; }
        public int Valor { get;  set; }
        public int Tipo { get;  set; }
        public int ValorSuceso { get;  set; }
        #endregion
        #region Metodos Get
        public static List<ParametrosSuceso> getParametrosSuceso(int deporteId, int control, int visor)
        {
            List<ParametrosSuceso> ph = new List<ParametrosSuceso>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("conj.fParametroSuceso ({0},{1},{2})", deporteId, control, visor));
            foreach (DataRow dr in dt.Rows)
            {
                ParametrosSuceso parH = ConvertToParametroSuceso(dr);
                ph.Add(parH);
            }
            return ph;
        }

        public static DataTable getSucesoPartido(int competidorId, int planillaId, int deporteId, int control, int visor, int deportePeriodoId)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("conj.fSucesosPartido ({0},{1},{2},{3},{4},{5}) order by Orden", competidorId, planillaId, deporteId, control, visor, deportePeriodoId));
            return dt;
        }

        public static DataTable GetParametroFinalPeriodo(int deporteId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("DeporteId", deporteId));
            dt = db.GetStoreProcedure("[conj].[pGetFinalPeriodosId]", ls);
            return dt;
        }

        public static DataTable GetVolleyPuntos(int cronogramaId )
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetResultadosVoley]({0})", cronogramaId));
            return dt;
        }

        public static DataTable GetVolleySet(int eventoId, int planillaId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("PlanillaId", planillaId));
            DataTable dt = new DataTable();
            dt = db.GetStoreProcedure("[conj].[pGetResultadosSetVoley]", ls);
            return dt;
        }

        public static DataTable GetPuntosSet(int planillaId, int deportePeriodoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetPuntosSet]({0},{1})", planillaId, deportePeriodoId));
            return dt;
        }
        public static DataTable GetPuntosBaloncesto(int PlanillaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetPuntosBaloncesto]({0})", PlanillaId));
            return dt;
        }
        public static DataTable GetPuntosGenerico(int PlanillaId, int DeportePeriodoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetPuntosPlanilla]({0},{1})", PlanillaId, DeportePeriodoId));
            return dt;
        }
        #endregion
        #region Private Members
        public static ParametrosSuceso ConvertToParametroSuceso(DataRow dr)
        {
            ParametrosSuceso ph = new ParametrosSuceso();
            if (dr != null)
            {
                ph.ParametroSucesoId = Convert.ToInt32(dr["ParametroSucesoId"]);
                ph.Parametro = Convert.ToString(dr["Parametro"]);
                ph.DeporteId = Convert.ToInt32(dr["DeporteId"]);
                ph.Color = Convert.ToString(dr["Color"]);
                ph.RegistraPersona = Convert.ToInt32(dr["RegistraPersona"]);
                ph.Orden = !string.IsNullOrEmpty(dr["Orden"].ToString()) ? Convert.ToInt32(dr["Orden"]) : 0;
                ph.Valor = 0;
                ph.ValorSuceso = Convert.ToInt32(dr["Valor"]);
                ph.Tipo = Convert.ToInt32(dr["Tipo"]);
            }
            return ph;
        }
        #endregion
    }
}
