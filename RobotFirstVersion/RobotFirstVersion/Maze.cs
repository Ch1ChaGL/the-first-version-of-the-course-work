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
        //public bool status { get; private set; } = false;
        int cellSize;
        Pen penR = new Pen(Color.Red);
        Pen penG = new Pen(Color.Green);
        private PictureBox _pictureBox;
        private int[,] _map;
        Robot _robot;
        public Maze (int[,] map, Robot robot, PictureBox pictureBox)
        {
            cellSize = Math.Min(pictureBox.Width / (map.GetLength(1) - 2), pictureBox.Height / (map.GetLength(0) - 2));
            _map = map;
            _robot = robot;
            _pictureBox = pictureBox;
            _pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
  
            pictureBox.Width = (_map.GetLength(0) - 2) * cellSize + 1;
            pictureBox.Height = (_map.GetLength(1) - 2) * cellSize + 1;
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {

            Graphics _canvas = e.Graphics;
            _canvas.Clear(Color.White);
            for (int i = 1; i < _map.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < _map.GetLength(1) - 1; j++)
                {

                   
                    _canvas.DrawRectangle(penG, cellSize * (i - 1), cellSize * (j - 1), cellSize, cellSize);
                    //_canvas.DrawRectangle(penG, cellSize * i, cellSize * j, cellSize, cellSize);
                    if (_map[j, i] == 1)
                    {
                        _canvas.FillRectangle(Brushes.Black, cellSize * (i - 1), cellSize * (j - 1), cellSize - 2, cellSize - 2);
                    }                                        
                    if (_map[j, i] == 3)
                    {
                        _canvas.FillRectangle(Brushes.Green, cellSize * (i - 1), cellSize * (j - 1), cellSize - 2, cellSize - 2);
                    }
                }
            }

            _canvas.DrawImage(_robot.image, cellSize * _robot.x + 5 - cellSize, cellSize * _robot.y + 5 - cellSize, cellSize - 5, cellSize - 5);
            //_canvas.DrawEllipse(penR, cellSize * _robot.x + 1, cellSize * _robot.y + 1, cellSize - 2, cellSize - 2);
        }


        public void update(int newX, int newY) {

            //int value = checkСell(newX, newY);
            //if (value == 1)
            //{
            //    endGame(value);
            //    //MessageBox.Show("Вы врезались в стену");
            //    //_robot.x = 1;
            //    //_robot.y = 1;
            //    //_pictureBox.Invalidate();
            //    //status = true;
            //}
            //else if (value == 3)
            //{
            //    endGame(value);
            //    //_pictureBox.Invalidate();
            //    //MessageBox.Show("Вы победили");
            //    //_robot.x = 1;
            //    //_robot.y = 1;
            //    //status = true;
            //}
            _pictureBox.Invalidate();
        }

        public int checkСell(int x, int y)
        {
            if (_map[y,x] == 1)
            {
                return 1; 
            }
            if (_map[y, x] == 3)
            {
                return 3;
            }
            if (_map[y, x] == 0)
            {
                return 0;
            }
            return -1;
        }

        public void endGame(int value)
        {
            if(value == 1)
            {
                MessageBox.Show("Вы врезались в стену");
                resetMap();
            }
            if (value == 3)
            {
                MessageBox.Show("Вы победили");
                resetMap();
            }
            if(value == 0)
            {
                MessageBox.Show("Вы не дошли до конца лабиринта");
                resetMap();
            }
        }

        public void resetMap()
        {
            _robot.x = _robot.startX;
            _robot.y = _robot.startY;
            _pictureBox.Invalidate();
            //status = false;
        }


    }
}
