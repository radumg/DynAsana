using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Asana.Helpers;
using Asana.Classes;

namespace Asana.Classes
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
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [SkipProperty]
        [JsonProperty("assignee")]
        public User Assignee { get; set; }

        [JsonProperty("assignee_status")]
        public string AssigneeStatus { get; set; }

        [JsonProperty("completed")]
        public bool? Completed { get; set; }

        [SkipProperty]
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        [JsonProperty("followers")]
        public Follower[] Followers { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [SkipProperty]
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        #endregion

        #region Context

        [SkipProperty]
        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }

        [SkipProperty]
        [JsonProperty("projects")]
        public List<Project> Projects { get; set; }

        [JsonProperty("parent")]
        public Task Parent { get; set; }

        [SkipProperty]
        [JsonProperty("memberships")]
        public List<Membership> Memberships { get; set; }

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
        public bool? Hearted { get; private set; }

        [SkipProperty]
        [JsonProperty("hearts")]
        public List<Heart> Hearts { get; private set; }

        [JsonProperty("num_hearts")]
        public int? NumberOfHearts { get; private set; }

        #endregion

        /// <summary>
        /// Create an Asana task by specifying basic properties & a few optional ones.
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="description">The description of the task. Relates to "notes" field in API.</param>
        /// <param name="workspace">The workspace to create Task in.</param>
        /// <param name="assignee">The user to assign the task to.</param>
        /// <param name="projects">The projects this task will be part of. Projects must be in same workspace as specified workspace.</param>
        /// <param name="tags">The tags to use on the task.</param>
        public Task(
            string name,
            string description,
            Workspace workspace,
            User assignee = null,
            List<Project> projects = null, // in Asana API, projects parameter can be empty if a workspace is supplied
            List<Tag> tags = null)
        {
            if (workspace != null && Helpers.Classes.CheckId(workspace.Id)) this.Workspace = workspace;
            if (projects != null && projects.Count > 0) this.Projects = projects;
            if (tags != null && tags.Count > 0) this.Tags = tags;
            if (Helpers.Classes.CheckFieldValue(name)) this.Name = name;
            if (Helpers.Classes.CheckFieldValue(description)) this.Notes = description;
            if (assignee != null && Helpers.Classes.CheckId(assignee.Id)) this.Assignee = assignee;
        }

        /// <summary>
        /// Parameterless Task constructor
        /// </summary>
        public Task()
        {
        }

    }

}
