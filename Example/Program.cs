using System.Text.RegularExpressions;

namespace Example;

public static class Program
{
    public const string CarbonExampleCode = "namespace syntax\n" +
                                            "{\n" +
                                            "enum Gender\n" +
                                            "{\n" +
                                            "  GENDER_FEMALE = 0,\n" +
                                            "  GENDER_MALE = 1,\n" +
                                            "};\n" +
                                            "\n" +
                                            "struct Person\n" +
                                            "{\n" +
                                            "  String name = \"\";\n" +
                                            "  char *detail = \"\";\n" +
                                            "  int age = 0;\n" +
                                            "  enum Gender gender = 0;\n" +
                                            "};\n" +
                                            "\n" +
                                            "class PersonInstance\n" +
                                            "{\n" +
                                            "  private struct Person instance;\n" +
                                            "  public float height;\n" +
                                            "  public float weight;\n" +
                                            "\n" +
                                            "  public PersonInstance(const struct Person *instance, const float height,\n" +
                                            "    const float weight)\n" +
                                            "  {\n" +
                                            "    if (instance == NULL)\n" +
                                            "      throw new exception::NullPointerException(\n" +
                                            "        \"Trying to create instance with a null pointer.\");\n" +
                                            "\n" +
                                            "    this.instance = {\n" +
                                            "      .name = instance->name,\n" +
                                            "      .detail = instance->detail,\n" +
                                            "      .age = instance->age,\n" +
                                            "      .gender = instance->gender\n" +
                                            "    };\n" +
                                            "\n" +
                                            "    this.height = height;\n" +
                                            "    this.weight = weight;\n" +
                                            "  }\n" +
                                            "\n" +
                                            "  public PersonInstance(PersonInstance *other)\n" +
                                            "  {\n" +
                                            "    if (other == NULL)\n" +
                                            "      throw new exception::NullPointerException(\n" +
                                            "        \"Trying to create instance with a null pointer.\");\n" +
                                            "\n" +
                                            "    this = other;\n" +
                                            "  }\n" +
                                            "\n" +
                                            "  public struct Person *getInstance() { return this.instance; }\n" +
                                            "  public float getHeight() { return this.height; }\n" +
                                            "  public float getWeight() { return this.weight; }\n" +
                                            "\n" +
                                            "  public void setInstance(struct Person *instance)\n" +
                                            "  {\n" +
                                            "    if (instance == NULL)\n" +
                                            "      throw new exception::NullPointerException(\n" +
                                            "        \"Trying to create instance with a null pointer.\");\n" +
                                            "\n" +
                                            "    this.instance = instance;\n" +
                                            "  }\n" +
                                            "  public void setHeight(const float height) { this.height = height; }\n" +
                                            "  public void setWeight(const float weight) { this.weight = weight; }\n" +
                                            "  \n" +
                                            "};\n" +
                                            "\n" +
                                            "class People extends Person\n" +
                                            "{\n" +
                                            "  private Array<Person> members;\n" +
                                            "\n" +
                                            "  public PersonInstance(const struct Person *instance, const float height,\n" +
                                            "    const float weight)\n" +
                                            "  {\n" +
                                            "    super(instance, height, weight);\n" +
                                            "  }\n" +
                                            "\n" +
                                            "  public PersonInstance(PersonInstance *other)\n" +
                                            "  {\n" +
                                            "    super(other);\n" +
                                            "  }\n" +
                                            "};\n" +
                                            "\n" +
                                            "namespace Human\n" +
                                            "{\n" +
                                            "  namespace abstraction;\n" +
                                            "  namespace computation;\n" +
                                            "  namespace conception;\n" +
                                            "  namespace serialisation;\n" +
                                            "  namespace exception;\n" +
                                            "  namespace precaution;\n" +
                                            "  namespace automation;\n" +
                                            "\n" +
                                            "  attribute CanDie\n" +
                                            "  {\n" +
                                            "    bool isDead = false;\n" +
                                            "  };\n" +
                                            "  attribute CanMetabolise {};\n" +
                                            "  attribute CanMove {};\n" +
                                            "  attribute CanSpeak\n" +
                                            "  {\n" +
                                            "    Locale lang = Locale.fromSystem();\n" +
                                            "    Audio[] tune = new Array<Audio>(0);\n" +
                                            "    bool isSpeaking = false;\n" +
                                            "  };\n" +
                                            "  attribute CanConsume {};\n" +
                                            "\n" +
                                            "  /* @<NATTR>[<T>, ...](attr[<AM>, ...]) <T> $param                           */\n" +
                                            "  /*          ~~~~~~~^  ~~~^                                                  */\n" +
                                            "  /*          Fields    Filter                                                */\n" +
                                            "  /* NATTR: Attributable Namespace                                            */\n" +
                                            "  /* T: Type                                                                  */\n" +
                                            "  /* AM: Attribute Members                                                    */\n" +
                                            "  /* Fields: The object attributed must be one of or belong to one of\n" +
                                            "             the fields.                                                      */\n" +
                                            "  /* Filter: The object attributed must have the same or have one belonging to\n" +
                                            "             the same filter specified.                                       */\n" +
                                            "  abstract void eat(\n" +
                                            "    /* Attribute here is just emphasising the filter which determines whether\n" +
                                            "       the given parameter is favorable.  It helps translator to reject if not.\n" +
                                            "       It's like a minimum requirement, once the object holds the specified\n" +
                                            "       properties, the examine will be passed. */\n" +
                                            "    @Ability[PersonInstance](attribute CanConsume) PersonInstance *dst,\n" +
                                            "    @Abstraction[Objective](attribute Edible) Item *food\n" +
                                            "  );\n" +
                                            "  abstract void die(\n" +
                                            "    @Ability[PersonInstance](attribute CanDie[isDead=false]) PersonInstance *dst\n" +
                                            "  );\n" +
                                            "  abstract void move(\n" +
                                            "    @Ability[PersonInstance](attribute CanMove) PersonInstance *dst,\n" +
                                            "    /* T<T> */\n" +
                                            "    const Array<Vector<Double>> *initialVelocity,\n" +
                                            "    const Array<Vector<Double>> *proceduralVelocity,\n" +
                                            "    Timer *duration,\n" +
                                            "    @Abstraction[PhysicsEngine](attribute Abstracted) LawOfPhysics *rule\n" +
                                            "  );\n" +
                                            "\n" +
                                            "  public interface IOtherBehaviours\n" +
                                            "  {\n" +
                                            "    int behave(@Ability[PersonInstance]() PersonInstance *dst);\n" +
                                            "    \n" +
                                            "    int behave(\n" +
                                            "      @Ability[PersonInstance]() PersonInstance *dst,\n" +
                                            "      @Abstraction[Behavioural](attribute HumanBehaving) Action[] *behaviours);\n" +
                                            "  };\n" +
                                            "\n" +
                                            "  protected class OtherBehaviours implements IOtherBehaviours\n" +
                                            "  {\n" +
                                            "    int behave(@Ability[PersonInstance]() PersonInstance *dst)\n" +
                                            "    {\n" +
                                            "      if (dst == NULL)\n" +
                                            "        /* Using namespace exception, no prefixes required (exception::). */\n" +
                                            "        throw new NullPointerException(\n" +
                                            "          \"Cannot have     NULL pointer being as destination for storage.\");\n" +
                                            "\n" +
                                            "      /* ... */\n" +
                                            "      return 0;\n" +
                                            "    }\n" +
                                            "\n" +
                                            "    int behave(\n" +
                                            "      @Ability[PersonInstance]() PersonInstance *dst,\n" +
                                            "      @Abstraction[Behavioural](attribute HumanBehaving) Action[] *behaviours)\n" +
                                            "    {\n" +
                                            "      if (dst == NULL)\n" +
                                            "        /* Using namespace exception, no prefixes required (exception::). */\n" +
                                            "        throw new NullPointerException(\n" +
                                            "          \"Cannot have NULL pointer being as destination for storage.\");\n" +
                                            "\n" +
                                            "      if (behaviours == NULL)\n" +
                                            "        return 0;\n" +
                                            "\n" +
                                            "      /* ... */\n" +
                                            "      return 0;\n" +
                                            "    }\n" +
                                            "  };\n" +
                                            "}\n" +
                                            "\n" +
                                            "}  /* namespace syntax */\n";

