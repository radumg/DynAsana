using RestSharp;
using System;
using System.Collections.Generic;
using Asana.Client;

namespace Asana
{
    #region Workspaces
    public partial class Workspace
    {
        /// <summary>
        /// Get all workspaces available to user.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <returns>Returns the compact records for all workspaces visible to the authorized user.</returns>
        public static List<Workspace> GetAllWorkspaces(AsanaClient client)
        {
            string resource = "workspaces/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Workspace>>(client);
        }

        /// <summary>
        /// Get a specific Asana workspace.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="workspaceId">The ID of the workspace to retrieve.</param>
        /// <returns>Returns the complete workspace record for a single workspace.</returns>
        public static List<Workspace> GetById(AsanaClient client, string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspaces/" + workspaceId;
            var request = new AsanaRequest(client, Method.GET, resource);

            return new List<Workspace> { request.Execute<Workspace>(client) };
        }
    }
    #endregion

    #region Projects
    public partial class Project
    {
        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <returns>Returns the compact project records for some filtered set of projects. Use one or more request parameters to filter the projects returned.</returns>
        public static List<Project> GetAllProjects(AsanaClient client)
        {
            string resource = "projects/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Project>>(client);
        }

        /// <summary>
        /// Get a specific Asana project.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="projectId">The ID of the project to retrieve.</param>
        /// <returns>Returns the complete task record for a single project.</returns>
        public static List<Project> GetById(AsanaClient client, string projectId)
        {
            if (!Helpers.Classes.CheckId(projectId)) throw new ArgumentException("Invalid project id.");
            string resource = "projects/" + projectId;
            var request = new AsanaRequest(client, Method.GET, resource);

            return new List<Project> { request.Execute<Project>(client) };
        }

        /// <summary>
        /// Get all projects in a specific workspace.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="workspaceId">The id of the workspace whose projects to retrieve.</param>
        /// <returns>Returns the compact project records for all projects in the workspace.</returns>
        public static List<Project> GetByWorkspace(AsanaClient client, string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspaces/" + workspaceId + "/projects/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Project>>(client);
        }

        /// <summary>
        /// Get all projects in a specific workspace.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="teamId">The id of the team whose projects to retrieve.</param>
        /// <returns>Returns the compact project records for all projects in the team.</returns>
        public static List<Project> GetByTeam(AsanaClient client, string teamId)
        {
            if (!Helpers.Classes.CheckId(teamId)) throw new ArgumentException("Invalid team id.");
            string resource = "teams/" + teamId + "/projects/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Project>>(client);
        }

        /// <summary>
        /// Get all projects the specified task if part of.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="taskId">The Id of the task whose projects to retrieve.</param>
        /// <returns>Returns a compact representation of all of the projects the task is in.</returns>
        public static List<Project> GetByTask(AsanaClient client, string taskId)
        {
            if (!Helpers.Classes.CheckId(taskId)) throw new ArgumentException("Invalid task id.");
            string resource = "tasks/" + taskId + "/projects/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Project>>(client);
        }
    }
    #endregion

    #region Tasks
    public partial class Task
    {
        /// <summary>
        /// Get all tasks.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <returns>Returns the compact task records for some filtered set of tasks. Use one or more request parameters to filter the tasks returned.</returns>
        public static List<Task> GetAllTasks(AsanaClient client)
        {
            string resource = "tasks/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Task>>(client);
        }

        /// <summary>
        /// Get a specific Asana task.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="taskId">The ID of the task to retrieve.</param>
        /// <returns>Returns the complete task record for a single task.</returns>
        public static List<Task> GetById(AsanaClient client, string taskId)
        {
            if (!Helpers.Classes.CheckId(taskId)) throw new ArgumentException("Invalid task id.");
            string resource = "tasks/" + taskId;
            var request = new AsanaRequest(client, Method.GET, resource);

            return new List<Task> { request.Execute<Task>(client) };
        }

        /// <summary>
        /// Get all tasks in a specific workspace.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="workspaceId">The id of the workspace whose tasks to retrieve.</param>
        /// <returns>A list of all the tasks in the supplied workspace.</returns>
        public static List<Task> GetByWorkspace(AsanaClient client, string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspaces/" + workspaceId + "/tasks/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Task>>(client);
        }

        /// <summary>
        /// Get all tasks in a specific project.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="projectId">The id of the project whose tasks to retrieve.</param>
        /// <returns>Returns the compact task records for all tasks within the given project, ordered by their priority within the project.</returns>
        public static List<Task> GetByProject(AsanaClient client, string projectId)
        {
            if (!Helpers.Classes.CheckId(projectId)) throw new ArgumentException("Invalid project id.");
            string resource = "projects/" + projectId + "/tasks/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Task>>(client);
        }

