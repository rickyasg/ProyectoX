using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HamGeneric
{
    public class Privilegio
    {
        #region Propiedades
        public int PrivilegioId { get; set; }
        public string PrivilegioDescripcion { get; set; }
        public string Codigo { get; set; }
        public int ParametroTipoPrivilegioId { get; set; }
        public string ParametroDescripcion { get; set; }
        public int Posicion { get; set; }
        public int Orden { get; set; }
        public int ParametroTipoMostrarId { get; set; }
        public int EventoId { get; set; }
        #endregion
        private const string Entity= "acre.Privilegios";

        #region Metodos Get
        public static List<Privilegio> getPrivilegioRol(int eventoId, int rolId)
        {
            List<Privilegio> lp = new List<Privilegio>();
            DBTransaction db = new DBTransaction();
            DataView dv = db.GetDataView(string.Format("acre.fPrivilegiosRoles ({0},{1})", eventoId, rolId)).DefaultView;
            dv.Sort = "ParametroTipoPrivilegioId, Orden";
            DataTable dt = dv.ToTable();
            string _columna = "";
            foreach (DataRow dr in dt.Rows)
            {
                Privilegio p = ConvertToPrivilegios(dr);
                if (_columna==p.ParametroDescripcion)
                {
                    p.ParametroDescripcion = "";
                }
                else
                {
                    _columna = p.ParametroDescripcion;
                }
                lp.Add(p);
            }
            return lp;
        }
        #endregion

        #region Private Member
        private static Privilegio ConvertToPrivilegios(DataRow dr)
        {
            Privilegio p = new Privilegio();
            if (dr != null)
            {
                p.PrivilegioId= Convert.ToInt32(dr["PrivilegioId"]);
                p.PrivilegioDescripcion= Convert.ToString(dr["Privilegio"]);
                p.Codigo = Convert.ToString(dr["Codigo"]);
                p.ParametroTipoPrivilegioId = Convert.ToInt32(dr["ParametroTipoPrivilegioId"]);
                p.ParametroDescripcion = Convert.ToString(dr["ParametroDescripcion"]);
                p.Posicion = Convert.ToInt32(dr["Posicion"]);
                p.Orden = Convert.ToInt32(dr["Orden"]);
                p.ParametroTipoMostrarId = Convert.ToInt32(dr["ParametroTipoMostrarId"]);
                p.EventoId = Convert.ToInt32(dr["EventoId"]);
            }
            return p;
        }
        #endregion




    }
}
