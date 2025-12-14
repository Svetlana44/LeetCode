# Коллекции C# — Гайд для Senior QA (Java → C#)

## Иерархия коллекций

```
                        IEnumerable<T>
                             │
            ┌────────────────┼────────────────┐
            │                │                │
      ICollection<T>    IQueryable<T>    (yield iterators)
            │
    ┌───────┴───────┐
    │               │
 IList<T>    IDictionary<K,V>    ISet<T>
    │               │               │
┌───┴───┐     ┌─────┴─────┐    ┌───┴───┐
│       │     │           │    │       │
List<T> T[]  Dictionary  Sorted HashSet Sorted
            <K,V>     Dictionary      HashSet
```

---

## Соответствие Java ↔ C#

| Java | C# | Описание |
|------|-----|----------|
| `Iterable<T>` | `IEnumerable<T>` | Можно перебирать foreach |
| `Collection<T>` | `ICollection<T>` | + Count, Add, Remove |
| `List<T>` (interface) | `IList<T>` | + индексатор [i] |
| `ArrayList<T>` | `List<T>` | Динамический массив |
| `LinkedList<T>` | `LinkedList<T>` | Двусвязный список |
| `HashMap<K,V>` | `Dictionary<K,V>` | Хэш-таблица |
| `TreeMap<K,V>` | `SortedDictionary<K,V>` | Отсортированный по ключу |
| `HashSet<T>` | `HashSet<T>` | Уникальные элементы |
| `TreeSet<T>` | `SortedSet<T>` | Отсортированный набор |
| `Queue<T>` | `Queue<T>` | FIFO очередь |
| `Deque<T>` | нет (используй LinkedList) | Двусторонняя очередь |
| `Stack<T>` | `Stack<T>` | LIFO стек |
| `T[]` | `T[]` | Массив фиксированной длины |

---

## Интерфейсы — от простого к сложному

### 1. IEnumerable<T> — только перебор

```csharp
public interface IEnumerable<T>
{
    IEnumerator<T> GetEnumerator();
}
```

**Что умеет:** только `foreach`

```csharp
IEnumerable<int> nums = GetNumbers();

foreach (var n in nums)      // ✅ OK
    Console.WriteLine(n);

int count = nums.Count;       // ❌ Нет свойства Count
nums.Add(5);                  // ❌ Нет метода Add
int first = nums[0];          // ❌ Нет индексатора
```

**Когда использовать:** 
- Параметры методов (принимает любую коллекцию)
- Возвращаемый тип для ленивых последовательностей (yield)

---

### 2. ICollection<T> — + Count, Add, Remove

```csharp
public interface ICollection<T> : IEnumerable<T>
{
    int Count { get; }
    bool IsReadOnly { get; }
    void Add(T item);
    void Clear();
    bool Contains(T item);
    void CopyTo(T[] array, int arrayIndex);
    bool Remove(T item);
}
```

**Что добавляет:** Count, Add, Remove, Contains, Clear

```csharp
ICollection<int> nums = new List<int> { 1, 2, 3 };

int count = nums.Count;       // ✅ 3
nums.Add(4);                  // ✅ OK
nums.Remove(2);               // ✅ OK
bool has = nums.Contains(1);  // ✅ true
int first = nums[0];          // ❌ Всё ещё нет индексатора!
```

---

### 3. IList<T> — + индексатор [i]

```csharp
public interface IList<T> : ICollection<T>
{
    T this[int index] { get; set; }  // Индексатор!
    int IndexOf(T item);
    void Insert(int index, T item);
    void RemoveAt(int index);
}
```

**Что добавляет:** `[i]`, `IndexOf`, `Insert`, `RemoveAt`

```csharp
IList<int> nums = new List<int> { 1, 2, 3 };

int first = nums[0];          // ✅ 1
nums[0] = 10;                 // ✅ OK
nums.Insert(1, 100);          // ✅ [10, 100, 2, 3]
nums.RemoveAt(0);             // ✅ [100, 2, 3]
int idx = nums.IndexOf(2);    // ✅ 1
```

---

### 4. IDictionary<K,V> — ключ-значение

```csharp
public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>
{
    TValue this[TKey key] { get; set; }
    ICollection<TKey> Keys { get; }
    ICollection<TValue> Values { get; }
    void Add(TKey key, TValue value);
    bool ContainsKey(TKey key);
    bool Remove(TKey key);
    bool TryGetValue(TKey key, out TValue value);
}
```

---

### 5. ISet<T> — уникальные элементы

