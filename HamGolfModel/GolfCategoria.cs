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

    public partial class GolfCategoria
    {
        private const string Entity = "golf.Categorias";

        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> EventoDeportivoId { get; set; }
        public Nullable<int> PruebaEventoId { get; set; }
        public Nullable<double> Porcentaje { get; set; }

        #region Metodos DML
        public bool Save()
        {
            bool result = false;
            if (CategoriaId > 0)
            {
                result = Update();
            }
            else
            {
                result = Insert();
            }
            return result;
        }

        private bool Insert()
        {
            DBTransaction db = new DBTransaction();
            List<SqlParameter> ps = LoadParameters();
            return ExecuteTransaction("[golf].[pNuevaCategoria]", ps);
        }

        private bool Update()
        {
            List<SqlParameter> ps = LoadParameters();
            ps.Add(new SqlParameter("CategoriaId", CategoriaId));
            return ExecuteTransaction("[golf].[pUpCategoria]", ps);
        }

        public bool Delete(int categoriaId)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("CategoriaId", categoriaId));
            return ExecuteTransaction("[golf].[pDelCategoria]", ps);
        }

        private bool ExecuteTransaction(string procedureName, List<SqlParameter> ps)
        {
            DBTransaction db = new DBTransaction();
            db.ExecStoreProcedure(procedureName, ps);
            return (db.RowAffected > 0);
        }
        #endregion

        #region Metodos GET
        public static GolfCategoria GetGolCategoria(int categoriaId)
        {
            return Parse(categoriaId);
        }

        public static List<GolfCategoria> GetGolCategorias(int eventoId)
        {
            List<GolfCategoria> lsc = new List<GolfCategoria>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[golf].[vCategorias] where EventoDeportivoId = {0}", eventoId));
            foreach (DataRow dr in dt.Rows)
            {
                GolfCategoria cg = ConvertToCategoia(dr);
                lsc.Add(cg);
            }
            return lsc;
        }
        #endregion  
        #region Private
        private static GolfCategoria ConvertToCategoia(DataRow dr)
        {
            GolfCategoria cg = new GolfCategoria();
            if (dr != null)
            {
                cg.CategoriaId = Convert.ToInt32(dr["CategoriaId"]);
                cg.Descripcion = Convert.ToString(dr["Descripcion"]);
                cg.EventoDeportivoId = Convert.ToInt32(dr["EventoDeportivoId"]);
                cg.Porcentaje = Convert.ToDouble(dr["Porcentaje"]);
                cg.PruebaEventoId= Convert.ToInt32(dr["PruebaEventoId"]);
            }
            return cg;
        }

        private static GolfCategoria Parse(int categoriaId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(CategoriaId), categoriaId);
            DataRow dr = db.GetDataRow(Entity, fields);
            GolfCategoria cg = ConvertToCategoia(dr);
            return cg;
        }

        private List<SqlParameter> LoadParameters()
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            ps.Add(new SqlParameter("Descripcion", Descripcion));
            ps.Add(new SqlParameter("EventoDeportivoId", EventoDeportivoId));
            ps.Add(new SqlParameter("Porcentaje", Porcentaje));
            return ps;
        }
        #endregion

    }
}