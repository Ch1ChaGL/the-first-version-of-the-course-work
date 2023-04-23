using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RobotFirstVersion.CommandBlock;

namespace RobotFirstVersion
{
    internal class ParserCommand
    { 
        private readonly CommandInterpreter _interpreter;
        private int _currentCommandIndex = 0;
        CommandBlock _comandBlock;
        private List<CommandBlock> _commandQueue = new List<CommandBlock>();
        int x;
        int y;
        public ParserCommand(string text, Robot robot, Maze maze)
        {
            
            //_commands = text.Split('\n').ToList();
            //_commands.RemoveAll(string.IsNullOrEmpty);
            x = robot.x;
            y = robot.y;
            _comandBlock = ParseCommands(text);
            _interpreter = new CommandInterpreter();
            AddCommandsToQueue(_comandBlock, robot, maze);
        }

        public async Task<int> ParseAll(Robot robot, CancellationToken cancellationToken)
        {
            for (int i = _currentCommandIndex; i < _commandQueue.Count; i++)
            {
               
                _interpreter.interpret(_commandQueue[i].Value, robot);
                try
                {
                    await Task.Delay(300, cancellationToken);
                    _currentCommandIndex++;
                }
                catch (OperationCanceledException)
                {
                    return -1;
                }
               
            }     
            
            _currentCommandIndex = 0;
            return robot.checkRobotStatus();
        }

       
      

