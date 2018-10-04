using HamDataTransactions;
using HamGeneric;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamSetModel
{
    public class Suceso
    {
        #region  Propiedades
        public int SucesoId { get; set; }
        public int DeportePeriodoId { get; set; }
        public string Tiempo { get; set; }
        public int CompetidorId { get; set; }
        public int PlanillaId { get; set; }
        public int ParametroSucesoId { get; set; }
        public int Valor { get; set; }


        public SucesoPersona SucesoPersona { get; set; }
        public List<SucesoPersona> SucesoPersonas { get; set; }
        public Competidor Competidor { get; set; }
        public ParametrosSuceso ParametrosSuceso { get; set; }

        #endregion
        #region Metodos Post
        public bool SaveSuceso()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadParameters();
            return ExecuteTransaction("[conj].[pInsSucesos]", ps);
        }
        public bool DeletSuceso()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("SucesoId", SucesoId));
            return ExecuteTransaction("conj.pDelSuceso", ps);
        }

        public bool SavePosesionBalon()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("DeportePeriodoId", DeportePeriodoId));
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));
            ps.Add(new SqlParameter("Valor", Valor));
            ps.Add(new SqlParameter("ParametroSucesoId", ParametroSucesoId));
            return ExecuteTransaction("[conj].[pInsSucesosPosesionBalon]", ps);
        }
        public bool SaveTiempoAdicion()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("DeportePeriodoId", DeportePeriodoId));
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));
            ps.Add(new SqlParameter("Valor", Valor));
            ps.Add(new SqlParameter("ParametroSucesoId", ParametroSucesoId));
            return ExecuteTransaction("[conj].[pInsSucesosAdicion]", ps);
        }

        public static List<Suceso> GetSucesos(int planillaId, int competidorId, int ParametroSucesoId)
        {
            List<Suceso> lsu = new List<Suceso>();

            return lsu;
        }

        public static List<Suceso> GetHistorialSuceso(int planillaId, int deportePeriodoId, int competidorId)
        {
            List<Suceso> lsu = new List<Suceso>();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("PlanillaId", planillaId));
            lp.Add(new SqlParameter("DeportePeriodoId", deportePeriodoId));
            lp.Add(new SqlParameter("CompetidorId", competidorId));

            DBTransaction db = new DBTransaction();

            DataTable dt = db.GetStoreProcedure("conj.pHistorialSuceso", lp);
            int FindIndice = -1;
            foreach (DataRow dr in dt.Rows)
            {
                Suceso sc = ConvertToSucesos(dr);
                sc.Competidor = Competidor.ConvertToCompetidor(dr);

                sc.Competidor.Equipo = Equipo.ConvertToEquipo(dr);
                sc.ParametrosSuceso = ParametrosSuceso.ConvertToParametroSuceso(dr);
                sc.SucesoPersonas = new List<SucesoPersona>();

                if (sc.ParametrosSuceso.RegistraPersona >= 1 && !string.IsNullOrEmpty(dr["PlanillaPersonaId"].ToString()))
                {

                    SucesoPersona scp = SucesoPersona.ConvertToSucesoPersona(dr);
                    scp.PlanillaPersona = PlanillaPersona.ConvertPlanillaPersona(dr, true);

                    FindIndice = lsu.FindIndex(delegate (Suceso s) { return s.SucesoId == sc.SucesoId; });
                    if (FindIndice > 0)
                    {
                        lsu.ElementAt(FindIndice).SucesoPersonas.Add(scp);
                    }
                    else
                    {
                        sc.SucesoPersonas.Add(scp);
                        FindIndice = -1;
                    }
                }
                else
                {
                    FindIndice = -1;
                }
                if (FindIndice < 0)
                {
                    lsu.Add(sc);
                }
            }
            return lsu;
        }

        public static List<Suceso> GetHistorialCronogramas(int cronogramaId, int deportePeriodoId, int competidorId)
        {
            List<Suceso> lsu = new List<Suceso>();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("CronogramaId", cronogramaId));
            lp.Add(new SqlParameter("DeportePeriodoId", deportePeriodoId));
            lp.Add(new SqlParameter("CompetidorId", competidorId));

            DBTransaction db = new DBTransaction();

            DataTable dt = db.GetStoreProcedure("conj.pHistorialCronograma", lp);
            int FindIndice = -1;
            foreach (DataRow dr in dt.Rows)
            {
                Suceso sc = ConvertToSucesos(dr);
                sc.Competidor = Competidor.ConvertToCompetidor(dr);

                sc.Competidor.Equipo = Equipo.ConvertToEquipo(dr);
                sc.ParametrosSuceso = ParametrosSuceso.ConvertToParametroSuceso(dr);
                sc.SucesoPersonas = new List<SucesoPersona>();

                if (sc.ParametrosSuceso.RegistraPersona >= 1 && !string.IsNullOrEmpty(dr["PlanillaPersonaId"].ToString()))
                {

                    SucesoPersona scp = SucesoPersona.ConvertToSucesoPersona(dr);
                    scp.PlanillaPersona = PlanillaPersona.ConvertPlanillaPersona(dr, true);

                    FindIndice = lsu.FindIndex(delegate (Suceso s) { return s.SucesoId == sc.SucesoId; });
                    if (FindIndice > 0)
                    {
                        lsu.ElementAt(FindIndice).SucesoPersonas.Add(scp);
                    }
                    else
                    {
                        sc.SucesoPersonas.Add(scp);
                        FindIndice = -1;
                    }
                }
                else
                {
                    FindIndice = -1;
                }
                if (FindIndice < 0)
                {
                    lsu.Add(sc);
                }
            }
            return lsu;
        }

        public static Suceso ConvertToSucesos(DataRow dr)
        {
            Suceso sc = new Suceso();
            sc.SucesoId = Convert.ToInt32(dr["SucesoId"]);
            sc.DeportePeriodoId = Convert.ToInt32(dr["DeportePeriodoId"]);
            sc.Tiempo = Convert.ToString(dr["Tiempo"]);
            sc.CompetidorId = Convert.ToInt32(dr["CompetidorId"]);
            sc.PlanillaId = Convert.ToInt32(dr["PlanillaId"]);
            sc.ParametroSucesoId = Convert.ToInt32(dr["ParametroSucesoId"]);
            sc.Valor = Convert.ToInt32(dr["Valor"]);
            return sc;
        }
        public static int DeleteSucesosGrupo(int[] sucesos)
        {
            int res = 0;
            foreach (int item in sucesos)
            {
                if (DeletSucesoId(item))
                    res += 1;
            }
            return res;
        }
        public static bool DeletSucesoId(int sucesoId)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("SucesoId", sucesoId));
            return ExecuteTransactionData("conj.pDelSuceso", ps);
        }

        #endregion

        public static int getPosecion(int DeporteId)
        {
            int resultado = 0;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("DeporteId", DeporteId));

            DBTransaction db = new DBTransaction();
            var tabla = db.GetDataFuncion(string.Format("select  conj.fGetPosesionBalonFlag({0})", DeporteId));
            if (tabla.Rows.Count > 0)
            {
                resultado = Convert.ToInt32(tabla.Rows[0][0]);

            }
            return resultado;
        }

        public static int getTiempoExtra(int DeporteId)
        {
            int resultado = 0;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("DeporteId", DeporteId));

            DBTransaction db = new DBTransaction();
            var tabla = db.GetDataFuncion(string.Format("select  conj.fGetTiempoExtraFlag({0})", DeporteId));
            if (tabla.Rows.Count > 0)
            {
                 resultado = Convert.ToInt32(tabla.Rows[0][0]);
               
            }
            return resultado;
        }
        public static int getDelegacioId(int CompetidorId)
        {
            int resultado = 0;
            DBTransaction db = new DBTransaction();
            var tabla = db.GetDataFuncion(string.Format("select  conj.fGetDelegacionId({0})", CompetidorId));
            if (tabla.Rows.Count > 0)
            {
                resultado = Convert.ToInt32(tabla.Rows[0][0]);

            }
            return resultado;
        }

        public static DataTable getNombrePersona(int PersonaId)
        {
            DBTransaction db = new DBTransaction();
            var tabla = db.GetDataFuncion(string.Format("select * from conj.fGetNombrePersona({0})", PersonaId));
            return tabla;
        }
        #region Private Members
        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("DeportePeriodoId", DeportePeriodoId));
            ps.Add(new SqlParameter("Tiempo", Tiempo));
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));
            ps.Add(new SqlParameter("ParametroSucesoId", ParametroSucesoId));
            ps.Add(new SqlParameter("Valor", Valor));
            // Complemento
            if (SucesoPersonas != null)
            {
                if (SucesoPersonas.Count >= 1)
                {
                    ps.Add(new SqlParameter("PlanillaPersonaId1", SucesoPersonas[0].PlanillaPersonaId));
                }
                if (SucesoPersonas.Count == 2)
                {
                    ps.Add(new SqlParameter("PlanillaPersonaId2", SucesoPersonas[1].PlanillaPersonaId));
                }

            }
            //ps.Add(new SqlParameter("PlanillaPersonaId", SucesoPersona.PlanillaPersonaId));
            //ps.Add(new SqlParameter("Orden", SucesoPersona.Orden));
            return ps;
        }
        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }

        private static bool ExecuteTransactionData(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        #endregion
    }
}
