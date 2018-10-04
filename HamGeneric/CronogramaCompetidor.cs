using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class CronogramaCompetidor
    {
        #region Propiedades
        public int CronogramaId { get; set; }
        public int CompetidorId { get; set; }
        public int Posicion { get; set; }
        public float Puntaje { get; set; }
        public decimal Marca { get; set; }
        public string Tiempo { get; set; }
        public int EsGanador { get; set; }
        public int ParametroMedallaId { get; set; }
        public int Sembrado { get; set; }
        public bool EsRecord { get; set; }
        public bool Activo { get; set; }
        #endregion
        #region Componentes

        public Competidor Competidor { get; set; }

        #endregion
        public static CronogramaCompetidor GetCronogramaCompetidor(int competidorId, int eventoId)
        {

            CronogramaCompetidor cc = new CronogramaCompetidor();
            cc.Competidor = Competidor.GetCompetidor(competidorId, eventoId, true);
            return cc;
        }

        #region Métodos DML
        public bool Save()
        {
            bool result = false;
            result = Insert();
        return result;
        }

     

        public static bool DeleteCronogramaCompetidor(int cronogramaId, int competidorId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CronogramaId", cronogramaId));
            ps.Add(new SqlParameter("CompetidorId", competidorId));
            db.ExecStoreProcedure("[indv].[pDelCronogramaCompetidor]", ps);
            return (db.RowAffected > 0);
        }
        #endregion
        #region Metodos Privados
        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CronogramaId", CronogramaId));
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            ps.Add(new SqlParameter("Posicion", Posicion));
            ps.Add(new SqlParameter("Puntaje", Puntaje));
            ps.Add(new SqlParameter("Marca", Marca));
            ps.Add(new SqlParameter("Tiempo", Tiempo));
            ps.Add(new SqlParameter("EsGanador", EsGanador));
            ps.Add(new SqlParameter("ParametroMedallaId", ParametroMedallaId));
            ps.Add(new SqlParameter("Sembrado", Sembrado));
            return ps;
        }
        private bool Insert()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = LoadParameters();
            return ExecuteTransaction("[indv].[pInsCronogramaCompetidor]", ps);
        }

  

        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        #endregion
    }
}
