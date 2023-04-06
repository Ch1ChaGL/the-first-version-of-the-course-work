using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace RobotFirstVersion
{
    public partial class MapSelection : Form
    {
        private List<Bitmap> pictureBoxList = new List<Bitmap>();
        private List<string> nameMap = new List<string>();
        public int[,] map;
        public int robotX;
        public int robotY;
        string aPath = Application.StartupPath + "\\map\\";
        private int currentMapIndex = 0;
        public MapSelection()
        {
            InitializeComponent();
            selectMap("standart1");
        }


        private void loadMap()
        {
            DirectoryInfo d = new DirectoryInfo(aPath);
            FileInfo[] files = d.GetFiles("*.txt"); // получить все файлы в папке aPath с расширением .txt

            foreach (FileInfo file in files)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.Name);
                nameMap.Add(fileNameWithoutExtension);
                selectMap(fileNameWithoutExtension);

                string imagePath = Path.Combine(Application.StartupPath, "imageMap", $"{fileNameWithoutExtension}.png");
                if (!File.Exists(imagePath)) // Проверяем, существует ли файл
                {
                    PictureBox tempPictureBox = new PictureBox(); // создаем временный PictureBox
                    tempPictureBox.Size = map1.Size; // задаем размеры как у основного PictureBox
                    tempPictureBox.Location = map1.Location; // задаем позицию как у основного PictureBox
                    tempPictureBox.Visible = false; // делаем его невидимым
                    this.Controls.Add(tempPictureBox); // добавляем на форму
                    Maze maze = new Maze(map, new Robot(robotX, robotY), tempPictureBox); // создаем лабиринт на временном PictureBox
                    Bitmap mazeBitmap = new Bitmap(tempPictureBox.Width, tempPictureBox.Height); // создаем Bitmap для скриншота
                    tempPictureBox.DrawToBitmap(mazeBitmap, new Rectangle(0, 0, tempPictureBox.Width, tempPictureBox.Height)); // получаем скриншот
                    mazeBitmap.Save(imagePath, ImageFormat.Png); // сохраняем скриншот в файл с расширением .png
                    Controls.Remove(tempPictureBox); // удаляем временный PictureBox со страницы
                }
                else
                {
                    pictureBoxList.Add(new Bitmap(imagePath)); // добавляем существующий скриншот в список
                }
            }
        }

        private void selectMap(string name = "")
        {
            string filePath = aPath + name + ".txt";
            if (File.Exists(filePath)) // Проверяем, существует ли файл
            {
                string[] lines = File.ReadAllLines(filePath); // Читаем все строки из файла
                map = new int[lines.Length, lines[0].Length]; // Создаем двумерный массив для карты

                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        int cellValue;
                        if (int.TryParse(lines[i][j].ToString(), out cellValue))
                        {
                            if (cellValue == 2)
                            {
                                robotX = j;
                                robotY = i;
                            }
                            map[i, j] = cellValue; // Преобразуем символы в числа и сохраняем в массив
                        }
                    }
                }
            }
        }

        private void map1_Click(object sender, EventArgs e)
        {

        }

        private void Previous_Click(object sender, EventArgs e)
        {

            var btn = sender as Button;
            if(btn.Name == "Next")
            {
                currentMapIndex--;
                if (currentMapIndex < 0)
                {
                    currentMapIndex = pictureBoxList.Count - 1;
                }
                NameMaze.Text = nameMap[currentMapIndex];
                UpdatePictureBox();
            }
            if(btn.Name == "Previous")
            {
                currentMapIndex++;
                if (currentMapIndex >= pictureBoxList.Count)
                {
                    currentMapIndex = 0;
                }
                NameMaze.Text = nameMap[currentMapIndex];
                UpdatePictureBox();
            }
        }

        private void UpdatePictureBox()
        {
            Console.WriteLine($"currentMapIndex: {currentMapIndex}");
            map1.Image = pictureBoxList[currentMapIndex];
        }

        private void OK_Click(object sender, EventArgs e)
        {
           
            selectMap(nameMap[currentMapIndex]);
        }

        private void MapSelection_Load(object sender, EventArgs e)
        {
            loadMap();
            NameMaze.Text = nameMap[currentMapIndex];
            map1.Image = pictureBoxList[currentMapIndex];
            map1.Refresh();

        }
    }
}