```csharp
public interface ISet<T> : ICollection<T>
{
    bool Add(T item);  // Возвращает false если уже есть!
    void ExceptWith(IEnumerable<T> other);
    void IntersectWith(IEnumerable<T> other);
    void UnionWith(IEnumerable<T> other);
    bool IsSubsetOf(IEnumerable<T> other);
    bool IsSupersetOf(IEnumerable<T> other);
    bool Overlaps(IEnumerable<T> other);
}
```

---

## Конкретные реализации

### List<T> — динамический массив

```csharp
// Создание
var list = new List<int>();                    // Пустой
var list = new List<int> { 1, 2, 3 };          // С элементами
var list = new List<int>(100);                 // С capacity
var list = new List<int>(existingCollection);  // Копия

// Добавление
list.Add(4);                    // В конец
list.AddRange(new[] { 5, 6 });  // Несколько
list.Insert(0, 0);              // По индексу

// Удаление
list.Remove(3);                 // По значению (первое вхождение)
list.RemoveAt(0);               // По индексу
list.RemoveAll(x => x < 0);     // По условию (возвращает количество)
list.RemoveRange(0, 2);         // Диапазон
list.Clear();                   // Все

// Поиск
int idx = list.IndexOf(5);           // -1 если нет
int idx = list.LastIndexOf(5);       // С конца
int idx = list.FindIndex(x => x > 3);// По условию
int val = list.Find(x => x > 3);     // Первый элемент
List<int> all = list.FindAll(x => x > 3); // Все элементы
bool has = list.Contains(5);         // Есть ли
bool any = list.Exists(x => x > 10); // Есть ли по условию

// Сортировка
list.Sort();                         // На месте
list.Sort((a, b) => b - a);          // С компаратором (desc)
list.Reverse();                      // Развернуть

// Преобразование
int[] arr = list.ToArray();
List<string> strs = list.ConvertAll(x => x.ToString());

// Другое
list.ForEach(x => Console.WriteLine(x));  // Итерация
int count = list.Count;                    // Количество
int capacity = list.Capacity;              // Ёмкость буфера
```

**Сложность операций:**
| Операция | Сложность |
|----------|-----------|
| `Add` (в конец) | O(1)* |
| `Insert` (в середину) | O(n) |
| `Remove` | O(n) |
| `RemoveAt` | O(n) |
| `[i]` (индексатор) | O(1) |
| `Contains` | O(n) |
| `Sort` | O(n log n) |

*амортизированная, O(n) при расширении буфера

---

### Dictionary<K,V> — хэш-таблица

```csharp
// Создание
var dict = new Dictionary<string, int>();
var dict = new Dictionary<string, int>
{
    { "apple", 1 },
    { "banana", 2 }
};
var dict = new Dictionary<string, int>
{
    ["apple"] = 1,
    ["banana"] = 2
};
// Case-insensitive ключи
var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

// Добавление
dict.Add("cherry", 3);          // Exception если ключ есть
dict["cherry"] = 3;             // Добавит или обновит
dict.TryAdd("cherry", 3);       // false если ключ есть

// Получение
int val = dict["apple"];                      // Exception если нет
bool ok = dict.TryGetValue("apple", out int v); // Безопасно
int val = dict.GetValueOrDefault("apple");    // 0 если нет
int val = dict.GetValueOrDefault("apple", -1);// -1 если нет

// Проверка
bool hasKey = dict.ContainsKey("apple");      // O(1)
bool hasVal = dict.ContainsValue(1);          // O(n) — медленно!

// Удаление
dict.Remove("apple");                         // true/false
dict.Remove("apple", out int removed);        // С получением значения
dict.Clear();

// Итерация
foreach (var kvp in dict)
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");

foreach (var (key, value) in dict)  // Деконструкция
    Console.WriteLine($"{key}: {value}");

foreach (var key in dict.Keys)
    Console.WriteLine(key);

foreach (var value in dict.Values)
    Console.WriteLine(value);
```

**Сложность операций:**
| Операция | Сложность |
|----------|-----------|
| `Add` | O(1)* |
| `[key]` | O(1) |
| `TryGetValue` | O(1) |
| `ContainsKey` | O(1) |
| `ContainsValue` | O(n) ⚠️ |
| `Remove` | O(1) |

---

### HashSet<T> — уникальные элементы

