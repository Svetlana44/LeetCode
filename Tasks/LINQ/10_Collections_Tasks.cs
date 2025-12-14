using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Tasks.LINQ
{
    /// <summary>
    /// ЗАДАЧИ НА РАЗНЫЕ КОЛЛЕКЦИИ — List, HashSet, конвертация
    /// Важно для собеса: знать разницу и когда что использовать
    /// </summary>
    public class Collections_Tasks
    {
        #region Задача 1: Remove Duplicates (HashSet)
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. Remove Duplicates Using HashSet (Easy)                        ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан List<int> с дубликатами. Удалите дубликаты, сохранив порядок.║
        ║ Используйте HashSet для отслеживания уже встреченных элементов.  ║
        ║                                                                  ║
        ║ Example 1:                                                       ║
        ║   Input:  nums = [1, 2, 2, 3, 1, 4, 2]                           ║
        ║   Output: [1, 2, 3, 4]                                           ║
        ║                                                                  ║
        ║ Example 2:                                                       ║
        ║   Input:  nums = [5, 5, 5]                                       ║
        ║   Output: [5]                                                    ║
        ║                                                                  ║
        ║ Hint: HashSet.Add() возвращает false если элемент уже есть       ║
        ║       Или используй .Distinct() но это менее показательно        ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= nums.Count <= 1000                                      ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public List<int> RemoveDuplicatesWithHashSet(List<int> nums)
        {
            // Твоё решение здесь
            // Подсказка: var seen = new HashSet<int>();
            //            return nums.Where(n => seen.Add(n)).ToList();
            throw new NotImplementedException();
        }

        [Test]
        public void Test_RemoveDuplicatesWithHashSet_1()
        {
            var nums = new List<int> { 1, 2, 2, 3, 1, 4, 2 };
            var result = RemoveDuplicatesWithHashSet(nums);
            Assert.That(result, Is.EqualTo(new List<int> { 1, 2, 3, 4 }));
        }

        [Test]
        public void Test_RemoveDuplicatesWithHashSet_2()
        {
            var nums = new List<int> { 5, 5, 5 };
            var result = RemoveDuplicatesWithHashSet(nums);
            Assert.That(result, Is.EqualTo(new List<int> { 5 }));
        }
        #endregion

        #region Задача 2: Set Operations
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Set Operations (Medium)                                       ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Даны два HashSet<int>. Выполните операции над множествами.       ║
        ║                                                                  ║
        ║ Верните кортеж из трёх HashSet:                                  ║
        ║   1. Union — объединение (все элементы из обоих)                 ║
        ║   2. Intersection — пересечение (общие элементы)                 ║
        ║   3. Difference — разность (только в первом, не во втором)       ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   Input:  set1 = {1, 2, 3, 4}, set2 = {3, 4, 5, 6}               ║
        ║   Output:                                                        ║
        ║     Union:        {1, 2, 3, 4, 5, 6}                             ║
        ║     Intersection: {3, 4}                                         ║
        ║     Difference:   {1, 2}                                         ║
        ║                                                                  ║
        ║ Hint: UnionWith, IntersectWith, ExceptWith (изменяют set!)       ║
        ║       Или LINQ: Union, Intersect, Except (создают новый)         ║
        ║                                                                  ║
        ║ ⚠️ Важно: методы *With изменяют исходный set!                    ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public (HashSet<int> Union, HashSet<int> Intersection, HashSet<int> Difference) 
            SetOperations(HashSet<int> set1, HashSet<int> set2)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_SetOperations()
        {
            var set1 = new HashSet<int> { 1, 2, 3, 4 };
            var set2 = new HashSet<int> { 3, 4, 5, 6 };
            
            var (union, intersection, difference) = SetOperations(set1, set2);
            
            Assert.That(union, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6 }));
            Assert.That(intersection, Is.EquivalentTo(new[] { 3, 4 }));
            Assert.That(difference, Is.EquivalentTo(new[] { 1, 2 }));
        }
        #endregion

        #region Задача 3: List Modifications
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. List Modifications (Easy)                                     ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан List<string>. Выполните модификации НА МЕСТЕ (in-place).     ║
        ║                                                                  ║
        ║ 1. Удалите все строки короче minLength                           ║
        ║ 2. Преобразуйте оставшиеся в UPPERCASE                           ║
        ║ 3. Отсортируйте по алфавиту                                      ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   Input:  words = ["cat", "a", "elephant", "dog", "be"]          ║
        ║           minLength = 3                                          ║
        ║   Output: ["CAT", "DOG", "ELEPHANT"]                             ║
        ║                                                                  ║
        ║ Hint: RemoveAll, ConvertAll (или ForEach), Sort                  ║
        ║       Эти методы изменяют List на месте!                         ║
        ║                                                                  ║
        ║ ⚠️ Отличие от LINQ:                                              ║
        ║    LINQ (.Where, .Select) создаёт НОВУЮ коллекцию                ║
        ║    List методы (RemoveAll, Sort) изменяют СУЩЕСТВУЮЩУЮ           ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public void ModifyListInPlace(List<string> words, int minLength)
        {
            // Твоё решение здесь — изменить words на месте
            // words.RemoveAll(...)
            // for (int i = 0; i < words.Count; i++) words[i] = ...
            // words.Sort()
            throw new NotImplementedException();
        }

        [Test]
        public void Test_ModifyListInPlace()
        {
            var words = new List<string> { "cat", "a", "elephant", "dog", "be" };
            ModifyListInPlace(words, 3);
            
            Assert.That(words, Is.EqualTo(new List<string> { "CAT", "DOG", "ELEPHANT" }));
        }
        #endregion

        #region Задача 4: Convert Between Collections
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 4. Convert Between Collections (Easy)                            ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив int[]. Верните кортеж со всеми конвертациями.         ║
        ║                                                                  ║
        ║ 1. ToList()                                                      ║
        ║ 2. ToHashSet()                                                   ║
        ║ 3. ToDictionary (ключ = элемент, значение = квадрат)             ║
        ║ 4. ToLookup (ключ = чётность, значения = элементы)               ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   Input:  nums = [1, 2, 3, 2]                                    ║
        ║   Output:                                                        ║
        ║     List:       [1, 2, 3, 2]                                     ║
        ║     HashSet:    {1, 2, 3}                                        ║
        ║     Dictionary: {1:1, 2:4, 3:9} (без дубликатов!)                ║
        ║     Lookup:     {true:[1,3], false:[2,2]}                        ║
        ║                                                                  ║
        ║ ⚠️ ToDictionary бросит исключение при дубликатах ключей!         ║
        ║    Сначала нужен Distinct()                                      ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public (List<int> list, HashSet<int> set, Dictionary<int, int> dict) 
            ConvertCollections(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_ConvertCollections()
        {
            var nums = new[] { 1, 2, 3, 2 };
            var (list, set, dict) = ConvertCollections(nums);
            
            Assert.That(list, Is.EqualTo(new List<int> { 1, 2, 3, 2 }));
            Assert.That(set, Is.EquivalentTo(new HashSet<int> { 1, 2, 3 }));
            Assert.That(dict[1], Is.EqualTo(1));
            Assert.That(dict[2], Is.EqualTo(4));
            Assert.That(dict[3], Is.EqualTo(9));
        }
        #endregion

        #region Задача 5: Find And Remove
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 5. Find And Remove (Medium)                                      ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан List<User>. Найдите и удалите всех неактивных пользователей. ║
        ║ Верните список удалённых.                                        ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   Input: [                                                       ║
        ║     { Id=1, Name="Alice", IsActive=true },                       ║
        ║     { Id=2, Name="Bob", IsActive=false },                        ║
        ║     { Id=3, Name="Charlie", IsActive=false }                     ║
        ║   ]                                                              ║
        ║   Output:                                                        ║
        ║     Удалённые: [Bob, Charlie]                                    ║
        ║     Оставшиеся в списке: [Alice]                                 ║
        ║                                                                  ║
        ║ Hint: FindAll + RemoveAll или Where + RemoveAll                  ║
        ║                                                                  ║
        ║ ⚠️ List.Find/FindAll — возвращает элемент(ы)                     ║
        ║    List.FindIndex — возвращает индекс                            ║
        ║    List.RemoveAll — удаляет и возвращает количество              ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
        
        public List<User> FindAndRemoveInactive(List<User> users)
        {
            // Твоё решение здесь
            // Верни список удалённых, при этом измени исходный users
            throw new NotImplementedException();
        }

        [Test]
        public void Test_FindAndRemoveInactive()
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "Alice", IsActive = true },
                new User { Id = 2, Name = "Bob", IsActive = false },
                new User { Id = 3, Name = "Charlie", IsActive = false }
            };
            
            var removed = FindAndRemoveInactive(users);
            
            Assert.That(removed.Select(u => u.Name), Is.EquivalentTo(new[] { "Bob", "Charlie" }));
            Assert.That(users.Select(u => u.Name), Is.EqualTo(new[] { "Alice" }));
        }
        #endregion

        #region Задача 6: IEnumerable Processing
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 6. Process Any IEnumerable (Medium)                              ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Напишите метод, который принимает ЛЮБУЮ коллекцию (IEnumerable)  ║
        ║ и возвращает статистику по ней.                                  ║
        ║                                                                  ║
        ║ Метод должен работать с: int[], List<int>, HashSet<int>, etc.    ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   Input:  [3, 1, 4, 1, 5, 9, 2, 6]                               ║
        ║   Output: { Count=8, Sum=31, Min=1, Max=9, Avg=3.875 }           ║
        ║                                                                  ║
        ║ ⚠️ Важно: IEnumerable может быть "ленивым"!                       ║
        ║    Если вызвать Count(), Min(), Max() отдельно —                 ║
        ║    коллекция будет перечислена НЕСКОЛЬКО раз!                    ║
        ║    Материализуй сначала через ToList() если нужно много операций ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public record CollectionStats(int Count, int Sum, int Min, int Max, double Avg);
        
        public CollectionStats GetCollectionStats(IEnumerable<int> numbers)
        {
            // Твоё решение здесь
            // Подсказка: сначала .ToList() чтобы не перечислять несколько раз
            throw new NotImplementedException();
        }

        [Test]
        public void Test_GetCollectionStats_Array()
        {
            var nums = new[] { 3, 1, 4, 1, 5, 9, 2, 6 };
            var stats = GetCollectionStats(nums);
            
            Assert.That(stats.Count, Is.EqualTo(8));
            Assert.That(stats.Sum, Is.EqualTo(31));
            Assert.That(stats.Min, Is.EqualTo(1));
            Assert.That(stats.Max, Is.EqualTo(9));
            Assert.That(stats.Avg, Is.EqualTo(3.875));
        }

        [Test]
        public void Test_GetCollectionStats_List()
        {
            var nums = new List<int> { 10, 20, 30 };
            var stats = GetCollectionStats(nums);
            
            Assert.That(stats.Count, Is.EqualTo(3));
            Assert.That(stats.Sum, Is.EqualTo(60));
            Assert.That(stats.Avg, Is.EqualTo(20));
        }

        [Test]
        public void Test_GetCollectionStats_HashSet()
        {
            var nums = new HashSet<int> { 5, 10, 15 };
            var stats = GetCollectionStats(nums);
            
            Assert.That(stats.Count, Is.EqualTo(3));
            Assert.That(stats.Sum, Is.EqualTo(30));
        }
        #endregion

        #region Задача 7: Queue and Stack Operations
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 7. Queue and Stack Operations (Medium)                           ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан массив чисел. Создайте Queue и Stack из него.                ║
        ║ Извлеките все элементы из каждого и верните как массивы.         ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   Input:  nums = [1, 2, 3, 4, 5]                                 ║
        ║   Output:                                                        ║
        ║     FromQueue: [1, 2, 3, 4, 5]  (FIFO)                           ║
        ║     FromStack: [5, 4, 3, 2, 1]  (LIFO)                           ║
        ║                                                                  ║
        ║ Hint:                                                            ║
        ║   Queue: Enqueue/Dequeue, FIFO (первый вошёл — первый вышел)     ║
        ║   Stack: Push/Pop, LIFO (последний вошёл — первый вышел)         ║
        ║                                                                  ║
        ║ ⚠️ Queue<T> и Stack<T> — НЕ реализуют IList<T>!                  ║
        ║    Нет индексатора [], только Enqueue/Dequeue или Push/Pop       ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public (int[] fromQueue, int[] fromStack) QueueStackOperations(int[] nums)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_QueueStackOperations()
        {
            var nums = new[] { 1, 2, 3, 4, 5 };
            var (fromQueue, fromStack) = QueueStackOperations(nums);
            
            Assert.That(fromQueue, Is.EqualTo(new[] { 1, 2, 3, 4, 5 }));
            Assert.That(fromStack, Is.EqualTo(new[] { 5, 4, 3, 2, 1 }));
        }
        #endregion

        #region Задача 8: LinkedList Operations
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 8. LinkedList Operations (Medium)                                ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан LinkedList<int>. Выполните операции:                         ║
        ║                                                                  ║
        ║ 1. Добавьте 0 в начало                                           ║
        ║ 2. Добавьте 100 в конец                                          ║
        ║ 3. Найдите узел со значением target и вставьте после него 999    ║
        ║ 4. Удалите первый чётный элемент                                 ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   Input:  list = [1, 2, 3, 4, 5], target = 3                     ║
        ║   После шага 1: [0, 1, 2, 3, 4, 5]                               ║
        ║   После шага 2: [0, 1, 2, 3, 4, 5, 100]                          ║
        ║   После шага 3: [0, 1, 2, 3, 999, 4, 5, 100]                     ║
        ║   После шага 4: [0, 1, 3, 999, 4, 5, 100] (удалили 2)            ║
        ║                                                                  ║
        ║ Hint: AddFirst, AddLast, Find, AddAfter, Remove                  ║
        ║                                                                  ║
        ║ ⚠️ LinkedList отличается от List:                                ║
        ║    - Быстрая вставка/удаление в середине O(1)                    ║
        ║    - Нет индексатора [] — нельзя list[i]                         ║
        ║    - Работа через узлы (LinkedListNode<T>)                       ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public void LinkedListOperations(LinkedList<int> list, int target)
        {
            // Твоё решение здесь — изменить list на месте
            throw new NotImplementedException();
        }

        [Test]
        public void Test_LinkedListOperations()
        {
            var list = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });
            LinkedListOperations(list, 3);
            
            Assert.That(list.ToArray(), Is.EqualTo(new[] { 0, 1, 3, 999, 4, 5, 100 }));
        }
        #endregion
    }
}

