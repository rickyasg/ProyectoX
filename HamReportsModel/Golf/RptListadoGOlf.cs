
using cnsReports.pdfResources;
using erpReports.pdfResources;
using HamCommon;
using HamDataModel;
using HamDataTransactions;
using HamReportsModel.pdfResources;
using HamSecurityModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace HamReportsModel.Golf
{
    public class RptListadoGolf
    {
        private static Document documentPdf;
        public static string PathResource = string.Empty;
        private static string fileName = string.Empty;
        private static string path = string.Empty;
        private static string pathImage = string.Empty;
        public static SecUsuario user;
        private static CultureInfo cultureInfo = DBGlobalization.GetCultureInfo();
        public static DataTable _cabecera;
        public static DataTable _total;

        public RptListadoGolf()
        { }

        public static string ReporteListado(DataTable jugadores, DataTable hoyos, string jornada, string categoria, int eventoid, string pathResources)
        {
            try
            {
                PathResource = pathResources;
                fileName = string.Format("TimeSheet_{0:yyMMdd_HHmmss}.pdf", DateTime.Now);
                path = string.Format(@"{0}\Reportes\{1}", PathResource, fileName);
                pathImage = string.Format(@"{0}\Images\", PathResource);
                DataTable led = EventoDeportivo.GetEventoName(eventoid);
                string descEvento = string.Empty;
                string lugarEvento = string.Empty;
                if (led.Rows.Count > 0)
                {
                    descEvento = led.Rows[0]["Nombre"].ToString();
                    lugarEvento = led.Rows[0]["Ubicacion"].ToString();
                }
                //_cabecera = cabecera;
                SetHead(jornada, categoria, descEvento, lugarEvento, eventoid);
                SetBody(jugadores, hoyos, descEvento, jornada);
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

        private static void SetHead(string jornada, string categoria, string descEvento, string lugarEvento, int eventoId)
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
            //Segir buscando como cambiarl la funte de las letras de todo el doc
            //documentPdf

            PdfWriter writer = PdfWriter.GetInstance(documentPdf, new FileStream(path, FileMode.Create));

            HeaderGolf header = new HeaderGolf();
            header.Titulo = lugarEvento;
            header.TituloIdioma = "Casa de Campo Cochabamba";
            header.SubTitulo = descEvento;
            header.Deporte = "golf";
            header.HasLeyenda = true;

            header.Jornada = jornada;
            header.Categoria = categoria;
            header.User = "admin";
            header.NombreReporte = "ListadoEquipos";
            header.LogoDerecha = Image.GetInstance(string.Format(@"{0}\Golf\golf.png", pathImage));
            header.LogoIzquierda = Image.GetInstance(string.Format(@"{0}\Golf\Federacion.png", pathImage));
            header.LogoAbajoDerecha = Image.GetInstance(string.Format(@"{0}\Hammer\marcaDoble.png", pathImage));
            header.LogoAbajoIzquierda = Image.GetInstance(string.Format(@"{0}\Hammer\hammerLogoH.png", pathImage));

            string fechas = string.Empty;
            foreach (DateTime item in GolfJornada.GetGolfJornadasFechas(eventoId))
            {
                if (string.IsNullOrEmpty(fechas))
                {
                    fechas = string.Format(DBGlobalization.GetCultureInfo(), "{0:dd}", item);
                }
                else
                {
                    fechas = string.Format(DBGlobalization.GetCultureInfo(), "{0},{1:dd}", fechas, item);
                }
            }
            header.Fecha = fechas;

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

        private static void SetBody(DataTable jugadores, DataTable hoyos, string descEvento, string jornada)
        {
            PdfPTable colores = new PdfPTable(new float[] { 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1 });
            colores.WidthPercentage = 70;
            colores.AddCell(DrawTable.DrawCell(descEvento, 14, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
            colores.AddCell(DrawTable.DrawCell(HeaderGolf.FirstCharToUpper(jornada), 12, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
            colores.AddCell(DrawTable.DrawCell("Resultados", 10, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
            colores.AddCell(DrawTable.DrawCell("\n", 10, CellBorder.NONE, CellAlignment.Center, 19, CellFontStyle.Bold));
            colores.HeaderRows = 2;
            documentPdf.Add(colores);

            if (jugadores.Columns.Count == 30)
            {

                #region boddy columnas
                PdfPTable body = new PdfPTable(new float[] { 1, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, (float)1.2, 1, 1, 1, 1, 1, 1, 1, 1, 1, (float)1.2, (float)1.2, (float)1.2, (float)1.2 });
                body.WidthPercentage = 100;
                body.AddCell(DrawTable.DrawCellHeader("HCP", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("Jugador/Hoyo", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("1", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("2", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("3", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("4", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("5", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("6", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("7", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("8", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("9", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("1RA", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("10", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("11", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("12", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("13", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("14", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("15", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("16", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("17", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("18", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("2DA", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("Total", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("Total Neto", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("Score", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));

                var data = GolfHoyoPar.GetGolfHoyoPar("");
                #region PAR
                body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
                body.AddCell(DrawTable.DrawCellHeader("PAR ", 7, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));



                var dataRow = (from myRow in data.AsEnumerable()
                               where myRow.Field<int>("HoyoParId") <= 10
                               select myRow).Union(from myRow in data.AsEnumerable()
                                                   where myRow.Field<int>("HoyoParId") == 20
                                                   select myRow).Union(from myRow in data.AsEnumerable()
                                                                       where myRow.Field<int>("HoyoParId") >= 11 && myRow.Field<int>("HoyoParId") < 20
                                                                       select myRow).Union(from myRow in data.AsEnumerable()
                                                                                           where myRow.Field<int>("HoyoParId") >= 11 && myRow.Field<int>("HoyoParId") > 20
                                                                                           select myRow);

                foreach (DataRow row in dataRow)
                {
                    body.AddCell(DrawTable.DrawCellHeader(row["Par"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                }
                body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
                body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));

                #endregion

                #region BLANCOS
                body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
                body.AddCell(DrawTable.DrawCellHeader("YARDAS ", 7, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));

                foreach (DataRow row in dataRow)
                {
                    body.AddCell(DrawTable.DrawCellHeader(row["Blancas"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                }
                body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
                body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));

                #endregion

                foreach (DataRow row in jugadores.Rows)
                {
                    body.AddCell(DrawTable.DrawCellHeader(row["Handicap"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Normal));
                    body.AddCell(DrawTable.DrawCellHeader(row["NomCompleto"].ToString(), 7, CellBorder.BOX, CellAlignment.Left, CellAlignment.Center, CellFontStyle.Normal));
                    body.AddCell(DrawTable.DrawCellHeader(row["1"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["1"].ToString(), 0)));
                    body.AddCell(DrawTable.DrawCellHeader(row["2"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["2"].ToString(), 1)));
                    body.AddCell(DrawTable.DrawCellHeader(row["3"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["3"].ToString(), 2)));
                    body.AddCell(DrawTable.DrawCellHeader(row["4"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["4"].ToString(), 3)));
                    body.AddCell(DrawTable.DrawCellHeader(row["5"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["5"].ToString(), 4)));
                    body.AddCell(DrawTable.DrawCellHeader(row["6"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["6"].ToString(), 5)));
                    body.AddCell(DrawTable.DrawCellHeader(row["7"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["7"].ToString(), 6)));
                    body.AddCell(DrawTable.DrawCellHeader(row["8"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["8"].ToString(), 7)));
                    body.AddCell(DrawTable.DrawCellHeader(row["9"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["9"].ToString(), 8)));
                    body.AddCell(DrawTable.DrawCellHeader(row["1 Vuelta"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, BaseColor.LIGHT_GRAY));
                    body.AddCell(DrawTable.DrawCellHeader(row["10"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["10"].ToString(), 9)));
                    body.AddCell(DrawTable.DrawCellHeader(row["11"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["11"].ToString(), 10)));
                    body.AddCell(DrawTable.DrawCellHeader(row["12"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["12"].ToString(), 11)));
                    body.AddCell(DrawTable.DrawCellHeader(row["13"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["13"].ToString(), 12)));
                    body.AddCell(DrawTable.DrawCellHeader(row["14"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["14"].ToString(), 13)));
                    body.AddCell(DrawTable.DrawCellHeader(row["15"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["15"].ToString(), 14)));
                    body.AddCell(DrawTable.DrawCellHeader(row["16"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["16"].ToString(), 15)));
                    body.AddCell(DrawTable.DrawCellHeader(row["17"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["17"].ToString(), 16)));
                    body.AddCell(DrawTable.DrawCellHeader(row["18"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["18"].ToString(), 17)));
                    body.AddCell(DrawTable.DrawCellHeader(row["2 Vuelta"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, BaseColor.LIGHT_GRAY));
                    body.AddCell(DrawTable.DrawCellHeader(row["Total"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, BaseColor.WHITE));
                    body.AddCell(DrawTable.DrawCellHeader(row["TotalNeto"].ToString(), 8, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Bold, BaseColor.WHITE));
                    body.AddCell(DrawTable.DrawCellHeader(row["Score"].ToString(), 8, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Bold, BaseColor.WHITE));

                }
                #endregion

                body.HeaderRows = 3;
                documentPdf.Add(body);

            }
            else
            {



                #region boddy columnas
                PdfPTable body = new PdfPTable(new float[] {7, 1, 1, 1, 1, 1, 1, 1, 1, 1, (float)1.4, 1, 1, 1, 1, 1, 1, 1, 1, 1, (float)1.4, (float)1.4, (float)1.4 });
                body.WidthPercentage = 100;
               // body.AddCell(DrawTable.DrawCellHeader("HCP", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("Jugador/Hoyo", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("1", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("2", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("3", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("4", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("5", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("6", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("7", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("8", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("9", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("1RA", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("10", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("11", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("12", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("13", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("14", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("15", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("16", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("17", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("18", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("2DA", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("Total", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                body.AddCell(DrawTable.DrawCellHeader("Score", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                var data = GolfHoyoPar.GetGolfHoyoPar("");
                #region PAR
                //body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
                body.AddCell(DrawTable.DrawCellHeader("PAR ", 7, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));



                var dataRow = (from myRow in data.AsEnumerable()
                               where myRow.Field<int>("HoyoParId") <= 10
                               select myRow).Union(from myRow in data.AsEnumerable()
                                                   where myRow.Field<int>("HoyoParId") == 20
                                                   select myRow).Union(from myRow in data.AsEnumerable()
                                                                       where myRow.Field<int>("HoyoParId") >= 11 && myRow.Field<int>("HoyoParId") < 20
                                                                       select myRow).Union(from myRow in data.AsEnumerable()
                                                                                           where myRow.Field<int>("HoyoParId") >= 11 && myRow.Field<int>("HoyoParId") > 20
                                                                                           select myRow);

                foreach (DataRow row in dataRow)
                {
                    body.AddCell(DrawTable.DrawCellHeader(row["Par"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                }
                body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
                #endregion

                #region BLANCOS
                //body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
                body.AddCell(DrawTable.DrawCellHeader("YARDAS ", 7, CellBorder.BOX, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));

                foreach (DataRow row in dataRow)
                {
                    body.AddCell(DrawTable.DrawCellHeader(row["Blancas"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
                }
                body.AddCell(DrawTable.DrawCellHeader(" ", 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.WHITE));
                #endregion

                foreach (DataRow row in jugadores.Rows)
                {
                    //body.AddCell(DrawTable.DrawCellHeader(row["Handicap"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Normal));
                    body.AddCell(DrawTable.DrawCellHeader(row["NomCompleto"].ToString(), 7, CellBorder.BOX, CellAlignment.Left, CellAlignment.Center, CellFontStyle.Normal));
                    body.AddCell(DrawTable.DrawCellHeader(row["1"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["1"].ToString(), 0)));
                    body.AddCell(DrawTable.DrawCellHeader(row["2"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["2"].ToString(), 1)));
                    body.AddCell(DrawTable.DrawCellHeader(row["3"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["3"].ToString(), 2)));
                    body.AddCell(DrawTable.DrawCellHeader(row["4"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["4"].ToString(), 3)));
                    body.AddCell(DrawTable.DrawCellHeader(row["5"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["5"].ToString(), 4)));
                    body.AddCell(DrawTable.DrawCellHeader(row["6"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["6"].ToString(), 5)));
                    body.AddCell(DrawTable.DrawCellHeader(row["7"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["7"].ToString(), 6)));
                    body.AddCell(DrawTable.DrawCellHeader(row["8"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["8"].ToString(), 7)));
                    body.AddCell(DrawTable.DrawCellHeader(row["9"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["9"].ToString(), 8)));
                    body.AddCell(DrawTable.DrawCellHeader(row["1 Vuelta"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, BaseColor.LIGHT_GRAY));
                    body.AddCell(DrawTable.DrawCellHeader(row["10"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["10"].ToString(), 9)));
                    body.AddCell(DrawTable.DrawCellHeader(row["11"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["11"].ToString(), 10)));
                    body.AddCell(DrawTable.DrawCellHeader(row["12"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["12"].ToString(), 11)));
                    body.AddCell(DrawTable.DrawCellHeader(row["13"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["13"].ToString(), 12)));
                    body.AddCell(DrawTable.DrawCellHeader(row["14"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["14"].ToString(), 13)));
                    body.AddCell(DrawTable.DrawCellHeader(row["15"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["15"].ToString(), 14)));
                    body.AddCell(DrawTable.DrawCellHeader(row["16"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["16"].ToString(), 15)));
                    body.AddCell(DrawTable.DrawCellHeader(row["17"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["17"].ToString(), 16)));
                    body.AddCell(DrawTable.DrawCellHeader(row["18"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, GetColorCell(hoyos, row["18"].ToString(), 17)));
                    body.AddCell(DrawTable.DrawCellHeader(row["2 Vuelta"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, BaseColor.LIGHT_GRAY));
                    body.AddCell(DrawTable.DrawCellHeader(row["Total"].ToString(), 7, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Normal, BaseColor.WHITE));
                    body.AddCell(DrawTable.DrawCellHeader(row["Score"].ToString(), 8, CellBorder.BOX, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Bold, BaseColor.WHITE));
                }
                #endregion

                //body.HeaderRows = 3;
                //documentPdf.Add(body);
                body.HeaderRows = 3;
                documentPdf.Add(body);

            }

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
