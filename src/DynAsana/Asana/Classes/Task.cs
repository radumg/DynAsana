using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft;
using Web;

/// <summary>
/// Namespace holds classes that are used to represent Slack entities
/// </summary>
namespace Asana
{
    /// <summary>
    /// Class represents a Slack message.
    /// See API structure at https://asana.com/developers/api-reference/tasks
    /// </summary>
    class Task
    {
        public string text { get; set; }
        public string id { get; private set; }
        public string assignee { get; set; }

        /// <summary>
        /// Construct a Slack message given a text and an optional attachment
        /// </summary>
        /// <param name="Text">The text to be sent as a Slack message</param>
        public Task(string Text)
        {
            if (!String.IsNullOrEmpty(Text) && !String.IsNullOrWhiteSpace(Text)) this.text = Text;
        }

        /// <summary>
        /// Serializes the Slack message to JSON
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Posts the message to Slack on behalf of the Slack Client's user. Requires a valid OAuth token in Client.
        /// </summary>
        /// <returns></returns>
        public string Post(Client slackClient)
        {
            string response = null;

            try
            {
                if (slackClient == null) throw new Exception("A valid Slack client needs to be supplied.");

                // TODO : implement message posting factory
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return response;
        }
    }


}
