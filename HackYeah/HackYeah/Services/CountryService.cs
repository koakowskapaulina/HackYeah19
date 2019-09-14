using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HackYeah.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace HackYeah.Services
{
    public interface ICountryService
    {
        List<AirportsInCountries> ProcessCityTags(List<AirportsInCountries> countries);
    }

    public class CountryService : ICountryService
    {
        public string hot = "hot";
        public string cheap = "cheap";
        public string away = "away";
        public string near = "near";
        public string beach = "beach";
        public string seesighting = "seesighting";
        public string rest = "rest";
        
        public List<AirportsInCountries> ProcessCityTags(List<AirportsInCountries> countries)
        {
            foreach(var country in countries)
            {
                foreach (var city in country.cities)
                {
                    city.tags = AssignTags(city.city);
                }
            }

            return countries;
        }

        #region hey, dont look here
        private List<string> AssignTags(string country)
        {
            switch (country.ToUpper())
            {
                case "NICE":
                    return new List<string>(new string[] {near, beach });
                case "PARIS":
                    return new List<string>(new string[] { near, beach, seesighting, rest });
                case "BERLIN":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "FRANKFURT":
                    return new List<string>(new string[] { near, seesighting, rest  });
                case "MUNICH":
                    return new List<string>(new string[] { near, seesighting, rest  });
                case "ATHENS":
                    return new List<string>(new string[] { near, seesighting, rest, hot, beach });
                case "BUDAPEST":
                    return new List<string>(new string[] { near, seesighting, rest, cheap });
                case "DELHI":
                    return new List<string>(new string[] { away, seesighting, rest, hot, cheap });
                case "TEL AVIV":
                    return new List<string>(new string[] { near, seesighting, rest, hot });
                case "TOKYO":
                    return new List<string>(new string[] { away, rest });
                case "CRACOW":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "GDANSK":
                    return new List<string>(new string[] { near, seesighting, rest, beach });
                case "WARSAW":
                    return new List<string>(new string[] { near, seesighting, rest,  });
                case "WROCLAW":
                    return new List<string>(new string[] { near, seesighting, rest,  });
                case "MOSCOW (ALL)":
                    return new List<string>(new string[] { near, seesighting, rest,  });
                case "SINGAPORE":
                    return new List<string>(new string[] { away, seesighting, rest, beach, hot });
                case "BARCELONA":
                    return new List<string>(new string[] { near, seesighting, rest, beach, hot });
                case "MADRID":
                    return new List<string>(new string[] { near, seesighting, rest, hot });
                case "GENEVA":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "ZURICH":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "ISTANBUL":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "LONDON (ALL)":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "LONDON (CITY)":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "LONDON (HEATHROW)":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "CHICAGO":
                    return new List<string>(new string[] { away, rest });
                case "LOS ANGELES":
                    return new List<string>(new string[] { away, rest, hot, beach });
                case "MIAMI":
                    return new List<string>(new string[] { away, rest, hot, beach });
                case "NEW YORK":
                    return new List<string>(new string[] { away, rest });
                case "NEW YORK (ALL)":
                    return new List<string>(new string[] { away, rest });
                case "LVIV":
                    return new List<string>(new string[] { near, rest, cheap });
                case "ODESSA":
                    return new List<string>(new string[] { near, rest, cheap });

                default:
                    return new List<string>();
                    
            }
                        
        }
        #endregion
    }



}

