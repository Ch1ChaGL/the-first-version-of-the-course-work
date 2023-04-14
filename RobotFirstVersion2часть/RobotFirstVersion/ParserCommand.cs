using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotFirstVersion
{
    internal class ParserCommand
    {
        private readonly List<string> _commands;
        private readonly CommandInterpreter _interpreter;
        private int _currentCommandIndex = 0;

        public ParserCommand(string text)
        {
            _commands = text.Split('\n').ToList();
            _commands.RemoveAll(string.IsNullOrEmpty);
            _interpreter = new CommandInterpreter();
        }

        public int ParseAll(Robot robot)
        {
            foreach (var command in _commands)
            {
                _interpreter.interpret(command, robot); 
                if(robot.checkRobotStatus() == 1)
                {
                    return 1;
                }
            }
            return robot.checkRobotStatus();
        }

        public int ParseNext(Robot robot)
        {
            if (_currentCommandIndex < _commands.Count)
            {
                var command = _commands[_currentCommandIndex];
                 _interpreter.interpret(command,robot);
                _currentCommandIndex++;
                if (robot.checkRobotStatus() == 1)
                {
                    return 1;
                }
                if(_currentCommandIndex == _commands.Count)
                {
                    return robot.checkRobotStatus();
                }
                return -1;
            }
            return 0;
        }
    }
}
