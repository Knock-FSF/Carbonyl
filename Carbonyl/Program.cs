using System.Globalization;
using Carbonyl.Class;
using Carbonyl.Resources.Languages;

namespace Carbonyl;

public static class Program
{
    private static void Main(string[] args)
    {
        /* [ 国际化 - 初始化 ] */
        GlobalVars.Internationalization.SystemDefaultLanguage = Thread.CurrentThread.CurrentUICulture;
    }
}