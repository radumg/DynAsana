using RestSharp;
using System;
using System.Collections.Generic;
using Asana.Classes;

namespace Asana
{
    public partial class Client
    {

        #region Workspaces

        /// <summary>
        /// Get a specific Asana workspace.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace to retrieve.</param>
        /// <returns>Returns the complete workspace record for a single workspace.</returns>
        public Workspace GetWorkspaceById(string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspaces/" + workspaceId;
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<Workspace>(this);
        }

        /// <summary>
        /// Get all workspaces available to user.
        /// </summary>
        /// <returns>Returns the compact records for all workspaces visible to the authorized user.</returns>
        public List<Workspace> GetWorkspaces()
        {
            string resource = "workspaces/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Workspace>>(this);
        }

        #endregion

        #region Projects

        /// <summary>
        /// Get a specific Asana project.
        /// </summary>
        /// <param name="projectId">The ID of the project to retrieve.</param>
        /// <returns>Returns the complete task record for a single project.</returns>
        public Project GetProjectById(string projectId)
        {
            if (!Helpers.Classes.CheckId(projectId)) throw new ArgumentException("Invalid project id.");
            string resource = "projects/" + projectId;
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<Project>(this);
        }

        /// <summary>
        /// Get all projects in a specific workspace.
        /// </summary>
        /// <param name="workspaceId">The id of the workspace whose projects to retrieve.</param>
        /// <returns>Returns the compact project records for all projects in the workspace.</returns>
        public List<Project> GetProjectsByWorkspace(string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspace/" + workspaceId + "/projects/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Project>>(this);
        }

        /// <summary>
        /// Get all projects in a specific workspace.
        /// </summary>
        /// <param name="teamId">The id of the team whose projects to retrieve.</param>
        /// <returns>Returns the compact project records for all projects in the team.</returns>
        public List<Project> GetProjectsByTeam(string teamId)
        {
            if (!Helpers.Classes.CheckId(teamId)) throw new ArgumentException("Invalid team id.");
            string resource = "teams/" + teamId + "/projects/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Project>>(this);
        }

