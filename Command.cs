namespace SkillFactorySVN18;

internal abstract class Command
{
    internal abstract Task Run();
    internal abstract Task Cancel();
}
