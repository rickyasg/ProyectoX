using DoNetJasper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace HamServicesJasper.Controllers
{
    public class JasperController : ApiController
    {
        #region Repotes
        [HttpGet]
        public HttpResponseMessage getGrupos(string eventoId, int deporteId = 2)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "8");
            js.Parameters.Add("DeporteId", deporteId);
            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string NameReporte = "rptGrupos";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, WebApiApplication.ApplicationResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }
        [HttpGet]
        public HttpResponseMessage getProgramacion(int eventoId, int deporteId,string fecha)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "7");
            js.Parameters.Add("DeporteId", deporteId);
            js.Parameters.Add("Fecha", fecha);
            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = "rptProgramacion";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, WebApiApplication.ApplicationResources, NameReporte, WebApiApplication.ApplicationResourcesImages);

            return getReportePDF(js.UrlGenerate);
        }

        [HttpGet]
        public HttpResponseMessage getResumenPartido(int eventoId, int deporteId, int cronogramaId)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "2");
            js.Parameters.Add("CronogramaId", cronogramaId);
            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = string.Format("rptResumen{0}", deporteId);
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, pathResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }

        [HttpGet]
        public HttpResponseMessage getTablaPosicion(int eventoId, int deporteId)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "10");
            js.Parameters.Add("DeporteId", deporteId);
            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = "rptTablaPosicion";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, pathResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }

        [HttpGet]
        public HttpResponseMessage getMedalleroGeneral(int eventoId)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "9");
             
            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = "rptMedalleroGeneral";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, pathResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }

        [HttpGet]
        public HttpResponseMessage getMedallasEvento(int eventoId, string fecha)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "15");
            js.Parameters.Add("Fecha", fecha);
            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = "rptMedallasEvento";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, pathResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }

        [HttpGet]
        public HttpResponseMessage getMedalleroDeporte(int eventoId, int deporteId)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "9");
            js.Parameters.Add("DeporteId", deporteId);
            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = "rptMedalleroDeporte";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, pathResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }



        [HttpGet]
        public HttpResponseMessage getIndividuales(int eventoId, int cronogramaId, int deporteId, int pruebaId, int parametroRamaId)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "3");
            js.Parameters.Add("CronogramaId", cronogramaId);
            js.Parameters.Add("DeporteId", deporteId);
            js.Parameters.Add("PruebaId", pruebaId);
            js.Parameters.Add("ParametroRamaId", parametroRamaId);

            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = "rptIndividual";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, pathResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }

        [HttpGet]
        public HttpResponseMessage getPodiosReporte(int eventoId, int cronogramaId, int deporteId, int pruebaId, int parametroRamaId)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "3");
            js.Parameters.Add("CronogramaId", cronogramaId);
            js.Parameters.Add("DeporteId", deporteId);
            js.Parameters.Add("PruebaId", pruebaId);
            js.Parameters.Add("ParametroRamaId", parametroRamaId);

            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = "rptIndividualResumen";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, pathResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }


        [HttpGet]
        public HttpResponseMessage getControlParametro(int eventoId, int deporteId, int pruebaId, int parametroRamaId, int parametroSucesoId)
        {

            JasperReport js = new JasperReport(WebApiApplication.JasperUser, WebApiApplication.JasperPassword, WebApiApplication.JasperServer, WebApiApplication.JasperPuerto);
            js.Parameters.Add("EventoId", eventoId);
            js.Parameters.Add("ReporteId", "16");
            js.Parameters.Add("ParametroSucesoId", parametroSucesoId);
            js.Parameters.Add("DeporteId", deporteId);
            js.Parameters.Add("PruebaId", pruebaId);
            js.Parameters.Add("ParametroRamaId", parametroRamaId);

            js.Parameters.Add("NombreSistema", WebApiApplication.ApplicationName);
            string pathResources = WebApiApplication.ApplicationResources;
            string NameReporte = "rptControlParametro";
            js.GenerateReport(WebApiApplication.JasperUrlReport, JasperReport.Type.PDF, pathResources, NameReporte, WebApiApplication.ApplicationResourcesImages);
            return getReportePDF(js.UrlGenerate);
        }


        public HttpResponseMessage getReportePDF(string path)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "erpDeportes";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return response;
        }

        #endregion
    }
}
