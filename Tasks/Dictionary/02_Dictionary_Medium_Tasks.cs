using System;
using System.Collections.Generic;
using System.Linq;
using Allure.NUnit;
using NUnit.Framework;

namespace LeetCode.Tasks.Dictionary
{
    /// <summary>
    /// ЗАДАЧИ НА DICTIONARY — средний уровень
    /// </summary>
    [AllureNUnit]
    public class Dictionary_Medium_Tasks
    {
        #region Задача 1: Group Anagrams
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Group Anagrams (Medium) — LeetCode #49                        ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк. Сгруппируйте анаграммы вместе.                 ║
        ║ Анаграммы — слова из одинаковых букв (eat, tea, ate).            ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  strs = ["eat","tea","tan","ate","nat","bat"]           ║
        ║   Output: [["bat"],["nat","tan"],["ate","eat","tea"]]            ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  strs = [""]                                            ║
        ║   Output: [[""]]                                                 ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  strs = ["a"]                                           ║
        ║   Output: [["a"]]                                                ║
        ║                                                                  ║
        ║ Hint: Отсортированная строка как ключ — "eat" → "aet"            ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= strs.length <= 10^4                                     ║
        ║   • strs[i] contains only lowercase letters                      ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_GroupAnagrams_1()
        {
            var strs = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var result = GroupAnagrams(strs);
            
            Assert.That(result.Count, Is.EqualTo(3));
            
            // Проверяем что все анаграммы вместе
            var flattened = result.SelectMany(g => g).OrderBy(s => s).ToList();
            Assert.That(flattened, Is.EquivalentTo(strs));
        }

        [Test]
        public void Test_GroupAnagrams_2()
        {
            var strs = new[] { "" };
            var result = GroupAnagrams(strs);
            
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Contains.Item(""));
        }

        [Test]
        public void Test_GroupAnagrams_3()
        {
            var strs = new[] { "a" };
            var result = GroupAnagrams(strs);
            
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Contains.Item("a"));
        }
        #endregion

        #region Задача 2: Longest Consecutive Sequence
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Longest Consecutive Sequence (Medium) — LeetCode #128         ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан несортированный массив чисел. Найдите длину самой длинной    ║
        ║ последовательности подряд идущих чисел.                          ║
        ║ Алгоритм должен работать за O(n).                                ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [100, 4, 200, 1, 3, 2]                          ║
        ║   Output: 4                                                      ║
        ║   Explanation: Последовательность [1, 2, 3, 4], длина 4          ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [0, 3, 7, 2, 5, 8, 4, 6, 0, 1]                  ║
        ║   Output: 9                                                      ║
        ║   Explanation: [0, 1, 2, 3, 4, 5, 6, 7, 8]                       ║
        ║                                                                  ║
        ║ Hint: HashSet для O(1) проверки. Начинаем счёт только если       ║
        ║       num-1 нет в сете (начало последовательности).              ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 0 <= nums.length <= 10^5                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int LongestConsecutive(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 100, 4, 200, 1, 3, 2 }, 4)]
        [TestCase(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new[] { 1 }, 1)]
        public void Test_LongestConsecutive(int[] nums, int expected)
        {
            var result = LongestConsecutive(nums);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: Subarray Sum Equals K
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Subarray Sum Equals K (Medium) — LeetCode #560                ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив целых чисел и число k.                                ║
        ║ Найдите количество подмассивов с суммой равной k.                ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 1, 1], k = 2                                ║
        ║   Output: 2                                                      ║
        ║   Explanation: [1,1] (индексы 0-1) и [1,1] (индексы 1-2)         ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [1, 2, 3], k = 3                                ║
        ║   Output: 2                                                      ║
        ║   Explanation: [1,2] и [3]                                       ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [1, -1, 0], k = 0                               ║
        ║   Output: 3                                                      ║
        ║   Explanation: [1,-1], [-1,0], [1,-1,0]... и [0]                 ║
        ║                                                                  ║
        ║ Hint: Prefix sum + Dictionary<prefixSum, count>                  ║
        ║       Если prefixSum[j] - prefixSum[i] = k, то сумма [i+1..j]=k  ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 2 * 10^4                                 ║
        ║   • -1000 <= nums[i] <= 1000                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int SubarraySum(int[] nums, int k)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 1, 1 }, 2, 2)]
        [TestCase(new[] { 1, 2, 3 }, 3, 2)]
        [TestCase(new[] { 1 }, 1, 1)]
        public void Test_SubarraySum(int[] nums, int k, int expected)
        {
            var result = SubarraySum(nums, k);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

