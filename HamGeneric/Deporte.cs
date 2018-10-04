using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamDataTransactions;
using System.Data;
using System.Data.SqlClient;

namespace HamGeneric
{
    public class Deporte
    {

        #region Propiedades
        public int DeporteId { get; set; }
        public string DeporteDescripcion { get; set; }
        #endregion

        #region Metodos Get
        public static List<Deporte> GetDeportes(int eventoId)
        {
            List<Deporte> dep = new List<Deporte>();
            //DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("prog.fDeportes ({0})", eventoId));
            DataView view = new DataView(dt);

            view.Sort = "Deporte";
            dt1 = view.ToTable(); ;
            foreach (DataRow dr in dt1.Rows)
            {
                Deporte dp = ConvertToDeporte(dr);
                dep.Add(dp);
            }
            return dep;
        }

        #region Private menber
        private static Deporte ConvertToDeporte(DataRow dr)
        {
            Deporte dp = new Deporte();
            if (dr != null)
            {
                dp.DeporteId = Convert.ToInt32(dr["DeporteId"]);
                dp.DeporteDescripcion = Convert.ToString(dr["Deporte"]);
            }
            return dp;
        }
        #endregion

        #endregion
    }
    public class DeporteConjunto
    {
        #region Propiedades
        public int EsIndivudual { get; set; }
        public string Detalle { get; set; }
        #endregion
        #region Metodos Get

        public static List<DeporteConjunto> GetEsIndivudual(int eventoId, int deporteId)
        {
            List<DeporteConjunto> dep = new List<DeporteConjunto>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("prog.[fEsIndividual] ({0},{1})", eventoId, deporteId));
            foreach (DataRow dr in dt.Rows)
            {
                DeporteConjunto dp = ConvertToIndividual(dr);
                dep.Add(dp);
            }
            return dep;
        }

        #region Private menber
        private static DeporteConjunto ConvertToIndividual(DataRow dr)
        {
            DeporteConjunto dp = new DeporteConjunto();
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
