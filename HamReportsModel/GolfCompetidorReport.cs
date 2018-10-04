using HamCommon;
using iTextSharp.text;
using iTextSharp.text.pdf;
using erpReports.pdfResources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HamReportsModel.pdfResources;
using cnsReports.pdfResources;
using HamDataModel;

namespace HamReportsModel
{
    public enum HoyoPar
    {
        Hoyo = 1,
        Vuelta = 2,
        Total = 3
    }

    public class GolfCompetidorReport
    {
        private static Document documentPdf;
        private static string pathResource = string.Empty;//Global.ApplicationResources;
        private static string fileName = string.Empty;
        private static string path = "";
        private static string pathImage = string.Empty;
        //private static Usuario user = (Usuario)HttpContext.Current.Session["Usuario"];
        //private static CultureInfo cultureInfo = erpUtils.StringUtils.GetCultureInfo();
        //public static DataTable _cabecera;
        //public static DataTable _total;

        public GolfCompetidorReport()
        {

        }

        public static string ReporteResultadosCompetidor(DataTable dtDatosCompetidor, int eventoid, string categoriaName, string jornadasIds, int personaId, string pathSendet)
        {
            try
            {
                pathResource = pathSendet;
                fileName = string.Format("FinalesGolf=){0:yyMMdd_HHmmss}.pdf", DateTime.Now);
                path = string.Format(@"{0}\Reportes\{1}", pathResource, fileName);
                pathImage = string.Format(@"{0}\Images\", pathResource);
                DataTable dt = EventoDeportivo.GetEventoName(eventoid);
                string descEvento = string.Empty;
                string lugarEvento = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    descEvento = dt.Rows[0]["Nombre"].ToString();
                    lugarEvento = dt.Rows[0]["Ubicacion"].ToString();
                }

                SetHead(categoriaName, descEvento, lugarEvento, eventoid);
                SetBody(dtDatosCompetidor, descEvento, jornadasIds, personaId);
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
        
        public static string ReporteJornadaInscritos(DataTable dtInscritos, string pathSendet, int eventoid,int categoriaId, int jornadaId)
        {
            try
            {

                pathResource = pathSendet;
                fileName = string.Format("Jornadas=){0:yyMMdd_HHmmss}.pdf", DateTime.Now);
                path = string.Format(@"{0}\Reportes\{1}", pathResource, fileName);
                pathImage = string.Format(@"{0}\Images\", pathResource);
                DataTable dt = EventoDeportivo.GetEventoName(eventoid);
               
               

                HeaderGolf header = new HeaderGolf();
                header.Titulo = dt.Rows.Count > 0 ? dt.Rows[0]["Nombre"].ToString().ToUpper() : "";
                header.TituloIdioma = "";
                header.SubTitulo = dt.Rows.Count > 0 ? dt.Rows[0]["Ubicacion"].ToString().ToUpper() : "";
                header.Categoria = categoriaId == 0 ? "Todos" : GolfCategoria.GetGolCategoria(categoriaId).Descripcion;
                header.Fecha = GolfJornada.GetFechasJornadas(eventoid);
                var jornada = GolfJornada.GetGolfJornada(jornadaId);
                header.Jornada = jornadaId==0? "Todos" : jornada.Descripcion;
                
                SetHead(header);
                //dtInscritos.Columns.Remove("PersonaId");

                 SetBody(dtInscritos, header.Titulo,jornada.Descripcion,jornada.Fecha?.ToString("dd MMM yyyy"));
                dt.Dispose();
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
        private static void SetHead(HeaderGolf header)
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
            header.Deporte = "golf";
            header.HasLeyenda = false;
            header.User = "";// user.Username;
            header.NombreReporte = "Resultados Finales.";
            header.LogoDerecha = Image.GetInstance(string.Format(@"{0}\Golf\{1}", pathImage, "golf.png"));
            header.LogoIzquierda = Image.GetInstance(string.Format(@"{0}\Golf\{1}", pathImage, "Federacion.png"));
            header.LogoAbajoDerecha = Image.GetInstance(string.Format(@"{0}\Hammer\{1}", pathImage, "marcaDoble.png"));
            header.LogoAbajoIzquierda = Image.GetInstance(string.Format(@"{0}\Hammer\{1}", pathImage, "hammerLogoH.png"));
            
            
            header.leyendas = null;

            writer.PageEvent = header;
            documentPdf.Open();

        }
        private static void SetBody(DataTable datos,string descEvento,string jornada,string fecha)
        {
            PdfPTable body = new PdfPTable(new float[] { (float)1.5, 6, 6, 5, 5 });
            body.WidthPercentage = 100;
            body.AddCell(DrawTable.DrawCell(descEvento, 14, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell(string.Format("{0} , {1:dd MMM yyyy}", jornada, fecha), 12, CellBorder.NONE, CellAlignment.Center, 5, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Listado de Salidas y Cuartetos", 10, CellBorder.NONE, CellAlignment.Center, 5, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("\n", 10, CellBorder.NONE, CellAlignment.Center, 5, CellFontStyle.Bold));

            body.AddCell(DrawTable.DrawCellHeader("Salida", 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Jugador 1 (HCP)", 8, CellBorder.NONE, CellAlignment.Left, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Jugador 2 (HCP)", 8, CellBorder.NONE, CellAlignment.Left, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Jugador 3 (HCP)", 8, CellBorder.NONE, CellAlignment.Left, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Jugador 4 (HCP)", 8, CellBorder.NONE, CellAlignment.Left, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCell("\n", 14, CellBorder.NONE, CellAlignment.Center, 5, CellFontStyle.Bold));
            body.HeaderRows=5;
            foreach (DataRow rows in datos.Rows)
            {
                body.AddCell(DrawTable.DrawCell(rows["Grupo"].ToString(), 7, CellBorder.BOTTOM, CellAlignment.Center,  CellFontStyle.Normal));
                body.AddCell(DrawTable.DrawCell(rows["1"].ToString(), 7, CellBorder.BOTTOM, CellAlignment.Left, CellFontStyle.Normal));
                body.AddCell(DrawTable.DrawCell(rows["2"].ToString(), 7, CellBorder.BOTTOM, CellAlignment.Left,  CellFontStyle.Normal));
                body.AddCell(DrawTable.DrawCell(rows["3"].ToString(), 7, CellBorder.BOTTOM, CellAlignment.Left,  CellFontStyle.Normal));
                body.AddCell(DrawTable.DrawCell(rows["4"].ToString(), 7, CellBorder.BOTTOM, CellAlignment.Left, CellFontStyle.Normal));
            }
            
            documentPdf.Add(body);
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
            documentPdf.SetPageSize(PageSize.LETTER);
            documentPdf.SetMargins(marginLeft, marginRight, marginTop, marginBottom);

            PdfWriter writer = PdfWriter.GetInstance(documentPdf, new FileStream(path, FileMode.Create));

            HeaderGolf header = new HeaderGolf();
            header.Titulo = lugarEvento;
            header.TituloIdioma = "Casa de campo COCHABAMBA";
            header.SubTitulo = descEvento;
            header.Deporte = "golf";
            header.HasLeyenda = true;

            header.Jornada = "todas";
            header.Categoria = categoria;
            header.User = "";// user.Username;
            header.NombreReporte = "Resultados Finales.";
            header.LogoDerecha = Image.GetInstance(string.Format(@"{0}\Golf\{1}", pathImage, "golf.png"));
            header.LogoIzquierda = Image.GetInstance(string.Format(@"{0}\Golf\{1}", pathImage, "Federacion.png"));
            header.LogoAbajoDerecha = Image.GetInstance(string.Format(@"{0}\Hammer\{1}", pathImage, "marcaDoble.png"));
            header.LogoAbajoIzquierda = Image.GetInstance(string.Format(@"{0}\Hammer\{1}", pathImage, "hammerLogoH.png"));
            header.Fecha = GolfJornada.GetFechasJornadas(eventoid);

            PdfPTable leyen = new PdfPTable(new float[] { 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1 });
            leyen.AddCell(DrawTable.DrawCell("Leyenda", 6, CellBorder.NONE, CellAlignment.Left, 14, CellFontStyle.Bold));
            leyen.AddCell(DrawTable.DrawCellHeader("Hoyo en Uno", 5, CellBorder.UNDEFINED, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
            leyen.AddCell(DrawTable.DrawCellHeader(string.Empty, 5, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.YELLOW));
            leyen.AddCell(DrawTable.DrawCellHeader("Albatros", 5, CellBorder.UNDEFINED, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
            leyen.AddCell(DrawTable.DrawCellHeader(string.Empty, 5, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, new BaseColor(192, 119, 160)));
            leyen.AddCell(DrawTable.DrawCellHeader("Eagle", 5, CellBorder.UNDEFINED, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
            leyen.AddCell(DrawTable.DrawCellHeader(string.Empty, 5, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, new BaseColor(248, 177, 17)));
            leyen.AddCell(DrawTable.DrawCellHeader("Birdie", 5, CellBorder.UNDEFINED, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
            leyen.AddCell(DrawTable.DrawCellHeader(string.Empty, 5, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, new BaseColor(35, 190, 82)));
            leyen.AddCell(DrawTable.DrawCellHeader("PAR", 5, CellBorder.UNDEFINED, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
            leyen.AddCell(DrawTable.DrawCellHeader(string.Empty, 5, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
            leyen.AddCell(DrawTable.DrawCellHeader("Bogey", 5, CellBorder.UNDEFINED, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
            leyen.AddCell(DrawTable.DrawCellHeader(string.Empty, 5, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, new BaseColor(92, 119, 229)));
            leyen.AddCell(DrawTable.DrawCellHeader("Doble Bogey o más", 5, CellBorder.UNDEFINED, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
            leyen.AddCell(DrawTable.DrawCellHeader(string.Empty, 5, CellBorder.UNDEFINED, CellAlignment.Right, CellAlignment.Buttom, CellFontStyle.Normal, new BaseColor(237, 62, 48)));
            header.leyendas = leyen;

            writer.PageEvent = header;
            documentPdf.Open();
        }

        private static void SetBody(DataTable datosCompetidor, string descEvento, string jornadasIds, int personaId)
        {
            PdfPTable body = new PdfPTable(new float[] { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            body.WidthPercentage = 100;

            body.AddCell(DrawTable.DrawCell(descEvento, 14, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Resultado del Competidor", 10, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("\n", 10, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
            Image imgDir;
            string writepath = string.Format("{0}Images/erpDeportes/{1}.jpg", pathResource, personaId);
            if (File.Exists(writepath))
            {
                imgDir = Image.GetInstance(Path.Combine(HttpContext.Current.Server.MapPath("/"), @writepath));
            }
            else
            {
                imgDir = Image.GetInstance(string.Format("{0}Images/erpDeportes/User.png", pathResource));
            }

            imgDir.ScaleToFit(115f, 120f);
            PdfPCell cellImg = new PdfPCell(imgDir);
            cellImg.Border = PdfPCell.NO_BORDER;
            //cellImg.PaddingTop = 10;
            cellImg.Colspan = 6;
            cellImg.Rowspan = 9;
            cellImg.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            body.AddCell(cellImg);

            body.AddCell(DrawTable.DrawCell("Nombre :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell(datosCompetidor.Rows[0]["Nombres"].ToString(), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Paterno  :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell(datosCompetidor.Rows[0]["Paterno"].ToString(), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Materno  :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell(datosCompetidor.Rows[0]["Materno"].ToString(), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Fecha de Nacimiento :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            DateTime? fechaAuxi = string.IsNullOrEmpty(datosCompetidor.Rows[0]["FechaNacimiento"].ToString()) ? (DateTime?)null : Convert.ToDateTime(datosCompetidor.Rows[0]["FechaNacimiento"]);
            body.AddCell(DrawTable.DrawCell(fechaAuxi == null ? "" : string.Format("{0:dd/MM/yyyy}", fechaAuxi), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("C.I. :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell(datosCompetidor.Rows[0]["DocumentoIdentidad"].ToString(), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Sexo  :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell(datosCompetidor.Rows[0]["Sexo"].ToString(), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Handicap  :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            DataTable dtAuxi = GolfCompetidor.GetHCPporciento(Convert.ToInt32(datosCompetidor.Rows[0]["CompetidorId"]));
            int hcpPorciento = 0;
            if (dtAuxi.Rows.Count > 0)
            {
                hcpPorciento = Convert.ToInt32(dtAuxi.Rows[0][0]);
            }
            body.AddCell(DrawTable.DrawCell(string.Format("{0} - {1} (80%)", datosCompetidor.Rows[0]["Handicap"], hcpPorciento), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Categoria  :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell(datosCompetidor.Rows[0]["Descripcion"].ToString(), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("Club  :", 8, CellBorder.NONE, CellAlignment.Right, 4, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell(datosCompetidor.Rows[0]["Club"].ToString(), 8, CellBorder.NONE, CellAlignment.Left, 9, CellFontStyle.Bold));
            DataTable dt = new DataTable();
            string[] jIDs = jornadasIds.Split(',');
            int nroJor = 1;
            int nrorow = 0;
            bool flag = false;
            foreach (string jorId in jIDs)
            {
                DataTable dtPares = GolfHoyoPar.GetGolfHoyoPar(Convert.ToInt32(HoyoPar.Hoyo));
                body.AddCell(DrawTable.DrawCell("\n", 14, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
                dt = GolfCompetidor.GetResultadoCompetidor(Convert.ToInt32(jorId), personaId);
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.ColumnName == "Detalle")
                    {
                        body.AddCell(DrawTable.DrawCellHeader(string.Format("Dia {0}", nroJor), 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                    }
                    else
                    {
                        body.AddCell(DrawTable.DrawCellHeader(dc.ColumnName, 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                    }
                }

                body.AddCell(DrawTable.DrawCell("\n", 14, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));

                foreach (DataRow rows in dt.Rows)
                {
                    nrorow = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (dc.ColumnName == "Detalle")
                        {
                            body.AddCell(DrawTable.DrawCellHeader(rows[dc.ColumnName].ToString(), 7, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Normal));
                        }
                        else
                        {
                            if (flag)
                            {
                                body.AddCell(DrawTable.DrawCellHeader(rows[dc.ColumnName].ToString(), 7, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Normal, GetColorCell(dtPares, rows[dc.ColumnName].ToString(), nrorow)));
                            }
                            else
                            {
                                body.AddCell(DrawTable.DrawCellHeader(rows[dc.ColumnName].ToString(), 7, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Normal));
                            }
                            nrorow++;
                        }
                    }
                    flag = flag == false;
                }
                nroJor++;
                flag = false;

            }
            documentPdf.Add(body);
        }

        private static BaseColor GetColorCell(DataTable hoyos, string data, int row)
        {
            BaseColor color = BaseColor.WHITE;
            if (!string.IsNullOrEmpty(data))
            {
                int birdie = Convert.ToInt32(hoyos.Rows[row]["Par"]) - 1;
                int eagle = Convert.ToInt32(hoyos.Rows[row]["Par"]) - 2;
                int albatros = Convert.ToInt32(hoyos.Rows[row]["Par"]) - 3;
                int bogey = Convert.ToInt32(hoyos.Rows[row]["Par"]) + 1;
                int dBogey = Convert.ToInt32(hoyos.Rows[row]["Par"]) + 2;

                int value = Convert.ToInt32(data);
                if (value == 1)
                    color = BaseColor.YELLOW;
                else if (value == birdie)
                    color = new BaseColor(35, 190, 82);
                else if (value == bogey)
                    color = new BaseColor(92, 119, 229);
                else if (value == eagle)
                    color = new BaseColor(248, 177, 17);
                else if (value >= dBogey)
                    color = new BaseColor(237, 62, 48);
                else if (value == albatros)
                    color = new BaseColor(192, 119, 160);
            }
            return color;
        }
        private static void SetFooter()
        {
            documentPdf.Close();
        }
    }
}
