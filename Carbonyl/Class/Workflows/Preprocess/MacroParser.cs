namespace Carbonyl.Class.Workflows.Preprocess;

public static class MacroParser
{
    public static List<(string, string, string, int, int)> Parser(string code)
    {
        var macros = new List<(string, string, string, int, int)>();
        // 获取代码的所有行
        var lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        // 遍历代码的每一行
        for (var i = 0; i < lines.Length; i++)
            // 检查该行是否以#开头的宏
            if (lines[i].TrimStart().StartsWith('#'))
            {
                var line = lines[i].TrimStart();

                // 判断是否有反斜杠，如果有就删除并继续读取下一行
                while (line.EndsWith('\\'))
                {
                    line = line.Substring(0, line.Length - 1);

                    if (i + 1 < lines.Length)
                    {
                        i++;
                        line += lines[i].TrimStart();
                    }
                }

                // 提取操作
                var operation = line.Substring(0, line.IndexOf(' '));
                // 提取操作后的内容（去除前后空格）
                var content = line.Substring(line.IndexOf(' ') + 1).Trim();
                // 在内容中查找空格的位置（identifier 后面）
                var spaceIndex = content.IndexOf(' ');
                if (spaceIndex < 0) // 如果没有找到，设置为行的末尾
                    spaceIndex = content.Length;
                // 提取宏标识符
                var identifier = content.Substring(0, spaceIndex);
                // 提取宏定义
                var definition = content.Substring(spaceIndex).Trim();
                // 宏指令的位置（字符偏移量）和长度
                var lineNum = i; // 行号
                var length = line.Length; // 行长度

                macros.Add((operation, identifier, definition, lineNum, length));
            }

        return macros;
    }

    // TODO: ConditionalParser
}