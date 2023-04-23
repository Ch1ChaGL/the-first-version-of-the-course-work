using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace RobotFirstVersion
{
    public partial class RedactorMap : Form
    {
        public RedactorMap()
        {
            InitializeComponent();
        }
        private List<Bitmap> pictureBoxList = new List<Bitmap>();
        private List<string> nameMap = new List<string>();
        public int[,] map;
        public int robotX;
        public int robotY;
        string aPath = Application.StartupPath + "\\map\\";
        private int currentMapIndex = 0;
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
                    tempPictureBox.Size = pictureBox1.Size; // задаем размеры как у основного PictureBox
                    tempPictureBox.Location = pictureBox1.Location; // задаем позицию как у основного PictureBox
                    tempPictureBox.Visible = false; // делаем его невидимым
                    this.Controls.Add(tempPictureBox); // добавляем на форму
                    Maze maze = new Maze(map, new Robot(robotX, robotY), tempPictureBox); // создаем лабиринт на временном PictureBox

                    Bitmap mazeBitmap = new Bitmap(tempPictureBox.Width, tempPictureBox.Height); // создаем Bitmap для скриншота
                    tempPictureBox.DrawToBitmap(mazeBitmap, new Rectangle(0, 0, tempPictureBox.Width, tempPictureBox.Height)); // получаем скриншот
                    mazeBitmap.Save(imagePath, ImageFormat.Png); // сохраняем скриншот в файл с расширением .png
                    Controls.Remove(tempPictureBox); // удаляем временный PictureBox со 
                    pictureBoxList.Add(new Bitmap(mazeBitmap));
                }
                else
                {                                                         
                   pictureBoxList.Add(new Bitmap(imagePath));                    
                }
            }
        }



        private void selectMap(string name = "")
        {
            string filePath = Path.Combine(aPath, name + ".txt");
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] lines = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    map = new int[lines.Length, lines[0].Length];

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
                                map[i, j] = cellValue;
                            }
                        }
                    }
                }
            }
        }



        private void RedactorMap_Load(object sender, EventArgs e)
        {

            loadMap();

            pictureBox1.Image = pictureBoxList[currentMapIndex];
            NameMaze.Text = nameMap[currentMapIndex];
            pictureBox1.Refresh();
        }
        private void UpdatePictureBox()
        {
            Console.WriteLine($"currentMapIndex: {currentMapIndex}");
            pictureBox1.Image = pictureBoxList[currentMapIndex];
        }

        private void Back_Click_1(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn.Name == "Next")
            {
                currentMapIndex--;
                if (currentMapIndex < 0)
                {
                    currentMapIndex = pictureBoxList.Count - 1;
                }
               NameMaze.Text = nameMap[currentMapIndex];
                UpdatePictureBox();
            }
            if (btn.Name == "Back")
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

        private void DeleteMap_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count > 0)
            {

                string currentMapName = nameMap[currentMapIndex];
                string currentMapFilePath = aPath + currentMapName + ".txt";
                string currentMapImagePath = Path.Combine(Application.StartupPath, "imageMap", $"{currentMapName}.png");

                // Удалить изображение карты из списка pictureBoxList
                pictureBoxList[currentMapIndex].Dispose();
                pictureBoxList.RemoveAt(currentMapIndex);

                // Удалить имя карты из списка nameMap
                nameMap.RemoveAt(currentMapIndex);

                if (pictureBoxList.Count > 0)
                {
                    // Отобразить следующую карту в списке, если она есть
                    
                    currentMapIndex = 0;
                    
                    UpdatePictureBox();
                }
                else
                {
                    // Очистить PictureBox, если больше нет карт в списке
                    pictureBox1.Image = null;
                }

                // Удалить файл с картой
                if (File.Exists(currentMapFilePath))
                {
                    File.Delete(currentMapFilePath);
                }
                Console.WriteLine(currentMapName);
                Console.WriteLine(currentMapIndex);
                // Удалить файл с изображением
                try
                {
                    if (File.Exists(currentMapImagePath))
                    {
                        File.Delete(currentMapImagePath);
                    }
                }
                catch (IOException ex)
                {
                    if (IsFileLocked(ex))
                    {
                        MessageBox.Show("Файл " + currentMapFilePath + " заблокирован другим процессом.");
                    }
                    else
                    {
                        throw;
                    }
                }

            }
        }

      

        public static bool IsFileLocked(Exception exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == 32 || errorCode == 33;
        }


        private void CreateMazeBtn_Click(object sender, EventArgs e)
        {
            Visible = false;
            CreateMaze createMaze = new CreateMaze();
            createMaze.ShowDialog();
            createMaze = null;
            pictureBoxList.Clear();
            nameMap.Clear();
            loadMap();
            Visible = true;
        }

        private void RedactorMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Image = null;
            foreach(var bitmap in pictureBoxList)
            {
                bitmap.Dispose();
            }
        }

        private void RedactMap_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            foreach (var bitmap in pictureBoxList)
            {
                bitmap.Dispose();
            }
            int[,] map;
            string filePath = aPath + nameMap[currentMapIndex] + ".txt";
            string currentMapName = nameMap[currentMapIndex];
            string currentMapImagePath = Path.Combine(Application.StartupPath, "imageMap", $"{currentMapName}.png");
            if (File.Exists(currentMapImagePath))
            {
                File.Delete(currentMapImagePath);
            }
            pictureBoxList.Clear();
            nameMap.Clear();
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
                            map[i, j] = cellValue; // Преобразуем символы в числа и сохраняем в массив
                        }
                    }
                }
                Visible = false;
                RedactMaze redactMaze = new RedactMaze(map, filePath);
                redactMaze.ShowDialog();
                loadMap();
                pictureBox1.Image = pictureBoxList[currentMapIndex];
                NameMaze.Text = nameMap[currentMapIndex];
                Visible = true;
            }
            
        }
    }
}
