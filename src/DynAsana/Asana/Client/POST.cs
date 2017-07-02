using Asana.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Asana.Client;


namespace Asana
{
    /// Notice that each web call is encapsulated in the right class.
    /// Although these methods could live in the class definition, 
    /// I've chosen to separate them here

    public partial class Task
    {
        /// <summary>
        /// Create an Asana task by uploading an Asana Task object.
        /// </summary>
        /// <param name="task">The task to upload.</param>
        /// <returns>The createad task.</returns>
        public static Task UploadTask(AsanaClient client, Task task)
        {
            /// web requests can take a long time, so we validate data before POST and bail early if required
            if (task == null) throw new ArgumentException("Must supply a valid task.");
            if (task.Workspace == null) throw new ArgumentException("Must specify a workspace when creating a task.");
            if (Helpers.Classes.CheckId(task.Workspace.Id) == false) throw new ArgumentException("Invalid workspace id.");
            if (task.Projects == null) throw new ArgumentException("Must specify a project when creating a task.");
            task.Projects.ForEach(p =>
                { if (Helpers.Classes.CheckId(p.Id) == false) throw new ArgumentException("Invalid project id."); }
            );


            var request = new AsanaRequest(client, Method.POST, "tasks/");

            try
            {
                request.restRequest.AddParameter("workspaces", task.Workspace.Id, ParameterType.GetOrPost);
                request.restRequest.AddParameter("name", task.Name, ParameterType.GetOrPost);
                if (task.Projects.Any())
                {
                    var projects = string.Join(",", task.Projects.Select(p => p.Id).ToArray());
                    request.restRequest.AddParameter("projects", projects, ParameterType.GetOrPost);
                }
                if (task.Tags.Any())
                {
                    var tags = string.Join(",", task.Tags.Select(t => t.Id).ToArray());
                    request.restRequest.AddParameter("tags", tags, ParameterType.GetOrPost);
                }
                request.restRequest.AddParameter("notes", task.Notes, ParameterType.GetOrPost);
                if (task.Assignee != null)
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

            return request.Execute<Task>(client);
        }

    }

    public partial class Project
    {
        /// <summary>
        /// Create a new Asana project in a specified workspace.
        /// </summary>
        /// <param name="name">The name of the new project.</param>
        /// <param name="workspaceID">The workspace to create the project in.</param>
        /// <param name="description">(optional) The description of the project.</param>
        /// <returns>The newly-created Asana Project object.</returns>
        public static Project CreateProject(AsanaClient client, string name, string workspaceID, string description = null)
        {
            /// web requests can take a long time, so we validate data before POST and bail early if required
            if (String.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Must supply a name.");
            if (Helpers.Classes.CheckId(workspaceID) == false) throw new ArgumentException("Must supply a valid workspace ID.");


            var request = new AsanaRequest(client, Method.POST, "projects/");

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

            return request.Execute<Project>(client);
        }
    }

    public partial class Tag
    {
        /// <summary>
        /// Create a new Asana Tag in a specified workspace.
        /// </summary>
        /// <param name="name">The name of the new project.</param>
        /// <param name="workspaceID">The workspace to create the project in.</param>
        /// <param name="colour">(optional) A colour to use for the tag, must be one of the standard Asana colours, in a string format.</param>
        /// <returns>The newly-created Asana Tag object.</returns>
        public static Tag CreateTag(AsanaClient client, string name, string workspaceID, string colour = null)
        {
            /// web requests can take a long time, so we validate data before POST and bail early if required
            if (String.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Must supply a name.");
            if (Helpers.Classes.CheckId(workspaceID) == false) throw new ArgumentException("Must supply a valid workspace ID.");


            var request = new AsanaRequest(client, Method.POST, "tags/");

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

            return request.Execute<Tag>(client);
        }
    }
}

