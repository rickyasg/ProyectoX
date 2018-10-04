

namespace HamCommon
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class AcreRol
    {
        #region Propiedades
        public int RolId { get; set; }
        public string RolDescripcion { get; set; }
        public string Codigo { get; set; }
        public int GrupoId { get; set; }
        #endregion
        #region Metodos Get
        public static List<AcreRol> getRoles()
        {
            List<AcreRol> lr = new List<AcreRol>();
            lr.Add(new AcreRol { RolId = 0, RolDescripcion = "Seleccione Rol", Codigo = null, GrupoId = 0 });
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[acre].[Roles]");
            foreach(DataRow dr in dt.Rows)
            {
                AcreRol r = ConvertToRol(dr);
                lr.Add(r);
            }
            return lr;
        }
        public static List<AcreRol> getRolGrupo(int grupoId)
        {
            List<AcreRol> lr = new List<AcreRol>();
            lr.Add(new AcreRol { RolId = 0, RolDescripcion = "Seleccione Rol", Codigo = null, GrupoId = 0 });
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[acre].[Roles] where GrupoId = {0}", grupoId));
            foreach (DataRow dr in dt.Rows)
            {
                AcreRol r = ConvertToRol(dr);
                lr.Add(r);
            }
            return lr;
        }
        #endregion

        #region Private Members
        private static AcreRol ConvertToRol(DataRow dr)
        {
            AcreRol r = new AcreRol();
            if(dr != null)
            {
                r.RolId = Convert.ToInt32(dr["RolId"]);
                r.RolDescripcion = Convert.ToString(dr["Rol"]);
                r.Codigo = Convert.ToString(dr["Codigo"]);
                r.GrupoId = Convert.ToInt32(dr["GrupoId"]);
            }
            return r;
        }
        #endregion
    }
}
