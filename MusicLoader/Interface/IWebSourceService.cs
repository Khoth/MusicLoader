namespace MusicLoader.Interface
{
    /// <summary>
    /// Веб-сервис, сочетающий возможность поиска и скачивания треков.
    /// </summary>
    public interface IWebSourceService : ISearchService, IDownloadService
    {
    }
}
