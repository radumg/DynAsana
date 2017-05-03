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
    internal class AsanaError
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("phrase")]
        public string Phrase { get; set; }
    }

    /// <summary>
    /// Response from the Asana API detailing the errors that occured.
    /// </summary>
    public class AsanaErrorResponse
    {
        [JsonProperty("errors")]
        internal List<AsanaError> Errors { get; set; }
    }
}
