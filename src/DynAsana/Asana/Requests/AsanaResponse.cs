using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Asana
{
    /// <summary>
    /// Individual error message from Asana API.
    /// </summary>
    internal class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("phrase")]
        public string Phrase { get; set; }
    }

    /// <summary>
    /// Response from the Asana API.
    /// </summary>
    public class AsanaResponse
    {
        [JsonProperty("errors")]
        internal List<Error> Errors { get; set; }
    }
}
