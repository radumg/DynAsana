using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaSlack.Asana.Classes
{
    /// <summary>
    /// This class serializes to JSON the payload required by Slack Incoming WebHooks
    /// </summary>
    class SlackPayload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon_emoji")]
        public string Emoji { get; set; }

        [JsonProperty("icon_url")]
        public string Icon { get; set; }
    }
}
