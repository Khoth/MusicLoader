using System;
using System.Threading.Tasks;

namespace MusicLoader.Interface
{
    /// <summary>
    /// Сервис скачивания треков.
    /// </summary>
    public interface IDownloadService
    {
        /// <summary>
        /// Скачать трек.
        /// </summary>
        /// <param name="source">Путь до скачиваемого файла.</param>
        /// <param name="destination">Адрес локального каталога, куда будет скачан трек.</param>
        /// <param name="fileName">Имя скачанного файла. Если не указан, используется имя из <paramref name="source"/>.</param>
        /// <returns></returns>
        Task DownloadAsync(Uri source, string destination, string fileName = null);
    }
}
