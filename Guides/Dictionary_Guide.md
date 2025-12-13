# Dictionary в C# — Гайд для Senior QA (Java Map → C#)

## Быстрая таблица соответствий Java ↔ C#

| Java Map | C# Dictionary | Описание |
|----------|---------------|----------|
| `HashMap<K,V>` | `Dictionary<TKey,TValue>` | Основная реализация |
| `LinkedHashMap` | `Dictionary` (с .NET 7+ сохраняет порядок) | Порядок вставки |
| `TreeMap` | `SortedDictionary<TKey,TValue>` | Отсортированный по ключу |
| `ConcurrentHashMap` | `ConcurrentDictionary<TKey,TValue>` | Потокобезопасный |
| `map.put(k, v)` | `dict[k] = v` или `dict.Add(k, v)` | Добавление |
| `map.get(k)` | `dict[k]` или `dict.TryGetValue(k, out v)` | Получение |
| `map.getOrDefault(k, def)` | `dict.GetValueOrDefault(k, def)` | С дефолтом |
| `map.containsKey(k)` | `dict.ContainsKey(k)` | Проверка ключа |
| `map.containsValue(v)` | `dict.ContainsValue(v)` | Проверка значения |
| `map.remove(k)` | `dict.Remove(k)` | Удаление |
| `map.size()` | `dict.Count` | Количество |
| `map.isEmpty()` | `dict.Count == 0` | Пустой? |
| `map.clear()` | `dict.Clear()` | Очистка |
| `map.keySet()` | `dict.Keys` | Все ключи |
| `map.values()` | `dict.Values` | Все значения |
| `map.entrySet()` | `dict` (итерация по KeyValuePair) | Пары ключ-значение |
| `map.putIfAbsent(k, v)` | `dict.TryAdd(k, v)` | Добавить если нет |
| `map.computeIfAbsent()` | `dict.GetOrAdd()` (ConcurrentDictionary) | Вычислить если нет |
| `map.merge()` | нет прямого аналога | Слияние |
| `map.forEach()` | `foreach` или LINQ | Итерация |

---

## Создание Dictionary

```csharp
// Пустой
var dict = new Dictionary<string, int>();

// С начальной ёмкостью (оптимизация)
var dict = new Dictionary<string, int>(capacity: 100);

// Инициализация
var dict = new Dictionary<string, int>
{
    { "apple", 1 },
    { "banana", 2 },
    { "cherry", 3 }
};

// Альтернативный синтаксис (C# 6+)
var dict = new Dictionary<string, int>
{
    ["apple"] = 1,
    ["banana"] = 2,
    ["cherry"] = 3
};

// Из массива пар
var pairs = new[] { ("a", 1), ("b", 2) };
var dict = pairs.ToDictionary(p => p.Item1, p => p.Item2);

// Из коллекции объектов
var users = new[] { new User { Id = 1, Name = "Alice" }, new User { Id = 2, Name = "Bob" } };
var dict = users.ToDictionary(u => u.Id, u => u.Name);
// или
var dict = users.ToDictionary(u => u.Id);  // значение = весь объект
```

---

## Добавление элементов

### Add vs индексатор []

```csharp
var dict = new Dictionary<string, int>();

// Add — бросает исключение если ключ существует
dict.Add("apple", 1);
dict.Add("apple", 2);  // ❌ ArgumentException: Key already exists!

// Индексатор — перезаписывает если ключ существует
dict["apple"] = 1;
dict["apple"] = 2;  // ✅ Теперь apple = 2

// TryAdd — возвращает false если ключ существует (не бросает исключение)
bool added = dict.TryAdd("apple", 3);  // false, значение НЕ изменилось
```

**Собес:** Когда Add, когда []?
> `Add` — когда дубликат это ошибка (хотим исключение). `[]` — когда хотим обновить или добавить.

---

## Получение элементов

### [] vs TryGetValue

```csharp
var dict = new Dictionary<string, int> { ["apple"] = 1 };

// Индексатор — бросает исключение если ключа нет
int value = dict["apple"];   // ✅ 1
int value = dict["banana"];  // ❌ KeyNotFoundException!

// TryGetValue — безопасное получение
if (dict.TryGetValue("banana", out int val))
{
    Console.WriteLine(val);  // Не выполнится
}
else
{
    Console.WriteLine("Key not found");
}

// GetValueOrDefault (C# 7.1+) — с дефолтным значением
int value = dict.GetValueOrDefault("banana");      // 0 (default для int)
int value = dict.GetValueOrDefault("banana", -1);  // -1
```

**Собес:** Когда [], когда TryGetValue?
> `[]` — когда уверен что ключ есть (или это баг). `TryGetValue` — когда отсутствие ключа допустимо.

---

## Проверка и удаление

