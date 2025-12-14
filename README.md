# LeetCode - Алгоритмы и Тестирование

Проект на .NET 10.0 с реализацией алгоритмических задач, unit-тестами на NUnit и отчётами Allure.

---

## 📁 Структура проекта

```
LeetCode/
├── 📂 Guides/                   # 📚 Гайды для собеседования
│   ├── IEnumerable_LINQ_Guide.md    # LINQ для Java-разработчиков
│   └── Dictionary_Guide.md          # Dictionary (Java Map → C#)
│
├── 📂 Tasks/                    # 🎯 Задачи в формате LeetCode
│   ├── LINQ/                    # LINQ задачи (Where, Select, GroupBy...)
│   │   ├── 01_Where_Tasks.cs
│   │   ├── 02_Select_Tasks.cs
│   │   ├── ...
│   │   └── 09_LINQ_Medium_Extra_Tasks.cs
│   └── Dictionary/              # Dictionary задачи
│       ├── 01_Dictionary_Basic_Tasks.cs
│       ├── 02_Dictionary_Medium_Tasks.cs
│       └── 03_Dictionary_Advanced_Tasks.cs
│
├── 📂 Tests/                    # Unit-тесты
│   ├── SortArray.cs             # Тесты на сортировку
│   └── ContainsArray.cs         # Тесты на поиск
│
├── 📂 NordCodes/                # Бизнес-логика и тесты
│   ├── MyClass.cs               # Алгоритмы
│   ├── MyClassTests.cs          # Unit-тесты
│   └── AllureHelper.cs          # Хелпер для Allure
│
├── 📂 Pages/                    # Razor Pages (UI слой)
│   ├── Index.cshtml             # Главная страница
│   ├── Index.cshtml.cs          # Page Model
│   ├── Privacy.cshtml           # Страница политики
│   ├── Error.cshtml             # Страница ошибок
│   └── Shared/                  # Общие компоненты
│       ├── _Layout.cshtml       # Основной layout
│       └── _Layout.cshtml.css   # Стили layout
│
├── 📂 wwwroot/                  # Статические файлы
│   ├── css/site.css             # Пользовательские стили
│   ├── js/site.js               # Пользовательские скрипты
│   └── lib/                     # Библиотеки (Bootstrap, jQuery)
│
├── 📂 Properties/
│   └── launchSettings.json      # Настройки запуска
│
├── 📄 Program.cs                # Точка входа приложения
├── 📄 allureConfig.json         # Конфигурация Allure
├── 📄 appsettings.json          # Конфигурация приложения
├── 📄 .gitignore                # Исключения для Git
└── 📄 LeetCode.csproj           # Файл проекта
```

---

## 📚 Гайды для собеседования (Guides/)

Подробные туториалы для подготовки к собесу **Senior C# QA Automation**.
Адаптированы для переходящих с Java.

