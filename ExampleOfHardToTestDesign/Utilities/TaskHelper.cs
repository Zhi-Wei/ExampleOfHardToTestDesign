using System;
using ExampleOfHardToTestDesign.Enums;

namespace ExampleOfHardToTestDesign.Utilities
{
    /// <summary>
    /// 任務實用程式。
    /// </summary>
    /// <seealso cref="ExampleOfHardToTestDesign.Utilities.ITaskHelper" />
    public class TaskHelper : ITaskHelper
    {
        /// <summary>
        /// 新增任務，若新增任務成功回傳 <c>true</c> 否則為 <c>false</c>。
        /// </summary>
        /// <param name="taskType">任務類型。</param>
        /// <param name="data">任務資料。</param>
        /// <param name="bookingTime">預訂時間（選項）。</param>
        /// <returns>若新增任務成功回傳 <c>true</c> 否則為 <c>false</c>。</returns>
        public bool CreateTask(TaskTypeEnum taskType, string data, DateTime? bookingTime = null)
        {
            // 範例程式不實作。
            return true;
        }
    }
}