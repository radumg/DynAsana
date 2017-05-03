using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            if (task.Workspace == null) throw new ArgumentException("Must specify a workspace when creating a task.");
            if (CheckId(task.Workspace.Id) == false) throw new ArgumentException("Invalid workspace id.");

            var request = new AsanaRequest(this, Method.POST, "workspaces/" + task.Workspace.Id + "/tasks/");

            request.restRequest.AddParameter("application/x-www-form-urlencoded", "projects=200419949000730&notes=This%20is%20the%20textual%20description%20of%20the%20task%2C%20created%20in%20Postman.&assignee=198487209472854&tags=204494482735923", ParameterType.RequestBody);

            request.restRequest.AddParameter("name", task.Name, ParameterType.GetOrPost);
            request.restRequest.AddParameter("projects", task.Projects.First().Id, ParameterType.GetOrPost);
            request.restRequest.AddParameter("notes", task.Notes, ParameterType.GetOrPost);
            request.restRequest.AddParameter("assignee", task.Assignee.Id, ParameterType.GetOrPost);
            request.restRequest.AddParameter("tags", task.Tags.First().Id, ParameterType.GetOrPost);

            Console.WriteLine(JObject.FromObject(request.restRequest).ToString());

            return request.Execute<Asana.Task>(this);
        }

        /// <summary>
        /// Gets only non-null properties from a Type. Also respects the [SkipProperty] attribute.
        /// </summary>
        /// <param name="obj">The object to extract type properties from.</param>
        /// <returns>A dictionary of properties and their values.</returns>
        internal static Dictionary<string, string> GetValidProperties(object obj)
        {
            var parameters = new Dictionary<string, string>();
            Type type = obj.GetType();
            foreach (PropertyInfo prop in type.GetFilteredProperties())
            {
                object value = prop.GetValue(obj);
                if (value != null) parameters.Add(prop.Name, value.ToString());
            }
            return parameters;
        }

        /// <summary>
        /// Gets JSON encoded non-null properties from a Type. Also respects the [SkipProperty] attribute.
        /// </summary>
        /// <param name="obj">The object to extract type properties from.</param>
        /// <returns>A dictionary of properties and their values.</returns>
        internal static Dictionary<string, string> GetValidPropertiesJSON(object obj)
        {
            var parameters = new Dictionary<string, string>();
            Type type = obj.GetType();
            foreach (PropertyInfo prop in type.GetFilteredProperties())
            {
                object value = prop.GetValue(obj);
                if (value != null) parameters.Add(prop.Name, JsonConvert.SerializeObject(value.ToString()));
            }
            return parameters;
        }

    }
}
