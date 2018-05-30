using System.Collections.Generic;
using ExampleOfHardToTestDesign.Models;

namespace ExampleOfHardToTestDesign.Services
{
    /// <summary>
    /// 定義批次上傳服務的方法。
    /// </summary>
    public interface IBatchUploadService
    {
        /// <summary>
        /// 新增批次上傳任務，若新增成功則回傳 <c>true</c> 否則為 <c>false</c>。
        /// </summary>
        /// <param name="batchUploadData">批次上傳資料集。</param>
        /// <returns>若新增成功則回傳 <c>true</c> 否則為 <c>false</c>。</returns>
        bool CreateBatchUploadTasks(IEnumerable<BatchUploadDataEntity> batchUploadData);
    }
}