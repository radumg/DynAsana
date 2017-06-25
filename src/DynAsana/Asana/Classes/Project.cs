using Newtonsoft.Json;

namespace Asana
{
    /// <summary>
    /// Class represents an Asana project.
    /// See API structure at https://asana.com/developers/api-reference/projects
    /// </summary>
    public partial class Project
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public Project()
        {

        }

        public Project(string id)
        {
            if (Helpers.Classes.CheckId(id)) this.Id = id;
        }
    }

    /// <summary>
    /// Class represents an Asana section.
    /// See API structure at https://asana.com/developers/api-reference/sections
    /// </summary>
    public partial class Section
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public Section()
        {

        }

        public Section(string id)
        {
            if (Helpers.Classes.CheckId(id)) this.Id = id;
        }
    }

    /// <summary>
    /// Class represents an Asana membership.
    /// See API structure at https://asana.com/developers/api-reference/sections
    /// </summary>
    public class Membership
    {
        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("section")]
        public Section Section { get; set; }
    }

}
