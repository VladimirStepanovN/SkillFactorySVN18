using YoutubeExplode;

namespace SkillFactorySVN18;

internal class VideoInfo
{
   private readonly string _url;
    internal VideoInfo(string url)
    {
        _url = url;
    }
    internal async Task Operation()
    {
        var youtube = new YoutubeClient();
        var videoUrl = _url;
        var video = await youtube.Videos.GetAsync(videoUrl);
        var title = video.Title;
        var author = video.Author.Title;
        var duration = video.Duration;
        Console.WriteLine($"Название видео: {title} {System.Environment.NewLine} " +
            $"Автор видео: {author} {System.Environment.NewLine} " +
            $"Длительность видео: {duration} {System.Environment.NewLine}");
    }
}
