using System;
using System.Collections.Generic;
using System.Linq;
using Allure.NUnit;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА SELECTMANY — развёртка вложенных коллекций (flatMap)
    /// </summary>
    [AllureNUnit]
    public class SelectMany_Tasks
    {
        #region Задача 1: Flatten 2D Array
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Flatten 2D Array (Easy)                                       ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан двумерный массив. Верните одномерный массив всех элементов.  ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  matrix = [[1, 2], [3, 4], [5, 6]]                      ║
        ║   Output: [1, 2, 3, 4, 5, 6]                                     ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  matrix = [[1], [2], [3]]                               ║
        ║   Output: [1, 2, 3]                                              ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  matrix = [[1, 2, 3, 4, 5]]                             ║
        ║   Output: [1, 2, 3, 4, 5]                                        ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= matrix.length <= 100                                    ║
        ║   • 1 <= matrix[i].length <= 100                                 ║
        ╚══════════════════════════════════════════════════════════════════╝
        */

        public int[] Flatten2DArray(int[][] matrix)
        {
            // Твоё решение здесь
            return matrix.SelectMany(x => x.Select(y => y)).ToArray();

            throw new NotImplementedException();
        }

        [Test]
        public void Test_Flatten2DArray_1()
        {
            var matrix = new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 } };
            var expected = new[] { 1, 2, 3, 4, 5, 6 };
            Assert.That(Flatten2DArray(matrix), Is.EqualTo(expected));
        }

        [Test]
        public void Test_Flatten2DArray_2()
        {
            var matrix = new[] { new[] { 1 }, new[] { 2 }, new[] { 3 } };
            var expected = new[] { 1, 2, 3 };
            Assert.That(Flatten2DArray(matrix), Is.EqualTo(expected));
        }

        [Test]
        public void Test_Flatten2DArray_3()
        {
            var matrix = new[] { new[] { 1, 2, 3, 4, 5 } };
            var expected = new[] { 1, 2, 3, 4, 5 };
            Assert.That(Flatten2DArray(matrix), Is.EqualTo(expected));
        }
        #endregion

        #region Задача 2: Split And Flatten
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Split And Flatten (Medium)                                    ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк, каждая содержит слова через пробел.            ║
        ║ Верните массив всех отдельных слов.                              ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  sentences = ["hello world", "foo bar baz"]             ║
        ║   Output: ["hello", "world", "foo", "bar", "baz"]                ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  sentences = ["one", "two three", "four five six"]      ║
        ║   Output: ["one", "two", "three", "four", "five", "six"]         ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  sentences = ["single"]                                 ║
        ║   Output: ["single"]                                             ║
        ║                                                                  ║
        ║ Hint: string.Split(' ')                                          ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= sentences.length <= 100                                 ║
        ║   • Words are separated by single space                          ║
        ╚══════════════════════════════════════════════════════════════════╝
        */

        public string[] SplitAndFlatten(string[] sentences)
        {
            // Твоё решение здесь
            return sentences.SelectMany(str => str.Split(" ")).ToArray();


            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "hello world", "foo bar baz" }, new[] { "hello", "world", "foo", "bar", "baz" })]
        [TestCase(new[] { "one", "two three", "four five six" }, new[] { "one", "two", "three", "four", "five", "six" })]
        [TestCase(new[] { "single" }, new[] { "single" })]
        public void Test_SplitAndFlatten(string[] sentences, string[] expected)
        {
            var result = SplitAndFlatten(sentences);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Задача 3: Get All Characters
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Get All Characters (Medium)                                   ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив строк. Верните массив всех уникальных символов        ║
        ║ в алфавитном порядке (в нижнем регистре).                        ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  words = ["Hello", "World"]                             ║
        ║   Output: ['d', 'e', 'h', 'l', 'o', 'r', 'w']                    ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  words = ["AAA", "aaa"]                                 ║
        ║   Output: ['a']                                                  ║
        ║                                                                  ║
        ║ Example 3:                                                       ║
        ║   Input:  words = ["abc", "def"]                                 ║
        ║   Output: ['a', 'b', 'c', 'd', 'e', 'f']                         ║
        ║                                                                  ║
        ║ Hint: SelectMany + Distinct + OrderBy + ToLower                  ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= words.length <= 100                                     ║
        ║   • Only letters a-z, A-Z                                        ║
        ╚══════════════════════════════════════════════════════════════════╝
        */

        public char[] GetAllCharacters(string[] words)
        {
            // Твоё решение здесь
            return words.SelectMany(word => word.ToLower()
            .ToCharArray()) //конец SelectMany
            .OrderBy(c => c)
            .Distinct()
                .ToArray<char>();

            throw new NotImplementedException();
        }

        [Test]
        [TestCase(new[] { "Hello", "World" }, new[] { 'd', 'e', 'h', 'l', 'o', 'r', 'w' })]
        [TestCase(new[] { "AAA", "aaa" }, new[] { 'a' })]
        [TestCase(new[] { "abc", "def" }, new[] { 'a', 'b', 'c', 'd', 'e', 'f' })]
        public void Test_GetAllCharacters(string[] words, char[] expected)
        {
            var result = GetAllCharacters(words);
            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}

