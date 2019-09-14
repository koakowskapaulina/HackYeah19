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

namespace HackYeah.Controllers
{
    [Route("dej/lotniska")]
    public class AirportsController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        IAuthenticationService _authenticationService;
        public AirportsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
              
        // GET api/values
        [HttpGet]
        public async Task<AirportsInCountries> GetAsync()
        {

            //            var values = new Dictionary<string, string>
            //{
            //{ "thing1", "hello" },
            //{ "thing2", "world" }
            //};

            //            var content = new FormUrlEncodedContent(values);

            //            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            //            var responseString = await response.Content.ReadAsStringAsync()



            //            var responseString = await client.GetAsync(url, content);
            //            AirportsInCountries model = new AirportsInCountries();
            //            model = JsonConvert.DeserializeObject<AirportsInCountries>(responseString);
            //            return model;


            const string url = "https://api.lot.com/flights-dev/v2/airports/get";

            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            // Add our custom headers
        
         //   requestMessage.Headers.Add("content-type", "application/json");
            requestMessage.Headers.Add("X-Api-Key", "9YFNNKS31u9gCFKPetPWdAAjEXnED0B3K18AeYgg");
            requestMessage.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbiI6IjI4ODI0NzIxZTZmYTY0NzRjMDM3MjY2NmIxMmFiODUxYTdhYzNkYWEiLCJib29rZXJwcm94eUlkIjoiVEZGTlpFWks4OFc0IiwiYm9va2VycHJveHlVdG0iOiJnaXRodWIiLCJpYXQiOjE1Njg0NjQ4MjcsImV4cCI6MTU2ODQ2NjAyN30.35Mh3l5bmCOPcT9eADAhkSmSv-PKUREUrQh2N_jTzXo");


            requestMessage.RequestUri = new Uri(url);
            requestMessage.Content = new StringContent("{secret_key:2przp49a52}", Encoding.UTF8, "application/json");
            //request.Headers["content-type"] = "application/json";
            //request.Headers["X-Api-Key"] = "9YFNNKS31u9gCFKPetPWdAAjEXnED0B3K18AeYgg";
            //request.Headers["Authorization"] = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbiI6IjI4ODI0NzIxZTZmYTY0NzRjMDM3MjY2NmIxMmFiODUxYTdhYzNkYWEiLCJib29rZXJwcm94eUlkIjoiVEZGTlpFWks4OFc0IiwiYm9va2VycHJveHlVdG0iOiJnaXRodWIiLCJpYXQiOjE1Njg0NjQ4MjcsImV4cCI6MTU2ODQ2NjAyN30.35Mh3l5bmCOPcT9eADAhkSmSv-PKUREUrQh2N_jTzXo";

            // Add request body


            // Send the request to the server
            HttpResponseMessage response = await client.SendAsync(requestMessage);

            // Get the response
            var responseString = await response.Content.ReadAsStringAsync();
            AirportsInCountries model = new AirportsInCountries();
            model = JsonConvert.DeserializeObject<AirportsInCountries>(responseString);
            return model;


            //AirportsInCountries model = new AirportsInCountries();
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.Headers["content-type"] = "application/json";
            //request.Headers["X-Api-Key"] = "9YFNNKS31u9gCFKPetPWdAAjEXnED0B3K18AeYgg";
            //request.Headers["Authorization"] = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbiI6IjI4ODI0NzIxZTZmYTY0NzRjMDM3MjY2NmIxMmFiODUxYTdhYzNkYWEiLCJib29rZXJwcm94eUlkIjoiVEZGTlpFWks4OFc0IiwiYm9va2VycHJveHlVdG0iOiJnaXRodWIiLCJpYXQiOjE1Njg0NjQ4MjcsImV4cCI6MTU2ODQ2NjAyN30.35Mh3l5bmCOPcT9eADAhkSmSv-PKUREUrQh2N_jTzXo";

            //string stringData = ""; //place body here
            //var data = Encoding.ASCII.GetBytes(stringData); // or UTF8

            //var newStream = request.GetRequestStream();
            //newStream.Write(data, 0, data.Length);
            //newStream.Close();

            //try
            //{
            //    WebResponse response = request.GetResponse();
            //    using (Stream responseStream = response.GetResponseStream())
            //    {
            //        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            //        model = JsonConvert.DeserializeObject<AirportsInCountries>(reader.ReadToEnd());
            //    }
            //}
            //catch (WebException ex)
            //{
            //    WebResponse errorResponse = ex.Response;
            //    using (Stream responseStream = errorResponse.GetResponseStream())
            //    {
            //        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
            //        String errorText = reader.ReadToEnd();
            //        // log errorText
            //    }
            //    throw;
            //}

            //return model;

            var token = _authenticationService.GetToken();


            return new string[] { "mati", "lotnisko szopena" };
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
