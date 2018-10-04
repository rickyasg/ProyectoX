using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamSecurityModel
{
    public class SecUsuario
    {
        public int UsuarioId { get; set; }
        /* Old Strunct**/
        public string Usuario { get; set; }
        
        public Nullable<int> OficinaId { get; set; }
        public bool IsActivo { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        /**/

        public int UserId { get; set; }
        public string User { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public Nullable<int> PersonId { get; set; }
        public DateTime Register { get; set; }


        public List<SecMenuItem> TOC { get; set; }
        public string TOCJson { get; set; }



        private const string Entity = "erp.Users";

        #region Metodos DML

        public bool Save()
        {
            bool result = false;
            result = (UsuarioId > 0) ? Insert() : Update();
            return result;
        }

        // actualizar Usuarios
        public bool Guardar  ()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("UsuarioId",UsuarioId));
            ps.Add(new SqlParameter("Usuario", Username));
            ps.Add(new SqlParameter("contraseña", DBSecurity.Encriptar(Password)));
            ps.Add(new SqlParameter("IsActivo", IsActivo));     

            db.ExecStoreProcedure("[erp].[pUpUsuarios]", ps);
            return (db.RowAffected > 0);
        }
        
        public bool ActualizarPassword()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Password", Password));
            ps.Add(new SqlParameter("UsuarioId", UsuarioId));

            db.ExecStoreProcedure("erp.pUpPassword", ps);
            return (db.RowAffected > 0);

        }
        public bool AddUsuario()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Username", Username));
            ps.Add(new SqlParameter("Password", Password));
            ps.Add(new SqlParameter("OficinaId", OficinaId));
            ps.Add(new SqlParameter("IsActivo", IsActivo));
            ps.Add(new SqlParameter("PersonaId", PersonaId));

            db.ExecStoreProcedure("dbo.pInsUsuarios", ps);
            return (db.RowAffected > 0);
        }
        private bool Insert()
        {
            return ExecuteTransaction("pSMInsertUsuario");
        }

        private bool Update()
        {
            return ExecuteTransaction("pSMUpdateUsuario");
        }

        public bool Delete(int categoriaId)
        {
            return ExecuteTransaction("pSMDeleteUsuario");
        }
        //eliminar usuario
        public bool DeleteU(int usuarioId)
        {

            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("usuarioId", usuarioId));
            db.ExecStoreProcedure("[erp].[pDelUsuario]", ps);
            return (db.RowAffected > 0);
        }
        //para obtener en editar
        public static SecUsuario GetUser(int usuarioId)
        {
            return Parse(usuarioId);
        }

        private bool ExecuteTransaction(string procedureName)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Usuario", Usuario));
            ps.Add(new SqlParameter("Password", Password));
            ps.Add(new SqlParameter("OficinaId", OficinaId));
            ps.Add(new SqlParameter("IsActivo", IsActivo));
            ps.Add(new SqlParameter("PersonaId", PersonaId));

            if (procedureName == "pSMInsertUsuario")
            {
                db.ExecStoreProcedure(procedureName, ps);
            }

            if ((procedureName == "pSMUpdateUsuario") ||
                (procedureName == "pSMDeleteUsuario"))
            {
                ps.Add(new SqlParameter("UsuarioId", UsuarioId));
                db.ExecStoreProcedure(procedureName, ps);
            }

            return (db.RowAffected > 0);
        }
        #endregion

        #region Metodos GET
        public static SecUsuario GetSecUsuario(int userId)
        {
            return Parse(userId);
        }

        public static SecUsuario GetSecUsuario(string usuario, string password)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("User", usuario));
            //ps.Add(new SqlParameter("Usuario", usuario));
            ps.Add(new SqlParameter("Password", password));
            DataTable dt = db.GetStoreProcedure("[erp].[pGetUser]", ps);
            //DataTable dt = db.GetStoreProcedure("erp.pSMGetUsuario", ps);
            if (dt.Rows.Count > 0)
            {
                return ConvertToUsuario(dt.Rows[0]);
            }
            return new SecUsuario();
        }

        public static DataTable GetSecUsuarios()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            return db.GetStoreProcedure("[pSMGetUsuarios]", ps);
        }
        public static DataTable GetUsuariosRegistrados()
        {
            DBTransaction db = new DBTransaction();
            //var vista = db.GetData("select upper(substring(Usuario,1,1))+ replace(lower(substring (Usuario,2,DATALENGTH(Usuario))),'.',' ')" +
            //    " as Nombre,* from dbo.Usuarios order by Usuario");
            //return vista.Table;
            return db.GetDataView("dbo.Usuarios");
        }
        #endregion



        #region Private
        private static SecUsuario ConvertToUsuario(DataRow dr)
        {
            SecUsuario u = new SecUsuario();
            if (dr != null)
            {
                u.UserId = Convert.ToInt32(dr["UserId"]);
                u.User = Convert.ToString(dr["User"]);
                u.Password = Convert.ToString(dr["Password"]);
                u.PersonId = Convert.ToInt32(dr["PersonId"]);
                u.Register = Convert.ToDateTime(dr["Register"]);
                u.Username = Convert.ToString(dr["UserName"]);
                // u.OficinaId = 0;//Convert.ToInt32(dr["OficinaId"]);
                // u.IsActivo = true;// Convert.ToBoolean(dr["IsActivo"]);
                //u.PersonaId = 10;// Convert.ToInt32(dr["PersonaId"]);
                //  u.UsuarioId = 5;// Convert.ToInt32(dr["UsuarioId"]);
                // u.Usuario = "Nombre Usuario";// Convert.ToString(dr["Usuario"]);
                //u.Password = Convert.ToString(dr["Password"]);
                //u/.PersonaId = 10;// Convert.ToInt32(dr["PersonaId"]);
                //u.FechaRegistro = Convert.ToDateTime(dr["Register"]); //Convert.ToDateTime(dr["FechaRegistro"]);
            }
            return u;
        }

        private static SecUsuario Parse(int userId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(UserId), userId);
            DataRow dr = db.GetDataRow(Entity, fields);
            SecUsuario u = ConvertToUsuario(dr);
            SecTOC t = new SecTOC("");
            u.TOC = t.MenuItems;
            u.TOCJson = t.TOCJson;
            return u;
        }

        public string GetFotoPerfil(string path)
        {
            string imageName = string.Format("{0}Images\\erpDeportes\\{1}.png", path, this.PersonaId);
            if (!File.Exists(imageName))
            {
                imageName = string.Format("{0}Images\\erpDeportes\\user.png", path);
            }
            return string.Format("data:image/jpeg;base64,{0}", ImageToString(imageName));
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
