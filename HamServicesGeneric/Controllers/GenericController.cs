using System;
using System.Collections.Generic;
using System.Web.Http;
using HamGeneric;
using System.Data;

namespace HamServicesGeneric.Controllers
{
    public class GenericController : ApiController
    {
        #region Get Parametros


        [HttpGet]
        public List<Resources> Getresources()
        {
            return Resources.GetReources();
        }
        [HttpGet]
        public List<Parametros> GetParametros()
        {
            return Parametros.GetParametros();
        }

        [HttpGet]
        public List<Parametros> GetParametros(int codigo)
        {
            return Parametros.GetParametros(codigo);
        }

        #endregion
        [HttpGet]
        public List<Persona> GetDeportista(string search, int eventoId, int DelegacionId)
       {
            return Persona.SearchPersonaEvento(search,eventoId, DelegacionId);
        }

        #region Gets Evento
        [HttpGet]
        public DataTable GetFechaEvento(int eventoId)
        {
            return Evento.getFechaEvento(eventoId);
        }

        [HttpGet]
        public Evento GetEvento(int eventoId)
        {
            return Evento.getEvento(eventoId);
        }


        [HttpGet]
        public List<Ticket> GetTickets ()
        {
            return Ticket.GetTickets();
        }
        [HttpGet]
        public List<Ticket> GetAsignados()
        {
            return Ticket.GetAsignados();
        }

        #endregion

        #region Gets Acreditacion
        [HttpGet]
        public List<Grupo> GetGrupos(int eventoId=1)
        {
            return Grupo.getGrupos(eventoId);
        }
        [HttpGet]
        public List<Rol> GetRoles()
        {
            return Rol.getRoles();
        }
        [HttpGet]
        public List<Rol> GetRolGrupo(int grupoId)
        {
            return Rol.getRolGrupo(grupoId);
        }
        [HttpGet]
        public Persona GetAcreditacionPersona(int personaId)
        {
            return Persona.GetPersona(personaId);
        }

 
        [HttpGet]
        public DataTable GetAcreditacionDetallePersona(int personaId)
        {
            return Persona.GetDetalleAcreditacionPersona(personaId);
        }

        [HttpGet]
        public List<Delegacion> GetDelegaciones(int eventoId)
        {
            return Delegacion.getDelegaciones(eventoId);
        }


        [HttpGet]
        public DataTable GetInscripcionEvento(int eventoId)
        {
            return Persona.GetInscripcionEvento(eventoId);
        }

        [HttpGet]
        public DataTable GetInscripcionEnventoDelegacion(int eventoId, int delegacionId)
        {
            return Persona.GetInscripcionEnventoDelegacion(eventoId, delegacionId);
        }

        [HttpGet]
        public DataTable GetAcreditacionPersonaByCI(string CI)
        {
            return Persona.GetPersonaByCI(CI);
        }

        [HttpGet]
        public List<Persona> SearchPersona(string search)
        {
            return Persona.SearchPersona(search);
        }

        [HttpGet]
        public string GetFotoPersona(int personaId)
        {
            return Persona.GetFotoPersona(personaId);
        }
        #endregion

        #region Post Acreditacion
        [HttpPost]
        public int SaveAcreditacionPersonaInstricta([FromBody] Persona persona)
        {
            return persona.SavePersonaInscrita();
        }
        [HttpPost]
        public int SetTicket([FromBody] int n)
        {
             return Ticket.SetTicket (DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), n);
        }
        [HttpPost]
        public int Asignar([FromBody] Ticket TT)
        {
            return Ticket.Asignar(TT);
        }
        [HttpPost]
        public int Cerrar([FromBody] Ticket TT)
        {
            return Ticket.Cerrar(TT);
        }

        [HttpPost]
        public int Imprimir([FromBody] Evento S)
        {
            return Ticket.Imprimir(S);
        }

        [HttpPost]
        public int Llamado([FromBody] int n)
        {
            return Ticket.Llamado(n);
        }


        [HttpPost]
        public int SaveEquipo([FromBody] Equipo equipo)
        {
            return equipo.SaveEquipo();
        }
        [HttpGet]
        public List<Privilegio> GetPrivilegiosRol(int rolId, int eventoId = 1)
        {
            return Privilegio.getPrivilegioRol(eventoId, rolId);
        }
        #endregion

