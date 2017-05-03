using Asana.Helpers;
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

        public User()
        {
        }

        public User(string id=null, string name=null, string email=null, List<Workspace> workspace =null)
        {
            if (Helpers.Classes.CheckId(id)) this.Id = id;
            else this.Id = "";
            if (Helpers.Classes.CheckFieldValue(name)) this.Name = name;
            else this.Name = "";
            if (Helpers.Classes.CheckFieldValue(email)) this.Email = email;
            else this.Email = "";
            if (workspace != null) this.Workspaces = workspace;
            else this.Workspaces = new List<Workspace>();
        }
    }

    internal class CustomFieldValue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("name")]
        public string Value { get; set; }

        public CustomFieldValue()
        {

        }

        public CustomFieldValue(string id=null, string value=null)
        {
            if (Helpers.Classes.CheckId(id)) this.Id = id;
            else this.Id = "";

            if (Helpers.Classes.CheckId(id)) this.Value = value;
            else this.Value = "";
        }
    }

    public class CustomField
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enum_value")]
        internal CustomFieldValue EnumValue { get; set; }

        public string Value { get { return this.EnumValue.Value; } }
        public bool Enabled { get { return this.EnumValue.Enabled; } }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public CustomField()
        {

        }

        public CustomField(string id=null, string name = null, string value=null)
        {
            if (Helpers.Classes.CheckId(id)) this.Id = id;
            else this.Id = "";
            this.EnumValue = new CustomFieldValue("", value);
        }
    }

    public class Follower
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public Follower()
        {

        }

        public Follower(string id)
        {
            if (Classes.CheckId(id)) this.Id = id;
        }
    }

    public class Project
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public Project()
        {

        }

        public Project(string id)
        {
            if (Classes.CheckId(id)) this.Id = id;
        }
    }

    public class Section
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public Section()
        {

        }

        public Section(string id)
        {
            if (Classes.CheckId(id)) this.Id = id;
        }
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

        public Workspace()
        {
        }

        public Workspace(string id)
        {
            if (Classes.CheckId(id)) this.Id = id;
        }
    }

    public class Tag
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("followers")]
        public List<Follower> Followers { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("workspace")]
        public Workspace Workspace { get; set; }

        public Tag()
        {
        }

        public Tag(string id)
        {
            if (Helpers.Classes.CheckId(id)) this.Id = id;
        }
    }

    public class Heart
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        public Heart()
        {

        }

        public Heart(string id)
        {
            if (Classes.CheckId(id)) this.Id = id;
        }
    }

    public class Photo
    {
        public string image_21x21 { get; set; }
        public string image_27x27 { get; set; }
        public string image_36x36 { get; set; }
        public string image_60x60 { get; set; }
        public string image_128x128 { get; set; }
    }

}
