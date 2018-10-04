using HamSetModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using HamGeneric;
using Grupo = HamSetModel.Grupo;
// ReSharper disable InconsistentNaming


namespace HamServicesSet.Controllers
{
    public class SetController : ApiController
    {
        #region Servicios Post Planilla
        [HttpPost]
        public int SavePlanilla([FromBody] Planilla planilla)
        {
            return planilla.Save();
        }
        [HttpPost]
        public int UpdateHoraInicio(int planillaId, string horaInicio = null)
        {
            return Planilla.UpdateHoraInicio(planillaId, horaInicio);
        }
        [HttpPost]
        public int UpdateHoraFin(int planillaId, string horaFin = null)
        {
            return Planilla.UpdateHoraFin(planillaId, horaFin);
        }
        [HttpPost]
        public int SavePlanillaPersona([FromBody] PlanillaPersona planillaPersona)
        {
            return planillaPersona.Save();
        }
        [HttpPost]
        public bool DeletePlanillaPersona([FromBody] PlanillaPersona planillaPersona)
        {
            return planillaPersona.Delete();
        }
        #endregion
        #region Metodos Post EquipoPersona
        [HttpPost]
        public bool UpdateEquipoPersona(int equipoId, int personaId, int planillaPersonaId, string posicion = "", int nroCamiseta = 0, int parametroRolId = 2, int capitan = 0)
        {
            return EquipoPersona.UpdateEquipoPersona(equipoId, personaId, posicion, nroCamiseta, planillaPersonaId, parametroRolId, capitan);
        }
        #endregion

       
        #region Servicios Post Sucesos
        [HttpPost]
        public bool SaveSuceso([FromBody] Suceso suceso)
        {
            return suceso.SaveSuceso();
        }
        [HttpPost]
        public bool SavePosesionBalon([FromBody] Suceso suceso)
        {
            return suceso.SavePosesionBalon();
        }
        [HttpPost]
        public bool InsSucesosAdicion([FromBody] Suceso suceso)
        {
            return suceso.SaveTiempoAdicion();
        }
        [HttpPost]
        public bool DeletSuceso([FromBody] Suceso suceso)
        {
            return suceso.DeletSuceso();
        }
        [HttpPost]
        public int DeleteSucesosGrupos(int[] sucesos)
        {
            return Suceso.DeleteSucesosGrupo(sucesos);
        }
        #endregion
        #region Servicios Get Sucesos
        [HttpGet]
        public List<DeportePeriodo> GetDeportePeriodo(int eventoId, int deporteId)
        {
            return DeportePeriodo.getDeportePeriodo(eventoId, deporteId);
        }
        [HttpGet]
        public List<ParametrosSuceso> GetParametroSuceso(int deporteId, int control, int visor)
        {
            return ParametrosSuceso.getParametrosSuceso(deporteId, control, visor);
        }
        [HttpGet]
        public List<Suceso> getHistorialSucesos(int planillaId, int deportePeriodoId = 0, int competidorId = 0)
        {
            return Suceso.GetHistorialSuceso(planillaId, deportePeriodoId, competidorId);
        }
        [HttpGet]
        public List<Suceso> getHistorialCronograma(int cronogramaId, int deportePeriodoId = 0, int competidorId = 0)
        {
            return Suceso.GetHistorialCronogramas(cronogramaId, deportePeriodoId, competidorId);
        }
        [HttpGet]
        public DataTable GetSucesoPartido(int competidorId, int planillaId, int deporteId, int control = 1, int visor = 0, int deportePeriodoId = 0)
        {
            return ParametrosSuceso.getSucesoPartido(competidorId, planillaId, deporteId, control, visor, deportePeriodoId);
        }
        [HttpGet]
        public DataTable GetParametroFinalPeriodo(int deporteId)
        {
            return ParametrosSuceso.GetParametroFinalPeriodo(deporteId);
        }
        [HttpGet]
        public int InitPosecion(int deporteId)
        {
            return Suceso.getPosecion(deporteId);
        }

        [HttpGet]
        public int InitTiempoExtra(int deporteId)
        {
            return Suceso.getTiempoExtra(deporteId);
        }
        #endregion

