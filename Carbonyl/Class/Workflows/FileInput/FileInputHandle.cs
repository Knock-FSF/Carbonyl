using Spectre.Console;

namespace Carbonyl.Class.Workflows.FileInput;

public static class FileInputHandle
{
    public static string? GetFileText(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception e)
        {
            AnsiConsole.WriteException(e);
            return null;
        }
    }

}