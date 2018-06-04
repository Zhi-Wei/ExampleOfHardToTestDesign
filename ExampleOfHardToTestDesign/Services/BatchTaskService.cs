using System;
using System.Collections.Generic;
using ExampleOfHardToTestDesign.Enums;
using ExampleOfHardToTestDesign.Models;
using ExampleOfHardToTestDesign.Utilities;
using Newtonsoft.Json;

namespace ExampleOfHardToTestDesign.Services
{
    /// <summary>
    /// 批次任務服務。
    /// </summary>
    /// <seealso cref="ExampleOfHardToTestDesign.Services.IBatchTaskService" />
    public class BatchTaskService : IBatchTaskService
    {
        /// <summary>
        /// 任務實用程式。
        /// </summary>
        private readonly ITaskHelper _taskHelper;

        /// <summary>
        /// 初始化 <see cref="BatchTaskService"/> 類別實體。
        /// </summary>
        /// <param name="taskHelper">任務實用程式。</param>
        /// <exception cref="ArgumentNullException">taskHelper</exception>
        public BatchTaskService(ITaskHelper taskHelper)
        {
            this._taskHelper = taskHelper ?? throw new ArgumentNullException(nameof(taskHelper));
        }

        /// <summary>
        /// 現在時間。
        /// </summary>
        public Func<DateTime> DateTimeNow { get; set; } = () => DateTime.Now;

        /// <summary>
        /// 新增批次任務，若全部新增成功則回傳 <c>true</c> 否則為 <c>false</c>。
        /// </summary>
        /// <param name="batchTaskData">批次任務資料集。</param>
        /// <returns>若全部新增成功則回傳 <c>true</c> 否則為 <c>false</c>。</returns>
        /// <exception cref="ArgumentNullException">batchTaskData</exception>
        public bool CreateBatchTasks(IEnumerable<BatchTaskDataEntity> batchTaskData)
        {
            if (batchTaskData == null)
            {
                throw new ArgumentNullException(nameof(batchTaskData));
            }

            int officeHours = 9;
            int offHours = 18;
            int currentHours = this.DateTimeNow().Hour;
            var isDelayBookingTime = false;

            if (currentHours > officeHours && currentHours < offHours)
            {
                isDelayBookingTime = true;
            }

            var result = true;
            int intervals = 1;
            var bookingTime = this.DateTimeNow();

            foreach (var item in batchTaskData)
            {
                try
                {
                    bookingTime = isDelayBookingTime ? bookingTime.AddMinutes(intervals) : this.DateTimeNow();
                    var serializedData = JsonConvert.SerializeObject(item);
                    this._taskHelper.CreateTask(TaskTypeEnum.BatchTask, serializedData, bookingTime);
                }
                catch (Exception)
                {
                    result = false;
                    //// TODO: 記錄錯誤資訊。

                    continue;
                }
            }

            return result;
        }
    }
}