```csharp
var dict = new Dictionary<string, int> { ["apple"] = 1, ["banana"] = 2 };

// Проверка ключа
if (dict.ContainsKey("apple"))  // true
{
    // ...
}

// Проверка значения (O(n) — медленно!)
if (dict.ContainsValue(1))  // true
{
    // ...
}

// Удаление
bool removed = dict.Remove("apple");  // true
bool removed = dict.Remove("orange"); // false — ключа не было

// Удаление с получением значения (C# 5+)
if (dict.Remove("banana", out int removedValue))
{
    Console.WriteLine($"Removed: {removedValue}");  // 2
}

// Очистка
dict.Clear();
```

---

## Итерация

```csharp
var dict = new Dictionary<string, int>
{
    ["apple"] = 1,
    ["banana"] = 2,
    ["cherry"] = 3
};

// По парам ключ-значение (KeyValuePair)
foreach (var kvp in dict)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// Деконструкция (C# 7+) — РЕКОМЕНДУЕТСЯ
foreach (var (key, value) in dict)
{
    Console.WriteLine($"{key}: {value}");
}

// Только ключи
foreach (var key in dict.Keys)
{
    Console.WriteLine(key);
}

// Только значения
foreach (var value in dict.Values)
{
    Console.WriteLine(value);
}
```

---

## LINQ с Dictionary

```csharp
var dict = new Dictionary<string, int>
{
    ["apple"] = 5,
    ["banana"] = 2,
    ["cherry"] = 8,
    ["date"] = 3
};

// Фильтрация
var filtered = dict.Where(kvp => kvp.Value > 3)
                   .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
// { apple: 5, cherry: 8 }

// Сортировка по ключу
var sortedByKey = dict.OrderBy(kvp => kvp.Key)
                      .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

// Сортировка по значению
var sortedByValue = dict.OrderByDescending(kvp => kvp.Value)
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

// Трансформация значений
var doubled = dict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value * 2);

// Макс/мин по значению
var maxEntry = dict.MaxBy(kvp => kvp.Value);  // cherry: 8
var minEntry = dict.MinBy(kvp => kvp.Value);  // banana: 2

// Сумма значений
int total = dict.Values.Sum();  // 18

// Группировка в Dictionary
var words = new[] { "apple", "ant", "banana", "cherry", "cat" };
var grouped = words.GroupBy(w => w[0])
                   .ToDictionary(g => g.Key, g => g.ToList());
// { 'a': ["apple", "ant"], 'b': ["banana"], 'c': ["cherry", "cat"] }
```

---

## Паттерны использования

### 1. Подсчёт частоты (Counter)

```csharp
// Java: Map<String, Integer> с getOrDefault
var words = new[] { "apple", "banana", "apple", "cherry", "banana", "apple" };

var counter = new Dictionary<string, int>();
foreach (var word in words)
{
    // Вариант 1: TryGetValue
    counter.TryGetValue(word, out int count);
    counter[word] = count + 1;
    
    // Вариант 2: GetValueOrDefault (короче)
    counter[word] = counter.GetValueOrDefault(word) + 1;
    
    // Вариант 3: CollectionsMarshal (самый быстрый, .NET 6+)
    // CollectionsMarshal.GetValueRefOrAddDefault(counter, word, out _)++;
}
// { apple: 3, banana: 2, cherry: 1 }

// LINQ вариант (создаёт новый Dictionary)
var counter = words.GroupBy(w => w)
                   .ToDictionary(g => g.Key, g => g.Count());
```

### 2. Группировка (Grouping)

```csharp
var users = new[]
{
    new { Name = "Alice", Role = "Admin" },
    new { Name = "Bob", Role = "User" },
    new { Name = "Charlie", Role = "Admin" }
};

var byRole = users.GroupBy(u => u.Role)
                  .ToDictionary(g => g.Key, g => g.Select(u => u.Name).ToList());
// { "Admin": ["Alice", "Charlie"], "User": ["Bob"] }
```

### 3. Кэширование / Мемоизация

```csharp
private Dictionary<int, long> _cache = new();

public long Fibonacci(int n)
{
    if (n <= 1) return n;
    
    if (_cache.TryGetValue(n, out long cached))
        return cached;
    
    long result = Fibonacci(n - 1) + Fibonacci(n - 2);
    _cache[n] = result;
    return result;
}
```

### 4. Two-Sum паттерн (LeetCode классика)

```csharp
public int[] TwoSum(int[] nums, int target)
{
    var seen = new Dictionary<int, int>();  // value -> index
    
    for (int i = 0; i < nums.Length; i++)
    {
        int complement = target - nums[i];
        
        if (seen.TryGetValue(complement, out int j))
            return new[] { j, i };
        
        seen[nums[i]] = i;
    }
    
    return Array.Empty<int>();
}
```

