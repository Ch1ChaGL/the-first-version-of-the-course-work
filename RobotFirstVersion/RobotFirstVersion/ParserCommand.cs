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

        public void ParseAll(Robot robot)
        {
            foreach (var command in _commands)
            {
                _interpreter.interpret(command, robot);
            }
        }

        public bool ParseNext(Robot robot)
        {
            if (_currentCommandIndex < _commands.Count)
            {
                var command = _commands[_currentCommandIndex];
                 _interpreter.interpret(command,robot);
                _currentCommandIndex++;
                return true;
            }
            return false;
        }
    }
}
