using HamDataModel;
using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamCommon
{
    public class Competidor
    {
        #region Propiedades
        public int CompetidorId { get; set; }
        public int EquipoId { get; set; }
        public int PersonaId { get; set; }
        public int DisciplinaId { get; set; }
        public string Categoria { get; set; }
        public int EventoDeportivoId { get; set; }
        public GolfCompetidor Gcompetidor { get; set; }
        const string Entity = "Competidor";
        #endregion

        #region DML
        public bool Save()
        {
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadParameters();

            if (CompetidorId == 0)
            {
                procedimiento = "[psetCompetidor]";
            }
            else
            {
                procedimiento = "[pUpCompetidor]";
                ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            }

            return ExecuteTransaction(procedimiento, ps);

        }

        public bool DeleteCompetidor(int competidorId)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("competidorId", competidorId));
            return ExecuteTransaction("pDelCompetidor", ps);
        }
        #endregion

        #region Metodos GET
        public static Competidor GetCompetidor(int competidorId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(CompetidorId), competidorId);
            DataRow dr = db.GetDataRow(Entity, fields);
            return ConvertToCompetidor(dr);
        }
        #endregion

        #region Private
        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("EquipoId", EquipoId));
            ps.Add(new SqlParameter("DisciplinaId", DisciplinaId));
            ps.Add(new SqlParameter("PersonaId", PersonaId));
            //ps.Add(new SqlParameter("Categoria", Categoria));
            ps.Add(new SqlParameter("EventoId", EventoDeportivoId));
            return ps;
        }

        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure(procedureName, ps);

            if (dt.Rows.Count > 0)
            {
                this.CompetidorId = Convert.ToInt32(dt.Rows[0]["Resultado"]);
            }
            return (this.CompetidorId > 0);
        }

        private static Competidor ConvertToCompetidor(DataRow dr)
        {
            Competidor ed = new Competidor();
            if (dr != null)
            {
                ed.CompetidorId = Convert.ToInt32(dr["EventoDeportivoId"]);
                ed.EquipoId = Convert.ToInt32(dr["EventoDeportivoId"]);
                ed.PersonaId = Convert.ToInt32(dr["EventoDeportivoId"]);
                ed.DisciplinaId = Convert.ToInt32(dr["EventoDeportivoId"]);
                ed.Categoria = Convert.ToString(dr["EventoDeportivoId"]);
                ed.EventoDeportivoId = Convert.ToInt32(dr["EventoDeportivoId"]);
            }
            return ed;
        }
        #endregion
    }
}
