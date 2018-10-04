using erpReports.pdfResources;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;


namespace HamReportsModel.pdfResources
{
    public class ItextUtils
    {
        public static float CentimetersToPoints(float Centimeters)
        {
            return Utilities.MillimetersToPoints(Centimeters * 10);
        }

        public static ColumnText PositionDocument(PdfWriter writer, string texto, float x, float y, float xCaja, float yCaja, float sizeCelda, float sizeText)
        {
            ColumnText ColumnText = new ColumnText(writer.DirectContent);
            ColumnText.SetSimpleColumn(CentimetersToPoints(x), CentimetersToPoints(y), CentimetersToPoints(xCaja), CentimetersToPoints(yCaja));
            PdfPTable tabla = new PdfPTable(1);
            PdfPCell celda = new PdfPCell(new Phrase(texto, FontFactory.GetFont("Verdana", sizeText)));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.Border = (byte)CellBorder.NONE;
            celda.FixedHeight = CentimetersToPoints(sizeCelda);
            tabla.AddCell(celda);
            ColumnText.AddElement(tabla);
            ColumnText.Go();
            return ColumnText;
        }

        public static ColumnText PositionDocumentAlign(PdfWriter Writer, string Texto, float X, float Y, float xBox, float yBox, float SizeCell, float SizeText, sbyte AlignH, sbyte AlignV)
        {
            ColumnText ColumnText = new ColumnText(Writer.DirectContent);
            ColumnText.SetSimpleColumn(CentimetersToPoints(X), CentimetersToPoints(Y), CentimetersToPoints(xBox), CentimetersToPoints(yBox));
            PdfPTable tabla = new PdfPTable(1);
            PdfPCell celda = new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Verdana", SizeText)));
            celda.HorizontalAlignment = AlignH;
            celda.VerticalAlignment = AlignV;
            celda.Border = (byte)CellBorder.NONE;
            celda.FixedHeight = CentimetersToPoints(SizeCell);
            tabla.AddCell(celda);
            ColumnText.AddElement(tabla);
            ColumnText.Go();
            return ColumnText;
        }

        public static void PositionText(PdfWriter writer, string text, sbyte AlignHorizontal, float positionX, float positionY)
        {
            ColumnText.ShowTextAligned(writer.DirectContent, AlignHorizontal, new Phrase(text), CentimetersToPoints(positionX), CentimetersToPoints(positionY), 0);
        }

        public static void PositionText(PdfWriter writer, string text, Font font, sbyte AlignHorizontal, float positionX, float positionY)
        {
            ColumnText.ShowTextAligned(writer.DirectContent, AlignHorizontal, new Phrase(text, font), CentimetersToPoints(positionX), CentimetersToPoints(positionY), 0);
        }

        public static void PositionPage(PdfWriter Writer, PdfPCell CellPdf, float WidthBox, float HightBox, float Xposition, float Yposition)
        {
            PdfContentByte cb = Writer.DirectContent;
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = CentimetersToPoints(WidthBox);
            PdfPCell celda = CellPdf;
            celda.FixedHeight = CentimetersToPoints(HightBox);
            table.AddCell(celda);
            table.WriteSelectedRows(0, -1, CentimetersToPoints(Xposition), CentimetersToPoints(Yposition), cb);
        }

        public static void PositionTable(PdfWriter Writer, PdfPTable CellTable, float WidthBox, float HightBox, float Xposition, float Yposition, sbyte Border)
        {
            PdfContentByte cb = Writer.DirectContent;
            PdfPTable table = new PdfPTable(1);
            CellTable.TotalWidth = CentimetersToPoints(WidthBox);
            PdfPCell celda = new PdfPCell(CellTable);
            celda.FixedHeight = CentimetersToPoints(HightBox);
            celda.Border = Border;
            table.AddCell(celda);
            CellTable.WriteSelectedRows(0, -1, CentimetersToPoints(Xposition), CentimetersToPoints(Yposition), cb);
        }

        public static void HtmlToItext(Document document, string html)
        {

            TextReader reader = new StringReader(html);
          /*  HTMLWorker worker = new HTMLWorker(document);
            worker.StartDocument();
            worker.Parse(reader);
            worker.EndDocument();
            worker.Close();*/
        }

        public static void cuadrito(PdfWriter Writer, PdfPCell CellPdf, float WidthBox, float HightBox, float Xposition, float Yposition, BaseColor ColorBox)
        {
            PdfContentByte cb = Writer.DirectContent;
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = ItextUtils.CentimetersToPoints(WidthBox);
            PdfPCell celda = CellPdf;
            celda.FixedHeight = ItextUtils.CentimetersToPoints(HightBox);
            celda.BackgroundColor = ColorBox;
            table.AddCell(celda);
            table.WriteSelectedRows(0, -1, ItextUtils.CentimetersToPoints(Xposition), ItextUtils.CentimetersToPoints(Yposition), cb);
        }
    }
}