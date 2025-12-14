using System;
using System.Collections.Generic;
using System.Linq;
using Allure.NUnit;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА ANY / ALL — проверка условий
    /// </summary>
    [AllureNUnit]
    public class AnyAll_Tasks
    {
        #region Задача 1: Contains Negative
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Contains Negative (Easy)                                      ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел. Проверьте, есть ли хотя бы одно отрицательное. ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, -2, 3, 4]                                   ║
        ║   Output: true                                                   ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [1, 2, 3, 4]                                    ║
        ║   Output: false                                                  ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums = [-1]                                            ║
        ║   Output: true                                                   ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.length <= 1000                                     ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public bool ContainsNegative(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, -2, 3, 4 }, true)]
        [TestCase(new[] { 1, 2, 3, 4 }, false)]
        [TestCase(new[] { -1 }, true)]
        public void Test_ContainsNegative(int[] nums, bool expected)
        {
            var result = ContainsNegative(nums);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 2: All Strings Start With Uppercase
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. All Strings Start With Uppercase (Easy)                       ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк. Проверьте, что ВСЕ строки начинаются           ║
        ║ с заглавной буквы.                                               ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["Hello", "World", "Test"]                     ║
        ║   Output: true                                                   ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["Hello", "world"]                             ║
        ║   Output: false                                                  ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["ABC"]                                        ║
        ║   Output: true                                                   ║
        ║                                                                  ║
        ║ Hint: char.IsUpper()                                             ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 1000                                    ║
        ║   • words[i] is non-empty                                        ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public bool AllStringsStartWithUppercase(string[] words)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "Hello", "World", "Test" }, true)]
        [TestCase(new[] { "Hello", "world" }, false)]
        [TestCase(new[] { "ABC" }, true)]
        public void Test_AllStringsStartWithUppercase(string[] words, bool expected)
        {
            var result = AllStringsStartWithUppercase(words);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: Has Common Elements
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Has Common Elements (Medium)                                  ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Даны два массива чисел. Проверьте, есть ли общие элементы.       ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums1 = [1, 2, 3], nums2 = [3, 4, 5]                   ║
        ║   Output: true (общий элемент: 3)                                ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums1 = [1, 2], nums2 = [3, 4]                         ║
        ║   Output: false                                                  ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  nums1 = [5, 5, 5], nums2 = [5]                         ║
        ║   Output: true                                                   ║
        ║                                                                  ║
        ║ Hint: Any + Contains или Intersect + Any                         ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums1.length, nums2.length <= 1000                      ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public bool HasCommonElements(int[] nums1, int[] nums2)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 4, 5 }, true)]
        [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, false)]
        [TestCase(new[] { 5, 5, 5 }, new[] { 5 }, true)]
        public void Test_HasCommonElements(int[] nums1, int[] nums2, bool expected)
        {
            var result = HasCommonElements(nums1, nums2);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

