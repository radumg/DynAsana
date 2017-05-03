using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana
{
    internal class PostTask
    {

        [JsonProperty("assignee")]
        public string Assignee { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("workspace")]
        public string Workspace { get; set; }

        [JsonProperty("projects")]
        public string Projects { get; set; }

    }

    internal class PostObject
    {
        [JsonProperty("data")]
        public object data { get; set; }

        public PostObject(object data)
        {
            this.data = data;
        }
    }

}
