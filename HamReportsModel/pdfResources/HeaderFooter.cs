using erpReports.pdfResources;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace cnsReports.pdfResources
{    
    public class HeaderFooter : PdfPageEventHelper
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

        #endregion

        public HeaderFooter()
        {
            LimitMargin = 20;
            LimitBorderBottom = 80;
            LimitBorderTop = 78;
        }

        public HeaderFooter(string pageHorizontal)
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
            datosImpresion = string.Format("{0} - {1:dddd,d MMMM yyyy HH:mm:ss}", User, DateTime.Now);
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

    // Reporte Acreditacion
    public class HeaderReport : PdfPageEventHelper
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
        public Image LogoDerecha { get; set; }
        public Image LogoIzquierda { get; set; }

        #endregion

        public HeaderReport()
        {
            LimitMargin = 20;
            LimitBorderBottom = 80;
            LimitBorderTop = 78;
        }

        public HeaderReport(string pageHorizontal)
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
            base.OnStartPage(writer, document);
            PdfPTable header = new PdfPTable(new float[] { 2, 8, 2 });
            header.WidthPercentage = 100;

            PdfPTable detalle = new PdfPTable(2);

            detalle.AddCell(DrawTable.DrawCell("Modulo:", 7,CellBorder.NONE, CellAlignment.Left,0,CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell("Delegación:", 7, CellBorder.NONE, CellAlignment.Right, 0, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell(Titulo, 8, CellBorder.NONE, CellAlignment.Left, 0, CellFontStyle.Bold));
            detalle.AddCell(DrawTable.DrawCell(SubTitulo, 8, CellBorder.NONE, CellAlignment.Right, 0, CellFontStyle.Bold));

            LogoIzquierda.ScaleToFit(90f, 40f);
            LogoDerecha.ScaleToFit(90f, 40f);
            PdfPCell cellImg = new PdfPCell(LogoIzquierda);
            cellImg.Border = PdfPCell.NO_BORDER;
            header.AddCell(cellImg);

            PdfPCell tc = new PdfPCell(detalle);
            tc.Border = 0;
            tc.PaddingLeft = 10;
            tc.PaddingRight = 10;
            header.AddCell(tc);
            cellImg = new PdfPCell(LogoDerecha);
            cellImg.Border = PdfPCell.NO_BORDER;
            header.AddCell(cellImg);

            document.Add(header);
            //document.Add(DrawTable.LineBottom(1, BaseColor.BLACK));
            document.Add(new Paragraph("\n"));
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
            datosImpresion = string.Format("{0} - {1:dddd,d MMMM yyyy HH:mm:ss}", User, DateTime.Now);
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

        public static string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            else
            {
                string[] palabras = input.Split(' ');
                string cadena = string.Empty;
                foreach (string palabra in palabras)
                {
                    if (!string.IsNullOrEmpty(palabra))
                    {
                        if (string.IsNullOrEmpty(cadena))
                        {
                            cadena = palabra.First().ToString().ToUpper() + palabra.Substring(1).ToLower();
                        }
                        else
                        {
                            cadena = string.Format("{0} {1}", cadena, palabra.First().ToString().ToUpper() + palabra.Substring(1).ToLower());
                        }
                    }
                }

                return cadena;
            }
        }
    }
    public class RoundedBorder : IPdfPCellEvent
    {
        public void CellLayout(PdfPCell cell, Rectangle rect, PdfContentByte[] canvas)
        {
            PdfContentByte cb = canvas[PdfPTable.BACKGROUNDCANVAS];
            cb.RoundRectangle(
              rect.Left + 1.5f,
              rect.Bottom + 1.5f,
              rect.Width - 3,
              rect.Height - 3, 4
            );
            cb.Stroke();
        }
    }

    public class HeaderGolf : PdfPageEventHelper
    {
        PdfTemplate template;
        PdfContentByte cb;
        BaseFont bf = null;
        #region Propiedades
        public int NumeroPaginas { get; set; }
        public string Titulo { get; set; }
        public string TituloIdioma { get; set; }
        public string SubTitulo { get; set; }
        public string NombreReporte { get; set; }
        public string User { get; set; }
        private float LimitMargin { get; set; }
        private float LimitBorderBottom { get; set; }
        private float LimitBorderTop { get; set; }
        private bool IsHorizontal { get; set; }
        public Image ImageHeader { get; set; }
        public string Jornada { get; set; }
        public string Categoria { get; set; }
        public string Fecha { get; set; }
        public string Deporte { get; set; }

        public Image LogoIzquierda { get; set; }
        public Image LogoDerecha { get; set; }
        public Image LogoAbajoIzquierda { get; set; }
        public Image LogoAbajoDerecha { get; set; }
        public bool HasLeyenda { get; set; }
        public PdfPTable leyendas { get; set; }
        #endregion

        public HeaderGolf()
        {
            LimitMargin = 20;
            LimitBorderBottom = 80;
            LimitBorderTop = 56;
        }

        public HeaderGolf(string pageHorizontal)
        {
            if (pageHorizontal.Equals("horizontal"))
            {
                LimitMargin = 10;
                LimitBorderBottom = 60;
                LimitBorderTop = 50;
                IsHorizontal = true;
            }
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //bf = BaseFont.CreateFont("Calibri", "", true);
            cb = writer.DirectContent;
            template = cb.CreateTemplate(100, 100);
            Titulo = (!string.IsNullOrEmpty(Titulo)) ? string.Format("{0}", Titulo) : "";
            User = (!string.IsNullOrEmpty(User)) ? string.Format("{0}", User) : "";
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            PdfPTable header = new PdfPTable(new float[] { 1, 10, 1 });
            header.WidthPercentage = 100;

            PdfPTable detalle = new PdfPTable(2);

            detalle.AddCell(DrawTable.DrawCell(FirstCharToUpper(Titulo), 10, CellBorder.NONE, CellAlignment.Left, 0, CellFontStyle.Bold)); detalle.AddCell(DrawTable.DrawCell(FirstCharToUpper(Deporte), 12, CellBorder.NONE, CellAlignment.Right, 0, CellFontStyle.Bold));
            detalle.AddCell(DrawTable.DrawCell(FirstCharToUpper(TituloIdioma), 7, CellBorder.NONE, CellAlignment.Left, 0, CellFontStyle.Normal)); detalle.AddCell(DrawTable.DrawCell("Categoria :", 6, CellBorder.NONE, CellAlignment.Right, 0, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell(SubTitulo, 7, CellBorder.NONE, CellAlignment.Left, 0, CellFontStyle.Normal)); detalle.AddCell(DrawTable.DrawCell(FirstCharToUpper(Categoria), 8, CellBorder.NONE, CellAlignment.Right, 0, CellFontStyle.Bold));
            detalle.AddCell(DrawTable.DrawCell("Jornada :", 6, CellBorder.NONE, CellAlignment.Right, 2, CellFontStyle.Normal));
            detalle.AddCell(DrawTable.DrawCell(FirstCharToUpper(Jornada), 8, CellBorder.NONE, CellAlignment.Right, 2, CellFontStyle.Bold));
            detalle.AddCell(DrawTable.DrawCell(Fecha, 6, CellBorder.NONE, CellAlignment.Left, 2, CellFontStyle.Normal));

            LogoIzquierda.ScaleToFit(60f, 60f);
            LogoDerecha.ScaleToFit(60f, 60f);
            PdfPCell cellImg = new PdfPCell(LogoIzquierda);
            cellImg.Border = PdfPCell.NO_BORDER;
            header.AddCell(cellImg);

            PdfPCell tc = new PdfPCell(detalle);
            tc.Border = 0;
            tc.PaddingLeft = 10;
            tc.PaddingRight = 10;
            header.AddCell(tc);
            cellImg = new PdfPCell(LogoDerecha);
            cellImg.Border = PdfPCell.NO_BORDER;
            header.AddCell(cellImg);

            document.Add(header);
            document.Add(DrawTable.LineBottom(1, BaseColor.BLACK));
            document.Add(new Paragraph("\n"));
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            int pageN = writer.PageNumber;
            string text = string.Format("Pág. {0} / ", writer.PageNumber);
            float len = bf.GetWidthPoint(text, 8);
            Rectangle pageSize = document.PageSize;
            float altoPiepagina = document.RightMargin + 40;

            PdfPTable footer_linea = new PdfPTable(1);
            if (HasLeyenda)
            {
                footer_linea.AddCell(leyendas);
                altoPiepagina = altoPiepagina + 25;
            }

            footer_linea.AddCell(DrawTable.DrawCell("\n", 6, CellBorder.NONE, CellAlignment.Left, 0, CellFontStyle.Normal));
            footer_linea.TotalWidth = pageSize.Width - LimitBorderTop;

            footer_linea.WidthPercentage = 100;
            footer_linea.DefaultCell.BorderWidthLeft = 0;
            footer_linea.DefaultCell.BorderWidthRight = 0;
            footer_linea.DefaultCell.BorderWidthTop = 1;
            footer_linea.DefaultCell.BorderWidthBottom = 0;
            footer_linea.DefaultCell.BorderColor = BaseColor.BLACK;
            footer_linea.AddCell("");

            PdfPTable footer_Logos = new PdfPTable(2);
            LogoAbajoIzquierda.ScaleToFit(90f, 40f);
            LogoAbajoDerecha.ScaleToFit(90f, 40f);
            PdfPCell cellImg = new PdfPCell(LogoAbajoIzquierda);
            cellImg.Border = PdfPCell.NO_BORDER;
            cellImg.PaddingTop = 10;

            footer_Logos.AddCell(cellImg);
            cellImg = new PdfPCell(LogoAbajoDerecha);
            cellImg.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cellImg.Border = PdfPCell.NO_BORDER;
            cellImg.PaddingTop = 10;
            footer_Logos.AddCell(cellImg);

            footer_linea.AddCell(footer_Logos);
            footer_linea.WriteSelectedRows(0, -1, pageSize.GetLeft(document.LeftMargin), pageSize.GetBottom(altoPiepagina), cb);

            cb.SetRGBColorFill(100, 100, 100);
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pageSize.GetRight(LimitBorderBottom), pageSize.GetBottom(LimitMargin + 30));
            cb.ShowText(text);
            cb.EndText();

            cb.AddTemplate(template, pageSize.GetRight(LimitBorderBottom) + len, pageSize.GetBottom(LimitMargin + 30));

            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pageSize.GetLeft(document.LeftMargin), pageSize.GetBottom(LimitMargin + 30));
            cb.ShowText("Hammer v1.1");
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bf, 6);
            string datosImpresion;
            datosImpresion = string.Format("{0} - {1:dddd,d MMMM yyyy HH:mm:ss}", User, DateTime.Now);
            cb.SetTextMatrix(((pageSize.Width / 2) - datosImpresion.Length), pageSize.GetBottom(LimitMargin + 30));
            cb.ShowText(datosImpresion);
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

        public static string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            else
            {
                string[] palabras = input.Split(' ');
                string cadena = string.Empty;
                foreach (string palabra in palabras)
                {
                    if (!string.IsNullOrEmpty(palabra))
                    {
                        if (string.IsNullOrEmpty(cadena))
                        {
                            cadena = palabra.First().ToString().ToUpper() + palabra.Substring(1).ToLower();
                        }
                        else
                        {
                            cadena = string.Format("{0} {1}", cadena, palabra.First().ToString().ToUpper() + palabra.Substring(1).ToLower());
                        }
                    }
                }

                return cadena;
            }
        }
    }
    
}