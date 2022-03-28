using MusicLoader.Utility;
using NUnit.Framework;
using System;
using System.IO;

namespace MusicLoader.BLL.Test;

[TestFixture]
internal class UriServiceTest
{
    [TestCase("https://ru.hitmotop.com/get/music/20211112/Ruki_Vverkh_-_Polunochnoe_taksi_73306705.mp3", "Ruki_Vverkh_-_Polunochnoe_taksi_73306705.mp3")]
    [TestCase("http://www.lindberg.no/hires/test/2L-056_04_stereo_DXD.flac", "2L-056_04_stereo_DXD.flac")]
    [TestCase("https://mrr.morsmusic.org/Trevor_Daniel_-_Falling.mp3", "Trevor_Daniel_-_Falling.mp3")]
    public void GetFileNameFromUri_WithCorrectUri_Success(string url, string expected)
    {
        var uri = new Uri(url);

        var result = UriUtility.GetFileNameFromUri(uri);
        var fileName = Path.GetFileNameWithoutExtension(result);
        var extension = Path.GetExtension(result);

        Assert.AreEqual(expected, result);
        Assert.IsTrue(!string.IsNullOrWhiteSpace(fileName));
        Assert.IsTrue(!string.IsNullOrWhiteSpace(extension));
        Assert.IsTrue(!string.IsNullOrWhiteSpace(result) && result.IndexOfAny(Path.GetInvalidFileNameChars()) < 0);
    }

    [TestCase("http://myUrl/%2E%2E/%2E%2E")]
    [TestCase("ftp://myUrl/../..")]
    public void GetFileNameFromUri_WithCorrectUriWithNoName_ThrowsExeption(string url)
    {
        var uri = new Uri(url);

        void code() => UriUtility.GetFileNameFromUri(uri);

        Assert.Throws<Exception>(code);
    }
}
