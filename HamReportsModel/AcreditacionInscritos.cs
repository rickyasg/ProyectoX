using cnsReports.pdfResources;
using erpReports.pdfResources;
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
    public class AcreditacionInscritos
    {
        private static Document documentPdf;
        private static string pathResource = "C:\\HammerResources\\";
        private static string fileName = string.Format("Inscritos=){0:yyMMdd_HHmmss}.pdf", DateTime.Now);
        private static string path = string.Format(@"{0}\Reportes\{1}", pathResource, fileName);

        public static string ReporteAcreditacionInscritos(DataTable dtInscritos, string pathSendet, string delegacion)
        {
            try
            {
                pathResource = pathSendet;
                if (delegacion == "undefined")
                    delegacion = "Todos";
                SetHead(delegacion);
                dtInscritos.Columns.Remove("PersonaId");
                dtInscritos.Columns.Remove("Grupo");
                dtInscritos.Columns.Remove("Rol");
                dtInscritos.Columns.Remove("Nombre");
                SetBody(dtInscritos);
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
        public static void SetHead(string delegacion)
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

            HeaderReport header = new HeaderReport();
            header.Titulo = "ACREDITACIONES";
            header.SubTitulo = delegacion;
            header.LogoDerecha = Image.GetInstance(Path.Combine(HttpContext.Current.Server.MapPath("/"), @"images\marcaDoble.png"));
            header.LogoIzquierda = Image.GetInstance(Path.Combine(HttpContext.Current.Server.MapPath("/"), @"images\hammerLogoH.png"));
            writer.PageEvent = header;

            documentPdf.Open();
        }
        public static void SetBody(DataTable dtInscritos)
        {
            int nroColumnas = dtInscritos.Columns.Count;
            float[] widthCell = { 1.5f, 3.2f, 3.5f, 3.5f, 5f, 3.2f, 3f };
            PdfPTable body = new PdfPTable(nroColumnas);
            body.SetWidths(widthCell);
            //body.WidthPercentage = 100;

            body.AddCell(DrawTable.DrawCell("LISTA DE INSCRITOS", 10, CellBorder.NONE, CellAlignment.Center, nroColumnas, CellFontStyle.Bold));
            body.AddCell(DrawTable.DrawCell("\n", 10, CellBorder.NONE, CellAlignment.Center, nroColumnas, CellFontStyle.Bold));
            //foreach (DataColumn dc in dtInscritos.Columns)
            //{
            //    body.AddCell(DrawTable.DrawCellHeader(dc.ColumnName, 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            //}
            body.AddCell(DrawTable.DrawCellHeader("Nro.",8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Doc. Identidad", 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Ap. Paterno", 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Ap. Materno", 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Nombres", 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Fecha Nac.", 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));
            body.AddCell(DrawTable.DrawCellHeader("Género", 8, CellBorder.NONE, CellAlignment.Center, CellAlignment.Center, CellFontStyle.Bold, BaseColor.LIGHT_GRAY));

            body.AddCell(DrawTable.DrawCell("\n", 14, CellBorder.NONE, CellAlignment.Center, nroColumnas, CellFontStyle.Bold));

            foreach(DataRow rows in dtInscritos.Rows)
            {
                foreach(DataColumn dc in dtInscritos.Columns)
                {
                    body.AddCell(DrawTable.DrawCellHeader(rows[dc.ColumnName].ToString(), 7, CellBorder.NONE, CellAlignment.Left, CellAlignment.Center, CellFontStyle.Normal));
                }
            }

            documentPdf.Add(body);
            
        }
        public static void SetFooter()
        {
            documentPdf.Close();
        }
    }
}
