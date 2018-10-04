using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamReportsModel.Acreditacion
{
    public class CredencialPluris
    {
        public int PersonaId { get; set; }
        public int EventoId { get; set; }
        public DataTable DatosPersonales { get; set; }
        public DataTable DatosPrivilegios { get; set; }

        private string Usuario { get; set; }
        private string Codigo { get; set; }
        private string Delegacion { get; set; }
        private string Representacion { get; set; }
        private int DelegacionId { get; set; }

        private string Nombre;
        private string TipoPersona;
        private string CodigoRol;
        private int ColorCodigoRol;
        private int ColorAccesos;
        private List<PrivilegioReporte> Privilegios = new List<PrivilegioReporte>();

        public string PathResources;
        private string PathImagenes;
        private Document doc = new Document(new Rectangle(283f, 454f), 0f, 0f, 0f, 0f);
        public CredencialPluris(DataTable datosPersonales, DataTable datosPrivilegios, string pathResources)
        {
            this.DatosPersonales = datosPersonales;
            this.DatosPrivilegios = datosPrivilegios;
            this.PathResources = pathResources;
            this.PathImagenes = string.Format(@"{0}Images\", PathResources);
            if (DatosPersonales.Rows.Count > 0)
            {
                DataRow dr = DatosPersonales.Rows[0];
                this.Nombre = string.Format("{0} {1} {2}", dr["Nombres"].ToString(), dr["Paterno"].ToString(), dr["Materno"], ToString());
                this.TipoPersona = dr["Rol"].ToString();
                this.CodigoRol = dr["Codigo"].ToString();
                this.ColorCodigoRol = Convert.ToInt32(dr["Color"].ToString().Substring(1), 16);
                this.Delegacion = string.Format("{0} {1}", dr["Nombre"].ToString(), string.IsNullOrEmpty(dr["Distrito"].ToString()) ? "" : "- " + dr["Distrito"].ToString());
                this.Representacion = dr["Representacion"].ToString();
                this.DelegacionId = Convert.ToInt32(dr["DelegacionId"]);
                this.Codigo = "2426";
                this.Usuario = "admin";
            }
            if (DatosPrivilegios.Rows.Count > 0)
            {
                foreach (DataRow dr in DatosPrivilegios.Rows)
                {
                    this.Privilegios.Add(new PrivilegioReporte(Convert.ToInt32(dr["Posicion"]), dr["Codigo"].ToString(), dr["Privilegio"].ToString(), (TipoPrivilego)(dr["ParametroTipoMostrarId"]), Convert.ToInt32(dr["Orden"])));
                }
                List<PrivilegioReporte> colorAccesos = this.Privilegios.FindAll(x => x.Posicion == 5 && x.Tipo == TipoPrivilego.Color);
                this.ColorAccesos = Convert.ToInt32(colorAccesos[0].Descripcion.Substring(1), 16);
            }
        }

        public string GenerarCredencial()
        {
            string fileName = string.Empty;
            #region iniciandoDocumento
            doc.AddAuthor("CODESUR");
            doc.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
            fileName = string.Format("CredencialAcreditacion_{0}_{1:yyyyMMddHHss}.pdf", Usuario, DateTime.Now);
            string path = PathResources;
            path = string.Format("{0}Reportes\\{1}", path, fileName);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            #endregion
            try
            {
                AgregarFondoAnverso();
                AgregarFoto();
                AgregarQR();
                AgregarCodigoRol();
                AgregarNombre();
                AgregarDatosDelegacion();
                AgregarPrivilegios();
                AgregarFondoReverso();
                AgregarCodigoBarras(wri);
                AgregarTextoFoto();
                AgregarNombreReverso();
                AgregarPrivilegiosReverso();
                PdfContentByte cb = wri.DirectContent;
                //PdfPTable table = new PdfPTable(1);
                ////PdfPCell[] cells = new PdfPCell[] { new PdfPCell(new Phrase("HOLAAA"))};
                ////PdfPRow p = new PdfPRow(cells);
                ////p.
                //table.TotalWidth = 400f;
                //table.AddCell("Test");
                //table.WriteSelectedRows(0, -1, 200, 50, cb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                doc.Close();
            }
            Spire.License.LicenseProvider.SetLicenseFileFullPath(@"C:\Hammer\ExternalReferences\license.lic");
            Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();
            try
            {
                pdfdocument.LoadFromFile(path);
                if (File.Exists(path))
                    File.Delete(path);
                Document realDoc = new Document(new Rectangle(566f, 454f), 0f, 0f, 0f, 0f);
                PdfPTable Reporte = new PdfPTable(new float[] { 283f, 283f });
                Reporte.WidthPercentage = 100;
                for (int i = 0; i < pdfdocument.Pages.Count; i++)
                {
                    System.Drawing.Image image = pdfdocument.SaveAsImage(i, 480, 500);
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    iTextSharp.text.Image imgpdf = iTextSharp.text.Image.GetInstance(ms.ToArray());
                    PdfPCell imgCell = new PdfPCell(imgpdf, true);
                    Reporte.AddCell(imgCell);
                }
                PdfWriter realWri = PdfWriter.GetInstance(realDoc, new FileStream(path, FileMode.Create));
                realDoc.Open();
                realDoc.Add(Reporte);


                realDoc.Close();
            }
            catch
            {
            }
            return path;
        }

        void AgregarFondoAnverso()
        {
            string pathImagenes = PathImagenes;
            Image fondo = Image.GetInstance(string.Format(@"{0}\\AcreditacionAnv.png", pathImagenes));
            fondo.ScalePercent(23.5f);
            fondo.SetAbsolutePosition(0f, 0f);
            fondo.Alignment = iTextSharp.text.Image.UNDERLYING;
            doc.Add(fondo);
        }

        void AgregarFoto()
        {

            string rutaImg = string.Format(@"C:\HammerResources\Images\erpDeportes\{0}.png", this.PersonaId);
            rutaImg = File.Exists(rutaImg) ? rutaImg : string.Format(@"C:\HammerResources\Images\user.png");

            Image imagenFoto = Image.GetInstance(rutaImg);
            imagenFoto.SetAbsolutePosition(11.5f, 300.5f);
            imagenFoto.ScaleToFit(83f, 110.5f);
            doc.Add(imagenFoto);
        }

        void AgregarQR()
        {
            string QR = string.Format("http://www.cochabamba2018.bo/Acreditacion/{0}/{1}", this.EventoId, this.PersonaId);
            BarcodeQRCode bcq = new BarcodeQRCode(QR, 10, 10, null);
            iTextSharp.text.Image codigoQR = iTextSharp.text.Image.GetInstance(bcq.GetImage());
            codigoQR.Alignment = iTextSharp.text.Image.UNDERLYING;
            codigoQR.ScaleToFit(65, 65);
            codigoQR.SetAbsolutePosition(210f, 136f);
            doc.Add(codigoQR);
        }

        void AgregarCodigoBarras(PdfWriter wri)
        {
            PdfContentByte cb = wri.DirectContent;
            Barcode128 bar128 = new Barcode128();
            int codigoBarra = Convert.ToInt32(string.Format("{0}{1}", this.EventoId * 10000, this.PersonaId));
            bar128.Code = codigoBarra.ToString("X");
            Image img128 = bar128.CreateImageWithBarcode(cb, null, null);
            img128.ScaleToFit(70, 100);
            img128.SetAbsolutePosition(198f, 90f);
            doc.Add(img128);
        }

        void AgregarCodigoRol()
        {
            PdfPTable tablaCodigoRol = new PdfPTable(new float[] { 103f, 165.5f, 14f });
            doc.Add(new Paragraph("\n"));
            tablaCodigoRol.SpacingBefore = 80.5f;
            tablaCodigoRol.WidthPercentage = 100;
            PdfPCell celda2 = new PdfPCell(new Phrase(this.CodigoRol, FontFactory.GetFont("VERDANA", 36, iTextSharp.text.Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, Border = 0, PaddingBottom = 15.5f, PaddingTop = 3.5f };
            celda2.BackgroundColor = new BaseColor(ColorCodigoRol);
            PdfPCell celda3 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            tablaCodigoRol.AddCell(celda3);
            tablaCodigoRol.AddCell(celda2);
            tablaCodigoRol.AddCell(celda3);
            doc.Add(tablaCodigoRol);
        }

        void AgregarNombre()
        {
            PdfPTable tablaNombre = new PdfPTable(1);
            tablaNombre.WidthPercentage = 95;
            PdfPCell celda = new PdfPCell(new Phrase(this.Nombre, FontFactory.GetFont("VERDANA", 19, iTextSharp.text.Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = 0, Border = 0, FixedHeight = 45 };
            tablaNombre.AddCell(celda);
            doc.Add(tablaNombre);
        }

        void AgregarDatosDelegacion()
        {
            PdfPTable tablaDatos = new PdfPTable(1);
            tablaDatos.WidthPercentage = 95;
            PdfPCell celda1 = new PdfPCell(new Phrase(this.TipoPersona, FontFactory.GetFont("VERDANA", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = 0, Border = 0 };
            tablaDatos.AddCell(celda1);
            celda1 = new PdfPCell(new Phrase(this.Delegacion, FontFactory.GetFont("VERDANA", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = 0, Border = 0 };
            tablaDatos.AddCell(celda1);
            celda1 = new PdfPCell(new Phrase(this.Representacion, FontFactory.GetFont("VERDANA", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = 0, Border = 0 };
            tablaDatos.AddCell(celda1);
            Image imagenDelegacion = Image.GetInstance(string.Format(@"C:\HammerResources\Images\Delegaciones\{0}.png", this.DelegacionId));
            imagenDelegacion.ScaleAbsolute(30f, 30f);
            tablaDatos.AddCell(new PdfPCell(imagenDelegacion) { Border = PdfPCell.NO_BORDER });
            doc.Add(tablaDatos);
        }

        void AgregarPrivilegios()
        {
            RoundRectangle rr = new RoundRectangle();
            Paragraph p = new Paragraph();
            p.IndentationLeft = 8;
            List<PrivilegioReporte> privilegios = this.Privilegios.FindAll(x => x.Posicion == 3);
            PdfPTable tablaDatos = new PdfPTable(privilegios.Count > 4 ? 4 : privilegios.Count) { HorizontalAlignment = Element.ALIGN_LEFT };
            tablaDatos.SpacingBefore = 10;
            tablaDatos.WidthPercentage = privilegios.Count > 4 ? 60 : privilegios.Count * 15;
            PdfPCell celda1;
            foreach (PrivilegioReporte item in privilegios)
            {
                celda1 = new PdfPCell(new Phrase(item.Descripcion, FontFactory.GetFont("VERDANA", 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = 1, CellEvent = rr, Border = PdfPCell.NO_BORDER, PaddingBottom = 6, PaddingTop = 6 };
                tablaDatos.AddCell(celda1);
            }
            if (privilegios.Count > 4)
            {
                for (int i = 0; i < 8 - privilegios.Count; i++)
                {
                    celda1 = new PdfPCell(new Phrase("")) { Border = 0 };
                    tablaDatos.AddCell(celda1);
                }
            }
            p.Add(tablaDatos);
            //doc.Add(p);
            
            //PdfPTable tablaDatosAccesos = new PdfPTable(accesos.Count);
            //tablaDatosAccesos.SpacingBefore = 20;
            //tablaDatosAccesos.WidthPercentage = accesos.Count > 5 ? 90 : accesos.Count * 18;
            //foreach (PrivilegioReporte item in accesos)
            //{
            //    celda1 = new PdfPCell(new Phrase(item.Descripcion, FontFactory.GetFont("VERDANA", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = 1, Padding = 4 };
            //    tablaDatosAccesos.AddCell(celda1);
            //}
            //doc.Add(tablaDatosAccesos);

            float espacioTabla1 = tablaDatos.TotalHeight;
            float espacioTabla2 = tablaDatos.TotalHeight;
            AgregarCodigo(123);
        }

        void AgregarCodigo(float spacing)
        {

            PdfPTable tablaCodigoRol = new PdfPTable(new float[] { 11f, 41.6f, 41.6f, 41.6f, 41.6f, 41.6f, 41.6f, 13.5f });
            tablaCodigoRol.SpacingBefore = spacing - 35;
            tablaCodigoRol.WidthPercentage = 100;

            PdfPCell celda1 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            tablaCodigoRol.AddCell(celda1);
            List<PrivilegioReporte> privilegios = this.Privilegios.FindAll(x => x.Posicion == 4);
            foreach (PrivilegioReporte item in privilegios)
            {
                celda1 = new PdfPCell(new Phrase(item.Privilegio, FontFactory.GetFont("VERDANA", 36, iTextSharp.text.Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = 1, Border = PdfPCell.NO_BORDER, PaddingBottom = 14, PaddingTop = 5 };
                celda1.BackgroundColor = new BaseColor(this.ColorCodigoRol);                
            }
            celda1.Colspan = 6;
            tablaCodigoRol.AddCell(celda1);
            //for (int i = 1; i <= 7; i++)
            //{
            //    List<PrivilegioReporte> privilegios = this.Privilegios.FindAll(x => x.Posicion == 5 && x.Orden == i);
            //    if (privilegios.Count > 0)
            //    {
            //        if (privilegios[0].Tipo != TipoPrivilego.Color)
            //        {
            //            celda1 = new PdfPCell(new Phrase(privilegios[0].Descripcion, FontFactory.GetFont("VERDANA", 36, iTextSharp.text.Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, Border = 0, PaddingBottom = 14, PaddingTop = 5 };
            //            celda1.BackgroundColor = new BaseColor(this.ColorAccesos);
            //            tablaCodigoRol.AddCell(celda1);
            //        }
            //    }
            //    else
            //    {
            //        celda1 = new PdfPCell(new Phrase("", FontFactory.GetFont("VERDANA", 36, iTextSharp.text.Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, Border = 0, PaddingBottom = 14, PaddingTop = 5 };
            //        celda1.BackgroundColor = new BaseColor(this.ColorAccesos);
            //        tablaCodigoRol.AddCell(celda1);
            //    }
            //}
            PdfPCell celda3 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            tablaCodigoRol.AddCell(celda3);
            doc.Add(tablaCodigoRol);
        }

        void AgregarFondoReverso()
        {
            string pathImagenes = PathImagenes;
            doc.NewPage();
            doc.Add(new Paragraph(" "));
            iTextSharp.text.Image fondo2 = iTextSharp.text.Image.GetInstance(string.Format(@"{0}\\AcreditacionRev.png", pathImagenes));
            fondo2.ScalePercent(23.5f);
            fondo2.SetAbsolutePosition(0f, 0f);
            doc.Add(fondo2);
        }

        void AgregarTextoFoto()
        {
            string textoReverso = "Al usar esta acreditación acepto ser fotografiado, identificado y registrado por Cochabamba 2018 y terceros autorizados por la organización, estas grabaciones podrán ser usadas con uso comercial a no comercial sin pago alguno por la máxima duración permitida por ley en cualquier formato y mediante cualquier medio la promoción de las actividades indirectamente relacionadas con los juegos";
            PdfPTable tablaCodigoTexto = new PdfPTable(1);
            tablaCodigoTexto.SpacingBefore = 10;
            tablaCodigoTexto.WidthPercentage = 95;
            PdfPCell celda = new PdfPCell(new Phrase(textoReverso, FontFactory.GetFont("VERDANA", 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED, Border = 0 };
            tablaCodigoTexto.AddCell(celda);
            doc.Add(tablaCodigoTexto);

            string rutaImg = string.Format(@"C:\HammerResources\Images\erpDeportes\{0}.png", this.PersonaId);
            rutaImg = File.Exists(rutaImg) ? rutaImg : string.Format(@"C:\HammerResources\Images\user.png");
            Image imagenFoto = Image.GetInstance(rutaImg);
            imagenFoto.SetAbsolutePosition(14.2f, 290f);
            imagenFoto.ScaleToFit(55.3f, 75f);
            doc.Add(imagenFoto);
        }

        void AgregarNombreReverso()
        {
            PdfPTable tablaNombre = new PdfPTable(new float[] { 90f, 179f, 14f });
            tablaNombre.WidthPercentage = 100;
            tablaNombre.SpacingBefore = 15;
            PdfPCell celda1 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            PdfPCell celda2 = new PdfPCell(new Phrase(this.Nombre, FontFactory.GetFont("VERDANA", 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = 0, Border = 0, FixedHeight = 28 };
            PdfPCell celda3 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            tablaNombre.AddCell(celda1);
            tablaNombre.AddCell(celda2);
            tablaNombre.AddCell(celda3);

            celda1 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            tablaNombre.AddCell(celda1);
            celda1 = new PdfPCell(new Phrase(this.TipoPersona, FontFactory.GetFont("VERDANA", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = 0, Border = 0 };
            tablaNombre.AddCell(celda1);
            celda1 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            tablaNombre.AddCell(celda1);
            celda1 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            tablaNombre.AddCell(celda1);
            celda1 = new PdfPCell(new Phrase(this.Delegacion, FontFactory.GetFont("VERDANA", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = 0, Border = 0 };
            tablaNombre.AddCell(celda1);
            celda1 = new PdfPCell(new Phrase("")) { HorizontalAlignment = 1, Border = 0 };
            tablaNombre.AddCell(celda1);
            doc.Add(tablaNombre);
        }

        void AgregarPrivilegiosReverso()
        {
            PdfPTable contenedor = new PdfPTable(1);
            contenedor.WidthPercentage = 90;
            PdfPTable tablaFila = new PdfPTable(new float[] { 30f, 100f, 30f, 100f });
            tablaFila.WidthPercentage = 100;
            PdfPCell celda1;
            foreach (PrivilegioReporte privilegio in this.Privilegios)
            {
                if (privilegio.Tipo == TipoPrivilego.Color)
                {
                    celda1 = new PdfPCell(new Phrase("")) { };
                    celda1.BackgroundColor = new BaseColor(Convert.ToInt32(privilegio.Descripcion.Substring(1), 16));
                }
                else
                {
                    celda1 = new PdfPCell(new Phrase(privilegio.Descripcion, FontFactory.GetFont("VERDANA", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = PdfPCell.ALIGN_CENTER };
                }
                tablaFila.AddCell(celda1);
                celda1 = new PdfPCell(new Phrase(privilegio.Privilegio, FontFactory.GetFont("VERDANA", 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED, Border = 0 };
                tablaFila.AddCell(celda1);
            }
            if (this.Privilegios.Count % 2 == 1)
            {
                celda1 = new PdfPCell(new Phrase("")) { Border = 0 };
                tablaFila.AddCell(celda1);
                tablaFila.AddCell(celda1);
            }
            celda1 = new PdfPCell(tablaFila) { Border = 0, PaddingTop = 10 };
            contenedor.AddCell(celda1);
           // doc.Add(contenedor);
            float totalAlto = contenedor.TotalHeight;
            totalAlto = 233 - totalAlto;

            AgregarCodigo(totalAlto);
        }
    }
}
