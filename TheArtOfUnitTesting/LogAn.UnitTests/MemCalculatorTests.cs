using Ch2_SimpleUnitTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class MemCalculatorTests
    {
        [Test]
        public void Sum_ByDefault_ReturnZero()
        {
            var calculator = MakeCalc();
            var result = calculator.Sum();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_AddOneThenAddTwo_ReturnOne()
        {
            var calculator = MakeCalc();
            calculator.Add(1);
            calculator.Add(2);

            var result = calculator.Sum();
            Assert.AreEqual(3, result);
        }

        private static MemCalaulator MakeCalc()
        {
            return new MemCalaulator();
        }

    }
}
