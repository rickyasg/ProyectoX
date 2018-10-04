using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class Resources
    {
        public string Nombre { get; set; }
        public string Extencion { get; set; }
        public string Contenido { get; set; }

        public static List<Resources> GetReources()
        {
            List<Resources> lrs = new List<Resources>();
            DirectoryInfo di = new DirectoryInfo(@"C:\HammerResources\Images\erpDeportes");
            
            foreach (var fi in di.GetFiles())
            {
                Resources rs = new Resources();
                rs.Nombre = fi.Name;
                rs.Extencion = fi.Extension;
                rs.Contenido = FileToString(fi.FullName);
                lrs.Add(rs);
            }
            return lrs;

        }
        public static string FileToString(string file)
        {
            string contenido = string.Empty;
            if (File.Exists(file))
            {
                byte[] fileData = File.ReadAllBytes(file);
                contenido = Convert.ToBase64String(fileData);
            }
            return contenido;
        }
    }
}
