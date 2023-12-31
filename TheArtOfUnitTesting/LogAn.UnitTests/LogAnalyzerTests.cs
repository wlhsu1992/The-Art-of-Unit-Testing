using Ch2_SimpleUnitTest;
using Ch2_SimpleUnitTest.Interface;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace LogAn.UnitTests
{
    /// <summary>
    /// 測試類命名原則 {TargetTestClass}Tests
    /// </summary>
    [TestFixture]
    public class LogAnalyzerTests
    {
        /// <summary>
        /// 單元測試命名原則 {UnitOfWorkName}_{Scenario}_{ExpectedBehavior}
        /// </summary>
        [Test]
        public void IsValidLogFileName_NameSupportedExtension_ReturnTrue()
        {
            var fakeExtensionManager = new FakeExtensionManager();
            var fakeWebService = new FakeWebService();
            fakeExtensionManager.WillBeValid = true;
            var logAnalyzer = new LogAnalyzer(fakeExtensionManager, fakeWebService);

            bool result = logAnalyzer.IsValidLogFileName("short.SLF");
            Assert.True(result);
        }

        /// <summary>
        /// 測試拋出例外情形
        /// </summary>
        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            var fakeExtensionManager = new FakeExtensionManager();
            var fakeWebService = new FakeWebService();
            var logAnalyzer = new LogAnalyzer(fakeExtensionManager, fakeWebService);

            var ex = Assert.Catch<Exception>(() => logAnalyzer.IsValidLogFileName(string.Empty));

            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        /// <summary>
        /// 忽略測試案例
        /// </summary>
        [Test]
        [Ignore("ignore this test case")]
        public void IsValidFileNAme_ValidFile_ReturnTrue()
        {
            Assert.True(false);
        }

        /// <summary>
        /// 使用 Mock 驗證第三方操作
        /// </summary>
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            var fakeExtensionManager = new FakeExtensionManager();
            var mockService = new FakeWebService();
            var log = new LogAnalyzer(fakeExtensionManager, mockService);
            string tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);

            // 對模擬物件進行斷言：驗證參數可以如預期般的被傳入
            StringAssert.Contains("Filename too short:abc.ext", mockService.LastError);
        }
    }

    public class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public bool IsValid(string fileName)
        {
            return WillBeValid;
        }
    }

    public class FakeWebService : IWebService
    {
        public string LastError { get; set; }

        public void LogError(string message) 
        {
            LastError = message;
        }
    }
}