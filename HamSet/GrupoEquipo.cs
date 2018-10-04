using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamGeneric;
using System.Data;
using System.Data.SqlClient;
using HamDataTransactions;

namespace HamSetModel
{
    public class GrupoEquipo
    {
        #region Propiedades
        public int GrupoId { get; set; }
        public int EquipoId { get; set; }
        public int Orden { get; set; }
        public Equipo   Equipo { get; set; }
        #endregion
        #region Post
        public int SaveEquipoGrupo()
        {
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("GrupoId", GrupoId));
            lp.Add(new SqlParameter("EquipoId", EquipoId));
            lp.Add(new SqlParameter("Orden", Orden));
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure("prog.pUpEquipoGrupo", lp);
            return db.RowAffected;
        }
        public static int DeleteEquipoGrupo(int grupoId, int equipoId)
        {
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("GrupoId", grupoId));
            ls.Add(new SqlParameter("EquipoId", equipoId));
            return Convert.ToInt32(ExecuteTransactionData("[prog].[pDelEquipoGrupo]", ls).Rows[0]["Resultado"]);
        }
        public static bool CreateFixture(int eventoId, int deporteId, int parametroRamaId)
        {
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("DeporteId", deporteId));
            ls.Add(new SqlParameter("ParametroRamaId", parametroRamaId));
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure("[prog].[pCreacionFixture]", ls);
            return (db.RowAffected > 0);
        }
        #endregion
        #region Get
        public static List<GrupoEquipo> GetGrupoEquipo(int grupoId)
        {
            List<GrupoEquipo> lge = new List<GrupoEquipo>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(String.Format("[prog].[fGetEquiposGrupo] ({0})", grupoId));
            foreach (DataRow dr1 in dt.Rows)
            {
                GrupoEquipo ge = new GrupoEquipo();
                ge = GrupoEquipo.ConvertToGrupoEquipo(dr1);
                lge.Add(ge);
            }

            return lge;
        }
        public static DataTable GetGruposDeportes(int eventoId, int deporteId, int parametroRamaId=0)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[conj].[fGetGruposDeporte]({0},{1},{2})", eventoId, deporteId, parametroRamaId));
            return dt;
        }
        #endregion

        #region Private

        public static GrupoEquipo ConvertToGrupoEquipo(DataRow dr)
        {
            GrupoEquipo gre = new GrupoEquipo();
            if (dr !=null)
            {
                gre.GrupoId= dr.Table.Columns.Contains("GrupoId") ? Convert.ToInt32(dr["GrupoId"]) : 0;
                gre.EquipoId = dr.Table.Columns.Contains("EquipoId") ? Convert.ToInt32(dr["EquipoId"]) : 0;
                gre.Orden = dr.Table.Columns.Contains("Orden") ? Convert.ToInt32(dr["Orden"]) : 0;
                gre.Equipo =Equipo.ConvertToEquipo(dr);

            }
            return gre;
        }
        private static DataTable ExecuteTransactionData(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure(procedureName, ps);

            return dt;
        }
        #endregion
    }
}
