using System;
using System.Collections.Generic;
using System.Data;
using HamDataTransactions;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace HamSiteModel
{
    public class Web
    {
        #region voleibol
        public static DataTable GetGetResultadosVoley(int cronogramaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetResultadosVoley] ({0})", cronogramaId));
            return dt;
        }
        #endregion

        #region Baloncesto

        public static DataTable GetResultadosBaloncesto( int cronogramaId) {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetResultadosBaloncesto] ({0})",cronogramaId));
            return dt;
        }
        public static DataTable GetPlanillaBaloncesto(int cronogramaId, int competidorId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetPlanillaBaloncesto] ({0}, {1})", cronogramaId,competidorId));
            return dt;
        }
        


    #endregion
    #region Metodos Get

    public static DataTable GetPlanillaArbitraje(int cronogramaId)
    {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetArbitros] ({0}) order by ParametroId", cronogramaId));
            return dt;
    }
    public static DataTable GetMedalleroGeneral(int eventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("EventoId", eventoId));
            dt = db.GetStoreProcedure("prog.pGetMedalleroGeneral", lp);
            return dt;
        }
        public static DataTable GetMedalleroDeporte(int eventoId, int deporteId, int pruebaId = 0, int parametroRamaId = 0)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("EventoId", eventoId));
            lp.Add(new SqlParameter("DeporteId", deporteId));
            lp.Add(new SqlParameter("PruebaId", pruebaId));
            lp.Add(new SqlParameter("ParametroRamaId", parametroRamaId));
            dt = db.GetStoreProcedure("prog.pGetMedalleroDeporte", lp);
            return dt;
        }
        public static DataTable GetMedalleroDelegacion(int eventoId, int delegacionId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("EventoId", eventoId));
            lp.Add(new SqlParameter("DelegacionId", delegacionId));
            dt = db.GetStoreProcedure("prog.pGetMedalleroDelegacion", lp);
            return dt;
        }
        public static DataTable GetCronogramaDelegacion(int eventoId, int delegacionId, int deporteId, DateTime? fecha = null,int pruebaId= 0, int parametroRamaId = 0)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("EventoId", eventoId));
            par.Add(new SqlParameter("DelegacionId", delegacionId));
            par.Add(new SqlParameter("DeporteId", deporteId));
            par.Add(new SqlParameter("Fecha", fecha));
            par.Add(new SqlParameter("PruebaId", pruebaId));
            par.Add(new SqlParameter("ParametroRamaId", parametroRamaId));
            dt = db.GetStoreProcedure("[prog].[pGetCronograma]", par);
            return dt;
        }

        public static DataTable GetDeportesDia(int eventoId, int delegacionId, int deporteId, DateTime? fecha = null, int pruebaId = 0, int parametroRamaId = 0)
        {
            DataTable dt = new DataTable();
            dt = GetCronogramaDelegacion(eventoId, delegacionId, deporteId, fecha, pruebaId, parametroRamaId);
            DataSet ds = new DataSet();            
            if (dt.Rows.Count > 0) {
                DataView view = new DataView(dt);
                dt = view.ToTable(true, "DeporteId", "Deporte");
            }
            return dt;
        }

        public static DataTable GetEvento(int eventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[erp].[fGetEvento] ({0})", eventoId));
            return dt;
        }
        public static DataTable GetProgramacionGeneral(int eventoId, int delegacionId, int deporteId, DateTime? fecha = null, int pruebaId=0, int parametroRamaId =0)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ls = new List<SqlParameter>();
            DBTransaction db = new DBTransaction();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("DelegacionId", delegacionId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            ls.Add(new SqlParameter("PruebaId", pruebaId));
            ls.Add(new SqlParameter("ParametroRamaId", parametroRamaId));
            ls.Add(new SqlParameter("Fecha", fecha));
            dt = db.GetStoreProcedure("prog.pGetProgramacionGeneral", ls);
            return dt;
        }
        public static DataTable GetResultadoConjuntoVs(int cronogramaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            dt = db.GetStoreProcedure("[conj].[pGetResultadoConjuntoVs]", ls);
            return dt;
        }
        public static DataTable GetCalendarioEvento(int eventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            dt = db.GetStoreProcedure("[prog].[pGetCalendarioEvento]", ls);
            return dt;
        }
        public static DataTable GetCalendarioDelegacion(int eventoId, int delegacionId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("DelegacionId", delegacionId));
            dt = db.GetStoreProcedure("[prog].[pGetCalendarioDelegacion]", ls);
            return dt;
        }
        public static DataTable GetPodio(int eventoId, int deporteId = 0, int pruebaId = 0, int parametroRamaId = 0, int delegacionId = 0)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("EventoId", eventoId));
            lp.Add(new SqlParameter("DeporteId", deporteId));
            lp.Add(new SqlParameter("PruebaId", pruebaId));
            lp.Add(new SqlParameter("ParametroRamaId", parametroRamaId));
            lp.Add(new SqlParameter("DelegacionId", delegacionId));
            dt = db.GetStoreProcedure("[prog].[pGetPodios]", lp);
            return dt;
        }
        public static DataTable GetTablaPosicion(int eventoId, int deporteId, int parametroRamaId = 0, int grupoid = 0)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("EventoId", eventoId));
            lp.Add(new SqlParameter("DeporteId", deporteId));
            lp.Add(new SqlParameter("GrupoId", grupoid));
            lp.Add(new SqlParameter("ParametroRamaId", parametroRamaId));
            dt = db.GetStoreProcedure("[conj].[pTablaPosicion]", lp);
            return dt;
        }
        public static DataTable GetResultadoEncuentro(int cronogramaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fResultadoEncuentro]({0})", cronogramaId));
            return dt;
        }

        public static DataTable GetCronogramaInstalacion(int cronogramaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("prog.fgetCronogramaInstalacion({0})", cronogramaId));
            return dt;
        }
        

        public static DataTable GetEstadisticoWeb(int cronogramaId, int deporteId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("_CronogramaId", cronogramaId));
            ls.Add(new SqlParameter("_DeporteId", deporteId));
            dt = db.GetStoreProcedure("[conj].[pGetEstadisticoWeb]", ls);
            return dt;
        }
        public static DataTable GetResultadosWeb(int cronogramaId, int deporteId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("_CronogramaId", cronogramaId));
            ls.Add(new SqlParameter("_DeporteId", deporteId));
            dt = db.GetStoreProcedure("[conj].[pGetResultadoWeb]", ls);
            return dt;
        }
        #endregion
        #region Metodos Get Persona
        public static DataTable GetPersonaEvento(int eventoId, int personaId, string search = "")
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("PersonaId", personaId));
            ls.Add(new SqlParameter("Search", search));
            dt = db.GetStoreProcedure("[acre].[pGetPersonaEvento]", ls);
            return dt;
        }
        public static DataTable GetCompetidorEvento(int eventoId, int personaId, int deporteId = 0, int delegacionId = 0, string search = "")
        {
            if (string.IsNullOrEmpty(search))
                search = "";
            DataTable dt = new DataTable();            
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("PersonaId", personaId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            ls.Add(new SqlParameter("DelegacionId", delegacionId));
            ls.Add(new SqlParameter("Search", search));
            dt = db.GetStoreProcedure("[acre].[pGetCompetidorEvento]", ls);
            return dt;
        }
        public static DataTable GetPersonaPrueba(int eventoId, int personaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("PersonaId", personaId));
            dt = db.GetStoreProcedure("[acre].[pGetPersonaPruebas]", ls);
            return dt;
        }
        public static DataTable GetUltimoCronogramaId(int eventoId, int deporteId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            dt = db.GetStoreProcedure("conj.pGetUltimoCronogramaId", ls);
            return dt;
        }
        #endregion
        public static DataTable GetDelegaciones(int eventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[acre].[vDelegaciones] where EventoId = {0}", eventoId));
            return dt;
        }
        public static DataTable GetDeportes(int eventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[prog].[fDeportes]({0})", eventoId));
            return dt;
        }
        public static DataTable GetIsIndividual(int eventoId, int deporteId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[prog].[fEsIndividual]({0}, {1})", eventoId, deporteId));
            return dt;
        }
        public static DataTable GetPruebas(int eventoId, int deporteId, int esIndividual)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[prog].[fPruebas]({0},{1},{2})", eventoId, deporteId, esIndividual));
            return dt;
        }
        public static DataTable GetRamasPrueba(int eventoId, int deporteId, int esIndividual, int pruebaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[prog].[fRamasPruebas]({0},{1},{2},{3})", eventoId, deporteId, esIndividual, pruebaId));
            return dt;
        }
        public static DataTable GetResumenJornada(int deporteId, string fecha, int eventoId = 4, int delegacionId = 0)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("DelegacionId", delegacionId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            if(fecha.ToLower()!="null")
            {
                ls.Add(new SqlParameter("Fecha", fecha));
            }
            dt = db.GetStoreProcedure("[rpt].[pGetProgramacionConjunto]", ls);

            DataView view = new DataView(dt);
            view.Sort = "HoraProgramada";
            dt1 = view.ToTable(); ;
            return dt1;
        }
        public static DataTable GetCompetidoresDeporte(int deporteId, int pruebaId, int parametroRamaId, int eventoId = 1)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            DataSet ds = new DataSet();

            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("PruebaId", pruebaId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            ls.Add(new SqlParameter("ParametroRamaId", parametroRamaId));
            dt = db.GetStoreProcedure("[prog].[pGetCompetidoresDeportes]", ls);
            return dt;
        }
        public static DataTable GetAsistentes(int cronogramaId, int competidorId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetDirectorTecAsistentes]({0},{1})", cronogramaId, competidorId));
            return dt; 
        }
        #region Metodos Instalaciones
        public static DataTable GetInstalaciones(int eventoId, int tipo)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[prog].[fGetInstalacion]({0}, {1})", tipo, eventoId));
            return dt;
        }
        public static DataTable GetProgramacionInstalaciones(int eventoId, int instalacionId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("InstalacionId", instalacionId));
            dt = db.GetStoreProcedure("[prog].[pGetProgramacionInstalaciones]", ls);
            return dt;
        }
        #endregion
        public static List<ImagenFile> GetImagesFile(string eventoId, string directorio)
        {
            List<ImagenFile> lsI = new List<ImagenFile>();
            string fdir = string.Format(@"{0}\{1}\{2}", ConfigurationManager.AppSettings["ApplicationResources"], eventoId, directorio);
            DirectoryInfo dir = new DirectoryInfo(fdir);
            foreach (var fi in dir.GetFiles())
            {
                ImagenFile i = new ImagenFile();
                i.Name = fi.Name;
                i.ImagenId = i.Name.Replace(fi.Extension, "");
                i.Extension = fi.Extension;
                i.GetFotoPersona(fi.FullName);
                lsI.Add(i);
            }
            return lsI;
        }
        #region Get Datos Encuentros
        public static DataTable GetPlanilla(int cronogramaId, int competidorId, int parametroRolId, int deporteId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            ls.Add(new SqlParameter("CompetidorId", competidorId));
            ls.Add(new SqlParameter("ParametroRolId", parametroRolId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            dt = db.GetStoreProcedure("[conj].[pGetPlanillas]", ls);
            return dt;
        }
        public static DataTable GetResultados(int cronogramaId, int competidorId, int deporteId, int gol)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            ls.Add(new SqlParameter("CompetidorId", competidorId));
            ls.Add(new SqlParameter("Gol", gol));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            dt = db.GetStoreProcedure("[conj].[pGetGolTarjeta]", ls);
            return dt;
        }
        public static DataTable GetHistorialCronograma(int cronogramaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            ls.Add(new SqlParameter("CompetidorId", 0));
            ls.Add(new SqlParameter("DeportePeriodoId", 0));
            dt = db.GetStoreProcedure("[conj].[pHistorialCronograma]", ls);
            return dt;
        }
        #endregion
    }
    public class ImagenFile
    {
        public string ImagenId { get; set; }
        public string Imagen { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }

        public void GetFotoPersona(string fullpath)
        {
            if (File.Exists(fullpath))
            {

                this.Imagen = string.Format("data:image/jpeg;base64,{0}", ImageToString(fullpath));
            }
            else
            {
                this.Imagen = "";
            }
        }
        public static string ImageToString(string ImageFile)
        {
            string imagen = string.Empty;
            if (File.Exists(ImageFile))
            {
                byte[] fileData = File.ReadAllBytes(ImageFile);
                imagen = Convert.ToBase64String(fileData);
            }
            return imagen;
        }
    }
}
