using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using RestSharp;
using SoccerClub.Models;
using System.Configuration;
using Method = RestSharp.Method;

namespace SoccerClub.API
{
    public class ApiHelper:IApiHelper
    {
		private readonly IConfiguration _configuration;
		public ApiHelper(IConfiguration _configuration) 
        {
            this._configuration = _configuration;
        }
        public string GetRecentUpdates()
        {
            var options = new RestClientOptions("https://gnews.io")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/v4/search?q=soccer&lang=en&country=us&max=10&apikey=191c750e413590e294b4e11183ff6652", Method.Get);
            request.AddHeader("Authorization", "Bearer {{ACCESS_TOKEN}}");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "PHPSESSID=7e52qjehfl0hr7f6r843722nta");
            RestResponse response =  client.Execute(request);
            string jsonContent = response.Content;
            jsonContent = jsonContent.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
            
            return jsonContent;
        }
         
		public string TopTenScores(string competition)
        {
            var apiKey = _configuration["ApiSettings:TopTenApiKey"];
			var options = new RestClientOptions("http://api.football-data.org")
			{
				MaxTimeout = -1,
			};
			var client = new RestClient(options);
			var request = new RestRequest($"/v4/competitions/{competition}/scorers", Method.Get);
            request.AddHeader("X-Auth-Token", apiKey);
			RestResponse response = client.Execute(request);
			string jsonContent = response.Content;
			return jsonContent;
		}
	}
}

