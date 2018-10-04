
namespace HamCommon
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class Persona
    {
        #region Propiedades
        private const string Entity = "Persona";

        public int PersonaId { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Extension { get; set; }
        public string Titulo { get; set; }
        public string RUDE { get; set; }
        public int CompetidorId { get; set; }
        public string NombreCompleto
        {
            get { return string.Format("{0} {1} {2}", Nombre, Paterno, Materno); }
        }
        #endregion

        #region DML

        public bool Save()
        {
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadParameters();
            if (PersonaId == 0)
            {
                procedimiento = "[pInsertPersona]";
            }
            else
            {
                procedimiento = "[pUpdatePersona]";
                ps.Add(new SqlParameter("PersonaId", PersonaId));
            }
            return ExecuteTransaction(procedimiento, ps);
        }
        #endregion

        #region Metodos GET
        public static Persona GetPersona(int personaId)
        {
            return Parse(personaId);
        }
        public static List<Persona> GetPersonas(int eventoId)
        {
            List<Persona> lcp = new List<Persona>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView( string.Format("[golf].[fGetPersonasCompetidor]({0})", eventoId));
            foreach (DataRow dr in dt.Rows)
            {
                Persona cp = ConvertToPersona(dr);
                lcp.Add(cp);
            }
            return lcp;
        }

        public static List<Persona> SearchCompetidores_Golf(int eventoId, string texto)
        {
            List<Persona> lp = new List<Persona>();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("EventoId", eventoId));
            ps.Add(new SqlParameter("search", texto));
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure("golf.pSearchCompetidor", ps);
            foreach (DataRow dr in dt.Rows)
            {
                lp.Add(ConvertToPersona(dr));
            }
            return lp;
        }
        #endregion

        #region Private
        private static Persona ConvertToPersona(DataRow dr)
        {
            Persona cg = new Persona();
            if (dr != null)
            {
                cg.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                cg.Paterno = Convert.ToString(dr["Paterno"]);
                cg.Materno = Convert.ToString(dr["Materno"]);
                cg.Nombre = Convert.ToString(dr["Nombre"]);

                string fechaNaci = dr["FechaNacimiento"].ToString();
                if (string.IsNullOrEmpty(fechaNaci))
                {
                    cg.FechaNacimiento = DateTime.Now;
                }
                else
                {
                    cg.FechaNacimiento = Convert.ToDateTime(fechaNaci);
                }

                cg.Sexo = Convert.ToString(dr["Sexo"]);
                cg.DocumentoIdentidad = Convert.ToString(dr["DocumentoIdentidad"]);
                cg.Extension = Convert.ToString(dr["Extension"]);
                cg.Titulo = Convert.ToString(dr["Titulo"]);
                cg.RUDE = Convert.ToString(dr["RUDE"]);
                cg.CompetidorId = Convert.ToInt32(dr["CompetidorId"]);
            }
            return cg;
        }

        private static Persona Parse(int personaId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(PersonaId), personaId);
            DataRow dr = db.GetDataRow(Entity, fields);
            Persona cp = ConvertToPersona(dr);
            return cp;
        }

        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Paterno", Paterno));
            ps.Add(new SqlParameter("Materno", Materno));
            ps.Add(new SqlParameter("Nombre", Nombre));
            ps.Add(new SqlParameter("FechaNacimiento", FechaNacimiento));
            ps.Add(new SqlParameter("Sexo", Sexo));
            ps.Add(new SqlParameter("DocumentoIdentidad", DocumentoIdentidad));
            ps.Add(new SqlParameter("Extension", Extension));
            ps.Add(new SqlParameter("Titulo", Titulo));
            ps.Add(new SqlParameter("RUDE", RUDE));
            return ps;
        }

        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        #endregion
    }
}
