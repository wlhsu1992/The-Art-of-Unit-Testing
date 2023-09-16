using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheArtOfUnitTesting;

namespace Ch1_SimpleUnitTestSample
{
    /// <summary>
    /// 無測試框架情況的通用測試類
    /// </summary>
    public class TestUtil
    {
        public static void ShowProblem(string test, string message)
        {
            string msg = string.Format(@"
            ---- {0} ----
            {1}
            -------------
            ", test, message);
            Console.WriteLine(msg);
        }

        public static void TestReturnZeroWhenEmptyString()
        {
            // 使用 .NET 反射 API 得到當前方法名
            string testName = MethodBase.GetCurrentMethod().Name;

            try
            {
                SimpleParser p = new SimpleParser();
                int result = p.ParseAndSum(string.Empty);
                if(result != 0)
                {
                    // 調用輔助方法
                    TestUtil.ShowProblem(testName,
                            "Parse and sum should have returned 0 on an empty string");
                }
            }catch(Exception ex) 
            {
                TestUtil.ShowProblem(testName, ex.ToString());    
            }
        }
    }
}