| Гайд | Описание | Темы |
|------|----------|------|
| `IEnumerable_LINQ_Guide.md` | LINQ для Java-разработчиков | IEnumerable vs IQueryable, Deferred Execution, все методы LINQ, yield, ловушки |
| `Dictionary_Guide.md` | Dictionary (HashMap → C#) | Add vs [], TryGetValue, LINQ с Dictionary, паттерны, ConcurrentDictionary |
| `Collections_Guide.md` | **Все коллекции C#** | Иерархия интерфейсов, List/HashSet/Queue/Stack/LinkedList, когда что использовать |

### Содержание LINQ гайда:
- ✅ Таблица соответствий Java Stream ↔ C# LINQ
- ✅ IEnumerable / IEnumerator — как работает foreach
- ✅ Deferred vs Immediate Execution (критично для собеса!)
- ✅ Все методы: Where, Select, SelectMany, GroupBy, Join, Aggregate...
- ✅ Select/Where с индексом `(item, index) => ...`
- ✅ yield return — генераторы
- ✅ Частые ошибки и ловушки
- ✅ Nullable types (`int?`) и FirstOrDefault
- ✅ Генерация тестовых данных
- ✅ Чек-лист вопросов на собес

---

## 🎯 Задачи в формате LeetCode (Tasks/)

Практические задачи для закрепления материала. Формат как на LeetCode:
- Описание задачи в ASCII-рамке
- Примеры Input/Output
- Hint с подсказкой
- Готовые NUnit тесты

### LINQ задачи (`Tasks/LINQ/`)

| Файл | Тема | Задачи |
|------|------|--------|
| `01_Where_Tasks.cs` | Where | Filter Even, Filter By Length, Filter In Range |
| `02_Select_Tasks.cs` | Select | Square Numbers, First Letters, Add Index |
| `03_SelectMany_Tasks.cs` | SelectMany | Flatten 2D, Split Sentences, Get All Chars |
| `04_OrderBy_Tasks.cs` | OrderBy | Sort By Abs, Sort By Length, Sort By Last Char |
| `05_GroupBy_Tasks.cs` | GroupBy | Group By Letter, Count By Length, Group By Remainder |
| `06_Aggregate_Tasks.cs` | Aggregate | Product, Join, Find Longest |
| `07_FirstSingle_Tasks.cs` | First/Single | First Greater, Find Unique, Safe Find |
| `08_AnyAll_Tasks.cs` | Any/All | Contains Negative, All Uppercase, Has Common |
| `09_LINQ_Medium_Extra_Tasks.cs` | **Medium LeetCode** | Top K Frequent, Two Sum, Group Anagrams... |
| `10_Collections_Tasks.cs` | **Коллекции** | List, HashSet, Queue, Stack, LinkedList |

### Dictionary задачи (`Tasks/Dictionary/`)

| Файл | Уровень | Задачи |
|------|---------|--------|
| `01_Dictionary_Basic_Tasks.cs` | Easy | Word Frequency, Two Sum (#1), First Unique Char (#387) |
| `02_Dictionary_Medium_Tasks.cs` | Medium | Group Anagrams (#49), Longest Consecutive (#128), Subarray Sum (#560) |
| `03_Dictionary_Advanced_Tasks.cs` | Hard | LRU Cache (#146), Design HashMap (#706), Copy Random List (#138) |

### Как решать задачи:

```csharp
// 1. Найди метод с throw new NotImplementedException()
public int[] FilterEvenNumbers(int[] nums)
{
    // Твоё решение здесь
    throw new NotImplementedException();
}

// 2. Замени на своё решение
public int[] FilterEvenNumbers(int[] nums)
{
    return nums.Where(n => n % 2 == 0).ToArray();
}

// 3. Запусти тесты
// dotnet test --filter "FilterEvenNumbers"
```

---

## 🏗️ Архитектура слоёв

### 1. Presentation Layer (Pages/)
Слой представления на основе **Razor Pages**.

| Файл | Назначение |
|------|------------|
| `_Layout.cshtml` | Мастер-страница с общей разметкой |
| `Index.cshtml` | Главная страница приложения |
| `Error.cshtml` | Обработка и отображение ошибок |

### 2. Business Logic Layer (NordCodes/MyClass.cs)
Содержит реализацию алгоритмов:

| Метод | Описание |
|-------|----------|
| `Min(int[] values)` | Поиск минимального элемента в массиве |
| `Reverse(string s)` | Переворот строки |
| `GetSign(List<string> values, string secret)` | Вычисление MD5-подписи |

### 3. Test Layer (NordCodes/MyClassTests.cs)
Unit-тесты с интеграцией **Allure**:

- Атрибуты для метаданных (`[Description]`, `[AllureSeverity]`)
- Шаги с логированием (`AllureHelper.Step()`)
- Прикрепление данных (`AllureHelper.AttachText()`)

### 4. Helpers (NordCodes/AllureHelper.cs)
Вспомогательный класс для работы с Allure:

| Метод | Описание |
|-------|----------|
| `Step(name, action)` | Создать шаг теста |
| `AttachText(name, content)` | Прикрепить текст |
| `AttachJson(name, json)` | Прикрепить JSON |
| `AttachScreenshot(name, bytes)` | Прикрепить скриншот |

---

## ⚡ Quick Start (Быстрый старт)

```powershell
# 1. Клонировать репозиторий
git clone <repository-url>
cd LeetCode

# 2. Восстановить пакеты
dotnet restore

# 3. Собрать проект
dotnet build

# 4. Запустить тесты
dotnet test

# 5. Открыть Allure отчёт (требуется Allure CLI)
allure serve allure-results
```

---

## 🚀 Запуск проекта

### Требования
| Компонент | Версия | Обязательно |
|-----------|--------|-------------|
| .NET SDK | 10.0+ | ✅ Да |
| Allure CLI | 2.x | ⭕ Для отчётов |

### Проверка .NET SDK
```powershell
dotnet --version
```

### Запуск веб-приложения
```powershell
# Из корня проекта
dotnet run

# Или с горячей перезагрузкой
dotnet watch run
```

📍 Приложение будет доступно:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

### Запуск тестов

```powershell
# Запуск всех тестов
dotnet test

# С подробным выводом
dotnet test --logger "console;verbosity=detailed"

# Запуск конкретного теста
dotnet test --filter "TestMin"

# Запуск тестов по тегу
dotnet test --filter "TestCategory=Crypto"
```

---

## 📊 Allure Reports — Формирование отчётов

### ⚠️ Обязательные атрибуты для Allure

Чтобы тесты попадали в Allure отчёт, класс должен иметь атрибут `[AllureNUnit]`:

```csharp
using Allure.NUnit;        // ← Добавить using
using NUnit.Framework;

[AllureNUnit]              // ← Обязательный атрибут!
public class MyTests
{
    [Test]
    public void MyTest() { }
}
```

**Без `[AllureNUnit]`** тесты выполнятся, но **не попадут в отчёт**!

### Дополнительные атрибуты Allure

```csharp
[Test]
[AllureDescription("Подробное описание теста")]
[AllureSeverity(SeverityLevel.critical)]     // blocker/critical/normal/minor/trivial
[AllureTag("LINQ", "Regression")]
[AllureOwner("Иван Иванов")]
[AllureIssue("JIRA-123")]                    // Ссылка на баг
[AllureTms("TMS-456")]                       // Ссылка на тест-кейс
public void MyTest() { }
```

### Шаги в тестах (Steps)

```csharp
[Test]
public void TestWithSteps()
{
    AllureApi.Step("Шаг 1: Подготовка данных", () =>
    {
        // код
    });
    
    AllureApi.Step("Шаг 2: Выполнение", () =>
    {
        // код
    });
    
    AllureApi.Step("Шаг 3: Проверка", () =>
    {
        Assert.That(result, Is.EqualTo(expected));
    });
}
```

---

### Шаг 1: Установка Allure CLI

**Windows (Scoop) — рекомендуется:**
```powershell
# Установить Scoop (если нет)
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
Invoke-RestMethod -Uri https://get.scoop.sh | Invoke-Expression

# Установить Allure
scoop install allure
```

**Windows (Chocolatey):**
```powershell
choco install allure
```

**Через npm (кроссплатформенно):**
```powershell
npm install -g allure-commandline
```

**Проверка установки:**
```powershell
allure --version
```

### Шаг 2: Запуск тестов

```powershell
cd C:\projects\LeetCode

# Очистить старые результаты (важно!)
Remove-Item allure-results -Recurse -Force -ErrorAction SilentlyContinue

# Запустить тесты
dotnet test
```

### Шаг 3: Просмотр отчёта

**Вариант A: Временный сервер (быстро посмотреть)**
```powershell
allure serve allure-results
```
> Откроется браузер с интерактивным отчётом. Сервер работает пока не нажмёте Ctrl+C.

**Вариант B: Статический HTML-отчёт (для CI/CD)**
```powershell
# Сгенерировать отчёт
allure generate allure-results -o allure-report --clean

# Открыть в браузере
allure open allure-report
```
> Папку `allure-report` можно загрузить на сервер или в CI артефакты.

### Полный цикл одной командой

```powershell
# Очистка → Тесты → Отчёт
Remove-Item allure-results -Recurse -Force -ErrorAction SilentlyContinue; dotnet test; allure serve allure-results
```

### 📍 Где находятся результаты?

После `dotnet test` результаты сохраняются в:
```
C:\projects\LeetCode\allure-results\
```

Содержимое папки:
```
allure-results/
├── *-result.json      # Результаты тестов
├── *-container.json   # Контейнеры (fixtures)
└── *-attachment       # Прикреплённые файлы
```

---

## 🎯 Тонкости работы с Allure

### Атрибуты тестов

```csharp
[Test]
[AllureDescription("Описание теста")]           // Подробное описание
[AllureSeverity(SeverityLevel.critical)]        // Приоритет
[AllureTag("Tag1", "Tag2")]                     // Теги для фильтрации
[AllureOwner("Иван Иванов")]                    // Ответственный
[AllureIssue("JIRA-123")]                       // Ссылка на баг
[AllureTms("TMS-456")]                          // Ссылка на тест-кейс
public void MyTest() { }
```

### Уровни Severity

| Уровень | Когда использовать |
|---------|-------------------|
| `blocker` | Блокирует работу системы |
| `critical` | Критический функционал |
| `normal` | Обычный функционал |
| `minor` | Незначительный функционал |
| `trivial` | Косметические проверки |

### Шаги (Steps)

```csharp
AllureApi.Step("Название шага", () =>
{
    // Код шага
});
```

**Вложенные шаги:**
```csharp
AllureApi.Step("Шаг 1", () =>
{
    AllureApi.Step("Вложенный шаг 1.1", () => { });
    AllureApi.Step("Вложенный шаг 1.2", () => { });
});
```

### Прикрепление файлов (Attachments)

```csharp
// Текст
AllureApi.AddAttachment("Название", "text/plain", "Содержимое");

// JSON
AllureApi.AddAttachment("Response", "application/json", jsonString);

// Скриншот
AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);

// Файл
AllureApi.AddAttachment("Log", "text/plain", File.ReadAllBytes("log.txt"));
```

### Параметризованные тесты

```csharp
[Test]
[TestCase("Hello", "olleH")]
[TestCase("World", "dlroW")]
public void TestReverse(string input, string expected)
{
    Assert.That(MyClass.Reverse(input), Is.EqualTo(expected));
}
```

### Категории ошибок (categories.json)

Создайте файл `allure-results/categories.json`:
```json
[
  {
    "name": "Ignored tests",
    "matchedStatuses": ["skipped"]
  },
  {
    "name": "Infrastructure problems",
    "matchedStatuses": ["broken", "failed"],
    "messageRegex": ".*timeout.*"
  },
  {
    "name": "Product defects",
    "matchedStatuses": ["failed"]
  }
]
```

### Очистка результатов

**⚠️ Важно:** Перед новым запуском очищайте папку `allure-results`:
```powershell
Remove-Item allure-results -Recurse -Force -ErrorAction SilentlyContinue
dotnet test
```

Иначе старые результаты будут смешиваться с новыми.

---

## 🔧 Конфигурация Allure

Файл `allureConfig.json`:
```json
{
  "allure": {
    "directory": "allure-results",
    "links": [
      "{link}",
      "{issue}",
      "{tms}"
    ]
  }
}
```

### Настройка ссылок на баг-трекер

```json
{
  "allure": {
    "directory": "allure-results",
    "links": [
      "https://jira.company.com/browse/{issue}",
      "https://tms.company.com/testcase/{tms}",
      "{link}"
    ]
  }
}
```

---

## 📦 Используемые пакеты

| Пакет | Версия | Назначение |
|-------|--------|------------|
| Microsoft.NET.Test.Sdk | 17.8.0 | SDK для тестов |
| NUnit | 4.2.2 | Фреймворк тестирования |
| NUnit3TestAdapter | 4.6.0 | Адаптер для VS/dotnet test |
| Allure.NUnit | 2.12.1 | Интеграция с Allure |

---

## 📝 Полезные команды

```powershell
# Сборка проекта
dotnet build

# Запуск тестов с подробным выводом
dotnet test --logger "console;verbosity=detailed"

# Запуск конкретного теста
dotnet test --filter "TestMin"

# Запуск тестов по категории
dotnet test --filter "TestCategory=Smoke"

# ⚡ Полный цикл Allure (очистка → тесты → отчёт)
Remove-Item allure-results -Recurse -Force -ErrorAction SilentlyContinue; dotnet test; allure serve allure-results

# Генерация отчёта Allure
allure serve allure-results
```

---

## 🐛 Частые проблемы

### Allure отчёт пустой
- Убедитесь, что `allureConfig.json` копируется в output (`CopyToOutputDirectory`)
- Проверьте, что атрибут `[AllureNUnit]` добавлен к классу тестов

### Тесты не обнаруживаются
- Выполните `dotnet restore`
- Убедитесь, что установлен `NUnit3TestAdapter`

### Ошибка "Test host process crashed"
- Проверьте статические конструкторы в тестовых классах
- Проверьте `[SetUpFixture]` на уровне сборки
- Используйте ленивую инициализацию для тяжёлых ресурсов

