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
    /// Class represents an Asana heart.
    /// See API structure at https://asana.com/developers/api-reference/stories
    /// </summary>
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

}
