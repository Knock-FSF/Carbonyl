using Carbonyl.Class.CommandHandler.Interfaces;

namespace Carbonyl.Class.CommandHandler;

public class CommandConfig(CommandManager commandManager) : ICommandConfig
{
    public void AddCommand<TCommand>(string identifier) where TCommand : class, ICommand
    {
        var command = Activator.CreateInstance<TCommand>();
        typeof(TCommand).GetProperty("Identifier")!.SetValue(command, identifier);
        commandManager.Commands.Add(command);
    }

    public void AddBranch<TCommand>(string identifier, Action<ICommandConfig> action) where TCommand : class, ICommand
    {
        var command = Activator.CreateInstance<TCommand>();
        typeof(TCommand).GetProperty("Identifier")!.SetValue(command, identifier);
        commandManager.Commands.Add(command);
        action(new CommandConfig(
            new CommandManager((typeof(TCommand).GetProperty("SubCommands")!.GetValue(command) as List<ICommand>)!)));
    }

    public void SetAppVersion(string appVersion)
    {
        commandManager.AppVersion = appVersion;
    }
}