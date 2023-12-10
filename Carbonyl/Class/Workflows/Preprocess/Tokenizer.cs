using System.Text.RegularExpressions;

namespace Carbonyl.Class.Workflows.Preprocess;

public static class Tokenizer
{
    public static List<string> TokenizeString(string code)
    {
        // 用一个或者多个空格字符分割字符串并将结果作为列表返回（目前效果好且代码长度短的方法（（
        return new List<string>(Regex.Split(code, @"\s+"));
    }
}