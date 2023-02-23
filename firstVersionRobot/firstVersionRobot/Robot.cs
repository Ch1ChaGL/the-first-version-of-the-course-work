using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstVersionRobot
{
    internal class Robot
    {
        private EnvironmentMap envMap;
        public Image image { get; private set; }
        public int x { get; private set; } = 0;
        public int y { get; private set; } = 0;

        public Robot( Image img, int x, int y) { 
            image = img;
            this.x = x;
            this.y = y;
        }
        public void setEnvMap(EnvironmentMap map)
        {
            this.envMap = map;
        }

        public void execute()
        {

        }
        public void moveUp(int y)
        {
            this.y -= y;
        }
        public void moveDown(int y)
        {
            this.y += y;
        }
        public void moveRight(int x)
        {
            this.x += x;
        }
        public void moveLeft(int x)
        {
            this.x -= x;
        }
    }
}
