namespace SkillFactorySVN18;

internal class InfoCommand : Command
{
    internal VideoInfo receiver;
    internal InfoCommand(VideoInfo receiver)
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
