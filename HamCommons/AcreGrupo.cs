

namespace HamCommon
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class AcreGrupo
    {
        #region Propiedades
        public int GrupoId { get; set; }
        public string GrupoDescripcion { get; set; }
        public string Color { get; set; }
        #endregion
        #region Metodos Get
        public static List<AcreGrupo> getGrupos()
        {
            List<AcreGrupo> lg = new List<AcreGrupo>();
            lg.Add(new AcreGrupo() { GrupoId = 0, GrupoDescripcion = "Seleccione Grupo", Color = "" });
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[acre].[Grupos]");
            foreach (DataRow dr in dt.Rows)
            {
                AcreGrupo g = ConvertToGrupo(dr);
                lg.Add(g);
            }
            return lg;
        }
        #endregion
        #region Private Members
        private static AcreGrupo ConvertToGrupo(DataRow dr)
        {
            AcreGrupo g = new AcreGrupo();
            if(dr!= null)
            {
                g.GrupoId = Convert.ToInt32(dr["GrupoId"]);
                g.GrupoDescripcion = Convert.ToString(dr["Grupo"]);
                g.Color = Convert.ToString(dr["Color"]);
            }
            return g;
        }
        #endregion


    }

}
