using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotFirstVersion
{
    internal class CommandInterpreter
    {

        public void interpret(string text, Robot _robot)
        {
            switch (text)
            {
                case "Вверх":
                    {
                        _robot.moveUp();
                        break;
                    }
                case "Вниз":
                    {
                        _robot.moveDown();
                        break;
                    }
                case "Влево":
                    {
                        _robot.moveLeft();
                        break;
                    }
                case "Вправо":
                    {
                        _robot.moveRight();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Позови маму, тут проблемы");
                        break;
                    }
                   
            }
        }
    }
}
