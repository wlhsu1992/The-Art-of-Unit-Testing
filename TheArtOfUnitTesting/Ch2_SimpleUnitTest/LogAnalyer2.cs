using Ch2_SimpleUnitTest.Interface;
using static Ch2_SimpleUnitTest.LogAnalyzer;

namespace Ch2_SimpleUnitTest
{
    public class LogAnalyer2
    {
        public IWebService WebService { get; set; }
        public IEmailService EmailService { get; set; }

        public LogAnalyer2(IWebService webService, IEmailService emailService)
        {
            WebService = webService;
            EmailService = emailService;
        }

        public void Analyze(string fileName)
        {
            // 當檔案名稱字數小於 8 時，執行以下操作
            if (fileName.Length < 8)
            {
                try
                {
                    // 記錄 Log 訊息
                    WebService.LogError($"Filename too short:{fileName}");
                }
                catch (Exception e)
                {
                    // 發送 Mail
                    EmailService.SendEmail("someone@somewhere.com", "can't log", e.Message);
                }
            }
        }
    }

}
