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
        MapSelection mapSelect = new MapSelection();
        public MainMenu()
        {
            InitializeComponent();
            

        }

        private void Play_Click(object sender, EventArgs e)
        {
            Visible = false;

            Game game = new Game(mapSelect.map, mapSelect.robotX, mapSelect.robotY);
            game.ShowDialog();
            mapSelect = new MapSelection();
            Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
            mapSelect = new MapSelection();
            mapSelect.ShowDialog();
            Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RedactorMap_Click(object sender, EventArgs e)
        {
            RedactorMap redactor = new RedactorMap();
            Visible = false;
            redactor.ShowDialog();
            redactor = null;
            Visible = true;
        }

        private void CreateMazeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
