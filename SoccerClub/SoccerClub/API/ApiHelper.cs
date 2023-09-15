using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using RestSharp;
using SoccerClub.Models;
using Method = RestSharp.Method;

namespace SoccerClub.API
{
    public class ApiHelper:IApiHelper
    {
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
    }
}
