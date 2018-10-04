using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamSingleModel
{
    public class Singles
    {
        #region Metodos Get
        public static DataTable BusquedaCompetidores(string search, int cronogramaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List <SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("Search", search));
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            dt = db.GetStoreProcedure("[indv].[pSearchCompetidor]", ls);
            return dt;
        }
        public static DataTable GetCompetidoresPrueba(int cronogramaId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[indv].[fGetCompetidoresPrueba]({0}) order by Posicion, Sembrado", cronogramaId));
            return dt;
        }
        public static DataTable GetCompetidor(int cronogramaId, int posicion)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[indv].[fGetCompetidoresDatos]({0},{1})", cronogramaId,posicion));
            return dt;
        }
        #endregion


        public static bool UpdateCronograma(int cronogramaId, int competidorId, string posicion, int parametromedallaId, int Sembrado, decimal marca, int esGanador, bool esRecord , string tiempo)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("CronogramaId", cronogramaId));
            ls.Add(new SqlParameter("CompetidorId", competidorId));
            ls.Add(new SqlParameter("Posicion", posicion));
            ls.Add(new SqlParameter("ParametroMedallaId", parametromedallaId));
            ls.Add(new SqlParameter("Sembrado", Sembrado));
            ls.Add(new SqlParameter("Tiempo", tiempo));
            ls.Add(new SqlParameter("Marca", marca));
            ls.Add(new SqlParameter("EsGanador", esGanador));
            ls.Add(new SqlParameter("EsRecord", esRecord));
            db.ExecStoreProcedure("[indv].[pUpCronogramaCompetidor]", ls);
            return (db.RowAffected > 0);
        }
    }
}
