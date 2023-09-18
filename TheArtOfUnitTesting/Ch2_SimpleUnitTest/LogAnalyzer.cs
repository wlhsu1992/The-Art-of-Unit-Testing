using Ch2_SimpleUnitTest.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch2_SimpleUnitTest
{
    public class LogAnalyzer
    {
        private IExtensionManager _extensionManager;
        private IWebService _webService;

        public LogAnalyzer(IExtensionManager mgr
            , IWebService webService)
        {
            _extensionManager = mgr;
            _webService = webService;
        }

        /// <summary>
        /// 驗證檔案副檔名是否為 SLF，是的話返回 true ；反之 false
        /// </summary>
        /// <param name="fileName">完整檔案名稱</param>
        /// <returns></returns>
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(
                    "filename has to be provided");
            }

            if(fileName.Length < 8)
            {
                _webService.LogError($"Filename too short: {fileName}");
            }

            return _extensionManager.IsValid(fileName);
        }
    }

}
