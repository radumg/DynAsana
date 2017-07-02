using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asana.Client;


namespace Asana
{
    public partial class Task
    {
        /// <summary>
        /// Updates an Asana Task from an Asana Task object.
        /// In the meantime, this method will fail and as such, is hidden from Dynamo by marking it as "internal"
        /// </summary>
        /// <param name="client">The Asana client to use to send the request.</param>
        /// <param name="task">The Task to update. This task has to already exist on Asana and have a valid ID.
        /// Any properties of the Task that are not null will update the task on Asana servers.</param>
        /// <returns>The modified Asana task as it now exists on the Asana servers.</returns>
        internal static List<Task> UpdateTask(AsanaClient client, Task task)
        {
            /// web requests can take a long time, so we validate data before PUT and bail early if required
            if (task == null)
                throw new ArgumentException("Must supply a valid task.");
            if (!Helpers.Classes.CheckId(task.Id))
                throw new ArgumentException("Invalid task id.");
            if (task.Workspace == null)
                throw new ArgumentException("Must specify a workspace when creating a task.");
            if (Helpers.Classes.CheckId(task.Workspace.Id) == false)
                throw new ArgumentException("Invalid workspace id.");
            if (task.Projects == null)
                throw new ArgumentException("Must specify a project when creating a task.");
            task.Projects.ForEach(p =>
            { if (Helpers.Classes.CheckId(p.Id) == false) throw new ArgumentException("Invalid project id."); }
            );

            string resource = "tasks/" + task.Id;
            var request = new AsanaRequest(client, Method.PUT, resource);

            /// TODO : implement support for uploading a JSON-serialised Asana.Task object directly as request Body
            return new List<Task> { request.Execute<Task>(client) };
        }

    }
}
