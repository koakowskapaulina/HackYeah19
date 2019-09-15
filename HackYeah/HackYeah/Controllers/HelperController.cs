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
    [Route("token/new")]
    public class HelperController : Controller
    {        
                
        IAuthenticationService _authenticationService;
        ICountryService _countryService;

        public HelperController(IAuthenticationService authenticationService, ICountryService countryService)
        {
            _authenticationService = authenticationService;
            _countryService = countryService;
        }
              
        // GET api/values
        [HttpGet]
        public string GetAsync()
        {
            var token = "Bearer " + _authenticationService.GetToken();

            return JsonConvert.SerializeObject(token);
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
