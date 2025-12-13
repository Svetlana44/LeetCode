using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА GROUPBY — группировка
    /// </summary>
    public class GroupBy_Tasks
    {
        #region Задача 1: Group By First Letter
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Group By First Letter (Easy)                                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив слов. Сгруппируйте по первой букве.                   ║
        ║ Верните Dictionary<char, List<string>>.                          ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["apple", "ant", "banana", "cherry", "cat"]    ║
        ║   Output: {                                                      ║
        ║     'a': ["apple", "ant"],                                       ║
        ║     'b': ["banana"],                                             ║
        ║     'c': ["cherry", "cat"]                                       ║
        ║   }                                                              ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["one"]                                        ║
        ║   Output: { 'o': ["one"] }                                       ║
        ║                                                                  ║
        ║ Hint: GroupBy + ToDictionary                                     ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 1000                                    ║
        ║   • All words start with lowercase letter                        ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public Dictionary<char, List<string>> GroupByFirstLetter(string[] words)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_GroupByFirstLetter_1()
        {
            var words = new[] { "apple", "ant", "banana", "cherry", "cat" };
            var result = GroupByFirstLetter(words);
            
            Assert.That(result['a'], Is.EqualTo(new[] { "apple", "ant" }));
            Assert.That(result['b'], Is.EqualTo(new[] { "banana" }));
            Assert.That(result['c'], Is.EqualTo(new[] { "cherry", "cat" }));
        }

        [Test]
        public void Test_GroupByFirstLetter_2()
        {
            var words = new[] { "one" };
            var result = GroupByFirstLetter(words);
            
            Assert.That(result['o'], Is.EqualTo(new[] { "one" }));
            Assert.That(result.Count, Is.EqualTo(1));
        }
        #endregion

        #region Задача 2: Count By Length
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Count By Length (Medium)                                      ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив слов. Верните Dictionary, где:                        ║
        ║   - Ключ: длина слова                                            ║
        ║   - Значение: количество слов такой длины                        ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["cat", "dog", "elephant", "rat", "lion"]      ║
        ║   Output: { 3: 3, 8: 1, 4: 1 }                                   ║
        ║   Explanation: 3 слова длины 3, 1 слово длины 8, 1 слово длины 4 ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["a", "bb", "ccc", "dd"]                       ║
        ║   Output: { 1: 1, 2: 2, 3: 1 }                                   ║
        ║                                                                  ║
        ║ Hint: GroupBy + ToDictionary + Count()                           ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 1000                                    ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public Dictionary<int, int> CountByLength(string[] words)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_CountByLength_1()
        {
            var words = new[] { "cat", "dog", "elephant", "rat", "lion" };
            var result = CountByLength(words);
            
            Assert.That(result[3], Is.EqualTo(3));
            Assert.That(result[8], Is.EqualTo(1));
            Assert.That(result[4], Is.EqualTo(1));
        }

        [Test]
        public void Test_CountByLength_2()
        {
            var words = new[] { "a", "bb", "ccc", "dd" };
            var result = CountByLength(words);
            
            Assert.That(result[1], Is.EqualTo(1));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(1));
        }
        #endregion

        #region Задача 3: Group Numbers By Remainder
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Group Numbers By Remainder (Medium)                           ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел и делитель. Сгруппируйте по остатку от деления. ║
        ║ Верните массив массивов, отсортированный по ключу (остатку).     ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 2, 3, 4, 5, 6], divisor = 3                 ║
        ║   Output: [[3, 6], [1, 4], [2, 5]]                               ║
        ║   Explanation:                                                   ║
        ║     остаток 0: [3, 6]                                            ║
        ║     остаток 1: [1, 4]                                            ║
        ║     остаток 2: [2, 5]                                            ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [10, 20, 30], divisor = 10                      ║
        ║   Output: [[10, 20, 30]]                                         ║
        ║   Explanation: все числа дают остаток 0                          ║
        ║                                                                  ║
        ║ Hint: GroupBy + OrderBy(g => g.Key) + Select(g => g.ToArray())   ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 1000                                     ║
        ║   • divisor > 0                                                  ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[][] GroupNumbersByRemainder(int[] nums, int divisor)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_GroupNumbersByRemainder_1()
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6 };
            var result = GroupNumbersByRemainder(nums, 3);
            
            Assert.That(result[0], Is.EqualTo(new[] { 3, 6 }));
            Assert.That(result[1], Is.EqualTo(new[] { 1, 4 }));
            Assert.That(result[2], Is.EqualTo(new[] { 2, 5 }));
        }

        [Test]
        public void Test_GroupNumbersByRemainder_2()
        {
            var nums = new[] { 10, 20, 30 };
            var result = GroupNumbersByRemainder(nums, 10);
            
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(new[] { 10, 20, 30 }));
        }
        #endregion
    }
}

