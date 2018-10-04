using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class Grupo
    {
        #region Propiedades
        public int GrupoId { get; set; }
        public string GrupoDescripcion { get; set; }
        public string Color { get; set; }
        public int EventoId { get; set; }
        #endregion

        #region Metodos Get
        public static List<Grupo> getGrupos(int eventoId=1)
        {
            List<Grupo> lg = new List<Grupo>();
            ///lg.Add(new Grupo() { GrupoId = 0, GrupoDescripcion = "Seleccione Grupo", Color = "" });
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("acre.vGrupos where EventoId={0}",eventoId));
            foreach (DataRow dr in dt.Rows)
            {
                Grupo g = ConvertToGrupo(dr);
                lg.Add(g);
            }
            return lg;
        }
        #endregion
        #region Private Members
        private static Grupo ConvertToGrupo(DataRow dr)
        {
            Grupo g = new Grupo();
            if (dr != null)
            {
                g.GrupoId = Convert.ToInt32(dr["GrupoId"]);
                g.GrupoDescripcion = Convert.ToString(dr["Grupo"]);
                g.Color = Convert.ToString(dr["Color"]);
                g.EventoId = Convert.ToInt32(dr["EventoId"]);
            }
            return g;
        }
        #endregion
    }
}
