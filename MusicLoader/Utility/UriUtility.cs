namespace MusicLoader.Utility;

/// <summary>
/// Сервис для операций над <see cref="Uri"/>.
/// </summary>
public sealed class UriUtility
{
    /// <summary>
    /// Получает название файла по его Url-адресу.
    /// </summary>
    /// <param name="source">Url-адрес файла.</param>
    /// <returns>Название файла.</returns>
    public static string GetFileNameFromUri(Uri source)
    {
        var result = Path.GetFileName(source.AbsoluteUri);

        if (string.IsNullOrWhiteSpace(result))
        {
            throw new Exception("URL не содержит названия файла");
        }

        return result;
    }
}
