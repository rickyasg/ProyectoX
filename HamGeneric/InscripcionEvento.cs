using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamGeneric
{
    public class InscripcionEvento
    {
        #region Propiedades
        public int PersonaId { get; set; }
        public int EventoId { get; set; }
        public int DelegacionId { get; set; }
        public  Nullable<int> RepresentacionId { get; set; }
        public int RolId { get; set; }
        public string Grado { get; set; }
        public string Talla { get; set; }
        public decimal Peso { get; set; }
        public decimal Estatura { get; set; }
        public int Edad { get; set; }
        public string Codigo { get; set; }
        public int DeporteId { get; set; }
        public int PruebaId { get; set; }
        public int ParametroRamaId { get; set; }
 

        private const string Entity = "acre.InscripcionEvento";
        #endregion

        #region Componentes
        public Deporte Deporte { get; set; }
        public Prueba Prueba { get; set; }
        public Evento Evento { get; set; }
        public Delegacion Delegacion { get; set; }
        public Representacion Representacion { get; set; }
        public PruebaEvento PruebaEvento { get; set; }
        public Competidor Competidor { get; set; }
        #endregion

        #region DML

        #endregion

        #region Metodos GET
        public static InscripcionEvento GetInscripcionEvento(int personaId)
        {
            return Parse(personaId);
        }
        public static InscripcionEvento ConvertToInscripcionEvento(DataRow dr)
        {
            InscripcionEvento aie = new InscripcionEvento();
            if (dr != null)
            {
                aie.PersonaId = dr.Table.Columns.Contains("PersonaId") ? Convert.ToInt32(dr["PersonaId"]):0;
                aie.EventoId = dr.Table.Columns.Contains("EventoId") ? Convert.ToInt32(dr["EventoId"]):0;
                aie.DelegacionId = Convert.ToInt32(dr["DelegacionId"]);
                aie.RepresentacionId = dr.Table.Columns.Contains("RepresentacionId")?Convert.ToInt32(dr["RepresentacionId"]): 0;
                aie.RolId =dr.Table.Columns.Contains("RolId") ? Convert.ToInt32(dr["RolId"]):0;
                aie.Grado = dr.Table.Columns.Contains("Grado") ? Convert.ToString(dr["Grado"]): "";
                aie.Talla = dr.Table.Columns.Contains("Talla")? Convert.ToString(dr["Talla"]):"";
                aie.Peso = dr.Table.Columns.Contains("Peso")?Convert.ToInt32(dr["Peso"]):0;
                aie.Estatura = dr.Table.Columns.Contains("Estatura")? Convert.ToInt32(dr["Estatura"]):0;
                aie.Edad = dr.Table.Columns.Contains("Edad")? Convert.ToInt32(dr["Edad"]):0;
            }
            return aie;
        }
        #endregion
        #region Private menbers
        private static InscripcionEvento Parse(int personaId)
        {
            DBTransaction db = new DBTransaction();
            Dictionary<string, int> fields = new Dictionary<string, int>();
            fields.Add(nameof(PersonaId), personaId);
            DataRow dr = db.GetDataRow(Entity, fields);
            InscripcionEvento cp = ConvertToInscripcionEvento(dr);
            return cp;
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
