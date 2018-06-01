using System.Collections.Generic;
using ExampleOfHardToTestDesign.Models;

namespace ExampleOfHardToTestDesign.Services
{
    /// <summary>
    /// 定義批次任務服務的方法。
    /// </summary>
    public interface IBatchTaskService
    {
        /// <summary>
        /// 新增批次任務，若全部新增成功則回傳 <c>true</c> 否則為 <c>false</c>。
        /// </summary>
        /// <param name="batchUploadData">批次任務資料集。</param>
        /// <returns>若全部新增成功則回傳 <c>true</c> 否則為 <c>false</c>。</returns>
        bool CreateBatchTasks(IEnumerable<BatchTaskDataEntity> batchUploadData);
    }
}