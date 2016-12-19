using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using MPD.Electio.SDK.NetCore.DataTypes.Attributes;

namespace Spa.StarterKit.React.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Get the description from the data attribute of the enum
        /// </summary>
        /// <param name="e">The enum to get the attribute from</param>
        /// <returns>Either the entry from the data attribute or, where description is found, the enum represented as a string</returns>
        public static string ToDescription(this Enum e)
        {
            var fieldInfo = e.GetType().GetTypeInfo().GetField(e.ToString());
            if (fieldInfo == null)
            {
                return e.ToString();
            }
            try
            {
                var attributes =
                    (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : e.ToString();
            }
            catch (Exception)
            {
                return e.ToString();
            }
        }

        /// <summary>
        /// Extension method to convert enum into its description
        /// <remarks>
        /// Description is obtained from the 'Description' data annotation
        /// </remarks>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        public static string ToDescription<TEnum>(this TEnum e)
        {
            var fieldInfo = e.GetType().GetField(e.ToString());
            if (fieldInfo == null)
            {
                return e.ToString();
            }

            try
            {
                var attributes =
                    (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : e.ToString();
            }
            catch (Exception)
            {
                return e.ToString();
            }
        }

        /// <summary>
        /// "UnCamelCase" an enum
        /// <remarks>
        /// This converts an enum such as ThisEnumString into This Enum String
        /// <see cref="http://stackoverflow.com/questions/155303/net-how-can-you-split-a-caps-delimited-string-into-an-array"/>
        /// </remarks>
        /// </summary>
        /// <typeparam name="TEnum">The type of enum</typeparam>
        /// <param name="e">The enum</param>
        public static string UnCamelCase<TEnum>(this TEnum e)
        {
            var s = e.ToString();
            return Regex.Replace(s, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
        }

        /// <summary>
        /// Extension method to convert an enum to its display name
        /// <remarks>
        /// Display name taken from the [Display(Name="x")] data annotation
        /// </remarks>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        public static string ToDisplayName<TEnum>(this TEnum e)
        {
            var fieldInfo = e.GetType().GetField(e.ToString());
            var attributes =
                fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (attributes == null)
            {
                return e.ToString();
            }

            try
            {
                return (attributes.Length > 0 ? attributes[0].Name : e.ToString());
            }
            catch (Exception)
            {
                return e.ToString();
            }
        }

        private static readonly ConcurrentDictionary<Tuple<bool, Type, Type, Enum>, Attribute> AttributeMap = new ConcurrentDictionary<Tuple<bool, Type, Type, Enum>, Attribute>();

        /// <summary>
        /// Gets the specified attribute from an enum via a cache.
        /// </summary>
        /// <param name="value">Enum value we are checkin gfor an attribute</param>
        /// <param name="inherit">Should we check inherited members?</param>
        public static T GetAttribute<T>(this Enum value, bool inherit = false) where T : Attribute
        {
            var attrType = typeof(T);
            var valueType = value.GetType();
            var key = new Tuple<bool, Type, Type, Enum>(inherit, attrType, valueType, value);

            var attribute = AttributeMap.GetOrAdd(key, GetAttribute);
            return attribute as T;
        }

        public static UiDisplaySeverityAttribute.UiDisplaySeverity UiSeverity(this Enum value)
        {
            var attr = GetAttribute<UiDisplaySeverityAttribute>(value);
            return attr?.Severity ?? UiDisplaySeverityAttribute.UiDisplaySeverity.None;
        }

        private static Attribute GetAttribute(Tuple<bool, Type, Type, Enum> key)
        {
            var valueString = key.Item4.ToString();
            var field = key.Item3.GetField(valueString);

            return field.GetType().GetTypeInfo().GetCustomAttribute(key.Item2, key.Item1);
        }
    }
}