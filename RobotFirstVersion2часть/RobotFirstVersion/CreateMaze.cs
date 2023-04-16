using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RobotFirstVersion
{
    public partial class CreateMaze : Form
    {
        Robot robot = new Robot(1, 1);
        Maze maze;
        int[,] map;
        public CreateMaze()
        {
            InitializeComponent();
            pictureBox1.MouseDown += pictureBox1_MouseDown;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Проверяем, что кнопка "wall" нажата
            if (wall.Checked)
            {

                int cellSize = maze.cellSize;
                int i = e.X / cellSize + 1;
                int j = e.Y / cellSize + 1;
                if (map[j, i] != 2) // проверка, что на этом месте нет робота
                {
                    map[j, i] = 1;
                    pictureBox1.Invalidate();
                }
            }
            if (cell.Checked)
            {
                int cellSize = maze.cellSize;
                int i = e.X / cellSize + 1;
                int j = e.Y / cellSize + 1;
                if (map[j, i] != 2) // проверка, что на этом месте нет робота
                {
                    map[j, i] = 0;
                    pictureBox1.Invalidate();
                }
            }
            if (exit.Checked)
            {
                int cellSize = maze.cellSize;
                int i = e.X / cellSize + 1;
                int j = e.Y / cellSize + 1;
                if (map[j, i] != 2) // проверка, что на этом месте нет робота
                {
                    map[j, i] = 3;
                    pictureBox1.Invalidate();
                }
            }
            if (start.Checked)
            {
                int cellSize = maze.cellSize;
                int i = e.X / cellSize + 1;
                int j = e.Y / cellSize + 1;
                int oldX = robot.x;
                int oldY = robot.y;
                map[oldY, oldX] = 0;
                map[j, i] = 2;
                robot.x = i;
                robot.y = j;
                pictureBox1.Invalidate();
            }
        }
        private void sizeMazeNumeric_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)sizeMazeNumeric.Value + 2;
            map = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                    {
                        map[i, j] = 1; // устанавливаем граничные элементы в 1
                    }
                    else
                    {
                        map[i, j] = 0; // остальные элементы в 0
                    }
                }
            }
            robot.x = 1;
            robot.y = 1;
            maze = new Maze(map, robot, pictureBox1);
            map[robot.x, robot.y] = 2;
            pictureBox1.Invalidate();
        }


        private void CreateMaze_Load(object sender, EventArgs e)
        {
            int size = (int)sizeMazeNumeric.Value + 2;
            map = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                    {
                        map[i, j] = 1; // устанавливаем граничные элементы в 1
                    }
                    else
                    {
                        map[i, j] = 0; // остальные элементы в 0
                    }
                }
            }
            maze = new Maze(map, robot, pictureBox1);
            map[robot.x, robot.y] = 2;
            pictureBox1.Invalidate();
        }

        private void save_Click(object sender, EventArgs e)
        {
            bool hasVictoryCell = false;

            // Проверяем наличие ячейки с типом 3
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 3)
                    {
                        hasVictoryCell = true;
                        break;
                    }
                }
            }

            // Если ячейки с типом 3 нет, выводим сообщение
            if (!hasVictoryCell)
            {
                MessageBox.Show("Необходимо добавить ячейку победы (тип 3)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Просим пользователя ввести имя файла
            string fileName = textBox1.Text != "" ? textBox1.Text + ".txt" : null;
            if (fileName == null)
            {
                MessageBox.Show("Название карты не введено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Проверяем, существует ли файл с таким именем
            if (File.Exists("map/" + fileName))
            {
                MessageBox.Show("Карта с таким названием существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Сохраняем карту в файл
            using (StreamWriter sw = new StreamWriter("map/" + fileName))
            {
                // Записываем ячейки карты с рамкой из единиц
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {                     
                        sw.Write(map[i, j]); 
                    }
                    sw.WriteLine();
                }
            }


        }

        private void CreateMaze_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
