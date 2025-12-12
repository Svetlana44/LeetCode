using NUnit.Framework;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace NordCodes;

[TestFixture]
[AllureNUnit]
[AllureSuite("MyClass Tests")]
[AllureFeature("Базовые алгоритмы")]
public class MyClassTests
{
    [Test]
    [Description("Проверка поиска минимального элемента в массиве")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureTag("Array", "Min")]
    public void TestMin()
    {
        int[] expectedArray = [-1, 1, 4, 5, 2, 3, 9, 8, 11, 0, -10, 100];
        int[] actualArray = (int[])expectedArray.Clone();

        AllureHelper.Step("Подготовка тестовых данных", () =>
        {
            AllureHelper.AttachText("Исходный массив", string.Join(", ", expectedArray));
        });

        int min = 0;
        AllureHelper.Step("Вызов метода Min", () =>
        {
            min = MyClass.Min(actualArray);
        });

        AllureHelper.Step("Проверка результата", () =>
        {
            Assert.That(min, Is.EqualTo(-10), "Минимальный элемент должен быть -10");
            Assert.That(actualArray, Is.EqualTo(expectedArray), "Массив не должен измениться");
        });
    }

    [Test]
    [Description("Проверка переворота строки")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureTag("String", "Reverse")]
    public void TestReverse()
    {
        const string input = "Hello, World!";
        const string expected = "!dlroW ,olleH";

        string result = string.Empty;
        AllureHelper.Step($"Переворот строки '{input}'", () =>
        {
            result = MyClass.Reverse(input);
        });

        AllureHelper.Step("Проверка результата", () =>
        {
            Assert.That(result, Is.EqualTo(expected));
        });
    }

    [Test]
    [Description("Проверка вычисления MD5 подписи")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureTag("Crypto", "MD5", "Sign")]
    public void TestSign()
    {
        List<string> values = ["key1", "bbbb", "key2", "ffff", "aaa", "zzzz"];
        string secret = "qweQWEqwe";

        AllureHelper.Step("Подготовка входных данных", () =>
        {
            AllureHelper.AttachText("Values", string.Join(", ", values));
            AllureHelper.AttachText("Secret", secret);
        });

        byte[] result = null!;
        AllureHelper.Step("Вычисление подписи", () =>
        {
            result = MyClass.GetSign(values, secret);
        });

        AllureHelper.Step("Проверка результата", () =>
        {
            Assert.That(result, Is.Not.Null);
            string hex = Convert.ToHexString(result).ToLowerInvariant();
            AllureHelper.AttachText("Результат (hex)", hex);
            Assert.That(hex, Is.EqualTo("757b47ac0de073b83110c998b001fa37"));
        });
    }
}

