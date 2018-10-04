using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HamGeneric
{
    public class Parametros
    {
        #region Propiedades
        public int ParametroId { get; set; }
        public int Codigo { get; set; }
        public string ParametroDescripcion { get; set; }
        public string Parametro { get; set; }
        public string Abreviatura { get; set; }
        public string Detalle { get; set; }
        public string Tabla { get; set; }
        public bool Visible { get; set; }
        #endregion

        #region Metodos Get
        public static List<Parametros> GetParametros()
        {
            List<Parametros> lp = new List<Parametros>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("erp.fParametros(0)");
            foreach (DataRow dr in dt.Rows)
            {
                Parametros pa = ConvertToParametros(dr);
                lp.Add(pa);
            }
            return lp;
        }

        public static List<Parametros> GetParametros(int codigo)
        {
            List<Parametros> lp = new List<Parametros>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("erp.fParametros({0})", codigo));
            foreach (DataRow dr in dt.Rows)
            {
                Parametros pa = ConvertToParametros(dr);
                lp.Add(pa);
            }
            return lp;
        }
   
        public static DataTable GetCategoria(int pruebaEventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[prog].[fGetCategoria]({0})", pruebaEventoId));
            return dt;
        }
        #endregion

        #region Private Members
        public static Parametros ConvertToParametros(DataRow dr)
        {
            Parametros pa = new Parametros();
            if (dr != null)
            {
                pa.ParametroId = Convert.ToInt32(dr["ParametroId"]);
                pa.Codigo = dr.Table.Columns.Contains("Codigo") ? Convert.ToInt32(dr["Codigo"]): 0 ;
                pa.ParametroDescripcion = dr.Table.Columns.Contains("Parametro") ? Convert.ToString(dr["Parametro"]):"";
                pa.Abreviatura = dr.Table.Columns.Contains("Abreviatura") ?  Convert.ToString(dr["Abreviatura"]): "";
                pa.Detalle = dr.Table.Columns.Contains("Detalle") ? Convert.ToString(dr["Detalle"]) : "";
                pa.Tabla = dr.Table.Columns.Contains("Tabla") ? Convert.ToString(dr["Tabla"]): "";
                pa.Visible = dr.Table.Columns.Contains("Visible") ? Convert.ToBoolean(dr["Visible"]): true;
            }
            return pa;
        }
        #endregion
    }
}
