using HamDataTransactions;
using HamSecurityModel;
using HamServicesSecurity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace HamServicesGolf.Controllers
{
    public class SecurityController : ApiController
    {
        #region Servicios Post
        [HttpPost]
        public bool SaveUsuario([FromBody] SecUsuario usuario)
        {
            return usuario.Save();
        }
        [HttpPost]
        public bool SaveNewPass(int id, string password)
        {
            var usr = GetUsuario(id);
            var pass = DBSecurity.Encriptar(password);
            usr.Password = pass;
            return usr.ActualizarPassword();
        }
        [HttpPost]
        public bool SaveNewPass([FromBody] SecUsuario usuario)
        {
            usuario.Password = DBSecurity.Encriptar(usuario.Password);
            return usuario.ActualizarPassword();
        }
        [HttpPost]
        public bool AddUsuario([FromBody] SecUsuario usuario)
        {
            usuario.Password = DBSecurity.Encriptar(usuario.Password);
            usuario.IsActivo = true;
            usuario.Username = usuario.Usuario;

            return usuario.AddUsuario();
        }

        [HttpPost]
        public bool AddUsuarioPrivilegio(string usu, string password)
        {
            SecUsuario usuario = new SecUsuario();
            usuario.Password = DBSecurity.Encriptar(password);
            usuario.IsActivo = true;
            usuario.Username = usuario.Usuario;

            return usuario.AddUsuario();
        }
        [HttpPost]
        public bool setJsonPrivilegioUsuario([FromBody]SecUsuario texto)
        {

            SecUsuario usuario = SecUsuario.GetSecUsuario(texto.UsuarioId);
            string path = string.Format(@"{0}TOCs\{1}.json", WebApiApplication.ApplicationResources, usuario.Usuario);
            dynamic parsedJson = JsonConvert.DeserializeObject(texto.TOCJson.Replace("}{", "},{"));
            var json = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

            File.WriteAllText(path, json);

            return true;

        }
        #endregion

        #region Servicios Delete
        [HttpDelete]
        public bool DeleteUsuario(int usuarioId)
        {
            SecUsuario user = new SecUsuario();
            return user.Delete(usuarioId);
        }
        #endregion

        #region Servios Get
        [HttpGet]
        public bool verificarClave(int id, string clave)
        {
            try
            {
                var usr = GetUsuario(id);
                var pass = DBSecurity.Encriptar(clave);

                return pass == usr.Password;
            }
            catch
            {
                return false;
            }
        }
        //obtener usuarios para editar 
        public Object GetUser(int usuarioId)
        {
            Datos data = new Datos();
            data.data = SecUsuario.GetUser(usuarioId);
            return data;
        }
        //editar usuarios
        [HttpPost]
        public bool upUser([FromBody] SecUsuario usuario)
        {
            return usuario.Guardar();
        }
        //eliminar usuario
        public bool DeleteUser(int usuarioId)
        {
            SecUsuario usr = new SecUsuario();
            return usr.DeleteU(usuarioId);
        }
        [HttpGet]
        public SecUsuario GetUsuario(int usuarioId)
        {
            return SecUsuario.GetSecUsuario(usuarioId);
        }
        [HttpGet]
        public DataTable GetUsuariosRegistrados()
        {
            return SecUsuario.GetUsuariosRegistrados();
        }
        [HttpGet]
        public SecUsuario GetUsuarioByPassword(string usuario, string password)
        {
            Console.Write(password);
            return SecUsuario.GetSecUsuario(usuario, DBSecurity.Encriptar(password));
        }

        [HttpGet]
        public DataTable GetUsuarios()
        {
            return SecUsuario.GetSecUsuarios();
        }

        [HttpGet]
        public string GetListTocs(int filename)
        {


            SecUsuario usuario = SecUsuario.GetSecUsuario(filename);
            string path = string.Format(@"{0}TOCs\{1}.json", WebApiApplication.ApplicationResources, usuario.User);
            SecTOC misTocs = new SecTOC(path);

            string temp = misTocs.TOCJson;
            return temp;

        }

        [HttpGet]
        public string GetStringTocs(string filename)
        {
            SecTOC misTocs = new SecTOC(filename);
            return misTocs.TOCJson;
        }

        [HttpGet]
        public string GetMasterRelease()
        {
            string path = string.Format(@"{0}HamSecurityModel\{1}.json", WebApiApplication.ApplicationMaster, "MasterRelease2");
            SecTOC misTocs = new SecTOC(path);
            string temp = misTocs.TOCJson.Replace("items", "children");
            return temp;
        }

        #endregion

        [HttpGet]
        public string GetFotoPerfil(int usuarioId)
        {
            string path = WebApiApplication.ApplicationResources;
            SecUsuario usuario = SecUsuario.GetSecUsuario(usuarioId);
            return usuario.GetFotoPerfil(path);
        }


    }
    public class Datos
    {
        public Object data { get; set; }

        public Datos() { }
    }
}
