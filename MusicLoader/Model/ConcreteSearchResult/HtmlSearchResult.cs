using HtmlAgilityPack;

namespace MusicLoader.Model.ConcreteSearchResult
{
    /// <summary>
    /// Веб-страница с результатами поиска трека.
    /// </summary>
    public sealed class HtmlSearchResult : SearchResult
    {
        /// <summary>
        /// Результат в виде HTML документа.
        /// </summary>
        public HtmlDocument Document { get; private set; }

        /// <summary>
        /// Конструктор для создания <see cref="HtmlSearchResult"/>.
        /// </summary>
        /// <param name="pageContent">Содержимое страницы в формате HTML.</param>
        public HtmlSearchResult(string pageContent)
        {
            Document = new HtmlDocument();
            Document.LoadHtml(pageContent);
        }
    }
}
