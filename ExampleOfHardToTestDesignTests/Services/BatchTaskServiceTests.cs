using System;
using System.Collections.Generic;
using System.Linq;
using ExampleOfHardToTestDesign.Enums;
using ExampleOfHardToTestDesign.Models;
using ExampleOfHardToTestDesign.Services;
using ExampleOfHardToTestDesign.Utilities;
using FluentAssertions;
using NSubstitute;
using Xunit;

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
            this._taskHelper = Substitute.For<ITaskHelper>();
            this._jsonHelper = Substitute.For<IJsonHelper>();
        }

        /// <summary>
        /// 取得被測系統實體。
        /// </summary>
        /// <returns>被測系統實體。</returns>
        private BatchTaskService GetSystemUnderTestInstance()
        {
            var sut = new BatchTaskService(this._taskHelper, this._jsonHelper);

            return sut;
        }

        #endregion -- 前置準備 --

        #region -- CreateBatchTasks --

        /// <summary>
        /// Given   batchTaskData 為 Null
        /// When    執行 CreateBatchTasks
        /// Then    應拋出 ArgumentNullException 的例外狀況
        /// </summary>
        [Fact]
        [Trait(nameof(BatchTaskService), "CreateBatchTasks")]
        public void CreateBatchTasks_BatchTaskData_Is_Null_Should_Throw_ArgumentNullException()
        {
            // Arrange
            IEnumerable<BatchTaskDataEntity> batchTaskData = null;

            // Act
            Action act = () => this.GetSystemUnderTestInstance().CreateBatchTasks(batchTaskData);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .And.Message.Should().Be($"值不能為 null。{Environment.NewLine}參數名稱: batchTaskData");
        }

        /// <summary>
        /// Given   batchTaskData 不為空
        /// Given   DateTimeNow 為 9 時
        /// When    執行 CreateBatchTasks
        /// Then    應執行 _taskHelper.CreateTask 的方法並每個任務的預訂時間間隔一分鐘
        /// </summary>
        [Fact]
        [Trait(nameof(BatchTaskService), "CreateBatchTasks")]
        public void CreateBatchTasks_DateTimeNow_Nine_Clock_Each_Task_Should_Be_Intervals_One_Minutes()
        {
            // Arrange
            int intervals = 1;
            var dateTimeNow = new DateTime(2018, 6, 1, 9, 0, 0);
            var batchTaskData = new List<BatchTaskDataEntity>
            {
                new BatchTaskDataEntity { Data = "A" },
                new BatchTaskDataEntity { Data = "B" }
            };

            var batchTaskDataA = "{ \"Data\": \"A\" }";
            var batchTaskDataB = "{ \"Data\": \"B\" }";

            var bookingTimeA = dateTimeNow.AddMinutes(intervals);
            var bookingTimeB = bookingTimeA.AddMinutes(intervals);

            var sut = this.GetSystemUnderTestInstance();
            sut.DateTimeNow = () => dateTimeNow;

            this._jsonHelper.SerializeObject(Arg.Is(batchTaskData.First())).Returns(batchTaskDataA);
            this._jsonHelper.SerializeObject(Arg.Is(batchTaskData.Last())).Returns(batchTaskDataB);

            this._taskHelper.CreateTask(Arg.Any<TaskTypeEnum>(), Arg.Any<string>(), Arg.Any<DateTime?>())
                .Returns(true);

            // Act
            var actual = sut.CreateBatchTasks(batchTaskData);

            // Assert
            this._taskHelper.Received(1)
                .CreateTask(Arg.Is(TaskTypeEnum.BatchTask), Arg.Is(batchTaskDataA), Arg.Is(bookingTimeA));
            this._taskHelper.Received(1)
                .CreateTask(Arg.Is(TaskTypeEnum.BatchTask), Arg.Is(batchTaskDataB), Arg.Is(bookingTimeB));
            actual.Should().BeTrue();
        }

        #endregion -- CreateBatchTasks --
    }
}