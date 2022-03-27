using MusicLoader.Interface;
using System.IO;
using System.Threading.Tasks;

namespace MusicLoader.Service
{
    /// <inheritdoc cref="IFileService"/>
    internal sealed class FileService : IFileService
    {
        public bool IsExist(string path)
        {
            return File.Exists(path);
        }

        public async Task SaveAsync(Stream source, string destinationPath)
        {
            using var output = File.OpenWrite(destinationPath);
            await source.CopyToAsync(output);
        }
    }
}