    public const string SymbolPairsCheckExampleCorrectCode = """

                                                             {
                                                                 struct Person
                                                                 {
                                                                   String name = "";
                                                                   char *detail = "";
                                                                   int age = 0;
                                                                   enum Gender gender = 0;
                                                                 };
                                                             }
                                                             """;

    public const string SymbolPairsCheckExampleErrorCode1 = """
                                                            {
                                                                struct Person
                                                                
                                                                  String name = "";
                                                                  char *detail = "";
                                                                  int age = 0;
                                                                  enum Gender gender = 0;
                                                                };
                                                            }
                                                            """;

    public const string SymbolPairsCheckExampleErrorCode2 = """
                                                            {
                                                                struct Person
                                                                {
                                                                  String name = ";
                                                                  char *detail = "";
                                                                  int age = 0;
                                                                  enum Gender gender = 0;
                                                                };
                                                            }
                                                            """;

    public const string RemoveCommentsExampleCode1 = """
                                                     {
                                                        // 111
                                                        Example Code....
                                                        /* 222 */
                                                        123456
                                                        /* 333
                                                           444
                                                           */
                                                     }
                                                     """;

    public const string RecordMacrosExampleCode1 = """
                                                   #define RECORD_MACRO_1 1
                                                   #define RECORD_MACRO_2 2
                                                   {
                                                      #1
                                                      Example Code....
                                                   }
                                                   """;