```csharp
// Создание
var set = new HashSet<int>();
var set = new HashSet<int> { 1, 2, 3 };
var set = new HashSet<int>(existingCollection);  // Убрать дубликаты!
var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

// Добавление
bool added = set.Add(4);    // true
bool added = set.Add(4);    // false — уже есть!

// Проверка
bool has = set.Contains(3); // O(1)!

// Удаление
set.Remove(3);
set.RemoveWhere(x => x < 0);
set.Clear();

// Операции над множествами (ИЗМЕНЯЮТ set!)
set.UnionWith(other);       // Объединение (добавить все из other)
set.IntersectWith(other);   // Пересечение (оставить только общие)
set.ExceptWith(other);      // Разность (убрать все из other)
set.SymmetricExceptWith(other); // Симметричная разность

// Проверки (НЕ изменяют)
bool isSubset = set.IsSubsetOf(other);
bool isSuperset = set.IsSupersetOf(other);
bool overlaps = set.Overlaps(other);
bool equals = set.SetEquals(other);

// LINQ альтернативы (создают НОВЫЙ set)
var union = set.Union(other).ToHashSet();
var intersect = set.Intersect(other).ToHashSet();
var except = set.Except(other).ToHashSet();
```

**Сложность:** все операции O(1), кроме операций с другими множествами O(n+m)

---

### Queue<T> — FIFO очередь

```csharp
var queue = new Queue<int>();
var queue = new Queue<int>(new[] { 1, 2, 3 });

// Добавление (в конец)
queue.Enqueue(4);

// Извлечение (с начала)
int first = queue.Dequeue();        // Удаляет и возвращает
int first = queue.Peek();           // Только смотрит, не удаляет
bool ok = queue.TryDequeue(out int val); // Безопасно
bool ok = queue.TryPeek(out int val);

// Другое
int count = queue.Count;
bool has = queue.Contains(5);
queue.Clear();
int[] arr = queue.ToArray();
```

```
Enqueue → [1] [2] [3] [4] → Dequeue
           ↑               ↑
          tail           head
```

---

### Stack<T> — LIFO стек

```csharp
var stack = new Stack<int>();
var stack = new Stack<int>(new[] { 1, 2, 3 }); // 3 будет сверху!

// Добавление (на вершину)
stack.Push(4);

// Извлечение (с вершины)
int top = stack.Pop();              // Удаляет и возвращает
int top = stack.Peek();             // Только смотрит
bool ok = stack.TryPop(out int val);
bool ok = stack.TryPeek(out int val);

// Другое
int count = stack.Count;
bool has = stack.Contains(5);
stack.Clear();
int[] arr = stack.ToArray();        // Сверху вниз!
```

```
       Push ↓ ↑ Pop
            [4] ← top
            [3]
            [2]
            [1]
```

---

### LinkedList<T> — двусвязный список

```csharp
var list = new LinkedList<int>();
var list = new LinkedList<int>(new[] { 1, 2, 3 });

// Добавление
list.AddFirst(0);                    // В начало
list.AddLast(4);                     // В конец
LinkedListNode<int> node = list.Find(2);
list.AddBefore(node, 100);           // Перед узлом
list.AddAfter(node, 200);            // После узла

// Удаление
list.RemoveFirst();
list.RemoveLast();
list.Remove(2);                      // По значению
list.Remove(node);                   // По узлу

// Навигация по узлам
LinkedListNode<int> first = list.First;
LinkedListNode<int> last = list.Last;
LinkedListNode<int> next = node.Next;
LinkedListNode<int> prev = node.Previous;
int value = node.Value;

// Поиск
LinkedListNode<int> found = list.Find(5);      // От начала
LinkedListNode<int> found = list.FindLast(5);  // От конца
bool has = list.Contains(5);
```

**Когда использовать LinkedList:**
- Частые вставки/удаления в середине
- Не нужен доступ по индексу

**Сложность:**
| Операция | List<T> | LinkedList<T> |
|----------|---------|---------------|
| `Add` в конец | O(1)* | O(1) |
| `Insert` в середину | O(n) | O(1)** |
| `Remove` из середины | O(n) | O(1)** |
| `[i]` индексатор | O(1) | ❌ нет |
| Поиск | O(n) | O(n) |

** при наличии ссылки на узел

---

### SortedDictionary<K,V> — отсортированный по ключу

```csharp
var dict = new SortedDictionary<string, int>
{
    ["banana"] = 2,
    ["apple"] = 1,
    ["cherry"] = 3
};

foreach (var (key, value) in dict)
    Console.WriteLine($"{key}: {value}");
// apple: 1
// banana: 2
// cherry: 3
```

**Сложность:** все операции O(log n) — красно-чёрное дерево

---

### SortedSet<T> — отсортированный набор

```csharp
var set = new SortedSet<int> { 3, 1, 4, 1, 5, 9 };
// set = { 1, 3, 4, 5, 9 } — отсортировано, без дубликатов

int min = set.Min;  // 1
int max = set.Max;  // 9

// Диапазоны
var range = set.GetViewBetween(3, 6);  // { 3, 4, 5 }
```

