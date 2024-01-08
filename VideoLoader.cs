using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace SkillFactorySVN18;

internal class VideoLoader
{
    private readonly string _url;
    internal VideoLoader(string url)
    {
        _url = url;
    }
    internal async Task Operation()
    {
        var youtube = new YoutubeClient();
        var videoId = VideoId.Parse(_url);
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
        var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();
        if (streamInfo is null)
        {
            Console.Error.WriteLine("В этом видео нет мультиплексированных потоков");
            return;
        }
        var fileName = $"{videoId}.{streamInfo.Container.Name}";
        Console.Write(
            $"Загрузка потока: {streamInfo.VideoQuality.Label} / {streamInfo.Container.Name}... "
        );
        await youtube.Videos.Streams.DownloadAsync(streamInfo, fileName);
        Console.WriteLine("Загрузка завершена");
        Console.WriteLine($"Видео сохранено как '{fileName}'");
    }
}
