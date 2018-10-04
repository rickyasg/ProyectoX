using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class Evento
    {
        #region Propiedades

        
        public int EventoId { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Ubicacion { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        #endregion
        #region Metodos Get
        public static DataTable getFechaEvento(int eventoId)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("erp.fGetFechasEvento ({0})", eventoId));
            return dt;
        }
        public static Evento getEvento(int eventoId)
        {
            Evento ev = new Evento();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(String.Format("[erp].[fGetEvento] ({0})", eventoId));
            if (dt.Rows.Count>0)
            {
                ev = ConvertToEvento(dt.Rows[0]);
            }
            return ev;
        }
        #endregion

        #region Members
        public static Evento ConvertToEvento(DataRow dr)
        {
            Evento ev = new Evento();
            if (dr != null)
            {
                ev.EventoId = Convert.ToInt32(dr["EventoId"]);
                ev.Nombre = Convert.ToString(dr["Nombre"]);
                ev.Version = Convert.ToString(dr["Version"]);
                ev.Ubicacion = Convert.ToString(dr["Ubicacion"]);
                ev.Inicio = string.IsNullOrEmpty(dr["Inicio"].ToString()) ? DateTime.Now : Convert.ToDateTime(dr["Inicio"]);
                ev.Fin = string.IsNullOrEmpty(dr["Fin"].ToString()) ? DateTime.Now : Convert.ToDateTime(dr["Fin"]);
            }
            return ev;
        }
        #endregion

    }
}
