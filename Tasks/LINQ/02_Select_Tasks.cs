using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА SELECT — преобразование элементов (map)
    /// </summary>
    public class Select_Tasks
    {
        #region Задача 1: Square All Numbers
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Square All Numbers (Easy)                                     ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив целых чисел. Верните массив их квадратов.             ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 2, 3, 4]                                    ║
        ║   Output: [1, 4, 9, 16]                                          ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [-2, -1, 0, 1, 2]                               ║
        ║   Output: [4, 1, 0, 1, 4]                                        ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [10]                                            ║
        ║   Output: [100]                                                  ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 1000                                     ║
        ║   • -100 <= nums[i] <= 100                                       ║
        ╚══════════════════════════════════════════════════════════════════╝
        */

        public int[] SquareAllNumbers(int[] nums)
        {
            // Твоё решение здесь
            return nums.Select(n => n * n).ToArray();

            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 4, 9, 16 })]
        [TestCase(new[] { -2, -1, 0, 1, 2 }, new[] { 4, 1, 0, 1, 4 })]
        [TestCase(new[] { 10 }, new[] { 100 })]
        public void Test_SquareAllNumbers(int[] nums, int[] expected)
        {
            var result = SquareAllNumbers(nums);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 2: Extract First Letters
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Extract First Letters (Easy)                                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив слов. Верните строку из первых букв каждого слова.    ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["Hello", "World"]                             ║
        ║   Output: "HW"                                                   ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["As", "Soon", "As", "Possible"]               ║
        ║   Output: "ASAP"                                                 ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["Test"]                                       ║
        ║   Output: "T"                                                    ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 100                                     ║
        ║   • words[i] is non-empty                                        ║
        ╚══════════════════════════════════════════════════════════════════╝
        */

        public string ExtractFirstLetters(string[] words)
        {
            // Твоё решение здесь
            return String.Concat(words.Select(w => w[0]));

            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "Hello", "World" }, "HW")]
        [TestCase(new[] { "As", "Soon", "As", "Possible" }, "ASAP")]
        [TestCase(new[] { "Test" }, "T")]
        public void Test_ExtractFirstLetters(string[] words, string expected)
        {
            var result = ExtractFirstLetters(words);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: Add Index To Each Element
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Add Index To Each Element (Medium)                            ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк. Верните массив строк в формате "index: value". ║
        ║ Используйте перегрузку Select с индексом.                        ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  items = ["apple", "banana", "cherry"]                  ║
        ║   Output: ["0: apple", "1: banana", "2: cherry"]                 ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  items = ["first"]                                      ║
        ║   Output: ["0: first"]                                           ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  items = ["a", "b", "c", "d"]                           ║
        ║   Output: ["0: a", "1: b", "2: c", "3: d"]                       ║
        ║                                                                  ║
        ║ Hint: Select((item, index) => ...)                               ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= items.length <= 100                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */

        public string[] AddIndexToEachElement(string[] items)
        {
            // Твоё решение здесь
            return items.Select((item, index) => $"{index}: {item}").ToArray();
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "apple", "banana", "cherry" }, new[] { "0: apple", "1: banana", "2: cherry" })]
        [TestCase(new[] { "first" }, new[] { "0: first" })]
        [TestCase(new[] { "a", "b", "c", "d" }, new[] { "0: a", "1: b", "2: c", "3: d" })]
        public void Test_AddIndexToEachElement(string[] items, string[] expected)
        {
            var result = AddIndexToEachElement(items);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

