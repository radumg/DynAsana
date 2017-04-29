using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Asana
{
    /// <summary>
    /// Asana clients represent a single connection to an Asana organisation, with all associated properties and methods.
    /// </summary>
    public partial class Client
    {
        #region Properties
        public readonly string BaseUrl = "https://app.asana.com/api/1.0/";
        public string Token { get; internal set; }

        public Workspace Workspace;
        public List<Project> Projects;
        public User CurrentUser;

        internal RestClient restClient;

        /// <summary>
        /// Asana client constructor
        /// </summary>
        /// <param name="token">OAuth token, must be valid.</param>
        public Client(string token = null)
        {

            if (CheckToken(token) == false)
                throw new ArgumentNullException("Token cannot be empty or null");

            this.Token = token;
            this.restClient = new RestClient();
            this.restClient.BaseUrl = new System.Uri(this.BaseUrl);
            this.restClient.UserAgent = "DynAsana (github.com/radumg/DynAsana)";

            if (TestConnection().StatusCode != HttpStatusCode.OK) throw new InvalidOperationException("Could not establish connection to Asana.");
        }
        #endregion

        #region Common Request Methods

        /// <summary>
        /// Executes an Asana Request
        /// </summary>
        /// <typeparam name="T">The Asana object type to deserialize as.</typeparam>
        /// <param name="request">The Asana Request to execute.</param>
        /// <returns>Response from Asana API deserialized as the supplied type.</returns>
        public T Execute<T>(AsanaRequest request) where T : new()
        {
            var response = request.Execute(this);
            if (response.ErrorException != null)
                throw new ApplicationException("Error retrieving response", response.ErrorException);

            return Deserialize<T>(response, "$.data");
        }

        /// <summary>
        /// Deserializes a response from the Asana API to the supplied object type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="response">The response from Asana API to deserialize.</param>
        /// <param name="JsonToken">Optional : specify a JSON token as the root element to deserialise from.
        /// Default for Asana is : "$.data"</param>
        /// <returns>The supplied response from Asana API, deserialized as the supplied type.</returns>
        public T Deserialize<T>(IRestResponse response, string JsonToken = null) where T : new()
        {
            string data = "";
            if (!String.IsNullOrEmpty(JsonToken))
            {
                JObject o = JObject.Parse(response.Content);
                data = o.SelectToken(JsonToken).ToString();
            }
            else data = response.Content;

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = JsonConvert.DeserializeObject<AsanaResponse>(response.Content);
                Console.WriteLine(JObject.FromObject(error).ToString());
            }

            return JsonConvert.DeserializeObject<T>(data, settings);
        }
        #endregion

        #region Utils
        /// <summary>
        /// Test the connection to Asana by querying the API for the current user's data.
        /// </summary>
        /// <returns></returns>
        public IRestResponse TestConnection()
        {
            var request = new AsanaRequest(this, Method.GET, "users/me");

            var response = request.Execute(this);
            Console.WriteLine("Testing new client returned status code : " + response.StatusCode.ToString());
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

        /// <summary>
        /// Check if the supplied Id is valid. Note: does not guarantee Id is valid, only checks general format.
        /// </summary>
        /// <param name="Id">The id to check</param>
        /// <returns>True if Id seems valid, false otherwise.</returns>
        Boolean CheckId(string Id)
        {
            if (String.IsNullOrEmpty(Id) || string.IsNullOrWhiteSpace(Id)) return false;
            if (!long.TryParse(Id, out var id)) return false;
            return true;
        }
        #endregion
    }
}
