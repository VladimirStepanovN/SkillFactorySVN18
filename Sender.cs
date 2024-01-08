namespace SkillFactorySVN18;

internal class Sender
{
    internal Command command;
    internal void SetCommand(Command command)
    {
        this.command = command;
    }
    public async Task Run()
    {
        await command.Run();
    }
    public async Task Cancel()
    {
        //тут реализация отмены
    }
}
