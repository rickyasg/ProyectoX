using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class Delegacion
    {
        #region Propiedades
        public int DelegacionId { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int EventoId { get; set; }
        public bool Tipo { get; set; }
        #endregion

        #region Metodos Get
        public static List<Delegacion> getDelegaciones(int eventoId)
        {
            List<Delegacion> ld = new List<Delegacion>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[acre].[vDelegaciones] where EventoId = {0}", eventoId));
            foreach (DataRow dr in dt.Rows)
            {
                Delegacion d = ConvertToDelegacion(dr);
                ld.Add(d);
            }
            return ld;
        }
        public static DataTable GetGelegacion(int competidorId , int eventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[acre].[fGetDelegacion]({0},{1})", competidorId, eventoId));
            return dt;
        }
        #endregion

        #region Private Members
        private static Delegacion ConvertToDelegacion(DataRow dr)
        {
            Delegacion d = new Delegacion();
            if (dr != null)
            {
                d.DelegacionId = Convert.ToInt32(dr["DelegacionId"]);
                d.Nombre = Convert.ToString(dr["Nombre"]);
                d.NombreCorto = Convert.ToString(dr["NombreCorto"]);
                d.EventoId = Convert.ToInt32(dr["EventoId"]);
                d.Tipo = Convert.ToBoolean(dr["Tipo"]);
            }
            return d;
        }
        #endregion
    }
}