        /// <summary>
        /// Get all tasks with a specific tag.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="tagId">The Id of the tag whose tasks to retrieve.</param>
        /// <returns>Returns the compact task records for all tasks with the given tag</returns>
        public static List<Task> GetByTag(AsanaClient client, string tagId)
        {
            if (!Helpers.Classes.CheckId(tagId)) throw new ArgumentException("Invalid tag id.");
            string resource = "tags/" + tagId + "/tasks/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Task>>(client);
        }

        /// <summary>
        /// Get the subtasks of a specific Asana task.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="taskId">The ID of the task whose subtasks to retrieve.</param>
        /// <returns>Returns a compact representation of all of the subtasks of a task.</returns>
        public static List<Task> GetSubtasksByTask(AsanaClient client, string taskId)
        {
            if (!Helpers.Classes.CheckId(taskId)) throw new ArgumentException("Invalid task id.");
            string resource = "tasks/" + taskId + "/subtasks/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Task>>(client);
        }
    }

    public partial class Section
    {
        /// <summary>
        /// Get all sections in a specific project.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="projectId">The id of the project whose sections to retrieve.</param>
        /// <returns>Returns compact records for all sections in the specified project.</returns>
        public List<Section> GetSectionsByProject(AsanaClient client, string projectId)
        {
            if (!Helpers.Classes.CheckId(projectId)) throw new ArgumentException("Invalid project id.");
            string resource = "projects/" + projectId + "/sections/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Section>>(client);
        }

    }
    #endregion

    #region Tags
    public partial class Tag
    {
        /// <summary>
        /// Get all tags.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <returns>Returns the compact tag records for some filtered set of tags. Use one or more request parameters to filter the tags returned.</returns>
        public static List<Tag> GetAllTags(AsanaClient client)
        {
            string resource = "tags/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Tag>>(client);
        }

        /// <summary>
        /// Get a specific Asana tag.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="tagId">The ID of the tag to retrieve.</param>
        /// <returns>Returns the complete tag record for a single tag.</returns>
        public static List<Tag> GetById(AsanaClient client, string tagId)
        {
            if (!Helpers.Classes.CheckId(tagId)) throw new ArgumentException("Invalid tag id.");
            string resource = "tags/" + tagId;
            var request = new AsanaRequest(client, Method.GET, resource);

            return new List<Tag> { request.Execute<Tag>(client) };
        }

        /// <summary>
        /// Get all tags in a specific workspace.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="workspaceId">The id of the workspace whose tags to retrieve.</param>
        /// <returns>Returns the compact tag records in the workspace.</returns>
        public static List<Tag> GetByWorkspace(AsanaClient client, string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspaces/" + workspaceId + "/tags/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<Tag>>(client);
        }
    }
    #endregion

    #region Users
    public partial class User
    {
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="workspaceId">(optional) The id of the workspace whose users to retrieve.</param>
        /// <returns>Returns the user records for all users in all workspaces and organizations accessible to the authenticated user. Accepts an optional workspace ID parameter.</returns>
        public static List<User> GetAllUsers(AsanaClient client, string workspaceId = null)
        {
            string resource = "";
            if (Helpers.Classes.CheckId(workspaceId))
            {
                resource = "workspaces/" + workspaceId + "/users/";
            }
            else resource = "users/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<User>>(client);
        }

        /// <summary>
        /// Get the details for the currently logged in Asana user, usually the owner of the token used.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <returns>The Asana current user.</returns>
        public static List<User> GetBySession(AsanaClient client)
        {
            var request = new AsanaRequest(client, Method.GET, "users/me");
            return new List<User> { request.Execute<User>(client) };
        }

        /// <summary>
        /// Get the details of a specific Asana user.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="userId">The id of the user to retrieve.</param>
        /// <returns>The requested Asana user.</returns>
        public static List<User> GetById(AsanaClient client, string userId)
        {
            if (!Helpers.Classes.CheckId(userId)) throw new ArgumentException("Supplied task id is invalid.");
            string resource = "users/" + userId;
            var request = new AsanaRequest(client, Method.GET, resource);
            return new List<User> { request.Execute<User>(client) };
        }

        /// <summary>
        /// Get all users in a specific workspace.
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="workspaceId">The id of the workspace whose users to retrieve.</param>
        /// <returns>Returns the user records for all users in the specified workspace or organization.</returns>
        public static List<User> GetByWorkspace(AsanaClient client, string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspaces/" + workspaceId + "/users/";
            var request = new AsanaRequest(client, Method.GET, resource);

            return request.Execute<List<User>>(client);
        }
    }
    #endregion
}
