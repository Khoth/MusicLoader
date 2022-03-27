using MusicLoader.Interface;
using MusicLoader.Model;
using MusicLoader.Model.ConcreteSearchResult;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicLoader.Service.Hitmo
{
    /// <summary>
    /// Сервис для работы с сайтом hitmotop.com.
    /// </summary>
    public sealed class Hitmo : ISearchService, IDownloadService
    {
        private static string _baseUrl = "https://ru.hitmotop.com/";

        private readonly HttpClient _httpClient;
        private readonly IFileService _fileService;
        private readonly IUriService _uriService;

        /// <summary>
        /// Конструктор сервиса для работы с сайтом hitmotop.com.
        /// </summary>
        /// <param name="httpClient">TODO</param>
        /// <param name="fileService">TODO</param>
        /// <param name="uriService">TODO</param>
        public Hitmo(
            HttpClient httpClient,
            IFileService fileService,
            IUriService uriService)
        {
            _httpClient = httpClient;
            _fileService = fileService;
            _uriService = uriService;
        }

        public async Task DownloadAsync(Uri source, string destination, string fileName = null)
        {
            var finalFileName = fileName ?? _uriService.GetFileNameFromUri(source);
            var filePath = Path.Combine(destination, finalFileName);

            using var sourceStream = await _httpClient.GetStreamAsync(source.Query); // TODO ?
            await _fileService.SaveAsync(sourceStream, filePath);
        }

        public async Task<SearchResult> SearchAsync(SearchParams searchParams)
        {
            var pageContent = await _httpClient.GetStringAsync($"search?q={searchParams.SearchText}");
            var searchResult = new HtmlSearchResult(pageContent);

            // TODO searchResult.Tracks

            return searchResult;
        }
    }
}
