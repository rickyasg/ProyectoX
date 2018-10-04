using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class Instalacion
    {
        #region Propiedades
        public int InstalacionId { get; set; }
        public string InstalacionDescripcion { get; set; }
        public string Direccion { get; set; }
        public int ParametroTipoInstalacionId { get; set; }
        public string Codigo { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }

        private const string Entity = "[prog].[vInstalaciones]";

        #endregion

        #region Metodos Get
        public static List<Instalacion> GetInstalaciones()
        {
            List<Instalacion> lins = new List<Instalacion>();
            DBTransaction db = new DBTransaction();
            DataTable dt= db.GetDataView(Entity);
            dt.DefaultView.Sort = "Instalacion asc";
            foreach (DataRow dr in dt.Rows)
            {
                Instalacion ins = ConvertToInstalcion(dr);

                lins.Add(ins);
            }

            return lins;

        }
        public static List<Area> GetAreas(int InstalacionId)
        {
            List<Area> lins = new List<Area>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetData(string.Format("select * from prog.fGetAreasInstalacion({0})",InstalacionId)).Table;
            foreach (DataRow dr in dt.Rows)
            {
                Area area = new Area {
                    InstalacionId=Convert.ToInt32( dr["InstalacionId"]),
                    AreaInstalacionId=Convert.ToInt32( dr["AreaInstalacionId"]),
                    Instalacion=Convert.ToString( dr["Instalacion"]),
                    Descripcion=Convert.ToString( dr["Descripcion"])
                };

                lins.Add(area);
            }

            return lins;
        }

        public static Instalacion GetInstalacion(int instalacionId)
        {
            return Parse(instalacionId);
        }

        #endregion
        #region Private Members
        private static Instalacion Parse (int instalacionId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(InstalacionId), instalacionId);
            DataRow dr = db.GetDataRow(Entity, fields);
            Instalacion ins = ConvertToInstalcion(dr);
            return ins;
        }
        private static Instalacion ConvertToInstalcion(DataRow dr)
        {
            Instalacion ins = new Instalacion();
            if (dr!=null)
            {
                ins.InstalacionId = Convert.ToInt32(dr["InstalacionId"]);
                ins.InstalacionDescripcion = Convert.ToString(dr["Instalacion"]);
                ins.Direccion= Convert.ToString(dr["Direccion"]);
                ins.ParametroTipoInstalacionId= Convert.ToInt32(dr["ParametroTipoInstalacionId"]);
                ins.Codigo = Convert.ToString(dr["Codigo"]);
             //   ins.Latitud =(float)Convert.ToDecimal(dr["Latitud"]);
              //  ins.Longitud =(float)Convert.ToDecimal(dr["Longitud"]);
            }
            return ins;
        }
        #endregion

    }
}
