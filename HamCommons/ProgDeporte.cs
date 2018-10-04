using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamDataTransactions;
using System.Data;
using System.Data.SqlClient;

namespace HamCommon
{
   
    public class ProgDeporte
    {
        #region Propiedades
        public int DeporteId { get; set; }
        public string Deporte { get; set; }
        #endregion

        #region Metodos Get
        public static List<ProgDeporte> GetDeportes(int eventoId)
        {
            List<ProgDeporte> dep = new List<ProgDeporte>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("prog.fDeportes ({0})", eventoId));
            foreach ( DataRow dr in dt.Rows)
            {
                ProgDeporte dp = ConvertToDeporte(dr);
                dep.Add(dp);
            }
            return dep;
        }

        #region Private menber
        private static ProgDeporte ConvertToDeporte(DataRow dr)
        {
            ProgDeporte dp = new ProgDeporte();
            if (dr!=null)
            {
                dp.DeporteId = Convert.ToInt32(dr["DeporteId"]);
                dp.Deporte = Convert.ToString(dr["Deporte"]);
            }
            return dp;
        }
        #endregion

        #endregion
    }
    public class PrgDeporteConjunto
    {
        #region Propiedades
        public int EsIndivudual { get; set; }
        public string Detalle { get; set; }
        #endregion
        #region Metodos Get
        public static List<PrgDeporteConjunto> GetEsIndivudual(int eventoId, int deporteId)
        {
            List<PrgDeporteConjunto> dep = new List<PrgDeporteConjunto>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("prog.[fEsIndividual] ({0},{1})", eventoId, deporteId));
            foreach (DataRow dr in dt.Rows)
            {
                PrgDeporteConjunto dp = ConvertToIndividual(dr);
                dep.Add(dp);
            }
            return dep;
        }

        #region Private menber
        private static PrgDeporteConjunto ConvertToIndividual(DataRow dr)
        {
            PrgDeporteConjunto dp = new PrgDeporteConjunto();
            if (dr != null)
            {
                dp.EsIndivudual = Convert.ToInt32(dr["EsIndividual"]);
                dp.Detalle = Convert.ToString(dr["Detalle"]);

            }
            return dp;
        }
        #endregion

        #endregion
    }
}
