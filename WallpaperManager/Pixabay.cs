using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

using static System.Net.Mime.MediaTypeNames;
using PixabaySharp.Utility;
using PixabaySharp;
using System.Drawing.Imaging;
namespace WallpaperManager
{
    public partial class Pixabay : Form
    {
        private PictureBox pixabaySelectedPicture = null;


        public Pixabay()
        {
            InitializeComponent();
        }
        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var client = new PixabaySharpClient("49662846-8f39bd68e4eea8f7d33655195"); // remove spaces in the key if any
            int count = 1;
            string SearchText = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(SearchText))
                return;

            try
            {
                var result = await client.QueryImagesAsync(new ImageQueryBuilder()
                {
                    Query = SearchText,
                    PerPage = 6,
                    Page = count
                });

                count++;

                // Check for valid result and images
                if (result != null && result.Images != null && result.Images.Any())
                {
                    foreach (var im in result.Images)
                    {
                        PictureBox pic = new PictureBox
                        {
                            Width = 320,
                            Height = 180,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Margin = new Padding(20),
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        pic.Click += Pic_Click;
                        using (HttpClient httpclient = new HttpClient())
                        {
                            var url = im.ImageURL ?? im.LargeImageURL ?? im.WebformatURL;
                            var stream = await httpclient.GetStreamAsync(url);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                            pic.Image = image;
                        }

                        flowLayoutPanel1.Controls.Add(pic);
                    }
                    Pixabay_Load(sender, e);

                }
                else
                {
                    //MessageBox.Show("No images found.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        

        private void Pic_Click(object? sender, EventArgs e)
        {
            PictureBox Picture = sender as PictureBox;
            pixabaySelectedPicture = Picture;
            if (pixabaySelectedPicture != null)
            {
                buttonDownload.BackColor = Color.LimeGreen;
            }
            else
            {
                buttonDownload.BackColor = Color.White;
            }
        }
        public void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Pixabay_Load(object sender, EventArgs e)
        {

        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if(pixabaySelectedPicture != null)
            {
                string path = @"C:\ProgramData\WallpaperManager\images";
                string fileName = $"image_{DateTime.Now.Ticks}.png";
                string filePath = Path.Combine(path, fileName);
                pixabaySelectedPicture.Image.Save(filePath, ImageFormat.Png);
            }
            pixabaySelectedPicture = null;
            buttonDownload.BackColor = Color.White;
        }
    }
}
