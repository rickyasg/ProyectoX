
namespace HamCommon
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class AcreRepresentacion
    {
        #region Propiedades
        public int RepresentacionId { get; set; }
        public int DelegacionId { get; set; }
        public string Representacion { get; set; }
        public string Codigo { get; set; }
        public string Distrito { get; set; }
        public int ParametroTipoEducacionId { get; set; }
        public int ParametroTipoDependenciaId { get; set; }
        #endregion
        #region Metodos Get
        public static List<AcreRepresentacion> getRepresentacion()
        {
            List<AcreRepresentacion> lr = new List<AcreRepresentacion>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[acre].[Representacion]");
            foreach (DataRow dr in dt.Rows)
            {
                AcreRepresentacion r = ConvertToRepresentacion(dr);
                lr.Add(r);
            }
            return lr;
        }
        #endregion
        #region Private Members
        public static AcreRepresentacion ConvertToRepresentacion(DataRow dr)
        {
            AcreRepresentacion r = new AcreRepresentacion();
            if (dr != null)
            {
                r.RepresentacionId = Convert.ToInt32(dr["RepresentacionId"]);
                r.DelegacionId = Convert.ToInt32(dr["DelegacionId"]);
                r.Representacion = Convert.ToString(dr["Representacion"]);
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