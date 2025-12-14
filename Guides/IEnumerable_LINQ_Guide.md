# IEnumerable & LINQ — Гайд для Senior C# QA (Java → C#)

## Быстрая таблица соответствий Java ↔ C#

| Java Stream | C# LINQ | Описание |
|-------------|---------|----------|
| `stream()` | просто используй коллекцию | В C# LINQ работает напрямую |
| `.filter()` | `.Where()` | Фильтрация |
| `.map()` | `.Select()` | Преобразование |
| `.flatMap()` | `.SelectMany()` | Развёртка вложенных коллекций |
| `.sorted()` | `.OrderBy()` / `.OrderByDescending()` | Сортировка |
| `.distinct()` | `.Distinct()` | Уникальные элементы |
| `.limit()` | `.Take()` | Взять первые N |
| `.skip()` | `.Skip()` | Пропустить N |
| `.count()` | `.Count()` | Количество |
| `.findFirst()` | `.First()` / `.FirstOrDefault()` | Первый элемент |
| `.findAny()` | `.First()` | Любой элемент |
| `.anyMatch()` | `.Any()` | Есть ли совпадение |
| `.allMatch()` | `.All()` | Все ли совпадают |
| `.noneMatch()` | `!.Any()` | Нет совпадений |
| `.collect(toList())` | `.ToList()` | В список |
| `.toArray()` | `.ToArray()` | В массив |
| `.forEach()` | `.ForEach()` (только List) или foreach | Итерация |
| `.reduce()` | `.Aggregate()` | Свёртка |
| `.max()` / `.min()` | `.Max()` / `.Min()` | Макс/мин |
| `.sum()` | `.Sum()` | Сумма |
| `.average()` | `.Average()` | Среднее |
| `Collectors.groupingBy()` | `.GroupBy()` | Группировка |
| `Collectors.toMap()` | `.ToDictionary()` | В словарь |

---

## IEnumerable vs ICollection vs IList

```
IEnumerable<T>      — только перебор (foreach), ЛЕНИВЫЙ
    ↓
ICollection<T>      — + Count, Add, Remove, Contains
    ↓
IList<T>            — + индексатор [i], Insert, RemoveAt
    ↓
List<T>             — конкретная реализация
```

### Что спрашивают на собесе:

**Q: Что такое IEnumerable?**
> Интерфейс для перебора коллекции. Имеет один метод `GetEnumerator()`, который возвращает `IEnumerator`.

**Q: Разница IEnumerable vs IQueryable?**
> - `IEnumerable` — выполняется в памяти (LINQ to Objects)
> - `IQueryable` — транслируется в SQL (LINQ to SQL/EF), выполняется на сервере БД

**Q: Что такое отложенное (ленивое) выполнение?**
> LINQ-запрос НЕ выполняется при создании. Выполняется только при итерации (foreach) или вызове терминального метода (ToList, Count, First).

---

## IEnumerator — что это и зачем

### Интерфейс IEnumerator<T>
```csharp
public interface IEnumerator<T> : IDisposable
{
    T Current { get; }           // Текущий элемент
    bool MoveNext();             // Перейти к следующему (true если есть)
    void Reset();                // Сбросить на начало (редко используется)
}
```

### Связь IEnumerable и IEnumerator
```csharp
public interface IEnumerable<T>
{
    IEnumerator<T> GetEnumerator();  // Возвращает "курсор" для перебора
}
```

**Аналогия:** 
- `IEnumerable` — это **книга** (коллекция страниц)
- `IEnumerator` — это **закладка** (указатель на текущую страницу)

### Как foreach работает под капотом
```csharp
// Это:
foreach (var item in collection)
{
    Console.WriteLine(item);
}

// Компилятор превращает в это:
IEnumerator<T> enumerator = collection.GetEnumerator();
try
{
    while (enumerator.MoveNext())
    {
        var item = enumerator.Current;
        Console.WriteLine(item);
    }
}
finally
{
    enumerator.Dispose();  // IEnumerator<T> наследует IDisposable
}
```

### Зачем нужен IEnumerator напрямую?

**1. Ручной контроль итерации:**
```csharp
var enumerator = list.GetEnumerator();

enumerator.MoveNext();
var first = enumerator.Current;  // Первый элемент

enumerator.MoveNext();
var second = enumerator.Current;  // Второй элемент
// Можно остановиться в любой момент
```

