using Newtonsoft.Json;

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
            if (Helpers.Classes.CheckId(id)) this.Id = id;
        }
    }

}
