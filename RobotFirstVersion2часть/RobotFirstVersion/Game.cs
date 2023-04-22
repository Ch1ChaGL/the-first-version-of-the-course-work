using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace RobotFirstVersion
{
    public partial class Game : Form
    {
        Maze maze;
        Robot robot;
        ParserCommand parser = null;
        CancellationTokenSource cancellationToken;

        public Game(int[,] map, int robotX, int robotY)
        {
            InitializeComponent();
            robot = new Robot(robotX, robotY);
            maze = new Maze(map, robot ,pictureBox1);
            robot.setMaze(maze);
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
        private void TextField_KeyDown(object sender, KeyEventArgs e)
        {
            
            //e.SuppressKeyPress = true;
            //if (e.Control && e.KeyCode == Keys.V)
            //{

            //    IDataObject clipboardData = Clipboard.GetDataObject();

            //    if (clipboardData.GetDataPresent(DataFormats.UnicodeText))
            //    {
            //        string text = (string)clipboardData.GetData(DataFormats.UnicodeText);
            //        TextField.SelectedText = text;
            //    }

            //    // Предотвращаем вставку остальных данных из буфера обмена
            //    e.Handled = true;


            //}
            //if (TextField.Text.Length > 0)
            //{
            //    if (e.Control && e.KeyCode == Keys.C)
            //    {
            //        Clipboard.SetText(TextField.SelectedText);
            //        e.Handled = true;
            //    }
            //    else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            //    {
            //        FnDelete();
            //        e.Handled = true;
            //    }



            //}
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

            // Вычисляем отступы
            int openBrackets = 0;
            for (int i = 0; i < nextLineStart; i++)
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

            // Добавляем слово на позицию nextLineStart с отступами
            TextField.Text = TextField.Text.Insert(nextLineStart, indentation + direction);

            // Перемещаем курсор в конец добавленного слова
            TextField.SelectionStart = nextLineStart + indentation.Length + direction.Length;

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

        private async void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ValidationError vw = new ValidationError();
            var err = vw.Validate(TextField.Text);
            if (err.Count > 0)
            {
                for (int i = 0; i < err.Count; i++)
                {
                    Console.WriteLine(err[i]);
                }
                return;
            }
            parser = new ParserCommand(TextField.Text, robot, maze);
            playToolStripMenuItem.Enabled = false;
            Cancel.Enabled = true;
            cancellationToken  = new CancellationTokenSource();
            robot.x = robot.startX;
            robot.y = robot.startY;
           
            nextStepToolStripMenuItem.Enabled = false;
            result(await parser.ParseAll(robot, cancellationToken.Token));
            Cancel.Enabled = false;
            nextStepToolStripMenuItem.Enabled = true;
            playToolStripMenuItem.Enabled = true;
        }

        private void nextStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (parser == null)
           {
                parser = new ParserCommand(TextField.Text, robot, maze);
           }
           int value = parser.parseNext(robot, maze);
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

        private void insertIf_Click(object sender, EventArgs e)
        {
            string direction = "";
            
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
                TextField.Text = "if(" + condition + direction + ")\n{\n\n}\nelse\n{\n\n}\n";
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
                    TextField.Text = TextField.Text.Insert(position, indentation + "if(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n" + indentation + "else\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                }
                else
                {
                    // Вставляем блок на текущей строке
                    if (string.IsNullOrWhiteSpace(TextField.Lines[TextField.GetLineFromCharIndex(position)]))
                    {
                        TextField.Text = TextField.Text.Insert(position, indentation + "if(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n" + indentation + "else\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                    }
                    else
                    {
                        TextField.Text = TextField.Text.Insert(position, "\n" + indentation + "if(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n" + indentation + "else\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                    }
                }
            }

            TextField.SelectionStart = position + 3 + condition.Length + direction.Length + 4 * openBrackets + 12;
            TextField.Focus();
        }

        private void insertWhile_Click(object sender, EventArgs e)
        {
            string direction = "";

            // Получаем выбранное направление
            if (upWhile.Checked)
            {
                direction = "Вверх";
            }
            else if (downWhile.Checked)
            {
                direction = "Вниз";
            }
            else if (leftWhile.Checked)
            {
                direction = "Влево";
            }
            else if (rightWhile.Checked)
            {
                direction = "Вправо";
            }

            // Получаем тип условия
            string condition = "";
            if (freeWhile.Checked)
            {
                condition = "";
            }
            else if (notFreeWhile.Checked)
            {
                condition = "!";
            }

            // Вставляем команду в текстовое поле
            int position = TextField.GetFirstCharIndexOfCurrentLine();

            int openBrackets = 0;
            if (string.IsNullOrWhiteSpace(TextField.Text))
            {
                TextField.Text = "While(" + condition + direction + ")\n{\n\n}\n";
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
                    TextField.Text = TextField.Text.Insert(position, indentation + "While(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                }
                else
                {
                    // Вставляем блок на текущей строке
                    if (string.IsNullOrWhiteSpace(TextField.Lines[TextField.GetLineFromCharIndex(position)]))
                    {
                        TextField.Text = TextField.Text.Insert(position, indentation + "While(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                    }
                    else
                    {
                        TextField.Text = TextField.Text.Insert(position, "\n" + indentation + "While(" + condition + direction + ")\n" + indentation + "{\n" + indentation + "    \n" + indentation + "}\n");
                    }
                }
            }

            TextField.SelectionStart = position + 3 + condition.Length + direction.Length + 4 * openBrackets + 12;
            TextField.Focus();
        }

        private void TextField_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == 9)
            {
                e.Handled = false;
            }
           
        }

        private void TextField_TextChanged(object sender, EventArgs e)
        {
            parser = null;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            cancellationToken.Cancel();
            maze.resetMap();
            parser = null;
        }

        private void выгрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.Write(TextField.Text);
                    }
                }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                TextField.Text = File.ReadAllText(fileName);
            }
        }
    }
}
