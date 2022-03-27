using MusicLoader.Model;
using System.Threading.Tasks;

namespace MusicLoader.Interface
{
    /// <summary>
    /// Сервис поиска треков.
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Поиск трека.
        /// </summary>
        /// <param name="searchParams">Параметры поиска трека.</param>
        /// <returns>Результат поиска трека.</returns>
        Task<SearchResult> SearchAsync(SearchParams searchParams);
    }
}