**2. Параллельный перебор нескольких коллекций:**
```csharp
var enum1 = list1.GetEnumerator();
var enum2 = list2.GetEnumerator();

while (enum1.MoveNext() && enum2.MoveNext())
{
    Console.WriteLine($"{enum1.Current} - {enum2.Current}");
}
```

**3. Создание своего итератора (без yield):**
```csharp
public class CountdownEnumerator : IEnumerator<int>
{
    private int _current;
    private readonly int _start;
    
    public CountdownEnumerator(int start) => _start = _current = start + 1;
    
    public int Current => _current;
    object IEnumerator.Current => Current;
    
    public bool MoveNext() => --_current >= 0;
    public void Reset() => _current = _start + 1;
    public void Dispose() { }
}
```

### Вопросы на собесе:

**Q: Зачем GetEnumerator() возвращает новый объект каждый раз?**
> Чтобы можно было иметь несколько независимых "курсоров" на одну коллекцию. Каждый foreach создаёт свой enumerator.

**Q: Почему IEnumerator<T> наследует IDisposable?**
> Для освобождения ресурсов после итерации. Например, при чтении из файла или БД нужно закрыть соединение.

**Q: Что будет если изменить коллекцию во время итерации?**
> `InvalidOperationException: Collection was modified`. Enumerator отслеживает версию коллекции.

---

## Deferred vs Immediate Execution (КРИТИЧНО!)

### Отложенное выполнение (Deferred)
```csharp
var query = list.Where(x => x > 5);  // НЕ выполняется!
// ... list изменился ...
var result = query.ToList();          // Выполняется ЗДЕСЬ
```

**Deferred методы:** `Where`, `Select`, `SelectMany`, `OrderBy`, `Take`, `Skip`, `GroupBy`, `Join`, `Distinct`

### Немедленное выполнение (Immediate)
```csharp
var count = list.Where(x => x > 5).Count();  // Выполняется СРАЗУ
```

**Immediate методы:** `ToList`, `ToArray`, `ToDictionary`, `Count`, `First`, `Last`, `Single`, `Any`, `All`, `Sum`, `Max`, `Min`, `Average`

### Ловушка на собесе:
```csharp
var numbers = new List<int> { 1, 2, 3 };
var query = numbers.Where(x => x > 1);

numbers.Add(4);  // Добавили элемент

// Сколько элементов? 
Console.WriteLine(query.Count());  // 3! (2, 3, 4) — а не 2!
```

---

## LINQ Синтаксис: Query vs Method

```csharp
// Query синтаксис (SQL-like)
var result = from user in users
             where user.Age > 18
             orderby user.Name
             select user.Email;

// Method синтаксис (fluent) — ИСПОЛЬЗУЙ ЭТОТ
var result = users
    .Where(user => user.Age > 18)
    .OrderBy(user => user.Name)
    .Select(user => user.Email);
```

---

## Основные методы LINQ с примерами

### Where — фильтрация
```csharp
var adults = users.Where(u => u.Age >= 18);
var active = users.Where(u => u.IsActive && u.Role == "Admin");
```

### Select — преобразование (map)

**Базовое использование:**
```csharp
var names = users.Select(u => u.Name);
var dtos = users.Select(u => new UserDto { Id = u.Id, Name = u.Name });
```

#### Перегрузка Select с индексом

```csharp
// Сигнатура: Select<T, TResult>(Func<T, int, TResult> selector)
//                                    ↑    ↑
//                                 element index

var fruits = new[] { "apple", "banana", "cherry" };

// Получаем и элемент, и его индекс
var indexed = fruits.Select((item, index) => $"{index}: {item}");
// ["0: apple", "1: banana", "2: cherry"]

// Использовать индекс в вычислениях
var multiplied = numbers.Select((n, i) => n * i);
// numbers = [10, 20, 30]
// result  = [10*0, 20*1, 30*2] = [0, 20, 60]

// Фильтрация по индексу (каждый второй)
var everySecond = items.Select((item, i) => (item, i))
                       .Where(x => x.i % 2 == 0)
                       .Select(x => x.item);
```

