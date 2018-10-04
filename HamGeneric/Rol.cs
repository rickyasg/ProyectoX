using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HamGeneric
{
    public class Rol
    {
        #region Propiedades
        public int RolId { get; set; }
        public string RolDescripcion { get; set; }
        public string Codigo { get; set; }
        public int GrupoId { get; set; }
        public bool EsCompetidor { get; set; }
        #endregion

        #region Metodos Get
        public static List<Rol> getRoles()
        {
            List<Rol> lr = new List<Rol>();
          //  lr.Add(new Rol { RolId = 0, RolDescripcion = "Seleccione Rol", Codigo = null, GrupoId = 0 });
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[acre].[vRoles]");
            foreach (DataRow dr in dt.Rows)
            {
                Rol r = ConvertToRol(dr);
                lr.Add(r);
            }
            return lr;
        }
        public static List<Rol> getRolGrupo(int grupoId)
        {
            List<Rol> lr = new List<Rol>();
            //lr.Add(new Rol { RolId = 0, RolDescripcion = "Seleccione Rol", Codigo = null, GrupoId = 0 });
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[acre].[vRoles] where GrupoId = {0}", grupoId));
            foreach (DataRow dr in dt.Rows)
            {
                Rol r = ConvertToRol(dr);
                lr.Add(r);
            }
            return lr;
        }
        #endregion


        #region Private Members
        private static Rol ConvertToRol(DataRow dr)
        {
            Rol r = new Rol();
            if (dr != null)
            {
                r.RolId = Convert.ToInt32(dr["RolId"]);
                r.RolDescripcion = Convert.ToString(dr["Rol"]);
                r.Codigo = Convert.ToString(dr["Codigo"]);
                r.GrupoId = Convert.ToInt32(dr["GrupoId"]);
                r.EsCompetidor = Convert.ToBoolean(dr["EsCompetidor"]);
            }
            return r;
        }
        #endregion
    }
}