        #region Get Delegacion
        public DataTable GetDelegacion( int eventoId)
        {
            return Equipos.GetGelegacion( eventoId);
        }
        #endregion
        #region Servicios Get 
        [HttpGet]
        public int getDelegacionId(int CompetidorId)
        {
            return Suceso.getDelegacioId(CompetidorId);
        }
        [HttpGet]
        public DataTable getNombrePersona(int PersonaId)
        {
            return Suceso.getNombrePersona(PersonaId);
        }

        [HttpGet]
        public List<Equipos> GetEquiposPrueba(int PruebaEventoId)
        {
            return Equipos.getEquiposPrueba(PruebaEventoId);
        }

        [HttpGet]
        public List<Cronograma> GetGronogramaConjunto(int deporteId, int eventoId, Nullable<DateTime> fecha = null)
        {
            return Cronograma.GetCronogramaConjunto(deporteId, fecha, eventoId);
        }
        [HttpGet]
        public List<Persona> SearchPersonaEquipo(string search, int competidorId, int planillaId = 0)
        {
            return Persona.SearchPersonaEquipo(search, competidorId, planillaId);
        }
        [HttpGet]
        public List<Persona> SearchPersonaApoyo(string search, int eventoId)
        {
            return Persona.SearchPersonaApoyo(search, eventoId);
        }
        [HttpGet]
        public List<HamSetModel.Grupo> GetGruposEquipos(int deporteId, int ramaId, int eventoId, int faseId = 1)
        {
            return HamSetModel.Grupo.GetGruposEquipos(deporteId, ramaId, eventoId, faseId);
        }
        [HttpGet]
        public List<HamSetModel.GrupoEquipo> GetGruposEquipo(int grupoId)
        {
            return GrupoEquipo.GetGrupoEquipo(grupoId);
        }
        [HttpGet]
        public List<HamSetModel.Grupo> GetGrupos(int deporteId, int ramaId, int eventoId, int faseId = 1)
        {
            return HamSetModel.Grupo.GetGrupos(deporteId, ramaId, eventoId, faseId);
        }
        [HttpGet]
        public DataTable GetEquiposDeporte(int deporteId, int ramaId, int eventoId)
        {
            return HamSetModel.Grupo.GetEquiposDeporte(deporteId, ramaId, eventoId);
        }
        [HttpGet]
        public DataTable GetProgramacionConjunto(int eventoId, int delegacionId, int deporteId, DateTime? fecha = null)
        {
            return Cronograma.GetProgramacionConjunto(eventoId, delegacionId, deporteId, fecha);
        }
        [HttpGet]
        public DataTable GetCronogramasFecha(int DeporteId,int eventoId, int PruebaId, int ParametroRamaId, DateTime? fecha = null)
        {
            return Cronograma.GetCronogramasFecha(DeporteId,eventoId, PruebaId, ParametroRamaId, fecha);
        }
        [HttpGet]
        public DataTable GetVolleyPuntos(int cronogramaId)
        {
            return ParametrosSuceso.GetVolleyPuntos(cronogramaId);
        }
        [HttpGet]
        public DataTable GetVolleySet(int eventoId, int planillaId)
        {
            return ParametrosSuceso.GetVolleySet(eventoId, planillaId);
        }
        [HttpGet]
        public DataTable GetPuntosSet(int planillaId, int deportePeriodoId)
        {
            return ParametrosSuceso.GetPuntosSet(planillaId, deportePeriodoId);
        }
        [HttpGet]
        public DataTable GetPuntosBaloncesto(int planillaId)
        {
            return ParametrosSuceso.GetPuntosBaloncesto(planillaId);
        }
        [HttpGet]
        public DataTable GetGruposDeportes(int eventoId, int deporteId, int parametroRamaId = 0)
        {
            return GrupoEquipo.GetGruposDeportes(eventoId, deporteId, parametroRamaId);
        }
        [HttpGet]
        public DataTable GetPuntosPlanilla(int PlanillaId, int DeportePeriodoId)
        {
            return ParametrosSuceso.GetPuntosGenerico(PlanillaId, DeportePeriodoId);
        }
        #endregion
        #region Servicios Get Planilla
        [HttpGet]
        public List<PlanillaPersona> GetPlanillaPersonas(int competidorId, int planillaId, string search="",int parametroRolId=0)
        {
            return PlanillaPersona.GetPlanillaPersonas(competidorId,planillaId,search,parametroRolId);
        }
        [HttpGet]
        public List<PlanillaPersona> GetCapitanPlanilla(int competidorId, int planillaId)
        {
            return PlanillaPersona.GetCapitanPlanilla (competidorId, planillaId);
        }
        [HttpGet]
        public List<PlanillaPersona> GetPlanillaPersonasApoyo(int competidorId, int planillaId, string search = "", int parametroRolId = 0)
        {
            return PlanillaPersona.GetPlanillaPersonasApoyo(competidorId, planillaId, search, parametroRolId);
        }

