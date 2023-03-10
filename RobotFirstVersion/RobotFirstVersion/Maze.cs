using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotFirstVersion
{
    internal class Maze
    {
        int cellSize = 50;
        Pen penR = new Pen(Color.Red);
        Pen penG = new Pen(Color.Green);
        private PictureBox _pictureBox;
        private int[,] _map;
        Robot _robot;
        public Maze (int[,] map, Robot robot, PictureBox pictureBox)
        {
            _map = map;
            _robot = robot;
            _pictureBox = pictureBox;
            _pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics _canvas = e.Graphics;
            _canvas.Clear(Color.White);
            for (int i = 1; i < _map.GetLength(0); i++)
            {
                for (int j = 1; j < _map.GetLength(1); j++)
                {

                    _canvas.DrawRectangle(penG, cellSize * (i - 1), cellSize * (j - 1), cellSize, cellSize);
                    if (_map[i, j] == 1)
                    {
                        _canvas.FillRectangle(Brushes.Black, cellSize * i + 1, cellSize * j + 1, cellSize - 2, cellSize - 2);
                    }
                    if (_map[i, j] == 3)
                    {
                        _canvas.FillRectangle(Brushes.Green, cellSize * i + 1, cellSize * j + 1, cellSize - 2, cellSize - 2);
                    }
                }
            }

            _canvas.DrawImage(_robot.image, cellSize * _robot.x+5, cellSize * _robot.y+5, cellSize - 5, cellSize - 5);
            //_canvas.DrawEllipse(penR, cellSize * _robot.x + 1, cellSize * _robot.y + 1, cellSize - 2, cellSize - 2);
        }

        public void update(int newX, int newY) {
            _pictureBox.Invalidate();
        }
    }
}
