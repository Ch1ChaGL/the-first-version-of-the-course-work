using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static RobotFirstVersion.CommandBlock;

namespace RobotFirstVersion
{
    internal class ParserCommand
    {
        private readonly List<CommandBlock> _commands = new List<CommandBlock>();
        //private readonly List<string> _commands = new List<string>();
        private readonly CommandInterpreter _interpreter;
        private int _currentCommandIndex = 0;
        private Maze maze;
        Stack<List<string>> blockStack = new Stack<List<string>>();
        public ParserCommand(string text)
        {
            //_commands = text.Split('\n').ToList();
            //_commands.RemoveAll(string.IsNullOrEmpty);
            ParseCommands(text);
            _interpreter = new CommandInterpreter();
        }

        public int ParseAll(Robot robot)
        {
            foreach (var command in _commands)
            {
                //_interpreter.interpret(command, robot); 
                if(robot.checkRobotStatus() == 1)
                {
                    return 1;
                }
            }
            return robot.checkRobotStatus();
        }



        public int ParseNext(Robot robot)
        {
            return 0;
        }

        //public int ParseNext(Robot robot)
        //{
        //    if (_currentCommandIndex < _commands.Count)
        //    {
        //        var command = _commands[_currentCommandIndex];
        //        _interpreter.interpret(command, robot);
        //        _currentCommandIndex++;
        //        if (robot.checkRobotStatus() == 1)
        //        {
        //            return 1;
        //        }
        //        if (_currentCommandIndex == _commands.Count)
        //        {
        //            return robot.checkRobotStatus();
        //        }
        //        return -1;
        //    }
        //    return 0;
        //}


        //public CommandBlock ParseCommands(string text)
        //{
        //    var lines = text.Split('\n');
        //    var index = 0;

        //    var blockStack = new Stack<CommandBlock>();
        //    var rootBlock = new CommandBlock(CommandBlockType.Command, "");
        //    blockStack.Push(rootBlock);

        //    while (index < lines.Length)
        //    {
        //        var line = lines[index].Trim();
        //        if (string.IsNullOrEmpty(line))
        //        {
        //            index++;
        //            continue;
        //        }

        //        if (line.StartsWith("if("))
        //        {
        //            var condition = line.Substring(3, line.Length - 4);
        //            var ifBlock = new CommandBlock(CommandBlockType.If, condition);
        //            blockStack.Peek().NestedBlocks.Add(ifBlock);
        //            blockStack.Push(ifBlock);
        //        }
        //        else if (line == "}")
        //        {
        //            blockStack.Pop();
        //        }
        //        else if (line.StartsWith("else"))
        //        {
        //            var elseBlock = new CommandBlock(CommandBlockType.Else, "");
        //            blockStack.Peek().NestedBlocks.Add(elseBlock);
        //            blockStack.Push(elseBlock);
        //        }
        //        else if (line.StartsWith("while("))
        //        {
        //            var condition = line.Substring(6, line.Length - 7);
        //            var whileBlock = new CommandBlock(CommandBlockType.While, condition);
        //            blockStack.Peek().NestedBlocks.Add(whileBlock);
        //            blockStack.Push(whileBlock);
        //        }
        //        else
        //        {
        //            var commandBlock = new CommandBlock(CommandBlockType.Command, line);

        //            blockStack.Peek().NestedBlocks.Add(commandBlock);
        //        }

        //        index++;
        //    }

        //    return rootBlock;
        //}

        public CommandBlock ParseCommands(string text)
        {
            var lines = text.Split('\n');
            var index = 0;

            var blockStack = new Stack<CommandBlock>();
            var rootBlock = new CommandBlock(CommandBlockType.Command, "");
            blockStack.Push(rootBlock);

            while (index < lines.Length)
            {
                var line = lines[index].Trim();
                if (string.IsNullOrEmpty(line))
                {
                    index++;
                    continue;
                }

                if (line.StartsWith("if("))
                {
                    var condition = line.Substring(3, line.Length - 4);
                    var ifBlock = new CommandBlock(CommandBlockType.If, condition);
                    blockStack.Peek().NestedBlocks.Add(ifBlock);
                    blockStack.Push(ifBlock);
                }
                else if (line == "}")
                {
                    blockStack.Pop();
                }
                else if (line.StartsWith("else"))
                {
                    var elseBlock = new CommandBlock(CommandBlockType.Else, "");
                    blockStack.Peek().NestedBlocks.Add(elseBlock);
                    blockStack.Push(elseBlock);
                }
                else if (line.StartsWith("while("))
                {
                    var condition = line.Substring(6, line.Length - 7);
                    var whileBlock = new CommandBlock(CommandBlockType.While, condition);
                    blockStack.Peek().NestedBlocks.Add(whileBlock);
                    blockStack.Push(whileBlock);
                }
                else if (line == "{")
                {
                    // Пропускаем фигурную скобку в блоке с if
                }
                else
                {
                    var commandBlock = new CommandBlock(CommandBlockType.Command, line);
                    blockStack.Peek().NestedBlocks.Add(commandBlock);
                }

                index++;
            }

            return rootBlock;
        }








    }
}
