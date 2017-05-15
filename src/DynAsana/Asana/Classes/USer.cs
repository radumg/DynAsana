using Newtonsoft.Json;
using System.Collections.Generic;

namespace Asana.Classes
{
    /// <summary>
    /// Class represents an Asana user.
    /// See API structure at https://asana.com/developers/api-reference/users
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
            if (Helpers.Classes.CheckId(id)) this.Id = id;
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
