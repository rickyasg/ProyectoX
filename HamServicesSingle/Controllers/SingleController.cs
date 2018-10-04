using HamSingleModel;
using System.Data;
using System.Web.Http;


namespace HamServicesSingle.Controllers
{
    public class SingleController : ApiController
    {
        [HttpGet]
        public DataTable GetPlanillaAtletismo(int pruebaEventoId)
        {
            DataTable dt = Atletismo.GetPlanillaAtletismo(pruebaEventoId);
            return dt;
        }
        [HttpPost]
        public int SavePlanilla([FromBody] Atletismo atletismo)
        {
            return atletismo.save();
        }
        [HttpGet]
        public DataTable BusquedaCompetidor(int cronogramaId, string search)
        {
            DataTable dt = Singles.BusquedaCompetidores(search, cronogramaId);
            return dt;
        }
        [HttpGet]
        public DataTable GetCompetidorPrueba(int cronogramaId)
        {
            DataTable dt = Singles.GetCompetidoresPrueba(cronogramaId);
            return dt;
        }
        [HttpPost]
        public int UpdateEstado([FromBody] Atletismo atletismo)
        {
            return atletismo.UpdateEstado();
        }
        [HttpGet]
        public DataTable GetCompetidor(int cronogramaId, int posicion)
        {
            DataTable dt = Singles.GetCompetidor(cronogramaId, posicion);
            return dt;
        }

        #region Metodos Post cronogramacompetidor
        [HttpPost]  
        public bool UpdateCronogramaCompetidor(int cronogramaId, int competidorId, string posicion, int parametromedallaId, int Sembrado, int esGanador, bool esRecord, decimal marca, string tiempo)
        {
            return Singles.UpdateCronograma(cronogramaId, competidorId, posicion, parametromedallaId, Sembrado, marca, esGanador, esRecord, tiempo);
        }
        #endregion

        [HttpGet]
        public int GetPlanilla(int cronogramaId)
        {
            var dt = TiroArco.GetPlanilla(cronogramaId);
            return dt;
        }
        [HttpGet]
        public DataTable GetPersonas(int cronogramaId, int CompetidorId)
        {
            return TiroArco.GetPersonas(cronogramaId, CompetidorId);
        }
        [HttpGet]
        public DataTable GetPuntosPlanilla(int PlanillaId, int CompetidorId, int PeriodoId)
        {
            return punto_tiroArco.GetPuntos( PlanillaId,  CompetidorId,  PeriodoId);
        }
        [HttpGet]
        public int GetPuntajeTiros(int PeriodoId, int PlanillaId, int CompetidorId)
        {
            var dt = punto_tiroArco.GetPuntajeTiros(PeriodoId,PlanillaId,CompetidorId);
            return dt;
        }
        [HttpPost]
        public int savePlanilla_AT([FromBody] TiroArco suceso)
        {
            return suceso.savePlanilla();
        }
        [HttpPost]
        public DataTable CheckPeriodos([FromBody] Periodo_TiroArco suceso)
        {
            return suceso.controlPeriodo();
        }
        [HttpPost]
        public int savePuntos([FromBody] punto_tiroArco punto)
        {
            return punto.savePunto();
        }
        [HttpPost]
        public DataTable cerrarPeriodo([FromBody] Periodo_TiroArco periodo)
        {
            return periodo.cerrarPeriodo();
        }
        [HttpPost]
        public DataTable EliminarPunto([FromBody] punto_tiroArco punto)
        {
            return punto.EliminarPunto();
        }
        [HttpGet]
        public DataTable GetPuntosPlanilla(int PlanillaId, int PeriodoId)
        {
            return Periodo_TiroArco.GetPuntosPlanilla(PlanillaId, PeriodoId);
        }
    }
}
