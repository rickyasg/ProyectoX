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
    public class ProgPrueba
    {
        #region Propiedades
        public int PruebaId { get; set; }
        public int DeporteId { get; set; }
        public string Prueba { get; set; }
        #endregion

        #region Metodos Get
        public static List<ProgPrueba> GetPruebas(int eventoId,int deporteId, int esIndividual)
        {
            List<ProgPrueba> dep = new List<ProgPrueba>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("prog.[fPruebas] ({0},{1},{2})", eventoId,deporteId,esIndividual));
            foreach (DataRow dr in dt.Rows)
            {
                ProgPrueba dp = ConvertToPrueba(dr);
                dep.Add(dp);
            }
            return dep;
        }

        #region Private menber
        private static ProgPrueba ConvertToPrueba(DataRow dr)
        {
            ProgPrueba dp = new ProgPrueba();
            if (dr != null)
            {
                dp.PruebaId = Convert.ToInt32(dr["PruebaId"]);
                dp.DeporteId = Convert.ToInt32(dr["DeporteId"]);
                dp.Prueba = Convert.ToString(dr["Prueba"]);
            }
            return dp;
        }
        #endregion
        #endregion

    }
    public class ProgRamasPrueba
    {
        #region Propiedades
        public int ParametroRamaId { get; set; }
        public string Nombre { get; set; }
        #endregion

        #region Metodos Get
        public static List<ProgRamasPrueba> GetRamas(int eventoId, int deporteId, int esIndividual,int pruebaId)
        {
            List<ProgRamasPrueba> dep = new List<ProgRamasPrueba>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("prog.[fRamasPruebas] ({0},{1},{2},{3})", eventoId, deporteId, esIndividual,pruebaId));
            foreach (DataRow dr in dt.Rows)
            {
                ProgRamasPrueba dp = ConvertToPrueba(dr);
                dep.Add(dp);
            }
            return dep;
        }

        #region Private menber
        private static ProgRamasPrueba ConvertToPrueba(DataRow dr)
        {
            ProgRamasPrueba dp = new ProgRamasPrueba();
            if (dr != null)
            {
                dp.ParametroRamaId = Convert.ToInt32(dr["ParametroRamaId"]);
                dp.Nombre = Convert.ToString(dr["Nombre"]);
            }
            return dp;
        }
        #endregion
        #endregion

    }
}
