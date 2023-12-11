namespace Carbonyl.Class.CommandHandler.Interfaces;

public interface ICommand
{
    public string Identifier { get; set; }
    public bool HasSubCommands => SubCommands.Count > 0;
    public List<ICommand> SubCommands { get; set; }
    public Task<int> Execute(string[] args);
}