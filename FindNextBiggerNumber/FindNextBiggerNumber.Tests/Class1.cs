using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day2;

namespace Day2.Tests
{
    public static class FindNextBiggerNumberTests
    {
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(0, null)]
        [TestCase(1024, 1042)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(10, null)]
        public static void FindTests(int number, int? result)
        {
            Assert.AreEqual(result, FindNextBiggerNumber.Find(number));
        }
    }
}