---

## Выбор коллекции

```
                     Нужен ли ключ?
                    /             \
                  ДА              НЕТ
                   |               |
            Dictionary        Уникальность?
           или Sorted?        /          \
              /    \        ДА           НЕТ
          обычный  сорт.     |            |
             |       |    HashSet    Нужен индекс?
        Dictionary Sorted  или         /      \
                  Dictionary SortedSet       ДА       НЕТ
                                              |        |
                                           List<T>  IEnumerable
                                           или T[]  (ленивый)
```

### Шпаргалка:

| Задача | Коллекция |
|--------|-----------|
| Просто список | `List<T>` |
| Ключ → Значение | `Dictionary<K,V>` |
| Уникальные элементы | `HashSet<T>` |
| FIFO (очередь) | `Queue<T>` |
| LIFO (стек) | `Stack<T>` |
| Частые вставки в середину | `LinkedList<T>` |
| Отсортированный словарь | `SortedDictionary<K,V>` |
| Фиксированный размер | `T[]` |
| Ленивый перебор | `IEnumerable<T>` + yield |
| Потокобезопасный словарь | `ConcurrentDictionary<K,V>` |
| Неизменяемый | `ImmutableList<T>`, `ImmutableDictionary<K,V>` |

---

## Методы List<T> vs LINQ

| List<T> метод | LINQ метод | Разница |
|---------------|------------|---------|
| `Find(predicate)` | `FirstOrDefault(predicate)` | Find только для List |
| `FindAll(predicate)` | `Where(predicate).ToList()` | FindAll возвращает List |
| `FindIndex(predicate)` | нет прямого | — |
| `Exists(predicate)` | `Any(predicate)` | Одинаково |
| `TrueForAll(predicate)` | `All(predicate)` | Одинаково |
| `ConvertAll(converter)` | `Select(converter).ToList()` | ConvertAll только для List |
| `ForEach(action)` | нет (используй foreach) | LINQ не имеет side-effects |
| `Sort()` | `OrderBy().ToList()` | Sort изменяет на месте! |
| `Reverse()` | `Reverse().ToList()` | List.Reverse изменяет на месте! |
| `RemoveAll(predicate)` | `Where(!predicate).ToList()` | RemoveAll изменяет на месте! |

**⚠️ Ключевое отличие:**
- Методы **List<T>** изменяют коллекцию **на месте**
- Методы **LINQ** создают **новую** коллекцию

```csharp
var list = new List<int> { 3, 1, 2 };

// List — изменяет оригинал
list.Sort();  // list теперь [1, 2, 3]

// LINQ — создаёт новый
var sorted = list.OrderBy(x => x).ToList();  // list не изменился
```

---

## Вопросы на собесе

**Q: Разница List<T> и T[]?**
> `T[]` — фиксированный размер, `List<T>` — динамический. List внутри использует массив и расширяет его при необходимости.

**Q: Когда HashSet, когда List?**
> `HashSet` — нужны уникальные элементы и O(1) поиск. `List` — нужен порядок и доступ по индексу.

**Q: Разница Dictionary и SortedDictionary?**
> `Dictionary` — O(1) операции, без порядка. `SortedDictionary` — O(log n), отсортирован по ключу.

**Q: Что будет если изменить коллекцию в foreach?**
> `InvalidOperationException: Collection was modified`

**Q: Как безопасно удалять элементы при переборе?**
```csharp
// Вариант 1: RemoveAll
list.RemoveAll(x => x < 0);

// Вариант 2: Перебор в обратном порядке
for (int i = list.Count - 1; i >= 0; i--)
    if (list[i] < 0) list.RemoveAt(i);

// Вариант 3: ToList() для копии
foreach (var item in list.ToList())
    if (item < 0) list.Remove(item);
```

**Q: Что такое Capacity у List?**
> Размер внутреннего массива. Когда Count достигает Capacity, создаётся новый массив в 2 раза больше.

---

## Чек-лист для собеса

- [ ] Иерархия: IEnumerable → ICollection → IList/IDictionary/ISet
- [ ] List<T> методы изменяют на месте, LINQ создаёт новое
- [ ] Dictionary: Add бросает исключение, [] перезаписывает
- [ ] HashSet.Add() возвращает bool
- [ ] Нельзя изменять коллекцию в foreach
- [ ] O(1) поиск: Dictionary, HashSet; O(n): List
- [ ] Queue = FIFO, Stack = LIFO
- [ ] LinkedList — быстрая вставка, нет индексатора

