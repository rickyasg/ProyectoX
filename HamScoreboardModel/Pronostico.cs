using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamScoreboardModel
{
    public class Pronostico
    {
        public string fecha { get; set; }
        public string fecha_larga { get; set; }
        public string Mensaje { get; set; }
        public bool ShowMensaje { get; set; }
        public string humedad { get; set; }
        public string ico_fase_luna { get; set; }
        public string ico_viento { get; set; }
        public string icono { get; set; }
        public string puesta_luna { get; set; }
        public string puesta_sol { get; set; }
        public string salida_luna { get; set; }
        public string salida_sol { get; set; }
        public string temp_maxima { get; set; }
        public string temp_minina { get; set; }
        public string texto { get; set; }
        public string viento { get; set; }


        public Pronostico() { }

    }


}