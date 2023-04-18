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
        CommandBlock _comandBlock;
        Stack<List<string>> blockStack = new Stack<List<string>>();
        public ParserCommand(string text)
        {
            //_commands = text.Split('\n').ToList();
            //_commands.RemoveAll(string.IsNullOrEmpty);
            _comandBlock = ParseCommands(text);
            _interpreter = new CommandInterpreter();
        }

        public int ParseAll(Robot robot, Maze maze)
        {

                ParseCommandBlock(_comandBlock, robot, maze);
                if (robot.checkRobotStatus() == 1)
                {
                    return 1;
                }

            return robot.checkRobotStatus();
        }




        public int ParseNext(Robot robot)
        {
            return 0;
        }

       

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

        private void ParseCommandBlock(CommandBlock block, Robot robot, Maze maze)
        {
            foreach (var nestedBlock in block.NestedBlocks)
            {
                switch (nestedBlock.Type)
                {
                    case CommandBlockType.Command:
                        _interpreter.interpret(nestedBlock.Value, robot);
                        break;
                    case CommandBlockType.If:
                        if (CheckIfCondition(nestedBlock, robot, maze))
                        {
                            foreach (var commandBlock in nestedBlock.NestedBlocks)
                            {
                                if (commandBlock.Type == CommandBlockType.Command)
                                {
                                    if (robot.checkRobotStatus() == 1)
                                    {
                                        return;
                                    }
                                    _interpreter.interpret(commandBlock.Value, robot);
                                }
                                else
                                {
                                    ParseCommandBlock(commandBlock, robot, maze);
                                }
                            }
                        }
                        else if (nestedBlock.NestedBlocks.Count > 1 && nestedBlock.NestedBlocks[1].Type == CommandBlockType.Else)
                        {
                            ParseCommandBlock(nestedBlock.NestedBlocks[1], robot, maze);
                        }
                        break;
                    case CommandBlockType.Else:
                        foreach (var commandBlock in nestedBlock.NestedBlocks)
                        {
                            if (commandBlock.Type == CommandBlockType.Command)
                            {
                                if (robot.checkRobotStatus() == 1)
                                {
                                    return;
                                }
                                _interpreter.interpret(commandBlock.Value, robot);
                            }
                            else
                            {
                                ParseCommandBlock(commandBlock, robot, maze);
                            }
                        }
                        break;
                    case CommandBlockType.While:
                        while (CheckWhileCondition(nestedBlock, robot, maze))
                        {
                            ParseCommandBlock(nestedBlock.NestedBlocks[0], robot, maze);
                        }
                        break;
                    default:
                        throw new NotImplementedException($"Unhandled command block type: {nestedBlock.Type}");
                }
            }
        }




        private bool CheckIfCondition(CommandBlock ifBlock, Robot robot, Maze maze)
        {
            if (string.IsNullOrEmpty(ifBlock.Value))
            {
                // Если условие не указано, то считаем его выполненным
                return true;
            }
            else if (ifBlock.Value.StartsWith("!"))
            {
                // Если есть условие отрицания, то проверяем, есть ли стена в нужном направлении
                var direction = ifBlock.Value.Substring(1); // обрезаем восклицательный знак
                var x = robot.x;
                var y = robot.y;

                switch (direction)
                {
                    case "Вверх":
                        return maze.checkСell(x, y - 1) == 1;
                    case "Вниз":
                        return maze.checkСell(x, y + 1) == 1;
                    case "Влево":
                        return maze.checkСell(x - 1, y) == 1;
                    case "Вправо":
                        return maze.checkСell(x + 1, y) == 1;
                    default:
                        throw new InvalidOperationException($"Неверное направление: {direction}");
                }
            }
            else
            {
                // Если есть обычное условие, то проверяем, свободна ли клетка
                var x = robot.x;
                var y = robot.y;
                var direction = ifBlock.Value;
                switch (direction)
                {
                    case "Вверх":
                        return maze.checkСell(x, y - 1) == 0;
                    case "Вниз":
                        return maze.checkСell(x, y + 1) == 0;
                    case "Влево":
                        return maze.checkСell(x - 1, y) == 0;
                    case "Вправо":
                        return maze.checkСell(x + 1, y) == 0;
                    default:
                        throw new InvalidOperationException($"Неверное направление: {direction}");
                }
            }
        }



        private bool CheckWhileCondition(CommandBlock whileBlock, Robot robot, Maze maze)
        {
            return CheckIfCondition(whileBlock, robot, maze);
        }







    }
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