using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Asana.Helpers
{
    internal class SkipPropertyAttribute : Attribute
    {
    }

    internal static class TypeExtensions
    {
        internal static PropertyInfo[] GetFilteredProperties(this Type type)
        {
            return type.GetProperties().Where(prop => prop.GetCustomAttributes(typeof(SkipPropertyAttribute), true).Length == 0).ToArray();
        }
    }

    public static class Classes
    {
        /// <summary>
        /// Checks whether a field is a valid string
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>True if the value is not null/empty, false otherwise.</returns>
        public static Boolean CheckFieldValue(string value)
        {
            if (String.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) return false;
            return true;
        }

        /// <summary>
        /// Check if the supplied Id is valid. Note: does not guarantee Id is valid, only checks general format.
        /// </summary>
        /// <param name="Id">The id to check</param>
        /// <returns>True if Id seems valid, false otherwise.</returns>
        public static Boolean CheckId(string Id)
        {
            if (String.IsNullOrEmpty(Id) || string.IsNullOrWhiteSpace(Id)) return false;
            if (!long.TryParse(Id, out var id)) return false;
            return true;
        }

        /// <summary>
        /// Serializes any object to JSON, useful for debugging purposes
        /// </summary>
        /// <returns>The JSON-formatted string</returns>
        public static string ToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        #region Types

        /// <summary>
        /// Gets only non-null properties from a Type. Also respects the [SkipProperty] attribute.
        /// </summary>
        /// <param name="obj">The object to extract type properties from.</param>
        /// <returns>A dictionary of properties and their values.</returns>
        internal static Dictionary<string, string> GetValidProperties(object obj)
        {
            var parameters = new Dictionary<string, string>();
            Type type = obj.GetType();
            foreach (PropertyInfo prop in type.GetFilteredProperties())
            {
                object value = prop.GetValue(obj);
                if (value != null) parameters.Add(prop.Name, value.ToString());
            }
            return parameters;
        }

        /// <summary>
        /// Gets JSON encoded non-null properties from a Type. Also respects the [SkipProperty] attribute.
        /// </summary>
        /// <param name="obj">The object to extract type properties from.</param>
        /// <returns>A dictionary of properties and their values.</returns>
        internal static Dictionary<string, string> GetValidPropertiesJSON(object obj)
        {
            var parameters = new Dictionary<string, string>();
            Type type = obj.GetType();
            foreach (PropertyInfo prop in type.GetFilteredProperties())
            {
                object value = prop.GetValue(obj);
                if (value != null) parameters.Add(prop.Name, JsonConvert.SerializeObject(value.ToString()));
            }
            return parameters;
        }
        
        #endregion
    }

}