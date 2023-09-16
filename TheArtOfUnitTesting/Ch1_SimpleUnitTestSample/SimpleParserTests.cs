using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheArtOfUnitTesting
{
    /// <summary>
    /// 不使用測試框架的測試類
    /// </summary>
    public class SimpleParserTests
    {
        /// <summary>
        /// 測試目標方法是不是在輸入空字串時候可以正確返回 0
        /// </summary>
        public static void TestReturnZeroWhenEmptyString()
        {
            try
            {
                SimpleParser p = new SimpleParser();
                int result = p.ParseAndSum(string.Empty);

                // 預期 result 結果應為 0，如果不為 0 就返回以下文字表示測試失敗 
                if(result != 0)
                {
                    Console.WriteLine(@"SimpleParserTestsTestReturnsZeroWhenEmptyString:
                    ----------
                    Parse and sum should have returned 0 on an empty string");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