        public int parseNext(Robot robot, Maze maze)
        {
          
            _interpreter.interpret(_commandQueue[_currentCommandIndex].Value, robot);
            _currentCommandIndex++;
            if (_currentCommandIndex == _commandQueue.Count) { _currentCommandIndex = 0; return robot.checkRobotStatus(); }

            return -1;

        }
        int skipElse = 0;
        private void AddCommandsToQueue(CommandBlock block, Robot robot, Maze maze)
        {
            try 
            {
                foreach (var nestedBlock in block.NestedBlocks)
                {
                    if (skipElse > 0 && block.Type == CommandBlockType.Else) { skipElse--; continue; }
                    switch (nestedBlock.Type)
                    {
                        case CommandBlockType.Command:
                            if (nestedBlock.Value == "Вверх") y--;
                            else if (nestedBlock.Value == "Вниз") y++;
                            else if (nestedBlock.Value == "Влево") x--;
                            else if (nestedBlock.Value == "Вправо") x++;
                            _commandQueue.Add(nestedBlock);
                            if (maze.checkСell(x, y) == 1) return;
                            break;
                        case CommandBlockType.If:
                            if (nestedBlock.Type == CommandBlockType.If && CheckIfCondition(nestedBlock, robot, maze))
                            {

                                foreach (var commandBlock in nestedBlock.NestedBlocks)
                                {
                                    skipElse++;
                                    if (commandBlock.Type == CommandBlockType.Command)
                                    {
                                        if (commandBlock.Value == "Вверх") y--;
                                        else if (commandBlock.Value == "Вниз") y++;
                                        else if (commandBlock.Value == "Влево") x--;
                                        else if (commandBlock.Value == "Вправо") x++;
                                        _commandQueue.Add(commandBlock);
                                        if (maze.checkСell(x, y) == 1) return;

                                    }
                                    else if (commandBlock.Type == CommandBlockType.While)
                                    {
                                        while (CheckWhileCondition(commandBlock, robot, maze))
                                        {
                                            AddCommandsToQueue(commandBlock, robot, maze);
                                        }
                                    }
                                    else if (commandBlock.Type == CommandBlockType.If && CheckIfCondition(commandBlock, robot, maze))
                                    {
                                        skipElse++;
                                        if (CheckIfCondition(commandBlock, robot, maze))
                                        {
                                            foreach (var nestedCommandBlock in commandBlock.NestedBlocks)
                                            {
                                                if (nestedCommandBlock.Type == CommandBlockType.Command)
                                                {
                                                    if (nestedCommandBlock.Value == "Вверх") y--;
                                                    else if (nestedCommandBlock.Value == "Вниз") y++;
                                                    else if (nestedCommandBlock.Value == "Влево") x--;
                                                    else if (nestedCommandBlock.Value == "Вправо") x++;
                                                    _commandQueue.Add(nestedCommandBlock);
                                                    if (maze.checkСell(x, y) == 1) return;
                                                }
                                                else if (nestedCommandBlock.Type == CommandBlockType.While)
                                                {
                                                    while (CheckWhileCondition(nestedCommandBlock, robot, maze))
                                                    {
                                                        AddCommandsToQueue(nestedCommandBlock, robot, maze);
                                                    }
                                                }
                                                else
                                                {
                                                    AddCommandsToQueue(nestedCommandBlock, robot, maze);
                                                }
                                            }
                                        }
                                        else if (commandBlock.NestedBlocks.Count > 1 && commandBlock.NestedBlocks[1].Type == CommandBlockType.Else)
                                        {
                                            // do nothing, skip commands in the else block
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        AddCommandsToQueue(commandBlock, robot, maze);
                                    }
                                }
                            }
                            else if (nestedBlock.NestedBlocks.Count > 1 && nestedBlock.Type == CommandBlockType.Else)
                            {
                                if (skipElse > 0) { skipElse--; continue; }
                                foreach (var commandBlock in nestedBlock.NestedBlocks[1].NestedBlocks)
                                {
                                    if (commandBlock.Type == CommandBlockType.Command)
                                    {
                                        if (commandBlock.Value == "Вверх") y--;
                                        else if (commandBlock.Value == "Вниз") y++;
                                        else if (commandBlock.Value == "Влево") x--;
                                        else if (commandBlock.Value == "Вправо") x++;
                                        _commandQueue.Add(commandBlock);
                                        if (maze.checkСell(x, y) == 1) return;
                                    }
                                    else if (commandBlock.Type == CommandBlockType.While)
                                    {
                                        while (CheckWhileCondition(commandBlock, robot, maze))
                                        {
                                            AddCommandsToQueue(commandBlock, robot, maze);
                                        }
                                    }
                                    else
                                    {
                                        AddCommandsToQueue(commandBlock, robot, maze);
                                    }
                                }
                            }
                            break;
                        case CommandBlockType.Else:
                            if (skipElse > 0) { skipElse--; continue; }
                            foreach (var commandBlock in nestedBlock.NestedBlocks)
                            {
                                if (commandBlock.Type == CommandBlockType.Command)
                                {
                                    if (robot.checkRobotStatus() == 1)
                                    {
                                        return;
                                    }
                                    if (commandBlock.Value == "Вверх") y--;
                                    else if (commandBlock.Value == "Вниз") y++;
                                    else if (commandBlock.Value == "Влево") x--;
                                    else if (commandBlock.Value == "Вправо") x++;
                                    _commandQueue.Add(commandBlock);
                                    if (maze.checkСell(x, y) == 1) return;
                                }
                                else if (commandBlock.Type == CommandBlockType.While)
                                {
                                    while (CheckWhileCondition(commandBlock, robot, maze))
                                    {
                                        AddCommandsToQueue(commandBlock, robot, maze);
                                    }
                                }
                                else
                                {
                                    AddCommandsToQueue(commandBlock, robot, maze);
                                }
                            }
                            break;
                        case CommandBlockType.While:
                            TimeSpan limit = TimeSpan.FromSeconds(10); // установим лимит времени выполнения цикла в 10 секунд
                            DateTime startTime = DateTime.Now;
                            while (CheckWhileCondition(nestedBlock, robot, maze))
                            {
                                if (DateTime.Now - startTime > limit)
                                {
                                    throw new Exception("Бесконечный цикл обнаружен!"); // выбрасываем исключение, если лимит превышен
                                }
                                foreach (var commandBlock in nestedBlock.NestedBlocks)
                                {
                                    if (commandBlock.Type == CommandBlockType.Command)
                                    {
                                        if (commandBlock.Value == "Вверх") y--;
                                        else if (commandBlock.Value == "Вниз") y++;
                                        else if (commandBlock.Value == "Влево") x--;
                                        else if (commandBlock.Value == "Вправо") x++;
                                        _commandQueue.Add(commandBlock);
                                        if (maze.checkСell(x, y) == 1) return;
                                    }
                                    else if (commandBlock.Type == CommandBlockType.While)
                                    {
                                        while (CheckWhileCondition(commandBlock, robot, maze))
                                        {
                                            AddCommandsToQueue(commandBlock, robot, maze);
                                        }
                                    }
                                    else if (commandBlock.Type == CommandBlockType.If)
                                    {
                                        if (CheckIfCondition(commandBlock, robot, maze))
                                        {
                                            skipElse++;
                                            foreach (var nestedCommandBlock in commandBlock.NestedBlocks)
                                            {
                                                if (nestedCommandBlock.Type == CommandBlockType.Command)
                                                {
                                                    if (nestedCommandBlock.Value == "Вверх") y--;
                                                    else if (nestedCommandBlock.Value == "Вниз") y++;
                                                    else if (nestedCommandBlock.Value == "Влево") x--;
                                                    else if (nestedCommandBlock.Value == "Вправо") x++;

                                                    _commandQueue.Add(nestedCommandBlock);
                                                    if (maze.checkСell(x, y) == 1) return;

                                                }
                                                else if (nestedCommandBlock.Type == CommandBlockType.While)
                                                {
                                                    while (CheckWhileCondition(nestedCommandBlock, robot, maze))
                                                    {
                                                        AddCommandsToQueue(nestedCommandBlock, robot, maze);
                                                    }
                                                }
                                                else
                                                {
                                                    AddCommandsToQueue(nestedCommandBlock, robot, maze);
                                                }
                                            }
                                        }
                                    }
                                    else if (commandBlock.Type == CommandBlockType.Else)
                                    {
                                        if (skipElse > 0) { skipElse--; continue; }
                                        foreach (var commandBlock2 in commandBlock.NestedBlocks)
                                        {
                                            if (commandBlock2.Type == CommandBlockType.Command)
                                            {
                                                if (commandBlock2.Value == "Вверх") y--;
                                                else if (commandBlock2.Value == "Вниз") y++;
                                                else if (commandBlock2.Value == "Влево") x--;
                                                else if (commandBlock2.Value == "Вправо") x++;
                                                _commandQueue.Add(commandBlock2);
                                                if (maze.checkСell(x, y) == 1) return;
                                            }
                                            else if (commandBlock2.Type == CommandBlockType.While)
                                            {
                                                while (CheckWhileCondition(commandBlock2, robot, maze))
                                                {
                                                    AddCommandsToQueue(commandBlock2, robot, maze);
                                                }
                                            }
                                            else
                                            {
                                                AddCommandsToQueue(commandBlock2, robot, maze);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        AddCommandsToQueue(commandBlock, robot, maze);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                _commandQueue.Clear();
            }
         
            
           
            
        }

        public CommandBlock ParseCommands(string text)
        {
            var lines = text.Split(new[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
                    string condition;
                    if (line.EndsWith("{")) condition = line.Substring(3, line.Length - 5);
                    else condition = line.Substring(3, line.Length - 4);
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
                else if (line.StartsWith("While("))
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
                x = robot.x;
                y = robot.y;
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
                                else if (commandBlock.Type == CommandBlockType.While)
                                {
                                    while (CheckWhileCondition(commandBlock, robot, maze))
                                    {
                                        ParseCommandBlock(commandBlock, robot, maze);
                                        if(robot.checkRobotStatus() == 1) break;
                                    }
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
                            else if (commandBlock.Type == CommandBlockType.While)
                            {
                                while (CheckWhileCondition(commandBlock, robot, maze))
                                {
                                    ParseCommandBlock(commandBlock, robot, maze);
                                }
                            }
                            else
                            {
                                ParseCommandBlock(commandBlock, robot, maze);
                            }
                        }
                        break;
                    case CommandBlockType.While:
                        if (robot.checkRobotStatus() == 1) return;
                        while (CheckWhileCondition(nestedBlock, robot, maze))
                        {
                            foreach (var commandBlock in nestedBlock.NestedBlocks)
                            {
                                if (commandBlock.Type == CommandBlockType.Command)
                                {
                                    _interpreter.interpret(commandBlock.Value, robot);
                                    if (robot.checkRobotStatus() == 1)
                                    {
                                        return;
                                    }
                                }
                                else if (commandBlock.Type == CommandBlockType.While)
                                {
                                    while (CheckWhileCondition(commandBlock, robot, maze))
                                    {
                                        ParseCommandBlock(commandBlock, robot, maze);
                                        if (robot.checkRobotStatus() == 1) return;
                                    }
                                }
                                else if (commandBlock.Type == CommandBlockType.If)
                                {
                                    if (CheckIfCondition(commandBlock, robot, maze))
                                    {
                                        foreach (var nestedCommandBlock in commandBlock.NestedBlocks)
                                        {
                                            if (nestedCommandBlock.Type == CommandBlockType.Command)
                                            {
                                                _interpreter.interpret(nestedCommandBlock.Value, robot);
                                                if (robot.checkRobotStatus() == 1)
                                                {
                                                    return;
                                                }
                                            }
                                            else if (nestedCommandBlock.Type == CommandBlockType.While)
                                            {
                                                while (CheckWhileCondition(nestedCommandBlock, robot, maze))
                                                {
                                                    ParseCommandBlock(nestedCommandBlock, robot, maze);
                                                    if (robot.checkRobotStatus() == 1) break;
                                                }
                                            }
                                            else
                                            {
                                                ParseCommandBlock(nestedCommandBlock, robot, maze);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    ParseCommandBlock(commandBlock, robot, maze);
                                }
                            }
                        }
                        break;
                    default:
                        throw new ArgumentException($"Unknown command block type: {nestedBlock.Type}");
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
               
                //var x = robot.x;
                //var y = robot.y;
                
                

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
                //var x = robot.x;
                //var y = robot.y;
                var direction = ifBlock.Value;
                switch (direction)
                {
                    case "Вверх":
                        return maze.checkСell(x, y - 1) == 0 || maze.checkСell(x, y - 1) == 3;
                    case "Вниз":
                        return maze.checkСell(x, y + 1) == 0 || maze.checkСell(x, y + 1) == 3;
                    case "Влево":
                        return maze.checkСell(x - 1, y) == 0 || maze.checkСell(x - 1, y) == 3;
                    case "Вправо":
                        return maze.checkСell(x + 1, y) == 0 || maze.checkСell(x + 1, y) == 3;
                    default:
                        throw new InvalidOperationException($"Неверное направление: {direction}");
                }
            }
        }



        private bool CheckWhileCondition(CommandBlock whileBlock, Robot robot, Maze maze)
        {
            if (string.IsNullOrEmpty(whileBlock.Value))
            {
                // Если условие не указано, то считаем его выполненным
                return true;
            }
            else if (whileBlock.Value.StartsWith("!"))
            {
                // Если есть условие отрицания, то проверяем, есть ли стена в нужном направлении
                var direction = whileBlock.Value.Substring(1); // обрезаем восклицательный знак
                //var x = robot.x;
                //var y = robot.y;

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
                //var x = robot.x;
                //var y = robot.y;
                var direction = whileBlock.Value;
                switch (direction)
                {
                    case "Вверх":
                        return maze.checkСell(x, y - 1) == 0 || maze.checkСell(x, y - 1) == 3;
                    case "Вниз":
                        return maze.checkСell(x, y + 1) == 0 || maze.checkСell(x, y + 1) == 3;
                    case "Влево":
                        return maze.checkСell(x - 1, y) == 0 || maze.checkСell(x - 1, y) == 3;
                    case "Вправо":
                        return maze.checkСell(x + 1, y) == 0 || maze.checkСell(x + 1, y) == 3;
                    default:
                        throw new InvalidOperationException($"Неверное направление: {direction}");
                }
            }
        }
    }
}

