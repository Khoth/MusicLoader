using System.IO;
using System.Threading.Tasks;

namespace MusicLoader.Interface
{
    /// <summary>
    /// Сервис для работы с файлами.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Проверяет существует ли указанный файл.
        /// </summary>
        /// <param name="path">Полный путь до файла, включая имя и расширение.</param>
        /// <returns>Признак успешности проверки.</returns>
        bool IsExist(string path);

        /// <summary>
        /// Сохраняет содержимое потока в указанный файл.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="destinationPath">Полный путь до целевого файла, включая имя и расширение.</param>
        /// <returns></returns>
        Task SaveAsync(Stream source, string destinationPath);
    }
}
