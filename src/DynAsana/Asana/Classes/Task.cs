using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Asana.Helpers;

namespace Asana
{
    /// <summary>
    /// Class represents an Asana task.
    /// See API structure at https://asana.com/developers/api-reference/tasks
    /// </summary>
    [Serializable]
    public partial class Task
    {
        #region Properties

        #region General
        /// <summary>
        /// The unique numeric ID of the task
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name/title of the task
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The user assigned to the task
        /// </summary>
        [JsonProperty("assignee")]
        public User Assignee { get; set; }

        /// <summary>
        /// The status of the user assigned to the task
        /// </summary>
        [JsonProperty("assignee_status")]
        public string AssigneeStatus { get; set; }

        /// <summary>
        /// Boolean whether task is marked as complete or not
        /// </summary>
        [JsonProperty("completed")]
        public bool? Completed { get; set; }

        /// <summary>
        /// The list of custom fields attached to the task
        /// </summary>
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <summary>
        /// The list of users that follow the task
        /// </summary>
        [JsonProperty("followers")]
        public Follower[] Followers { get; set; }

        /// <summary>
        /// The description (text) of the task
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// The list of tags assigned to the task
        /// </summary>
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }
        #endregion
        #region Context

        /// <summary>
        /// The workspace the task is part of
        /// </summary>
        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }

        /// <summary>
        /// The list of projects the task is part of
        /// </summary>
        [JsonProperty("projects")]
        public List<Project> Projects { get; set; }

        /// <summary>
        /// The parent task, if any
        /// </summary>
        [JsonProperty("parent")]
        public Task Parent { get; set; }

        /// <summary>
        /// Task memberships
        /// </summary>
        [JsonProperty("memberships")]
        public List<Membership> Memberships { get; set; }

        #endregion
        #region Timestamps

        /// <summary>
        /// The datetime task was created at
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// The datetime the task was marked complete at
        /// </summary>
        [JsonProperty("completed_at")]
        public string CompletedAt { get; private set; }

        /// <summary>
        /// The date task is due on
        /// </summary>
        [JsonProperty("due_on")]
        public string DueOn { get; set; }

        /// <summary>
        /// The time the task is due at
        /// </summary>
        [JsonProperty("due_at")]
        public string DueAt { get; set; }

        /// <summary>
        /// The last datetime the task was modified
        /// </summary>
        [JsonProperty("modified_at")]
        public string ModifiedAt { get; private set; }

        #endregion
        #region Hearts

        /// <summary>
        /// Whether the task was hearted or not
        /// </summary>
        [JsonProperty("hearted")]
        public bool? Hearted { get; private set; }

        /// <summary>
        /// The list of heart objects
        /// </summary>
        [JsonProperty("hearts")]
        public List<Heart> Hearts { get; private set; }

        /// <summary>
        /// The number of hearts
        /// </summary>
        [JsonProperty("num_hearts")]
        public int? NumberOfHearts { get; private set; }

        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// Create an Asana task by specifying basic properties & a few optional ones.
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="description">The description of the task. Relates to "notes" field in API.</param>
        /// <param name="workspace">The workspace to create Task in.</param>
        /// <param name="projects">The projects this task will be part of. Projects must be in same workspace as specified workspace.</param>
        /// <param name="assignee">The user to assign the task to.</param>
        /// <param name="tags">The tags to use on the task.</param>
        public Task(
            string name,
            string description,
            Workspace workspace,
            List<Project> projects,
            User assignee = null,
            List<Tag> tags = null)
        {
            if (workspace != null && Helpers.Classes.CheckId(workspace.Id))
                this.Workspace = workspace;
            else
                this.Workspace = null;

            if (projects != null && projects.Count > 0)
                this.Projects = projects;
            else
                this.Projects = new List<Project>();

            if (tags != null && tags.Count > 0)
                this.Tags = tags;
            else
                this.Tags = new List<Tag>();

            if (Helpers.Classes.CheckFieldValue(name))
                this.Name = name;
            else
                this.Name = null;

            if (Helpers.Classes.CheckFieldValue(description))
                this.Notes = description;
            else
                this.Notes = null;

            if (assignee != null && Helpers.Classes.CheckId(assignee.Id))
                this.Assignee = assignee;
            else
                this.Assignee = null;
        }

        /// <summary>
        /// Parameterless Task constructor
        /// </summary>
        public Task()
        {
            this.Workspace = null;
            this.Projects = new List<Project>();
            this.Tags = new List<Tag>();
            this.Name = null;
            this.Notes = null;
            this.Assignee = null;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Adds a Tag to an Asana task.
        /// </summary>
        /// <param name="tag">The Tag to add to the task, must be a valid Tag object.</param>
        /// <returns>The modified Task.</returns>
        public Task AddTag(Tag tag)
        {
            /// TODO : add validation to Tag class
            this.Tags.Add(tag);
            return this;
        }

        /// <summary>
        /// Removes a specific Tag from an Asana Task.
        /// </summary>
        /// <param name="tag">The Tag to remove, must be a valid Tag object.</param>
        /// <returns>The modified Task.</returns>
        public Task RemoveTag(Tag tag)
        {
            this.Tags.Remove(tag);
            return this;
        }

        /// <summary>
        /// Sets the task's assigned user.
        /// </summary>
        /// <param name="user">The Asana user to assign to, must be a valid User object.</param>
        /// <returns>The modified Task.</returns>
        public Task AssignUser(User user)
        {
            this.Assignee = user;
            return this;
        }

        /// <summary>
        /// Removes the assigned user from a task.
        /// </summary>
        /// <returns>The modified task.</returns>
        public Task RemoveUser()
        {
            this.Assignee = null;
            return this;
        }

        #endregion
    }
}
