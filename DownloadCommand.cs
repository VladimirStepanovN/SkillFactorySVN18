namespace SkillFactorySVN18;

internal class DownloadCommand : Command
{
    internal VideoLoader receiver;
    internal DownloadCommand(VideoLoader receiver)
    {
        this.receiver = receiver;
    }
    internal override async Task Run()
    {
        await receiver.Operation();
    }
    internal override async Task Cancel()
    {
        //тут реализация отмены
    }
}
