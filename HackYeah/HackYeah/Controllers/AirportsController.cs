using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HackYeah.Models;
using HackYeah.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace HackYeah.Controllers
{
    [Route("dej/lotniska")]
    public class AirportsController : Controller
    {        
        private List<AirportsInCountries> _processedCountries = null;
        
        IAuthenticationService _authenticationService;
        ICountryService _countryService;

        public AirportsController(IAuthenticationService authenticationService, ICountryService countryService)
        {
            _authenticationService = authenticationService;
            _countryService = countryService;
        }
              
        // GET api/values
        [HttpGet]
        public string GetAsync()
        {
            if (_processedCountries == null)
            {
                const string url = "https://api.lot.com/flights-dev/v2";
                var token = _authenticationService.GetToken();

                var client = new RestClient(url);
                var request = new RestRequest("common/airports/get");
                request.AddHeader("content-type", "application/json");
                request.AddHeader("X-Api-Key", "9YFNNKS31u9gCFKPetPWdAAjEXnED0B3K18AeYgg");
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddJsonBody(new { secret_key = "2przp49a52" });
                var response = client.Get<AirportsInCountries>(request);

                var countries = JsonConvert.DeserializeObject<List<AirportsInCountries>>(response.Content);
                _processedCountries = _countryService.ProcessCityTags(countries);
            }                       

            return JsonConvert.SerializeObject(_processedCountries);
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value1";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
