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
        private int _width;
        private int _height;
        private DataGridView _dataGridView;

        public EnvironmentMap(int width, int height, DataGridView dataGridView)
        {
            _width = width;
            _height = height;
            _dataGridView = dataGridView;
            InitializeDataGridView();
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
        private int calculateDataGridViewSize(int size) {
            return size * 50;
        }
    }
}
