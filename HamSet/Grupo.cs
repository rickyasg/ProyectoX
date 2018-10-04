using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
// ReSharper disable InconsistentNaming

namespace HamSetModel
{
    public class Grupo
    {
        public int GrupoId { get; set; }
        public string GrupoDescripcion { get; set; }
        public int ParametroFaseId { get; set; }
        public int PruebaEventoId { get; set; }

        public List<GrupoEquipo> GrupoEquipos { get; set; }

        public static List<Grupo> GetGruposEquipos(int deporteId, int ramaId, int eventoId, int faseId)
        {
            List<Grupo> lg = new List<Grupo>();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("DeporteId", deporteId));
            lp.Add(new SqlParameter("RamaId", ramaId));
            lp.Add(new SqlParameter("EventoId", eventoId));
            lp.Add(new SqlParameter("FaseId", faseId));
            DataTable dt = ExecuteTransaction("[conj].[pGetGruposEvento]", lp);
            foreach (DataRow dr in dt.Rows)
            {
                Grupo gr = new Grupo();
                gr=gr.ConvertToGrupo(dr);
                DBTransaction db = new DBTransaction();
                DataTable dt1= db.GetDataView(String.Format("[prog].[fGetEquiposGrupo] ({0})", gr.GrupoId));
                gr.GrupoEquipos = new List<GrupoEquipo>();
                foreach (DataRow dr1 in dt1.Rows)
                {
                    GrupoEquipo ge = new GrupoEquipo();
                    ge = GrupoEquipo.ConvertToGrupoEquipo(dr1);
                    gr.GrupoEquipos.Add(ge);
                }
                lg.Add(gr);
            }
            return lg;
        }

        public static List<Grupo> GetGrupos (int deporteId, int ramaId, int eventoId, int faseId)
        {
            Grupo g = new Grupo();
            List<Grupo> lg = new List<Grupo>();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("DeporteId", deporteId));
            ls.Add(new SqlParameter("RamaId", ramaId));
            ls.Add(new SqlParameter("EventoId", eventoId));
            ls.Add(new SqlParameter("FaseId", faseId));
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure("[conj].[pGetGruposEvento]", ls);
            foreach (DataRow dr in dt.Rows)
            {
                g = g.ConvertToGrupo(dr);
                lg.Add(g);
            }
            return lg;
        }
        public static DataTable GetEquiposDeporte(int deporteId, int ramaId, int eventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("DeporteId", deporteId));
            ls.Add(new SqlParameter("RamaId", ramaId));
            ls.Add(new SqlParameter("EventoId", eventoId));
            dt = db.GetStoreProcedure("[conj].[pGetEquiposDeporte]", ls);
            return dt;
        }


        #region grupos
        public bool InsertGrupos()
        {
            List<SqlParameter> ls = new List<SqlParameter>
            {
                new SqlParameter("ParametroFaseId", ParametroFaseId),
                new SqlParameter("Grupo", GrupoDescripcion.ToUpper()),
                new SqlParameter("PruebaEventoId", PruebaEventoId)
            };

            return ExecuteTransactionData("[prog].[pInsGrupos]", ls);
        }
        public bool UpdateGrupos()
        {
            List<SqlParameter> ls = new List<SqlParameter>
            {
                new SqlParameter("GrupoId", GrupoId),
                new SqlParameter("ParametroFaseId", ParametroFaseId),
                new SqlParameter("Grupo", GrupoDescripcion),
                new SqlParameter("PruebaEventoId", PruebaEventoId)
            };

            return ExecuteTransactionData("[prog].[pUpdGrupos]", ls);
        }

        public static bool DeleteGrupo(int GrupoId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter> {new SqlParameter("GrupoId", GrupoId)};
            db.ExecStoreProcedure("[prog].[pDelGrupos]", ls);
            return (db.RowAffected > 0);
        }
        public static DataTable GetGruposEvento(int pruebaEventoId)
        {
            DBTransaction db = new DBTransaction();
            var dt = db.GetDataView($"[prog].[fGetGruposPruebasEvento] ({pruebaEventoId})");
            return dt;
        }
        #endregion


        #region Membrs
        public Grupo ConvertToGrupo(DataRow dr)
        {
            Grupo gr = new Grupo();
            if (dr!= null)
            {
                gr.GrupoId = Convert.ToInt32(dr["GrupoId"]);
                gr.ParametroFaseId= Convert.ToInt32(dr["ParametroFaseId"]);
                gr.GrupoDescripcion = Convert.ToString(dr["Grupo"]);
                gr.PruebaEventoId = Convert.ToInt32(dr["PruebaEventoId"]);
            }
            return gr;
        }
        private static DataTable ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetStoreProcedure(procedureName, ps);
            return dt;
        }
        #endregion
        #region Metodos Privados
        private static bool ExecuteTransactionData(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        #endregion
    }
}
