using HamCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HamServicesCommon.Controllers
{
    public class CommonController : ApiController
    {
        #region Servicios Post
        #region Golf Post
        [HttpPost]
        public bool SavePersona([FromBody] Persona persona)
        {
            return persona.Save();
        }

        [HttpPost]
        public bool SaveEventoDeportivo([FromBody] EventoDeportivo evento)
        {
            return evento.Save();
        }

        [HttpPost]
        public int SaveCompetidor([FromBody] Competidor competidor)
        {
            int result = 0;
            if (competidor.Save())
            {
                result = competidor.CompetidorId;
            }
            return result;
        }

        [HttpPost]
        public bool SaveDeportista([FromBody] Deportista deportista)
        {
            return deportista.Save();
        }

        [HttpPost]
        public bool InsertDeporteEnEvento(int eventoId, int disciplinaId, int ubicacionId)
        {
            return EventoDeportivo.InsertDeporteEnEvento(eventoId, disciplinaId, ubicacionId);
        }

        [HttpPost]
        public string SaveImageDeportista(string base64, string imagename, string path)
        {
            return Deportista.SaveImage(base64, imagename, path);
        }
        #endregion

        #region Acreditacion Post
        [HttpPost]
        public int SaveAcreditacionPersonaInstricta([FromBody] AcrePersona persona)
        {
            return persona.SavePersonaInscrita();
        }
        #endregion
        #endregion

        #region Servicios Delete
        #region Golf Deletions
        [HttpDelete]
        public bool DeleteEventoDeportivo(int eventoId)
        {
            EventoDeportivo ced = new EventoDeportivo();
            return ced.DeleteEventoDeportivo(eventoId);
        }

        [HttpDelete]
        public bool DeleteCompetidor(int competidorid)
        {
            Competidor cc = new Competidor();
            return cc.DeleteCompetidor(competidorid);
        }

        [HttpDelete]
        public bool DeleteDeporteEnEvento(int eventoId, int disciplinaId)
        {
            return EventoDeportivo.DeleteDeporteEnEvento(eventoId, disciplinaId);
        }

        [HttpDelete]
        public bool DeleteDeportista(int personaId)
        {
            return Deportista.Delete(personaId);
        }
        #endregion

        #region Acreditacion Deletions

        #endregion
        #endregion

        #region Servicios Get
        #region Programacion
        [HttpGet]
        public List<ProgDeporte> GetDeportes(int eventoId)
        {
          
            return ProgDeporte.GetDeportes(eventoId);
        }
        [HttpGet]
        public List<PrgDeporteConjunto> GetTipoDeportes(int eventoId,int deporteId)
        {

            return PrgDeporteConjunto.GetEsIndivudual(eventoId,deporteId);
        }
        [HttpGet]
        public List<ProgPrueba> GetPruebas(int eventoId, int deporteId, int esIndividual)
        {

            return ProgPrueba.GetPruebas (eventoId, deporteId,esIndividual);
        }
        [HttpGet]
        public List<ProgRamasPrueba> GetRamaPrueba(int eventoId, int deporteId, int esIndividual, int pruebaId)
        {

            return ProgRamasPrueba.GetRamas(eventoId, deporteId, esIndividual,pruebaId);
        }
        #endregion
        #region Golf Gets
        [HttpGet]
        public Persona GetPersona(int personaId)
        {
            return Persona.GetPersona(personaId);
        }

        [HttpGet]
        public Competidor GetCompetidor(int competidorId)
        {
            return Competidor.GetCompetidor(competidorId);
        }

        [HttpGet]
        public List<Persona> GetPersonas(int eventoId)
       {
            return Persona.GetPersonas(eventoId);
        }
        [HttpGet]
        public List<Persona> SearchCompetidores_Golf(int eventoId,string texto)
        {
            return Persona.SearchCompetidores_Golf(eventoId,texto);
        }

        [HttpGet]
        public List<Parametros> GetParametros()
        {
            return Parametros.GetParametros();
        }

        [HttpGet]
        public List<Parametros> GetParametros(int parametroId)
        {
            return Parametros.GetParametros(parametroId);
        }

        [HttpGet]
        public EventoDeportivo GetEventoDeportivo(int eventoDeportivoId)
        {
            return EventoDeportivo.GetEventoDeportivo(eventoDeportivoId);
        }

        [HttpGet]
        public List<EventoDeportivo> GetEventoDeportivos()
        {
            return EventoDeportivo.GetEventoDeportivos();
        }

        [HttpGet]
        public List<EventoDeportivo> GetEventosDeportivosByGestion(int gestion)
        {
            return EventoDeportivo.GetEventosDeportivosByGestion(gestion);
        }

        [HttpGet]
        public DataTable GetGestionesEventos()
        {
            return EventoDeportivo.GetGestionesEventos();
        }

        [HttpGet]
        public DataTable GetDeportesEvento(int eventoId)
        {
            return EventoDeportivo.GetDeportesEvento(eventoId);
        }

        [HttpGet]
        public List<Disciplina> GetDisciplinasActivas(int gestion)
        {
            return Disciplina.GetDisciplinasActivas(gestion);
        }

        [HttpGet]
        public DataTable GetGestionesEventos(int eventoId)
        {
            return Disciplina.GetGestionesEventos(eventoId);
        }

        [HttpGet]
        public DataTable GetUbicaciones()
        {
            return Disciplina.GetUbicaciones();
        }

        [HttpGet]
        public DataTable GetDeportistas()
        {
            return Deportista.GetDeportistas();
        }


        [HttpGet]
        public Deportista GetDeportista(int personaId)
        {
            return Deportista.GetDeportista(personaId);
        }

        [HttpGet]
        public DataTable GetDeportistasFiltro(int eventoId, int disciplinaId)
        {
            return Deportista.GetDeportistasFiltro(eventoId, disciplinaId);
        }

        [HttpGet]
        public DataTable GetDeportistaAcreditado(int personaId)
        {
            return Deportista.GetDeportistaAcreditado(personaId);
        }
        [HttpGet]
        public List<AcreGrupo> GetGrupos()
        {
            return AcreGrupo.getGrupos();
        }
        [HttpGet]
        public List<AcreRol> GetRoles()
        {
            return AcreRol.getRoles();
        }
        public List<AcreRol>GetRolGrupo(int grupoId)
        {
            return AcreRol.getRolGrupo(grupoId);
        }
        #endregion

        #region Acreditacion Gets
        [HttpGet]
        public AcrePersona GetAcreditacionPersona(int personaId)
        {
            return AcrePersona.GetPersona(personaId);
        }

        [HttpGet]
        public List<AcrePersona> GetAcreditacionPersonas()
        {
            return AcrePersona.GetPersonas();
        }

        public DataTable GetAcreditacionDetallePersona(int personaId)
        {
            return AcrePersona.GetDetalleAcreditacionPersona(personaId);
        }

        [HttpGet]
        public List<AcreDelegacion> GetDelegaciones(int eventoId)
        {
            return AcreDelegacion.getDelegaciones(eventoId);
        }


        [HttpGet]
        public DataTable GetInscripcionEvento(int eventoId)
        {
            return AcrePersona.GetInscripcionEvento(eventoId);
        }

        [HttpGet]
        public DataTable GetInscripcionEnventoDelegacion(int eventoId, int delegacionId)
        {
            return AcrePersona.GetInscripcionEnventoDelegacion(eventoId, delegacionId);
        }

        [HttpGet]
        public DataTable GetAcreditacionPersonaByCI(string CI)
        {
            return AcrePersona.GetPersonaByCI(CI);
        }

        [HttpGet]
        public string GetFotoPersona(int personaId)
        {
            return AcrePersona.GetFotoPersona(personaId);
        }
        #endregion
        #endregion
    }
}
