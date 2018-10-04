using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HamSetModel
{
    public class SucesoPersona
    {
        #region Metodos
        public int SucesoId {get; set;}
        public int PlanillaPersonaId { get; set; }
        public int Orden { set; get; }
        #endregion
        public PlanillaPersona PlanillaPersona { get; set; }


        public static SucesoPersona ConvertToSucesoPersona(DataRow dr)
        {
            SucesoPersona scp = new SucesoPersona();
            scp.SucesoId = Convert.ToInt32(dr["SucesoId"]);
            scp.PlanillaPersonaId = !string.IsNullOrEmpty(dr["PlanillaPersonaId"].ToString()) ?Convert.ToInt32(dr["PlanillaPersonaId"]):0;
            scp.Orden =  !string.IsNullOrEmpty(dr["Orden"].ToString())? Convert.ToInt32(dr["Orden"]): 0 ;
            return scp;
            

        }
    }
}
