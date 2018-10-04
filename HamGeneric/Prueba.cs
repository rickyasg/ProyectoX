using System;
using System.Collections.Generic;
using HamDataTransactions;
using System.Data;

namespace HamGeneric
{
    public class Prueba
    {
        #region Propiedades
 
        public int PruebaId { get; set; }
        public int DeporteId { get; set; }
        public string PruebaDescripcion { get; set; }
       
        #endregion

        #region Metodos Get
        public static List<Prueba> GetPruebas(int eventoId, int deporteId, int esIndividual)
        {
            List<Prueba> dep = new List<Prueba>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("prog.[fPruebas] ({0},{1},{2})", eventoId, deporteId, esIndividual));
            foreach (DataRow dr in dt.Rows)
            {
                Prueba dp = ConvertToPrueba(dr);
                dep.Add(dp);
            }
            return dep;
        }
        #endregion

        #region Private menber
        private static Prueba ConvertToPrueba(DataRow dr)
        {
            Prueba dp = new Prueba();
            if (dr != null)
            {
                dp.PruebaId = Convert.ToInt32(dr["PruebaId"]);
                dp.DeporteId = Convert.ToInt32(dr["DeporteId"]);
                dp.PruebaDescripcion = Convert.ToString(dr["Prueba"]);
            }
            return dp;
        }
        #endregion
    }
    public class RamasPrueba
    {
        #region Propiedades
        public int ParametroRamaId { get; set; }
        public string Nombre { get; set; }
        public int PruebaEventoId { get; set; }
        #endregion

        #region Metodos Get
        public static List<RamasPrueba> GetRamas(int eventoId, int deporteId, int esIndividual, int pruebaId)
        {
            List<RamasPrueba> dep = new List<RamasPrueba>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("prog.[fRamasPruebas] ({0},{1},{2},{3})", eventoId, deporteId, esIndividual, pruebaId));
            foreach (DataRow dr in dt.Rows)
            {
                RamasPrueba dp = ConvertToPrueba(dr);
                dep.Add(dp);
            }
            return dep;
        }
        #endregion
        #region Private menber
        private static RamasPrueba ConvertToPrueba(DataRow dr)
        {
            RamasPrueba dp = new RamasPrueba();
            if (dr != null)
            {
                dp.ParametroRamaId = Convert.ToInt32(dr["ParametroRamaId"]);
                dp.Nombre = Convert.ToString(dr["Nombre"]);
                dp.PruebaEventoId = Convert.ToInt32(dr["PruebaEventoId"]);
            }
            return dp;
        }
        #endregion
    }
}
