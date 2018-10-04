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
using System.Web;

namespace HamGeneric
{
    public class Persona
    {
        #region Propiedades
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Extension { get; set; }
        public int ParametroTipoSangreId { get; set; }
        public string photo { get; set; }
        public string NombreCompleto { get; set; }
      

        #region Componentes
        public InscripcionEvento InscripcionEvento { get; set; }
        #endregion  

        private const string Entity = "acre.Personas";
        #endregion


        #region Metodos Post

        public int SavePersonaInscrita()
        {
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
           
            if (PersonaId == 0)
            {
                ps = LoadFullParameters();
                procedimiento = "acre.pInsPersonas";
            }
            else
            {
                ps= this.LoadParametersInsPersonaEvento();
                procedimiento = "acre.pInsPersonaEvento";
                ps.Add(new SqlParameter("PersonaId", PersonaId));
            }
            ExecuteTransaction(procedimiento, ps);

            if (!string.IsNullOrEmpty(photo))
            {
                SaveFotoPersona();
            }
            return PersonaId;
        }

        #endregion

        #region Metodos GET
        public static Persona GetPersona(int personaId)
        {
            return Parse(personaId);
        }
               
        public static DataTable GetPersonaByCI(string ci)
        {
            DBTransaction db = new DBTransaction();
            return db.GetDataView(string.Format("[acre].[vAcreditacionDetallePersona]  where [DocIdentidad] = '{0}'", ci));
        }
        public static List<Persona> GetDeportista()
       {
            List<Persona> lpp = new List<Persona>();

            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            DataTable dt = db.GetStoreProcedure("acre.pSearchPersonas", ps);
           foreach (DataRow dr in dt.Rows)
            {
                lpp.Add(Persona.ConvertDeportista(dr));
            }
            return lpp;
        }
        public static Persona ConvertDeportista(DataRow dr)
        {
            Persona pp = new Persona();
            if (dr != null)
            {
                pp.NombreCompleto = Convert.ToString(dr["Completo"]);
                pp.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                pp.Nombres = Convert.ToString(dr["Nombres"]);
                pp.Paterno = Convert.ToString(dr["Paterno"]);
                pp.Materno = Convert.ToString(dr["Materno"]);


            }
            return pp;
        }

        public static List<Persona> SearchPersona(string search)
        {
            List<Persona> lp = new List<Persona>();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Search", search));
            DBTransaction db = new DBTransaction();
            DataTable dt= db.GetStoreProcedure("acre.pSearchPersona", ps);
            foreach (DataRow dr in dt.Rows)
            {
                lp.Add(ConvertToPersona(dr,true));
            }
            return lp;
        }
        public static List<Persona> SearchPersonaEvento(string search, int eventoId, int DelegacionId)
        {
         List<Persona> lp = new List<Persona>();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Search", search));
            ps.Add(new SqlParameter("EventoId", eventoId));
            ps.Add(new SqlParameter("DelegacionId", DelegacionId));
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure("acre.pSearchPersona", ps);
            foreach (DataRow dr in dt.Rows)
            {
                lp.Add(ConvertToPersona(dr, true));
            }
            return lp;
        }

        public static List<Persona> SearchPersonaEquipo(string search, int competidorId,int planillaId=0)
        {
            List<Persona> lp = new List<Persona>();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("search", search));
            ps.Add(new SqlParameter("CompetidorId", competidorId));
            ps.Add(new SqlParameter("PlanillaId", planillaId));
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure("conj.pSearchPersonaEquipo", ps);
            foreach (DataRow dr in dt.Rows)
            {
                lp.Add(ConvertToPersona(dr, false));
            }
            return lp;
        }

