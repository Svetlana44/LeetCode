using System;
using System.Collections.Generic;
using System.Linq;
using Allure.NUnit;
using NUnit.Framework;

namespace LeetCode.Tasks.Dictionary
{
    /// <summary>
    /// ЗАДАЧИ НА DICTIONARY — продвинутый уровень
    /// </summary>
    [AllureNUnit]
    public class Dictionary_Advanced_Tasks
    {
        #region Задача 1: LRU Cache
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 1. LRU Cache (Medium) — LeetCode #146                            ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Реализуйте структуру данных LRU (Least Recently Used) кэш.       ║
        ║                                                                  ║
        ║ Операции:                                                        ║
        ║   • LRUCache(int capacity) — инициализация с ёмкостью            ║
        ║   • int Get(int key) — вернуть значение или -1 если нет          ║
        ║   • void Put(int key, int value) — добавить/обновить             ║
        ║                                                                  ║
        ║ При переполнении удаляется наименее недавно использованный.      ║
        ║ Get и Put должны работать за O(1).                               ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   LRUCache cache = new LRUCache(2);                              ║
        ║   cache.Put(1, 1);                                               ║
        ║   cache.Put(2, 2);                                               ║
        ║   cache.Get(1);       // returns 1                               ║
        ║   cache.Put(3, 3);    // удаляет key 2 (LRU)                     ║
        ║   cache.Get(2);       // returns -1 (не найден)                  ║
        ║   cache.Put(4, 4);    // удаляет key 1                           ║
        ║   cache.Get(1);       // returns -1                              ║
        ║   cache.Get(3);       // returns 3                               ║
        ║   cache.Get(4);       // returns 4                               ║
        ║                                                                  ║
        ║ Hint: Dictionary + LinkedList (или OrderedDictionary)            ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 1 <= capacity <= 3000                                        ║
        ║   • 0 <= key <= 10^4                                             ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public class LRUCache
        {
            // Твоя реализация здесь
            
            public LRUCache(int capacity)
            {
                throw new NotImplementedException();
            }
            
            public int Get(int key)
            {
                throw new NotImplementedException();
            }
            
            public void Put(int key, int value)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void Test_LRUCache()
        {
            var cache = new LRUCache(2);
            
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.That(cache.Get(1), Is.EqualTo(1));
            
            cache.Put(3, 3);  // удаляет key 2
            Assert.That(cache.Get(2), Is.EqualTo(-1));
            
            cache.Put(4, 4);  // удаляет key 1
            Assert.That(cache.Get(1), Is.EqualTo(-1));
            Assert.That(cache.Get(3), Is.EqualTo(3));
            Assert.That(cache.Get(4), Is.EqualTo(4));
        }
        #endregion

        #region Задача 2: Design HashMap
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 2. Design HashMap (Easy) — LeetCode #706                         ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Реализуйте HashMap БЕЗ использования встроенных хэш-таблиц.      ║
        ║                                                                  ║
        ║ Операции:                                                        ║
        ║   • void Put(int key, int value) — добавить/обновить             ║
        ║   • int Get(int key) — вернуть значение или -1                   ║
        ║   • void Remove(int key) — удалить ключ                          ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   MyHashMap map = new MyHashMap();                               ║
        ║   map.Put(1, 1);                                                 ║
        ║   map.Put(2, 2);                                                 ║
        ║   map.Get(1);    // returns 1                                    ║
        ║   map.Get(3);    // returns -1                                   ║
        ║   map.Put(2, 1); // update                                       ║
        ║   map.Get(2);    // returns 1                                    ║
        ║   map.Remove(2);                                                 ║
        ║   map.Get(2);    // returns -1                                   ║
        ║                                                                  ║
        ║ Hint: Массив списков (buckets) + хэш-функция (key % size)        ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 0 <= key, value <= 10^6                                      ║
        ║   • At most 10^4 calls to put, get, remove                       ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public class MyHashMap
        {
            // Твоя реализация здесь
            
            public MyHashMap()
            {
                throw new NotImplementedException();
            }
            
            public void Put(int key, int value)
            {
                throw new NotImplementedException();
            }
            
            public int Get(int key)
            {
                throw new NotImplementedException();
            }
            
            public void Remove(int key)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void Test_MyHashMap()
        {
            var map = new MyHashMap();
            
            map.Put(1, 1);
            map.Put(2, 2);
            Assert.That(map.Get(1), Is.EqualTo(1));
            Assert.That(map.Get(3), Is.EqualTo(-1));
            
            map.Put(2, 1);  // update
            Assert.That(map.Get(2), Is.EqualTo(1));
            
            map.Remove(2);
            Assert.That(map.Get(2), Is.EqualTo(-1));
        }
        #endregion

        #region Задача 3: Copy List with Random Pointer
        /*
        ╔══════════════════════════════════════════════════════════════════╗
        ║ 3. Copy List with Random Pointer (Medium) — LeetCode #138        ║
        ╠══════════════════════════════════════════════════════════════════╣
        ║ Дан связный список, где каждый узел имеет:                       ║
        ║   • next — указатель на следующий узел                           ║
        ║   • random — указатель на любой узел или null                    ║
        ║                                                                  ║
        ║ Создайте глубокую копию списка.                                  ║
        ║                                                                  ║
        ║ Example:                                                         ║
        ║   Input:  [[7,null],[13,0],[11,4],[10,2],[1,0]]                  ║
        ║           (значение, индекс random)                              ║
        ║   Output: Копия списка с теми же связями                         ║
        ║                                                                  ║
        ║ Hint: Dictionary<Node, Node> — маппинг оригинал → копия          ║
        ║                                                                  ║
        ║ Constraints:                                                     ║
        ║   • 0 <= n <= 1000                                               ║
        ╚══════════════════════════════════════════════════════════════════╝
        */
        
        public class Node
        {
            public int val;
            public Node next;
            public Node random;
            
            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
        
        public Node CopyRandomList(Node head)
        {
            // Твоё решение здесь
            throw new NotImplementedException();
        }

        [Test]
        public void Test_CopyRandomList()
        {
            // Создаём список: 1 -> 2 -> 3
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            
            node1.next = node2;
            node2.next = node3;
            
            node1.random = node3;  // 1.random -> 3
            node2.random = node1;  // 2.random -> 1
            node3.random = node2;  // 3.random -> 2
            
            var copy = CopyRandomList(node1);
            
            // Проверяем что это копия, а не тот же объект
            Assert.That(copy, Is.Not.SameAs(node1));
            Assert.That(copy.val, Is.EqualTo(1));
            Assert.That(copy.next.val, Is.EqualTo(2));
            Assert.That(copy.next.next.val, Is.EqualTo(3));
            
            // Проверяем random указатели
            Assert.That(copy.random.val, Is.EqualTo(3));
            Assert.That(copy.next.random.val, Is.EqualTo(1));
            Assert.That(copy.next.next.random.val, Is.EqualTo(2));
        }
        #endregion
    }
}