**Когда нужен индекс:**
```csharp
// 1. Нумерация элементов
var numbered = items.Select((item, i) => $"{i + 1}. {item}");

// 2. Сравнение с предыдущим/следующим
var diffs = numbers.Select((n, i) => i == 0 ? 0 : n - numbers[i - 1]);

// 3. Позиционная логика
var positioned = items.Select((item, i) => new 
{
    Item = item,
    IsFirst = i == 0,
    IsLast = i == items.Length - 1,
    Position = i + 1
});
```

#### Другие методы LINQ с перегрузкой индекса

```csharp
// Where с индексом
var evenPositions = items.Where((item, index) => index % 2 == 0);
// Элементы на чётных позициях: [0], [2], [4]...

// SkipWhile / TakeWhile с индексом
var afterThird = items.SkipWhile((item, index) => index < 3);
// Пропустить первые 3, взять остальные

// Aggregate с индексом — НЕТ перегрузки!
// Но можно через Select:
var result = items.Select((item, i) => (item, i))
                  .Aggregate(...);
```

**Java эквивалент (нет встроенного индекса):**
```java
// Нужен AtomicInteger или IntStream
AtomicInteger index = new AtomicInteger(0);
list.stream()
    .map(item -> index.getAndIncrement() + ": " + item)
    .collect(toList());

// Или через IntStream
IntStream.range(0, list.size())
    .mapToObj(i -> i + ": " + list.get(i))
    .collect(toList());
```

### SelectMany — развёртка (flatMap)
```csharp
// У каждого юзера список заказов
var allOrders = users.SelectMany(u => u.Orders);

// Java эквивалент: users.stream().flatMap(u -> u.getOrders().stream())
```

### OrderBy / OrderByDescending / ThenBy
```csharp
var sorted = users
    .OrderBy(u => u.LastName)
    .ThenBy(u => u.FirstName)
    .ThenByDescending(u => u.Age);
```

### First / FirstOrDefault / Single / SingleOrDefault
```csharp
var first = users.First();                    // Exception если пусто
var firstOrNull = users.FirstOrDefault();     // null если пусто
var single = users.Single(u => u.Id == 5);    // Exception если 0 или >1
var singleOrNull = users.SingleOrDefault();   // null если 0, Exception если >1
```

**Собес:** Когда Single, когда First?
> `Single` — ожидаем РОВНО один элемент (ID в БД). `First` — берём первый из возможных многих.

### Any / All
```csharp
bool hasAdmins = users.Any(u => u.Role == "Admin");
bool allActive = users.All(u => u.IsActive);
bool isEmpty = !users.Any();  // проверка на пустоту
```

### Count / Sum / Average / Min / Max
```csharp
int count = users.Count(u => u.IsActive);
int totalAge = users.Sum(u => u.Age);
double avgAge = users.Average(u => u.Age);
int maxAge = users.Max(u => u.Age);
var oldest = users.MaxBy(u => u.Age);  // C# 10+
```

### GroupBy — группировка (GROUP BY из SQL)

**Что делает:** Группирует элементы по ключу. Возвращает `IEnumerable<IGrouping<TKey, TElement>>`.

```csharp
// ===== ИСХОДНЫЕ ДАННЫЕ =====

var users = new[]
{
    new { Id = 1, Name = "Alice",   Role = "Admin" },
    new { Id = 2, Name = "Bob",     Role = "User" },
    new { Id = 3, Name = "Charlie", Role = "Admin" },
    new { Id = 4, Name = "Diana",   Role = "User" },
    new { Id = 5, Name = "Eve",     Role = "User" }
};

// ===== GROUPBY =====

var byRole = users.GroupBy(u => u.Role);

// ===== ЧТО ПОЛУЧИЛОСЬ =====
// byRole — это IEnumerable<IGrouping<string, User>>
//
// Группа 1: Key = "Admin"
//   ├── { Id = 1, Name = "Alice",   Role = "Admin" }
//   └── { Id = 3, Name = "Charlie", Role = "Admin" }
//
// Группа 2: Key = "User"
//   ├── { Id = 2, Name = "Bob",   Role = "User" }
//   ├── { Id = 4, Name = "Diana", Role = "User" }
//   └── { Id = 5, Name = "Eve",   Role = "User" }
```

