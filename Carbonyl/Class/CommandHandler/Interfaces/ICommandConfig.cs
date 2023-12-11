namespace Carbonyl.Class.CommandHandler.Interfaces;

public interface ICommandConfig
{
    void AddCommand<TCommand>(string identifier) where TCommand : class, ICommand;
    void AddBranch<TCommand>(string identifier, Action<ICommandConfig> action) where TCommand : class, ICommand;
    void SetAppVersion(string appVersion);
}