using Newtonsoft.Json;

namespace Asana
{
    /// <summary>
    /// Class represents the value of an Asana CustomField.
    /// See API structure at https://asana.com/developers/api-reference/custom_fields
    /// </summary>
    internal class CustomFieldValue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("name")]
        public string Value { get; set; }

        public CustomFieldValue()
        {

        }

        public CustomFieldValue(string id=null, string value=null)
        {
            if (Helpers.Classes.CheckId(id)) this.Id = id;
            else this.Id = "";

            if (Helpers.Classes.CheckId(id)) this.Value = value;
            else this.Value = "";
        }
    }

    /// <summary>
    /// Class represents an Asana CustomField.
    /// See API structure at https://asana.com/developers/api-reference/custom_fields
    /// </summary>
    public class CustomField
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enum_value")]
        internal CustomFieldValue EnumValue { get; set; }

        public string Value { get { return this.EnumValue.Value; } }
        public bool Enabled { get { return this.EnumValue.Enabled; } }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public CustomField()
        {

        }

        public CustomField(string id=null, string name = null, string value=null)
        {
            if (Helpers.Classes.CheckId(id)) this.Id = id;
            else this.Id = "";
            this.EnumValue = new CustomFieldValue("", value);
        }
    }

}