**Что такое IGrouping<TKey, TElement>?**
```csharp
public interface IGrouping<TKey, TElement> : IEnumerable<TElement>
{
    TKey Key { get; }  // Ключ группы ("Admin", "User")
}
// IGrouping — это коллекция элементов + свойство Key
```

**Итерация по группам:**
```csharp
foreach (var group in byRole)
{
    Console.WriteLine($"=== {group.Key} ===");  // Key = "Admin" или "User"
    
    foreach (var user in group)  // group — это IEnumerable<User>
    {
        Console.WriteLine($"  {user.Name}");
    }
}

// Вывод:
// === Admin ===
//   Alice
//   Charlie
// === User ===
//   Bob
//   Diana
//   Eve
```

**Преобразование в Dictionary:**
```csharp
// Ключ → Список объектов
var dict = users.GroupBy(u => u.Role)
                .ToDictionary(g => g.Key, g => g.ToList());
// { "Admin": [Alice, Charlie], "User": [Bob, Diana, Eve] }

// Ключ → Только имена
var dict = users.GroupBy(u => u.Role)
                .ToDictionary(g => g.Key, g => g.Select(u => u.Name).ToList());
// { "Admin": ["Alice", "Charlie"], "User": ["Bob", "Diana", "Eve"] }

// Ключ → Количество
var dict = users.GroupBy(u => u.Role)
                .ToDictionary(g => g.Key, g => g.Count());
// { "Admin": 2, "User": 3 }
```

**Агрегация по группам:**
```csharp
var stats = users.GroupBy(u => u.Role)
                 .Select(g => new
                 {
                     Role = g.Key,
                     Count = g.Count(),
                     Names = string.Join(", ", g.Select(u => u.Name))
                 });

// { Role = "Admin", Count = 2, Names = "Alice, Charlie" }
// { Role = "User",  Count = 3, Names = "Bob, Diana, Eve" }
```

**Аналог в SQL:**
```sql
SELECT Role, COUNT(*) as Count
FROM Users
GROUP BY Role
```

**Java эквивалент:**
```java
Map<String, List<User>> byRole = users.stream()
    .collect(Collectors.groupingBy(User::getRole));
```

**⚠️ Частая ошибка — забыть что group это коллекция:**
```csharp
// ПЛОХО — пытаемся обратиться к user напрямую
var result = users.GroupBy(u => u.Role)
                  .Select(g => g.Name);  // ❌ Ошибка! g — это группа, не user

// ХОРОШО — итерируем по группе
var result = users.GroupBy(u => u.Role)
                  .Select(g => g.First().Name);  // ✅ Берём первого из группы
```

### Join — соединение (INNER JOIN из SQL)

**Что делает:** Соединяет две коллекции по общему ключу (как INNER JOIN в SQL).

```csharp
// ===== ИСХОДНЫЕ ДАННЫЕ =====

// Таблица пользователей
var users = new[]
{
    new { Id = 1, Name = "Alice" },
    new { Id = 2, Name = "Bob" },
    new { Id = 3, Name = "Charlie" }  // У Charlie нет заказов!
};

// Таблица заказов
var orders = new[]
{
    new { OrderId = 101, UserId = 1, Total = 250 },   // Заказ Alice
    new { OrderId = 102, UserId = 1, Total = 150 },   // Ещё заказ Alice
    new { OrderId = 103, UserId = 2, Total = 350 },   // Заказ Bob
    new { OrderId = 104, UserId = 99, Total = 50 }    // Несуществующий юзер!
};

// ===== JOIN =====

var result = users.Join(
    orders,                              // 1. Вторая коллекция
    user => user.Id,                     // 2. Ключ из первой (users)
    order => order.UserId,               // 3. Ключ из второй (orders)
    (user, order) => new                 // 4. Что создать из пары
    { 
        user.Name, 
        order.Total 
    }
);

// ===== РЕЗУЛЬТАТ =====
// { Name = "Alice", Total = 250 }
// { Name = "Alice", Total = 150 }
// { Name = "Bob",   Total = 350 }
//
// ❌ Charlie НЕТ — у него нет заказов (INNER JOIN)
// ❌ Заказ 104 НЕТ — UserId = 99 не существует
```

