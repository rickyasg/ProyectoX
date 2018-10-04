using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamSetModel
{
    public class EquipoPersona
    {
        #region Propiedades
        public int EquipoId { get; set; }
        public int PersonaId { get; set; }
        public string Posicion { get; set; }
        public string NroCamiseta { get; set; }
        public string Nombre { get; set; }
        public string Delegacion { get; set; }
        public string Representacion { get; set; }
        public string NombreAbreviado { get; set; }

        #endregion
        #region Metodos DML

        public static List<EquipoPersona> getEquiposPersona(int EquipoId)
        {
            List<EquipoPersona> dp = new List<EquipoPersona>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("acre.fGetEquipoPersona ({0})", EquipoId));
            foreach (DataRow item in dt.Rows)
            {
                EquipoPersona dper = ConvertToEquipoPersona(item);
                dp.Add(dper);
            }
            return dp;

        }



        #region Post

        public bool SaveEquipoPersona()
        {


            DataTable dt = new DataTable();
            DBTransaction db = new DBTransaction();
            List<SqlParameter> lp = new List<SqlParameter>();
            lp.Add(new SqlParameter("EquipoId", EquipoId));
            lp.Add(new SqlParameter("PersonaId", PersonaId));
            lp.Add(new SqlParameter("Posicion", Posicion));
            lp.Add(new SqlParameter("NroCamiseta", NroCamiseta));

            db.ExecStoreProcedure("[acre].[pInsEquipoPersona]", lp);

            return (db.RowAffected > 0);
        }
        public static bool DeleteEquipoPersona(int equipoId, int PersonaId)
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EquipoId", equipoId));
            ls.Add(new SqlParameter("PersonaId", PersonaId));

            db.ExecStoreProcedure("[acre].[pDelEquipoPersona]", ls);
            return (db.RowAffected > 0);
        }







        #endregion


        public static bool UpdateEquipoPersona(int equipoId, int personaId, string posicion, int nroCamiseta, int planillaPersonaId, int parametroRolId, int capitan)
        {
            List<SqlParameter> ls = new List<SqlParameter>();
            ls.Add(new SqlParameter("EquipoId", equipoId));
            ls.Add(new SqlParameter("PersonaId", personaId));
            ls.Add(new SqlParameter("Posicion", posicion));
            ls.Add(new SqlParameter("NroCamiseta", nroCamiseta));
            ls.Add(new SqlParameter("PlanillaPersonaId", planillaPersonaId));
            ls.Add(new SqlParameter("ParametroRolId", parametroRolId));
            ls.Add(new SqlParameter("Capitan", capitan));
            return (ExecuteTransactionData("[conj].[pUpdEquipoPersona]", ls));
        }
        #endregion

        #region Private Members
        private static EquipoPersona ConvertToEquipoPersona(DataRow dr)
        {
            EquipoPersona dper = new EquipoPersona();
            if (dr != null)
            {
                dper.EquipoId = Convert.ToInt32(dr["EquipoId"]);
                dper.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                dper.Nombre = Convert.ToString(dr["Nombre"]);
                dper.Posicion = Convert.ToString(dr["Posicion"]);
                dper.NroCamiseta = Convert.ToString(dr["NroCamiseta"]);
                dper.Delegacion = Convert.ToString(dr["Delegacion"]);
                dper.Representacion = Convert.ToString(dr["Representacion"]);
                dper.NombreAbreviado = Convert.ToString(dr["NombreAbreviado"]);

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
