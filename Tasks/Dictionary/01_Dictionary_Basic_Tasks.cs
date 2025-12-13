using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Tasks.Dictionary
{
    /// <summary>
    /// ЗАДАЧИ НА DICTIONARY — базовые операции
    /// </summary>
    public class Dictionary_Basic_Tasks
    {
        #region Задача 1: Word Frequency Counter
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Word Frequency Counter (Easy)                                 ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив слов. Верните Dictionary с частотой каждого слова.    ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["apple", "banana", "apple", "cherry", "apple"]║
        ║   Output: { "apple": 3, "banana": 1, "cherry": 1 }               ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["a", "a", "a"]                                ║
        ║   Output: { "a": 3 }                                             ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["one"]                                        ║
        ║   Output: { "one": 1 }                                           ║
        ║                                                                  ║
        ║ Hint: GetValueOrDefault или TryGetValue                          ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 1000                                    ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public Dictionary<string, int> WordFrequencyCounter(string[] words)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_WordFrequencyCounter_1()
        {
            var words = new[] { "apple", "banana", "apple", "cherry", "apple" };
            var result = WordFrequencyCounter(words);
            
            Assert.That(result["apple"], Is.EqualTo(3));
            Assert.That(result["banana"], Is.EqualTo(1));
            Assert.That(result["cherry"], Is.EqualTo(1));
        }

        [Test]
        public void Test_WordFrequencyCounter_2()
        {
            var words = new[] { "a", "a", "a" };
            var result = WordFrequencyCounter(words);
            
            Assert.That(result["a"], Is.EqualTo(3));
            Assert.That(result.Count, Is.EqualTo(1));
        }
        #endregion

        #region Задача 2: Two Sum
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Two Sum (Easy) — LeetCode #1                                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел и целевая сумма target.                         ║
        ║ Найдите индексы двух чисел, сумма которых равна target.          ║
        ║ Гарантируется ровно одно решение.                                ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [2, 7, 11, 15], target = 9                      ║
        ║   Output: [0, 1]                                                 ║
        ║   Explanation: nums[0] + nums[1] = 2 + 7 = 9                     ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [3, 2, 4], target = 6                           ║
        ║   Output: [1, 2]                                                 ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [3, 3], target = 6                              ║
        ║   Output: [0, 1]                                                 ║
        ║                                                                  ║
        ║ Hint: Dictionary<int, int> для хранения value -> index           ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 2 <= nums.length <= 10^4                                     ║
        ║   • Exactly one valid answer exists                              ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[] TwoSum(int[] nums, int target)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [TestCase(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [TestCase(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        public void Test_TwoSum(int[] nums, int target, int[] expected)
        {
            var result = TwoSum(nums, target);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: First Unique Character
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. First Unique Character (Easy) — LeetCode #387                 ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дана строка. Верните индекс первого неповторяющегося символа.    ║
        ║ Если такого нет — верните -1.                                    ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  s = "leetcode"                                         ║
        ║   Output: 0                                                      ║
        ║   Explanation: 'l' встречается один раз и стоит первой           ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  s = "loveleetcode"                                     ║
        ║   Output: 2                                                      ║
        ║   Explanation: 'v' — первый уникальный символ (индекс 2)         ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  s = "aabb"                                             ║
        ║   Output: -1                                                     ║
        ║                                                                  ║
        ║ Hint: Два прохода — сначала считаем частоту, потом ищем первый   ║
        ║       с частотой 1                                               ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= s.length <= 10^5                                        ║
        ║   • s contains only lowercase letters                            ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int FirstUniqueCharacter(string s)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase("leetcode", 0)]
        [TestCase("loveleetcode", 2)]
        [TestCase("aabb", -1)]
        public void Test_FirstUniqueCharacter(string s, int expected)
        {
            var result = FirstUniqueCharacter(s);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

