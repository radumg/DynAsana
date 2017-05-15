using Newtonsoft.Json;
using System.Collections.Generic;

namespace Asana.Classes
{
    /// <summary>
    /// Class represents an Asana tag.
    /// See API structure at https://asana.com/developers/api-reference/tags
    /// </summary>
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

}
