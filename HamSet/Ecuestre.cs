using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HamSetModel
{
   public class Ecuestre
    {
        public int CompetidorId { get; set; }
        public int CronogramaId { get; set; }
        public int LeccionId { get; set; }
        public int LeccionCompetidorId { get; set; }
        public string Hora { get; set; }

        public static DataTable GetCompetidoresEcuestre(int cronogramaId, int LeccionId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[ecue].[fGetLeccionCompetidores]({0},{1}) order by Hora", cronogramaId, LeccionId));
            return dt;
        }

        public   int saveCompetidor()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CronogramaId", CronogramaId));
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            ps.Add(new SqlParameter("LeccionId", LeccionId));
            ps.Add(new SqlParameter("Hora", Hora));
            ps.Add(new SqlParameter("LeccionCompetidorId", LeccionCompetidorId));
            var resultado=db.GetStoreProcedure("[ecue].[pInsLeccionCompetidor]", ps).Rows[0]["Resultado"];
            return Convert.ToInt32(resultado);
        }
        public static int deleteCompetidor(int LeccionCompetidorId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("LeccionCompetidorId", LeccionCompetidorId));
            var resultado = db.GetStoreProcedure("[ecue].[pDelLeccionCompetidor]", ps).Rows[0]["Resultado"];
            return Convert.ToInt32(resultado);
        }
        public static DataTable fGetLecciones(int EventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[ecue].[fGetLecciones]({0}) order by Leccion", EventoId));
            return dt;
        }
    }
}
