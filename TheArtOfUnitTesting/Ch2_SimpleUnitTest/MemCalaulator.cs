using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch2_SimpleUnitTest
{
    public class MemCalaulator
    {
        private int sum = 0;

        /// <summary>
        /// 將輸入值與當前加總進行相加
        /// </summary>
        /// <param name="number"></param>
        public void Add(int number)
        {
            sum += number;
        }

        /// <summary>
        /// 返回當前加總並將加總值歸 0
        /// </summary>
        /// <returns></returns>
        public int Sum() 
        {
            int temp = sum;
            sum = 0;
            return temp;
        }    
    }
}
