using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeetCode.Tests
{
    public class ContainsArray
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
        [TestCase(new int[] { 0, 1 }, 2)]
        [TestCase(new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9 }, 1)]
        public void Test1(int[] nums, int expected)
        {
            int missingNumber = 0;
            //[9,6,4,2,3,5,7,0,1]
            for (int i = 0; i < nums.Length + 1; i++)
            {
                if (!nums.Contains(i))
                {
                    missingNumber = i;
                }
            }
            Assert.That(missingNumber, Is.EqualTo(expected));
            TestContext.WriteLine($"Missing number: {missingNumber}");
        }
    }
}