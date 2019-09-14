using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace HackYeah.Services
{
    public interface IAuthenticationService
    {
        string GetToken();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private string _token = string.Empty;

        public string GetToken()
        {
            if (_token.Equals(string.Empty))
            {
                SzczelDoLatajacegoApi();
            }
            return _token;
        }

        [HttpPost]
        private void SzczelDoLatajacegoApi()
        {
            var client = new RestClient("https://api.lot.com/flights-dev/v2");
            var request = new RestRequest("auth/token/get");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-Api-Key", "9YFNNKS31u9gCFKPetPWdAAjEXnED0B3K18AeYgg");
            request.AddJsonBody(new {secret_key = "2przp49a52"});                        
            var response = client.Post<AuthenticationResponseModel>(request);
            _token = response.Data.access_token;
        }
    }

    public class AuthenticationResponseModel
    {
        public string access_token { get; set; }
    }
       
}

