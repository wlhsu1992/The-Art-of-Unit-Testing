using Ch2_SimpleUnitTest;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    /// <summary>
    /// 測試類命名原則 {TargetTestClass}Tests
    /// </summary>
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer _analyzer = null;

        /// <summary>
        /// 在測試類中的每個測試 [運行之前] 都會執行這個方法。
        /// 通常用來執行一些重複性的初始化動作。
        /// (可能會降低代碼可讀性，所以書中不建議使用)
        /// </summary>
        [SetUp]
        public void SetUP()
        {
            _analyzer = new LogAnalyzer();
        }

        /// <summary>
        /// 單元測試命名原則 {UnitOfWorkName}_{Scenario}_{ExpectedBehavior}
        /// </summary>
        [Test]
        [TestCase("filewithbadextension.foo", false)]
        [TestCase("filewithbadextension.SLF", true)]
        [TestCase("filewithbadextension.slf", true)]
        public void IsValidLogFileName_BadExtension_ReturnFalse(string fileName, bool expected)
        {
            bool result = _analyzer.IsValidLogFileName(fileName);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// 測試拋出例外情形
        /// </summary>
        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            // Assert.Carch 函數返回 Lambda 內拋出的異常實例
            var ex = Assert.Catch<Exception>(() => _analyzer.IsValidLogFileName(string.Empty));

            // 對異常物件的訊息進行斷言
            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        /// <summary>
        /// 在測試類中的每個測試 [運行之後] 都會執行這個方法。
        /// 通常用來執行重複性的靜態變數初始化動作。
        /// (可能會降低代碼可讀性，所以書中不建議使用)
        /// </summary>
        [TearDown]
        public void TearDown() 
        {
            _analyzer = null;
        }
    }
}