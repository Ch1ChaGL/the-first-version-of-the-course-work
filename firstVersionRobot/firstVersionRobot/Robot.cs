using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace firstVersionRobot
{
    internal class Robot
    {

        private bool crach = false;
        private delegate void MoveAction(int distance);
        private Dictionary<string, MoveAction> moveActions;
        private EnvironmentMap envMap;
        public Image image { get; private set; }
        public int x { get; private set; } = 0;
        public int y { get; private set; } = 0;

        public Robot( Image img, int x, int y) { 
            image = img;
            this.x = x;
            this.y = y;
            moveActions = new Dictionary<string, MoveAction>()
            {
                { "up", moveUp},
                { "down", moveDown},
                { "left", moveLeft},
                { "right", moveRight}
            };
        }
        
        public void setEnvMap(EnvironmentMap map)
        {
            this.envMap = map;
        }

        public void execute(string comand, int count)
        {

            try
            {
                crach = false;
                if (moveActions.ContainsKey(comand))
                {
                    moveActions[comand](count);
                    if (envMap.isWin(x, y))
                    {
                        start();
                    }
                }              
                else
                {
                    throw new Exception("Команды не существует: " + comand);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public  void execute(string[] comand)
        {
            
                crach = false;
                if (comand[0] == "while")
                {
                    moveWhileClear(comand[1], comand[3], comand[2]);
                    if (envMap.isWin(x, y))
                    {
                        start();
                    }
                }
                else
                {
                    throw new Exception("Неверный синтаксис While");
                }
             
        }

        private void moveUp(int y)
        {
            for (int i = 0; i < y; i++)
            {
                this.y -= 1;
                 envMap.updateMap(this.x, this.y);
            }
        }
        private void moveDown(int y)
        {
            for (int i = 0; i < y; i++)
            {
                this.y += 1;
                 envMap.updateMap(this.x, this.y);
            }
        }
        private  void moveRight(int x)
        {

            for (int i = 0; i < x; i++)
            {
                this.x += 1;
                 envMap.updateMap(this.x, this.y);
            }
 
        }
        private  void moveLeft(int x)
         {

            for (int i = 0; i < x; i++)
            {

                this.x -= 1;
                 envMap.updateMap(this.x, this.y);
            }
          }


        private void moveWhileClear(string directionSuspect, string direction, string clear)
        {
            if (clear == "clear")
            {
                if (directionSuspect == "up")
                {
                    while (!envMap.isWall(x, y - 1) && !crach)
                    {
                        if (direction == "up")
                        {
                             moveUp(1);
                        }
                        if (direction == "down")
                        {
                             moveDown(1);
                        }
                        if (direction == "left")
                        {
                             moveLeft(1);
                        }
                        if (direction == "right")
                        {
                             moveRight(1);
                        }

                    }
                }
                if (directionSuspect == "down")
                {
                    while (!envMap.isWall(x, y + 1) && !crach)
                    {
                        if (direction == "up")
                        {
                             moveUp(1);
                        }
                        if (direction == "down")
                        {
                             moveDown(1);
                        }
                        if (direction == "left")
                        {
                             moveLeft(1);
                        }
                        if (direction == "right")
                        {
                             moveRight(1);
                        }

                    }
                }
                if (directionSuspect == "left")
                {
                    while (!envMap.isWall(x - 1, y) && !crach)
                    {
                        if (direction == "up")
                        {
                             moveUp(1);
                        }
                        if (direction == "down")
                        {
                             moveDown(1);
                        }
                        if (direction == "left")
                        {
                             moveLeft(1);
                        }
                        if (direction == "right")
                        {
                             moveRight(1);
                        }

                    }
                }
                if (directionSuspect == "right")
                {
                    while (!envMap.isWall(x + 1, y) && !crach)
                    {
                        if (direction == "up")
                        {
                             moveUp(1);
                        }
                        if (direction == "down")
                        {
                             moveDown(1);
                        }
                        if (direction == "left")
                        {
                             moveLeft(1);
                        }
                        if (direction == "right")
                        {
                             moveRight(1);
                        }

                    }
                }
            }
            else if(clear == "not_clear"){
                if (directionSuspect == "up")
                {
                    while (envMap.isWall(x, y - 1) && !crach)
                    {
                        if (direction == "up")
                        {
                             moveUp(1);
                        }
                        if (direction == "down")
                        {
                             moveDown(1);
                        }
                        if (direction == "left")
                        {
                             moveLeft(1);
                        }
                        if (direction == "right")
                        {
                             moveRight(1);
                        }

                    }
                }
                if (directionSuspect == "down")
                {
                    while (envMap.isWall(x, y + 1) && !crach)
                    {
                        if (direction == "up")
                        {
                             moveUp(1);
                        }
                        if (direction == "down")
                        {
                             moveDown(1);
                        }
                        if (direction == "left")
                        {
                             moveLeft(1);
                        }
                        if (direction == "right")
                        {
                             moveRight(1);
                        }

                    }
                    envMap.isWin(x,y);
                }
                if (directionSuspect == "left")
                {
                    while (envMap.isWall(x - 1, y) && !crach)
                    {
                        if (direction == "up")
                        {
                             moveUp(1);
                        }
                        if (direction == "down")
                        {
                             moveDown(1);
                        }
                        if (direction == "left")
                        {
                             moveLeft(1);
                        }
                        if (direction == "right")
                        {
                             moveRight(1);
                        }

                    }
                }
                if (directionSuspect == "right")
                {
                    while (envMap.isWall(x + 1, y) && !crach)
                    {
                        if (direction == "up")
                        {
                             moveUp(1);
                        }
                        if (direction == "down")
                        {
                             moveDown(1);
                        }
                        if (direction == "left")
                        {
                             moveLeft(1);
                        }
                        if (direction == "right")
                        {
                             moveRight(1);
                        }

                    }
                }
            }
        }

        public  void crashed()
        {
            crach = true;
            this.x = 0;
            this.y = 0;
             envMap.updateMap(this.x, this.y);
            MessageBox.Show("Вы разбились");
        }
        public  void start()
        {
            this.x = 0;
            this.y = 0;
            envMap.updateMap(x, y);
        }
    }
}
