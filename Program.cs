namespace SkillFactorySVN18;

internal class Program
{
    internal static async Task Main(string[] args)
    {
        Console.WriteLine("Введите url youtube-видео:");
        string url = "";
        try
        {
            url = Console.ReadLine();
            if (string.IsNullOrEmpty(url)) throw new IOException();
        }
        catch (IOException)
        {
            Console.WriteLine("Адрес введен некорректно, повторите попытку.");
            Main(args);
        }
        Sender sender = new();
        int action = GetAction();
        while (action != 3)
        {
            if (action == 1)
            {
                VideoInfo info = new(url);
                InfoCommand command = new(info);
                sender.SetCommand(command);
                try
                {
                    await sender.Run();
                }
                catch (System.ArgumentException)
                {
                    Console.WriteLine("Видео по указанному адресу не найдено");
                    break;
                }
                action = GetAction();
            }
            else if (action == 2)
            {
                VideoLoader loader = new(url);
                DownloadCommand command = new(loader);
                sender.SetCommand(command);
                try
                {
                    await sender.Run();
                }
                catch (System.ArgumentException)
                {
                    Console.WriteLine("Видео по указанному адресу не найдено");
                    break;
                }
                action = GetAction();
            }
            else
            {
                action = GetAction();
            }
        }
    }
    internal static int GetAction()
    {
        Console.WriteLine($"Выберите действие: {System.Environment.NewLine} " +
            $"1 - получить информацию о видео {System.Environment.NewLine} " +
            $"2 - скачать видео {System.Environment.NewLine} " +
            $"3 - выйти {System.Environment.NewLine}");
        if (!int.TryParse(Console.ReadLine(), out int result))
        {
            return 0;
        }
        else
        {
            return result;
        }
    }
}