using System;

namespace MusicLoader.Interface
{
    public interface IUriService
    {
        string GetFileNameFromUri(Uri source);
    }
}
