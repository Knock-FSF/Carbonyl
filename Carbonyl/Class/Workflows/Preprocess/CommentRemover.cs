using System.Text.RegularExpressions;

namespace Carbonyl.Class.Workflows.Preprocess;

public static class CommentRemover
{
    public static string Remove(string code)
    {
        var re = @"(@(?:""[^""]*"")+|""[^""]*"")|//.*|/\*(?s:.*?)\*/";
        return Regex.Replace(code, re, "$1");
    }
}