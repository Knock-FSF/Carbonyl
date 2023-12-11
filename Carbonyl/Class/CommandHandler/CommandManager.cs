using Carbonyl.Class.CommandHandler.Interfaces;

namespace Carbonyl.Class.CommandHandler;

public class CommandManager
{
    private readonly CommandConfig _commandConfig;
    private readonly CommandRunner _commandRunner;
    public readonly List<ICommand> Commands;
    public string? AppVersion;

    public CommandManager()
    {
        _commandConfig = new CommandConfig(this);
        _commandRunner = new CommandRunner(this);
        Commands = new List<ICommand>();
    }

    public CommandManager(List<ICommand> commands)
    {
        _commandConfig = new CommandConfig(this);
        _commandRunner = new CommandRunner(this);
        Commands = commands;
    }

    public void Configure(Action<ICommandConfig> action)
    {
        action(_commandConfig);
    }

    public int Run(string[] args)
    {
        return RunAsync(args).GetAwaiter().GetResult();
    }

    public async Task<int> RunAsync(string[] args)
    {
        return await _commandRunner.ExecuteAsync(Commands, args).ConfigureAwait(false);
    }
}