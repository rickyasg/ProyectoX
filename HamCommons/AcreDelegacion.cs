namespace HamCommon
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class AcreDelegacion
    {
        #region Propiedades
        public int DelegacionId { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int EventoId { get; set; }
        #endregion
        #region Metodos Get
        public static List<AcreDelegacion> getDelegaciones(int eventoId)
        {
            List<AcreDelegacion> ld = new List<AcreDelegacion>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[acre].[vDelegaciones] where EventoId = {0}", eventoId));
            foreach (DataRow dr in dt.Rows)
            {
                AcreDelegacion d = ConvertToDelegacion(dr);
                ld.Add(d);
            }
            return ld;
        }
        #endregion
        #region Private Members
        private static AcreDelegacion ConvertToDelegacion(DataRow dr)
        {
            AcreDelegacion d = new AcreDelegacion();
            if (dr != null)
            {
                d.DelegacionId = Convert.ToInt32(dr["DelegacionId"]);
                d.Nombre = Convert.ToString(dr["Nombre"]);
                d.NombreCorto = Convert.ToString(dr["NombreCorto"]);
                d.EventoId = Convert.ToInt32(dr["EventoId"]);
            }
            return d;
        }
        #endregion
    }
}

