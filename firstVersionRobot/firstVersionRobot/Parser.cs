using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace firstVersionRobot
{
    internal class Parser
    {
        private Robot _robot;
        private RichTextBox _richTextBox;
        private int _width;
        private int _height;

        public Parser(int width, int height, Robot robot, RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;
            _robot = robot;
            _width = width;
            _height = height;
            InitializeRichTextBox();
        }
        private void InitializeRichTextBox()
        {
            _richTextBox.Width = _width;
            _richTextBox.Height = _height;
        }

        public void parseText()
        {   
            
            try
            {
                string[] currComand;
                string[] commands = _richTextBox.Text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                
                    foreach(string command in commands)
                    {   
                   
                        currComand = command.Split(' ');
                        if (currComand.Length == 2)
                        {
                            _robot.execute(currComand[0], int.Parse(currComand[1]));
                        }
                        if (currComand[0] == "while")
                        {
                        // Проверяем, что второй токен является одним из направлений
                        if (currComand[1] != "up" && currComand[1] != "down" && currComand[1] != "left" && currComand[1] != "right")
                        {
                            throw new Exception("Ошибка: ожидалось одно из направлений");
                        }

                        // Проверяем, что третий токен является "clear"
                        if (currComand[2] != "clear" && currComand[2] != "not_clear")
                        {
                            throw new Exception("Ошибка: ожидалось 'clear'");
                        }

                        // Проверяем, что четвертый токен является одним из направлений
                        if (currComand[3] != "up" && currComand[3] != "down" && currComand[3] != "left" && currComand[3] != "right")
                        {
                            throw new Exception("Ошибка: ожидалось одно из направлений");
                        }                        
                        // Если все проверки прошли успешно, вызываем метод execute                        
                         _robot.execute(currComand);
                       
                       

                    }

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
