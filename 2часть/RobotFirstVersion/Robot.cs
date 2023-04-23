using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RobotFirstVersion
{
    internal class Robot
    {
        public Image image { get; private set; } = Properties.Resources.robot;
        Maze maze;
        public int x;
        public int y;
        public int startX;
        public int startY;
        public Robot(int startX, int startY)
        {
            x = startX;
            y = startY;
            this.startX = startX;
            this.startY = startY;
        }
        public void setMaze(Maze maze)
        {
            this.maze = maze;
        }
        public void moveUp()
        {
            y -= 1;
            maze.update(x, y);
            
        }
        public void moveDown()
        {
            y += 1;
            maze.update(x, y);
           
        }
        public void moveRight()
        {
            x += 1;
            maze.update(x, y);
            
        }
        public void moveLeft()
        {   
            x -= 1;
            maze.update(x, y);
            
        }
       
        public int checkRobotStatus()
        {
            return maze.checkСell(x, y);
        }
        
    }
}
