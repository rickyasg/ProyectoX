using System;
using System.Collections.Generic;
using HamDataTransactions;
using System.Data;
using System.Data.SqlClient;

namespace HamGeneric
{
    public class Cronograma
    {
        public int CronogramaId { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraProgramada { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int PruebaEventoId { get; set; }
        public int InstalacionId { get; set; }
        public int ParametroFaseId { get; set; }
        public int ParametroTipoId { get; set; }
        public int Estado { get; set; }
        public int EventoId { get; set; }
        public int DeporteId { get; set; }
        public int ParametroRamaId { get; set; }
        public int PruebaId { get; set; }
        public int FaseId { get; set; }
        public int AreaInstalacionId { get; set; }
        public string Descripcion { get; set; }

        public PruebaEvento PruebaEvento { get; set; }
        public Instalacion Instalacion { get; set; }
        public List<CronogramaCompetidor> CronogramaCompetidor { get; set; }
        public Evento Evento { get; set; }

        #region Metodos Get
        public  static List<Cronograma> GetCronogramaConjunto(int deporteId,Nullable<DateTime> fecha, int eventoId)
        {
            List<Cronograma> lcr = new List<Cronograma>();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("DeporteId",deporteId));
            if (fecha != null)
            {
                ps.Add(new SqlParameter("Fecha", fecha.Value.ToShortDateString()));
            }
            ps.Add(new SqlParameter("EventoId", eventoId));
            DataTable dt = db.GetStoreProcedure("conj.pGetCronogramaConjunto",ps);
            foreach (DataRow dr in dt.Rows)
            {
                Cronograma cr = ConvertToCronogramas(dr);
                cr.CronogramaCompetidor = new List<CronogramaCompetidor>();
                CronogramaCompetidor cc = new CronogramaCompetidor();
                cc = HamGeneric.CronogramaCompetidor.GetCronogramaCompetidor(Convert.ToInt32(dr["CompetidorA"]), cr.EventoId);
                cr.CronogramaCompetidor.Add(cc);
                cc = HamGeneric.CronogramaCompetidor.GetCronogramaCompetidor(Convert.ToInt32(dr["CompetidorB"]), cr.EventoId);
                cr.CronogramaCompetidor.Add(cc);
                cr.Instalacion = cr.InstalacionId != 0 ?  Instalacion.GetInstalacion(cr.InstalacionId) : new Instalacion();
                lcr.Add(cr);
            }
            return lcr;
        }
        
        public static DataTable GetPruebaEventoIndv(int eventoId, int pruebaId, int parametroRamaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[indv].[fGetPruebaEventosIndv]({0},{1},{2})", eventoId, pruebaId, parametroRamaId));
            return dt;
        }

        public static DataTable GetProgramacionConjunto(int eventoId, int delegacionId, int deporteId, DateTime? fecha = null)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("DelegacionId", delegacionId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            ls.Add(new SqlParameter("Fecha", fecha));
            dt = db.GetStoreProcedure("[prog].[pGetProgramacionConjunto]", ls);
            DataView view = new DataView(dt);
            view.Sort = "HoraProgramada";
            dt1 = view.ToTable(); ;
            return dt1;
        }
        public static DataTable GetCronogramasFecha(int DeporteId, int eventoId, int PruebaId, int ParametroRamaId, DateTime? fecha = null)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("DeporteId", DeporteId));
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("PruebaId", PruebaId));
            ls.Add(new SqlParameter("ParametroRamaId", ParametroRamaId));
            ls.Add(new SqlParameter("Fecha", fecha));
            dt = db.GetStoreProcedure("[prog].[pGetCronogramasFecha]", ls);
            return dt;
        }

        public static DataTable GetCronogramas( int eventoId, int pruebaId, int deporteId, int instalacionId, int parametroRamaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("PruebaId", pruebaId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            ls.Add(new SqlParameter("InstalacionId", instalacionId));
            ls.Add(new SqlParameter("ParametroRamaId", parametroRamaId));
            //ls.Add(new SqlParameter("Descripcion", descripcion));
            dt = db.GetStoreProcedure("prog.pgetCronogramas", ls);
            return dt;
        }
        public static DataTable  GetFases(int eventoId, int deporteId, int parametroRamaId, int parametroTipoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[prog].[fGetFases]({0},{1},{2},{3})", eventoId, deporteId, parametroRamaId, parametroTipoId));
            return dt;
        }
        public static DataTable GetCronogramaFase(int eventoId, int deporteId,int pruebaId, int parametroRamaId, int parametroTipoId, int parametroFaseId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[prog].[fGetCronogramaFases]({0},{1},{2},{3},{4},{5})", eventoId, deporteId, pruebaId, parametroRamaId, parametroTipoId, parametroFaseId));
            return dt;
        }
      


        #endregion

        #region Post

        public bool SaveCronograma()
        {
 

            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", this.EventoId));
            ls.Add(new SqlParameter("DeporteId", this.DeporteId));
            ls.Add(new SqlParameter("PruebaId", this.PruebaId ));
            ls.Add(new SqlParameter("ParametroRamaId", this.ParametroRamaId));
            ls.Add(new SqlParameter("ParametroFaseId", this.ParametroFaseId));
            ls.Add(new SqlParameter("InstalacionId", this.InstalacionId));
            ls.Add(new SqlParameter("Fecha", this.Fecha));
            ls.Add(new SqlParameter("HoraProgramada", this.HoraProgramada));
           // ls.Add(new SqlParameter("FaseId", this.FaseId));
            ls.Add(new SqlParameter("ParametroTipoId", this.ParametroTipoId));
            ls.Add(new SqlParameter("AreaInstalacionId", this.AreaInstalacionId));
            ls.Add(new SqlParameter("Descripcion", this.Descripcion));

            if (this.CronogramaId == 0)
            {
                db.ExecStoreProcedure("prog.pInsCronograma", ls);
            }
            else
            {
                ls.Add(new SqlParameter("CronogramaId", this.CronogramaId));
                db.ExecStoreProcedure("[prog].[pUpCronograma]", ls);
            }
       
           
            return db.RowAffected >1 ? true: false;
            

        }
        public static bool UpdateCronogramaEstado(int cronogramaId, int estadoId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            ls.Add(new SqlParameter("Estado", estadoId));
            db.ExecStoreProcedure("[prog].[pUpEstadoCronograma]", ls);
            return (db.RowAffected > 0);
        }
        public static bool DeleteCronograma(int cronogramaId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            db.ExecStoreProcedure("[prog].[pDelCronograma]", ls);
            return (db.RowAffected > 0);
        }
        #endregion

        #region Metodo Privados
        private static Cronograma ConvertToCronogramas(DataRow dr)
        {
            Cronograma cr = new Cronograma();
            cr.CronogramaId = Convert.ToInt32(dr["CronogramaId"]);
            cr.Fecha = string.IsNullOrEmpty(dr["Fecha"].ToString()) ? DateTime.Now : Convert.ToDateTime(dr["Fecha"]);
            cr.HoraProgramada = Convert.ToString(dr["HoraProgramada"]);
            cr.PruebaEventoId = Convert.ToInt32(dr["PruebaEventoId"]);
            cr.InstalacionId = Convert.ToInt32(dr["InstalacionId"]);
            cr.ParametroFaseId = Convert.ToInt32(dr["ParametroFaseId"]);
            cr.ParametroTipoId = Convert.ToInt32(dr["ParametroTipoId"]);
            cr.Estado = Convert.ToInt32(dr["Estado"]);
            cr.EventoId = Convert.ToInt32(dr["EventoId"]);
            return cr;
        }
        #endregion
    }
}
