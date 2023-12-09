using Carbonyl.Class;

namespace Carbonyl;

public static class Program
{
    private static async Task Main(string[] args)
    {
        /* [ 国际化 - 初始化 ] */
        GlobalVars.Internationalization.SystemDefaultLanguage = Thread.CurrentThread.CurrentUICulture;
        /* [ 命令行 - 初始化 ] */
    }
}