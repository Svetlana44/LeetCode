using System.Text;
using Allure.Net.Commons;

namespace NordCodes;

/// <summary>
/// Вспомогательный класс для работы с Allure отчётами
/// </summary>
public static class AllureHelper
{
    /// <summary>
    /// Выполнить шаг теста с логированием в Allure
    /// </summary>
    public static void Step(string name, Action action)
    {
        AllureApi.Step(name, action);
    }

    /// <summary>
    /// Прикрепить текстовый файл к отчёту
    /// </summary>
    public static void AttachText(string name, string content)
    {
        AllureApi.AddAttachment(name, "text/plain", Encoding.UTF8.GetBytes(content));
    }

    /// <summary>
    /// Прикрепить JSON к отчёту
    /// </summary>
    public static void AttachJson(string name, string json)
    {
        AllureApi.AddAttachment(name, "application/json", Encoding.UTF8.GetBytes(json));
    }

    /// <summary>
    /// Прикрепить скриншот к отчёту
    /// </summary>
    public static void AttachScreenshot(string name, byte[] screenshot)
    {
        AllureApi.AddAttachment(name, "image/png", screenshot);
    }

    /// <summary>
    /// Прикрепить произвольные бинарные данные
    /// </summary>
    public static void AttachBinary(string name, string mimeType, byte[] data)
    {
        AllureApi.AddAttachment(name, mimeType, data);
    }
}

