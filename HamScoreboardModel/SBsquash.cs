using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamScoreboardModel
{
    public class SBsquash
    {
        public string Periodo { get; set; }
        public int ScoreA { get; set; }
        public int ScoreB { get; set; }
        public string Mensaje { get; set; }
        public bool ShowMensaje { get; set; }
        public int Tope { get; set; }
        public CompetidorSquash TeamA { get; set; }
        public CompetidorSquash TeamB { get; set; }

        public SBsquash() { }

    }

    public class CompetidorSquash
    {
        public string CI{ get; set; }
        public int CompetidorId { get; set; }
        public int CronogramaId { get; set; }
        public string Delegacion { get; set; }
        public int EsGanador { get; set; }
        public bool EsRecord { get; set; }
        public string FotoUrl{ get; set; }
        //public string Marca { get; set; }
        public string Medalla { get; set; }
        public string Nombre{ get; set; }
        public int PersonaId { get; set; }
        public int Posicion { get; set; }
        //public string Representacion { get; set; }

    }
}