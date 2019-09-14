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
    [Route("dej/availability")]
    public class AvailabilityController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        IAuthenticationService _authenticationService;
        public AvailabilityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET api/values
        [HttpGet]
        public string GetAsync([FromBody] AvailabilityRequest data)
        {
            const string url = "https://api.lot.com/flights-dev/v2";
            var token = _authenticationService.GetToken();

            var client = new RestClient(url);
            var request = new RestRequest("booking/availability");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-Api-Key", "9YFNNKS31u9gCFKPetPWdAAjEXnED0B3K18AeYgg");
            request.AddHeader("Authorization", "Bearer " + token);

        
            request.AddJsonBody(new { data.adt, data.cabinClass, data.departureDate, data.destination, data.market, data.origin, data.tripType });

            //request.AddParameter("params", new { data.adt, data.cabinClass, data.departureDate, data.destination, data.market, data.origin, data.tripType });


            //request.AddParameter ("adt", data.adt);
            //request.AddParameter ("cabinClass", data.cabinClass);
            //request.AddParameter ("departureDate", data.departureDate);
            //request.AddParameter ("destination", data.destination);
            //request.AddParameter ("market", data.market);
            //request.AddParameter ("origin", data.origin);
            //request.AddParameter ("tripType", data.tripType);

            var response = client.Post<Object>(request);

            return response.Content;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value1";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
