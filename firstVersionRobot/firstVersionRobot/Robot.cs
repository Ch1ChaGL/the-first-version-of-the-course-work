using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstVersionRobot
{
    internal class Robot
    {
        
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
                if (moveActions.ContainsKey(comand))
                {
                    moveActions[comand](count);
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
        private void moveUp(int y)
        {
            for (int i = 0; i < y; i++)
            {
                if (envMap.isWall(this.x, this.y - 1)) { crashed(); break; }
                this.y -= 1;
                envMap.updateMap(this.x, this.y);
            }
            envMap.isWin(this.x, this.y);
        }
        private void moveDown(int y)
        {
            for (int i = 0; i < y; i++)
            {
                if (envMap.isWall(this.x, this.y + 1)) { crashed(); break; }
                this.y += 1;
                envMap.updateMap(this.x, this.y);
            }
            envMap.isWin(this.x, this.y);
        }
        private void moveRight(int x)
        {

            for (int i = 0; i < x; i++)
            {
                if (envMap.isWall(this.x + 1, this.y)) { crashed(); break; }
                this.x += 1;
                envMap.updateMap(this.x, this.y);
            }
            envMap.isWin(this.x, this.y);
        }
        private void moveLeft(int x)
        {

            for (int i = 0; i < x; i++)
            {
                if (envMap.isWall(this.x - 1, this.y)) { crashed(); break; }
                this.x -= 1;
                envMap.updateMap(this.x, this.y);
            }
            envMap.isWin(this.x, this.y);
        }

        private void crashed()
        {
            this.x = 0;
            this.y = 0;
            envMap.updateMap(this.x, this.y);
            MessageBox.Show("Вы разбились");
        }
    }
}
