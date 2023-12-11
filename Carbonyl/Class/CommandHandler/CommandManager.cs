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


    /*
    private readonly string _identifier;
    private readonly List<CommandManager> _subcommands;
    public CommandManager(string? identifier, List<CommandManager>? subcommands) {
        _identifier = identifier ?? throw new NullReferenceException("Command identifier cannot be null");
        _subcommands = subcommands ?? new List<CommandManager>(0);
    }

    public CommandManager(string? identifier) {
        _identifier = identifier ?? throw new NullReferenceException("Command identifier cannot be null");
        _subcommands = new List<CommandManager>(0);
    }

    public delegate Task<int> ExecDelegate();
    public delegate Task<int> ExecArgsDelegate(string[] args);

    public ExecDelegate? ExecFunction { get; init; }
    public ExecArgsDelegate? ExecArgsFunction { get; init; }

    public async Task<int> Exec()
    {
        return await(ExecFunction?.Invoke() ?? Task.FromResult(0));
    }

    public async Task<int> Exec(string[] args) {
        return await(ExecArgsFunction?.Invoke(args) ?? Task.FromResult(0));
    }

    protected void AddSubcommand(CommandManager? newSubcommand) {
        if (newSubcommand is null)
            throw new NullReferenceException("New command cannot be null");

        _subcommands.Add(newSubcommand);
    }

    public string GetIdentifier() {
        return _identifier;
    }

    public List<CommandManager> GetSubCommands() {
        return _subcommands;
    }
    */
}