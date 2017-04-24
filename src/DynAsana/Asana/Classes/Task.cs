using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft;
using Web;
using Asana;
using RestSharp;

/// <summary>
/// Namespace holds classes that are used to represent Asana entities
/// </summary>
namespace Asana
{
    /// <summary>
    /// Class represents an Asana task.
    /// See API structure at https://asana.com/developers/api-reference/tasks
    /// </summary>
    [Serializable]
    public class Task
    {
        #region Properties
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("assignee")]
        public Asana.User Assignee { get; set; }

        [JsonProperty("assignee_status")]
        public string AssigneeStatus { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("custom_fields")]
        public List<Asana.CustomField> CustomFields { get; set; }

        [JsonProperty("followers")]
        public Asana.Follower[] Followers { get; private set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("tags")]
        public List<Asana.Tag> Tags { get; private set; }
        #endregion

        #region Context
        [JsonProperty("workspace")]
        public Asana.Workspace Workspace { get; private set; }

        [JsonProperty("projects")]
        public List<Asana.Project> Projects { get; private set; }

        [JsonProperty("parent")]
        public Asana.Task Parent { get; set; }

        [JsonProperty("memberships")]
        public List<Asana.Membership> Memberships { get; set; }
        #endregion

        #region Timestamps
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; private set; }

        [JsonProperty("completed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CompletedAt { get; private set; }

        [JsonProperty("due_on", NullValueHandling = NullValueHandling.Ignore)]
        public string DueOn { get; set; }

        [JsonProperty("due_at", NullValueHandling = NullValueHandling.Ignore)]
        public string DueAt { get; set; }

        [JsonProperty("modified_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifiedAt { get; private set; }
        #endregion

        #region Hearts

        [JsonProperty("hearted")]
        public bool Hearted { get; set; }

        [JsonProperty("hearts")]
        public List<Asana.Heart> Hearts { get; set; }

        [JsonProperty("num_hearts")]
        public int NumberOfHearts { get; set; }

    #endregion

        /// <summary>
        /// Create an Asana task
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="description">The description of the task.</param>
        public Task(string name, string description)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name)) this.Name = name;
            if (!String.IsNullOrEmpty(description) && !String.IsNullOrWhiteSpace(description)) this.Name = name;
        }

        /// <summary>
        /// Serializes the Slack message to JSON
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}
