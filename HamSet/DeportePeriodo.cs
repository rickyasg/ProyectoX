using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamSetModel
{
    public class DeportePeriodo
    {
        #region Propiedades
        public int DeportePeriodoId { get; set; }
        public int DeporteId { get; set; }
        public string Periodo { get; set; }
        public string Abreviatura { get; set; }
        public int EventoId { get; set; }
        public string Tiempo { get; set; }
        public int Punto { get; set; }
        public int Orden { get; set; }
        public int TipoCronometro { get; set; }
        public int TipoPeriodo { get; set; }
        public int intervaloDescanso { get; set; }
        public int MaximoPunto { get;  set; }
        #endregion
        #region Metodos Get
        public static List<DeportePeriodo> getDeportePeriodo(int EventoId, int DeporteId)
        {
            List<DeportePeriodo> dp = new List<DeportePeriodo>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("conj.fDeportePeriodo ({0},{1})", EventoId, DeporteId));
            foreach (DataRow item in dt.Rows)
            {
                DeportePeriodo dper = ConvertToDeportePeriodo(item);
                dp.Add(dper);
            }
            return dp;

        }
        #endregion
        #region Private Members
        private static DeportePeriodo ConvertToDeportePeriodo(DataRow dr)
        {
            DeportePeriodo dper = new DeportePeriodo();
            if (dr != null)
            {
                dper.DeportePeriodoId = Convert.ToInt32(dr["DeportePeriodoId"]);
                dper.DeporteId = Convert.ToInt32(dr["DeporteId"]);
                dper.Periodo = Convert.ToString(dr["Periodo"]);
                dper.Abreviatura = Convert.ToString(dr["Abreviatura"]);
                dper.EventoId = Convert.ToInt32(dr["EventoId"]);
                dper.Tiempo = dr.Table.Columns.Contains("Tiempo") ? Convert.ToString(dr["Tiempo"]) : "";
                dper.Punto = Convert.ToInt32(dr["Punto"]);
                dper.Orden = Convert.ToInt32(dr["Orden"]);
                dper.TipoCronometro = Convert.ToInt32(dr["TipoCronometro"]);
                dper.TipoPeriodo = Convert.ToInt32(dr["TipoPeriodo"]);
                dper.MaximoPunto = Convert.ToInt32(dr["MaximoPunto"] is DBNull ? 0 : dr["MaximoPunto"]);
                dper.intervaloDescanso = Convert.ToInt32(dr["intervaloDescanso"] is DBNull ? 0 : dr["intervaloDescanso"]);
            }
            return dper;
        }
        #endregion


    }
}
