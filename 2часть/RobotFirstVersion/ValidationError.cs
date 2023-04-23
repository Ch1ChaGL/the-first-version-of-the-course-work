using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RobotFirstVersion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class ValidationError
{
    List<int> errorsLine = new List<int>();

    RichTextBox _richTextBox;
    public ValidationError(RichTextBox richTextBox)
    {
        _richTextBox = richTextBox;
    }
    public void ValidateCommand(string input)
    {
       
        string[] keywords = { "if(", "else", "While(", "}", "{" , " " };
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

    





















    public bool Validate(string text)
    {
        errorsLine.Clear();
        ValidateCommand(text);
        ValidateIfStatement(text);
        ValidateWhileStatement(text);
        ErrorFinder errorFinder = new ErrorFinder();
        errorFinder.FindErrors(text, errorsLine);
        for (int i = 0; i < errorsLine.Count; i++)
        {
            Console.WriteLine( errorsLine[i]);
        }
        invalidСodeHighlighting();
        return errorsLine.Count == 0;
    }
    public void invalidСodeHighlighting()
    {
        // Делаем все строки черными
        for (int i = 0; i < _richTextBox.Lines.Length; i++)
        {
            _richTextBox.SelectionStart = _richTextBox.GetFirstCharIndexFromLine(i);
            _richTextBox.SelectionLength = _richTextBox.Lines[i].Length;
            _richTextBox.SelectionColor = Color.Black;
        }

        string[] lines = _richTextBox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            if (errorsLine.Contains(i + 1))
            {
                _richTextBox.Select(_richTextBox.GetFirstCharIndexFromLine(i), lines[i].Length);
                _richTextBox.SelectionColor = Color.Red;
            }
        }
    }


  
}
