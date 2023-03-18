using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RobotFirstVersion
{
    public partial class Game : Form
    {
        Maze maze;
        Robot robot;
        ParserCommand parser = null;
        public Game(int[,] map)
        {
            InitializeComponent();
            robot = new Robot(1,2);
            maze = new Maze(map, robot ,pictureBox1);
            robot.setMaze(maze);


        }

        private void Down_Click(object sender, EventArgs e)
        {
            robot.moveDown();
        }

        //private void Up_Click(object sender, EventArgs e)
        //{
        //    TextField.Text += "Вверх\n";
        //}

        //private void Down_Click_1(object sender, EventArgs e)
        //{
        //    TextField.Text += "Вниз\n";
        //}

        //private void Left_Click(object sender, EventArgs e)
        //{
        //    TextField.Text += "Влево\n";
        //}

        //private void Right_Click(object sender, EventArgs e)
        //{
        //    TextField.Text += "Вправо\n";
        //}

        private void Play_Click(object sender, EventArgs e)
        {   parser = new ParserCommand(TextField.Text);
            result(parser.ParseAll(robot));            
        }

        private void NextStep_Click(object sender, EventArgs e)
        {   
            if(parser == null)
            {
                parser = new ParserCommand(TextField.Text);
            }
            int value = parser.ParseNext(robot);
            if (value != -1)
            {
                result(value);
                parser = null;
            }
        }

        private void result(int res)
        {
            if(res == 1)
            {
                MessageBox.Show("Вы разбились");
                maze.resetMap();
            }
            if (res == 3)
            {
                MessageBox.Show("Вы победили");
                maze.resetMap();
            }
            if (res == 0)
            {
                MessageBox.Show("Вы не прошли лабиринт");
                maze.resetMap();
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            
        }

        private void TextField_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Вставляем текст из буфера обмена
                TextField.Paste();

            }
            if (TextField.Text.Length > 0) {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    Clipboard.SetText(TextField.SelectedText);
                    e.Handled = true;
                }              
                else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                {
                    FnDelete();
                    e.Handled = true;
                }



            }          
        }

        private void Up_Click(object sender, EventArgs e)
        {
            string direction = "";
            var button = sender as Button;
            if (button.Name == "Up")
            {
                direction = "Вверх\n";
            }
            if (button.Name == "Left")
            {
                direction = "Влево\n";
            }
            if (button.Name == "Down")
            {
                direction = "Вниз\n";
            }
            if (button.Name == "Right")
            {
                direction = "Вправо\n";
            }

            // Получаем номер строки, на которой находится курсор
            int currentLineIndex = TextField.GetLineFromCharIndex(TextField.SelectionStart);

            // Находим начало следующей строки
            int nextLineStart = TextField.GetFirstCharIndexFromLine(currentLineIndex + 1);
            if (nextLineStart == -1)
            {
                // Если следующей строки нет, то добавляем слово в конец текста
                nextLineStart = TextField.Text.Length;              
            }
           

            // Добавляем слово на позицию nextLineStart
            TextField.Text = TextField.Text.Insert(nextLineStart, direction);

            // Перемещаем курсор в конец добавленного слова
            TextField.SelectionStart = nextLineStart + direction.Length;

            // Перемещаем фокус на текстовое поле
            TextField.Focus();
        }




        private void FnDelete()
        {
            int currentLineIndex = TextField.GetLineFromCharIndex(TextField.SelectionStart);
            int currentLineStart = TextField.GetFirstCharIndexFromLine(currentLineIndex);
            int currentLineEnd = TextField.GetFirstCharIndexFromLine(currentLineIndex + 1);
            if (currentLineEnd == -1)
            {
                //currentLineEnd = TextField.Text.Length;
                currentLineEnd = currentLineStart;
                currentLineStart = TextField.GetFirstCharIndexFromLine(currentLineIndex - 1);

                if (currentLineStart == -1)
                {
                    currentLineStart = 0;
                }
            }



            // Сохраняем текущую позицию курсора
            int cursorPosition = TextField.SelectionStart;



            TextField.Text = TextField.Text.Remove(currentLineStart, currentLineEnd - currentLineStart);


            // Восстанавливаем позицию курсора
            if (cursorPosition >= currentLineStart)
            {
                if (cursorPosition <= currentLineEnd)
                {
                    TextField.SelectionStart = currentLineStart;
                }
                else
                {
                    TextField.SelectionStart = cursorPosition - (currentLineEnd - currentLineStart);
                }
            }
        }
        private void FnClear() { TextField.Clear(); }
        private void FnCopy()
        {
            Clipboard.SetText(TextField.Text);
        }
        private void FnReset()
        {
            TextField.Text = "";
            maze.resetMap();
            parser = null;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if(button.Name == "Delete")
            {
                FnDelete();
            }
            if (button.Name == "Clear")
            {
                FnClear();
            }
            if (button.Name == "Reset")
            {
                FnReset();
            }
            if (button.Name == "Copy")
            {
                FnCopy();
            }
        }
    }
}
