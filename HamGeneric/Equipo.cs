using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class Equipo
    {
        #region Propiedades

        public int EquipoId { get; set; }
        public string EquipoDescripcion { get; set; }
        public int DelegacionId { get; set; }
        public int PruebaEventoId { get; set; }
        public string Representacion { get; set; }
        public int EventoId { get; set; }

        #endregion

        #region Componentes
        public Delegacion Delegacion { get; set; }
        public PruebaEvento PruebaEvento { get; set; }
        #endregion

        private const string Entity = "acre.Equipos";

        #region Metodos Get
        public  static Equipo GetEquipo(int equipoId, bool constructComponentes=false)
        {
            Equipo eq = new Equipo();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("acre.fEquipos ({0})", equipoId));
            eq = ConvertToEquipo(dt.Rows[0], constructComponentes);
            return eq;
        }
        public static DataTable getEquipoConjunto (int cronogramaId, int parametroTipoId, string buscar)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            ls.Add(new SqlParameter("ParametroTipoId", parametroTipoId));
            ls.Add(new SqlParameter("Buscar", buscar));

            dt = db.GetStoreProcedure ("[conj].[pGetEquiposConjunto]",ls);
            return dt;
        }
        #endregion

        public int SaveEquipo()
        {
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadFullParameters();
            if (this.EquipoId==0)
            {
                procedimiento = "[acre].[pInsEquipo]";
            }
            else
            {
                procedimiento = "[Coleque Aqui Su Procedimiento de Update]";
                ps.Add(new SqlParameter("EquipoId", EquipoId));
            }

            ExecuteTransaction(procedimiento, ps);
            return EquipoId;

        }

        #region Members
        private List<SqlParameter> LoadFullParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Equipo",this.EquipoDescripcion));
            ps.Add(new SqlParameter("DelegacionId", this.DelegacionId));
            ps.Add(new SqlParameter("PruebaId",this.PruebaEvento.PruebaId));
            ps.Add(new SqlParameter("ParametroRamaId",this.PruebaEvento.ParametroRamaId));
            ps.Add(new SqlParameter("EventoId",this.EventoId));
            return ps;

        }
        public static Equipo ConvertToEquipo(DataRow dr,bool buildComponents=false)
        {
            Equipo eq = new Equipo();
            if (dr!=null)
            {
                eq.EquipoId = Convert.ToInt32(dr["EquipoId"]);
                eq.EquipoDescripcion = Convert.ToString(dr["Equipo"]);
                eq.DelegacionId = dr.Table.Columns.Contains("DelegacionId") ? Convert.ToInt32(dr["DelegacionId"]) : 0;
                eq.PruebaEventoId = dr.Table.Columns.Contains("PruebaEventoId") ? Convert.ToInt32(dr["PruebaEventoId"]) : 0;
                eq.Representacion = dr.Table.Columns.Contains("Representacion") ? Convert.ToString(dr["Representacion"]) : string.Empty;
                if (buildComponents)
                {
                    eq.Delegacion = eq.DelegacionId == 0 ? new Delegacion() : new Delegacion(); //Falta estos metodos
                    eq.PruebaEvento = eq.PruebaEventoId == 0 ? new PruebaEvento() : new PruebaEvento();//Falta estos metodos
                }
            }
            return eq;
        }

        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure(procedureName, ps);
            if (dt.Rows.Count > 0)
            {
                this.EquipoId = Convert.ToInt32(dt.Rows[0][0]);
            }
            return (this.EquipoId > 0);
        }
        #endregion

    }
}
