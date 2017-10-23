using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Day2;

namespace Day2.Tests
{
    public static class InsertNumberTests
    {
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(8, 15, 0, 0, 9)]
        [TestCase(8, 15, 3, 8, 120)]
        public static void InsertTest(int n1, int n2, int i, int j, int result)
        {
            Assert.AreEqual(result, InsertNumber.Insert(n1, n2, i, j));
        }
    }
}
