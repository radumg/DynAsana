using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana
{
    /// <summary>
    /// The below classes represent Asana entities.
    /// </summary>
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("photo")]
        public Photo Photos { get; set; }

        [JsonProperty("workspaces")]
        public List<Workspace> Workspaces { get; set; }

    }

    public class CustomFieldValue
    {
        public string id { get; set; }
        public bool enabled { get; set; }
        public string name { get; set; }
    }

    public class CustomField
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enum_value")]
        public CustomFieldValue Value { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Follower
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Project
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Section
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Membership
    {
        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("section")]
        public Section Section { get; set; }
    }

    public class Workspace
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_organization")]
        public bool IsOrganisation { get; set; }
    }

    public class Tag
    {
        public string id { get; set; }
        public string color { get; set; }
        public string created_at { get; set; }
        public List<Follower> followers { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public Workspace workspace { get; set; }
    }

    public class Heart
    {
        public string id { get; set; }
        public User user { get; set; }
    }

}
