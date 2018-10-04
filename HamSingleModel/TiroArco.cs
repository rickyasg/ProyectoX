using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HamSingleModel
{
    public class Periodo_TiroArco
    {
        public int sw { get; set; }
        public int valor { get; set; }
        public int PlanillaId { get; set; }
        public int PeriodoId { get; set; }

        public DataTable controlPeriodo()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("sw", sw));
            ps.Add(new SqlParameter("valor", valor));
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));

            var resultado = db.GetStoreProcedure("[tarc].[pCheckPeriodos]", ps);
            return resultado;
        }
        public DataTable cerrarPeriodo()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));
            ps.Add(new SqlParameter("PeriodoId", PeriodoId));

            return db.GetStoreProcedure("[tarc].[pUpdPeriodos ]", ps);
        }

        public static DataTable GetPuntosPlanilla(int PlanillaId, int PeriodoId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));
            ps.Add(new SqlParameter("PeriodoId", PeriodoId));

            var resultado = db.GetStoreProcedure("[tarc].[pGetPuntosPlanilla]", ps);
            return resultado;
        }

    }
    public class punto_tiroArco
    {
        public int PeriodoId { get; set; }
        public int PersonaId { get; set; }
        public int PlanillaId { get; set; }
        public int CompetidorId { get; set; }
        public int Puntaje { get; set; }
        public int Estado { get; set; }
        public int UsuarioId { get; set; }
        public int PuntoId { get; set; }

        public int savePunto()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PeriodoId", PeriodoId));
            ps.Add(new SqlParameter("PersonaId", PersonaId));
            ps.Add(new SqlParameter("PlanillaId", PlanillaId));
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            ps.Add(new SqlParameter("Puntaje", Puntaje));
            ps.Add(new SqlParameter("Estado", Estado));
            ps.Add(new SqlParameter("UsuarioId", UsuarioId));
            ps.Add(new SqlParameter("PuntoId", PuntoId));

            var resultado = db.GetStoreProcedure("[tarc].[pInsPuntos]", ps).Rows[0]["Resultado"];
            return Convert.ToInt32(resultado);
        }
        public static DataTable GetPuntos(int PlanillaId, int CompetidorId, int PeriodoId)
        {
            DataTable personal = new DataTable();
            DBTransaction db = new DBTransaction();
            personal = db.GetDataFuncion(string.Format("select * from [tarc].[fGetPuntosPlanilla]({0},{1},{2})", PlanillaId, CompetidorId, PeriodoId));

            return personal;
        }
        public static int GetPuntajeTiros(int PeriodoId, int PlanillaId, int CompetidorId)
        {
            int puntos = 0;
            DBTransaction db = new DBTransaction();
            var dt = db.GetDataFuncion(string.Format("select [tarc].[fGetPuntajeTiros]({0},{1},{2})", PeriodoId,PlanillaId,CompetidorId));
            if (dt.Rows.Count > 0)
            {
                try
                {
                    puntos = Convert.ToInt32(dt.Rows[0][0]);
                }
                catch 
                {
                    puntos = 0;
                }
                
            }
            return puntos;
        }
        public DataTable EliminarPunto()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PuntoId", PuntoId));

            return db.GetStoreProcedure("[tarc].[pDelPuntos]", ps);
        }

    }
    public class TiroArco
    {
        public int CronogramaId { get; set; }
        public static int GetPlanilla(int cronogramaId)
        {
            int planilla = 0;
            DBTransaction db = new DBTransaction();
            var dt = db.GetDataFuncion(string.Format("select [tarc].[fGetPlanilla]({0})", cronogramaId));
            if (dt.Rows.Count > 0)
            {
                planilla = Convert.ToInt32(dt.Rows[0][0]);
            }
            return planilla;
        }

        public int savePlanilla()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CronogramaId", CronogramaId));
            var resultado = db.GetStoreProcedure("[tarc].[pInsPlanilla]", ps).Rows[0]["Resultado"];
            return Convert.ToInt32(resultado);
        }
        public static DataTable GetPersonas(int cronogramaId, int CompetidorId)
        {
            DataTable personal = new DataTable();
            DBTransaction db = new DBTransaction();
            personal = db.GetDataFuncion(string.Format("select * from [tarc].[fGetPersonasCompetidor]({0},{1})", cronogramaId, CompetidorId));

            return personal;
        }
        
    }
}
