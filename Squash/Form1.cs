using HamScoreboardModel;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Squash
{
    public partial class Form1 : Form
    {
        static string urlSocketServer = ConfigurationManager.AppSettings["UrlSocketServer"];
        public IHubProxy _hub;
        int minutos, segundos;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            minutos = segundos = 0;
            label1.Text = "00:00";            
            //cronometro.Stop();
            IDictionary<string, string> qs = new Dictionary<string, string>();
            qs.Add("name", Environment.MachineName);
            qs.Add("group", "squash");
            var connection = new HubConnection(urlSocketServer, qs);
            _hub = connection.CreateHubProxy("MarcadorSquashHub");
            connection.Start().Wait();

            _hub.On<Object>("devuelveVisor", (mensaje) =>
            {
                MessageBox.Show("Hoola");
            });

            _hub.On<bool>("HandleControlCronometro", (value) => ControlCronometro(value));
            _hub.On<SBsquash>("HandleActualizarMarcador", (value) => ActualizarMarcador(value));

            pictureBox1 = CornersRounded(pictureBox1);
            pictureBox2 = CornersRounded(pictureBox2);
            pictureBox3 = CornersRounded(pictureBox3);
            pictureBox4 = CornersRounded(pictureBox4);            
        }

        private void cronometro_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos == 60)
            {
                minutos++;
                segundos = 0;
            }
            label1.Text = string.Format("{0}:{1}", minutos.ToString().PadLeft(2,'0'), segundos.ToString().PadLeft(2, '0'));
        }


        public void ControlCronometro(bool value) {
            cronometro.Enabled = true;
            if (value)
                cronometro.Start();            
            else
                cronometro.Stop();
        }

        public void ActualizarMarcador(SBsquash value)
        {
            label2.Text = value.Periodo;
            label3.Text = value.ScoreA.ToString();
            label4.Text = value.ScoreB.ToString();
            label5.Text = value.TeamA.Nombre;
            label6.Text = value.TeamB.Nombre;
            pictureBox1.Load(value.TeamA.FotoUrl);
            pictureBox4.Load(value.TeamB.FotoUrl);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;            
        }

        public PictureBox CornersRounded(PictureBox pic1)
        {
            Rectangle r = new Rectangle(0, 0, pic1.Width, pic1.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = 24;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            pic1.Region = new Region(gp);
            return pic1;
        }
        //private void button1_Click(object sender, EventArgs e)
        //{                        
        //    ThreadStart delegado = new ThreadStart(() => {
        //        System.Threading.Thread.Sleep(5000);
        //        MessageBox.Show("Esto se ejecuta en hilo aparte");
        //    });
        //    Thread hilo = new Thread(delegado);
        //    hilo.Start();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Este es el hilo normal ");
        //}
    }
}
