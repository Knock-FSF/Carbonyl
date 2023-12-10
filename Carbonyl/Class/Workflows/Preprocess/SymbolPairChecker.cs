namespace Carbonyl.Class.Workflows.Preprocess;

public static class SymbolPairChecker
{
    public static bool AreParenthesesBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        Dictionary<char, char> mappings = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' },
            //{ '>', '<' }
        };
        
        /*
        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];
            if (c == '>' && i > 0 && expression[i - 1] == '-')
            {
                continue;
            }
            if (mappings.Values.Contains(c))
            {
                stack.Push(c);
            }
            else if (mappings.Keys.Contains(c))
            {
                if (stack.Count == 0 || stack.Pop() != mappings[c])
                {
                    return false;
                }
            }
            else if (c == '\'' || c == '\"')
            {
                if (stack.Count > 0 && stack.Peek() == c)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }
        }
        */
        
        foreach (char c in expression)
        {
            
            if (mappings.Values.Contains(c))
            {
                stack.Push(c);
            }
            else if (mappings.Keys.Contains(c))
            {
                if (stack.Count == 0 || stack.Pop() != mappings[c])
                {
                    return false;
                }
            }
            else if (c == '\'' || c == '\"')
            {
                if (stack.Count > 0 && stack.Peek() == c)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }
        }
        
        return stack.Count == 0;
    }
}