using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void Up_Click(object sender, EventArgs e)
        {
            TextField.Text += "Вверх\n";
        }

        private void Down_Click_1(object sender, EventArgs e)
        {
            TextField.Text += "Вниз\n";
        }

        private void Left_Click(object sender, EventArgs e)
        {
            TextField.Text += "Влево\n";
        }

        private void Right_Click(object sender, EventArgs e)
        {
            TextField.Text += "Вправо\n";
        }

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
    }
}
