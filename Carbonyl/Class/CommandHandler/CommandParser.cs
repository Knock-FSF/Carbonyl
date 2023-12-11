using Carbonyl.Class.CommandHandler.Interfaces;

namespace Carbonyl.Class.CommandHandler;

public class CommandParser(List<ICommand> commands)
{
    public ICommand? ParseCommand(string[] args)
    {
        if (args.Length <= 0) return null;
        foreach (var command in commands)
        {
            var identifiers = command.Identifier.Split('|');
            if (!identifiers.Contains(args[0])) continue;
            if (command.HasSubCommands && args.Length > 1)
            {
                var subParser = new CommandParser(command.SubCommands);
                return subParser.ParseCommand(args.Skip(1).ToArray());
            }
            // return await command.Execute(args.Skip(1).ToArray());
            return command;
        }

        return null;
    }
}