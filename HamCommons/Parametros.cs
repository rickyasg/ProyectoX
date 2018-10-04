

namespace HamCommon
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class Parametros
    {
        #region Propiedades
        public int ParametroId { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public string Observacion { get; set; }
        public string ParametroTabla { get; set; }
        public int NivelVisivilidad { get; set; }
        #endregion

        #region Metodos GET
        public static List<Parametros> GetParametros()
        {
            List<Parametros> lp = new List<Parametros>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[ErpParametros]");
            foreach (DataRow dr in dt.Rows)
            {
                Parametros pa = ConvertToParametros(dr);
                lp.Add(pa);
            }
            return lp;
        }

        public static List<Parametros> GetParametros(int parametroId)
        {
            List<Parametros> lp = new List<Parametros>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[ErpParametros] where [ParametroId] = {0}", parametroId));
            foreach (DataRow dr in dt.Rows)
            {
                Parametros pa = ConvertToParametros(dr);
                lp.Add(pa);
            }
            return lp;
        }

        public static List<Parametros> GetTipoTiros()
        {
            List<Parametros> lp = new List<Parametros>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[ErpParametros] where [ParametroId] = 10");
            foreach (DataRow dr in dt.Rows)
            {
                Parametros pa = ConvertToParametros(dr);
                lp.Add(pa);
            }
            return lp;
        }
        #endregion

        #region Private Members
        private static Parametros ConvertToParametros(DataRow dr)
        {
            Parametros pa = new Parametros();
            if (dr != null)
            {
                pa.ParametroId = Convert.ToInt32(dr["ParametroId"]);
                pa.Codigo = Convert.ToInt32(dr["Codigo"]);
                pa.Descripcion = Convert.ToString(dr["Descripcion"]);
                pa.Abreviatura = Convert.ToString(dr["Abreviatura"]);
                pa.Observacion = Convert.ToString(dr["Observacion"]);
                pa.ParametroTabla = Convert.ToString(dr["ParametroTabla"]);
                pa.NivelVisivilidad = Convert.ToInt32(dr["NivelVisivilidad"]);
            }
            return pa;
        }
        #endregion
    }
}
