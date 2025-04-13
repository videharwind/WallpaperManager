using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WallpaperManager
{
    public partial class Form1 : Form
    {
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPI_UPDATEINFILE = 1;
        public const int SPI_SENDCHANGE = 2;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(uint uAction, uint uParam, String lpvParam, int fuWinIni);

        private PictureBox SelectedPicture = null;
        public static void SetWallpaper(string imagePath)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPI_UPDATEINFILE | SPI_SENDCHANGE);
        }
        private static void SetWallpaper(PictureBox picturebox)
        {

            string temppath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "TempWallpaper.bmp");
            picturebox.Image.Save(temppath, System.Drawing.Imaging.ImageFormat.Bmp);
            SetWallpaper(temppath);
        }
        private Image LoadWithoutLock(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return Image.FromStream(stream);
            }
        }
        public static string[] getImages(string path)
        {
            string[] files = Directory.GetFiles(path);
            string[] images = new string[20];
            int index = 0;
            foreach (string i in files)
            {
                string extension = Path.GetExtension(i);
                if (extension == ".jpg" || extension == ".png")
                {
                    images[index] = i;
                    index++;
                }
            }
            string[] im = new string[index];
            Array.Copy(images, im, index);
            return im;
        }
        public static string CreateAppDataPath()
        {
            string commanPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string appPath = Path.Combine(commanPath, "WallpaperManager\\images");
            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);
            }
            return appPath;
        }
        public Form1()
        {
            CreateAppDataPath();
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string appPath = CreateAppDataPath();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ImageFiles (*.png)|*.png";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string source in ofd.FileNames)
                {
                    string destinationPath = Path.Combine(appPath, Path.GetFileName(source));
                    File.Copy(source, destinationPath);

                }
            }
            LoadWallpapers();
        }

        public void LoadWallpapers()
        {
            flowLayoutPanel1.Controls.Clear();
            string[] im = getImages(CreateAppDataPath());
            foreach (string images in im)
            {
                PictureBox pictures = new PictureBox
                {
                    Image = LoadWithoutLock(images),
                    Width = 320,
                    Height = 180,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Tag = images,
                    Margin = new Padding(20),
                    BorderStyle = BorderStyle.FixedSingle

                };

                pictures.Click += Pictures_Click;
                flowLayoutPanel1.Controls.Add(pictures);
            }
        }

        private void Pictures_Click(object? sender, EventArgs e)
        {
            PictureBox Picture = sender as PictureBox;
            SelectedPicture = Picture;
            if (SelectedPicture != null)
            {
                buttonSelect.BackColor = Color.Green;
                ButtonRemove.BackColor = Color.Green;
            }
            else
            {

                ButtonRemove.BackColor = Color.White;
                buttonSelect.BackColor = Color.White;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadWallpapers();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectedPicture != null)
            {
                SetWallpaper(SelectedPicture);
                SelectedPicture = null;
                buttonSelect.BackColor = Color.White;
                ButtonRemove.BackColor = Color.White;
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (SelectedPicture != null)
            {
                File.Delete((string)SelectedPicture.Tag);
                buttonSelect.BackColor = Color.White;
                ButtonRemove.BackColor = Color.White;
                SelectedPicture = null;
            }
            LoadWallpapers();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Pixabay pixaform = new Pixabay();
            pixaform.ShowDialog();
            LoadWallpapers();
        }
    }
}

