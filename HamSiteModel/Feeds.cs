using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace HamSiteModel
{
   public class Feeds
    {

        public static DataTable GetNoticias(int limite, int item_Id = -1)
        {

            DataTable tabla = new DataTable();
            tabla.Columns.Add("title", typeof(string));
            tabla.Columns.Add("description", typeof(string));
            tabla.Columns.Add("link", typeof(string));
            tabla.Columns.Add("pubDate", typeof(string));
            tabla.Columns.Add("item_Id", typeof(int));
            tabla.Columns.Add("url", typeof(string));
            try
            {
                XDocument feedXML = XDocument.Load(ConfigurationManager.AppSettings["UrlRSS"]);
                DataSet ds = new DataSet();

                var reader = feedXML.CreateReader(ReaderOptions.OmitDuplicateNamespaces);
                ds.ReadXml(reader);
                var items = ds.Tables["item"];
                var imgs = ds.Tables["enclosure"];

                var result = from dataRows1 in items.AsEnumerable().Take(limite)
                             join dataRows2 in imgs.AsEnumerable().Take(limite)
                             on dataRows1.Field<int>("item_Id") equals dataRows2.Field<int>("item_Id") into lj
                             from r in lj.DefaultIfEmpty()
                             select tabla.LoadDataRow(new object[]
                             {
                dataRows1.Field<string>("title"),
                dataRows1.Field<string>("description"),
                dataRows1.Field<string>("link"),
                dataRows1.Field<string>("pubDate"),
                dataRows1.Field<int>("item_Id"),


                r == null ? "" : r.Field<string>("url")
                              }, false);
                tabla = result.CopyToDataTable();
                if (item_Id > -1)
                    tabla = tabla.Select("item_Id=" + item_Id).CopyToDataTable();
            }
            catch { tabla = new DataTable(); }
            return tabla;
        }

        public string getTexto(string url)
        {
            try
            {
                XDocument feedXML = XDocument.Load(url);
                return feedXML.Element("data").Value;
            }
            catch
            {
                return "";
            }
        }
    }
}
