using System;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asana
{
    class Program2
    {
        const string BaseUrl = "https://app.asana.com/api/1.0/";
        const string token = "Bearer 0/7e47c745e9546e47b4f677926649db7d";

        static void Main2(string[] args)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient();
            //client.BaseUrl = new Uri("https://app.asana.com/api/1.0/");
            client.BaseUrl = new System.Uri(BaseUrl);

            var request = new RestRequest();
            request.Resource = "workspaces/198488041683503";
            request.AddParameter("Authorization", token, ParameterType.HttpHeader); // authorisation required on every request, added as header parameter

            var response = client.Execute(request);
            if (response.ErrorException != null)
                throw new ApplicationException("Error retrieving response.  Check inner details for more info.", response.ErrorException);
            Console.WriteLine("Asana Response ====================");
            Console.WriteLine(response.Content);

            var task = new AsanaTask();
            task = GetTask("325519749237450");
            Console.WriteLine("Deserialised task ================");
            Console.WriteLine("id : " + task.id);
            Console.WriteLine("name : " + task.name);
            Console.WriteLine("completed : " + task.completed.ToString());

            Console.ReadKey();
        }

        public static T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new System.Uri(BaseUrl);
            request.AddParameter("Authorization", token, ParameterType.HttpHeader); // used on every request

            var response = client.Execute<T>(request);
            if (response.ErrorException != null)
                throw new ApplicationException("Error retrieving response.  Check inner details for more info.", response.ErrorException);
            Console.WriteLine(response.Content);
            return response.Data;
        }


        public class AsanaTask
        {
            /* Asana API response
              "id": 281886789136277,
              "assignee": null,
              "completed": false,
              "due_on": null,
              "name": "Token",
              "parent": null
            */
            public string id { get; set; }
            public string assignee { get; set; }
            public bool completed { get; set; }
            public string due_on { get; set; }
            public string name { get; set; }
            public string parent { get; set; }

        }
        public static AsanaTask GetTask(string taskId) //request.Resource = "tasks/325519749237450";
        {

            var request = new RestRequest();
            string opts = "?opt_fields=id,completed,due_on,name";
            request.Resource = "tasks/" + taskId + opts;

            // REQUEST
            //var a =  Execute<AsanaTask>(request);
            var client = new RestClient();
            client.BaseUrl = new System.Uri(BaseUrl);
            request.AddParameter("Authorization", token, ParameterType.HttpHeader); // used on every request
            var response = client.Execute(request);

            // only use data inside JSON nested "data" object
            // see this for deserialisation help : http://www.newtonsoft.com/json/help/html/SelectToken.htm
            JObject o = JObject.Parse(response.Content);
            JToken taskData = o.SelectToken("$.data");
            Console.WriteLine("Serialised task ================");
            Console.WriteLine(taskData);

            var task = JsonConvert.DeserializeObject<AsanaTask>(taskData.ToString());
            return task;
        }

    }

}
