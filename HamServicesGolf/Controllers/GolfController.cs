using HamCommon;
using HamDataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace HamServicesGolf.Controllers
{
    public class GolfController : ApiController
    {
        #region Servicios Post
        [HttpPost]
        public bool InsertGolfJugada([FromBody] GolfJugada jugadas)
        {
            return jugadas.Insert();
        }

        [HttpPost]
        public bool SaveGolfJornada([FromBody] GolfJornada jornada)
        {
            return jornada.Save();
        }

        [HttpPost]
        public int SaveGolfGrupo([FromBody] GolfGrupos grupos)
        {
            return grupos.Save();
        }

        [HttpPost]
        public bool InsertGolfCompetidorJornada([FromBody] GolfCompetidorJornada competidorJornada)
        {
            return competidorJornada.Insert();
        }

        [HttpPost]
        public bool UpdateGolfCompetidorJornada([FromBody] GolfCompetidorJornada competidorJornada)
        {
            return competidorJornada.Update();
        }



        [HttpPost]
        public bool CambiarEstadoGolfCompetidorJornada(int competidorJornadaId)
        {
            return GolfCompetidorJornada.CambiarEstado(competidorJornadaId);
        }

        [HttpPost]
        public bool SaveGolfCategoria([FromBody] GolfCategoria categoria)
        {
            return categoria.Save();
        }

        [HttpPost]
        public bool InsertCompetidorGolfCompetidor([FromBody] CompetidorGolfCompetidor gcompetidor)
        {
            Competidor cp = new Competidor();
            bool resultado = true;
            GolfCompetidor gcp = new GolfCompetidor();
            gcp.CompetidorId = gcompetidor.CompetidorId;
            gcp.CategoriaId = gcompetidor.CategoriaId;
            gcp.Handicap = gcompetidor.Handicap;
            gcp.Club = gcompetidor.Club;
            if (gcompetidor.Accion == 0)
                resultado = InsertGolfCompetidor(gcp);
            else
                resultado = resultado && UpdateGolfCompetidor(gcp);

            return resultado;
        }

        [HttpPost]
        public bool InsertGolfCompetidor([FromBody] GolfCompetidor competidor)
        {
            return competidor.Insert();
        }

        [HttpPost]
        public bool UpdateGolfCompetidor([FromBody] GolfCompetidor competidor)
        {
            return competidor.Update();
        }

        [HttpPost]
        public bool UpdateGolfCompetidorEstado([FromBody] GolfCompetidorJornada golfgrupo)
        {
            return golfgrupo.UpdateEstado();
        }

        [HttpPost]
        public bool SaveGolfGrupoCompetidores([FromBody] CompetidorAuxiliar golfgrupo)
        {
            bool resultado = (golfgrupo != null);
            bool isEdit = (golfgrupo.GrupoId > 0);
            if (resultado)
            {
                GolfGrupos gg = new GolfGrupos();
                gg.GrupoId = golfgrupo.GrupoId;
                gg.Descripcion = golfgrupo.HoraSalida.ToString();
                if (gg.GrupoId == 0)
                    gg.GrupoId = SaveGolfGrupo(gg);
                else
                    SaveGolfGrupo(gg);
                resultado = resultado && (gg.GrupoId > 0);
                if (isEdit)
                {
                    resultado = resultado && GolfCompetidorJornada.Delete(gg.GrupoId);
                }
                if (resultado)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    dynamic dyCompetidor = golfgrupo.Jugador;
                    int PosicionIni = 1;
                    int nroCompetidores = ((Newtonsoft.Json.Linq.JContainer)dyCompetidor).Count > 4 ? 4 : ((Newtonsoft.Json.Linq.JContainer)dyCompetidor).Count;
                    for (int i = 0; i < nroCompetidores; i++)
                    {
                        string stgCompetidor = dyCompetidor[string.Format("{0}", i)].ToString();
                        CompetidorConSinJornada compete = js.Deserialize<CompetidorConSinJornada>(stgCompetidor);
                        GolfCompetidorJornada gcj = new GolfCompetidorJornada();
                        gcj.CompetidorId = compete.CompetidorId;
                        gcj.JornadaId = golfgrupo.JornadaId;
                        gcj.UsuarioId = 1;
                        gcj.GrupoId = gg.GrupoId;
                        gcj.Posicion = PosicionIni;
                        PosicionIni++;
                        resultado = resultado && InsertGolfCompetidorJornada(gcj);
                    }
                }
            }
            return resultado;
        }



        #endregion

        #region Servicios Delete
        [HttpDelete]
        public bool DeleteGolfJornada(int jornadaId)
        {
            GolfJornada gj = new GolfJornada();
            return gj.Delete(jornadaId);
        }

        [HttpDelete]
        public bool DeleteGolfCategoria(int categoriaId)
        {
            GolfCategoria gc = new GolfCategoria();
            return gc.Delete(categoriaId);
        }

        [HttpDelete]
        public bool DeleteGolfCompetidor(int competidorId)
        {
            GolfCompetidor gc = new GolfCompetidor();
            return gc.Delete(competidorId);
        }

        [HttpDelete]
        public bool DeleteGolfPuntaje(int competidorJornadaId)
        {
            return GolfJugada.DeletePuntaje(competidorJornadaId);
        }

        [HttpDelete]
        public bool DeleteGolfGrupoCompetidores(int grupoId)
        {
            bool resultado = (grupoId > 0);
            resultado = resultado && GolfCompetidorJornada.Delete(grupoId);
            resultado = resultado && GolfGrupos.Delete(grupoId);

            return resultado;
        }
        [HttpDelete]
        public bool Delete_GolfCompetidor(int competidorId)
        {
            bool resultado = (competidorId > 0);
            GolfCompetidor data = new GolfCompetidor();
            resultado = resultado && data.DeleteInscrito(competidorId);

            return resultado;
        }
        #endregion

        #region Servicios GET
        [HttpGet]
        public GolfCategoria GetGolCategoria(int categoriaId)
        {
            return GolfCategoria.GetGolCategoria(categoriaId);
        }

        [HttpGet]
        public Object GetGolfCategorias(int eventoId)
        {
            Datos data = new Datos();
            data.data = GolfCategoria.GetGolCategorias(eventoId);
            return data;
        }

        [HttpGet]
        public string GetGolfJornadasFechas(int eventoDeportivoId)
        {
            List<DateTime> ls = GolfJornada.GetGolfJornadasFechas(eventoDeportivoId);
            return string.Format("Del {0:dd MMMM} al {1:dd MMMM} {1:yyyy}", ls[0], ls[ls.Count - 1]);
        }

        [HttpGet]
        public Object GetGolfJornadas(int eventoDeportivoId)
        {
            Datos data = new Datos();
            data.data = GolfJornada.GetGolfJornadas(eventoDeportivoId);
            return data;
        }
        [HttpGet]
        public DataTable GetEquiposJornada(int EventoId,int PruebaEventoId,int par)
        {
            return GolfJornada.getEquiposResultados(EventoId, PruebaEventoId, par);
        }

        [HttpGet]
        public Object GetGolfJornada(int jornadaId)
        {
            Datos data = new Datos();
            data.data = GolfJornada.GetGolfJornada(jornadaId);
            return data;
        }

        [HttpGet]
        public DataTable GetCompetidoresSinJornada(int categoriaId, int jornadaId, int eventoId)
        {
            DataTable dt = GolfCompetidorJornada.GetCompetidoresSinJornada(categoriaId, jornadaId, eventoId);
            return dt;
        }

        [HttpGet]
        public DataTable GetCompetidoresConJornada(int grupoId)
        {
            DataTable dt = GolfCompetidorJornada.GetCompetidoresConJornada(grupoId);
            return dt;
        }

        [HttpGet]
        public Object GetCompetidoresGrupos(int jornadaId, int categoriaId)
        {
            Datos data = new Datos();
            data.data = GolfCompetidorJornada.GetCompetidoresGrupos(jornadaId, categoriaId);
            return data;
        }

        //[HttpGet]
        //public DataTable GetResultadosCompetidor(int jornaId, int personaId)
        //{
        //    return GolfCompetidor.GetResultadosCompetidor(jornaId, personaId);
        //}

        [HttpGet]
        public List<DataTable> GetResultadosCompetidor(int personaId, int eventoId)
        {
            return GolfCompetidor.GetResultadosCompetidor(personaId, eventoId);
        }

        [HttpGet]
        public int GetHCPporciento(int competidorId)
        {
            DataTable dt = GolfCompetidor.GetHCPporciento(competidorId);
            int hcpPorciento = 0;

            if (dt.Rows.Count > 0)
            {
                hcpPorciento = Convert.ToInt32(dt.Rows[0][0]);
            }
            return hcpPorciento;
        }

        [HttpGet]
        public DataTable GetEventoName(int eventoid)
        {
            return EventoDeportivo.GetEventoName(eventoid);
        }

        [HttpGet]
        public List<Parametros> GetTipoTirosGolf()
        {
            return Parametros.GetTipoTiros();
        }

        [HttpGet]
        public GolfCompetidor GetGolfCompetidor(int competidorId)
        {
            return GolfCompetidor.GetGolfCompetidor(competidorId);
        }

        [HttpGet]
        public DataTable GetGolfCompetidorByPersonaId(int personaId)
        {
            return GolfCompetidor.GetGolfCompetidorByPersonaId(personaId);
        }

        [HttpGet]
        public DataTable GetGolfJugadores(int grupoId)
        {
            return GolfGrupos.GetJugadores(grupoId);
        }

        [HttpGet]
        public int GetGolfParTotal()
        {
            return GolfHoyoPar.GetParTotal();
        }

        [HttpGet]
        public DataTable GetGolfHoyoPar(int tipoHoyoId)
        {
            return GolfHoyoPar.GetGolfHoyoPar(tipoHoyoId);
        }

        [HttpGet]
        public DataTable GetGolfLista(int jornadaId, int categoriaId)
        {
            return GolfJornada.GetLista(jornadaId, categoriaId);
        }

        [HttpGet]
        public DataTable GetGolfListaSHCP(int jornadaId, int categoriaId)
        {
            return GolfJornada.GetListaSHCP(jornadaId, categoriaId);
        }

        [HttpGet]
        public DataTable GetGolfNroJornadas(int eventoId)
        {
            return GolfJornada.GetNroJornadas(eventoId);
        }

        [HttpGet]
        public GolfJugada GetGolfJugada(int jugadasId)
        {
            return GolfJugada.GetJugada(jugadasId);
        }

        [HttpGet]
        public DataTable GetGolfTotalesFinales(int jornada, int categoria)
        {
            return GolfJugada.GetTotalesFinales(jornada, categoria);
        }


        [HttpGet]
        public DataTable GetGolfTotalesTorneo(int eventoId, int categoriaId)
        {
            DataTable dt = GolfJugada.TotalesTorneo(eventoId, categoriaId);
            dt.Columns.Remove("JornadaId");
            dt.Columns.Remove("CategoriaId");
            dt.Columns.Remove("CompetidorId");
            dt.Columns.Remove("CompetidorJornadaId");
            dt.Columns.Remove("Nombre");
            return dt;
        }

        [HttpGet]
        public DataTable GetGolfTotalesFinalesReporte(int jornada, int categoria)
        {
            return GolfJugada.GetTotalesFinalesReporte(jornada, categoria);
        }

        [HttpGet]
        public DataTable GetGolfTarijeta(int competidorJornadaId1, int competidorJornadaId2, int competidorJornadaId3, int competidorJornadaId4)
        {
            return GolfJugada.GetTarijeta(competidorJornadaId1, competidorJornadaId2, competidorJornadaId3, competidorJornadaId4);
        }

        [HttpGet]
        public DataTable GetGolfGolpes(int competidorJornadaId, int hoyoParId)
        {
            return GolfJugada.GetGolpes(competidorJornadaId, hoyoParId);
        }

        [HttpGet]
        public DataTable GetGolfTotales(int grupoId)
        {
            return GolfJugada.GetTotales(grupoId);
        }
        [HttpGet]
        public DataTable GetGrupoPersonas(string Fecha, int JornadaId, int CategoriaId)
        {
            return GolfGrupos.GetGrupoPersonas(Fecha, JornadaId, CategoriaId);
        }
        #endregion
    }

    #region Auxiliar Class
    public class Datos
    {
        public Object data { get; set; }

        public Datos() { }
    }

    public class CompetidorAuxiliar
    {
        public int GrupoId { get; set; }
        public string HoraSalida { get; set; }
        public int JornadaId { get; set; }
        public object Jugador { get; set; }
    }

    public class CompetidorConSinJornada
    {
        public int PersonaId { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Extension { get; set; }
        public object Titulo { get; set; }
        public int CompetidorId { get; set; }
        public object EquipoId { get; set; }
        public int DisciplinaId { get; set; }
        public int CategoriaId { get; set; }
        public int Handicap { get; set; }
        public int EventoDeportivoId { get; set; }
        public int JornadaId { get; set; }
        public int Estado { get; set; }
        public int GrupoId { get; set; }

        public CompetidorConSinJornada()
        {

        }
    }

    public class CompetidorGolfCompetidor
    {
        public int PersonaId { get; set; }
        public int CompetidorId { get; set; }
        public int DisciplinaId { get; set; }
        public int EventoDeportivoId { get; set; }
        public int CategoriaId { get; set; }
        public int Handicap { get; set; }
        public string Club { get; set; }
        public int Accion { get; set; }
    }
    #endregion
}
