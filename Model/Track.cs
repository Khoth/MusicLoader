using System;

namespace MusicLoader.Model
{
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
    }
}
