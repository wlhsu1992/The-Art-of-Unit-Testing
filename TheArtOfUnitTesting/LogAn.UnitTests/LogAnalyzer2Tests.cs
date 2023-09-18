using Ch2_SimpleUnitTest;
using Ch2_SimpleUnitTest.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ch2_SimpleUnitTest.LogAnalyzer;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            var stubService = new FakeWebService2();
            stubService.ToThrow = new Exception("fake exception");
            
            FakeMailService mockEmail = new FakeMailService();

            LogAnalyer2 log = new LogAnalyer2(stubService, mockEmail);
            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);

            StringAssert.Contains("someone@somewhere.com", mockEmail.To);
            StringAssert.Contains("fake exception", mockEmail.Body);
            StringAssert.Contains("can't log", mockEmail.Subject);
        }

    }
    public class FakeWebService2 : IWebService
    {
        public Exception ToThrow;

        public void LogError(string message)
        {
            if(ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }

    public class FakeMailService : IEmailService
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject; 
            Body = body;
        }
    }
}
