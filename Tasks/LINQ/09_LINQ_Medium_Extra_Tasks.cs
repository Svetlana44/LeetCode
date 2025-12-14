using System;
using System.Collections.Generic;
using System.Linq;
using Allure.NUnit;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ДОПОЛНИТЕЛЬНЫЕ MEDIUM ЗАДАЧИ НА LINQ
    /// </summary>
    [AllureNUnit]
    public class LINQ_Medium_Extra_Tasks
    {
        #region Задача 1: Top K Frequent Elements
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Top K Frequent Elements (Medium) — LeetCode #347              ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел и число k.                                      ║
        ║ Верните k самых часто встречающихся элементов.                   ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1,1,1,2,2,3], k = 2                            ║
        ║   Output: [1, 2]                                                 ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [1], k = 1                                      ║
        ║   Output: [1]                                                    ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [4,4,4,1,1,2,2,2,3], k = 2                      ║
        ║   Output: [4, 2]  (или [2, 4] — порядок не важен)                ║
        ║                                                                  ║
        ║ Hint: GroupBy + OrderByDescending + Take                         ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 10^5                                     ║
        ║   • k is always valid                                            ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[] TopKFrequent(int[] nums, int k)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_TopKFrequent_1()
        {
            var nums = new[] { 1, 1, 1, 2, 2, 3 };
            var result = TopKFrequent(nums, 2);
            Assert.That(result, Is.EquivalentTo(new[] { 1, 2 }));
        }

        [Test]
        public void Test_TopKFrequent_2()
        {
            var nums = new[] { 1 };
            var result = TopKFrequent(nums, 1);
            Assert.That(result, Is.EqualTo(new[] { 1 }));
        }

        [Test]
        public void Test_TopKFrequent_3()
        {
            var nums = new[] { 4, 4, 4, 1, 1, 2, 2, 2, 3 };
            var result = TopKFrequent(nums, 2);
            Assert.That(result, Is.EquivalentTo(new[] { 4, 2 }));
        }
        #endregion

        #region Задача 2: Intersection of Two Arrays II
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Intersection of Two Arrays II (Easy) — LeetCode #350          ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Даны два массива. Верните их пересечение.                        ║
        ║ Каждый элемент в результате должен появляться столько раз,       ║
        ║ сколько он появляется в обоих массивах.                          ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums1 = [1,2,2,1], nums2 = [2,2]                       ║
        ║   Output: [2, 2]                                                 ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums1 = [4,9,5], nums2 = [9,4,9,8,4]                   ║
        ║   Output: [4, 9] или [9, 4]                                      ║
        ║                                                                  ║
        ║ Hint: GroupBy обоих массивов, потом Join или сравнение           ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums1.length, nums2.length <= 1000                      ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_Intersect_1()
        {
            var result = Intersect(new[] { 1, 2, 2, 1 }, new[] { 2, 2 });
            Assert.That(result.OrderBy(x => x), Is.EqualTo(new[] { 2, 2 }));
        }

        [Test]
        public void Test_Intersect_2()
        {
            var result = Intersect(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 });
            Assert.That(result.OrderBy(x => x), Is.EqualTo(new[] { 4, 9 }));
        }
        #endregion

        #region Задача 3: Find All Duplicates
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Find All Duplicates (Medium) — LeetCode #442                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив из n чисел, где все числа в диапазоне [1, n].         ║
        ║ Некоторые числа появляются дважды, некоторые — один раз.         ║
        ║ Найдите все числа, которые появляются дважды.                    ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [4,3,2,7,8,2,3,1]                               ║
        ║   Output: [2, 3]                                                 ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [1,1,2]                                         ║
        ║   Output: [1]                                                    ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [1]                                             ║
        ║   Output: []                                                     ║
        ║                                                                  ║
        ║ Hint: GroupBy + Where(count == 2)                                ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • n == nums.length                                             ║
        ║   • 1 <= n <= 10^5                                               ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public IList<int> FindDuplicates(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new[] { 2, 3 })]
        [TestCase(new[] { 1, 1, 2 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new int[] { })]
        public void Test_FindDuplicates(int[] nums, int[] expected)
        {
            var result = FindDuplicates(nums);
            Assert.That(result.OrderBy(x => x), Is.EqualTo(expected.OrderBy(x => x)));
        }
        #endregion

        #region Задача 4: Kth Largest Element
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 4. Kth Largest Element (Medium) — LeetCode #215                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел и число k.                                      ║
        ║ Верните k-й по величине элемент (не k-й уникальный).             ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [3,2,1,5,6,4], k = 2                            ║
        ║   Output: 5                                                      ║
        ║   Explanation: Отсортированный: [6,5,4,3,2,1], 2-й = 5           ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [3,2,3,1,2,4,5,5,6], k = 4                      ║
        ║   Output: 4                                                      ║
        ║   Explanation: [6,5,5,4,3,3,2,2,1], 4-й = 4                      ║
        ║                                                                  ║
        ║ Hint: OrderByDescending + Skip + First (или ElementAt)           ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= k <= nums.length <= 10^5                                ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int FindKthLargest(int[] nums, int k)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
        [TestCase(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
        [TestCase(new[] { 1 }, 1, 1)]
        public void Test_FindKthLargest(int[] nums, int k, int expected)
        {
            var result = FindKthLargest(nums, k);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 5: Product of Array Except Self
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 5. Product of Array Except Self (Medium) — LeetCode #238         ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив nums. Верните массив result, где result[i] равен      ║
        ║ произведению всех элементов кроме nums[i].                       ║
        ║ Нельзя использовать деление!                                     ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1,2,3,4]                                       ║
        ║   Output: [24,12,8,6]                                            ║
        ║   Explanation: [2*3*4, 1*3*4, 1*2*4, 1*2*3]                      ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [-1,1,0,-3,3]                                   ║
        ║   Output: [0,0,9,0,0]                                            ║
        ║                                                                  ║
        ║ Hint: Два прохода — prefix и suffix products                     ║
        ║       Или: Select с индексом, Where исключает текущий            ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 2 <= nums.length <= 10^5                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[] ProductExceptSelf(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 24, 12, 8, 6 })]
        [TestCase(new[] { -1, 1, 0, -3, 3 }, new[] { 0, 0, 9, 0, 0 })]
        public void Test_ProductExceptSelf(int[] nums, int[] expected)
        {
            var result = ProductExceptSelf(nums);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 6: Merge Intervals
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 6. Merge Intervals (Medium) — LeetCode #56                       ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив интервалов intervals[i] = [start, end].               ║
        ║ Объедините все пересекающиеся интервалы.                         ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  intervals = [[1,3],[2,6],[8,10],[15,18]]               ║
        ║   Output: [[1,6],[8,10],[15,18]]                                 ║
        ║   Explanation: [1,3] и [2,6] пересекаются → [1,6]                ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  intervals = [[1,4],[4,5]]                              ║
        ║   Output: [[1,5]]                                                ║
        ║                                                                  ║
        ║ Hint: OrderBy start, потом Aggregate или цикл                    ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= intervals.length <= 10^4                                ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public int[][] MergeIntervals(int[][] intervals)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_MergeIntervals_1()
        {
            var intervals = new[] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } };
            var expected = new[] { new[] { 1, 6 }, new[] { 8, 10 }, new[] { 15, 18 } };
            var result = MergeIntervals(intervals);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test_MergeIntervals_2()
        {
            var intervals = new[] { new[] { 1, 4 }, new[] { 4, 5 } };
            var expected = new[] { new[] { 1, 5 } };
            var result = MergeIntervals(intervals);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 7: Majority Element II
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 7. Majority Element II (Medium) — LeetCode #229                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив размера n. Найдите все элементы, которые              ║
        ║ появляются более ⌊n/3⌋ раз.                                      ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [3,2,3]                                         ║
        ║   Output: [3]                                                    ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [1]                                             ║
        ║   Output: [1]                                                    ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [1,2]                                           ║
        ║   Output: [1, 2]                                                 ║
        ║                                                                  ║
        ║ Hint: GroupBy + Where(count > n/3)                               ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 5 * 10^4                                 ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public IList<int> MajorityElement(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 3, 2, 3 }, new[] { 3 })]
        [TestCase(new[] { 1 }, new[] { 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 2 })]
        public void Test_MajorityElement(int[] nums, int[] expected)
        {
            var result = MajorityElement(nums);
            Assert.That(result.OrderBy(x => x), Is.EqualTo(expected.OrderBy(x => x)));
        }
        #endregion

        #region Задача 8: Find Disappeared Numbers
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 8. Find Disappeared Numbers (Easy) — LeetCode #448               ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив n чисел, где nums[i] в диапазоне [1, n].              ║
        ║ Найдите все числа от 1 до n, которых нет в массиве.              ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [4,3,2,7,8,2,3,1]                               ║
        ║   Output: [5, 6]                                                 ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [1,1]                                           ║
        ║   Output: [2]                                                    ║
        ║                                                                  ║
        ║ Hint: Enumerable.Range(1, n).Except(nums)                        ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • n == nums.length                                             ║
        ║   • 1 <= n <= 10^5                                               ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new[] { 5, 6 })]
        [TestCase(new[] { 1, 1 }, new[] { 2 })]
        public void Test_FindDisappearedNumbers(int[] nums, int[] expected)
        {
            var result = FindDisappearedNumbers(nums);
            Assert.That(result.OrderBy(x => x), Is.EqualTo(expected));
        }
        #endregion

        #region Задача 9: Sort Characters By Frequency
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 9. Sort Characters By Frequency (Medium) — LeetCode #451         ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дана строка. Отсортируйте символы по убыванию частоты.           ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  s = "tree"                                             ║
        ║   Output: "eert" или "eetr"                                      ║
        ║   Explanation: 'e' появляется 2 раза, 't' и 'r' по 1 разу        ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  s = "cccaaa"                                           ║
        ║   Output: "aaaccc" или "cccaaa"                                  ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  s = "Aabb"                                             ║
        ║   Output: "bbAa" или "bbaA"                                      ║
        ║                                                                  ║
        ║ Hint: GroupBy + OrderByDescending + SelectMany                   ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= s.length <= 5 * 10^5                                    ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public string FrequencySort(string s)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_FrequencySort_1()
        {
            var result = FrequencySort("tree");
            // 'e' должна быть первой (2 раза)
            Assert.That(result.Count(c => c == 'e'), Is.EqualTo(2));
            Assert.That(result.Substring(0, 2), Is.EqualTo("ee"));
        }

        [Test]
        public void Test_FrequencySort_2()
        {
            var result = FrequencySort("cccaaa");
            Assert.That(result.Length, Is.EqualTo(6));
            // Первые 3 символа должны быть одинаковыми
            Assert.That(result[0], Is.EqualTo(result[1]));
            Assert.That(result[1], Is.EqualTo(result[2]));
        }
        #endregion

        #region Задача 10: Partition Labels
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 10. Partition Labels (Medium) — LeetCode #763                    ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дана строка s. Разбейте её на как можно больше частей так,       ║
        ║ чтобы каждая буква появлялась только в одной части.              ║
        ║ Верните список размеров этих частей.                             ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  s = "ababcbacadefegdehijhklij"                         ║
        ║   Output: [9, 7, 8]                                              ║
        ║   Explanation: "ababcbaca" | "defegde" | "hijhklij"              ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  s = "eccbbbbdec"                                       ║
        ║   Output: [10]                                                   ║
        ║                                                                  ║
        ║ Hint: Сначала найти последнее вхождение каждого символа          ║
        ║       Select с индексом для создания пар (char, lastIndex)       ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= s.length <= 500                                         ║
        ║   • s contains only lowercase letters                            ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public IList<int> PartitionLabels(string s)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase("ababcbacadefegdehijhklij", new[] { 9, 7, 8 })]
        [TestCase("eccbbbbdec", new[] { 10 })]
        public void Test_PartitionLabels(string s, int[] expected)
        {
            var result = PartitionLabels(s);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

