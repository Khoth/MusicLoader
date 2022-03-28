namespace MusicLoader.Model;

/// <summary>
/// Информация о треке.
/// </summary>
public class Track
{
    /// <summary>
    /// Расположение трека.
    /// </summary>
    public Uri Destination { get; set; }

    /// <summary>
    /// Артист.
    /// </summary>
    public string Artist { get; set; }

    /// <summary>
    /// Название трека.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Конструктор информации трека.
    /// </summary>
    /// <param name="destination">Расположение трека.</param>
    /// <param name="artist">Артист.</param>
    /// <param name="title">Название трека.</param>
    public Track(Uri destination, string artist, string title)
    {
        Destination = destination;
        Artist = artist;
        Title = title;
    }
}
