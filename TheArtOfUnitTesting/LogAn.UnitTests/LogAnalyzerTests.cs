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
        /// <summary>
        /// 單元測試命名原則 {UnitOfWorkName}_{Scenario}_{ExpectedBehavior}
        /// </summary>
        [Test]
        [TestCase("filewithbadextension.foo", false)]
        [TestCase("filewithbadextension.SLF", true)]
        [TestCase("filewithbadextension.slf", true)]
        public void IsValidLogFileName_BadExtension_ReturnFalse(string fileName, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(fileName);
            Assert.AreEqual(expected, result);
        }
    }
}