using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HamCommon
{
    public class AcrePersona
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
        public AcreInscripcionEvento PersonaInscrita { get; set; }

        private const string Entity = "Personas";
        #endregion

        #region DML
        public bool Save()
        {
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadParameters();
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

        public int SavePersonaInscrita()
        {
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadFullParameters();
            if (PersonaId == 0)
            {
                procedimiento = "acre.pInsPersonas";
            }
            else
            {
                procedimiento = "[Coleque Aqui Su Procedimiento de Update]";
                ps.Add(new SqlParameter("PersonaId", PersonaId));
            }

            ExecuteTransaction(procedimiento, ps);

            if (!string.IsNullOrEmpty(photo))
            {
                SaveFotoPersona();
            }
            return PersonaId;
        }

        private void SaveFotoPersona()
        {
            string path = ConfigurationManager.AppSettings["ApplicationResources"];
            path = string.Format("{0}Images\\erpDeportes\\{1}.png", path, PersonaId);
            string[] datosfoto = photo.Split(',');
            byte[] imageBytes = Convert.FromBase64String(datosfoto[1]);
            Image image = Image.FromStream(new MemoryStream(imageBytes));

            image.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            image.Dispose();
        }
        #endregion

        #region Metodos GET
        public static AcrePersona GetPersona(int personaId)
        {
            return Parse(personaId);
        }

        public static List<AcrePersona> GetPersonas()
        {
            List<AcrePersona> lap = new List<AcrePersona>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[Ingrese su vista Aqui]");
            foreach (DataRow dr in dt.Rows)
            {
                AcrePersona cp = ConvertToPersona(dr);
                lap.Add(cp);
            }
            return lap;
        }

        public static DataTable GetPersonaByCI(string ci)
        {
            DBTransaction db = new DBTransaction();
            return db.GetDataView(string.Format("[acre].[vAcreditacionDetallePersona]  where [DocIdentidad] = '{0}'", ci));
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
            DataTable dt = db.GetStoreProcedure("[acre].[pInscritosDelegacion]",ps);
            return dt;
        }
        #endregion

        #region Private menbers
        private static AcrePersona Parse(int personaId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(PersonaId), personaId);
            DataRow dr = db.GetDataRow(Entity, fields);
            AcrePersona cp = ConvertToPersona(dr);
            return cp;
        }

        private static AcrePersona ConvertToPersona(DataRow dr)
        {
            AcrePersona ap = new AcrePersona();
            if (dr != null)
            {
                ap.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                ap.Nombres = Convert.ToString(dr["Nombres"]);
                ap.Paterno = Convert.ToString(dr["Paterno"]);
                ap.Materno = Convert.ToString(dr["Materno"]);

                string fechaNaci = dr["FechaNacimiento"].ToString();
                if (string.IsNullOrEmpty(fechaNaci))
                {
                    ap.FechaNacimiento = DateTime.Now;
                }
                else
                {
                    ap.FechaNacimiento = Convert.ToDateTime(fechaNaci);
                }

                ap.Sexo = Convert.ToString(dr["Sexo"]);
                ap.DocumentoIdentidad = Convert.ToString(dr["DocumentoIdentidad"]);
                ap.Extension = Convert.ToString(dr["Extension"]);
                ap.ParametroTipoSangreId = Convert.ToInt32(dr["ParametroTipoSangreId"]);
            }
            return ap;
        }

        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Nombres", Nombres));
            ps.Add(new SqlParameter("Paterno", Paterno));
            ps.Add(new SqlParameter("Materno", Materno));
            ps.Add(new SqlParameter("FechaNacimiento", FechaNacimiento));
            ps.Add(new SqlParameter("Sexo", Sexo));
            ps.Add(new SqlParameter("DocumentoIdentidad", DocumentoIdentidad));
            ps.Add(new SqlParameter("Extension", Extension));
            ps.Add(new SqlParameter("ParametroTipoSangreId", ParametroTipoSangreId));
            return ps;
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

            ps.Add(new SqlParameter("EventoId", 1));
            ps.Add(new SqlParameter("DelegacionId", 1));
            ps.Add(new SqlParameter("RepresentacionId", 1));
            ps.Add(new SqlParameter("RolId", PersonaInscrita.RolId));
            ps.Add(new SqlParameter("Grado", ""));//PersonaInscrta.Grado
            ps.Add(new SqlParameter("Talla", ""));//PersonaInscrta.Talla
            ps.Add(new SqlParameter("Peso", PersonaInscrita.Peso));
            ps.Add(new SqlParameter("Estatura", PersonaInscrita.Estatura));
            ps.Add(new SqlParameter("Edad", PersonaInscrita.Edad));
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

        public static DataTable GetCredencialDatosPersonales(int personaId, int eventoId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PersonaId", personaId));
            ps.Add(new SqlParameter("EventoId", eventoId));
            return db.GetStoreProcedure("acre.pCredencialDatosPersonales", ps);
        }

        public static DataTable GetCredencialDatosPrivilegios(int personaId, int eventoId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PersonaId", personaId));
            ps.Add(new SqlParameter("EventoId", eventoId));
            return db.GetStoreProcedure("acre.pCredencialDatosPrivilegios", ps);
        }

        public static string GetFotoPersona(int personaId)
        {
            string path = ConfigurationManager.AppSettings["ApplicationResources"];
            path = string.Format("{0}Images\\erpDeportes\\{1}.png", path, personaId);
            if (!File.Exists(path))
            {
                path = string.Format("{0}Images\\erpDeportes\\user.png", path);
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
    }
}
