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
    public partial class MainMenu : Form
    {
        MapSelection mapSelect;
        public MainMenu()
        {
            InitializeComponent();
            mapSelect = new MapSelection();

        }

        private void Play_Click(object sender, EventArgs e)
        {
            Visible = false;

            Game game = new Game(mapSelect.map, mapSelect.robotX, mapSelect.robotY);
            game.ShowDialog();
            Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
            MapSelection mapSelection = new MapSelection();
            mapSelect.ShowDialog();
            Visible = true;
        }
    }
}
