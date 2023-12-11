using Carbonyl.Class.CommandHandler.Interfaces;
using Carbonyl.Resources.Languages;

namespace Carbonyl.Class.Commands.RootCommands;

public class RootCommand : ICommand
{
    public string? Identifier { get; set; } = null!;
    public List<ICommand> SubCommands { get; set; } = new();

    public async Task<int> Execute(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine(LangResource.UsageCarbonylOptions);
        Console.WriteLine();
        Console.WriteLine(LangResource.Options);
        Console.WriteLine($@"  help|-h|--help|-?            {LangResource.DisplayHelp}");
        return 0;
    }
}