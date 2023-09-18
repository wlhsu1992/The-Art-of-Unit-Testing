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
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager();
            fakeExtensionManager.WillBeValid = true;
            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeExtensionManager);

            bool result = logAnalyzer.IsValidLogFileName("short.ext");
            Assert.True(result);
        }

        /// <summary>
        /// 測試拋出例外情形
        /// </summary>
        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            FakeExtensionManager fakeExtensionManager = new FakeExtensionManager();
            LogAnalyzer logAnalyzer = new LogAnalyzer(fakeExtensionManager);

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
    }

    public class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public bool IsValid(string fileName)
        {
            return WillBeValid;
        }
    }
}