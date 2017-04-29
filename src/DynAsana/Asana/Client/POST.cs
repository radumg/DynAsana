using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana
{
    public partial class Client
    {
        /// <summary>
        /// Create an Asana task by uploading an Asana Task object.
        /// </summary>
        /// <param name="task">The task to upload.</param>
        /// <returns>The createad task.</returns>
        public Task CreateTask(Task task)
        {
            if (task == null) throw new ArgumentException("Invalid task.");
            var request = new AsanaRequest(this, Method.POST, "tasks/");

            var projects = new List<string>();
            task.Projects.ForEach(p => projects.Add(p.Id));
            var tags = new List<string>();
            task.Tags.ForEach(t => tags.Add(t.id));

            var parameters = new Dictionary<string, string>();
            parameters.Add("workspace", task.Workspace.Id);
            parameters.Add("projects", String.Join(",", projects.ToArray()));
            parameters.Add("assignee", task.Assignee.Id);
            parameters.Add("tags", String.Join(",", tags.ToArray()));
            parameters.Add("name", task.Name);
            parameters.Add("notes", task.Notes);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            foreach (var p in parameters)
            {
                request.AddParameter(p.Key, p.Value, "application/x-www-form-urlencoded", ParameterType.GetOrPost);
            }

            var response = request.Execute(this);
            Console.WriteLine("Raw response :" + JObject.FromObject(response).ToString());

            return Deserialize<Task>(response, "$.data");
        }
    }
}