        /// <summary>
        /// Get all projects the specified task if part of.
        /// </summary>
        /// <param name="tagId">The Id of the task whose projects to retrieve.</param>
        /// <returns>Returns a compact representation of all of the projects the task is in.</returns>
        public List<Project> GetProjectsByTask(string taskId)
        {
            if (!Helpers.Classes.CheckId(taskId)) throw new ArgumentException("Invalid task id.");
            string resource = "tasks/" + taskId + "/projects/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Project>>(this);
        }

        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <returns>Returns the compact project records for some filtered set of projects. Use one or more request parameters to filter the projects returned.</returns>
        public List<Project> GetProjects()
        {
            string resource = "projects/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Project>>(this);
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Get a specific Asana task.
        /// </summary>
        /// <param name="taskId">The ID of the task to retrieve.</param>
        /// <returns>Returns the complete task record for a single task.</returns>
        public Task GetTaskById(string taskId)
        {
            if (!Helpers.Classes.CheckId(taskId)) throw new ArgumentException("Invalid task id.");
            string resource = "tasks/" + taskId;
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<Task>(this);
        }

        /// <summary>
        /// Get all tasks in a specific workspace.
        /// </summary>
        /// <param name="workspaceId">The id of the workspace whose tasks to retrieve.</param>
        /// <returns>A list of all the tasks in the supplied workspace.</returns>
        public List<Task> GetTasksByWorkspace(string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspace/" + workspaceId + "/tasks/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Task>>(this);
        }

        /// <summary>
        /// Get all tasks in a specific project.
        /// </summary>
        /// <param name="projectId">The id of the project whose tasks to retrieve.</param>
        /// <returns>Returns the compact task records for all tasks within the given project, ordered by their priority within the project.</returns>
        public List<Task> GetTasksByProject(string projectId)
        {
            if (!Helpers.Classes.CheckId(projectId)) throw new ArgumentException("Invalid project id.");
            string resource = "projects/" + projectId + "/tasks/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Task>>(this);
        }

        /// <summary>
        /// Get all tasks with a specific tag.
        /// </summary>
        /// <param name="tagId">The Id of the tag whose tasks to retrieve.</param>
        /// <returns>Returns the compact task records for all tasks with the given tag</returns>
        public List<Task> GetTasksByTag(string tagId)
        {
            if (!Helpers.Classes.CheckId(tagId)) throw new ArgumentException("Invalid tag id.");
            string resource = "tags/" + tagId + "/tasks/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Task>>(this);
        }

        /// <summary>
        /// Get the subtasks of a specific Asana task.
        /// </summary>
        /// <param name="taskId">The ID of the task whose subtasks to retrieve.</param>
        /// <returns>Returns a compact representation of all of the subtasks of a task.</returns>
        public List<Task> GetSubtasksByTask(string taskId)
        {
            if (!Helpers.Classes.CheckId(taskId)) throw new ArgumentException("Invalid task id.");
            string resource = "tasks/" + taskId + "/subtasks/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Task>>(this);
        }

        /// <summary>
        /// Get all sections in a specific project.
        /// </summary>
        /// <param name="projectId">The id of the project whose sections to retrieve.</param>
        /// <returns>Returns compact records for all sections in the specified project.</returns>
        public List<Section> GetSectionsByProject(string projectId)
        {
            if (!Helpers.Classes.CheckId(projectId)) throw new ArgumentException("Invalid project id.");
            string resource = "projects/" + projectId + "/sections/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Section>>(this);
        }

        /// <summary>
        /// Get all tasks.
        /// </summary>
        /// <returns>Returns the compact task records for some filtered set of tasks. Use one or more request parameters to filter the tasks returned.</returns>
        public List<Task> GetTasks()
        {
            string resource = "tasks/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Task>>(this);
        }

        #endregion

        #region Tags

        /// <summary>
        /// Get a specific Asana tag.
        /// </summary>
        /// <param name="tagId">The ID of the tag to retrieve.</param>
        /// <returns>Returns the complete tag record for a single tag.</returns>
        public Tag GetTagById(string tagId)
        {
            if (!Helpers.Classes.CheckId(tagId)) throw new ArgumentException("Invalid tag id.");
            string resource = "tags/" + tagId;
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<Tag>(this);
        }

        /// <summary>
        /// Get all tags in a specific workspace.
        /// </summary>
        /// <param name="workspaceId">The id of the workspace whose tags to retrieve.</param>
        /// <returns>Returns the compact tag records in the workspace.</returns>
        public List<Tag> GetTagsByWorkspace(string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspace/" + workspaceId + "/tags/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Tag>>(this);
        }

        /// <summary>
        /// Get all tags.
        /// </summary>
        /// <returns>Returns the compact tag records for some filtered set of tags. Use one or more request parameters to filter the tags returned.</returns>
        public List<Tag> GetTags()
        {
            string resource = "tags/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Tag>>(this);
        }

        #endregion

        #region Users

        /// <summary>
        /// Get the details for the currently logged in Asana user, usually the owner of the token used.
        /// </summary>
        /// <returns>The Asana current user.</returns>
        public User GetUserBySession()
        {
            var request = new AsanaRequest(this, Method.GET, "users/me");
            return request.Execute<User>(this);
        }

        /// <summary>
        /// Get the details of a specific Asana user.
        /// </summary>
        /// <param name="userId">The id of the user to retrieve.</param>
        /// <returns>The requested Asana user.</returns>
        public User GetUserById(string userId)
        {
            if (!Helpers.Classes.CheckId(userId)) throw new ArgumentException("Supplied task id is invalid.");
            string resource = "users/" + userId;
            var request = new AsanaRequest(this, Method.GET, resource);
            return request.Execute<User>(this);
        }

        /// <summary>
        /// Get all users in a specific workspace.
        /// </summary>
        /// <param name="workspaceId">The id of the workspace whose users to retrieve.</param>
        /// <returns>Returns the user records for all users in the specified workspace or organization.</returns>
        public List<User> GetUsersByWorkspace(string workspaceId)
        {
            if (!Helpers.Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspace/" + workspaceId + "/users/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<User>>(this);
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="workspaceId">(optional) The id of the workspace whose users to retrieve.</param>
        /// <returns>Returns the user records for all users in all workspaces and organizations accessible to the authenticated user. Accepts an optional workspace ID parameter.</returns>
        public List<User> GetUsers(string workspaceId = null)
        {
            string resource = "";
            if (Helpers.Classes.CheckId(workspaceId))
            {
                resource = "workspace/" + workspaceId + "/users/";
            }
            else resource = "users/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<User>>(this);
        }

        #endregion
    }
}