        [HttpGet]
        public List<EquipoPersona> GetEquiposPersona(int EquipoId)
        {
            return EquipoPersona.getEquiposPersona(EquipoId);
        }

        [HttpGet]
        public List<Equipos> GetEquipos(int EquipoId)
        {
            return Equipos.getEquipos(EquipoId);
        }

        [HttpGet]
        public List<Equipos> GetDeporteEquipos(int EquipoId)
        {
            return Equipos.getDeporteEquipos(EquipoId);
        }




        [HttpGet]
        public List<Planilla> GetPlanilla(int cronogramaId)
        {
            return Planilla.GetPlanilla(cronogramaId);
        }
        #endregion
        #region Servicios Post Programancion
        [HttpPost]
        public int SaveEquipoGrupo([FromBody] GrupoEquipo grupoEquipo)
        {
            return grupoEquipo.SaveEquipoGrupo();
        }

        [HttpPost]
        public bool SaveEquipo([FromBody] Equipos equipos)
        {
            return equipos.SaveEquipo();
        }
        [HttpDelete]
        public bool DeleteEquipo(int EquipoId)
        {
            return Equipos.DeleteEquipo(EquipoId);
        }


        [HttpPost]
        public bool SaveEquipoPersona([FromBody] EquipoPersona equipopersona)
        {
            return equipopersona.SaveEquipoPersona();
        }
        [HttpDelete]
        public bool DeleteEquipoPersona(int EquipoId, int PersonaId)
        {
            return EquipoPersona.DeleteEquipoPersona(EquipoId,PersonaId);
        }




        [HttpGet]
        public int DeleteEquipoGrupo (int grupoId, int equipoId)
        {
            return GrupoEquipo.DeleteEquipoGrupo(grupoId, equipoId);
        }
        [HttpGet]
        public bool CreateFixture(int eventoId, int deporteId, int parametroRamaId)
        {
            return GrupoEquipo.CreateFixture(eventoId, deporteId, parametroRamaId);
        }
        #endregion
        #region Metodos Get EquipoPersona
        [HttpGet]
        public DataTable getEquipoPersona(int competidorId)
        {
            return PlanillaPersona.getEquipoPersona(competidorId);
        }
        [HttpGet]
        public int getPersonaId(int competidorId)
        {
            return PlanillaPersona.getPersonaId(competidorId);
        }
        #endregion

        #region Metodos  Grupo

        [HttpGet]
        public DataTable getGruposPruebasEvento(int PruebaEventoId)
        {
            return Grupo.GetGruposEvento(PruebaEventoId);
        }
        

        [HttpPost]
        public bool SaveGrupo([FromBody] Grupo grupoEquipo)
        {
            return grupoEquipo.InsertGrupos();
        }

        [HttpPost]
        public bool UpdateGrupo([FromBody] Grupo grupoEquipo)
        {
            return grupoEquipo.UpdateGrupos();
        }
        [HttpDelete]
        public bool DeleteGrupo(int GrupoId)
        {
            return Grupo.DeleteGrupo(GrupoId);
        }
        #endregion


        #region metodos ecuestre
        [HttpPost]
        public int saveCompetidor([FromBody] Ecuestre suceso)
        {
            return suceso.saveCompetidor();
        }
        [HttpGet]
        public DataTable GetCompetidoresEcuestre(int cronogramaId, int LeccionId)
        {
            return Ecuestre.GetCompetidoresEcuestre(cronogramaId, LeccionId);
        }
        [HttpPost]
        public int deleteCompetidor(int LeccionCompetidorId)
        {
            return Ecuestre.deleteCompetidor(LeccionCompetidorId);
        }
        [HttpGet]
        public DataTable fGetLecciones(int EventoId)
        {
            return Ecuestre.fGetLecciones(EventoId);
        }
        #endregion
    }
}
