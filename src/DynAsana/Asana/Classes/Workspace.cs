using Newtonsoft.Json;

namespace Asana.Classes
{
    /// <summary>
    /// Class represents an Asana workspace.
    /// See API structure at https://asana.com/developers/api-reference/workspaces
    /// </summary>
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
            if (Helpers.Classes.CheckId(id)) this.Id = id;
        }
    }

}
