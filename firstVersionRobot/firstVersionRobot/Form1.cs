using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstVersionRobot
{
    public partial class Form1 : Form
    {
        Image img;
        Robot robot;
        Parser pars;
        public Form1()
        {
            InitializeComponent();
            img = Properties.Resources.robot;
            robot = new Robot(img,0,0);
            EnvironmentMap map = new EnvironmentMap(10,10,dataGridView1,robot);
            pars = new Parser(400, 400, robot, richTextBox1);
            robot.execute("right",1);
            robot.execute("down", 2);

            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //imageColumn.Width = 50;
            //dataGridView1.Columns.Add(imageColumn);

            //var imageCell = new DataGridViewImageCell();
            //var image = Properties.Resources.turtle;
            //imageCell.Value = image;
            //imageCell.ImageLayout = DataGridViewImageCellLayout.Stretch;


            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //dataGridView1.ScrollBars = ScrollBars.None;
            //dataGridView1.AllowUserToResizeColumns = false;
            //dataGridView1.AllowUserToResizeRows = false;
            //dataGridView1.AutoSize = false;
            //dataGridView1.RowCount = 11;
            //dataGridView1.ColumnCount = 11;
            //dataGridView1.Rows[0].Cells[0] = imageCell;
            ////dataGridView1.Rows[0].Cells[0].Value = image;
            ////((DataGridViewImageCell)dataGridView1.Rows[0].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            //dataGridView1.Width = 550;
            //dataGridView1.Height = 550;
            //for (int i = 0; i < 11; i++)
            //{
            //    dataGridView1.Columns[i].Width = 50;
            //    dataGridView1.Rows[i].Height = 50;
            //}


        }

        private void button1_Click(object sender, EventArgs e)
        {
            robot.execute("left", 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            robot.execute("up", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            robot.execute("right", 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            robot.execute("down", 1);
        }

        private void Play_Click(object sender, EventArgs e)
        {   
            pars.parseText();
        }
    }
}
