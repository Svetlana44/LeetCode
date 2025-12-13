using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА WHERE — фильтрация элементов
    /// </summary>
    public class Where_Tasks
    {
        #region Задача 1: Filter Even Numbers
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Filter Even Numbers (Easy)                                    ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив целых чисел. Верните только чётные числа.             ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 2, 3, 4, 5, 6]                              ║
        ║   Output: [2, 4, 6]                                              ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [7, 9, 11]                                      ║
        ║   Output: []                                                     ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [2, 4, 6, 8]                                    ║
        ║   Output: [2, 4, 6, 8]                                           ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 0 <= nums.length <= 1000                                     ║
        ║   • -10^6 <= nums[i] <= 10^6                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[] FilterEvenNumbers(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 2, 4, 6 })]
        [TestCase(new[] { 7, 9, 11 }, new int[] { })]
        [TestCase(new[] { 2, 4, 6, 8 }, new[] { 2, 4, 6, 8 })]
        public void Test_FilterEvenNumbers(int[] nums, int[] expected)
        {
            var result = FilterEvenNumbers(nums);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 2: Filter Strings By Length
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Filter Strings By Length (Easy)                               ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк и число minLength.                              ║
        ║ Верните только строки длиной >= minLength.                       ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["cat", "elephant", "dog", "hippopotamus"]     ║
        ║           minLength = 4                                          ║
        ║   Output: ["elephant", "hippopotamus"]                           ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["a", "ab", "abc", "abcd"]                     ║
        ║           minLength = 3                                          ║
        ║   Output: ["abc", "abcd"]                                        ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["hello", "world"]                             ║
        ║           minLength = 10                                         ║
        ║   Output: []                                                     ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 0 <= words.length <= 1000                                    ║
        ║   • 1 <= minLength <= 100                                        ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public string[] FilterStringsByLength(string[] words, int minLength)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "cat", "elephant", "dog", "hippopotamus" }, 4, new[] { "elephant", "hippopotamus" })]
        [TestCase(new[] { "a", "ab", "abc", "abcd" }, 3, new[] { "abc", "abcd" })]
        [TestCase(new[] { "hello", "world" }, 10, new string[] { })]
        public void Test_FilterStringsByLength(string[] words, int minLength, string[] expected)
        {
            var result = FilterStringsByLength(words, minLength);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: Filter Numbers In Range
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Filter Numbers In Range (Medium)                              ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел и диапазон [min, max].                          ║
        ║ Верните числа в диапазоне, которые делятся на 3.                 ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 3, 5, 6, 9, 12, 15, 20]                     ║
        ║           min = 5, max = 15                                      ║
        ║   Output: [6, 9, 12, 15]                                         ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [1, 2, 4, 5, 7, 8]                              ║
        ║           min = 1, max = 10                                      ║
        ║   Output: []                                                     ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [3, 6, 9, 12]                                   ║
        ║           min = 0, max = 100                                     ║
        ║   Output: [3, 6, 9, 12]                                          ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 0 <= nums.length <= 1000                                     ║
        ║   • min <= max                                                   ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[] FilterNumbersInRange(int[] nums, int min, int max)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 3, 5, 6, 9, 12, 15, 20 }, 5, 15, new[] { 6, 9, 12, 15 })]
        [TestCase(new[] { 1, 2, 4, 5, 7, 8 }, 1, 10, new int[] { })]
        [TestCase(new[] { 3, 6, 9, 12 }, 0, 100, new[] { 3, 6, 9, 12 })]
        public void Test_FilterNumbersInRange(int[] nums, int min, int max, int[] expected)
        {
            var result = FilterNumbersInRange(nums, min, max);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

