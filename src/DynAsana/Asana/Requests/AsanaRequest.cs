using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Asana
{
    /// <summary>
    /// Represents any request to the Asana API. Inherits from the RestSharp RestRequest class.
    /// </summary>
    public class AsanaRequest : RestRequest
    {
        internal TimeSpan runtime { get; private set; }

        public AsanaRequest(Asana.Client client, Method method, string resource = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.AddParameter("Authorization", client.Token, ParameterType.HttpHeader);
            this.AddParameter("Asana-Fast-Api", "true", ParameterType.HttpHeader);
            this.Resource = resource;
            this.Method = method;
        }

        public IRestResponse Execute(Asana.Client client)
        {
            var startTime = DateTime.Now;
            var response = client.restClient.Execute(this);
            this.runtime = DateTime.Now - startTime;

            Console.WriteLine("Request took " + runtime.TotalMilliseconds.ToString() +"ms");
            return response;
        }

        public object Deserialize<T>(IRestResponse response)
        {
            JObject o = JObject.Parse(response.Content);
            JToken taskData = o.SelectToken("$.data");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            return JsonConvert.DeserializeObject<T>(taskData.ToString(), settings);
        }

    }


}
