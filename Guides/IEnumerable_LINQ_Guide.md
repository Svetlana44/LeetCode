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
```csharp
var names = users.Select(u => u.Name);
var dtos = users.Select(u => new UserDto { Id = u.Id, Name = u.Name });

// С индексом
var indexed = list.Select((item, index) => $"{index}: {item}");
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

### GroupBy
```csharp
var byRole = users.GroupBy(u => u.Role);

foreach (var group in byRole)
{
    Console.WriteLine($"Role: {group.Key}");
    foreach (var user in group)
        Console.WriteLine($"  {user.Name}");
}

// В Dictionary
var dict = users.GroupBy(u => u.Role)
                .ToDictionary(g => g.Key, g => g.ToList());
```

### Join — соединение
```csharp
var result = users.Join(
    orders,
    user => user.Id,
    order => order.UserId,
    (user, order) => new { user.Name, order.Total }
);
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

// Проверка
if (!numbers.Any()) { /* пусто */ }
// или
int? first = numbers.Cast<int?>().FirstOrDefault();
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
```csharp
var testUsers = Enumerable.Range(1, 100)
    .Select(i => new User { Id = i, Name = $"User{i}" })
    .ToList();

var randomSubset = testUsers
    .OrderBy(_ => Guid.NewGuid())
    .Take(10)
    .ToList();
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

