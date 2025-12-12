using System.Security.Cryptography;
using System.Text;

namespace NordCodes;

/// <summary>
/// Класс с алгоритмическими задачами
/// </summary>
public static class MyClass
{
    /// <summary>
    /// Найти наименьший элемент в массиве.
    /// Оригинальный массив не изменяется.
    /// </summary>
    /// <param name="values">Входной массив</param>
    /// <returns>Минимальный элемент</returns>
    public static int Min(int[] values)
    {
        return values.Min();
    }

    /// <summary>
    /// Перевернуть строку
    /// </summary>
    /// <param name="s">Входная строка</param>
    /// <returns>Перевёрнутая строка</returns>
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    /// <summary>
    /// Вычисляет MD5 подпись от отсортированных значений + secret.
    /// </summary>
    /// <param name="values">Список пар ключ-значение: ["key1", "value1", "key2", "value2", ...]</param>
    /// <param name="secret">Секретная строка</param>
    /// <returns>MD5 хеш</returns>
    public static byte[] GetSign(List<string> values, string secret)
    {
        var dict = new Dictionary<string, string>();
        for (int i = 0; i < values.Count; i += 2)
        {
            dict[values[i]] = values[i + 1];
        }

        var sortedValues = dict
            .OrderBy(kv => kv.Key)
            .Select(kv => kv.Value);

        string concatenated = string.Join("", sortedValues) + secret;

        return ComputeMd5(concatenated);
    }

    private static byte[] ComputeMd5(string str)
    {
        using var md5 = MD5.Create();
        return md5.ComputeHash(Encoding.UTF8.GetBytes(str));
    }
}

