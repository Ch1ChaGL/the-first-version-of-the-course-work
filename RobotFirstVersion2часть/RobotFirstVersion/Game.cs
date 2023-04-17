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
        public Game(int[,] map, int robotX, int robotY)
        {
            InitializeComponent();
            robot = new Robot(robotX, robotY);
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
        {            
        }

        private void NextStep_Click(object sender, EventArgs e)
        {   
           
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

                IDataObject clipboardData = Clipboard.GetDataObject();

                if (clipboardData.GetDataPresent(DataFormats.UnicodeText))
                {
                    string text = (string)clipboardData.GetData(DataFormats.UnicodeText);
                    TextField.SelectedText = text;
                }

                // Предотвращаем вставку остальных данных из буфера обмена
                e.Handled = true;


            }
            if (TextField.Text.Length > 0)
            {
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

            if (currentLineIndex >= 0 && currentLineIndex < TextField.Lines.Length &&
                        string.IsNullOrWhiteSpace(TextField.Lines[currentLineIndex]) && currentLineIndex > 0)
            {
                currentLineStart = GetPreviousLineStart(currentLineIndex);
            }

            if (currentLineStart == -1 && currentLineIndex > 0)
            {
                currentLineStart = GetPreviousLineStart(currentLineIndex);
                if (currentLineEnd == -1)
                {
                    currentLineEnd = TextField.Text.Length;
                }
            }

            if (currentLineStart >= 0 && currentLineIndex >= 0)
            {               
                if (currentLineEnd == -1)
                {
                    currentLineEnd = TextField.Text.Length;
                }

                // Сохраняем текущую позицию курсора
                int cursorPosition = TextField.SelectionStart;

                // Используем текущий индекс строки и индекс начала следующей строки, чтобы удалить всю текущую строку
                TextField.Text = TextField.Text.Remove(currentLineStart, currentLineEnd - currentLineStart);

                // Восстанавливаем позицию курсора
                if (cursorPosition >= currentLineStart)
                {
                    TextField.SelectionStart = currentLineStart;
                }
                else
                {
                    TextField.SelectionStart = cursorPosition;
                }
            }
        }
        private int GetPreviousLineStart(int currentLineIndex)
        {
            currentLineIndex--;
            int currentLineStart = TextField.GetFirstCharIndexFromLine(currentLineIndex);
            int nextLineStart = TextField.GetFirstCharIndexFromLine(currentLineIndex + 1);
            if (nextLineStart == -1)
            {
                nextLineStart = TextField.Text.Length;
            }
            return currentLineStart;
        }

        private void FnClear() { TextField.Clear(); }
        private void FnCopy()
        {
            if(TextField.Text.Length > 0)
            {
                Clipboard.SetText(TextField.Text);
            }
            else
            {
                return;
            }
            
        }
        private void FnReset()
        {
            TextField.Text = "";
            maze.resetMap();
            parser = null;
        }
        private void FnInsert()
        {
            IDataObject clipboardData = Clipboard.GetDataObject();

            if (clipboardData.GetDataPresent(DataFormats.Text))
            {
                string text = (string)clipboardData.GetData(DataFormats.Text);
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                string convertedText = Encoding.GetEncoding("windows-1251").GetString(bytes);
                TextField.SelectedText = text;
            }
            else
            {
                MessageBox.Show("Данные в буфере обмена не являются текстом или отсутствуют.", "Ошибка");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if(button.Name == "Delete")
            {
                FnDelete();
                TextField.Focus();
            }
            if (button.Name == "Clear")
            {
                FnClear();
                TextField.Focus();
            }
            if (button.Name == "Reset")
            {
                FnReset();
                TextField.Focus();
            }
            if (button.Name == "Copy")
            {
                FnCopy();
                TextField.Focus();
            }
            if(button.Name == "Insert")
            {
                FnInsert();
                TextField.Focus();
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripMenuItem;

            if (button.Name == "Delete")
            {
                FnDelete();
                TextField.Focus();
            }
            if (button.Name == "Clear")
            {
                FnClear();
                TextField.Focus();
            }
            if (button.Name == "Reset")
            {
                FnReset();
                TextField.Focus();
            }
            if (button.Name == "Copy")
            {
                FnCopy();
                TextField.Focus();
            }
            if (button.Name == "Insert")
            {
                FnInsert();
                TextField.Focus();
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parser = new ParserCommand(TextField.Text);
            result(parser.ParseAll(robot));
        }

        private void nextStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (parser == null)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ifBtn_Click(object sender, EventArgs e)
        {
            string template = "if ()\n{\n\t\n}\n";
            int currentLineIndex = TextField.GetLineFromCharIndex(TextField.SelectionStart);
            int nextLineStart = TextField.GetFirstCharIndexFromLine(currentLineIndex + 1);
            if (nextLineStart == -1)
            {
                nextLineStart = TextField.Text.Length;
            }
            TextField.Text = TextField.Text.Insert(nextLineStart, template);
            TextField.SelectionStart = nextLineStart + template.Length - 5;
            TextField.Focus();

            // Перемещаем курсор внутрь скобок
            TextField.SelectionStart += 4;
        }

        //private void insertIf_Click(object sender, EventArgs e)
        //{
        //    string direction = "";
        //    var button = sender as RadioButton;

        //    // Получаем выбранное направление
        //    if (upIf.Checked)
        //    {
        //        direction = "Вверх";
        //    }
        //    else if (downIf.Checked)
        //    {
        //        direction = "Вниз";
        //    }
        //    else if (leftIf.Checked)
        //    {
        //        direction = "Влево";
        //    }
        //    else if (rightIf.Checked)
        //    {
        //        direction = "Вправо";
        //    }

        //    // Получаем тип условия
        //    string condition = "";
        //    if (freeIf.Checked)
        //    {
        //        condition = "";
        //    }
        //    else if (notFreeIf.Checked)
        //    {
        //        condition = "!";
        //    }

        //    // Вставляем команду в текстовое поле
        //    int position = TextField.SelectionStart;

        //    if (string.IsNullOrWhiteSpace(TextField.Text))
        //    {
        //        TextField.Text = "if(" + condition + direction + ")\n{\n\n}\n";
        //    }
        //    else if (string.IsNullOrWhiteSpace(TextField.Lines[TextField.GetLineFromCharIndex(position)]))
        //    {
        //        TextField.Text = TextField.Text.Insert(position, "if(" + condition + direction + ")\n{\n\n}\n");
        //    }
        //    else
        //    {
        //        TextField.Text = TextField.Text.Insert(position, "\nif(" + condition + direction + ")\n{\n\n}\n");
        //    }

        //    TextField.SelectionStart = position + 3 + condition.Length + direction.Length;
        //    TextField.Focus();
        //}
        //private void insertIf_Click(object sender, EventArgs e)
        //{
        //    string direction = "";
        //    var button = sender as RadioButton;

        //    // Получаем выбранное направление
        //    if (upIf.Checked)
        //    {
        //        direction = "Вверх";
        //    }
        //    else if (downIf.Checked)
        //    {
        //        direction = "Вниз";
        //    }
        //    else if (leftIf.Checked)
        //    {
        //        direction = "Влево";
        //    }
        //    else if (rightIf.Checked)
        //    {
        //        direction = "Вправо";
        //    }

        //    // Получаем тип условия
        //    string condition = "";
        //    if (freeIf.Checked)
        //    {
        //        condition = "";
        //    }
        //    else if (notFreeIf.Checked)
        //    {
        //        condition = "!";
        //    }

        //    // Вставляем команду в текстовое поле
        //    int position = TextField.GetFirstCharIndexOfCurrentLine();

        //    int openBrackets = 0;
        //    if (string.IsNullOrWhiteSpace(TextField.Text))
        //    {
        //        TextField.Text = "if(" + condition + direction + ")\n{\n\n}\n";
        //    }
        //    else
        //    {
        //        for (int i = 0; i < position; i++)
        //        {
        //            if (TextField.Text[i] == '{')
        //            {
        //                openBrackets++;
        //            }
        //            else if (TextField.Text[i] == '}')
        //            {
        //                openBrackets--;
        //            }
        //        }

        //        string indentation = new string(' ', openBrackets * 4);

        //        if (string.IsNullOrWhiteSpace(TextField.Lines[TextField.GetLineFromCharIndex(position)]))
        //        {
        //            TextField.Text = TextField.Text.Insert(position, indentation + "if(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
        //        }
        //        else
        //        {
        //            TextField.Text = TextField.Text.Insert(position, "\n" + indentation + "if(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
        //        }
        //    }

        //    TextField.SelectionStart = position + 3 + condition.Length + direction.Length + 4 * openBrackets + 4;
        //    TextField.Focus();
        //}






        private void insertIf_Click(object sender, EventArgs e)
        {
            string direction = "";
            var button = sender as RadioButton;

            // Получаем выбранное направление
            if (upIf.Checked)
            {
                direction = "Вверх";
            }
            else if (downIf.Checked)
            {
                direction = "Вниз";
            }
            else if (leftIf.Checked)
            {
                direction = "Влево";
            }
            else if (rightIf.Checked)
            {
                direction = "Вправо";
            }

            // Получаем тип условия
            string condition = "";
            if (freeIf.Checked)
            {
                condition = "";
            }
            else if (notFreeIf.Checked)
            {
                condition = "!";
            }

            // Вставляем команду в текстовое поле
            int position = TextField.GetFirstCharIndexOfCurrentLine();

            int openBrackets = 0;
            if (string.IsNullOrWhiteSpace(TextField.Text))
            {
                TextField.Text = "if(" + condition + direction + ")\n{\n\n}\n";
            }
            else
            {
                for (int i = 0; i < position; i++)
                {
                    if (TextField.Text[i] == '{')
                    {
                        openBrackets++;
                    }
                    else if (TextField.Text[i] == '}')
                    {
                        openBrackets--;
                    }
                }

                string indentation = new string(' ', openBrackets * 4);

                int lineIndex = TextField.GetLineFromCharIndex(position);
                if (lineIndex < TextField.Lines.Length - 1 && TextField.Lines[lineIndex].TrimEnd().EndsWith("}"))
                {
                    // Вставляем блок на следующей строке после скобки
                    position = TextField.GetFirstCharIndexFromLine(lineIndex + 1);
                    TextField.Text = TextField.Text.Insert(position, indentation + "if(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                }
                else
                {
                    // Вставляем блок на текущей строке
                    if (string.IsNullOrWhiteSpace(TextField.Lines[TextField.GetLineFromCharIndex(position)]))
                    {
                        TextField.Text = TextField.Text.Insert(position, indentation + "if(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                    }
                    else
                    {
                        TextField.Text = TextField.Text.Insert(position, "\n" + indentation + "if(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                    }
                }
            }

            TextField.SelectionStart = position + 3 + condition.Length + direction.Length + 4 * openBrackets + 4;
            TextField.Focus();
        }










    }
}
