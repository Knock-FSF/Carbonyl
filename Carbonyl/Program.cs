using Carbonyl.Class;
using Carbonyl.Class.Workflows.FileInput;
using Carbonyl.Class.Workflows.Preprocess;
using Carbonyl.Resources.Languages;
using Spectre.Console;

namespace Carbonyl;

public static class Program
{
    private static async Task Main(string[] args)
    {
        /* -- [ 国际化 - 初始化 ] -- */
        // 保存系统默认语言
        GlobalVars.Internationalization.SystemDefaultLanguage = Thread.CurrentThread.CurrentUICulture;
        /* -- [ 命令行 - 初始化 ] -- */
        // WIP
        /* -- [ 程序 - - 初始化 ] -- */
        // 读取文件与获取其字符串
        if (args.Length == 0)
        {
            AnsiConsole.MarkupLine($"[red]{LangResource.PleaseSpecifyAFile}[/]");
            return;
        }
        string? codeString = FileInputHandle.GetFileText(args[0]);
        if (codeString is null or "")
        {
            AnsiConsole.MarkupLine($"{args[0]} [red]{LangResource.FileReadingFailed}[/]");
            return;
        }
        // 移除注释
        codeString = CommentRemover.Remove(codeString);
        // 符号对检查
        if (!SymbolPairChecker.AreParenthesesBalanced(codeString))
        {
            AnsiConsole.MarkupLine($"{args[0]} [red]{LangResource.SymbolPairCheckFailed}[/]");
            return;
        }
        // 记录宏
        var macros = MacroParser.Parser(codeString);
        // 短语化
        List<string> tokenizeCode = Tokenizer.TokenizeString(codeString);
        
    }
}