**Сигнатура метода:**
```csharp
outerCollection.Join(
    innerCollection,           // С чем соединяем
    outer => outer.Key,        // Ключ из внешней коллекции
    inner => inner.Key,        // Ключ из внутренней коллекции
    (outer, inner) => result   // Что вернуть для каждой пары
);
```

**Аналог в SQL:**
```sql
SELECT u.Name, o.Total
FROM Users u
INNER JOIN Orders o ON u.Id = o.UserId
```

**Java эквивалент (нет прямого, нужен flatMap):**
```java
users.stream()
    .flatMap(user -> orders.stream()
        .filter(order -> order.getUserId() == user.getId())
        .map(order -> new Result(user.getName(), order.getTotal())))
    .collect(toList());
```

### GroupJoin — LEFT JOIN с группировкой

```csharp
// Если нужен LEFT JOIN (все users, даже без заказов):
var result = users.GroupJoin(
    orders,
    user => user.Id,
    order => order.UserId,
    (user, userOrders) => new 
    { 
        user.Name, 
        OrderCount = userOrders.Count(),
        TotalSpent = userOrders.Sum(o => o.Total)
    }
);

// Результат:
// { Name = "Alice",   OrderCount = 2, TotalSpent = 400 }
// { Name = "Bob",     OrderCount = 1, TotalSpent = 350 }
// { Name = "Charlie", OrderCount = 0, TotalSpent = 0 }  // ✅ Charlie есть!
```

### Distinct / DistinctBy
```csharp
var unique = numbers.Distinct();
var uniqueByName = users.DistinctBy(u => u.Name);  // C# 10+
```

### Take / Skip / TakeLast / SkipLast
```csharp
var first10 = users.Take(10);
var skip5 = users.Skip(5);
var page = users.Skip(20).Take(10);  // пагинация
var last3 = users.TakeLast(3);
```

### Aggregate — свёртка (reduce)
```csharp
// Сумма
int sum = numbers.Aggregate((a, b) => a + b);

// Конкатенация строк
string joined = words.Aggregate((a, b) => a + ", " + b);

// С начальным значением
int sumPlus100 = numbers.Aggregate(100, (acc, x) => acc + x);
```

### Zip — объединение по парам
```csharp
var names = new[] { "Alice", "Bob" };
var ages = new[] { 25, 30 };

var pairs = names.Zip(ages, (name, age) => $"{name} is {age}");
// ["Alice is 25", "Bob is 30"]
```

### Concat / Union / Intersect / Except
```csharp
var all = list1.Concat(list2);           // Все элементы (с дубликатами)
var union = list1.Union(list2);          // Уникальные из обоих
var common = list1.Intersect(list2);     // Общие
var diff = list1.Except(list2);          // Только в list1
```

---

## yield return — генераторы

```csharp
public IEnumerable<int> GetNumbers()
{
    yield return 1;
    yield return 2;
    yield return 3;
}

// Ленивая генерация — элементы создаются по требованию
public IEnumerable<int> InfiniteNumbers()
{
    int i = 0;
    while (true)
        yield return i++;
}

// Использование
var first10 = InfiniteNumbers().Take(10).ToList();
```

**Собес:** Что делает yield?
> Превращает метод в генератор (итератор). При каждом вызове MoveNext() выполнение продолжается до следующего yield return.

---

## Частые ошибки и ловушки

### 1. Множественное перечисление
```csharp
// ПЛОХО — query выполняется 2 раза!
IEnumerable<User> query = GetUsers().Where(u => u.IsActive);
Console.WriteLine(query.Count());
foreach (var u in query) { }

// ХОРОШО — материализуем один раз
var users = GetUsers().Where(u => u.IsActive).ToList();
Console.WriteLine(users.Count);
foreach (var u in users) { }
```

### 2. Модификация коллекции при итерации
```csharp
// EXCEPTION!
foreach (var item in list)
    if (item.IsOld) list.Remove(item);

// ПРАВИЛЬНО
list.RemoveAll(item => item.IsOld);
// или
var toRemove = list.Where(x => x.IsOld).ToList();
foreach (var item in toRemove) list.Remove(item);
```

### 3. Замыкание переменной в цикле
```csharp
// ПЛОХО (до C# 5)
var actions = new List<Action>();
for (int i = 0; i < 3; i++)
    actions.Add(() => Console.WriteLine(i));

actions.ForEach(a => a());  // 3, 3, 3 — а не 0, 1, 2!

// В современном C# это исправлено для foreach, но осторожно с for
```

