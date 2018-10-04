

namespace HamCommon
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class EventoDeportivo
    {
        #region Propiedades
        public int EventoDeportivoId { get; set; }
        public string Nombre { get; set; }
        public int Gestion { get; set; }
        public string Ubicacion { get; set; }

        const string Entity = "EventoDeportivo";
        #endregion

        #region DML
        public bool Save()
        {
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadParameters();
            if (EventoDeportivoId == 0)
            {
                procedimiento = "[pInsEventoDeportivo]";
            }
            else
            {
                procedimiento = "[pUpEventoDeportivo]";
                ps.Add(new SqlParameter("EventoDeportivoId", EventoDeportivoId));
            }
            return ExecuteTransaction(procedimiento, ps);
        }

        public bool DeleteEventoDeportivo(int eventoId)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("EventoDeportivoId", eventoId));
            return ExecuteTransaction("pDelEventoDeportivo", ps);
        }

        public static bool InsertDeporteEnEvento(int eventoId, int disciplinaId, int ubicacionId)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("EventoDeportivoId", eventoId));
            ps.Add(new SqlParameter("DisciplinaId", disciplinaId));
            ps.Add(new SqlParameter("UbicacionId", ubicacionId));
            return ExecuteTransaction("pInsEventoDeportivoDisciplinas", ps);
        }

        public static bool DeleteDeporteEnEvento(int eventoId, int disciplinaId)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("EventoDeportivoId", eventoId));
            ps.Add(new SqlParameter("DisciplinaId", disciplinaId));
            return ExecuteTransaction("pDelEventoDeportivoDisciplinas", ps);
        }
        #endregion

        #region Metodos GET
        public static EventoDeportivo GetEventoDeportivo(int eventoDeportivoId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(EventoDeportivoId), eventoDeportivoId);
            DataRow dr = db.GetDataRow(Entity, fields);
            return ConvertToEventoDeportivo(dr);
        }

        public static List<EventoDeportivo> GetEventoDeportivos()
        {
            List<EventoDeportivo> led = new List<EventoDeportivo>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[EventosDeportivo]");
            foreach (DataRow dr in dt.Rows)
            {
                EventoDeportivo ed = ConvertToEventoDeportivo(dr);
                led.Add(ed);
            }
            return led;
        }

        public static List<EventoDeportivo> GetEventosDeportivosByGestion(int gestion)
        {
            List<EventoDeportivo> led = new List<EventoDeportivo>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[EventosDeportivo] WHERE Gestion = {0}", gestion));
            foreach (DataRow dr in dt.Rows)
            {
                EventoDeportivo ed = ConvertToEventoDeportivo(dr);
                led.Add(ed);
            }
            return led;
        }

        public static DataTable GetEventoName(int eventoid)
        {
            //List<EventoDeportivo> led = new List<EventoDeportivo>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[golf].[vGetEventoLugar] WHERE EventoId = {0}", eventoid));
            //dbTools.Sql = string.Format("SELECT [EventoDeportivoId],[Nombre],[Ubicacion] FROM [vGolfGetEventoLugar] WHERE EventoDeportivoId = {0}", eventoid);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    EventoDeportivo ed = ConvertToEventoDeportivo(dr);
            //    led.Add(ed);
            //}
            return dt;
        }

        public static DataTable GetGestionesEventos()
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("SELECT DISTINCT Gestion from EventosDeportivo");
            return dt;
        }

        public static DataTable GetDeportesEvento(int eventoId)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("SELECT EventoDeportivoId, DisciplinaId, Nombre, Color, DependienteId from vGetDeportesEvento WHERE EventoDeportivoId = {0}", eventoId));
            return dt;
        }
        #endregion

        #region Private Members
        private static EventoDeportivo ConvertToEventoDeportivo(DataRow dr)
        {
            EventoDeportivo ed = new EventoDeportivo();
            if (dr != null)
            {
                ed.EventoDeportivoId = Convert.ToInt32(dr["EventoDeportivoId"]);
                ed.Nombre = Convert.ToString(dr["Nombre"]);
                //ed.Gestion = Convert.ToInt32(dr["Gestion"]);
                ed.Ubicacion = Convert.ToString(dr["Ubicacion"]);
            }
            return ed;
        }

        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Nombre", Nombre));
            ps.Add(new SqlParameter("Gestion", Gestion));
            ps.Add(new SqlParameter("Ubicacion", Ubicacion));
            return ps;
        }

        private static bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        #endregion
    }
}
