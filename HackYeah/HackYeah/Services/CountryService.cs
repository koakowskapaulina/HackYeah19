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
        public string party = "party";

        public List<AirportsInCountries> ProcessCityTags(List<AirportsInCountries> countries)
        {
            foreach (var country in countries)
            {
                switch (country.country.ToUpper())
                {
                    case ("INDIA"):
                        country.countryOrderNumber = 2;
                        country.annualTemp = "23.65";
                        country.currency = "Rupee";
                        break;
                    case ("JAPAN"):
                        country.countryOrderNumber = 3;
                        country.annualTemp = "11.15";
                        country.currency = "Yen";
                        break;
                    case ("POLAND"):
                        country.countryOrderNumber = 4;
                        country.annualTemp = "7.85";
                        country.currency = "PLN";
                        break;
                    case ("ISRAEL"):
                        country.countryOrderNumber = 1;
                        country.annualTemp = "19.20";
                        country.currency = "Shekel"; 
                        break;
                    case ("USA"):
                        country.countryOrderNumber = 5;
                        country.annualTemp = "8.55";
                        country.currency = "USD";
                        break;
                    default:
                        country.countryOrderNumber = 6;
                        country.annualTemp = "Upgrade to Premium";
                        country.currency = "Upgrade to Premium";
                        break;

                }

                foreach (var city in country.cities)
                {
                    switch (city.city.ToUpper())
                    {
                        case ("WARSAW"):
                            city.cityOrderNumber = 0;
                            break;
                        case ("NEW YORK"):
                            city.cityOrderNumber = 0;
                            break;
                        case ("NEW YORK (ALL)"):
                            city.cityOrderNumber = 1;
                            break;
                        default:
                            city.cityOrderNumber = 2;
                            break;
                    }
                    city.tags = AssignTags(city.city);
                }
            }
            foreach (var country in countries)
            {
                country.cities = country.cities.OrderBy(c => c.cityOrderNumber).Cast<Airports>().ToList();
            }

            return countries.OrderBy(c => c.countryOrderNumber).Cast<AirportsInCountries>().ToList();
        }

        #region hey, dont look here
        private List<string> AssignTags(string country)
        {
            switch (country.ToUpper())
            {
                case "NICE":
                    return new List<string>(new string[] { near, beach, party });
                case "PARIS":
                    return new List<string>(new string[] { near, beach, seesighting, rest, party });
                case "BERLIN":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "FRANKFURT":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "MUNICH":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "ATHENS":
                    return new List<string>(new string[] { near, seesighting, rest, hot, beach, party });
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
                    return new List<string>(new string[] { near, seesighting, rest, party });
                case "WROCLAW":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "MOSCOW (ALL)":
                    return new List<string>(new string[] { near, seesighting, rest, party });
                case "SINGAPORE":
                    return new List<string>(new string[] { away, seesighting, rest, beach, hot });
                case "BARCELONA":
                    return new List<string>(new string[] { near, seesighting, rest, beach, hot, party });
                case "MADRID":
                    return new List<string>(new string[] { near, seesighting, rest, hot, party });
                case "GENEVA":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "ZURICH":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "ISTANBUL":
                    return new List<string>(new string[] { near, seesighting, rest });
                case "LONDON (ALL)":
                    return new List<string>(new string[] { near, seesighting, rest, party });
                case "LONDON (CITY)":
                    return new List<string>(new string[] { near, seesighting, rest, party });
                case "LONDON (HEATHROW)":
                    return new List<string>(new string[] { near, seesighting, rest, party });
                case "CHICAGO":
                    return new List<string>(new string[] { away, rest });
                case "LOS ANGELES":
                    return new List<string>(new string[] { away, rest, hot, beach, party });
                case "MIAMI":
                    return new List<string>(new string[] { away, rest, hot, beach, party });
                case "NEW YORK":
                    return new List<string>(new string[] { away, rest, party });
                case "NEW YORK (ALL)":
                    return new List<string>(new string[] { away, rest, party });
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