        public static List<Persona> SearchPersonaApoyo(string search, int eventoId)
        {
            List<Persona> lp = new List<Persona>();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("search", search));
            ps.Add(new SqlParameter("EventoId", eventoId));
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure("[conj].[pSearchPersonaApoyo]", ps);
            foreach (DataRow dr in dt.Rows)
            {
                lp.Add(ConvertToPersona(dr, false));
            }
            return lp;
        }



        public static DataTable GetDetalleAcreditacionPersona(int PersonaId)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[acre].[vAcreditacionDetallePersona] where [PersonaId]= {0}", PersonaId));
            return dt;
        }

        public static DataTable GetInscripcionEvento(int EventoId)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[acre].[vAcreditacionDetallePersona] where [EventoId]= {0}", EventoId));
            return dt;
        }

        public static DataTable GetInscripcionEnventoDelegacion(int EventoId, int DelegacionId)
        {
            DBTransaction db = new DBTransaction();
            //DataTable dt = db.GetDataView(string.Format("[acre].[vAcreditacionDetallePersona] where [EventoId]= {0} and DelegacionId = {1}", EventoId, DelegacionId));
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("EventoId", EventoId));
            ps.Add(new SqlParameter("DelegacionId", DelegacionId));
            DataTable dt = db.GetStoreProcedure("[acre].[pInscritosDelegacion]", ps);
            return dt;
        }

        public static string GetFotoPersona(int personaId)
        {
            string path = ConfigurationManager.AppSettings["ApplicationResources"];
            path = string.Format("{0}Images\\erpDeportes\\{1}.png", path, personaId);
            if (!File.Exists(path))
            {
                path = string.Format("{0}Images\\erpDeportes\\user.png", ConfigurationManager.AppSettings["ApplicationResources"]);
            }
            return string.Format("data:image/jpeg;base64,{0}", ImageToString(path));
        }


        public static string ImageToString(string ImageFile)
        {
            string imagen = string.Empty;
            if (File.Exists(ImageFile))
            {
                byte[] fileData = File.ReadAllBytes(ImageFile);
                imagen = Convert.ToBase64String(fileData);
            }
            return imagen;
        }
        #endregion

        #region Private members
        private static Persona Parse(int personaId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(PersonaId), personaId);
            DataRow dr = db.GetDataRow(Entity, fields);
            Persona cp = ConvertToPersona(dr);
            return cp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr">datarow que contiene todas las columnas para contruir el objeto</param>
        /// <param name="contructComponentes">true para contruir componentes que tiene el objeto, el valor es opcional por defecto tiene el valor false</param>
        /// <returns></returns>
        public static Persona ConvertToPersona(DataRow dr,bool constructComponentes = false)
        {
            Persona ap = new Persona();
            if (dr != null)
            {
                ap.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                ap.Nombres = Convert.ToString(dr["Nombres"]);
                ap.Paterno = Convert.ToString(dr["Paterno"]);
                ap.Materno = Convert.ToString(dr["Materno"]);
                ap.NombreCompleto = string.Format("{0} {1} {2}", ap.Nombres, ap.Paterno, ap.Materno);
                ap.FechaNacimiento = string.IsNullOrEmpty(dr["FechaNacimiento"].ToString())? DateTime.Now: Convert.ToDateTime(dr["FechaNacimiento"]);
                ap.Sexo = dr.Table.Columns.Contains("Sexo") ? Convert.ToString(dr["Sexo"]): "";
                ap.DocumentoIdentidad = dr.Table.Columns.Contains("DocumentoIdentidad")? Convert.ToString(dr["DocumentoIdentidad"]): "";
                ap.Extension = dr.Table.Columns.Contains("Extension") ? Convert.ToString(dr["Extension"]): "";
                ap.ParametroTipoSangreId = dr.Table.Columns.Contains("ParametroTipoSangreId")? Convert.ToInt32(dr["ParametroTipoSangreId"]is DBNull?0:dr["ParametroTipoSangreId"]) : 0;
               

            }
            return ap;
        }

        private List<SqlParameter> LoadFullParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Nombres", Nombres));
            ps.Add(new SqlParameter("Paterno", Paterno));
            ps.Add(new SqlParameter("Materno", Materno));
            ps.Add(new SqlParameter("FechaNacimiento", FechaNacimiento));
            ps.Add(new SqlParameter("Sexo", Sexo));
            ps.Add(new SqlParameter("DocumentoIdentidad", DocumentoIdentidad));
            ps.Add(new SqlParameter("ParametroTipoSangreId", ParametroTipoSangreId));
            ps.Add(new SqlParameter("EventoId", this.InscripcionEvento.EventoId));
            ps.Add(new SqlParameter("DelegacionId", this.InscripcionEvento.DelegacionId));
            ps.Add(new SqlParameter("RepresentacionId", this.InscripcionEvento.RepresentacionId));
            ps.Add(new SqlParameter("RolId", InscripcionEvento.RolId));
            ps.Add(new SqlParameter("Grado", this.InscripcionEvento.Grado));
            ps.Add(new SqlParameter("Talla", this.InscripcionEvento.Talla));
            ps.Add(new SqlParameter("Peso", InscripcionEvento.Peso));
            ps.Add(new SqlParameter("Estatura", InscripcionEvento.Estatura));
            ps.Add(new SqlParameter("Edad", InscripcionEvento.Edad));
            ps.Add(new SqlParameter("Codigo", InscripcionEvento.Codigo));
            ps.Add(new SqlParameter("DeporteId", InscripcionEvento.DeporteId));
            ps.Add(new SqlParameter("PruebaId", InscripcionEvento.PruebaId));
            ps.Add(new SqlParameter("ParametroRamaId", InscripcionEvento.ParametroRamaId));
            ps.Add(new SqlParameter("EsIndividual", this.InscripcionEvento.PruebaEvento.EsIndividual));
            ps.Add(new SqlParameter("EquipoId", this.InscripcionEvento.Competidor.EquipoId));
            ps.Add(new SqlParameter("Posicion", this.InscripcionEvento.Competidor.Posicion));
            ps.Add(new SqlParameter("MarcaTiempoInicial", this.InscripcionEvento.Competidor.MarcaTiempoInicial));
            return ps;
        }

        private List<SqlParameter> LoadParametersInsPersonaEvento()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PersonaId", PersonaId));
            ps.Add(new SqlParameter("EventoId", this.InscripcionEvento.EventoId));
            ps.Add(new SqlParameter("DelegacionId", this.InscripcionEvento.DelegacionId));
            ps.Add(new SqlParameter("RepresentacionId", this.InscripcionEvento.RepresentacionId));
            ps.Add(new SqlParameter("RolId", InscripcionEvento.RolId));
            ps.Add(new SqlParameter("Grado", this.InscripcionEvento.Grado));
            ps.Add(new SqlParameter("Talla", this.InscripcionEvento.Talla));
            ps.Add(new SqlParameter("Peso", InscripcionEvento.Peso));
            ps.Add(new SqlParameter("Estatura", InscripcionEvento.Estatura));
            ps.Add(new SqlParameter("Edad", InscripcionEvento.Edad));
            ps.Add(new SqlParameter("Codigo", InscripcionEvento.Codigo));
            ps.Add(new SqlParameter("DeporteId", InscripcionEvento.DeporteId));
            ps.Add(new SqlParameter("PruebaId", InscripcionEvento.PruebaId));
            ps.Add(new SqlParameter("ParametroRamaId", InscripcionEvento.ParametroRamaId));
            ps.Add(new SqlParameter("EsIndividual", this.InscripcionEvento.PruebaEvento.EsIndividual));
            ps.Add(new SqlParameter("EquipoId", this.InscripcionEvento.Competidor.EquipoId));
            ps.Add(new SqlParameter("Posicion", this.InscripcionEvento.Competidor.Posicion));
            ps.Add(new SqlParameter("MarcaTiempoInicial", this.InscripcionEvento.Competidor.MarcaTiempoInicial));
            ps.Add(new SqlParameter("ParametroTipoSangreId", this.ParametroTipoSangreId));
            return ps;
        }

        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure(procedureName, ps);
            if (dt.Rows.Count > 0)
            {
                PersonaId = Convert.ToInt32(dt.Rows[0][0]);
            }
            return (PersonaId > 0);
        }

        private void SaveFotoPersona()
        {
            string path = ConfigurationManager.AppSettings["ApplicationResources"];
            path = string.Format("{0}Images\\erpDeportes\\{1}.png", path, PersonaId);
            string[] datosfoto = photo.Split(',');
            byte[] imageBytes = Convert.FromBase64String(datosfoto[1]);
            Image image = Image.FromStream(new MemoryStream(imageBytes));

            image.Save(path, ImageFormat.Png);
            image.Dispose();
        }
        #endregion
    }

}
