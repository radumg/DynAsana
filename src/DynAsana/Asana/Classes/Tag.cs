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

        /// <summary>
        /// A list of colours Asana can use for tags.
        /// Note : _ has replaced - due to C# limitations on using - in enumerations.
        /// Use the TagColourToString node to convert back to a valid Asana tag colour.
        /// </summary>
        public enum TagColor
        {
            dark_pink,
            dark_green,
            dark_blue,
            dark_red,
            dark_teal,
            dark_brown,
            dark_orange,
            dark_purple,
            dark_warm_gray,
            light_pink,
            light_green,
            light_blue,
            light_red,
            light_teal,
            light_yellow,
            light_orange,
            light_purple,
            light_warm_gray
        }

        /// <summary>
        /// Converts one of the standard Asana colour enumerations to string format
        /// </summary>
        /// <param name="colour">The tag colour to convert</param>
        /// <returns>A string representation of the colour.</returns>
        public string TagColourToString(TagColor colour)
        {
            return colour.ToString().Replace("_", "-");
        }

    }


}
