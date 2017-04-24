using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;

namespace Asana
{
    /// <summary>
    /// Asana clients represent a single connection to an Asana organisation, with all associated properties and methods.
    /// </summary>
    public class Client
    {
        public readonly string BaseUrl = "https://app.asana.com/api/1.0/";
        public readonly string Token = "Bearer 0/7e47c745e9546e47b4f677926649db7d";

        /// <summary>
        /// Asana client constructor
        /// </summary>
        /// <param name="token">OAuth token, must be valid.</param>
        public Client(string token = null)
        {

            if (CheckToken(token)==false) this.Token = "Bearer 0/7e47c745e9546e47b4f677926649db7d";
            if (TestConnection().StatusCode != System.Net.HttpStatusCode.OK) throw new InvalidOperationException("Could not establish connection to Asana.");
        }

        public Task GetTask(string taskId)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient();
            client.BaseUrl = new System.Uri(this.BaseUrl);

            var request = new RestRequest();
            request.AddParameter("Authorization", this.Token, ParameterType.HttpHeader);
            //string opts = "?opt_fields=id,completed,due_on,name";
            request.Resource = "tasks/" + taskId;

            var response = client.Execute(request);
            JObject o = JObject.Parse(response.Content);
            JToken taskData = o.SelectToken("$.data");

            // deserialise
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.DeserializeObject<Asana.Task>(taskData.ToString(),settings);
        }

        /// <summary>
        /// Test the connection to Asana by querying the API for the current user's data.
        /// </summary>
        /// <returns></returns>
        public IRestResponse TestConnection()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient();
            client.BaseUrl = new System.Uri(BaseUrl);

            var request = new RestRequest();
            request.Resource = "users/me";
            request.AddParameter("Authorization", this.Token, ParameterType.HttpHeader);

            var response = client.Execute(request);
            Console.WriteLine("Testing new client returned : " + response.StatusCode.ToString());
            return response;
        }

        /// <summary>
        /// Checks whether an OAuth token is valid
        /// </summary>
        /// <param name="token">The token to check</param>
        /// <returns>True if token is valid and false otherwise</returns>
        Boolean CheckToken(string token)
        {
            if (String.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token)) return false;

            return true;
        }
    }
}
