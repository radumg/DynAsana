using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asana.Helpers;

namespace Asana
{
    public partial class Client
    {
        /// <summary>
        /// Get a specific Asana task.
        /// </summary>
        /// <param name="taskId">The ID of the task to retrieve.</param>
        /// <returns>The requested Asana task.</returns>
        public Task GetTask(string taskId)
        {
            if (!Classes.CheckId(taskId)) throw new ArgumentException("Invalid task id.");
            var request = new AsanaRequest(this, Method.GET, "tasks/" + taskId);

            return request.Execute<Asana.Task>(this);
        }

        /// <summary>
        /// Gets all tasks in a specific workspace.
        /// </summary>
        /// <param name="workspaceId">The workspace whose tasks to retrieve.</param>
        /// <returns>A list of all the tasks in the supplied workspace.</returns>
        public List<Task> GetWorkspaceTasks(string workspaceId)
        {
            if (!Classes.CheckId(workspaceId)) throw new ArgumentException("Invalid workspace id.");
            string resource = "workspace/" + workspaceId + "/tasks/";
            var request = new AsanaRequest(this, Method.GET, resource);

            return request.Execute<List<Task>>(this);
        }

        /// <summary>
        /// Get the details for the current Asana user, usually the owner of the token used.
        /// </summary>
        /// <returns>The Asana current user.</returns>
        public User GetCurrentUser()
        {
            var request = new AsanaRequest(this, Method.GET, "users/me");
            return request.Execute<Asana.User>(this);
        }

        /// <summary>
        /// Get the details of a specific Asana user.
        /// </summary>
        /// <param name="userId">The identifying user id.</param>
        /// <returns>The requested Asana user.</returns>
        public User GetUser(string userId)
        {
            if (!Classes.CheckId(userId)) throw new ArgumentException("Supplied task id is invalid.");
            var request = new AsanaRequest(this, Method.GET, "users/" + userId);
            return request.Execute<Asana.User>(this);
        }

    }
}
