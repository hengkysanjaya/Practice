using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmonicAirline
{
    class SurveyDetailData
    {
        public string Question { get; set; }
        public string Choice { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string CabinType { get; set; }
        public string DestinationAirport { get; set; }
        public int GenderValue { get; set; }
        public int AgeValue { get; set; }
        public int CabinTypeValue { get; set; }
        public int DestinationAirportValue { get; set; }
    }
}
