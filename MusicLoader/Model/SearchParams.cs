namespace MusicLoader.Model
{
    /// <summary>
    /// Параметры поиска трека.
    /// </summary>
    public sealed class SearchParams
    {
        /// <summary>
        /// Текстовое представление параметров поиска трека.
        /// </summary>
        public string SearchText { get; private set; }

        /// <summary>
        /// Конструктор параметров поиска трека.
        /// </summary>
        /// <param name="searchText">Строка поиска трека в произвольном формате.</param>
        public SearchParams(string searchText)
        {
            SearchText = searchText;
        }

        /// <summary>
        /// Конструктор параметров поиска трека.
        /// </summary>
        /// <param name="artist">Исполнитель.</param>
        /// <param name="trackTitle">Название трека.</param>
        public SearchParams(string artist, string trackTitle)
        {
            SearchText = $"{artist} - {trackTitle}";
        }
    }
}
