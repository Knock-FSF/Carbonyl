using Carbonyl.Class;
using Carbonyl.Class.CommandHandler;
using Carbonyl.Class.Commands;
using Carbonyl.Class.Commands.HelpCommands;
using Carbonyl.Class.Commands.RunCommands;
using Carbonyl.Class.Workflows.FileInput;
using Carbonyl.Class.Workflows.Preprocess;
using Carbonyl.Resources.Languages;
using Spectre.Console;

namespace Carbonyl;
public static class Program
{
    private static async Task<int> Main(string[] args)
    {
        /* --- [ 国际化 ] --- */
        // 保存系统默认语言
        GlobalVars.Internationalization.SystemDefaultLanguage = Thread.CurrentThread.CurrentUICulture;
        /* --- [ 命令行 ] --- */
        CommandManager commandManager = new();
        commandManager.Configure(config =>
        {
            // config.SetAppVersion("1.0.0");
            config.AddCommand<HelpCommand>("help|-h|--help|-?");
            config.AddCommand<RunCommand>("run");
        });
        return await commandManager.RunAsync(args);
    }
}