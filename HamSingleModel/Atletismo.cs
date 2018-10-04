using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamDataTransactions;
using System.Data.SqlClient;

namespace HamSingleModel
{
    public class Atletismo
    {
        public int CompetidorId { get; set; }
        public int PruebaEventoId { get; set; }
        public int PruebaEventoIdCalcular { get; set; }
        public decimal Marca { get; set; }
        public string Tiempo { get; set; }
        public bool Activo { get; set; }



        public static DataTable GetPlanillaAtletismo(int pruebaEventoId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("PruebaEventoId",pruebaEventoId));
            DataTable td = db.GetStoreProcedure("indv.pGetPlanillaMiniAtletismo", lp);
            return td;
        }
        public int save()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("PruebaEventoId", PruebaEventoId));
            ps.Add(new SqlParameter("PruebaEventoIdCalcular", PruebaEventoIdCalcular));
            if (Marca != 0)
            {
                ps.Add(new SqlParameter("Marca", Marca  ));
            }
            if (Tiempo != null)
            {
                ps.Add(new SqlParameter("Tiempo", Tiempo));
            }
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));

            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure("indv.pInsResultadosMiniAtletismo", ps);
            return db.RowAffected;
        }
        public int UpdateEstado()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CompetidorId", CompetidorId));
            ps.Add(new SqlParameter("Activo",Activo));
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure("indv.pUpEstadoCompetidor", ps);
            return db.RowAffected;
        }
    }
}
