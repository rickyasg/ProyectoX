using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamCommon
{
    public class Deportista
    {
        #region Propiedades
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string CI { get; set; }
        public string Extension { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Titulo { get; set; }
        public string Rude { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Competidor Competdor { get; set; }
        public string Image { get; set; }
        public string Usuario { get; set; }
        public string Club { get; set; }
        #endregion

        #region DML
        public bool Save()
        {
            bool isInsert = false;
            string procedimiento;
            isInsert = this.PersonaId == 0;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps = LoadParameters();
            if (this.PersonaId == 0)
            {
                procedimiento = "[psetPersona]";
            }
            else
            {
                procedimiento = "[pUpPersona]";
                ps.Add(new SqlParameter("PersonaId", PersonaId));
            }
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure(procedimiento, ps);
            if (dt.Rows.Count > 0)
            {
                if (isInsert)
                {
                    this.PersonaId = Convert.ToInt32(dt.Rows[0]["Resultado"]);
                    this.Competdor.PersonaId = this.PersonaId;
                    this.Competdor.Save();
                }
                else
                {
                    Competidor com = Competidor.GetCompetidor(this.PersonaId);
                    this.Competdor.Gcompetidor.CompetidorId = com.CompetidorId;
                    this.Competdor.Gcompetidor.Update();
                }
            }
            return (dt.Rows.Count > 0);
        }

        public static bool Delete(int personaId)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PersonaId", personaId));
            return ExecuteTransaction("pDelPersona", ps);
        }

        public static string SaveImage(string base64, string imagename, string path)
        {
            string name = imagename;
            try
            {
                base64 = base64.Replace("data:image/png;base64,", "");
                base64 = base64.Replace("data:image/jpeg;base64,", "");
                byte[] imageBytes = Convert.FromBase64String(base64);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = System.Drawing.Image.FromStream(ms, true);

                //string path = ConfigurationManager.AppSettings["ApplicationResources"];
                string pathImage = string.Format("{0}Images/erpDeportes/{1}.jpg", path, imagename);

                if (File.Exists(pathImage))
                {
                    File.Delete(pathImage);
                }
                image.Save(path + "Images/erpDeportes/" + name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception)
            { }
            return name;
        }
        #endregion

        #region Metodos GET
        public static DataTable GetDeportistas()
        {
            DBTransaction db = new DBTransaction();
            return db.GetDataView("vPersonas");
        }

        public static Deportista GetDeportista(int personaId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(personaId), personaId);
            DataRow dr = db.GetDataRow("vPersonas", fields);
            return ConvertToDeportista(dr);
        }

        public static DataTable GetDeportistasFiltro(int eventoId, int disciplinaId)
        {
            DBTransaction db = new DBTransaction();
            string sql = string.Format("[golf].[vPersonas] {0}",
                eventoId == 0 ? string.Empty : string.Format("WHERE EventoDeportivoId={0} {1}",
                eventoId,
                disciplinaId == 0 ? string.Empty : string.Format("AND DisciplinaId={0}", disciplinaId)
                ));
            return db.GetDataView(sql);
        }
        public static DataTable GetDeportistaAcreditado(int personaId)
        {
            DBTransaction db = new DBTransaction();
            return db.GetDataView(string.Format("[fPersonaAcreditacion] ({0},1)", personaId));
        }
        #endregion

        #region Private Members
        private static Deportista ConvertToDeportista(DataRow dr)
        {
            Deportista de = new Deportista();
            if (dr != null)
            {
                de.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                de.Nombre = dr["Nombre"].ToString();
                de.Paterno = dr["Paterno"].ToString();
                de.Materno = dr["Materno"].ToString();
                de.CI = dr["DocumentoIdentidad"].ToString();
                de.Extension = dr["Extension"].ToString();
                string fechaNaci = dr["FechaNacimiento"].ToString();
                if (string.IsNullOrEmpty(fechaNaci))
                {
                    de.FechaNacimiento = DateTime.Now;
                }
                else
                {
                    de.FechaNacimiento = Convert.ToDateTime(fechaNaci);
                }

                de.Titulo = dr["Titulo"].ToString();
                de.Rude = string.Empty; //dr["Rude"].ToString();
                de.Sexo = dr["Sexo"].ToString();
                de.Club = dr["Club"].ToString();
            }
            return de;
        }

        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Nombre", Nombre));
            ps.Add(new SqlParameter("Gestion", Paterno));
            ps.Add(new SqlParameter("Ubicacion", Materno));
            ps.Add(new SqlParameter("FechaNacimiento", FechaNacimiento));
            ps.Add(new SqlParameter("Sexo", Sexo));
            ps.Add(new SqlParameter("CI", CI));
            ps.Add(new SqlParameter("Extension", Extension));
            return ps;
        }

        private static bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        #endregion
    }
}
