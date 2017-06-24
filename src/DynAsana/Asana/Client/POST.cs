using Asana.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using Asana.Classes;
using System.Linq;

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
            /// web requests can take a long time, so we validate data before POST and bail early if required
            if (task == null) throw new ArgumentException("Must supply a valid task.");
            if (task.Workspace == null) throw new ArgumentException("Must specify a workspace when creating a task.");
            if (Helpers.Classes.CheckId(task.Workspace.Id) == false) throw new ArgumentException("Invalid workspace id.");
            if (task.Projects == null) throw new ArgumentException("Must specify a project when creating a task.");
            task.Projects.ForEach(p =>
                { if (Helpers.Classes.CheckId(p.Id) == false) throw new ArgumentException("Invalid project id."); }
            );


            var request = new AsanaRequest(this, Method.POST, "tasks/");

            /// transformations are required from lists to comma-separated strings for projects & tags
            var projects = string.Join(",", task.Projects.Select(p => p.Id).ToArray());
            var tags = string.Join(",", task.Tags.Select(t => t.Id).ToArray());

            try
            {
                request.restRequest.AddParameter("workspaces", task.Workspace.Id, ParameterType.GetOrPost);
                request.restRequest.AddParameter("name", task.Name, ParameterType.GetOrPost);
                request.restRequest.AddParameter("projects", projects, ParameterType.GetOrPost);
                request.restRequest.AddParameter("tags", tags, ParameterType.GetOrPost);
                request.restRequest.AddParameter("notes", task.Notes, ParameterType.GetOrPost);
                request.restRequest.AddParameter("assignee", task.Assignee.Id, ParameterType.GetOrPost);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("One or more of the supplied parameters was missing.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return request.Execute<Task>(this);
        }

        /// <summary>
        /// Create a new Asana project in a specified workspace.
        /// </summary>
        /// <param name="name">The name of the new project.</param>
        /// <param name="workspaceID">The workspace to create the project in.</param>
        /// <param name="description">(optional) The description of the project.</param>
        /// <returns>The newly-created Asana Project object.</returns>
        public Project CreateProject(string name, string workspaceID, string description = null)
        {
            /// web requests can take a long time, so we validate data before POST and bail early if required
            if (String.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Must supply a name.");
            if (Helpers.Classes.CheckId(workspaceID) == false) throw new ArgumentException("Must supply a valid workspace ID.");


            var request = new AsanaRequest(this, Method.POST, "projects/");

            try
            {
                request.restRequest.AddParameter("workspace", workspaceID, ParameterType.GetOrPost);
                request.restRequest.AddParameter("name", name, ParameterType.GetOrPost);
                request.restRequest.AddParameter("notes", description, ParameterType.GetOrPost);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("One or more of the supplied parameters was missing.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return request.Execute<Project>(this);
        }

        /// <summary>
        /// Create a new Asana Tag in a specified workspace.
        /// </summary>
        /// <param name="name">The name of the new project.</param>
        /// <param name="workspaceID">The workspace to create the project in.</param>
        /// <param name="colour">(optional) A colour to use for the tag, must be one of the standard Asana colours, in a string format.</param>
        /// <returns>The newly-created Asana Tag object.</returns>
        public Tag CreateTag(string name, string workspaceID, string colour = null)
        {
            /// web requests can take a long time, so we validate data before POST and bail early if required
            if (String.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Must supply a name.");
            if (Helpers.Classes.CheckId(workspaceID) == false) throw new ArgumentException("Must supply a valid workspace ID.");


            var request = new AsanaRequest(this, Method.POST, "tags/");

            try
            {
                request.restRequest.AddParameter("workspace", workspaceID, ParameterType.GetOrPost);
                request.restRequest.AddParameter("name", name, ParameterType.GetOrPost);
                request.restRequest.AddParameter("color", colour, ParameterType.GetOrPost);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("One or more of the supplied parameters was missing.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return request.Execute<Tag>(this);
        }

        #region Helpers

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
        #endregion
    }
}
