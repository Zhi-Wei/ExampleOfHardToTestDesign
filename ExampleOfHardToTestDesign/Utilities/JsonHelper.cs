using System;
using Newtonsoft.Json;

namespace ExampleOfHardToTestDesign.Utilities
{
    /// <summary>
    /// JSON 實用程式。
    /// </summary>
    /// <seealso cref="ExampleOfHardToTestDesign.Utilities.IJsonHelper" />
    public class JsonHelper : IJsonHelper
    {
        /// <summary>
        /// 還原序列化物件。
        /// </summary>
        /// <typeparam name="T">還原的型別。</typeparam>
        /// <param name="value">要還原序列化的值。</param>
        /// <returns>還原序列化後的物件。</returns>
        /// <exception cref="ArgumentException">value</exception>
        public T DeserializeObject<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(nameof(value));
            }

            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 序列化物件。
        /// </summary>
        /// <param name="value">要序列化的值。</param>
        /// <returns>序列化後的字串。</returns>
        /// <exception cref="ArgumentNullException">value</exception>
        public string SerializeObject(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return JsonConvert.SerializeObject(value);
        }
    }
}