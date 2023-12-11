using System.Reflection;
using Carbonyl.Class.CommandHandler.Interfaces;
using Carbonyl.Class.Commands;
using Carbonyl.Class.Commands.RootCommands;

namespace Carbonyl.Class.CommandHandler;

public class CommandRunner(CommandManager commandManager)
{
    public async Task<int> ExecuteAsync(List<ICommand> commands, IEnumerable<string> args)
    {
        args ??= new List<string>();
        args = args.ToList();
        if (args.Contains("-v") || args.Contains("--version"))
        {
            string version;
            if (!string.IsNullOrEmpty(commandManager.AppVersion))
                version = commandManager.AppVersion;
            else
                version = Assembly.GetEntryAssembly()?
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                    .InformationalVersion ?? "?";
            Console.WriteLine(version);
            return 0;
        }
        CommandParser commandParser = new(commands);
        ICommand? command = commandParser.ParseCommand(args.ToArray());
        if (command is null)
            return await new RootCommand().Execute(args.Skip(1).ToArray());
        return await command.Execute(args.Skip(1).ToArray());
    }
}