using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheArtOfUnitTesting
{
    public class SimpleParser
    {
        /// <summary>
        /// 字串解析數字
        /// </summary>
        /// <param name="numbers">要解析的字串</param>
        /// <returns></returns>
        public int ParseAndSum(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            if (!numbers.Contains(","))
            {
                return int.Parse(numbers);
            }
            else
            {
                throw new InvalidOperationException(
                    "I can only handle 0 or 1 numbers for now!");
            }
        }
    }
}
    