### 4. FirstOrDefault и value types
```csharp
var numbers = new List<int>();
int first = numbers.FirstOrDefault();  // 0, а не null!

// Как понять что элемента не было?
// Вариант 1: проверить заранее
if (!numbers.Any()) { /* пусто */ }

// Вариант 2: сделать nullable
int? first = numbers.Cast<int?>().FirstOrDefault();  // null если пусто
```

**Что такое `int?` (знак вопроса)?**

`int?` — это **Nullable<int>**, позволяет хранить `null` в value type.

```csharp
// Обычный int — НЕ может быть null
int a = 5;
int b = null;  // ❌ Ошибка компиляции!

// Nullable int — МОЖЕТ быть null
int? c = 5;
int? d = null;  // ✅ OK

// Проверка
if (d.HasValue)
    Console.WriteLine(d.Value);  // Получить значение
else
    Console.WriteLine("null");

// Или короче (null-coalescing)
int result = d ?? 0;  // Если d == null, то 0
```

**Зачем Cast<int?>() перед FirstOrDefault?**

```csharp
var numbers = new List<int>();  // Пустой список

// Проблема: FirstOrDefault для int возвращает 0
int first = numbers.FirstOrDefault();
// first = 0 — но это default(int), НЕ означает что элемент найден!
// Невозможно отличить "нашли 0" от "список пуст"

// Решение: преобразуем int → int?
int? firstNullable = numbers.Cast<int?>().FirstOrDefault();
// firstNullable = null — теперь ясно что список пуст!

if (firstNullable == null)
    Console.WriteLine("Список пуст");
else
    Console.WriteLine($"Первый элемент: {firstNullable.Value}");
```

**Java эквивалент:**
```java
// В Java примитивы тоже не могут быть null
// Используют Optional или boxed Integer
Optional<Integer> first = numbers.stream().findFirst();
Integer first = numbers.isEmpty() ? null : numbers.get(0);
```

---

## Сравнение производительности

| Операция | Сложность |
|----------|-----------|
| `Where` | O(n) ленивый |
| `Select` | O(n) ленивый |
| `OrderBy` | O(n log n) |
| `First` | O(1) - O(n) |
| `Count()` без параметров | O(1) для ICollection, O(n) для IEnumerable |
| `Any()` | O(1) |
| `ToList/ToArray` | O(n) |
| `Contains` (List) | O(n) |
| `Contains` (HashSet) | O(1) |

---

## AsEnumerable / AsQueryable / Cast / OfType

```csharp
// AsEnumerable — переключает с IQueryable на IEnumerable (с БД в память)
var inMemory = dbContext.Users
    .Where(u => u.IsActive)    // SQL
    .AsEnumerable()
    .Where(u => ComplexLogic(u));  // В памяти

// Cast — приводит каждый элемент к типу (exception если не может)
IEnumerable objects = GetObjects();
var strings = objects.Cast<string>();

// OfType — фильтрует и приводит (без exception)
var onlyStrings = objects.OfType<string>();
```

---

## Полезное для автотестов

### Проверки коллекций (NUnit/xUnit)
```csharp
// Все элементы соответствуют
Assert.That(users.All(u => u.IsValid), Is.True);

// Содержит элемент
Assert.That(list, Contains.Item(expectedItem));

// Коллекции равны (порядок важен)
Assert.That(actual, Is.EqualTo(expected));

// Коллекции равны (порядок не важен)
Assert.That(actual, Is.EquivalentTo(expected));

// Проверка количества
Assert.That(list, Has.Count.EqualTo(5));
Assert.That(list, Has.Exactly(3).Items.Matches<User>(u => u.IsActive));
```

### Генерация тестовых данных

#### Enumerable.Range — генератор последовательности чисел

```csharp
// Enumerable.Range(start, count) — генерирует count чисел начиная со start
Enumerable.Range(1, 5)   // → [1, 2, 3, 4, 5]
Enumerable.Range(0, 3)   // → [0, 1, 2]
Enumerable.Range(10, 4)  // → [10, 11, 12, 13]

// ⚠️ Это НЕ диапазон от 1 до 100, а 100 чисел начиная с 1!
Enumerable.Range(1, 100)  // → [1, 2, 3, ..., 100]
```

