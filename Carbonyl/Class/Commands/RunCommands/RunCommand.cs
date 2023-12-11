using Carbonyl.Class.CommandHandler.Interfaces;

namespace Carbonyl.Class.Commands.RunCommands;

public class RunCommand : ICommand
{
    public string Identifier { get; set; } = null!;
    public List<ICommand> SubCommands { get; set; } = new();

    public async Task<int> Execute(string[] args)
    {
        /*/* --- [ 程序 ] --- #1#
        // 读取文件与获取其字符串
        if (args.Length == 0)
        {
            AnsiConsole.MarkupLine($"[red]{LangResource.PleaseSpecifyAFile}[/]");
            return 1;
        }
        string? codeString = FileInputHandle.GetFileText(args[0]);
        if (codeString is null or "")
        {
            AnsiConsole.MarkupLine($"{args[0]} [red]{LangResource.FileReadingFailed}[/]");
            return 1;
        }
        // 移除注释
        codeString = CommentRemover.Remove(codeString);
        // 符号对检查
        if (!SymbolPairChecker.AreParenthesesBalanced(codeString))
        {
            AnsiConsole.MarkupLine($"{args[0]} [red]{LangResource.SymbolPairCheckFailed}[/]");
            return 1;
        }
        // 记录宏
        var macros = MacroParser.Parser(codeString);
        // 短语化
        List<string> tokenizeCode = Tokenizer.TokenizeString(codeString);
        foreach (var macro in macros)
        {
            Console.WriteLine($"{macro.Item1}\n" +
                              $"{macro.Item2}\n" +
                              $"{macro.Item3}\n" +
                              $"{macro.Item4}\n" +
                              $"{macro.Item5}\n");
        }*/
        return 0;
    }
}