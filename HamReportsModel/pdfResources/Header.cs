using erpReports.pdfResources;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Configuration;
using System.Web;

namespace erpReports.pdfResources
{
    public class Header : PdfPageEventHelper
    {
        PdfTemplate template;
        PdfContentByte cb;
        BaseFont bf = null;
        #region Propiedades
        public int NumeroPaginas { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string NombreReporte { get; set; }
        public string User { get; set; }
        private float LimitMargin { get; set; }
        private float LimitBorderBottom { get; set; }
        private float LimitBorderTop { get; set; }
        private bool IsHorizontal { get; set; }
        public Image ImageHeader { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public string Fecha { get; set; }
        public string Semana { get; set; }
        public string Totalhoras { get; set; }
        public Image LogoIzquierda { get; set; }
        public Image LogoDerecha { get; set; }
        public string Formulario { get; set; }
        public bool DrawHeader { get; set; }
        #endregion

        public Header()
        {
            LimitMargin = 20;
            LimitBorderBottom = 80;
            LimitBorderTop = 78;
            DrawHeader = true;
        }

        public Header(string pageHorizontal)
        {
            if (pageHorizontal.Equals("horizontal"))
            {
                LimitMargin = 10;
                LimitBorderBottom = 60;
                LimitBorderTop = 40;
                IsHorizontal = true;
            }
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb = writer.DirectContent;
            template = cb.CreateTemplate(100, 100);
            Titulo = (!string.IsNullOrEmpty(Titulo)) ? string.Format("{0}", Titulo) : "";
            User = (!string.IsNullOrEmpty(User)) ? string.Format("{0}", User) : "";
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            if (DrawHeader)
            {

            base.OnStartPage(writer, document);
            PdfPTable header = new PdfPTable(new float[] { 1, 10, 1 });
            header.WidthPercentage = 100;

            PdfPTable detalle = new PdfPTable(2);
            detalle.AddCell(DrawTable.DrawCellHeader("Nombre:", 8, CellBorder.NONE, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell(Nombre, 10, CellBorder.NONE, CellAlignment.Middle, CellFontStyle.Normal));

            detalle.AddCell(DrawTable.DrawCellHeader("Unidad:", 8, CellBorder.NONE, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell(Unidad, 10, CellBorder.NONE, CellAlignment.Left, CellFontStyle.Normal));

            detalle.AddCell(DrawTable.DrawCellHeader("Fecha:", 8, CellBorder.NONE, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell(Fecha, 10, CellBorder.NONE, CellAlignment.Left, CellFontStyle.Normal));

            detalle.AddCell(DrawTable.DrawCellHeader("Semana:", 8, CellBorder.NONE, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell(Semana, 10, CellBorder.NONE, CellAlignment.Left, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCellHeader("Total Horas:", 8, CellBorder.NONE, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell(Totalhoras, 10, CellBorder.NONE, CellAlignment.Left, CellFontStyle.Normal));
            PdfPCell cellImg;

            
            LogoIzquierda.ScaleToFit(60f, 60f);
            cellImg= new PdfPCell(LogoIzquierda);
            cellImg.Border = PdfPCell.NO_BORDER;
            header.AddCell(cellImg);

            PdfPCell tc = new PdfPCell(detalle);

            tc.Border = 0;
            header.AddCell(tc);

            LogoDerecha.ScaleToFit(60f, 60f);
            cellImg = new PdfPCell(LogoDerecha);
            cellImg.Border = PdfPCell.NO_BORDER;
            header.AddCell(cellImg);

            PdfPTable tp = new PdfPTable(new float[] { 60, 40 });
            tp.AddCell(DrawTable.DrawCellHeader(Titulo, 14, CellBorder.NONE, CellAlignment.Right, CellAlignment.Middle, CellFontStyle.Bold));
            tp.AddCell(DrawTable.DrawCellHeader(Formulario, 5, CellBorder.NONE, CellAlignment.Left, CellAlignment.Bottom, CellFontStyle.Bold));
            document.Add(tp);
            document.Add(header);
            document.Add(DrawTable.Line());
            document.Add(new Paragraph("\n"));
            }

        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            int pageN = writer.PageNumber;
            string text = string.Format("Pág. {0} de ", writer.PageNumber);
            float len = bf.GetWidthPoint(text, 8);
            Rectangle pageSize = document.PageSize;

            PdfPTable footer_linea = new PdfPTable(1);
            footer_linea.TotalWidth = pageSize.Width - LimitBorderTop;

            footer_linea.WidthPercentage = 100;
            footer_linea.DefaultCell.BorderWidthLeft = 0;
            footer_linea.DefaultCell.BorderWidthRight = 0;
            footer_linea.DefaultCell.BorderWidthTop = 1;
            footer_linea.DefaultCell.BorderWidthBottom = 0;
            footer_linea.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;

            footer_linea.AddCell("");
            footer_linea.WriteSelectedRows(0, -1, pageSize.GetLeft(document.LeftMargin), pageSize.GetBottom(document.RightMargin), cb);

            cb.SetRGBColorFill(100, 100, 100);
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pageSize.GetRight(LimitBorderBottom), pageSize.GetBottom(LimitMargin));
            cb.ShowText(text);
            cb.EndText();

            cb.AddTemplate(template, pageSize.GetRight(LimitBorderBottom) + len, pageSize.GetBottom(LimitMargin));

            cb.BeginText();
            cb.SetFontAndSize(bf, 6);
            string datosImpresion;
            datosImpresion = string.Format("{0} - {1:dddd,d MMMM yyyy HH:mm:ss}", User.ToLower(), DateTime.Now);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, datosImpresion, pageSize.GetLeft(document.LeftMargin), pageSize.GetBottom(LimitMargin), 0);
            cb.EndText();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            template.BeginText();
            template.SetFontAndSize(bf, 8);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }

    public class HeaderReportes : PdfPageEventHelper
    {
        PdfTemplate template;
        PdfContentByte cb;
        BaseFont bf = null;
        #region Propiedades
        public int NumeroPaginas { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string NombreReporte { get; set; }
        public string User { get; set; }
        private float LimitMargin { get; set; }
        private float LimitBorderBottom { get; set; }
        private float LimitBorderTop { get; set; }
        private bool IsHorizontal { get; set; }
        public Image ImageHeader { get; set; }
        public string Nombre { get; set; }        
        public Image LogoIzquierda { get; set; }
        public Image LogoDerecha { get; set; }
        public string Subtitulo1 { get; set; }
        public string Subtitulo2 { get; set; }
        public bool DrawHeader { get; set; }
        #endregion

        public HeaderReportes()
        {
            LimitMargin = 20;
            LimitBorderBottom = 80;
            LimitBorderTop = 78;
            DrawHeader = true;
        }

        public HeaderReportes(string pageHorizontal)
        {
            if (pageHorizontal.Equals("horizontal"))
            {
                LimitMargin = 10;
                LimitBorderBottom = 60;
                LimitBorderTop = 40;
                IsHorizontal = true;
            }
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb = writer.DirectContent;
            template = cb.CreateTemplate(100, 100);
            Titulo = (!string.IsNullOrEmpty(Titulo)) ? string.Format("{0}", Titulo) : "";
            User = (!string.IsNullOrEmpty(User)) ? string.Format("{0}", User) : "";
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            if (DrawHeader)
            {

                base.OnStartPage(writer, document);
                PdfPTable header = new PdfPTable(new float[] { 1, 10, 1 });
                header.WidthPercentage = 100;

                PdfPTable detalle = new PdfPTable(2);
                detalle.AddCell(DrawTable.DrawCellHeader("Nombre:", 8, CellBorder.NONE, CellAlignment.Right, CellAlignment.Center, CellFontStyle.Normal));
                detalle.AddCell(DrawTable.DrawCell(Nombre, 10, CellBorder.NONE, CellAlignment.Middle, CellFontStyle.Normal));

                PdfPTable tp = new PdfPTable(new float[] { 70 });
                tp.AddCell(DrawTable.DrawCellHeader(Titulo, 14, CellBorder.NONE, CellAlignment.Center, CellAlignment.Middle, CellFontStyle.Bold));
                tp.AddCell(DrawTable.DrawCellHeader(Subtitulo1, 7, CellBorder.NONE, CellAlignment.Center, CellAlignment.Top, CellFontStyle.Normal));
                tp.AddCell(DrawTable.DrawCellHeader(Subtitulo2, 9, CellBorder.NONE, CellAlignment.Center, CellAlignment.Top, CellFontStyle.Bold));

                PdfPCell cellImg;
                LogoIzquierda.ScaleToFit(60f, 60f);
                cellImg = new PdfPCell(LogoIzquierda);
                cellImg.Border = PdfPCell.NO_BORDER;
                header.AddCell(cellImg);
                PdfPCell tc = new PdfPCell(tp);
                tc.Border = 0;
                header.AddCell(tc);

                LogoDerecha.ScaleToFit(60f, 60f);
                cellImg = new PdfPCell(LogoDerecha);
                cellImg.Border = PdfPCell.NO_BORDER;
                header.AddCell(cellImg);
                                
                document.Add(header);
                document.Add(DrawTable.Line());
                document.Add(new Paragraph("\n"));
            }

        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            int pageN = writer.PageNumber;
            string text = string.Format("Pág. {0} de ", writer.PageNumber);
            float len = bf.GetWidthPoint(text, 8);
            Rectangle pageSize = document.PageSize;

            PdfPTable footer_linea = new PdfPTable(1);
            footer_linea.TotalWidth = pageSize.Width - LimitBorderTop;

            footer_linea.WidthPercentage = 100;
            footer_linea.DefaultCell.BorderWidthLeft = 0;
            footer_linea.DefaultCell.BorderWidthRight = 0;
            footer_linea.DefaultCell.BorderWidthTop = 1;
            footer_linea.DefaultCell.BorderWidthBottom = 0;
            footer_linea.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;

            footer_linea.AddCell("");
            footer_linea.WriteSelectedRows(0, -1, pageSize.GetLeft(document.LeftMargin), pageSize.GetBottom(document.RightMargin), cb);

            cb.SetRGBColorFill(100, 100, 100);
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pageSize.GetRight(LimitBorderBottom), pageSize.GetBottom(LimitMargin));
            cb.ShowText(text);
            cb.EndText();

            cb.AddTemplate(template, pageSize.GetRight(LimitBorderBottom) + len, pageSize.GetBottom(LimitMargin));

            cb.BeginText();
            cb.SetFontAndSize(bf, 6);
            string datosImpresion;
            datosImpresion = string.Format("{0} - {1:dddd,d MMMM yyyy HH:mm:ss}", User.ToLower(), DateTime.Now);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, datosImpresion, pageSize.GetLeft(document.LeftMargin), pageSize.GetBottom(LimitMargin), 0);
            cb.EndText();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            template.BeginText();
            template.SetFontAndSize(bf, 8);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }
}