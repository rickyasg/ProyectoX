using HamCommon;
using HamDataModel;
using HamReportsModel;
using HamReportsModel.Acreditacion;
using HamReportsModel.Golf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace HamServicesReport.Controllers
{
    public class ReportController : ApiController
    {
        #region Acreditacion Reportes
        [HttpGet]
        public HttpResponseMessage getAcreditacionCredencial(int personaId, int eventoId)
        {
            DataTable dtDatosPersonales = AcrePersona.GetCredencialDatosPersonales(personaId, eventoId);
            DataTable dtDatosPrivilegios = AcrePersona.GetCredencialDatosPrivilegios(personaId, eventoId);
            string pathResources = WebApiApplication.ApplicationResources;
            CredencialPluris  reporte = new CredencialPluris(dtDatosPersonales, dtDatosPrivilegios, pathResources);
            //AcreditacionCredencial reporte = new AcreditacionCredencial(dtDatosPersonales, dtDatosPrivilegios, pathResources);
            reporte.PersonaId = personaId;
            reporte.EventoId = eventoId;
            string path = reporte.GenerarCredencial();
            return getReportePDF(path);
        }

        [HttpGet]
        public HttpResponseMessage GetInscritosEvento(int eventoId, int delegacionId, string delegacion)
        {
          
            DataTable dt = AcrePersona.GetInscripcionEnventoDelegacion(eventoId, delegacionId);
            string pathResources = WebApiApplication.ApplicationResources;
            string path = AcreditacionInscritos.ReporteAcreditacionInscritos(dt, pathResources, delegacion);
            return getReportePDF(path);
        }
        #endregion


        #region GolfReportes
        [HttpGet]
        public HttpResponseMessage GetDetalleJornada(int jornadaId, int categoriaId,int eventoId)
        {
            var dtDatosJornada= GolfCompetidorJornada.GetCompetidoresGrupos(jornadaId, categoriaId);
            string pathResources = WebApiApplication.ApplicationResources;
            var path = GolfCompetidorReport.ReporteJornadaInscritos(dtDatosJornada, pathResources, eventoId, categoriaId, jornadaId);
            return getReportePDF(path);

        }
        [HttpGet]
        public HttpResponseMessage GetDetallePersonaCompetidor(int personaId, int eventoId, string categoriaName)
        {
            List<GolfJornada> list = GolfJornada.GetGolfJornadas(Convert.ToInt32(eventoId));
            string ids = string.Empty;
            foreach (GolfJornada item in list)
            {
                if (string.IsNullOrEmpty(ids))
                {
                    ids = item.JornadaId.ToString();
                }
                else
                {
                    ids = string.Format("{0},{1}", ids, item.JornadaId);
                }
            }
            DataTable dtDatosPersonales = GolfCompetidor.GetGolfCompetidorByPersonaId(personaId);
            string pathResources = WebApiApplication.ApplicationResources;
            string path = GolfCompetidorReport.ReporteResultadosCompetidor(dtDatosPersonales, eventoId, categoriaName, ids, personaId, pathResources);
            return getReportePDF(path);
        }

        [HttpGet]
        public HttpResponseMessage GetResultadosFinalesTorneo(int categoria, int eventoId, string categoriaName)
        {
            DataTable dtDatosPersonales = GolfJugada.TotalesTorneo(eventoId, categoria);
            string pathResources = WebApiApplication.ApplicationResources;
            string path = GolfResultadosFinalesReport.ReporteResultadosFinales(dtDatosPersonales, eventoId, categoriaName, pathResources);
            return getReportePDF(path);
        }

        #endregion

        #region Golf

        [HttpGet]
        public HttpResponseMessage GetRptListadoGolf(int eventoId, int jornadaId, int categoriaId, string jornada, string categoria)
        {
            DataTable dtLista = GolfJornada.GetLista(Convert.ToInt32(jornadaId), Convert.ToInt32(categoriaId));
            DataTable dtHoyos = GolfHoyoPar.GetGolfHoyoPar((int)HoyoPar.Hoyo);
            string pathResources = WebApiApplication.ApplicationResources;
            string ruta = RptListadoGolf.ReporteListado(dtLista, dtHoyos, jornada, categoria, eventoId, pathResources);
            return getReportePDF(ruta);
        }

        //private DataTable GetAllTotalesReporte(DataTable dtJornadas, int cateId)
        //{
        //    DataTable dt = new DataTable();
        //    DataTable dtauxi = new DataTable();
        //    int contador = 2;
        //    int contCol = 3;
        //    string namecolum = string.Empty;
        //    int vuno, vdos = 0;
        //    foreach (DataRow dr in dtJornadas.Rows)
        //    {
        //        if (dt.Rows.Count < 1)
        //        {
        //            dtauxi = GolfJugada.GetTotalesFinalesReporte(Convert.ToInt32(dr[0]), cateId);
        //            dt = dtauxi;
        //        }
        //        else
        //        {
        //            dtauxi = GolfJugada.GetTotalesFinalesReporte(Convert.ToInt32(dr[0]), cateId);
        //            int nrofilasauxi = dtauxi.Rows.Count;
        //            int contadorauxi = 0;
        //            int[] nRows = new int[nrofilasauxi];

        //            if (dtauxi.Rows.Count > 0)
        //            {
        //                for (int x = 0; x < dt.Rows.Count; x++)
        //                {
        //                    if (contadorauxi < nrofilasauxi)
        //                    {
        //                        vuno = Convert.ToInt32(dt.Rows[x]["CompetidorId"]);
        //                        vdos = Convert.ToInt32(dtauxi.Rows[contadorauxi]["CompetidorId"]);
        //                        if (vuno == vdos)
        //                        {
        //                            nRows[contadorauxi] = x;
        //                            contadorauxi++;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        x = dt.Rows.Count;
        //                    }
        //                }

        //                for (int x = 0; x <= 3; x++)
        //                {
        //                    namecolum = dtauxi.Columns[contCol].ColumnName;
        //                    namecolum = string.Format("{0} {1}", namecolum, contador);
        //                    dt.Columns.Add(namecolum);
        //                    for (int i = 0; i < dtauxi.Rows.Count; i++)
        //                    {
        //                        dt.Rows[nRows[i]][namecolum] = dtauxi.Rows[i][contCol];
        //                    }
        //                    contCol++;
        //                }
        //            }
        //            contador++;
        //        }
        //    }
        //    return dt;
        //}

        //private DataTable CalcularScores(DataTable dt, DataTable dtJornadas)
        //{
        //    int nroRow = 0;
        //    int totalNeto = 0;
        //    int totalGross = 0;
        //    int parjornadas = 0;
        //    if (dt.Columns.Count > 7)
        //    {
        //        parjornadas = GolfHoyoPar.GetParTotal() * dtJornadas.Rows.Count;
        //        dt.Columns.Add("Total Gross");
        //        dt.Columns.Add("Total Neto");
        //        dt.Columns.Add("Score", typeof(Int32));
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            totalNeto = 0;
        //            totalGross = 0;
        //            for (int i = 1; i <= dtJornadas.Rows.Count; i++)
        //            {
        //                if (totalGross == 0)
        //                {
        //                    totalGross = totalGross + Convert.ToInt32(dr["Gross"]);
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(dr["Gross" + " " + i].ToString()))
        //                    {
        //                        totalGross = totalGross + 500;
        //                    }
        //                    else
        //                    {
        //                        totalGross = totalGross + Convert.ToInt32(dr["Gross" + " " + i]);
        //                    }
        //                }
        //                if (totalNeto == 0)
        //                {
        //                    totalNeto = totalNeto + Convert.ToInt32(dr["Neto"]);
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(dr["Neto" + " " + i].ToString()))
        //                    {
        //                        totalNeto = totalNeto + 500;
        //                    }
        //                    else
        //                    {
        //                        totalNeto = totalNeto + Convert.ToInt32(dr["Neto" + " " + i]);
        //                    }
        //                }
        //            }
        //            dt.Rows[nroRow]["Total Gross"] = totalGross;
        //            dt.Rows[nroRow]["Total Neto"] = totalNeto;
        //            dt.Rows[nroRow]["Score"] = totalGross - parjornadas;
        //            nroRow++;
        //        }
        //    }
        //    else
        //    {
        //        parjornadas = GolfHoyoPar.GetParTotal();
        //        dt.Columns.Add("Score", typeof(Int32));
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            totalGross = Convert.ToInt32(dr["Gross"]);
        //            dt.Rows[nroRow]["Score"] = totalGross - parjornadas;
        //            nroRow++;
        //        }
        //    }
        //    return dt;
        //}
        //private DataTable SetPosicionTabla(DataTable dtTotales)
        //{
        //    dtTotales.Columns.Add("Posición").SetOrdinal(0);
        //    int position = 1;
        //    int axuPosition = 1;
        //    int fila = 0;
        //    string scoreAnterior = string.Empty;
        //    foreach (DataRow dr in dtTotales.Rows)
        //    {
        //        if (position < 4)
        //        {
        //            dtTotales.Rows[fila]["Posición"] = position;
        //            position++;
        //        }
        //        else
        //        {
        //            if (scoreAnterior == dtTotales.Rows[fila]["Score"].ToString())
        //            {
        //                scoreAnterior = dtTotales.Rows[fila]["Score"].ToString();
        //                dtTotales.Rows[fila]["Posición"] = string.Format("E{0}", axuPosition);
        //                dtTotales.Rows[fila - 1]["Posición"] = string.Format("E{0}", axuPosition);
        //            }
        //            else
        //            {
        //                axuPosition = position;
        //                scoreAnterior = dtTotales.Rows[fila]["Score"].ToString();
        //                dtTotales.Rows[fila]["Posición"] = axuPosition;
        //            }
        //            position++;
        //        }
        //        fila++;
        //    }
        //    return dtTotales;
        //}
        #endregion

        public HttpResponseMessage getReportePDF(string path)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "erpDeportes";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return response;
        }
    }
}
