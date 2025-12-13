using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА FIRST / SINGLE / FIRSTORDEFAULT / SINGLEORDEFAULT
    /// Критично знать разницу для собеседования!
    /// </summary>
    public class FirstSingle_Tasks
    {
        #region Задача 1: Find First Matching
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Find First Matching (Easy)                                    ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел и целевое значение target.                      ║
        ║ Верните первое число больше target.                              ║
        ║ Если такого нет — верните -1.                                    ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 5, 8, 3, 10], target = 6                    ║
        ║   Output: 8                                                      ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [1, 2, 3], target = 10                          ║
        ║   Output: -1                                                     ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [100, 200, 300], target = 0                     ║
        ║   Output: 100                                                    ║
        ║                                                                  ║
        ║ Hint: FirstOrDefault с проверкой (или Cast<int?>)                ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 1000                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int FindFirstGreaterThan(int[] nums, int target)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 5, 8, 3, 10 }, 6, 8)]
        [TestCase(new[] { 1, 2, 3 }, 10, -1)]
        [TestCase(new[] { 100, 200, 300 }, 0, 100)]
        public void Test_FindFirstGreaterThan(int[] nums, int target, int expected)
        {
            var result = FindFirstGreaterThan(nums, target);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 2: Find Unique Element
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Find Unique Element (Medium)                                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел, где одно число встречается ровно один раз,     ║
        ║ а все остальные — ровно два раза.                                ║
        ║ Найдите это уникальное число.                                    ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 2, 1, 3, 2]                                 ║
        ║   Output: 3                                                      ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [5, 5, 7]                                       ║
        ║   Output: 7                                                      ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [9]                                             ║
        ║   Output: 9                                                      ║
        ║                                                                  ║
        ║ Hint: GroupBy + Single (так как гарантированно есть РОВНО ОДИН)  ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 1000                                     ║
        ║   • Exactly one unique element exists                            ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int FindUniqueElement(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 2, 1, 3, 2 }, 3)]
        [TestCase(new[] { 5, 5, 7 }, 7)]
        [TestCase(new[] { 9 }, 9)]
        public void Test_FindUniqueElement(int[] nums, int expected)
        {
            var result = FindUniqueElement(nums);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: Safe Find Or Default
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Safe Find Or Default (Medium)                                 ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк и искомая строка search.                        ║
        ║ Верните строку если найдена РОВНО ОДНА такая.                    ║
        ║ Если не найдена ИЛИ найдено несколько — верните "NOT_FOUND".     ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["apple", "banana", "cherry"], search = "banana"║
        ║   Output: "banana"                                               ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["a", "a", "b"], search = "a"                  ║
        ║   Output: "NOT_FOUND" (найдено 2 элемента!)                      ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["x", "y", "z"], search = "w"                  ║
        ║   Output: "NOT_FOUND" (не найдено)                               ║
        ║                                                                  ║
        ║ Hint: SingleOrDefault бросает исключение если >1 элемент!        ║
        ║       Используй try-catch или проверь Count.                     ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 1000                                    ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public string SafeFindOrDefault(string[] words, string search)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "apple", "banana", "cherry" }, "banana", "banana")]
        [TestCase(new[] { "a", "a", "b" }, "a", "NOT_FOUND")]
        [TestCase(new[] { "x", "y", "z" }, "w", "NOT_FOUND")]
        public void Test_SafeFindOrDefault(string[] words, string search, string expected)
        {
            var result = SafeFindOrDefault(words, search);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

