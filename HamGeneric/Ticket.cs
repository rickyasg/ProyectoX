using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace HamGeneric
{
    public class Ticket
    {
        public int Id { get; set; }
        public int tkt { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string estado { get; set; }
        public int mesa { get; set; }
        public string tiempo { get; set; }
        public string servicio { get; set; }


        public static Ticket GetTicket(int tktId)
        {
            return Parse(tktId);
        }

        public static List<Ticket> GetTickets()
        { int x = -1;
            List<Ticket> lcp = new List<Ticket>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("erp.vTicket");
            foreach (DataRow dr in dt.Rows)
            {
             Ticket cp = ConvertToTicket(dr);
                if (cp.estado == "False" && (cp.fecha.CompareTo(DateTime.Now.ToShortDateString())) == 1)
                {
                    lcp.Add(cp);
                    x++;
                }

            }
            if (x == -1)
                return null;
            else
                return lcp;
        }
        public static List<Ticket> GetAsignados()
        {
            List<Ticket> lcp = new List<Ticket>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("erp.vAsignacionTicket");
            foreach (DataRow dr in dt.Rows)
            {
                Ticket cp = ConvertToTicket2(dr);
                if ( (cp.fecha.CompareTo(DateTime.Now.ToShortDateString())== 1 ) && (cp.servicio=="TTT") )
                        lcp.Add(cp);
            }
            return lcp;
        }
        public static int SetTicket(string f, string h, int n)
        {
          
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Fecha",DateTime.Now));
            ps.Add(new SqlParameter("Hora", DateTime.Now));
            ps.Add(new SqlParameter("Numero", n));
            ps.Add(new SqlParameter("Estado", "0"));
            procedimiento = "erp.pInsTicket";

            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedimiento, ps);
            return (db.RowAffected);

        }
        public static int Cerrar(Ticket tt)
        {

            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("tickeId", tt.Id));
            ps.Add(new SqlParameter("tiempo", tt.tiempo));
            ps.Add(new SqlParameter("servi", tt.servicio));
            procedimiento = "erp.pUpCerrar";

            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedimiento, ps);
            return (db.RowAffected);

        } 
        public static int Asignar(Ticket TT)
        {
            
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("TicketId", TT.Id));
            ps.Add(new SqlParameter("Mesa",TT.mesa));
            ps.Add(new SqlParameter("fecha", TT.fecha));
            ps.Add(new SqlParameter("tkt", TT.tkt));
            
            procedimiento = "erp.pInsAsignar";

            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedimiento, ps);
            return (db.RowAffected);

        }

        public static int Llamado(int IDticket)
        {
           
            string procedimiento;
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("TicketId", IDticket));
            procedimiento = "erp.pUpTicket";

            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedimiento, ps);
            return (db.RowAffected);

        }

        public static int Imprimir(Evento S)
        {
            FileStream fs = new FileStream("ticket0"+S.Version+".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document(PageSize.A7,2f,2f,5f,5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            


            var titleFont = FontFactory.GetFont("Arial", 42, 1,BaseColor.BLACK);
            var font2 = FontFactory.GetFont("Arial", 14, 0, BaseColor.BLACK);
            Paragraph Para = new Paragraph(S.Version,titleFont);
            Para.Alignment = Element.ALIGN_CENTER;
            Paragraph Para1 = new Paragraph("JUEGOS "+S.Nombre, font2);
            Para1.Alignment = Element.ALIGN_CENTER;
            Paragraph Para2 = new Paragraph(DateTime.Now.ToShortDateString(), font2);
            Para2.Alignment = Element.ALIGN_CENTER;
            Paragraph Para3 = new Paragraph(DateTime.Now.ToShortTimeString(), font2);
            Para3.Alignment = Element.ALIGN_CENTER;
            Paragraph Para4 = new Paragraph("Espere Su turno Gracias", font2);
            Para4.Alignment = Element.ALIGN_CENTER;


            doc.Open();
     
            doc.Add(Para1);
            try
            {
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("../../Hammer/HamPresentation/erpHammerClient/src/assets/0"+S.EventoId+"/logos/logo1.png");
                jpg.Alignment = Element.ALIGN_CENTER;
                jpg.ScaleToFit(70f, 32f);
                doc.Add(jpg);
            }
            catch (Exception ex) {  }
            
            doc.Add(Para2);
            doc.Add(Para3);
            doc.Add(new Paragraph("              Tiket Nro."));
            doc.Add(Para);
            doc.Add(Para4);
            doc.Close();
            //Response.ContentType = "pdf/application";
            //Response.AddHeader("content-disposition", "attachment;filename=First_PDF_document.pdf");
            //Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.Verb = "Print";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //proc.StartInfo.Verb = "Print";
            proc.StartInfo.FileName = "ticket0" + S.Version + ".pdf";
           
            proc.Start();
            proc.WaitForExit();
            proc.Close();
            return 1;
        }

        private static Ticket ConvertToTicket(DataRow dr)
        {
            Ticket cg = new Ticket();
            if (dr != null)
            {
                cg.Id = Convert.ToInt32(dr["TicketId"]);
                cg.tkt = Convert.ToInt32(dr["numero"]);
                cg.fecha = Convert.ToString(dr["Fecha"]);
                cg.hora = Convert.ToString(dr["Hora"]);
                cg.estado = Convert.ToString(dr["Estado"]);

            }
            return cg;
        }



        private static Ticket ConvertToTicket2(DataRow dr)
        {
            Ticket cg = new Ticket();
            if (dr != null)
            {
                cg.Id = Convert.ToInt32(dr["TicketId"]);
                cg.tkt = Convert.ToInt32(dr["tkt"]);
                cg.fecha = Convert.ToString(dr["Fecha"]);
                cg.servicio = Convert.ToString(dr["Servicio"]);
                cg.mesa = Convert.ToInt32(dr["Mesa"]);
                cg.tiempo = Convert.ToString(dr["tiempo"]);
            }
            return cg;
        }


        private static Ticket Parse(int tktId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(Id), tktId);
            DataRow dr = db.GetDataRow("vTicket", fields);
            Ticket cp = ConvertToTicket(dr);
            return cp;
        }

        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("TicketId", Id));
            ps.Add(new SqlParameter("Numero", tkt));
            ps.Add(new SqlParameter("Fecha", fecha));
            ps.Add(new SqlParameter("Hora", hora));
            ps.Add(new SqlParameter("Estado", estado));
            return ps;
        }

        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
       
    }

}