### 5. Инвертирование Dictionary

```csharp
var dict = new Dictionary<string, int>
{
    ["apple"] = 1,
    ["banana"] = 2
};

// Инвертируем: значение -> ключ
var inverted = dict.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
// { 1: "apple", 2: "banana" }

// ⚠️ Если значения не уникальны — будет исключение!
```

---

## Сравнение реализаций

| Тип | Порядок | Сложность | Когда использовать |
|-----|---------|-----------|-------------------|
| `Dictionary<K,V>` | Нет (с .NET 7 сохраняет порядок вставки) | O(1) | По умолчанию |
| `SortedDictionary<K,V>` | По ключу (красно-чёрное дерево) | O(log n) | Нужен порядок по ключу |
| `SortedList<K,V>` | По ключу (массив) | O(log n) поиск, O(n) вставка | Редкие вставки, частый поиск |
| `ConcurrentDictionary<K,V>` | Нет | O(1) | Многопоточность |
| `ImmutableDictionary<K,V>` | Нет | O(log n) | Неизменяемость |

---

## ConcurrentDictionary — потокобезопасный

```csharp
var dict = new ConcurrentDictionary<string, int>();

// Добавить или обновить атомарно
dict.AddOrUpdate("key", 
    addValue: 1,                           // если ключа нет
    updateValueFactory: (k, old) => old + 1);  // если ключ есть

// Получить или добавить атомарно
int value = dict.GetOrAdd("key", 42);
int value = dict.GetOrAdd("key", k => ExpensiveComputation(k));

// Попытка обновить
dict.TryUpdate("key", newValue: 10, comparisonValue: 5);  // только если текущее = 5

// Попытка удалить
dict.TryRemove("key", out int removed);
```

---

## Частые ошибки

### 1. KeyNotFoundException
```csharp
// ПЛОХО
int value = dict["key"];  // 💥 если ключа нет

// ХОРОШО
if (dict.TryGetValue("key", out int value))
{
    // используем value
}
```

### 2. Изменение коллекции при итерации
```csharp
// ПЛОХО — InvalidOperationException!
foreach (var kvp in dict)
{
    if (kvp.Value < 0)
        dict.Remove(kvp.Key);  // 💥
}

// ХОРОШО — сначала собираем ключи
var keysToRemove = dict.Where(kvp => kvp.Value < 0)
                       .Select(kvp => kvp.Key)
                       .ToList();
foreach (var key in keysToRemove)
    dict.Remove(key);
```

### 3. Дубликаты при ToDictionary
```csharp
var items = new[] { ("a", 1), ("a", 2), ("b", 3) };

// ПЛОХО — ArgumentException: duplicate key!
var dict = items.ToDictionary(x => x.Item1, x => x.Item2);

// ХОРОШО — используем GroupBy или ToLookup
var dict = items.GroupBy(x => x.Item1)
                .ToDictionary(g => g.Key, g => g.Last().Item2);
```

### 4. null как ключ
```csharp
var dict = new Dictionary<string, int>();

// ПЛОХО — ArgumentNullException!
dict[null] = 1;  // 💥

// Dictionary НЕ допускает null в качестве ключа
// (в отличие от HashMap в Java, который допускает один null-ключ)
```

---

## Вопросы на собесе

**Q: Чем Dictionary отличается от Hashtable?**
> `Dictionary<K,V>` — generic, типобезопасный, быстрее. `Hashtable` — non-generic, boxing/unboxing, устаревший.

**Q: Какая сложность операций Dictionary?**
> Добавление, получение, удаление — O(1) в среднем. В худшем случае O(n) из-за коллизий.

**Q: Что будет если изменить ключ после добавления?**
> Элемент "потеряется" — хэш изменится, но в Dictionary останется старый. **Ключи должны быть immutable!**

**Q: Как работает Dictionary внутри?**
> Массив бакетов + массив entries. Хэш ключа определяет бакет. Коллизии разрешаются цепочками.

**Q: Когда использовать Dictionary, когда HashSet?**
> `HashSet` — только уникальные ключи (без значений). `Dictionary` — пары ключ-значение.

**Q: Как сделать Dictionary с case-insensitive ключами?**
```csharp
var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
dict["Apple"] = 1;
Console.WriteLine(dict["APPLE"]);  // 1
```

---

## Чек-лист для собеса

- [ ] Add vs [] — когда что использовать
- [ ] TryGetValue vs [] — безопасное получение
- [ ] Сложность операций O(1)
- [ ] Нельзя изменять коллекцию при итерации
- [ ] Ключи должны быть immutable
- [ ] null не может быть ключом
- [ ] ToDictionary с дубликатами — исключение
- [ ] ConcurrentDictionary для многопоточности
- [ ] Кастомный Comparer для ключей

