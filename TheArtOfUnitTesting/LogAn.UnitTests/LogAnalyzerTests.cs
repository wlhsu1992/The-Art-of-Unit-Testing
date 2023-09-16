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
        public void IsValidLogFileName_BadExtension_ReturnFalse()
        {
        }
    }
}