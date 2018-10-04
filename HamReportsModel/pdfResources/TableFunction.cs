
using cnsReports.pdfResources;
using HamReportsModel.pdfResources;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace erpReports.pdfResources
{
    #region Enums
    public enum CellMerge
    {
        Colspan0 = 0,
        Colspan1 = 1,
        Colspan2 = 2,
        Colspan3 = 3,
        Colspan4 = 4,
        Colspan5 = 5,
        Colspan6 = 6,
        Colspan7 = 7,
        Colspan8 = 8,
        Colspan9 = 9,
        Colspan10 = 10,
        Colspan11 = 11,
        Colspan12 = 12,
        Colspan13 = 13,
        Colspan14 = 14,
        Colspan15 = 15,
        Colspan16 = 16,
        Colspan17 = 17,
        Colspan18 = 18,
        Colspan19 = 19,
        Colspan20 = 20,
        Rowspan0 = 0,
        Rowspan1 = 1,
        Rowspan2 = 2,
        Rowspan3 = 3,
        Rowspan4 = 4,
        Rowspan5 = 5,
        Rowspan6 = 6,
        Rowspan7 = 7,
        Rowspan8 = 8,
        Rowspan9 = 9,
        Rowspan10 = 10,
        Rowspan11 = 11,
        Rowspan12 = 12,
        Rowspan13 = 13,
        Rowspan14 = 14,
        Rowspan15 = 15,
        Rowspan16 = 16,
        Rowspan17 = 17,
        Rowspan18 = 18,
        Rowspan19 = 19,
        Rowspan20 = 20
    }

    public enum CellAlign
    {
        UNDEFINED = -1,
        LEFT = 0,
        CENTER = 1,
        RIGHT = 2,
        JUSTIFIED = 3,
        TOP = 4,
        MIDDLE = 5,
        BOTTOM = 6,
        BASELINE = 7,
        JUSTIFIED_ALL = 8
    }

    public enum CellBorder2
    {
        UNDEFINED = -1,
        NO = 0,
        TOP = 1,
        BOTTOM = 2,
        TOP_BOTTOM = 3,
        LEFT = 4,
        LEFT_TOP = 5,
        LEFT_BOTTOM = 6,
        LEFT_TOP_BOTTOM = 7,
        RIGHT = 8,
        TOP_RIGHT = 9,
        RIGHT_BOTTOM = 10,
        TOP_RIGHT_BOTTOM = 11,
        LEFT_RIGHT = 12,
        LEFT_TOP_RIGHT = 13,
        LEFT_BOTTOM_RIGHT = 14,
        BOX = 15
    }

    public enum CellTextSize
    {
        TSC1 = 1,
        TSC2 = 2,
        TSC3 = 3,
        TSC4 = 4,
        TSC5 = 5,
        TSC6 = 6,
        TSC7 = 7,
        TSC8 = 8,
        TSC9 = 9,
        TSC10 = 10,
        TSC11 = 11,
        TSC12 = 12,
        TSC13 = 13,
        TSC14 = 14,
        TSC15 = 15,
        TSC16 = 16,
        TSC17 = 17,
        TSC18 = 18,
        TSC19 = 19,
        TSC20 = 20,
        TSC21 = 21,
        TSC22 = 22,
        TSC23 = 23,
        TSC24 = 24,
        TSC25 = 25,
        TSC26 = 26,
        TSC27 = 27,
        TSC28 = 28,
        TSC29 = 29,
        TSC30 = 30,
        TSC35 = 35,
        TSC40 = 40,
        TSC45 = 45,
        TSC50 = 50,
        TSC55 = 55,
        TSC60 = 60,
        TSC65 = 65,
        TSC70 = 70,
        TSC75 = 75,
        TSC80 = 80
    }

    public enum CellTextFont
    {
        ARIAL,
        COURIER,
        HELVETICA,
        TIMES,
        VERDANA,
        ZAPFDINGBATS
    }

    public enum CellTextRotation
    {
        R0 = 0,
        R90 = 90,
        R180 = 180,
        R270 = 270,
        R360 = 360
    }

    public enum CellTextFormat
    {
        UNDEFINED = -1,
        NORMAL = 0,
        BOLD = 1,
        ITALIC = 2,
        BOLDITALIC = 3,
        UNDERLINE = 4,
        BOLDUNDERLINE = 5,
        ITALICUNDERLINE = 6,
        BOLDITALICUNDERLINE = 7,
        STRIKETHRU = 8,
        BOLDSTRIKETHRU = 9,
        ITALICSTRIKETHRU = 10,
        BOLDITALICUNDERLINESTRIKETHRU = 11,
        DEFAULTSIZE = 12
    }

    public enum CellPadding
    {
        PC1 = 1,
        PC2 = 2,
        PC3 = 3,
        PC4 = 4,
        PC5 = 5,
        PC6 = 6,
        PC7 = 7,
        PC8 = 8,
        PC9 = 9,
        PC10 = 10,
        PC11 = 11,
        PC12 = 12,
        PC13 = 13,
        PC14 = 14,
        PC15 = 15,
        PC16 = 16,
        PC17 = 17,
        PC18 = 18,
        PC19 = 19,
        PC20 = 20,
        PC21 = 21,
        PC22 = 22,
        PC23 = 23,
        PC24 = 24,
        PC25 = 25,
        PC26 = 26,
        PC27 = 27,
        PC28 = 28,
        PC29 = 29,
        PC30 = 30,
        PC35 = 35,
        PC40 = 40,
        PC45 = 45,
        PC50 = 50,
        PC55 = 55,
        PC60 = 60,
        PC65 = 65,
        PC70 = 70,
        PC75 = 75,
        PC80 = 80,
        PC85 = 85,
        PC90 = 90,
        PC95 = 95,
        PC100 = 100
    }
    #endregion

    public enum CellAlignment
    {
        Buttom = 6,
        Justified = 3,
        Baseline = 7,
        Bottom = 6,
        Center = 1,
        JustifiedAll = 8,
        Left = 0,
        Middle = 5,
        Right = 2,
        Undefinied = -1,
        Top = 4
    }

    public enum CellFontStyle
    {
        Bold = 1,
        BoldItalic = 3,
        DefaultSize = 12,
        Italic = 2,
        Normal = 0,
        StrikeThur = 8,
        Undefined = -1,
        Underline = 4,
    }

    public enum CellBorder
    {
        UNDEFINED = -1,
        NONE = 0,
        TOP = 1,
        BOTTOM = 2,
        TOP_BOTTOM = 3,
        LEFT = 4,
        LEFT_TOP = 5,
        LEFT_BOTTOM = 6,
        LEFT_TOP_BOTTOM = 7,
        RIGHT = 8,
        TOP_RIGHT = 9,
        RIGHT_BOTTOM = 10,
        TOP_RIGHT_BOTTOM = 11,
        LEFT_RIGHT = 12,
        LEFT_TOP_RIGHT = 13,
        LEFT_BOTTOM_RIGHT = 14,
        BOX = 15
    }

    public class DrawTable
    {
        public static PdfPTable linea()
        {
            PdfPTable header_linea = new PdfPTable(1);
            header_linea.WidthPercentage = 100;

            float[] tamlie = { 100 };
            header_linea.DefaultCell.BorderWidthLeft = 0;
            header_linea.DefaultCell.BorderWidthRight = 0;
            header_linea.DefaultCell.BorderWidthTop = 0;
            header_linea.DefaultCell.BorderWidthBottom = 1;
            header_linea.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
            header_linea.SetWidths(tamlie);
            header_linea.AddCell((" "));
            return header_linea;
        }

        public static PdfPTable linea(int color)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;

            float[] tamlie = { 100 };
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 1;

            switch (color)
            {
                case 1:
                    line.DefaultCell.BorderColor = BaseColor.BLACK;
                    break;
                case 2:
                    line.DefaultCell.BorderColor = BaseColor.DARK_GRAY;
                    break;
                default:
                    line.DefaultCell.BorderColor = BaseColor.BLACK;
                    break;
            }
            line.SetWidths(tamlie);
            line.AddCell((" "));
            return line;
        }

        public static PdfPCell NormalCell(string text, float size, int border, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size)));
            PdfPCell cellColor = new PdfPCell(new Phrase(""));
            cellColor.BackgroundColor = new BaseColor(151, 151, 151);
            cellColor.PaddingLeft = 300;
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 10:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 11:
                    CeldaPDF.Border = PdfPCell.NO_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                case 4:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell NormalCell(string text, float size, int border, int alignment, string font)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont(font, size)));
            PdfPCell cellColor = new PdfPCell(new Phrase(""));
            cellColor.BackgroundColor = new BaseColor(151, 151, 151);
            cellColor.PaddingLeft = 300;
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 10:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 11:
                    CeldaPDF.Border = PdfPCell.NO_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell AddLine(PdfPTable linea, float size, int border, int alignment, int collspan)
        {
            PdfPCell CeldaPDF = new PdfPCell(linea);
            CeldaPDF.Colspan = collspan;
            PdfPCell cellColor = new PdfPCell(new Phrase(""));
            cellColor.BackgroundColor = new BaseColor(151, 151, 151);
            cellColor.PaddingLeft = 100;
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 10:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 11:
                    CeldaPDF.Border = PdfPCell.NO_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell CustomizeCell(string text, int collspan, int rowspan, float size, int alignment, int border, BaseColor textColor)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Calibri", size, textColor)));
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 10:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            CeldaPDF.Colspan = collspan;
            CeldaPDF.Rowspan = rowspan;
            CeldaPDF.HorizontalAlignment = alignment;
            CeldaPDF.VerticalAlignment = alignment;
            return CeldaPDF;
        }

        public static PdfPCell TextColorCell(string text, float size, int border, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size, new BaseColor(151, 151, 151))));
            //CeldaPDF.BackgroundColor = new BaseColor(151, 151, 151);
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell BackColorCell(string text, float size, int border, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size)));
            CeldaPDF.BackgroundColor = new BaseColor(151, 151, 151);
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell ColsHeaderCell(string text, int colspan)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", 12, iTextSharp.text.Font.NORMAL, BaseColor.WHITE)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.GRAY;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.HorizontalAlignment = 1;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell ColsHeaderCell(string text, int colspan, float size)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, iTextSharp.text.Font.NORMAL, BaseColor.WHITE)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.GRAY;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.HorizontalAlignment = 1;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell ColsHeaderCell(string text, int colspan, int rowspan, float size)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, iTextSharp.text.Font.NORMAL, BaseColor.WHITE)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.GRAY;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.Rowspan = rowspan;
            CeldaPDF.HorizontalAlignment = 1;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell ColsHeaderCellNormal(string text, int colspan, float size)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.WHITE;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.HorizontalAlignment = 1;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell BlankCell(string text, float size, int alignment, int colspan)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, BaseColor.BLACK))); CeldaPDF.Colspan = colspan;
            CeldaPDF.HorizontalAlignment = alignment;
            CeldaPDF.Border = 0;
            return CeldaPDF;
        }

        public static PdfPCell MergeCell(string text, float size, int alignment, int colspan, int borde)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, BaseColor.BLACK)));
            //CeldaPDF.BackgroundColor = new BaseColor(151, 151, 151);
            CeldaPDF.Colspan = colspan;
            #region "borde"
            switch (borde)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            //CeldaPDF.HorizontalAlignment = alignment;
            //CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell BoldCell(string text, float size, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size, iTextSharp.text.Font.BOLD)));
            CeldaPDF.HorizontalAlignment = alignment;//0=Left, 1=Center, 2=Right 
            CeldaPDF.Border = 0;
            return CeldaPDF;
        }

        public static PdfPCell celdasize(string Texto, float tamaño, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Verdana", tamaño)));
            CeldaPDF.HorizontalAlignment = 1;//0=Left, 1=Center, 2=Right            
            //CeldaPDF.BackgroundColor = BaseColor.GRAY;
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell celdasize(string Texto, float tamaño, CellAlignment alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Verdana", tamaño)));
            CeldaPDF.HorizontalAlignment = (int)alignment;
            return CeldaPDF;
        }

        public static PdfPCell HeaderNextCell(string text, int collspan, int rowspan, float size, CellAlignment alignment, CellBorder border)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Tahoma", size)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
            CeldaPDF.Colspan = collspan;
            CeldaPDF.Rowspan = rowspan;
            CeldaPDF.HorizontalAlignment = (int)alignment;
            CeldaPDF.VerticalAlignment = (int)alignment;
            CeldaPDF.Border = (int)border;
            return CeldaPDF;
        }

        public static PdfPCell celColspan(string Texto, float tamaño, int borde, int alignment, int colspan, int color)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Verdana", tamaño, BaseColor.BLACK)));
            CeldaPDF.Colspan = colspan;
            #region color
            switch (color)
            {
                case 1:
                    PdfPCell cellColor = new PdfPCell(new Phrase(""));
                    break;
                case 2:
                    CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.GRAY;
                    break;
                case 3:
                    CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
                    break;
            }
            #endregion
            #region "borde"
            switch (borde)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                case 4:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell CellPaddingText(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlingH, sbyte AlignV, float Padding, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Padding = Padding;
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.HorizontalAlignment = AlignV;
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            return cell;
        }

        #region MetodosAgregado
        /// <summary>
        /// CellSimple Se puede enviar Argumentos de Texto, y Borde
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <returns></returns>
        public static PdfPCell CellSimple(string Text, sbyte Border)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellSimpleCR Se puede enviar Argumentos Texto, Border, Combinación de Columnas, Combinación de Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellSimpleCR(string Text, sbyte Border, byte Colspan, byte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellSimpleCR Se puede enviar Argumentos Texto, Combinación de Columnas, Combinación de Filas.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellSimpleCR(string Text, byte Colspan, byte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border, float Size)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border, float Size, sbyte Format)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Color Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="ColorText"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border, float Size, sbyte Format, BaseColor ColorText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Color Texto, Color De Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border, float Size, sbyte Format, BaseColor ColorText, BaseColor BackgroundCell)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            return cell;
        }

        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(string Text, sbyte Border, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(string Text, sbyte Border, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(string Text, sbyte Border, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBA = CellTexFontBorderAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBA(string Text, string Font, sbyte Border, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBA = CellTexFontBorderAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBA(string Text, string Font, sbyte Border, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBA = CellTexFontBorderAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBA(string Text, string Font, sbyte Border, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBSA = CellTexFontBorderSizeAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSA(string Text, string Font, sbyte Border, float Size, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSA = CellTexFontBorderSizeAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSA(string Text, string Font, sbyte Border, float Size, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSA = CellTexFontBorderSizeAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSA(string Text, string Font, sbyte Border, float Size, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoA = CellTexFontBorderSizeFormatAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoA(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoA = CellTexFontBorderSizeFormatAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoA(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoA = CellTexFontBorderSizeFormatAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto,Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoA(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACt = CellTexFontBorderSizeFormatAlignColorText,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto,Alineacion Horizontal
        /// Color de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="ColorText"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACt(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, BaseColor ColorText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACt = CellTexFontBorderSizeFormatAlignColorText,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Vertical
        /// Color de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACt(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, BaseColor ColorText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, ColorText)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACt = CellTexFontBorderSizeFormatAlignColorText,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal, Alineacion Vertical
        /// Color de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACt(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, BaseColor ColorText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACtBa = CellTexFontBorderSizeFormatAlignColorTextBackColor,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal
        /// Color de texto, Color de Fondo de Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBa(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, BaseColor ColorText, BaseColor BackgroundCell)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtBa = CellTexFontBorderSizeFormatAlignColorTextBackColor,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Vertical
        /// Color de texto, Color de Fondo de Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBa(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, BaseColor ColorText, BaseColor BackgroundCell)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, ColorText)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtBa = CellTexFontBorderSizeFormatAlignColorTextBackColor,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal, Alineacion Vertical
        /// Color de texto, Color de Fondo de Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBa(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, BaseColor ColorText, BaseColor BackgroundCell)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            return cell;
        }

        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>           
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, float Size, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Color Texto
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="ColorText"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, float Size, sbyte Format, BaseColor ColorText, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Color Texto, Color de Fondo de Celda
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, float Size, sbyte Format, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTBACR = CellTexBorderAligColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Horizontal, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTBACR(string Text, sbyte Border, byte AlignH, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTBACR = CellTexBorderAligColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Vertical, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTBACR(string Text, sbyte Border, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTBACR = CellTexBorderAligColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Bordes, Alineación Horizontal, Alineación Vertical,  
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTBACR(string Text, sbyte Border, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        public static PdfPCell CellTBACR(string Text, sbyte Border, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan, sbyte size)
        {
            PdfPCell cell = new PdfPCell(new Paragraph(Text, FontFactory.GetFont("Verdana", size)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        // PdfPCell CeldaPDF = 
        /// <summary>
        /// CellTFBACR = CellTexFontBorderAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineación Horizontal, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBACR(string Text, string Font, sbyte Border, byte AlignH, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBACR = CellTexFontBorderAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineación Vertical, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBACR(string Text, string Font, sbyte Border, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBACR = CellTexFontBorderAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineación Horizontal, Alineación Vertical
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBACR(string Text, string Font, sbyte Border, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTFBSACR = CellTexFontBorderSizeAlignColspanRowpan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineación Horizontal, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignH"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSACR(string Text, string Font, sbyte Border, float Size, byte AlignH, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSACR = CellTexFontBorderSizeAlignColspanRowpan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineación Vertical, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSACR(string Text, string Font, sbyte Border, float Size, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSACR = CellTexFontBorderSizeAlignColspanRowpan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineación Horizontal, Alineación Vertical 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSACR(string Text, string Font, sbyte Border, float Size, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACR = CellTexFontBorderSizeFormatAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal,
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACR(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACR = CellTexFontBorderSizeFormatAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Vertical, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACR = CellTexFontBorderSizeFormatAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, Alineación Vertical
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACtCR = CellTexFontBorderSizeFormatAlignColorTextColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal
        /// Color de texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="ColorText"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtCR(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, BaseColor ColorText, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtCR = CellTexFontBorderSizeFormatAlignColorTextColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Vertical
        /// Color de texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, BaseColor ColorText, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, ColorText)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtCR = CellTexFontBorderSizeFormatAlignColorTextColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, Alineación Vertical
        /// Color de texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, BaseColor ColorText, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACtBaCR = CellTexFontBorderSizeFormatAlignColorTextBackColorColspanRowspan, 
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, 
        /// Color de texto, Color de Fondo de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBaCR(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtBaCR = CellTexFontBorderSizeFormatAlignColorTextBackColorColspanRowspan, 
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Vertical, 
        /// Color de texto, Color de Fondo de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBaCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, ColorText)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtBaCR = CellTexFontBorderSizeFormatAlignColorTextBackColorColspanRowspan, 
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, Alineación Vertical, 
        /// Color de texto, Color de Fondo de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBaCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Parrafo, Bordes, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(Paragraph Text, sbyte Border, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(Text);
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Parrafo, Bordes, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(Paragraph Text, sbyte Border, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(Text);
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Parrafo, Bordes, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(Paragraph Text, sbyte Border, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(Text);
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Table, Bordes, Alineacion Horizontal
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(PdfPTable Table, sbyte Border, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(Table);
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Table, Bordes, Alineacion Vertical
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(PdfPTable Table, sbyte Border, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(Table);
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Parrafo, Table, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(PdfPTable Table, sbyte Border, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(Table);
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        #endregion

        public static PdfPCell CellTFBSAP(string Tex, string Font, sbyte Border, float Size, byte AlignH, float Padding)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Tex, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            cell.Padding = Padding;
            return cell;
        }        

        public static PdfPCell CellPadding(PdfPCell Cell, float Padding)
        {
            PdfPCell cell = Cell;
            cell.Padding = ItextUtils.CentimetersToPoints(Padding);
            return cell;
        }

        public static PdfPCell CellColorBorder(PdfPCell Cell, BaseColor BordeColor)
        {
            PdfPCell cell = Cell;
            cell.BorderColor = BordeColor;
            return cell;
        }

        public static PdfPCell CellColorBorderHeight(PdfPCell Cell, BaseColor ColorBorder, float WidthFixedHeight)
        {
            PdfPCell cell = Cell;
            cell.FixedHeight = ItextUtils.CentimetersToPoints(WidthFixedHeight);
            cell.BorderColor = ColorBorder;
            return cell;
        }

        public static PdfPTable Borde(PdfPCell header)
        {
            PdfPTable bordes = new PdfPTable(1);
            bordes.AddCell(header);
            return bordes;
        }

        public static PdfPTable Line()
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 1;
            line.DefaultCell.BorderWidthBottom = 0;
            line.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
            line.AddCell("");
            return line;
        }

        public static PdfPTable Line(BaseColor color)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 1;
            line.DefaultCell.BorderColor = color;
            line.SetWidths(new float[] { 100 });
            line.AddCell((" "));
            return line;
        }

        public static PdfPCell AddLine(PdfPTable linea, int colspan)
        {
            PdfPCell CeldaPDF = new PdfPCell(linea);
            if (colspan > 1)
            {
                CeldaPDF.Colspan = colspan;
            }
            return CeldaPDF;
        }

        public static PdfPTable LineLeft(float WidthLeft, BaseColor BordeColor)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = WidthLeft;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 0;
            line.DefaultCell.BorderColor = BordeColor;
            line.AddCell(" ");
            return line;
        }

        public static PdfPTable LineRight(float WidthRight, BaseColor BordeColor)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = WidthRight;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 0;
            line.DefaultCell.BorderColor = BordeColor;
            line.AddCell(" ");
            return line;
        }

        public static PdfPTable LineTop(float WidthTop, BaseColor BordeColor)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = WidthTop;
            line.DefaultCell.BorderWidthBottom = 0;
            line.DefaultCell.BorderColor = BordeColor;
            line.AddCell(" ");
            return line;
        }

        public static PdfPTable LineBottom(float WidthBottom, BaseColor BordeColor)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = WidthBottom;
            line.DefaultCell.BorderColor = BordeColor;
            line.AddCell(" ");
            return line;
        }

        public static PdfPCell Imagen(Image ImagenCell, sbyte Colspan, sbyte Rowspan, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell celdaImg = new PdfPCell(ImagenCell, true);
            if (Colspan > 1)
            {
                celdaImg.Colspan = Colspan;
            }
            if (Rowspan > 1)
            {
                celdaImg.Rowspan = Rowspan;
            }
            celdaImg.HorizontalAlignment = AlignH;
            celdaImg.VerticalAlignment = AlignV;
            celdaImg.Border = 0;
            return celdaImg;
        }

        public static PdfPCell Imagen(Image ImagenCell, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell celdaImg = new PdfPCell(ImagenCell, true);
            celdaImg.HorizontalAlignment = AlignH;
            celdaImg.VerticalAlignment = AlignV;
            celdaImg.Border = 0;
            return celdaImg;
        }

        public static PdfPCell CellHeight(PdfPCell cell, float Height)
        {
            PdfPCell celda = cell;
            celda.FixedHeight = ItextUtils.CentimetersToPoints(Height);
            return celda;
        }

        public static PdfPCell CellColspan(PdfPCell cell, sbyte colspan)
        {
            PdfPCell celda = cell;
            if (colspan > 1)
                celda.Colspan = colspan;
            return celda;
        }

        public static PdfPCell CellRowspan(PdfPCell cell, sbyte rowspan)
        {
            PdfPCell celda = cell;
            if (rowspan > 1)
                celda.Rowspan = rowspan;
            return celda;
        }

        public static PdfPCell CellMergs(PdfPCell cell, sbyte colspan, sbyte rowspan)
        {
            PdfPCell celda = cell;
            if (colspan > 1)
                celda.Rowspan = rowspan;
            if (rowspan > 1)
                celda.Colspan = colspan;
            return celda;
        }

        public static PdfPCell CellColspan(PdfPTable cell, sbyte colspan)
        {
            PdfPCell celda = new PdfPCell(cell);
            celda.Border = 0;
            if (colspan > 1)
                celda.Colspan = colspan;
            return celda;
        }

        public static PdfPCell CellRowspan(PdfPTable cell, sbyte rowspan)
        {
            PdfPCell celda = new PdfPCell(cell);
            if (rowspan > 1)
                celda.Rowspan = rowspan;
            return celda;
        }

        public static PdfPCell CellMergs(PdfPTable cell, sbyte colspan, sbyte rowspan)
        {
            PdfPCell celda = new PdfPCell(cell);
            if (colspan > 1)
                celda.Rowspan = rowspan;
            if (rowspan > 1)
                celda.Colspan = colspan;
            return celda;
        }

        public static PdfPCell CellRotate(PdfPCell cell, int rotate)
        {
            return new PdfPCell(cell) { Rotation = rotate };
        }

        public static PdfPCell CellRotate(string cell, int rotate)
        {
            return new PdfPCell(new Phrase(cell)) { Rotation = rotate };
        }

        public static PdfPCell DrawCell(string Texto, float sizeFont, CellBorder border, CellAlignment alignment, int colspan, CellFontStyle fontStyle)
        {
            Font f = FontFactory.GetFont("Tahoma ", sizeFont, (int)fontStyle, BaseColor.BLACK);
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(Texto, f));
            CeldaPDF.Colspan = colspan;
            CeldaPDF.Border = (int)border;
            CeldaPDF.HorizontalAlignment = (int)alignment;
            return CeldaPDF;
        }

        public static PdfPCell DrawCell(string Texto, float sizeFont, CellBorder border, CellAlignment alignment, CellFontStyle fontStyle)
        {
            Font f = FontFactory.GetFont("Tahoma ", sizeFont, (int)fontStyle, BaseColor.BLACK);
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(Texto, f));
            CeldaPDF.Border = (int)border;
            CeldaPDF.HorizontalAlignment = (int)alignment;
            CeldaPDF.BorderColor = BaseColor.LIGHT_GRAY;
            return CeldaPDF;
        }
        public static PdfPCell DrawCellHeader(string texto, float sizeFont, CellBorder border, CellAlignment alignmentHorizontal, CellAlignment alignmentVertical, CellFontStyle fontStyle, int rowSpan, int colSpan)
        {
            Font font = FontFactory.GetFont("Tahoma", sizeFont, (int)fontStyle, BaseColor.BLACK);
            PdfPCell cell = new PdfPCell(new Phrase(texto, font));
            cell.Border = (int)border;
            cell.HorizontalAlignment = (int)alignmentHorizontal;
            cell.VerticalAlignment = (int)alignmentVertical;
            cell.Rowspan = rowSpan;
            cell.Colspan = colSpan;
            return cell;
        }

        public static PdfPCell DrawCellHeader(string texto, float sizeFont, CellBorder border, CellAlignment alignmentHorizontal, CellAlignment alignmentVertical, CellFontStyle fontStyle)
        {
            Font font = FontFactory.GetFont("Tahoma", sizeFont, (int)fontStyle, BaseColor.BLACK);
            PdfPCell cell = new PdfPCell(new Phrase(texto, font));
            cell.Border = (int)border;
            cell.HorizontalAlignment = (int)alignmentHorizontal;
            cell.VerticalAlignment = (int)alignmentVertical;
            return cell;
        }
        public static PdfPCell DrawCellHeader(string texto, float sizeFont, CellBorder border, CellAlignment alignmentHorizontal, CellAlignment alignmentVertical, CellFontStyle fontStyle, BaseColor color)
        {
            Font font = FontFactory.GetFont("Tahoma", sizeFont, (int)fontStyle, BaseColor.BLACK);
            PdfPCell cell = new PdfPCell(new Phrase(texto, font));
            cell.Border = (int)border;
            cell.HorizontalAlignment = (int)alignmentHorizontal;
            cell.VerticalAlignment = (int)alignmentVertical;
            cell.BackgroundColor = color;
            return cell;
        }
    }

    public class TableFunction
    {
        public static PdfPTable linea()
        {
            PdfPTable header_linea = new PdfPTable(1);
            header_linea.WidthPercentage = 100;

            float[] tamlie = { 100 };
            header_linea.DefaultCell.BorderWidthLeft = 0;
            header_linea.DefaultCell.BorderWidthRight = 0;
            header_linea.DefaultCell.BorderWidthTop = 0;
            header_linea.DefaultCell.BorderWidthBottom = 1;
            header_linea.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
            header_linea.SetWidths(tamlie);
            header_linea.AddCell((" "));
            return header_linea;
        }

        public static PdfPTable linea(int color)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;

            float[] tamlie = { 100 };
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 1;

            switch (color)
            {
                case 1:
                    line.DefaultCell.BorderColor = BaseColor.BLACK;
                    break;
                case 2:
                    line.DefaultCell.BorderColor = BaseColor.DARK_GRAY;
                    break;
                default:
                    line.DefaultCell.BorderColor = BaseColor.BLACK;
                    break;
            }
            line.SetWidths(tamlie);
            line.AddCell((" "));
            return line;
        }

        public static PdfPCell NormalCell(string text, float size, int border, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size)));
            PdfPCell cellColor = new PdfPCell(new Phrase(""));
            cellColor.BackgroundColor = new BaseColor(151, 151, 151);
            cellColor.PaddingLeft = 300;
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 10:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 11:
                    CeldaPDF.Border = PdfPCell.NO_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                case 4:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell NormalCell(string text, float size, int border, int alignment, string font)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont(font, size)));
            PdfPCell cellColor = new PdfPCell(new Phrase(""));
            cellColor.BackgroundColor = new BaseColor(151, 151, 151);
            cellColor.PaddingLeft = 300;
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 10:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 11:
                    CeldaPDF.Border = PdfPCell.NO_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell AddLine(PdfPTable linea, float size, int border, int alignment, int collspan)
        {
            PdfPCell CeldaPDF = new PdfPCell(linea);
            CeldaPDF.Colspan = collspan;
            PdfPCell cellColor = new PdfPCell(new Phrase(""));
            cellColor.BackgroundColor = new BaseColor(151, 151, 151);
            cellColor.PaddingLeft = 100;
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 10:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 11:
                    CeldaPDF.Border = PdfPCell.NO_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell CustomizeCell(string text, int collspan, int rowspan, float size, int alignment, int border, BaseColor textColor)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Calibri", size, textColor)));
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 10:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            CeldaPDF.Colspan = collspan;
            CeldaPDF.Rowspan = rowspan;
            CeldaPDF.HorizontalAlignment = alignment;
            CeldaPDF.VerticalAlignment = alignment;
            return CeldaPDF;
        }

        public static PdfPCell TextColorCell(string text, float size, int border, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size, new BaseColor(151, 151, 151))));
            //CeldaPDF.BackgroundColor = new BaseColor(151, 151, 151);
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell BackColorCell(string text, float size, int border, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size)));
            CeldaPDF.BackgroundColor = new BaseColor(151, 151, 151);
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell ColsHeaderCell(string text, int colspan)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", 12, iTextSharp.text.Font.NORMAL, BaseColor.WHITE)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.GRAY;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.HorizontalAlignment = 1;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell ColsHeaderCell(string text, int colspan, float size)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, iTextSharp.text.Font.NORMAL, BaseColor.WHITE)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.GRAY;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.HorizontalAlignment = 1;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell ColsHeaderCell(string text, int colspan, int rowspan, float size)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, iTextSharp.text.Font.NORMAL, BaseColor.WHITE)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.GRAY;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.Rowspan = rowspan;
            CeldaPDF.HorizontalAlignment = 1;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell ColsHeaderCellNormal(string text, int colspan, float size)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.WHITE;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.HorizontalAlignment = 1;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell BlankCell(string text, float size, int alignment, int colspan)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, BaseColor.WHITE)));
            CeldaPDF.BackgroundColor = new BaseColor(151, 151, 151);
            CeldaPDF.Colspan = colspan;
            CeldaPDF.HorizontalAlignment = alignment;
            CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell MergeCell(string text, float size, int alignment, int colspan, int borde)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(text, FontFactory.GetFont("Verdana", size, BaseColor.BLACK)));
            //CeldaPDF.BackgroundColor = new BaseColor(151, 151, 151);
            CeldaPDF.Colspan = colspan;
            #region "borde"
            switch (borde)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            //CeldaPDF.HorizontalAlignment = alignment;
            //CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
            return CeldaPDF;
        }

        public static PdfPCell BoldCell(string text, float size, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size, iTextSharp.text.Font.BOLD)));
            CeldaPDF.HorizontalAlignment = alignment;//0=Left, 1=Center, 2=Right 
            CeldaPDF.Border = 0;
            return CeldaPDF;
        }

        public static PdfPCell celdasize(string Texto, float tamaño, int alignment)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Verdana", tamaño)));
            CeldaPDF.HorizontalAlignment = 1;//0=Left, 1=Center, 2=Right            
            //CeldaPDF.BackgroundColor = BaseColor.GRAY;
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell celdasizePadding(string Texto, float tamaño, int alignment, float padding, float paddingBottom, float paddingLeft, float paddingRight)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Verdana", tamaño)));
            CeldaPDF.HorizontalAlignment = 1;//0=Left, 1=Center, 2=Right            
            //CeldaPDF.BackgroundColor = BaseColor.GRAY;

            CeldaPDF.Padding = padding;
            CeldaPDF.PaddingBottom = paddingBottom;
            CeldaPDF.PaddingLeft = paddingLeft;
            CeldaPDF.PaddingRight = paddingRight;
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell HeaderNextCell(string text, int collspan, int rowspan, float size, int alignment, int border)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Paragraph(text, FontFactory.GetFont("Verdana", size)));
            CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
            CeldaPDF.Colspan = collspan;
            CeldaPDF.Rowspan = rowspan;
            CeldaPDF.HorizontalAlignment = alignment;
            CeldaPDF.VerticalAlignment = alignment;
            #region "borde"
            switch (border)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                default:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell celColspan(string Texto, float tamaño, int borde, int alignment, int colspan, int color)
        {
            PdfPCell CeldaPDF = new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Verdana", tamaño, BaseColor.BLACK)));
            CeldaPDF.Colspan = colspan;
            #region color
            switch (color)
            {
                case 1:
                    PdfPCell cellColor = new PdfPCell(new Phrase(""));
                    break;
                case 2:
                    CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.GRAY;
                    break;
                case 3:
                    CeldaPDF.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
                    break;
            }
            #endregion
            #region "borde"
            switch (borde)
            {
                case 0:
                    CeldaPDF.Border = 0;
                    break;
                case 1:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    break;
                case 2:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    break;
                case 3:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 4:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 5:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 6:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 7:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                case 8:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER;
                    break;
                case 9:
                    CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    break;
                default:
                    CeldaPDF.Border = 0;
                    break;
            }
            #endregion
            #region "alinear"
            switch (alignment)
            {
                case 1:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                case 2:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 3:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    break;
                case 4:
                    CeldaPDF.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
            }
            #endregion
            return CeldaPDF;
        }

        public static PdfPCell CellPaddingTextText(string Text1, string Text2, string Font, sbyte Border, float Size, sbyte Format, sbyte AlingH, sbyte AlignV, float Padding, sbyte Colspan, sbyte Rowspan)
        {
            Phrase phrase = new Phrase();
            sbyte Format1 = (sbyte)CellTextFormat.NORMAL;
            phrase.Add(new Chunk(Text1, FontFactory.GetFont(Font, Size, Format1)));
            phrase.Add(new Chunk(Text2, FontFactory.GetFont(Font, Size, Format)));
            PdfPCell cell = new PdfPCell(phrase);
            cell.Padding = Padding;
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.HorizontalAlignment = AlignV;
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            return cell;
        }

        public static PdfPCell CellPaddingTextTextSize(string Text1, string Text2, string Font, sbyte Border, float Size, float Size1, sbyte Format, sbyte AlingH, sbyte AlignV, float Padding, sbyte Colspan, sbyte Rowspan)
        {
            Phrase phrase = new Phrase();
            sbyte Format1 = (sbyte)CellTextFormat.NORMAL;
            phrase.Add(new Chunk(Text1, FontFactory.GetFont(Font, Size, Format1)));
            phrase.Add(new Chunk(Text2, FontFactory.GetFont(Font, Size1, Format)));
            PdfPCell cell = new PdfPCell(phrase);
            cell.Padding = Padding;
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.HorizontalAlignment = AlignV;
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            return cell;
        }

        public static PdfPCell CellPaddingTextTextTextSize(string Text1, string Text2, string Text3, string Font, sbyte Border, float Size, float Size1, sbyte Format, sbyte AlingH, sbyte AlignV, float Padding, sbyte Colspan, sbyte Rowspan, float Sangria, float AbsoluteL, float RelativeL)
        {
            Phrase phrase = new Phrase();
            sbyte Format1 = (sbyte)CellTextFormat.NORMAL;
            phrase.Add(new Chunk(Text1, FontFactory.GetFont(Font, Size, Format1)));
            phrase.Add(new Chunk(Text2, FontFactory.GetFont(Font, Size1, Format)));
            phrase.Add(new Chunk(Text3, FontFactory.GetFont(Font, Size, Format1)));
            PdfPCell cell = new PdfPCell(phrase);
            cell.Padding = Padding;
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.HorizontalAlignment = AlignV;
            cell.Indent = Sangria;
            cell.SetLeading(AbsoluteL, RelativeL);
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            return cell;
        }

        public static PdfPCell CellPaddingText(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlingH, sbyte AlignV, float Padding, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Padding = Padding;
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.HorizontalAlignment = AlignV;
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            return cell;
        }
        public static PdfPCell CellPaddingText(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlingH, sbyte AlignV, float Padding, sbyte Colspan, sbyte Rowspan, int rotation)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Padding = Padding;
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.HorizontalAlignment = AlignV;
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            cell.Rotation = rotation;

            return cell;
        }

        public static PdfPCell CellNoPaddingText(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlingH, sbyte AlignV, float Padding, sbyte Colspan, sbyte Rowspan, int rotation)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Padding = Padding;
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.VerticalAlignment = AlignV;
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            cell.Rotation = rotation;

            return cell;
        }

        public static PdfPCell CellPaddingInternoText(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlingH, sbyte AlignV, float Sangria, float AbsoluteL, float RelativeL, sbyte Colspan, sbyte Rowspan, int rotation)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Indent = Sangria;
            cell.SetLeading(AbsoluteL, RelativeL);
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.VerticalAlignment = AlignV;
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            cell.Rotation = rotation;

            return cell;
        }

        public static PdfPCell CellPaddingText(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlingH, sbyte AlignV, float Padding, sbyte Colspan, sbyte Rowspan, int rotation, float TamHeight)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Padding = Padding;
            cell.Border = Border;
            cell.HorizontalAlignment = AlingH;
            cell.VerticalAlignment = AlignV;
            if (Colspan > 0)
                cell.Colspan = Colspan;
            if (Rowspan > 0)
                cell.Rowspan = Rowspan;
            cell.Rotation = rotation;
            cell.FixedHeight = ItextUtils.CentimetersToPoints(TamHeight);
            return cell;
        }
        public static PdfPCell celFirmas(string Texto, int alignment, int colspan, int rowspan, int negrita, int border)
        {

            PdfPCell CeldaPDF = negrita.Equals(1) ? new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Verdana", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK))) : new PdfPCell(new Phrase(Texto, FontFactory.GetFont("Verdana", 10, BaseColor.BLACK)));
            CeldaPDF.HorizontalAlignment = alignment.Equals(1) ? Element.ALIGN_RIGHT : alignment.Equals(2) ? Element.ALIGN_CENTER : Element.ALIGN_LEFT;
            CeldaPDF.Border = 0;
            CeldaPDF.Colspan = colspan;
            CeldaPDF.Rowspan = rowspan;
            CeldaPDF.HorizontalAlignment = alignment;
            if (border == 1)
            {
                RoundedBorder roundedBorder = new RoundedBorder();
                CeldaPDF.CellEvent = roundedBorder;
                CeldaPDF.Border = 0;
            }
            return CeldaPDF;
        }
        //Metodos Agregados 24-09-15
        #region MetodosAgregado
        /// <summary>
        /// CellSimple Se puede enviar Argumentos de Texto, y Borde
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <returns></returns>
        public static PdfPCell CellSimple(string Text, sbyte Border)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellSimpleCR Se puede enviar Argumentos Texto, Border, Combinación de Columnas, Combinación de Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellSimpleCR(string Text, sbyte Border, byte Colspan, byte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellSimpleCR Se puede enviar Argumentos Texto, Combinación de Columnas, Combinación de Filas.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellSimpleCR(string Text, byte Colspan, byte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border, float Size)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border, float Size, sbyte Format)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Color Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="ColorText"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border, float Size, sbyte Format, BaseColor ColorText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellBasic, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Color Texto, Color De Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <returns></returns>
        public static PdfPCell CellBasic(string Text, string Font, sbyte Border, float Size, sbyte Format, BaseColor ColorText, BaseColor BackgroundCell)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            return cell;
        }

        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(string Text, sbyte Border, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(string Text, sbyte Border, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(string Text, sbyte Border, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBA = CellTexFontBorderAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBA(string Text, string Font, sbyte Border, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBA = CellTexFontBorderAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBA(string Text, string Font, sbyte Border, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBA = CellTexFontBorderAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBA(string Text, string Font, sbyte Border, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBSA = CellTexFontBorderSizeAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSA(string Text, string Font, sbyte Border, float Size, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSA = CellTexFontBorderSizeAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSA(string Text, string Font, sbyte Border, float Size, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSA = CellTexFontBorderSizeAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSA(string Text, string Font, sbyte Border, float Size, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoA = CellTexFontBorderSizeFormatAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoA(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }/// <summary>
         /// CellTFBSFoA = CellTexFontBorderSizeFormatAlign,
         /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal
         /// </summary>
         /// <param name="Text"></param>
         /// <param name="Font"></param>
         /// <param name="Border"></param>
         /// <param name="Size"></param>
         /// <param name="Format"></param>
         /// <param name="AlignH"></param>
         /// <returns></returns>
        public static PdfPCell CellTFBSFoAH(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoA = CellTexFontBorderSizeFormatAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoA(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoA = CellTexFontBorderSizeFormatAlign,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto,Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoA(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACt = CellTexFontBorderSizeFormatAlignColorText,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto,Alineacion Horizontal
        /// Color de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="ColorText"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACt(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, BaseColor ColorText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACt = CellTexFontBorderSizeFormatAlignColorText,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Vertical
        /// Color de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACt(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, BaseColor ColorText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACt = CellTexFontBorderSizeFormatAlignColorText,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal, Alineacion Vertical
        /// Color de Texto
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACt(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, BaseColor ColorText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACtBa = CellTexFontBorderSizeFormatAlignColorTextBackColor,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal
        /// Color de texto, Color de Fondo de Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBa(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, BaseColor ColorText, BaseColor BackgroundCell)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtBa = CellTexFontBorderSizeFormatAlignColorTextBackColor,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Vertical
        /// Color de texto, Color de Fondo de Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBa(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, BaseColor ColorText, BaseColor BackgroundCell)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, ColorText)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtBa = CellTexFontBorderSizeFormatAlignColorTextBackColor,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineacion Horizontal, Alineacion Vertical
        /// Color de texto, Color de Fondo de Celda
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBa(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, BaseColor ColorText, BaseColor BackgroundCell)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            return cell;
        }

        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>           
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, float Size, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Color Texto
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="ColorText"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, float Size, sbyte Format, BaseColor ColorText, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellBasicCR, se puede enviar los siguiente parametros
        /// Texto, Fuente de Texto, Borde de Celda, Tamaño de Texto, Formato de Texto, Color Texto, Color de Fondo de Celda
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellBasicCR(string Text, string Font, sbyte Border, float Size, sbyte Format, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTBACR = CellTexBorderAligColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Horizontal, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTBACR(string Text, sbyte Border, byte AlignH, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTBACR = CellTexBorderAligColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Bordes, Alineacion Vertical, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTBACR(string Text, sbyte Border, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTBACR = CellTexBorderAligColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Bordes, Alineación Horizontal, Alineación Vertical,  
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTBACR(string Text, sbyte Border, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        public static PdfPCell CellTBACR(string Text, sbyte Border, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan, sbyte size)
        {
            PdfPCell cell = new PdfPCell(new Paragraph(Text, FontFactory.GetFont("Verdana", size)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        // PdfPCell CeldaPDF = 
        /// <summary>
        /// CellTFBACR = CellTexFontBorderAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineación Horizontal, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBACR(string Text, string Font, sbyte Border, byte AlignH, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBACR = CellTexFontBorderAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineación Vertical, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBACR(string Text, string Font, sbyte Border, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBACR = CellTexFontBorderAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Alineación Horizontal, Alineación Vertical
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBACR(string Text, string Font, sbyte Border, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTFBSACR = CellTexFontBorderSizeAlignColspanRowpan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineación Horizontal, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignH"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSACR(string Text, string Font, sbyte Border, float Size, byte AlignH, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSACR = CellTexFontBorderSizeAlignColspanRowpan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineación Vertical, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSACR(string Text, string Font, sbyte Border, float Size, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSACR = CellTexFontBorderSizeAlignColspanRowpan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Alineación Horizontal, Alineación Vertical 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSACR(string Text, string Font, sbyte Border, float Size, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACR = CellTexFontBorderSizeFormatAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal,
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACR(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellHeaderTBSAHAVCR = CellHeaderTexFontBorderSizeFormatHorizontalAlignVerticalAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación horizontal, Alineacion Vertical,
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellHeaderTBSAHAVCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        public static PdfPCell CellTFBSFoACR(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, sbyte Colspan, sbyte Rowspan, float Padding)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            cell.Padding = Padding;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACR = CellTexFontBorderSizeFormatAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Vertical, 
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACR = CellTexFontBorderSizeFormatAlignColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, Alineación Vertical
        /// Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        public static PdfPCell CellTFBSFoACRR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan, int rotation)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.Rotation = rotation;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        public static PdfPCell CellTFBSFoACR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, sbyte Colspan, sbyte Rowspan, float Paddign)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Padding = Paddign;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtCR = CellTexFontBorderSizeFormatAlignColorTextColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal
        /// Color de texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="ColorText"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtCR(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, BaseColor ColorText, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtCR = CellTexFontBorderSizeFormatAlignColorTextColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Vertical
        /// Color de texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, BaseColor ColorText, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, ColorText)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtCR = CellTexFontBorderSizeFormatAlignColorTextColspanRowspan,
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, Alineación Vertical
        /// Color de texto, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, BaseColor ColorText, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACtBaCR = CellTexFontBorderSizeFormatAlignColorTextBackColorColspanRowspan, 
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, 
        /// Color de texto, Color de Fondo de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBaCR(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTFBSFoACtBaCR = CellTexFontBorderSizeFormatAlignColorTextBackColorColspanRowspan, 
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, 
        /// Color de texto, Color de Fondo de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoAACtBaCR(string Text, string Font, sbyte Border, float Size, sbyte Format, byte AlignH, byte AlignV, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtBaCR = CellTexFontBorderSizeFormatAlignColorTextBackColorColspanRowspan, 
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Vertical, 
        /// Color de texto, Color de Fondo de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBaCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignV, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, ColorText)));
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }
        /// <summary>
        /// CellTFBSFoACtBaCR = CellTexFontBorderSizeFormatAlignColorTextBackColorColspanRowspan, 
        /// Recibe los siguiente Parametros Texto, Fuente, Bordes, Tamaño de Texto, Formato de Texto, Alineación Horizontal, Alineación Vertical, 
        /// Color de texto, Color de Fondo de Celda, Combinación De Columnas, Combinación De Filas
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="Border"></param>
        /// <param name="Size"></param>
        /// <param name="Format"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <param name="ColorText"></param>
        /// <param name="BackgroundCell"></param>
        /// <param name="Colspan"></param>
        /// <param name="Rowspan"></param>
        /// <returns></returns>
        public static PdfPCell CellTFBSFoACtBaCR(string Text, string Font, sbyte Border, float Size, sbyte Format, sbyte AlignH, sbyte AlignV, BaseColor ColorText, BaseColor BackgroundCell, sbyte Colspan, sbyte Rowspan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Text, FontFactory.GetFont(Font, Size, Format, ColorText)));
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            cell.BackgroundColor = BackgroundCell;
            if (Colspan > 1)
                cell.Colspan = Colspan;
            if (Rowspan > 1)
                cell.Rowspan = Rowspan;
            return cell;
        }

        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Parrafo, Bordes, Alineacion Horizontal
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(Paragraph Text, sbyte Border, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(Text);
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Parrafo, Bordes, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(Paragraph Text, sbyte Border, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(Text);
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Parrafo, Bordes, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(Paragraph Text, sbyte Border, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(Text);
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }

        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Table, Bordes, Alineacion Horizontal
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(PdfPTable Table, sbyte Border, byte AlignH)
        {
            PdfPCell cell = new PdfPCell(Table);
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Table, Bordes, Alineacion Vertical
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Border"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(PdfPTable Table, sbyte Border, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(Table);
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        /// <summary>
        /// CellTBA = CellTexBorderAlig, 
        /// Recibe los siguiente Parametros Parrafo, Table, Alineacion Horizontal, Alineacion Vertical
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Border"></param>
        /// <param name="AlignH"></param>
        /// <param name="AlignV"></param>
        /// <returns></returns>
        public static PdfPCell CellTBA(PdfPTable Table, sbyte Border, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell cell = new PdfPCell(Table);
            cell.HorizontalAlignment = AlignH;
            cell.VerticalAlignment = AlignV;
            cell.Border = Border;
            return cell;
        }
        #endregion

        public static PdfPCell CellTFBSAP(string Tex, string Font, sbyte Border, float Size, byte AlignH, float Padding)
        {
            PdfPCell cell = new PdfPCell(new Phrase(Tex, FontFactory.GetFont(Font, Size)));
            cell.HorizontalAlignment = AlignH;
            cell.Border = Border;
            cell.Padding = Padding;
            return cell;
        }

        public static PdfPCell CellPadding(PdfPCell Cell, float Padding)
        {
            PdfPCell cell = Cell;
            cell.Padding = ItextUtils.CentimetersToPoints(Padding);
            return cell;
        }
        /// <summary>
        /// CellLeftPadding = CellLeftPadding, 
        /// Recibe los siguiente Parametros celda, valor de margen izquierdo
        /// </summary>
        /// <param name="Cell"></param>
        /// <param name="LeftPadding"></param>
        /// <returns></returns>
        public static PdfPCell CellLeftPadding(PdfPCell Cell, float LeftPadding)
        {
            PdfPCell cell = Cell;
            cell.PaddingLeft = ItextUtils.CentimetersToPoints(LeftPadding);
            return cell;
        }

        public static PdfPCell CellColorBorder(PdfPCell Cell, BaseColor BordeColor)
        {
            PdfPCell cell = Cell;
            cell.BorderColor = BordeColor;
            return cell;
        }

        public static PdfPCell CellColorBorderHeight(PdfPCell Cell, BaseColor ColorBorder, float WidthFixedHeight)
        {
            PdfPCell cell = Cell;
            cell.FixedHeight = ItextUtils.CentimetersToPoints(WidthFixedHeight);
            cell.BorderColor = ColorBorder;
            return cell;
        }

        public static PdfPTable Borde(PdfPCell header)
        {
            PdfPTable bordes = new PdfPTable(1);
            bordes.AddCell(header);
            return bordes;
        }

        public static PdfPTable Line()
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 1;
            line.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
            line.AddCell(" ");
            return line;
        }

        public static PdfPTable Line(BaseColor color)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 1;
            line.DefaultCell.BorderColor = color;
            line.SetWidths(new float[] { 100 });
            line.AddCell((" "));
            return line;
        }

        public static PdfPCell AddLine(PdfPTable linea, int colspan)
        {
            PdfPCell CeldaPDF = new PdfPCell(linea);
            if (colspan > 1)
            {
                CeldaPDF.Colspan = colspan;
            }
            return CeldaPDF;
        }

        public static PdfPTable LineLeft(float WidthLeft, BaseColor BordeColor)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = WidthLeft;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 0;
            line.DefaultCell.BorderColor = BordeColor;
            line.AddCell(" ");
            return line;
        }

        public static PdfPTable LineRight(float WidthRight, BaseColor BordeColor)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = WidthRight;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = 0;
            line.DefaultCell.BorderColor = BordeColor;
            line.AddCell(" ");
            return line;
        }

        public static PdfPTable LineTop(float WidthTop, BaseColor BordeColor)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = WidthTop;
            line.DefaultCell.BorderWidthBottom = 0;
            line.DefaultCell.BorderColor = BordeColor;
            line.AddCell(" ");
            return line;
        }

        public static PdfPTable LineBottom(float WidthBottom, BaseColor BordeColor)
        {
            PdfPTable line = new PdfPTable(1);
            line.WidthPercentage = 100;
            line.DefaultCell.BorderWidthLeft = 0;
            line.DefaultCell.BorderWidthRight = 0;
            line.DefaultCell.BorderWidthTop = 0;
            line.DefaultCell.BorderWidthBottom = WidthBottom;
            line.DefaultCell.BorderColor = BordeColor;
            line.AddCell(" ");
            return line;
        }

        public static PdfPCell Imagen(Image ImagenCell, sbyte Colspan, sbyte Rowspan, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell celdaImg = new PdfPCell(ImagenCell, true);
            if (Colspan > 1)
            {
                celdaImg.Colspan = Colspan;
            }
            if (Rowspan > 1)
            {
                celdaImg.Rowspan = Rowspan;
            }
            celdaImg.HorizontalAlignment = AlignH;
            celdaImg.VerticalAlignment = AlignV;
            celdaImg.Border = 0;
            return celdaImg;
        }

        public static PdfPCell Imagen(Image ImagenCell, sbyte AlignH, sbyte AlignV)
        {
            PdfPCell celdaImg = new PdfPCell(ImagenCell, true);
            celdaImg.HorizontalAlignment = AlignH;
            celdaImg.VerticalAlignment = AlignV;
            celdaImg.Border = 0;
            return celdaImg;
        }

        public static PdfPCell CellHeight(PdfPCell cell, float Height)
        {
            PdfPCell celda = cell;
            celda.FixedHeight = ItextUtils.CentimetersToPoints(Height);
            return celda;
        }

        public static PdfPCell CellColspan(PdfPCell cell, sbyte colspan)
        {
            PdfPCell celda = cell;
            if (colspan > 1)
                celda.Colspan = colspan;
            return celda;
        }

        public static PdfPCell CellRowspan(PdfPCell cell, sbyte rowspan)
        {
            PdfPCell celda = cell;
            if (rowspan > 1)
                celda.Rowspan = rowspan;
            return celda;
        }

        public static PdfPCell CellMergs(PdfPCell cell, sbyte colspan, sbyte rowspan)
        {
            PdfPCell celda = cell;
            if (colspan > 1)
                celda.Rowspan = rowspan;
            if (rowspan > 1)
                celda.Colspan = colspan;
            return celda;
        }

        public static PdfPCell CellColspan(PdfPTable cell, sbyte colspan)
        {
            PdfPCell celda = new PdfPCell(cell);
            celda.Border = 0;
            if (colspan > 1)
                celda.Colspan = colspan;
            return celda;
        }

        public static PdfPCell CellRowspan(PdfPTable cell, sbyte rowspan)
        {
            PdfPCell celda = new PdfPCell(cell);
            if (rowspan > 1)
                celda.Rowspan = rowspan;
            return celda;
        }

        public static PdfPCell CellMergs(PdfPTable cell, sbyte colspan, sbyte rowspan)
        {
            PdfPCell celda = new PdfPCell(cell);
            if (colspan > 1)
                celda.Rowspan = rowspan;
            if (rowspan > 1)
                celda.Colspan = colspan;
            return celda;
        }

        public static PdfPCell CellRotate(PdfPCell cell, int rotate)
        {
            return new PdfPCell(cell) { Rotation = rotate };
        }

        public static PdfPCell CellRotate(string cell, int rotate)
        {
            return new PdfPCell(new Phrase(cell)) { Rotation = rotate };
        }
    }
}