**Java эквивалент:**
```java
IntStream.range(1, 6)      // → [1, 2, 3, 4, 5] (exclusive end)
IntStream.rangeClosed(1, 5) // → [1, 2, 3, 4, 5] (inclusive end)
```

#### Создание тестовых объектов

```csharp
// Генерируем 100 пользователей
var testUsers = Enumerable.Range(1, 100)
    .Select(i => new User { Id = i, Name = $"User{i}" })
    .ToList();

// Что получилось:
// [
//   { Id = 1,   Name = "User1" },
//   { Id = 2,   Name = "User2" },
//   { Id = 3,   Name = "User3" },
//   ...
//   { Id = 100, Name = "User100" }
// ]
```

**Разбор по шагам:**
```csharp
Enumerable.Range(1, 100)  // 1. Генерируем числа [1, 2, 3, ..., 100]
    .Select(i => ...)     // 2. Каждое число i преобразуем в объект
    .ToList();            // 3. Материализуем в List<User>
```

**$"User{i}" — интерполяция строк:**
```csharp
int i = 42;
string s = $"User{i}";  // → "User42"

// Java эквивалент:
String s = "User" + i;          // конкатенация
String s = String.format("User%d", i);  // форматирование
```

#### Случайная выборка (shuffle + take)

```csharp
var randomSubset = testUsers
    .OrderBy(_ => Guid.NewGuid())  // Перемешиваем случайно
    .Take(10)                       // Берём первые 10
    .ToList();
```

**Разбор:**
```csharp
.OrderBy(_ => Guid.NewGuid())
//       ↑
//       _ — "отбрасываем" параметр, он нам не нужен
//           (user не используется, нужен только случайный ключ)
//
// Guid.NewGuid() — генерирует уникальный случайный идентификатор
// Каждый вызов = новый GUID = случайная сортировка

.Take(10)  // Берём 10 элементов из перемешанного списка
```

**Почему `_` (underscore)?**
```csharp
// Когда параметр не используется, принято называть его _
.OrderBy(_ => Guid.NewGuid())      // ✅ Ясно что user не нужен
.OrderBy(user => Guid.NewGuid())   // ⚠️ Зачем user если не используем?

// Другие примеры:
list.Select((_, index) => index)   // Нужен только индекс
```

#### Ещё примеры генерации тестовых данных

```csharp
// Список случайных чисел
var randomNumbers = Enumerable.Range(0, 50)
    .Select(_ => Random.Shared.Next(1, 100))
    .ToList();

// Список дат (последние 30 дней)
var dates = Enumerable.Range(0, 30)
    .Select(i => DateTime.Today.AddDays(-i))
    .ToList();

// Список с разными статусами
var statuses = new[] { "Active", "Pending", "Closed" };
var items = Enumerable.Range(1, 20)
    .Select(i => new 
    { 
        Id = i, 
        Status = statuses[i % statuses.Length]  // Циклически
    })
    .ToList();

// Enumerable.Repeat — повторить элемент N раз
var fiveZeros = Enumerable.Repeat(0, 5).ToList();  // [0, 0, 0, 0, 0]
var fiveHellos = Enumerable.Repeat("Hello", 5).ToList();

// Enumerable.Empty — пустая коллекция нужного типа
IEnumerable<User> empty = Enumerable.Empty<User>();
```

### Ожидание условия (для UI/API тестов)
```csharp
// Ждём пока появится элемент
var element = await WaitUntil(() => 
    elements.FirstOrDefault(e => e.IsDisplayed));

// Ждём пока все загрузятся
await WaitUntil(() => items.All(i => i.IsLoaded));
```

---

## Чек-лист для собеса

- [ ] Разница IEnumerable vs IQueryable
- [ ] Отложенное vs немедленное выполнение
- [ ] Когда использовать First vs Single vs FirstOrDefault
- [ ] Что такое yield return
- [ ] Опасность множественного перечисления
- [ ] Методы изменяющие коллекцию (Add, Remove) vs LINQ (создаёт новое)
- [ ] GroupBy — как работает, что возвращает
- [ ] SelectMany — для чего нужен
- [ ] Разница Any() vs Count() > 0 (производительность)

