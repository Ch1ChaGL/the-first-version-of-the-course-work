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
                        if(currComand.Length > 2) throw new Exception("Неверный синтаксис команды");
                    _robot.execute(currComand[0], int.Parse(currComand[1]));
                    }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
