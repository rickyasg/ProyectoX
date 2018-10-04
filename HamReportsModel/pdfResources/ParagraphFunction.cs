using iTextSharp.text;

namespace erpReports.pdfResources
{
    #region Enums
    public enum TextFormat
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

    public enum TextFont
    {
        ARIAL,
        COURIER,
        HELVETICA,
        TIMES,
        VERDANA,
        ZAPFDINGBATS
    }

    public enum TextAlign
    {
        LEFT = 0,
        CENTER = 1,
        RIGHT = 2,
        JUSTIFIED = 3,
        TOP = 4,
        MIDDLE = 5,
        BOTTOM = 6
    }

    public enum TextSize
    {
        S5 = 5,
        S6 = 6,
        S7 = 7,
        S8 = 8,
        S9 = 9,
        S10 = 10,
        S11 = 11,
        S12 = 12,
        S13 = 13,
        S14 = 14,
        S15 = 15,
        S16 = 16,
        S17 = 17,
        S18 = 18,
        S19 = 19,
        S20 = 20,
        S21 = 21,
        S22 = 22,
        S23 = 23,
        S24 = 24,
        S25 = 25,
        S30 = 30,
        S35 = 35,
        S40 = 40,
        S45 = 45,
        S50 = 50,
        S55 = 55
    }

    public enum TextSpacingAfter
    {
        TSA0 = 0,
        TSA1 = 1,
        TSA2 = 2,
        TSA3 = 3,
        TSA4 = 4,
        TSA5 = 5,
        TSA6 = 6,
        TSA7 = 7,
        TSA8 = 8,
        TSA9 = 9,
        TSA10 = 10,
        TSA11 = 11,
        TSA12 = 12,
        TSA13 = 13,
        TSA15 = 15,
        TSA16 = 16,
        TSA17 = 17,
        TSA18 = 18,
        TSA19 = 19,
        TSA20 = 20,
        TSA21 = 21,
        TSA22 = 22,
        TSA23 = 23,
        TSA24 = 24,
        TSA25 = 25,
        TSA30 = 30,
        TSA35 = 35,
        TSA40 = 40,
        TSA45 = 45,
        TSA50 = 50,
        TSA55 = 55
    }

    public enum TextSpacingBefore
    {
        TSB0 = 0,
        TSB1 = 1,
        TSB2 = 2,
        TSB3 = 3,
        TSB4 = 4,
        TSB5 = 5,
        TSB6 = 6,
        TSB7 = 7,
        TSB8 = 8,
        TSB9 = 9,
        TSB10 = 10,
        TSB11 = 11,
        TSB12 = 12,
        TSB13 = 13,
        TSB15 = 15,
        TSB16 = 16,
        TSB17 = 17,
        TSB18 = 18,
        TSB19 = 19,
        TSB20 = 20,
        TSB21 = 21,
        TSB22 = 22,
        TSB23 = 23,
        TSB24 = 24,
        TSB25 = 25,
        TSB30 = 30,
        TSB35 = 35,
        TSB40 = 40,
        TSB45 = 45,
        TSB50 = 50,
        TSB55 = 55
    }

    public enum TextRotation
    {
        R0 = 0,
        R90 = 0,
        R180 = 180,
        R270 = 270,
        R360 = 360
    }
    #endregion

    public class ParagraphFunction
    {
        /// <summary>
        /// font -> Recibe parametros Tipo de Texto.
        /// </summary>
        /// <param name="FontText"></param>
        /// <returns></returns>
        public static Font font(string FontText)
        {
            return new Font(FontFactory.GetFont(FontText));
        }
        /// <summary>
        /// font -> Recibe parametros Tipo de Texto, Tamaño de Texto.
        /// </summary>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <returns></returns>
        public static Font font(string FontText, float SizeText)
        {
            return new Font(FontFactory.GetFont(FontText, SizeText));
        }
        /// <summary>
        /// font -> Recibe parametros Tipo de Texto, Tamaño de Texto, Formato De Texto.
        /// </summary>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="FormatTex"></param>
        /// <returns></returns>
        public static Font font(string FontText, float SizeText, int FormatTex)
        {
            return new Font(FontFactory.GetFont(FontText, SizeText, FormatTex));
        }
        /// <summary>
        /// font -> Recibe parametros Tipo de Texto, Tamaño de Texto, Formato De Texto, Color De Texto.
        /// </summary>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="FormatTex"></param>
        /// <param name="ColorTex"></param>
        /// <returns></returns>
        public static Font font(string FontText, float SizeText, int FormatTex, BaseColor ColorTex)
        {
            return new Font(FontFactory.GetFont(FontText, SizeText, FormatTex, ColorTex));
        }
        /// <summary>
        /// font -> Recibe parametros Tipo de Texto, Tamaño de Texto, Color De Texto.
        /// </summary>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="ColorTex"></param>
        /// <returns></returns>
        public static Font font(string FontText, float SizeText, BaseColor ColorTex)
        {
            return new Font(FontFactory.GetFont(FontText, SizeText, ColorTex));
        }

