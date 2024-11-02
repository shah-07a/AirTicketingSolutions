using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FareSettingsParameters
    {
        public bool CCEnableAir { get; set; }
        public double StandardPublishedMarkup { get; set; }
        public double StandardNetMarkup { get; set; }
        public double StandardTourNetMarkup { get; set; }
        public double InfantFare { get; set; }
        public bool IsAveragefare { get; set; }
        public bool IsChangeCancelDisplay { get; set; }
        
	}
}
