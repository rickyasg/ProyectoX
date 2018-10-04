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
    public class AcreInscripcionEvento
    {
        #region Propiedades
        public int PersonaId { get; set; }
        public int EventoId { get; set; }
        public int DelegacionId { get; set; }
        public int RepresentacionId { get; set; }
        public int RolId { get; set; }
        public string Grado { get; set; }
        public string Talla { get; set; }
        public decimal Peso { get; set; }
        public decimal Estatura { get; set; }
        public int Edad { get; set; }

        private const string Entity = "Persona";
        #endregion

        #region DML
        public bool Save()
        {
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            //ps = LoadParameters();
            if (PersonaId == 0)
            {
                procedimiento = "[Coleque Aqui Su Procedimiento de Insert]";
            }
            else
            {
                procedimiento = "[Coleque Aqui Su Procedimiento de Update]";
                ps.Add(new SqlParameter("PersonaId", PersonaId));
            }
            return ExecuteTransaction(procedimiento, ps);
        }
        #endregion

        #region Metodos GET
        public static AcreInscripcionEvento GetInscripcionEvento(int personaId)
        {
            return Parse(personaId);
        }
        #endregion

        #region Private menbers
        private static AcreInscripcionEvento Parse(int personaId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(PersonaId), personaId);
            DataRow dr = db.GetDataRow(Entity, fields);
            AcreInscripcionEvento cp = ConvertToPersona(dr);
            return cp;
        }

        private static AcreInscripcionEvento ConvertToPersona(DataRow dr)
        {
            AcreInscripcionEvento aie = new AcreInscripcionEvento();
            if (dr != null)
            {
                aie.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                aie.EventoId = Convert.ToInt32(dr["EventoId"]);
                aie.DelegacionId = Convert.ToInt32(dr["DelegacionId"]);
                aie.RepresentacionId = Convert.ToInt32(dr["RepresentacionId"]);
                aie.RolId = Convert.ToInt32(dr["RolId"]);
                aie.Grado = Convert.ToString(dr["Grado"]);
                aie.Talla = Convert.ToString(dr["Talla"]);
                aie.Peso = Convert.ToInt32(dr["Peso"]);
                aie.Estatura = Convert.ToInt32(dr["Estatura"]);
                aie.Edad = Convert.ToInt32(dr["Edad"]);
            }
            return aie;
        }
        //private List<SqlParameter> LoadParameters()
        //{
        //    List<SqlParameter> ps = new List<SqlParameter>();
        //    ps.Add(new SqlParameter("Nombres", Nombres));
        //    ps.Add(new SqlParameter("Paterno", Paterno));
        //    ps.Add(new SqlParameter("Materno", Materno));
        //    ps.Add(new SqlParameter("FechaNacimiento", FechaNacimiento));
        //    ps.Add(new SqlParameter("Sexo", Sexo));
        //    ps.Add(new SqlParameter("DocumentoIdentidad", DocumentoIdentidad));
        //    ps.Add(new SqlParameter("Extension", Extension));
        //    ps.Add(new SqlParameter("ParametroTipoSangreId", ParametroTipoSangreId));
        //    return ps;
        //}

        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        #endregion
    }
}
