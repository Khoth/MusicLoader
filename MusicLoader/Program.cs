using HtmlAgilityPack;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicLoader
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var list = args[0];
			var output = args[1];

			using var listFileReader = File.OpenText(list);

			while (!listFileReader.EndOfStream)
			{
				var song = listFileReader.ReadLine();

				// TODO
                if (song.Contains(" - "))
				{
					var parts = song.Split(" - ");
					song = $"{parts[1]} - { parts[0]}";
				}

				Console.WriteLine($"Песня: {song}");

				if (File.Exists(GetFileFullPath(output, song)))
				{
					Console.WriteLine($"Уже скачана\n");
					continue;
				}

				var searchResultPage = await SearchFileAsync(song);
				var songUrl = GetDownloadUrl(searchResultPage);

				if (string.IsNullOrEmpty(songUrl))
				{
					Console.WriteLine($"Не удалось найти");
				}
				else
				{
					Console.WriteLine($"Загрузка...");
					try
					{
						await DownloadFile(songUrl, output, song);
						Console.WriteLine($"Скачана");
					}
					catch
					{
						Console.WriteLine("Что-то пошло не так :(");
					}
				}

				Console.WriteLine("\n");
			}
		}

		private static readonly string _siteUrl = "https://ru.hitmotop.com/";
			//"https://mrr.morsmusic.org/";

		static async Task<string> SearchFileAsync(string song)
		{
			using var client = new HttpClient();
			client.BaseAddress = new Uri(_siteUrl);
			//return await client.GetStringAsync($"search/{song}");
			return await client.GetStringAsync($"search?q={song}");
		}

		static string GetDownloadUrl(string html)
		{
			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(html);
			//return htmlDoc
			//	.DocumentNode
			//	.SelectSingleNode("//div[@class='wrapper-tracklist muslist']//a[@class='track-download']")
			//	?.GetAttributeValue("href", string.Empty) ?? string.Empty;
			return htmlDoc
				.DocumentNode
				.SelectSingleNode("//*[@class='tracks__list']//a[@class='track__download-btn']")
				?.GetAttributeValue("href", string.Empty) ?? string.Empty;
		}

		static string GetFileFullPath(string outputPath, string fileName)
		{
			return $"{outputPath}//{fileName}.mp3";
		}

		static async Task DownloadFile(string sourceUrl, string outputPath, string fileName)
		{
			using var client = new HttpClient();
			client.BaseAddress = new Uri(_siteUrl);
			using var sourceStream = await client.GetStreamAsync(sourceUrl);
			using var outputStream = File.OpenWrite(GetFileFullPath(outputPath, fileName));
			await sourceStream.CopyToAsync(outputStream);
		}
	}
}
