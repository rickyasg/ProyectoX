using HamDataTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamCommon
{
    public class Disciplina
    {
        #region Propiedades
        public int DisciplinaId { get; set; }
        public string Nombre { get; set; }
        public int DependienteId { get; set; }
        public int Activo { get; set; }
        public int Orden { get; set; }
        public string Color { get; set; }
        public int GestionId { get; set; }
        public string Usuario { get; set; }

        private const string Entity = "Disciplinas";
        #endregion

        #region Metodos GET
        public static List<Disciplina> GetDisciplinasActivas(int eventoId)
        {
            List<Disciplina> led = new List<Disciplina>();
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("[Disciplinas] WHERE Activo = 1 AND EventoDeportivoId = {0}", eventoId));
            foreach (DataRow dr in dt.Rows)
            {
                Disciplina ed = ConvertToEDisciplina(dr);
                led.Add(ed);
            }
            return led;
        }

        public static DataTable GetGestionesEventos(int eventoId)
        {
            DBTransaction db = new DBTransaction();
            DataTable dt = db.GetDataView(string.Format("vGetDeportes WHERE v.Activo = 1 AND v.DependienteId > 0 AND v.DisciplinaId not in (SELECT e.DisciplinaId FROM [EventoDeportivoDisciplinas] e WHERE e.EventoDeportivoId = {0})", eventoId));
            return dt;
        }

        public static DataTable GetUbicaciones()
        {
            DBTransaction db = new DBTransaction();
            return db.GetDataView("Instalaciones");
        }
        #endregion

        #region Private Members
        private static Disciplina ConvertToEDisciplina(DataRow dr)
        {
            Disciplina dc = new Disciplina();
            if (dr != null)
            {
                dc.DisciplinaId = Convert.ToInt32(dr["DisciplinaId"]);
                dc.Nombre = Convert.ToString(dr["Nombre"]);
                dc.DependienteId = Convert.ToInt32(dr["DependienteId"]);
                dc.Activo = Convert.ToInt32(dr["Activo"]);
                dc.Orden = Convert.ToInt32(dr["Orden"]);
                dc.Color = Convert.ToString(dr["Color"]);
                dc.GestionId = Convert.ToInt32(dr["GestionId"]);
                dc.Usuario = Convert.ToString(dr["Usuario"]);
            }
            return dc;
        }
        #endregion
    }
}