        #region Programacion
        [HttpGet]
        public List<Deporte> GetDeportes(int eventoId)
        {

            return Deporte.GetDeportes(eventoId);
        }
        [HttpGet]
        public List<DeporteConjunto> GetTipoDeportes(int eventoId, int deporteId)
        {

            return DeporteConjunto.GetEsIndivudual(eventoId, deporteId);
        }
        [HttpGet]
        public List<Prueba> GetPruebas(int eventoId, int deporteId, int esIndividual)
        {
            return Prueba.GetPruebas(eventoId, deporteId, esIndividual);
        }
        [HttpGet]
        public List<RamasPrueba> GetRamaPrueba(int eventoId, int deporteId, int esIndividual, int pruebaId)
        {

            return RamasPrueba.GetRamas(eventoId, deporteId, esIndividual, pruebaId);
        }
        [HttpGet]
        public DataTable GetPruebaEventoIndv(int eventoId, int pruebaId, int parametroRamaId)
        {
            return Cronograma.GetPruebaEventoIndv(eventoId, pruebaId, parametroRamaId);
        }
        [HttpGet]
        public DataTable GetCategoria(int pruebaEventoId)
        {
            return Parametros.GetCategoria(pruebaEventoId);
        }
        [HttpGet]
        public DataTable GetCronogramas(int eventoId=0, int deporteId=0 , int pruebaId = 0, int parametroRamaId = 0, int instalacionId=0)
        {
            return Cronograma.GetCronogramas(eventoId, pruebaId, deporteId, instalacionId, parametroRamaId);
        }
        [HttpPost]
        public bool SaveCronograma([FromBody] Cronograma cronograma)
        {
            return cronograma.SaveCronograma();
        }
        [HttpDelete]
        public bool DeleteCronograma(int cronogramaId)
        {
            return Cronograma.DeleteCronograma(cronogramaId);
        }
        [HttpGet]
        public DataTable GetEquipoConjunto(int cronogramaId, int parametroTipoId, string buscar)
        {
            return Equipo.getEquipoConjunto(cronogramaId, parametroTipoId, buscar);
        }
        [HttpGet]
        public DataTable GetFases(int eventoId, int deporteId, int parametroRamaId, int parametroTipoId)
        {
            return Cronograma.GetFases(eventoId, deporteId, parametroRamaId, parametroTipoId);
        }
        [HttpGet]
        public DataTable GetCronogramaFases(int eventoId, int deporteId, int pruebaId, int parametroRamaId, int parametroTipoId, int parametroFaseId)
        {
            return Cronograma.GetCronogramaFase (eventoId, deporteId, pruebaId, parametroRamaId, parametroTipoId, parametroFaseId);
        }
        #endregion

        #region CronogramaCompetidor
        [HttpPost]
        public bool SaveCronogramaCompetidor([FromBody] CronogramaCompetidor cronogramaCompetidor)
        {
            return cronogramaCompetidor.Save();
        }

        [HttpPost]
        public bool UpdateCronogramaEstado(int cronogramaId, int estadoId)
        {
            //return Cronograma.UpdateCronogramaEstado(cronogramaId, estadoId);
            return Cronograma.UpdateCronogramaEstado(cronogramaId, estadoId);
        }

        




        [HttpDelete]
        public bool DeleteCronogramaCompetidor(int cronogramaId, int competidorId)
        {
            return CronogramaCompetidor.DeleteCronogramaCompetidor(cronogramaId, competidorId);
        }
        #endregion
        #region Get Delegacion
        public DataTable GetDelegacion(int competidorId, int eventoId)
        {
            return Delegacion.GetGelegacion(competidorId, eventoId);
        }

       
        #endregion

        #region Instalaciones
        [HttpGet]
        public List<Instalacion> GetInstalaciones()
        {
            return Instalacion.GetInstalaciones();
        }
        [HttpGet]
        public List<Area> GetAreasInstalacion(int InstalacionId)
        {
            return Instalacion.GetAreas(InstalacionId);
        }
        #endregion
    }
}
