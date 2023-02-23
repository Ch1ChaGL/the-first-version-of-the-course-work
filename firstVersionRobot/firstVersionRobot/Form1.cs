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
        public Form1()
        {
            InitializeComponent();
            Image img = Properties.Resources.robot;
            Robot robot = new Robot(img,0,0);
            EnvironmentMap map = new EnvironmentMap(10,10,dataGridView1,robot);
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
        
    }
}
