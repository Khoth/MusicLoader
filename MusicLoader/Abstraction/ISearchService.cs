using MusicLoader.Model;

namespace MusicLoader.Abstraction;

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
