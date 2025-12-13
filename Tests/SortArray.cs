using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeetCode.Tests
{
    public class SortArray
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int[] nums = { 3, 0, 1 };
            // Array.Sort(nums1) изменяет исходный массив
            // Array.Reverse(nums1); изменяет исходный массив
            // nums.OrderBy<int, int>(x => x).ToArray<int>() не изменяет исходный массив
            // создаёт новый массив
            //var sorted = nums1.OrderByDescending(n => n).ToArray(); обратная сортировка
            int[] sortedNums = nums.OrderBy<int, int>(x => x).ToArray<int>();

            // Проверяем что результат отсортирован правильно
            int[] expected = { 0, 1, 3 };
            Assert.That(sortedNums, Is.EqualTo(expected));
        }

        // ========== ВАРИАНТ 1: СОЗДАЁТСЯ НОВЫЙ МАССИВ ==========
        // LINQ-методы (Select, OrderBy) НЕ изменяют исходный массив.
        // Они возвращают IEnumerable, а ToArray() создаёт НОВЫЙ массив.
        // Исходный массив nums остаётся без изменений.
        // Плюсы: безопасно, исходные данные сохранены
        // Минусы: выделяется дополнительная память
        [Test]
        [TestCase(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
        public void SortedSquares_NewArray(int[] nums, int[] expected)
        {
            // Select создаёт новую последовательность (не массив)
            // OrderBy создаёт новую отсортированную последовательность
            // ToArray() выделяет память и копирует результат в НОВЫЙ массив
            var result = nums.Select(x => x * x).OrderBy(x => x).ToArray();
            
            // nums всё ещё [-7, -3, 2, 3, 11] — не изменился!
            Assert.That(result, Is.EqualTo(expected));
        }

        // ========== ВАРИАНТ 2: ИЗМЕНЯЕМ ИСХОДНЫЙ МАССИВ ==========
        // Используем цикл for для изменения элементов на месте.
        // Array.Sort() сортирует массив на месте (in-place).
        // Новый массив НЕ создаётся, экономим память.
        // Плюсы: экономия памяти
        // Минусы: исходные данные теряются
        [Test]
        [TestCase(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
        public void SortedSquares_InPlace(int[] nums, int[] expected)
        {
            // Изменяем каждый элемент ПРЯМО в массиве nums
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] * nums[i];
            }
            
            // Array.Sort изменяет массив на месте (in-place)
            // Новый массив НЕ создаётся
            Array.Sort(nums);
            
            // nums теперь [4, 9, 9, 49, 121] — изменился!
            Assert.That(nums, Is.EqualTo(expected));
        }
    }
}