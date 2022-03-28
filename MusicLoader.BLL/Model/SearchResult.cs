namespace MusicLoader.Model;

/// <summary>
/// Результат поиска трека.
/// </summary>
public abstract class SearchResult
{
    /// <summary>
    /// Треки.
    /// </summary>
    public Track[] Tracks { get; set; } = Array.Empty<Track>();
}
