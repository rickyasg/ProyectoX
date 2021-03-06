//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HamDataModel
{
    using HamDataTransactions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public partial class GolfHoyoPar
    {
        #region Propiedades
        public int HoyoParId { get; set; }
        public int Azules { get; set; }
        public int Blancas { get; set; }
        public int Rojas { get; set; }
        public string Hoyo { get; set; }
        public int Ventaja { get; set; }
        public int Par { get; set; }
        public int Tipo { get; set; }
        const string Entity = "GolfHoyoPar";
        #endregion

        #region Metodos GET
        public static int GetParTotal()
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView("[golf].[HoyoPar] where HoyoParId = 22");

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Par"]);
            }
            else
            {
                return 0;
            }
        }

        public static DataTable GetGolfHoyoPar(int tipoHoyoId)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[golf].[HoyoPar] WHERE Tipo = {0}", tipoHoyoId));
            return dt;
        }
        public static DataTable GetGolfHoyoPar(string sql)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[golf].[HoyoPar]  {0}", sql));
            return dt;
        }
        #endregion

    }
}
