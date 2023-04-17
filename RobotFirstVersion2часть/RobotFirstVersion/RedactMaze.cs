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

namespace RobotFirstVersion
{
    public partial class RedactMaze : Form
    {
        int[,] map;
        Maze maze;
        Robot robot = new Robot(0,0);
        string path;
        public RedactMaze(int[,] map , string path)
        {
            InitializeComponent();
            this.map = map;
            this.path = path;
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

        private void RedactMaze_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j] == 2)
                    {
                        robot.x = j;
                        robot.y = i;
                    }
                }
            }
            maze = new Maze(map, robot, pictureBox1);
        }

        private void save_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            using (StreamWriter sw = new StreamWriter(path))
            {
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

       
    }
}
