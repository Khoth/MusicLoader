namespace MusicLoader.Utility;

/// <summary>
/// Сервис для работы с файлами.
/// </summary>
internal sealed class FileUtility
{
    /// <summary>
    /// Проверяет существует ли указанный файл.
    /// </summary>
    /// <param name="path">Полный путь до файла, включая имя и расширение.</param>
    /// <returns>Признак успешности проверки.</returns>
    public static bool IsExist(string path)
    {
        return File.Exists(path);
    }

    /// <summary>
    /// Сохраняет содержимое потока в указанный файл.
    /// </summary>
    /// <param name="source">Источник данных.</param>
    /// <param name="destinationPath">Полный путь до целевого файла, включая имя и расширение.</param>
    /// <returns></returns>
    public static async Task SaveAsync(Stream source, string destinationPath)
    {
        using var output = File.OpenWrite(destinationPath);
        await source.CopyToAsync(output);
    }
}
