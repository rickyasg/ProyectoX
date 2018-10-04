

namespace HamDataModel
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public partial class GolfCompetidor
    {
        #region Propiedades
        public int CompetidorId { get; set; }
        public int Handicap { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaDescripcion { get; set; }
        public string Club { get; set; }

        const string Entity = "GolfCompetidor";
        #endregion

        #region Metodos DML
        public bool Insert()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = SetParameters(ps);
            db.ExecStoreProcedure("[golf].[pInsCompetidor]", ps);
            return (db.RowAffected > 0);
        }

        public bool Update()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = SetParameters(ps);
            db.ExecStoreProcedure("[golf].[pUpCompetidor]", ps);
            return (db.RowAffected > 0);
        }

        public bool UpdateEstado()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = SetParameters(ps);
            db.ExecStoreProcedure("[golf].[pUpdEstadoTarjeta]", ps);
            return (db.RowAffected > 0);
        }


        public bool DeleteInscrito(int CompetidorId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            db.ExecStoreProcedure("[golf].[pDeleteCompetidor]", ps);
            return (db.RowAffected > 0);
        }

        public bool Delete(int competidorId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CompetidorId", competidorId));
            db.ExecStoreProcedure("pDelCompetidor", ps);
            return (db.RowAffected > 0);
        }
        #endregion

        #region Metodos GET
        public static GolfCompetidor GetGolfCompetidor(int competidorId)
        {
            return Parse(competidorId);
        }

        public static DataTable GetGolfCompetidorByPersonaId(int personaId)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[golf].[vPersonas] where [PersonaId] = {0}", personaId));
            return dt;
        }

        public static DataTable GetResultadoCompetidor(int jornaId, int personaId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("JornadaId", jornaId));
            ps.Add(new SqlParameter("PersonaId", personaId));
            return db.GetStoreProcedure("[golf].[pResultadosCompetidor]", ps);
        }

        public static List<DataTable> GetResultadosCompetidor(int personaId,int eventoId)
        {
            List<GolfJornada> nroJornadas = GolfJornada.GetGolfJornadas(eventoId);
            DBTransaction db = new DBTransaction();
            List<DataTable> resultadosCompetidor = new List<DataTable>();
            foreach (GolfJornada item in nroJornadas)
            {
                List<SqlParameter> ps = new List<SqlParameter>();
                ps.Add(new SqlParameter("JornadaId", item.JornadaId));
                ps.Add(new SqlParameter("PersonaId", personaId));
                DataTable dt = db.GetStoreProcedure("[golf].[pResultadosCompetidor]", ps);
                if (dt.Rows.Count > 0)
                {
                    resultadosCompetidor.Add(dt);
                }
            }

            return resultadosCompetidor;
        }

        public static DataTable GetHCPporciento(int competidorId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CompetidorId", competidorId));
            return db.GetStoreProcedure("pGolfGetHCPporciento", ps);
        }

        

        #endregion

        #region Private Members
        private static GolfCompetidor Parse(int competidorId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(CompetidorId), competidorId);
            DataRow dr = db.GetDataRow(Entity, fields);
            GolfCompetidor gjo = ConvertToJornada(dr);
            return gjo;
        }

        private static GolfCompetidor ConvertToJornada(DataRow dr)
        {
            GolfCompetidor gc = new GolfCompetidor();
            if (dr != null)
            {
                gc.CompetidorId = Convert.ToInt32(dr["CompetidorId"]);
                gc.Handicap = Convert.ToInt32(dr["Handicap"]);
                gc.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                gc.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                gc.CategoriaId = Convert.ToInt32(dr["CategoriaId"]);
                gc.CategoriaDescripcion = Convert.ToString(dr["CategoriaDescripcion"]);
                gc.Club = Convert.ToString(dr["Club"]);
            }
            return gc;
        }

        private List<SqlParameter> SetParameters(List<SqlParameter> ps)
        {
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            ps.Add(new SqlParameter("Handicap", Handicap));
            ps.Add(new SqlParameter("CategoriaID", CategoriaId));
            ps.Add(new SqlParameter("Club", Club));
            return ps;
        }
        #endregion
    }
}
