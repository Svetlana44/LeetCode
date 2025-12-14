using System;
using System.Collections.Generic;
using System.Linq;
using Allure.NUnit;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА ORDERBY — сортировка
    /// </summary>
    [AllureNUnit]
    public class OrderBy_Tasks
    {
        #region Задача 1: Sort By Absolute Value
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Sort By Absolute Value (Easy)                                 ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел. Отсортируйте по модулю (абсолютному значению). ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [-5, 2, -1, 3, -4]                              ║
        ║   Output: [-1, 2, 3, -4, -5]                                     ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [10, -10, 5, -5]                                ║
        ║   Output: [5, -5, 10, -10]                                       ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [1, 2, 3]                                       ║
        ║   Output: [1, 2, 3]                                              ║
        ║                                                                  ║
        ║ Hint: Math.Abs()                                                 ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 1000                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[] SortByAbsoluteValue(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { -5, 2, -1, 3, -4 }, new[] { -1, 2, 3, -4, -5 })]
        [TestCase(new[] { 10, -10, 5, -5 }, new[] { 5, -5, 10, -10 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        public void Test_SortByAbsoluteValue(int[] nums, int[] expected)
        {
            var result = SortByAbsoluteValue(nums);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 2: Sort Strings By Length Then Alphabetically
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Sort Strings By Length Then Alphabetically (Medium)           ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк. Отсортируйте:                                  ║
        ║   1) Сначала по длине (короткие первые)                          ║
        ║   2) При равной длине — по алфавиту                              ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["banana", "apple", "pie", "fig"]              ║
        ║   Output: ["fig", "pie", "apple", "banana"]                      ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["cat", "bat", "ant"]                          ║
        ║   Output: ["ant", "bat", "cat"]                                  ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["z", "a", "bb", "aa"]                         ║
        ║   Output: ["a", "z", "aa", "bb"]                                 ║
        ║                                                                  ║
        ║ Hint: OrderBy + ThenBy                                           ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 1000                                    ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public string[] SortStringsByLengthThenAlphabetically(string[] words)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "banana", "apple", "pie", "fig" }, new[] { "fig", "pie", "apple", "banana" })]
        [TestCase(new[] { "cat", "bat", "ant" }, new[] { "ant", "bat", "cat" })]
        [TestCase(new[] { "z", "a", "bb", "aa" }, new[] { "a", "z", "aa", "bb" })]
        public void Test_SortStringsByLengthThenAlphabetically(string[] words, string[] expected)
        {
            var result = SortStringsByLengthThenAlphabetically(words);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: Sort By Last Character Descending
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Sort By Last Character Descending (Medium)                    ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк. Отсортируйте по последнему символу             ║
        ║ в обратном алфавитном порядке (z → a).                           ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["hello", "world", "code"]                     ║
        ║   Output: ["hello", "code", "world"]                             ║
        ║   Explanation: 'o' > 'e' > 'd'                                   ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["az", "by", "cx"]                             ║
        ║   Output: ["az", "by", "cx"]                                     ║
        ║   Explanation: 'z' > 'y' > 'x'                                   ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["a", "b", "c"]                                ║
        ║   Output: ["c", "b", "a"]                                        ║
        ║                                                                  ║
        ║ Hint: OrderByDescending + Last()                                 ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 1000                                    ║
        ║   • words[i] is non-empty                                        ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public string[] SortByLastCharacterDescending(string[] words)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "hello", "world", "code" }, new[] { "hello", "code", "world" })]
        [TestCase(new[] { "az", "by", "cx" }, new[] { "az", "by", "cx" })]
        [TestCase(new[] { "a", "b", "c" }, new[] { "c", "b", "a" })]
        public void Test_SortByLastCharacterDescending(string[] words, string[] expected)
        {
            var result = SortByLastCharacterDescending(words);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

