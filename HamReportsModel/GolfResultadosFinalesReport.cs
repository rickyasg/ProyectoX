using cnsReports.pdfResources;
using erpReports.pdfResources;
using HamCommon;
using HamDataModel;
using HamReportsModel.pdfResources;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HamReportsModel
{
    public class GolfResultadosFinalesReport
    {
        private static Document documentPdf;
        private static string pathResource = "C:\\HammerResources\\";
        private static string fileName = string.Format("FinalesGolf=){0:yyMMdd_HHmmss}.pdf", DateTime.Now);
        private static string path = string.Format(@"{0}\Reportes\{1}", pathResource, fileName);
        private static string pathImage = string.Empty;

        //private static string pathImage = ConfigurationManager.AppSettings["Images"];
        //private static Usuario user = (Usuario)HttpContext.Current.Session["Usuario"];
        //private static CultureInfo cultureInfo = erpUtils.StringUtils.GetCultureInfo();
        public static DataTable _cabecera;
        public static DataTable _total;

        public GolfResultadosFinalesReport()
        {

        }

        public static string ReporteResultadosFinales(DataTable dtResultados, int eventoid, string categoriaName, string pathSendet)
        {
            try
            {
                pathResource = pathSendet;
                pathImage = string.Format(@"{0}\Images\", pathResource);
                DataTable dt = EventoDeportivo.GetEventoName(eventoid);
                string descEvento = dt.Rows.Count>0?dt.Rows[0]["Nombre"].ToString():"";
                string lugarEvento = dt.Rows.Count > 0 ? dt.Rows[0]["Ubicacion"].ToString():"";
                
                SetHead(categoriaName, descEvento, lugarEvento, eventoid);

                dtResultados.Columns.Remove("CompetidorId");
                dtResultados.Columns.Remove("JornadaId");
                dtResultados.Columns.Remove("CategoriaId");
                dtResultados.Columns.Remove("Nombre");
                dtResultados.Columns.Remove("CompetidorJornadaId");
                SetBody(dtResultados, descEvento);
                return path;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                SetFooter();
            }
        }

        private static void SetHead(string categoria, string descEvento, string lugarEvento, int eventoid)
        {
            float legalMarginWidth = ItextUtils.CentimetersToPoints(33.02F);
            float legalMarginHeight = ItextUtils.CentimetersToPoints(21.59F);
            float marginLeft = ItextUtils.CentimetersToPoints(1);
            float marginRight = ItextUtils.CentimetersToPoints(1);
            float marginTop = ItextUtils.CentimetersToPoints(1);
            float marginBottom = ItextUtils.CentimetersToPoints(4);


            documentPdf = new Document();
            documentPdf.SetPageSize(PageSize.LETTER.Rotate());
            documentPdf.SetMargins(marginLeft, marginRight, marginTop, marginBottom);

            PdfWriter writer = PdfWriter.GetInstance(documentPdf, new FileStream(path, FileMode.Create));

            HeaderGolf header = new HeaderGolf();
            header.Titulo = lugarEvento;
            header.TituloIdioma = "Casa de campo COCHABAMBA";
            header.SubTitulo = descEvento;
            header.Deporte = "golf";
            header.HasLeyenda = false;

            header.Jornada = "todas";
            header.Categoria = categoria;
            header.User = "";// user.Username;
            header.NombreReporte = "Resultados Finales.";
            header.LogoDerecha = Image.GetInstance(string.Format(@"{0}\Golf\{1}", pathImage, "golf.png"));
            header.LogoIzquierda = Image.GetInstance(string.Format(@"{0}\Golf\{1}", pathImage, "Federacion.png"));
            header.LogoAbajoDerecha = Image.GetInstance(string.Format(@"{0}\Hammer\{1}", pathImage, "marcaDoble.png"));
            header.LogoAbajoIzquierda = Image.GetInstance(string.Format(@"{0}\Hammer\{1}", pathImage, "hammerLogoH.png"));
            header.Fecha = GolfJornada.GetFechasJornadas(eventoid);

            writer.PageEvent = header;
            documentPdf.Open();
        }

        private static void SetBody(DataTable dtresultado, string descEvento)
        {
            int nroColumnas = dtresultado.Columns.Count;
            float [] x = new float[nroColumnas];
            x[0] = 2;
            x[1] = 6;
            x[2] = 6;
            for (int i = 3; i < nroColumnas; i++)
            {
                x[i] = 2;
            }
            PdfPTable body = new PdfPTable(x);
            body.WidthPercentage = 100;

            body.AddCell(DrawTable.DrawCell(descEvento, 14, CellBorder.NONE, CellAlignment.Center, nroColumnas, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Resultado Finales", 10, CellBorder.NONE, CellAlignment.Center, nroColumnas, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("\n", 10, CellBorder.NONE, CellAlignment.Center, nroColumnas, CellFontStyle.Bold));

            foreach (DataColumn dc in dtresultado.Columns)
            {
                body.AddCell(DrawTable.DrawCellHeader(dc.ColumnName, 8, CellBorder.BOTTOM, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            }

            body.AddCell(DrawTable.DrawCell("\n", 14, CellBorder.NONE, CellAlignment.Center, nroColumnas, CellFontStyle.Bold));

            foreach (DataRow rows in dtresultado.Rows)
            {
                foreach (DataColumn dc in dtresultado.Columns)
                {
                    if (dc.ColumnName == "Score")
                    {
                        int score = Convert.ToInt32(rows[dc.ColumnName]);
                        if (score > 0)
                        {
                            body.AddCell(DrawTable.DrawCell(string.Format("+{0}", score), 7, CellBorder.BOTTOM, CellAlignment.Center,  CellFontStyle.Normal));
                        }
                        else
                        {
                            body.AddCell(DrawTable.DrawCell(rows[dc.ColumnName].ToString(), 7, CellBorder.BOTTOM, CellAlignment.Center,  CellFontStyle.Normal));
                        }
                    }
                    else
                    {
                        body.AddCell(DrawTable.DrawCell(rows[dc.ColumnName].ToString(), 7, CellBorder.BOTTOM, CellAlignment.Center,  CellFontStyle.Normal));
                    }
                }
            }
            body.HeaderRows = 5;
            documentPdf.Add(body);
        }
        private static void SetFooter()
        {
            documentPdf.Close();
        }
    }
}
