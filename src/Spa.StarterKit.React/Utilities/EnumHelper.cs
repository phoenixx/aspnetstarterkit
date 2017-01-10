using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa.StarterKit.React.Extensions;


namespace Spa.StarterKit.React.Utilities
{
    public static class EnumHelper
    {
        /// <summary>
        /// Convert an Enum into a list of strings
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        public static List<string> EnumToList<TEnum>()
        {
            var resultList = (from TEnum type in Enum.GetValues(typeof(TEnum))
                              select type.ToString()).ToList();
            return resultList;
        }

        /// <summary>
        /// Convert an enum into a list of descriptions
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        public static List<string> EnumToDescriptionList<TEnum>()
        {
            var resultList = (from TEnum type in Enum.GetValues(typeof(TEnum)) select type.ToDescription()).ToList();
            return resultList;

        }

        /// <summary>
        /// Convert an enum into a list of "uncamelcased" strings
        /// <remarks>
        /// Uncamelcasing uses the <see cref="EnumExtensions"/> class to convert AStringLikeThis into A String Like This
        /// </remarks>
        /// </summary>
        /// <typeparam name="TEnum">The enum to convert</typeparam>
        /// <returns>A list of string</returns>
        public static List<string> EnumToUncamelCaseList<TEnum>()
        {
            var resultList = (from TEnum type in Enum.GetValues(typeof(TEnum)) select type.UnCamelCase()).ToList();
            return resultList;
        }

        /// <summary>
        /// Convert an enum into a list of key value pairs
        /// <remarks>
        /// The key is the int represenation of the enum, and the value is the string representation
        /// </remarks>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        public static List<System.Collections.Generic.KeyValuePair<int, string>> EnumToKeyValuePairs<TEnum>()
        {
            var resultList = (from object type in Enum.GetValues(typeof(TEnum)) select new System.Collections.Generic.KeyValuePair<int, string>((int)type, type.ToString())).ToList();
            return resultList;
        }

        /// <summary>
        /// Convert an enum into a list of key value pairs
        /// <remarks>
        /// The key is the int representation of the enum, and the value is the description from data annotations
        /// </remarks>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        public static List<System.Collections.Generic.KeyValuePair<int, string>> EnumToKeyValuePairDescriptions<TEnum>()
        {
            var resultList =
                (from object type in Enum.GetValues(typeof(TEnum))
                 select new System.Collections.Generic.KeyValuePair<int, string>((int)type, type.ToDescription())).ToList();
            return resultList;
        }

        /// <summary>
        /// Convert an enum into a list of key value pairs
        /// <remarks>
        /// The key is the int representation of the enum, and the value is the display name from data annotations
        /// </remarks>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<System.Collections.Generic.KeyValuePair<int, string>> EnumToKeyValuePairDisplayName<TEnum>()
        {
            return (from object type in Enum.GetValues(typeof(TEnum)) select new System.Collections.Generic.KeyValuePair<int, string>((int)type, type.ToDisplayName())).ToList();
        }

        public static List<System.Collections.Generic.KeyValuePair<int, string>> EnumToKeyValuePairDisplayNameExcludingObsolete<TEnum>()
        {
            return (from object type in Enum.GetValues(typeof(TEnum)) where !IsObsolete(type) select new System.Collections.Generic.KeyValuePair<int, string>((int)type, type.ToDisplayName())).ToList();
        }

        private static bool IsObsolete(object value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (ObsoleteAttribute[])
                fi.GetCustomAttributes(typeof(ObsoleteAttribute), false);
            return (attributes.Length > 0);
        }

        public static SelectList EnumToSelectList<TEnum>()
        {
            var results = EnumToList<TEnum>();
            return new SelectList(results);
        }

        public static IList<Tuple<int, string>> EnumToUncamelCaseTuple<TEnum>()
        {
            var resultTuple = (from object type in Enum.GetValues(typeof(TEnum))
                               select new Tuple<int, string>((int)type, type.UnCamelCase())).ToList();

            return resultTuple;
        }

        public static IList<TEnum> EnumToEnumList<TEnum>()
        {
            var result = (from object type in Enum.GetValues(typeof(TEnum))
                          select (TEnum)type).ToList();
            return result;
        }
    }
}