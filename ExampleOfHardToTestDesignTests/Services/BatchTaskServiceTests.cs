using ExampleOfHardToTestDesign.Services;
using ExampleOfHardToTestDesign.Utilities;

namespace ExampleOfHardToTestDesignTests.Services.Tests
{
    /// <summary>
    /// 批次任務服務的測試類別。
    /// </summary>
    public class BatchTaskServiceTests
    {
        #region -- 前置準備 --

        /// <summary>
        /// 任務實用程式。
        /// </summary>
        private readonly ITaskHelper _taskHelper;

        /// <summary>
        /// JSON 實用程式。
        /// </summary>
        private readonly IJsonHelper _jsonHelper;

        /// <summary>
        /// 初始化 <see cref="BatchTaskServiceTests"/> 類別實體。
        /// </summary>
        public BatchTaskServiceTests()
        {
        }

        private BatchTaskService GetSystemUnderTestInstance()
        {
            var sut = new BatchTaskService(this._taskHelper, this._jsonHelper);

            return sut;
        }

        #endregion -- 前置準備 --
    }
}