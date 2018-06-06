namespace ExampleOfHardToTestDesign.Utilities
{
    /// <summary>
    /// 定義 JSON 實用程式的方法。
    /// </summary>
    public interface IJsonHelper
    {
        /// <summary>
        /// 序列化物件。
        /// </summary>
        /// <param name="value">要序列化的值。</param>
        /// <returns>序列化後的字串。</returns>
        string SerializeObject(object value);

        /// <summary>
        /// 還原序列化物件。
        /// </summary>
        /// <typeparam name="T">還原的型別。</typeparam>
        /// <param name="value">要還原序列化的值。</param>
        /// <returns>還原序列化後的物件。</returns>
        T DeserializeObject<T>(string value);
    }
}