    public const string RecordMacrosExampleCode2 = """
                                                   #define MAX compare(a,\
                                                   b)
                                                   {
                                                      #1
                                                      #define RECORD_MACRO_2 2
                                                      Example Code....
                                                   }
                                                   """;
    public const string TokeniseExampleCode = """
                                              int main()
                                              {
                                                struct Person
                                                {
                                                    String name = "";
                                                    char *detail = "";
                                                    int age = 0;
                                                    enum Gender gender = 0;
                                                };
                                              }
                                              """;
                                            

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        /* - 文件输入 --------------------------- */
        // string -> CarbonExampleCode 暂时完成 "文件输入”
        /* - 预处理  --------------------------- */
        /* ------ 剔除注释 ---------------------- */
        Console.WriteLine($"剔除注释 - 代码例子: {RemoveComments(RemoveCommentsExampleCode1)}");
        /* ------ 符号对检查 -------------------- */
        Console.WriteLine($"符号对检查 - 正确代码检查: {AreParenthesesBalanced(SymbolPairsCheckExampleCorrectCode)}");
        Console.WriteLine($"符号对检查 - 错误代码检查: {AreParenthesesBalanced(SymbolPairsCheckExampleErrorCode1)}");
        Console.WriteLine($"符号对检查 - 错误代码检查: {AreParenthesesBalanced(SymbolPairsCheckExampleErrorCode2)}");
        /* ------ 记录宏 ------------------------ */
        Console.WriteLine("记录宏（预处理器指令） - 情况1:");
        foreach (var rm in ExtractCPreprocessorDirectives(RecordMacrosExampleCode1))
            Console.WriteLine("   -> " + rm);
        Console.WriteLine("记录宏（预处理器指令） - 情况2:");
        foreach (var rm in ExtractCPreprocessorDirectives(RecordMacrosExampleCode2))
            Console.WriteLine("   -> " + rm);
        Console.WriteLine("[注] 宏或预处理器指令部分尚未完善");
        /* ------ 短语化 ------------------------ */
        Console.WriteLine("短语化 - 代码例子:");
        string[] tokeniseTest = TokeniseString(TokeniseExampleCode).ToArray();
        foreach (var tks in tokeniseTest)
            Console.WriteLine(tks);
        /* ------ 合规可处理源代码 ---------------- */
        Console.WriteLine("合规可处理源代码:");
        string removedCommentsCode = RemoveComments(CarbonExampleCode);
        Console.WriteLine($"剔除注释: {removedCommentsCode}");
        Console.WriteLine($"符号对检查: {AreParenthesesBalanced(removedCommentsCode)}");
        Console.WriteLine("记录宏（预处理器指令） - 暂时跳过...");
        Console.WriteLine("短语化: ");
        foreach (var tks in TokeniseString(removedCommentsCode))
            Console.WriteLine(tks);
    }

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

    public static string RemoveComments(string code)
    {
        var re = @"(@(?:""[^""]*"")+|""[^""]*"")|//.*|/\*(?s:.*?)\*/";
        return Regex.Replace(code, re, "$1");
    }
    /* 处理单行宏
    public static List<string> CollectPreprocessorDirectives(string code)
    {
        List<string> directives = new List<string>();

        var lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        foreach (var line in lines)
        {
            var trimmedLine = Regex.Replace(line, @"\s+", " ").Trim();
            if (trimmedLine.StartsWith("#"))
            {
                directives.Add(trimmedLine);
            }
        }

        return directives;
    }
    */
    public static List<string> ExtractCPreprocessorDirectives(string code)
    {
        List<string> directives = new List<string>();

        // 获取代码行，跳过空行
        var lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            // 将多个空格替换为单个空格并修剪前导和尾随空格
            var trimmedLine = Regex.Replace(line, @"\s+", " ").Trim();

            if (trimmedLine.StartsWith("#"))
            {
                // 处理多行指令
                while (trimmedLine.EndsWith("\\"))
                {
                    // 删除结尾的反斜杠
                    trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);

                    // 将下一行添加到当前行
                    if (++i < lines.Length)
                    {
                        trimmedLine += lines[i].Trim();
                    }
                }

                directives.Add(trimmedLine);
            }
        }

        return directives;
    }
    
    public static List<string> TokeniseString(string code)
    {
        // 用一个或者多个空格字符分割字符串并将结果作为列表返回（目前效果好且长度短的方法（（
        return new List<string>(Regex.Split(code, @"\s+"));
    }
}