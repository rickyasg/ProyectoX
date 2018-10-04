using HamSiteModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HamSingleModel;
using System.Configuration;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Xml;
using HamSetModel;

namespace HamServicesSite.Controllers
{
    public class SiteController : ApiController
    {
        [HttpGet]
        public List<String> getTiempo()
        {
          
            String URLString = "http://xml.tutiempo.net/xml/55546.xml";
            XmlTextReader reader = new XmlTextReader(URLString);

            List<String> tiempo = new List<String>();


            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // El nodo es un elemento.
                        //Console.Write("<" + reader.Name);
                        //Console.WriteLine(">");

                        tiempo.Add(reader.Name);

                        break;

                    case XmlNodeType.Text: //Muestra el texto en cada elemento. 
                        //Console.WriteLine(reader.Value);
                        tiempo.Add(reader.Value);
                        break;

                    case XmlNodeType.EndElement: //Muestra el final del elemento.
                        //Console.Write("</" + reader.Name);
                        //Console.WriteLine(">");
                        //tiempo.Add(reader.Name);
                        break;
                }
            }

            return tiempo;
        }
        [HttpGet]
        public DataTable getCronogramaDelegacion(int eventoId, int delegacionId, int deporteId, DateTime? fecha = null, int pruebaId = 0, int parametroRamaId = 0)
        {
            return Web.GetCronogramaDelegacion(eventoId, delegacionId, deporteId, fecha, pruebaId, parametroRamaId);
        }

        [HttpGet]
        public DataTable getDeportesDia(int eventoId, int delegacionId, int deporteId, DateTime? fecha = null, int pruebaId = 0, int parametroRamaId = 0)
        {
            return Web.GetDeportesDia(eventoId, delegacionId, deporteId, fecha, pruebaId, parametroRamaId);
        }

        [HttpGet]
        public DataTable GetCompetidorPrueba(int cronogramaId)
        {
            DataTable dt = Singles.GetCompetidoresPrueba(cronogramaId);
            return dt;
        }
        [HttpGet]
        public DataTable getEvento(int eventoId)
        {
            return Web.GetEvento(eventoId);
        }
        [HttpGet]
        public DataTable GetMedalleroDeporte(int eventoId, int deporteId, int pruebaId = 0, int parametroRamaId = 0)
        {
            return Web.GetMedalleroDeporte(eventoId, deporteId, pruebaId, parametroRamaId);
        }
        [HttpGet]
        public DataTable GetMedalleroDelegacion(int eventoId, int delegacionId)
        {
            return Web.GetMedalleroDelegacion(eventoId, delegacionId);
        }
        [HttpGet]
        public DataTable GetMedalleroGeneral(int eventoId)
        {
            return Web.GetMedalleroGeneral(eventoId);
        }
        [HttpGet]
        public DataTable getProgramacionGeneral(int eventoId, int delegacionId, int deporteId, DateTime? fecha = null, int pruebaId = 0, int parametroRamaId = 0)
        {
            return Web.GetProgramacionGeneral(eventoId, delegacionId, deporteId, fecha, pruebaId, parametroRamaId);
        }
        [HttpGet]
        public DataTable getResultadoConjuntoVs(int cronogramaId)
        {
            return Web.GetResultadoConjuntoVs(cronogramaId);
        }

        [HttpGet]
        public DataTable GetCronogramaInstalacion(int cronogramaId)
        {
            return Web.GetCronogramaInstalacion(cronogramaId);
        }



        [HttpGet]
        public DataTable getPersonaEvento(int eventoId, int personaId, string search = "")
        {
            return Web.GetPersonaEvento(eventoId, personaId, search);
        }
        [HttpGet]
        public DataTable getCompetidorEvento(int eventoId, int personaId, int deporteId, int delegacionId = 0, string search = "")
        {
            return Web.GetCompetidorEvento(eventoId, personaId, deporteId, delegacionId, search);
        }

        [HttpGet]
        public DataTable getPersonaPrueba(int eventoId, int personaId)
        {
            return Web.GetPersonaPrueba(eventoId, personaId);
        }
        [HttpGet]
        public DataTable getUltimoCronogramaId(int eventoId, int deporteId)
        {
            return Web.GetUltimoCronogramaId(eventoId, deporteId);
        }
        [HttpGet]
        public DataTable getCalendarioEvento(int eventoId)
        {
            return Web.GetCalendarioEvento(eventoId);
        }
        [HttpGet]
        public DataTable getCalendarioDelegacion(int eventoId, int delegacionId)
        {
            return Web.GetCalendarioDelegacion(eventoId, delegacionId);
        }
        [HttpGet]
        public DataTable GetDeportes(int eventoId)
        {
            return Web.GetDeportes(eventoId);
        }
        [HttpGet]
        public DataTable GetDelegaciones(int eventoId)
        {
            return Web.GetDelegaciones(eventoId);
        }

        [HttpGet]
        public DataTable GetPodio(int eventoId, int deporteId = 0, int pruebaId = 0, int parametroRamaId = 0, int delegacionId = 0)
        {
            return Web.GetPodio(eventoId, deporteId, pruebaId, parametroRamaId, delegacionId);
        }
        [HttpGet]
        public DataTable GetTablaPosicion(int eventoId, int deporteId, int parametroRamaId = 0, int grupoid = 0)
        {
            return Web.GetTablaPosicion(eventoId, deporteId, parametroRamaId, grupoid);
        }
        [HttpGet]
        public DataTable GetIsIndividual(int eventoId, int deporteId)
        {
            return Web.GetIsIndividual(eventoId, deporteId);
        }
        [HttpGet]
        public DataTable GetPruebas(int eventoId, int deporteId, int isIndividual)
        {
            return Web.GetPruebas(eventoId, deporteId, isIndividual);
        }
        [HttpGet]
        public DataTable GetRamasPrueba(int eventoId, int deporteId, int isIndividual, int pruebaId)
        {
            return Web.GetRamasPrueba(eventoId, deporteId, isIndividual, pruebaId);
        }
        [HttpGet]
        public DataTable GetResultadoEncuentro(int cronogramaId)
        {
            return Web.GetResultadoEncuentro(cronogramaId);
        }
        [HttpGet]
        public DataTable GetEstadisticoWeb(int cronogramaId, int deporteId)
        {
            return Web.GetEstadisticoWeb(cronogramaId, deporteId);
        }
        [HttpGet]
        public DataTable GetResultadosWeb(int cronogramaId, int deporteId)
        {
            return Web.GetResultadosWeb(cronogramaId, deporteId);
        }
        [HttpGet]
        public DataTable GetResumenJornada(int deporteId, string fecha, int eventoId)
        {
            return Web.GetResumenJornada(deporteId, fecha, eventoId);
        }
        [HttpGet]
        public DataTable GetHistorialCronograma(int cronogramaId)
        {
            return Web.GetHistorialCronograma(cronogramaId);
        }
        [HttpGet]
        public DataTable GetCompetidorDeportes(int deporteId, int pruebaId, int parametroRamaId, int eventoId = 1)
        {
            return Web.GetCompetidoresDeporte(deporteId, pruebaId, parametroRamaId, eventoId);
        }
        [HttpGet]
        public DataTable GetAsistentes(int cronogramaId, int competidorId)
        {
            return Web.GetAsistentes(cronogramaId, competidorId);
        }
        [HttpGet]
        public List<ImagenFile> GetImagesFile(string eventoId, string directorio)
        {
            return Web.GetImagesFile(eventoId, directorio);
        }
        [HttpGet]
        public DataTable GetInstalaciones(int eventoId, int tipo)
        {
            return Web.GetInstalaciones(eventoId, tipo);
        }
        [HttpGet]
        public DataTable GetProgramacionInstalaciones(int eventoId, int instalacionId)
        {
            return Web.GetProgramacionInstalaciones(eventoId, instalacionId);
        }

        [HttpGet]
        public List<PlanillaPersona> GetPlanillaPersonas(int competidorId, int planillaId, string search = "", int parametroRolId = 0)
        {
            return PlanillaPersona.GetPlanillaPersonas(competidorId, planillaId, search, parametroRolId);
        }

        public DataTable GetNoticias(int limite = 10)
        {
            return Feeds.GetNoticias(limite);
        }


        [HttpPost]
        public bool SendPush([FromBody] PushNotifications push)
        {
            return PushNotifications.SendPush(push);
        }        

        #region Get datos encuentro
        public DataTable GetPlanilla(int cronogramaId, int competidorId, int parametroRolId, int deporteId)
        {
            return Web.GetPlanilla(cronogramaId, competidorId, parametroRolId, deporteId);
        }
        public DataTable GetResultados(int cronogramaId, int competidorId, int deporteId, int gol)
        {
            return Web.GetResultados(cronogramaId, competidorId, deporteId, gol);
        }
        public DataTable GetGetResultadosVoley(int cronogramaId)
        {
            return Web.GetGetResultadosVoley(cronogramaId);
        }
        public DataTable GetResultadosBaloncesto(int cronogramaId)
        {
            return Web.GetResultadosBaloncesto(cronogramaId);
        }
        public DataTable GetPlanillaBaloncesto(int cronogramaId, int competidorId)
        {
            return Web.GetPlanillaBaloncesto(cronogramaId, competidorId);
        }
        public DataTable GetPlanillaArbitraje(int cronogramaId)
        {
            return Web.GetPlanillaArbitraje(cronogramaId);
        }
        #endregion

        public dynamic GetNoticiasJson()
        {
            string uri = ConfigurationManager.AppSettings["noticias"];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            List <News> json = new List<News>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                //if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                //else
                  //  readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                string data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                json = JsonConvert.DeserializeObject<List<News>>(data);                
            }
            var x = json.Take<News>(10);

            return x;
        }
    }
    public class News {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
    }

}

