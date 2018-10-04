using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HamServicesSecurity.Models
{
    public class Complainant
    {
        public int ComplainantId { get; set; }
        public string   Name { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string NroDocument { get; set; }
        public int ParameterExtent { get; set; }
        public int ParameterGender { get; set; }
        public DateTime BirthDate { get; set; }
        public int ParameterCivilStatus { get; set; }
        public int ParameterNationality { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int LaborDataId { get; set; }
        public string Occupation { get; set; }
        public string Workplace { get; set; }
        public string wPhone { get; set; }
        public string wAddress { get; set; }

    }
}