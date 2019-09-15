using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackYeah.Models
{
    public class AirportsInCountries
    {
        public string country { get; set; }
        public int countryOrderNumber { get; set; }
        public List<Airports> cities;
        
        public AirportsInCountries()
        {            
            cities = new List<Airports>();
        }
    }

    public class Airports
    {
        public Airports()
        {
            tags = new List<string>();
        }
        public string city { get; set; }
        public string iata { get; set; }
        public int cityOrderNumber { get; set; }
        public List<string> tags;

        
    }
}
