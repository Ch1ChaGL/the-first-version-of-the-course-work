using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstVersionRobot
{
    internal class EnvironmentMap
    {
        DataGridViewImageCell imageCell = new DataGridViewImageCell();
        Robot robot;
        private int _width;
        private int _height;
        int robotX;
        int robotY;
        private DataGridView _dataGridView;
        int[,] map1 = new int[,] {
    { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
    { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
    { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
    { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1 },
    { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1 },
    { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
    { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 },
    { 1, 0, 0, 0, 0, 0, 0, 0, 2, 1 },
    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
};
        public EnvironmentMap(int width, int height, DataGridView dataGridView, Robot robot)
        {   
            robotX = robot.x;
            robotY = robot.y;
            _width = width;
            _height = height;
            _dataGridView = dataGridView;
            this.robot = robot;
            robot.setEnvMap(this);
            InitializeDataGridView();
            InitializeRobot();
            createLabirint(map1);
            
        }
        private void InitializeDataGridView()
        {
            _dataGridView.Visible = true;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _dataGridView.ScrollBars = ScrollBars.None;
            _dataGridView.AllowUserToResizeColumns = false;
            _dataGridView.AllowUserToResizeRows = false;
            _dataGridView.AutoSize = false;
            _dataGridView.RowCount = _height;
            _dataGridView.ColumnCount = _width;
            _dataGridView.Width = calculateDataGridViewSize(_width);
            _dataGridView.Height = calculateDataGridViewSize(_height);
            for (int i = 0; i < _width; i++)
            {
                _dataGridView.Columns[i].Width = 50;                          
            }
            for (int j = 0; j < _height; j++)
            {
                _dataGridView.Rows[j].Height = 50;
            }
        }
        private void InitializeRobot()
        {
            int x = robot.x;
            int y = robot.y;
           
            imageCell.Value = robot.image;
            imageCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
            _dataGridView.Rows[y].Cells[x] = imageCell;
        }
        private int calculateDataGridViewSize(int size) {
            return size * 50;
        }
        private void createLabirint(int[,] arr)
        {
            try
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] == 1)
                        {
                            _dataGridView.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        }
                        if (arr[i,j]==2) _dataGridView.Rows[i].Cells[j].Style.BackColor = Color.Green;
                    }
                }
                if (isWall(robot.x, robot.y)) throw new Exception("При создании карты робот оказался на стене");
            }
            catch(Exception e)
            {
                clearMap();
                MessageBox.Show(e.Message);
            }
           
        }
        public bool isWall(int x, int y)
        {
            if (_dataGridView.Rows[y].Cells[x].Style.BackColor == Color.Black) return true;
            return false;
        }
        public bool isWin(int x, int y)
        {
            if (map1[x, y] == 2) { _dataGridView.Enabled = false; MessageBox.Show("Вы прошли лабиринт"); return true; }            
            return false;
        }
        public void clearMap()
        {
            for (int i = 0; i < _dataGridView.RowCount; i++)
            {
                for (int j = 0; j < _dataGridView.ColumnCount; j++)
                {
                   _dataGridView.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        public void updateMap(int newX, int newY) 
        {
            //  Заменяем ячейку с картинкой на обычную ячейку
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            if (map1[robotX,robotY] == 2) cell.Style.BackColor = Color.Green;
            cell.Value = null;
            _dataGridView.Rows[robotY].Cells[robotX] = cell;

            // Создаем новую ячейку с новой картинкой
            DataGridViewImageCell imageCell = new DataGridViewImageCell();
            imageCell.Value = robot.image;
            imageCell.ImageLayout = DataGridViewImageCellLayout.Stretch;


            // Добавляем новую ячейку в новую позицию
            _dataGridView.Rows[newY].Cells[newX] = imageCell;
            //Текущие координаты робота
            robotX = newX;
            robotY = newY;
        }
    }
}
