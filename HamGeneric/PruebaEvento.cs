using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class PruebaEvento
    {
        #region Propiedades

        
        public int PruebaEventoId { get; set; }
        public int EventoId { get; set; }
        public int PruebaId { get; set; }
        public int ParametroRamaId { get; set; }
        public string Color { get; set; }
        public int ParticipanteMin { get; set; }
        public int ParticipanteMax { get; set; }
        public bool EsIndividual { get; set; }
        #endregion

        #region Componentes

        public Prueba Prueba { get; set; }
        public Evento Evento { get; set; }
        #endregion
    }
}
