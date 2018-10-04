using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace HamGeneric
{
    public class Competidor
    {
        #region Propiedades
        public int CompetidorId { get; set; }
        public int EquipoId { get; set; }
        public int PersonaId { get; set; }
        public int PruebaEventoId { get; set; }
        public bool Activo { get; set; }
        public string MarcaTiempoInicial { get; set; }
        public string Posicion { get; set; }
        #endregion

        #region Componentes

        public Persona Persona { get; set; }
        public Equipo Equipo { get; set; }
        public PruebaEvento PruebaEvento { get; set; }
        
        #endregion

        #region DML
        public static Competidor GetCompetidor(int competidorId,int eventoId,bool constructComponentes=false)
        {
            Competidor cp = new Competidor();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("acre.fCompetidor ({0},{1})", competidorId, eventoId));
            if (dt.Rows.Count>0)
            {
                cp = ConvertToCompetidor(dt.Rows[0], constructComponentes);

            }
            return cp;
        }

        //public int SaveCompetidor()
        //{
        //    string procedimiento="";
        //    List<SqlParameter> ps = new List<SqlParameter>();
        //    ps = LoadParameters();
        //    if (this.PersonaId==0)
        //    {
        //        procedimiento = "acre.pInsPersonas";

        //    }
        //    ExecuteTransaction(procedimiento, ps);
        //    return PersonaId;
        //}
        #endregion

        #region Members
        public static Competidor ConvertToCompetidor(DataRow dr, bool constructComponentes=false)
        {
            Competidor cp = new Competidor();
            if (dr!=null)
            {
                cp.CompetidorId = Convert.ToInt32(dr["CompetidorId"]);
                cp.EquipoId = dr.Table.Columns.Contains("EquipoId")? string.IsNullOrEmpty(dr["EquipoId"].ToString())? 0 : Convert.ToInt32(dr["EquipoId"]) : 0;
                cp.PersonaId = dr.Table.Columns.Contains("PersonaId") ? string.IsNullOrEmpty(dr["PersonaId"].ToString())?  0: Convert.ToInt32(dr["PersonaId"]) : 0;
                cp.PruebaEventoId = Convert.ToInt32(dr["PruebaEventoId"]);
                cp.Activo = Convert.ToBoolean(dr["Activo"]);
                cp.MarcaTiempoInicial = dr.Table.Columns.Contains("MarcaTiempoInicial") ? Convert.ToString(dr["MarcaTiempoInicial"]): "";

                if (constructComponentes)
                {
                    cp.Persona = cp.PersonaId !=0? Persona.GetPersona(cp.PersonaId): new Persona();
                    cp.Equipo = cp.EquipoId != 0 ? Equipo.GetEquipo(cp.EquipoId,true): new Equipo();
                }
            }
            return cp;
        }

        //private List<SqlParameter> LoadParameters()
        //{
        //    List<SqlParameter> ps = new List<SqlParameter>();
        //    ps.Add(new SqlParameter("Nombre", this.Persona.Nombres));
        //    ps.Add(new SqlParameter("Paterno", this.Persona.Paterno));
        //    ps.Add(new SqlParameter("Materno", this.Persona.Materno));
        //    ps.Add(new SqlParameter("FechaNacimiento", this.Persona.FechaNacimiento));
        //    ps.Add(new SqlParameter("Sexo", this.Persona.Sexo));
        //    ps.Add(new SqlParameter("DocumentoIdentidad", this.Persona.DocumentoIdentidad));
        //    ps.Add(new SqlParameter("ParametroTipoSangreId", this.Persona.ParametroTipoSangreId));
        //    ps.Add(new SqlParameter("EventoId", this.Persona.InscripcionEvento.EventoId));
        //    ps.Add(new SqlParameter("DelegacionId", this.Persona.InscripcionEvento.DelegacionId));
        //    ps.Add(new SqlParameter("RepresentacionId", this.Persona.InscripcionEvento.RepresentacionId));
        //    ps.Add(new SqlParameter("RolId", this.Persona.InscripcionEvento.RolId));
        //    ps.Add(new SqlParameter("Grado", this.Persona.InscripcionEvento.Grado));
        //    ps.Add(new SqlParameter("Peso", this.Persona.InscripcionEvento.Peso));
        //    ps.Add(new SqlParameter("Estatura", this.Persona.InscripcionEvento.Estatura));
        //    ps.Add(new SqlParameter("Edad", this.Persona.InscripcionEvento.Edad));
        //    ps.Add(new SqlParameter("Codigo", this.Persona.InscripcionEvento.Codigo));
        //    ps.Add(new SqlParameter("EsIndividual", this.PruebaEvento.EsIndividual));
        //    ps.Add(new SqlParameter("EquipoId", this.EquipoId));
        //    ps.Add(new SqlParameter("Posicion", this.Posicion));
        //    ps.Add(new SqlParameter("MarcaTiempoInicial", this.MarcaTiempoInicial));

        //    return ps;
        //}
        //private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        //{
        //    DBTransaction db = new DBTransaction();
        //    DataTable dt = db.GetStoreProcedure(procedureName, ps);
        //    if (dt.Rows.Count > 0)
        //    {
        //        PersonaId = Convert.ToInt32(dt.Rows[0][0]);
        //    }
        //    return (PersonaId > 0);
        //}
        #endregion

    }
}
