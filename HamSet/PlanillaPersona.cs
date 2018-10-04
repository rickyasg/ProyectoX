using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamDataTransactions;
using HamGeneric;
using System.Data;

namespace HamSetModel
{
    public class PlanillaPersona
    {
        #region Propiedades
        public int PlanillaPersonaId { get; set; }
        public int PlanillaId { get; set; }
        public int PersonaId { get; set; }
        public int CompetidorId { get; set; }
        public int NumeroCamiseta { get; set; }
        public string Posicion { get; set; }
        public int ParametroRolId { get; set; }
        public bool Capitan { get; set; }
        public string FotoUrl { get; set; }
        #endregion
        public Persona Persona { get; set; }
        public Parametros Parametros { get; set; }


        #region Metodos Get

        public static List<PlanillaPersona> GetPlanillaPersonas(int competidorId, int planillaId, string search, int parametroRolId = 0)
        {
            List<PlanillaPersona> lpp = new List<PlanillaPersona>();

            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CompetidorId", competidorId));
            ps.Add(new SqlParameter("PlanillaId", planillaId));
            ps.Add(new SqlParameter("search", search));
            ps.Add(new SqlParameter("ParametroRolId", parametroRolId));
            DataTable dt = db.GetStoreProcedure("conj.pGetPlanillaPersonas", ps);
            foreach (DataRow dr in dt.Rows)
            {
                lpp.Add(PlanillaPersona.ConvertPlanillaPersona(dr, true));
            }
            return lpp;
        }







        public static List<PlanillaPersona> GetPlanillaPersonasApoyo(int competidorId, int planillaId, string search, int parametroRolId = 0)
        {
            List<PlanillaPersona> lpp = new List<PlanillaPersona>();

            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CompetidorId", competidorId));
            ps.Add(new SqlParameter("PlanillaId", planillaId));
            ps.Add(new SqlParameter("search", search));
            ps.Add(new SqlParameter("ParametroRolId", parametroRolId));
            DataTable dt = db.GetStoreProcedure("[conj].[pGetPlanillaPersonasApoyo]", ps);
            foreach (DataRow dr in dt.Rows)
            {
                lpp.Add(PlanillaPersona.ConvertPlanillaPersona(dr, true));
            }
            return lpp;
        }

        public static List<PlanillaPersona> GetCapitanPlanilla(int competidorId, int planillaId)
        {
            List<PlanillaPersona> lpp = new List<PlanillaPersona>();

            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CompetidorId", competidorId));
            ps.Add(new SqlParameter("PlanillaId", planillaId));
            DataTable dt = db.GetStoreProcedure("[conj].[pGetCapitanPlanilla]", ps);
            foreach (DataRow dr in dt.Rows)
            {
                lpp.Add(PlanillaPersona.ConvertPlanillaPersona(dr, true));
            }
            return lpp;
        }
        #endregion
        #region Metodos DML
        public int Save()
        {
            /// int result = 0;
            if (PlanillaPersonaId == 0)
            {
                return Insert();
            }
            else
            {
                return Update();
            }

        }

        public bool Delete()
        {
            if (PlanillaPersonaId != 0)
            {
                List<SqlParameter> ps = new List<SqlParameter>();
                ps.Add(new SqlParameter("PlanillaPersonaId", PlanillaPersonaId));
                return Convert.ToBoolean(ExecuteTransaction("conj.pDelPlanillaPersona", ps).Rows[0]["Resultado"]);
            }
            return false;
        }

        public static PlanillaPersona ConvertPlanillaPersona(DataRow dr, bool buildComponents = false)
        {
            PlanillaPersona pp = new PlanillaPersona();
            if (dr != null)
            {
                pp.PlanillaPersonaId = !string.IsNullOrEmpty(dr["PlanillaPersonaId"].ToString()) ? Convert.ToInt32(dr["PlanillaPersonaId"]) : 0;
                pp.PlanillaId = Convert.ToInt32(dr["PlanillaId"]);
                pp.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                pp.CompetidorId = Convert.ToInt32(dr["CompetidorId"]);
                pp.NumeroCamiseta = Convert.ToInt32(dr["NumeroCamiseta"]);
                pp.Posicion = Convert.ToString(dr["Posicion"]);
                pp.ParametroRolId = dr.Table.Columns.Contains("ParametroRolId") ? Convert.ToInt32(dr["ParametroRolId"]) : 0;
                pp.Capitan = Convert.ToBoolean(dr["Capitan"]);
                try
                {
                    pp.FotoUrl = string.IsNullOrEmpty(dr["FotoUrl"].ToString()) ? string.Empty : dr["FotoUrl"].ToString();
                }
                catch { }
                if (buildComponents)
                {
                    pp.Persona = pp.PersonaId != 0 ? Persona.ConvertToPersona(dr) : new Persona();
                    pp.Parametros = pp.ParametroRolId != 0 ? Parametros.ConvertToParametros(dr) : new Parametros();
                }
            }
            return pp;
        }


        private int Insert()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadParameters();
            try
            {
                return Convert.ToInt32(ExecuteTransaction("[conj].[pInsPlanillaPersona]", ps).Rows[0]["Resultado"]);
            }
            catch
            {
                return -1;
            }
        }
        private int Update()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadParameters();
            ps.Add(new SqlParameter("PlanillaPersonaId", PlanillaPersonaId));
            return Convert.ToInt32(ExecuteTransaction("[conj].[pUpdPlanillaPersona]", ps).Rows[0]["Resultado"]);
        }

        private DataTable ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure(procedureName, ps);

            return dt;
        }
        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));
            ps.Add(new SqlParameter("PersonaId", PersonaId));
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            ps.Add(new SqlParameter("NumeroCamiseta", NumeroCamiseta));
            ps.Add(new SqlParameter("Posicion", Posicion));
            ps.Add(new SqlParameter("ParametroRolId", ParametroRolId));
            ps.Add(new SqlParameter("Capitan", Capitan));
            return ps;
        }
        #endregion
        #region Metodos Equipo Persona
        public static DataTable getEquipoPersona(int competidorId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetPlanillaEquipoPersona]({0})", competidorId));
            return dt;
        }
        public static int getPersonaId(int competidorId)
        {
            try
            {
                DBTransaction db = new DBTransaction();

                var resultado = db.GetData(string.Format("select indv.fGetPersonaIdComp({0})", competidorId));
                var entero = Convert.ToInt32(resultado[0][0]);
                return entero;
            }
            catch (Exception e) {
                var mensaje = e.Message;
                return 0; }
        }
        #endregion
    }
}