        /// <summary>
        /// paragraph, Recibe los siguientes parametros, Texto
        /// </summary>
        /// <param name="Tex"></param>
        /// <returns></returns>
        public static Paragraph paragraph(string Text)
        {
            return new Paragraph(Text);
        }
        /// <summary>
        /// paragraph, Recibe los siguientes parametros, Texto, Fuente Texto
        /// </summary>
        /// <param name="Tex"></param>
        /// <param name="FontText"></param>
        /// <returns></returns>
        public static Paragraph paragraph(string Text, string FontText)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Font = FontFactory.GetFont(FontText);
            paragraph.Add(Text);
            return paragraph;
        }
        /// <summary>
        /// paragraph, Recibe los siguientes parametros, Texto, Fuente Texto, Alineación Texto
        /// </summary>
        /// <param name="Tex"></param>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="AlignText"></param>
        /// <returns></returns>
        public static Paragraph paragraph(string Text, string FontText, float SizeText, sbyte AlignText)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Alignment = AlignText;            
            paragraph.Font = FontFactory.GetFont(FontText, SizeText);
            paragraph.Add(Text);
            return paragraph;
        }
        /// <summary>
        /// paragraph, Recibe los siguientes parametros, Texto, Fuente Texto, Alineación Texto, Formato de Texto
        /// </summary>
        /// <param name="Tex"></param>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="AlignText"></param>
        /// <param name="FormatTex"></param>
        /// <returns></returns>
        public static Paragraph paragraph(string Text, string FontText, float SizeText, sbyte AlignText, sbyte FormatTex)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Alignment = AlignText;
            paragraph.Font = FontFactory.GetFont(FontText, SizeText, FormatTex);
            paragraph.Add(Text);
            return paragraph;
        }
        /// <summary>
        /// paragraph, Recibe los siguientes parametros, Texto, Fuente Texto, Alineación Texto, Formato de Texto, Color De Texto
        /// </summary>
        /// <param name="Tex"></param>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="AlignText"></param>
        /// <param name="FormatTex"></param>
        /// <param name="ColorTex"></param>
        /// <returns></returns>
        public static Paragraph paragraph(string Text, string FontText, float SizeText, sbyte AlignText, sbyte FormatTex, BaseColor ColorTex)
        {

            Font f = FontFactory.GetFont(FontText, SizeText, FormatTex, ColorTex);
            Chunk background = new Chunk(Text, f);
            Paragraph paragraph = new Paragraph(background);
            paragraph.Alignment = AlignText;
            return paragraph;
        }
        /// <summary>
        /// paragraph, Recibe los siguientes parametros, Texto, Fuente Texto, Alineación Texto, Formato de Texto, Color De Texto, Color de Fondo
        /// </summary>
        /// <param name="Tex"></param>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="AlignText"></param>
        /// <param name="FormatTex"></param>
        /// <param name="ColorTex"></param>
        /// <param name="BackgroundP"></param>
        /// <returns></returns>
        public static Paragraph paragraph(string Text, string FontText, float SizeText, sbyte AlignText, sbyte FormatTex, BaseColor ColorTex, BaseColor BackgroundP)
        {
            Font f = FontFactory.GetFont(FontText, SizeText, FormatTex, ColorTex);
            Chunk background = new Chunk(Text, f);
            background.SetBackground(BackgroundP);
            Paragraph paragraph = new Paragraph(background);
            paragraph.Alignment = AlignText;
            return paragraph;
        }
        /// <summary>
        /// paragraph, Recibe los siguientes parametros, Texto, Fuente Texto, Alineación Texto, Formato de Texto, Espacio de Parrafo Despues, Espacio de Parrafo Antes
        /// </summary>
        /// <param name="Tex"></param>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="AlignText"></param>
        /// <param name="FormatTex"></param>
        /// <param name="SpacingTextAfter"></param>
        /// <param name="SpacingTextBefore"></param>
        /// <returns></returns>
        public static Paragraph paragraph(string Text, string FontText, float SizeText, sbyte AlignText, sbyte FormatTex, float SpacingTextAfter, float SpacingTextBefore)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.SpacingAfter = SpacingTextAfter;
            paragraph.SpacingBefore = SpacingTextBefore;
            paragraph.Alignment = AlignText;
            paragraph.Font = FontFactory.GetFont(FontText, SizeText, FormatTex);
            paragraph.Add(Text);
            return paragraph;
        }
        /// <summary>
        /// /// paragraph, Recibe los siguientes parametros, Texto, Fuente Texto, Alineación Texto, Espacio de Parrafo Despues, Espacio de Parrafo Antes
        /// </summary>
        /// <param name="Tex"></param>
        /// <param name="FontText"></param>
        /// <param name="SizeText"></param>
        /// <param name="AlignText"></param>
        /// <param name="SpacingTextAfter"></param>
        /// <param name="SpacingTextBefore"></param>
        /// <returns></returns>
        public static Paragraph paragraph(string Text, string FontText, float SizeText, sbyte AlignText, float SpacingTextAfter, float SpacingTextBefore)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Alignment = AlignText;
            paragraph.SpacingAfter = SpacingTextAfter;
            paragraph.SpacingBefore = SpacingTextBefore;
            paragraph.Font = FontFactory.GetFont(FontText, SizeText);
            paragraph.Add(Text);
            return paragraph;
        }
    }
}