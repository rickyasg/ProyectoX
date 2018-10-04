using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class Representacion
    {
        #region Propiedades
        public int RepresentacionId { get; set; }
        public int DelegacionId { get; set; }
        public string RepresentacionDescripcion { get; set; }
        public string Codigo { get; set; }
        public string Distrito { get; set; }
        public int ParametroTipoEducacionId { get; set; }
        public int ParametroTipoDependenciaId { get; set; }
        #endregion

        #region Metodos Get
        public static List<Representacion> getRepresentacion()
        {
            List<Representacion> lr = new List<Representacion>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[acre].[Representacion]");
            foreach (DataRow dr in dt.Rows)
            {
                Representacion r = ConvertToRepresentacion(dr);
                lr.Add(r);
            }
            return lr;
        }
        #endregion

        #region Private Members
        public static Representacion ConvertToRepresentacion(DataRow dr)
        {
            Representacion r = new Representacion();
            if (dr != null)
            {
                r.RepresentacionId = Convert.ToInt32(dr["RepresentacionId"]);
                r.DelegacionId = Convert.ToInt32(dr["DelegacionId"]);
                r.RepresentacionDescripcion = Convert.ToString(dr["Representacion"]);
                r.Codigo = Convert.ToString(dr["Codigo"]);
                r.Distrito = Convert.ToString(dr["Distrito"]);
                r.ParametroTipoEducacionId = Convert.ToInt32(dr["ParametroTipoEducacionId"]);
                r.ParametroTipoDependenciaId = Convert.ToInt32(dr["ParametroTipoDependenciaId"]);
            }
            return r;
        }
        #endregion
    }
}
