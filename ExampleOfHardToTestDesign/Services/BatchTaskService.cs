using System;
using System.Collections.Generic;
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
        /// 新增批次任務，若全部新增成功則回傳 <c>true</c> 否則為 <c>false</c>。
        /// </summary>
        /// <param name="batchUploadData">批次任務資料集。</param>
        /// <returns>若全部新增成功則回傳 <c>true</c> 否則為 <c>false</c>。</returns>
        public bool CreateBatchTasks(IEnumerable<BatchTaskDataEntity> batchTaskData)
        {
            if (batchTaskData == null)
            {
                throw new ArgumentNullException(nameof(batchTaskData));
            }

            int officeHours = 9;
            int offHours = 18;
            int currentHours = DateTime.Now.Hour;
            var isDelayBookingTime = false;

            if (currentHours > officeHours && currentHours < offHours)
            {
                isDelayBookingTime = true;
            }

            var result = true;
            int intervals = 1;
            var bookingTime = DateTime.Now;
            var taskHelper = new TaskHelper();

            foreach (var item in batchTaskData)
            {
                try
                {
                    bookingTime = isDelayBookingTime ? bookingTime.AddMinutes(intervals) : DateTime.Now;
                    var serializedData = JsonConvert.SerializeObject(item);
                    taskHelper.CreateTask("BatchTask", serializedData, bookingTime);
                }
                catch (Exception ex)
                {
                    result = false;
                    // TODO: 記錄錯誤資訊。

                    continue;
                }
            }

            return result;
        }
    }
}