using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА AGGREGATE — свёртка (reduce)
    /// </summary>
    public class Aggregate_Tasks
    {
        #region Задача 1: Product Of All Numbers
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Product Of All Numbers (Easy)                                 ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел. Верните произведение всех чисел.               ║
        ║ Используйте Aggregate.                                           ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 2, 3, 4]                                    ║
        ║   Output: 24                                                     ║
        ║   Explanation: 1 * 2 * 3 * 4 = 24                                ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [5, 5]                                          ║
        ║   Output: 25                                                     ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [10]                                            ║
        ║   Output: 10                                                     ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 20                                       ║
        ║   • 1 <= nums[i] <= 100                                          ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public long ProductOfAllNumbers(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 4 }, 24)]
        [TestCase(new[] { 5, 5 }, 25)]
        [TestCase(new[] { 10 }, 10)]
        public void Test_ProductOfAllNumbers(int[] nums, long expected)
        {
            var result = ProductOfAllNumbers(nums);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 2: Join With Separator
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Join With Separator (Easy)                                    ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк и разделитель. Объедините в одну строку.        ║
        ║ Используйте Aggregate (не string.Join!).                         ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["a", "b", "c"], separator = "-"               ║
        ║   Output: "a-b-c"                                                ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["hello", "world"], separator = " "            ║
        ║   Output: "hello world"                                          ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["one"], separator = ","                       ║
        ║   Output: "one"                                                  ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 100                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public string JoinWithSeparator(string[] words, string separator)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "a", "b", "c" }, "-", "a-b-c")]
        [TestCase(new[] { "hello", "world" }, " ", "hello world")]
        [TestCase(new[] { "one" }, ",", "one")]
        public void Test_JoinWithSeparator(string[] words, string separator, string expected)
        {
            var result = JoinWithSeparator(words, separator);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: Find Longest String
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Find Longest String (Medium)                                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк. Найдите самую длинную строку.                  ║
        ║ Используйте Aggregate (не Max/MaxBy!).                           ║
        ║ Если несколько строк одинаковой длины — верните первую.          ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["cat", "elephant", "dog"]                     ║
        ║   Output: "elephant"                                             ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["ab", "cd", "ef"]                             ║
        ║   Output: "ab"                                                   ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["supercalifragilistic"]                       ║
        ║   Output: "supercalifragilistic"                                 ║
        ║                                                                  ║
        ║ Hint: Aggregate((longest, current) => ...)                       ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 1000                                    ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public string FindLongestString(string[] words)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "cat", "elephant", "dog" }, "elephant")]
        [TestCase(new[] { "ab", "cd", "ef" }, "ab")]
        [TestCase(new[] { "supercalifragilistic" }, "supercalifragilistic")]
        public void Test_FindLongestString(string[] words, string expected)
        {
            var result = FindLongestString(words);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

