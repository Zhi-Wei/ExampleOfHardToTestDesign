using System;
using ExampleOfHardToTestDesign.Enums;

namespace ExampleOfHardToTestDesign.Utilities
{
    /// <summary>
    /// 定義任務實用程式的方法。
    /// </summary>
    public interface ITaskHelper
    {
        /// <summary>
        /// 新增任務，若新增任務成功回傳 <c>true</c> 否則為 <c>false</c>。
        /// </summary>
        /// <param name="taskType">任務類型。</param>
        /// <param name="data">任務資料。</param>
        /// <param name="bookingTime">預訂時間（選項）。</param>
        /// <returns>若新增任務成功回傳 <c>true</c> 否則為 <c>false</c>。</returns>
        bool CreateTask(TaskTypeEnum taskType, string data, DateTime? bookingTime = null);
    }
}