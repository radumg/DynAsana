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
            if (Classes.CheckId(id)) this.Id = id;
        }
    }

}
