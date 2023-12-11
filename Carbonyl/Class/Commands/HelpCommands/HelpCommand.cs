using Carbonyl.Class.CommandHandler.Interfaces;
using Spectre.Console;

namespace Carbonyl.Class.Commands.HelpCommands;

public class HelpCommand : ICommand
{
    public string? Identifier { get; set; } = null!;
    public List<ICommand> SubCommands { get; set; } = new();
    public async Task<int> Execute(string[] args)
    {
        AnsiConsole.MarkupLine("[gold3_1]╔═╗       ╔╗[/]");
        AnsiConsole.MarkupLine("[gold3_1]║╔╝╔═╗ ╔╦╗║╚╗╔═╗╔═╦╗╔╦╗╔╗[/]");
        AnsiConsole.MarkupLine("[gold3_1]║╚╗║╬╚╗║╔╝║╬║║╬║║║║║║║║║╚╗[/]");
        AnsiConsole.MarkupLine("[gold3_1]╚═╝╚══╝╚╝ ╚═╝╚═╝╚╩═╝╠╗║╚═╝[/]");
        AnsiConsole.MarkupLine("[gold3_1]                    ╚═╝[/]");
        return 0;
    }
}