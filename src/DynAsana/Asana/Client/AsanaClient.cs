using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using Asana.Classes;

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
        public string JsonTokenOverride { get; set; }

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
            this.JsonTokenOverride = "$.data";
            this.restClient = new RestClient();
            this.restClient.BaseUrl = new System.Uri(this.BaseUrl);
            this.restClient.UserAgent = "DynAsana (github.com/radumg/DynAsana)";
            this.restClient.Timeout = 15000;

            if (TestConnection().StatusCode != HttpStatusCode.OK) throw new InvalidOperationException("Could not establish connection to Asana.");
        }
        #endregion

        #region Utils
        /// <summary>
        /// Test the connection to Asana by querying the API for the current user's data.
        /// </summary>
        /// <returns></returns>
        private IRestResponse TestConnection()
        {
            var request = new AsanaRequest(this, Method.GET, "users/me");

            var response = this.restClient.Execute(request.restRequest);
            Console.WriteLine("Testing new client returned status code : " + response.StatusCode.ToString());
            Console.WriteLine();
            return response;
        }

        /// <summary>
        /// Checks whether an OAuth token is valid
        /// </summary>
        /// <param name="token">The token to check</param>
        /// <returns>True if token is valid and false otherwise</returns>
        internal static Boolean CheckToken(string token)
        {
            if (String.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token)) return false;
            return true;
        }

        #endregion
    }
}
