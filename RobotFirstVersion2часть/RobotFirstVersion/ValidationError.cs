using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class ValidationError
{
    private static readonly string[] VALID_COMMANDS = { "Вверх", "Вниз", "Влево", "Вправо" };
    List<int> errorsLine = new List<int>();
    public void ValidateCommand(string input)
    {
        string[] keywords = { "if(", "else", "While(", "}", "{" };
        string[] validDirections = { "Вверх", "Вниз", "Влево", "Вправо" };

        string[] lines = input.Split('\n');
       
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (!string.IsNullOrEmpty(line))
            {
                bool isValidKeyword = false;
                foreach (string keyword in keywords)
                {
                    if (line.StartsWith(keyword))
                    {
                        isValidKeyword = true;
                        break;
                    }
                }

                if (isValidKeyword)
                {
                    // Do nothing
                }
                else if (validDirections.Contains(line))
                {
                    // Do nothing
                }
                else
                {
                    Console.WriteLine("Invalid input on line " + (i + 1));
                    errorsLine.Add(i + 1);
                }
            }
        }
    }

    public void ValidateIfStatement(string code)
    {
        string[] lines = code.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (line.StartsWith("if(!") || line.StartsWith("if("))
            {
                int openingParenthesisIndex = line.IndexOf('(');
                int closingParenthesisIndex = line.IndexOf(')');

                if (openingParenthesisIndex == -1 || closingParenthesisIndex == -1)
                {
                    Console.WriteLine($"Invalid if statement on line {i + 1}: missing parenthesis");
                    errorsLine.Add(i+1);
                    continue;
                }

                string condition = line.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1).Trim();

                if (string.IsNullOrEmpty(condition))
                {
                    Console.WriteLine($"Invalid if statement on line {i + 1}: missing condition");
                    errorsLine.Add(i + 1);
                    continue;
                }

                if (condition != "Вверх" && condition != "Вниз" && condition != "Влево" && condition != "Вправо" && condition != "!Вверх" && condition != "!Вниз" && condition != "!Влево" && condition != "!Вправо")
                {
                    Console.WriteLine($"Invalid if statement on line {i + 1}: invalid condition");
                    errorsLine.Add(i + 1);
                    continue;
                }

                
                    if (lines[i].Contains("if("))
                    {
                        int ifIndex = lines[i].IndexOf("if(");

                        if (ifIndex != -1)
                        {
                            int openingBraceIndex = lines[i].IndexOf('{', ifIndex);

                            if (openingBraceIndex == -1)
                            {
                                bool braceFound = false;
                                for (int j = i + 1; j < lines.Length; j++)
                                {
                                    if (lines[j].Contains("{"))
                                    {
                                        braceFound = true;
                                        break;
                                    }
                                    else if (lines[j].Trim() != "")
                                    {
                                        Console.WriteLine($"Invalid if statement on line {i + 1}: missing opening brace");
                                        errorsLine.Add(i + 1);
                                        break;
                                    }
                                }

                                if (!braceFound)
                                {
                                    Console.WriteLine($"Invalid if statement on line {i + 1}: missing opening brace");
                                    errorsLine.Add(i + 1);
                                }
                            }
                        }
                    }
                

            }
        }

    }

    public void ValidateWhileStatement(string code)
    {
        string[] lines = code.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (line.StartsWith("While(!") || line.StartsWith("While("))
            {
                int openingParenthesisIndex = line.IndexOf('(');
                int closingParenthesisIndex = line.IndexOf(')');

                if (openingParenthesisIndex == -1 || closingParenthesisIndex == -1)
                {
                    Console.WriteLine($"Invalid While statement on line {i + 1}: missing parenthesis");
                    errorsLine.Add(i + 1);
                    continue;
                }

                string condition = line.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1).Trim();

                if (string.IsNullOrEmpty(condition))
                {
                    Console.WriteLine($"Invalid While statement on line {i + 1}: missing condition");
                    errorsLine.Add(i + 1);
                    continue;
                }

                if (condition != "Вверх" && condition != "Вниз" && condition != "Влево" && condition != "Вправо" && condition != "!Вверх" && condition != "!Вниз" && condition != "!Влево" && condition != "!Вправо")
                {
                    Console.WriteLine($"Invalid While statement on line {i + 1}: invalid condition");
                    errorsLine.Add(i + 1);
                    continue;
                }


                if (lines[i].Contains("While("))
                {
                    int WhileIndex = lines[i].IndexOf("While(");

                    if (WhileIndex != -1)
                    {
                        int openingBraceIndex = lines[i].IndexOf('{', WhileIndex);

                        if (openingBraceIndex == -1)
                        {
                            bool braceFound = false;
                            for (int j = i + 1; j < lines.Length; j++)
                            {
                                if (lines[j].Contains("{"))
                                {
                                    braceFound = true;
                                    break;
                                }
                                else if (lines[j].Trim() != "")
                                {
                                    Console.WriteLine($"Invalid While statement on line {i + 1}: missing opening brace");
                                    errorsLine.Add(i + 1);
                                    break;
                                }
                            }

                            if (!braceFound)
                            {
                                Console.WriteLine($"Invalid While statement on line {i + 1}: missing opening brace");
                                errorsLine.Add(i + 1);
                            }
                        }
                    }
                }


            }
        }

    }


    public void ValidateBrackets(string code)
    {
        Stack<int> stack = new Stack<int>();
        string[] lines = code.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            // Check for opening braces
            int openingBraceIndex = line.IndexOf('{');
            if (openingBraceIndex != -1)
            {
                stack.Push(i);
            }

            // Check for closing braces
            int closingBraceIndex = line.IndexOf('}');
            if (closingBraceIndex != -1)
            {
                if (stack.Count == 0)
                {
                    errorsLine.Add(i);
                }
                else
                {
                    stack.Pop();
                }
            }

            // Check for if, else and while blocks
            if (line.StartsWith("if ") || line.StartsWith("else ") || line.StartsWith("while "))
            {
                int openingBraceIndexLine = line.IndexOf('{');
                if (openingBraceIndexLine == -1)
                {
                    // If there is no opening brace, check the next line for an opening brace
                    if (i < lines.Length - 1)
                    {
                        string nextLine = lines[i + 1].Trim();
                        if (nextLine != "" && !nextLine.StartsWith("{"))
                        {
                            errorsLine.Add(i);
                        }
                    }
                }
            }
        }

        while (stack.Count > 0)
        {
            errorsLine.Add(stack.Pop());
        }

        if (errorsLine.Count > 0)
        {
            Console.WriteLine($"Code validation failed on lines: {string.Join(",", errorsLine)}");
        }
    }




    public List<int> Validate(string text)
    {
        ValidateCommand(text);
        ValidateIfStatement(text);
        ValidateWhileStatement(text);
        ValidateBrackets(text);
        return errorsLine;
    }



    public static List<string> Validate2(string code)
    {
        List<string> errors = new List<string>();

        string commandRegex = "^(" + String.Join("|", VALID_COMMANDS) + ")$";
        string ifConditionRegex = "^if\\((!?" + commandRegex + ")\\)$";
        string whileConditionRegex = "^While\\((!?" + commandRegex + ")\\)$";

        Stack<string> blockStack = new Stack<string>();
        int lineNumber = 1;

        foreach (string line in code.Split('\n'))
        {
            string trimmedLine = line.Trim();

            if (trimmedLine.Length == 0) // Пропускаем пустые строки
            {
                lineNumber++;
                continue;
            }

            if (trimmedLine.StartsWith("if"))
            {
                if (!Regex.IsMatch(trimmedLine, ifConditionRegex))
                {
                    errors.Add($"Line {lineNumber}: Неправильное условие в блоке if");
                }
                else if (!trimmedLine.EndsWith("{"))
                {
                    errors.Add($"Line {lineNumber}: Отсутствует открывающая скобка после блока if");
                }
                else
                {
                    blockStack.Push("if");
                }
            }
            else if (trimmedLine.StartsWith("else"))
            {
                if (blockStack.Count == 0 || blockStack.Peek() != "if")
                {
                    errors.Add($"Line {lineNumber}: Блок else не соответствует ни одному блоку if");
                }
                else if (!trimmedLine.EndsWith("{"))
                {
                    errors.Add($"Line {lineNumber}: Отсутствует открывающая скобка после блока else");
                }
                else
                {
                    blockStack.Pop(); // Убираем "if" из стека
                    blockStack.Push("else"); // Добавляем "else" в стек
                }
            }
            else if (trimmedLine.StartsWith("While"))
            {
                if (!Regex.IsMatch(trimmedLine, whileConditionRegex))
                {
                    errors.Add($"Line {lineNumber}: Неправильное условие в блоке While");
                }
                else if (!trimmedLine.EndsWith("{"))
                {
                    errors.Add($"Line {lineNumber}: Отсутствует открывающая скобка после блока while");
                }
                else
                {
                    blockStack.Push("while");
                }
            }
            else if (trimmedLine == "}")
            {
                if (blockStack.Count == 0)
                {
                    errors.Add($"Line {lineNumber}: Лишняя закрывающая скобка }}");
                }
                else
                {
                    string blockType = blockStack.Pop();

                    if (blockType == "if")
                    {
                        if (blockStack.Count > 0 && blockStack.Peek() == "else")
                        {
                            blockStack.Pop(); // Убираем "else" из стека                        continue;
                        }
                    }

                    if (blockType != "while")
                    {
                        errors.Add($"Line {lineNumber}: Лишняя закрывающая скобка }}");
                    }
                }
            }
            else // Обрабатываем строки с командами
            {
                if (!Regex.IsMatch(trimmedLine, commandRegex))
                {
                    errors.Add($"Line {lineNumber}: Неизвестная команда: {trimmedLine}");
                }
            }

            lineNumber++;
        }

        if (blockStack.Count > 0)
        {
            errors.Add($"Не хватает закрывающей скобки для блока {blockStack.Peek()}");
        }

        return errors;
    }
}
