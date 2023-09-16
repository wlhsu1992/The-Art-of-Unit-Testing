using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch2_SimpleUnitTest
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        /// <summary>
        /// 驗證檔案副檔名是否為 SLF，是的話返回 true ；反之 false
        /// </summary>
        /// <param name="fileName">完整檔案名稱</param>
        /// <returns></returns>
        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(
                    "filename has to be provided");
            }

            if(!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;
            return true;

        }
    }
}
