using System.Text.RegularExpressions;

namespace Carbonyl.Class.Workflows.Preprocess;

public static class CommentRemover
{
    public static string Remove(string code)
    {
        const string re = @"(@(?:""[^""]*"")+|""[^""]*"")|//.*|/\*(?s:.*?)\*/";
        return Regex.Replace(code, re, "$1");
    }
}