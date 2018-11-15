namespace Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [ExcludeFromCodeCoverage]
    public static class Extensions
    {       
        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>returns an object</returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }        

        /// <summary>
        /// To the j token.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static JToken ToJToken(this string value)
        {
            return JToken.Parse(value);
        }

        /// <summary>
        /// Converts object to JToken.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A JToken object created from the input object</returns>
        public static JToken ToJToken(this object value)
        {
            // Sending Octal numbers (with leading zeros) is not as per the specification of JSON
            // refer http://www.ietf.org/rfc/rfc4627.txt
            // This new extension method handles this scenario where the input value is sent as an object instead of string.
            // Now this input can be used for creating a JToken using the JToken.FromObject method which doesn't change the type of the input value
            return JToken.FromObject(value);
        }

        /// <summary>
        /// To the JObject.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns an JObject</returns>
        public static JObject ToJObject(this string value)
        {
            return JObject.Parse(value);
        }

        /// <summary>
        /// To the j array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>returns JArray object</returns>
        public static JArray ToJArray(this string value)
        {
            return JArray.Parse(value);
        }

        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>returns an object</returns>
        public static string ToJson(this object obj, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        public static string ToJson(this object obj, Formatting settings)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static T FromJson<T>(this object obj)
        {
            return JsonConvert.DeserializeObject<T>(obj as string);
        }

        /// <summary>
        /// Deserializes the helper.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>returns an object</returns>
        public static object FromJson(this string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        /// <summary>
        /// Deserializes the helper.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object FromJson(this string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }

        /// <summary>
        /// Deserializes the helper.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>returns an object</returns>
        public static object FromJson(this string value, Type type, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject(value, type, settings);
        }

        /// <summary>
        /// Deserializes the helper.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>returns an object</returns>
        public static T FromJson<T>(this string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }        
    }
}