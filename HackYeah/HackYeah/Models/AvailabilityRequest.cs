using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackYeah.Models
{
    public class AvailabilityRequest
    {
        public string[] origin { get; set; }  
        public string[] destination { get; set; }  
        public string[] departureDate { get; set; } 
        public string cabinClass { get; set; }
        public string market { get; set; }
        public string tripType { get; set; }
        public int adt { get; set; }
    }
}
