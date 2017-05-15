using System;
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

    internal static class Classes
    {
        /// <summary>
        /// Checks whether a field is a valid string
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>True if the value is not null/empty, false otherwise.</returns>
        internal static Boolean CheckFieldValue(string value)
        {
            if (String.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) return false;
            return true;
        }

        /// <summary>
        /// Check if the supplied Id is valid. Note: does not guarantee Id is valid, only checks general format.
        /// </summary>
        /// <param name="Id">The id to check</param>
        /// <returns>True if Id seems valid, false otherwise.</returns>
        internal static Boolean CheckId(string Id)
        {
            if (String.IsNullOrEmpty(Id) || string.IsNullOrWhiteSpace(Id)) return false;
            if (!long.TryParse(Id, out var id)) return false;
            return true;
        }
    }
}
