using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HamSetModel
{
    public class Equipos
    {
        public int EquipoId { get; set; }
        public string Equipo { get; set; }
        public int DelegacionId { get; set; }
        public int PruebaEventoId { get; set; }
        public int PruebaId { get; set; }
        public int DeporteId { get; set; }
        public int ParametroRamaId { get; set; }
        public int EventoId { get; set; }
        public string Nombre { get; set; }
        public string Deporte { get; set; }
        public string PruebaRama { get; set; }
        public int NroDeportistas { get; set; }

        public static List<Equipos> getEquipos(int EquipoId)
        {
            List<Equipos> dp = new List<Equipos>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("acre.fEquipos ({0})", EquipoId));
            foreach (DataRow item in dt.Rows)
            {
                Equipos dper = ConvertToEquipo(item);
                dp.Add(dper);
            }
            return dp;

        }

        public static List<Equipos> getDeporteEquipos(int EquipoId)
        {
            List<Equipos> dp = new List<Equipos>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("acre.fGetDeporteEquipos ({0})", EquipoId));
            foreach (DataRow item in dt.Rows)
            {
                Equipos dper = ConvertToDeporteEquipos(item);
                dp.Add(dper);
            }
            return dp;

        }

   


        public static List<Equipos> getEquiposPrueba(int PruebaEventoId)
        {
            List<Equipos> dp = new List<Equipos>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("acre.fGetEquiposPruebas ({0})", PruebaEventoId));
            foreach (DataRow item in dt.Rows)
            {
                Equipos dper = ConvertToEquipos(item);
                dp.Add(dper);
            }
            return dp;

        }

       

        public static DataTable GetGelegacion( int eventoId)
        {
            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            dt = db.GetDataView(string.Format("[acre].[fGetDelegacionesEvento]({0})", eventoId));
            return dt;
        }

        #region Post

        public bool SaveEquipo()
        {


            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("Equipo", Equipo.ToUpper()));
            lp.Add(new SqlParameter("DelegacionId", DelegacionId));
            lp.Add(new SqlParameter("PruebaId", PruebaId));
            lp.Add(new SqlParameter("ParametroRamaId", ParametroRamaId));
            lp.Add(new SqlParameter("EventoId", EventoId));

            if (this.EquipoId == 0)
            {
                db.ExecStoreProcedure("[acre].[pInsEquipo]", lp);
            }
            else
            {
                lp.Clear();
                lp.Add(new SqlParameter("EquipoId", this.EquipoId));
                lp.Add(new SqlParameter("Equipo", Equipo.ToUpper()));
                lp.Add(new SqlParameter("DelegacionId", DelegacionId));
                lp.Add(new SqlParameter("PruebaEventoId", PruebaEventoId));

                db.ExecStoreProcedure("[acre].[pUpdEquipos]", lp);
            }


            return db.RowAffected > 1 ? true : false;


        }
        public static bool DeleteEquipo(int equipoId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EquipoId", equipoId));
            db.ExecStoreProcedure("[acre].[pDelEquipos]", ls);
            return (db.RowAffected > 0);
        }
        #endregion








        #region Private Members
        private static Equipos ConvertToEquipos(DataRow dr)
        {
            Equipos dper = new Equipos();
            if (dr != null)
            {
                dper.EquipoId = Convert.ToInt32(dr["EquipoId"]);
                dper.DelegacionId = Convert.ToInt32(dr["DelegacionId"]);
                dper.PruebaEventoId = Convert.ToInt32(dr["PruebaEventoId"]);
                dper.Equipo = Convert.ToString(dr["Equipo"]);
                dper.Nombre = Convert.ToString(dr["Nombre"]);
                dper.Deporte = Convert.ToString(dr["Deporte"]);
                dper.DeporteId = Convert.ToInt32(dr["DeporteId"]);
                dper.PruebaRama = Convert.ToString(dr["PruebaRama"]);
                dper.NroDeportistas = Convert.ToInt32(dr["NroDeportistas"]);

            }
            return dper;
        }

        private static Equipos ConvertToEquipo(DataRow dr)
        {
            Equipos dper = new Equipos();
            if (dr != null)
            {
                dper.EquipoId = Convert.ToInt32(dr["EquipoId"]);
                dper.Equipo = Convert.ToString(dr["Equipo"]);



            }
            return dper;
        }

        private static Equipos ConvertToDeporteEquipos(DataRow dr)
        {
            Equipos dper = new Equipos();
            if (dr != null)
            {
                dper.EquipoId = Convert.ToInt32(dr["DeporteId"]);
                dper.Equipo = Convert.ToString(dr["Deporte"]);



            }
            return dper;
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
