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

namespace PictureViewermasterpro
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// Przycisk Załaduj ma za zadanie uruchomić Eksplorator plików w celu wyszukania zdjęcia. 
        /// Ustawione są selekcje rozszerzeń : jpg/png/bmp/all
        /// </summary>

        //Przycisk Załaduj
        public void showButton_Click(object sender, EventArgs e)
        {
            //otwiera FileDialog w celu załadowania zdjęcia
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var plikIsObraz = Stat.SprawzCzyObraz(openFileDialog1.FileName);
                if (plikIsObraz)
                    pictureBox1.Load(openFileDialog1.FileName);

                //wyświetla załadowany obraz na pictureBox'ie
            }
        }

        //przycisk Wyczyść
        public void clearButton_Click(object sender, EventArgs e)
        {
            //Czyści pictureBox z obrazu
            pictureBox1.Image = null;
        }
        /// <summary>
        /// Przycisk Kolor tła ma za zadanie uruchomić fabrycznie zainstalowaną paletę kolorów i zmienić tło,
        /// w którym jest pokazywane zdjęcie
        /// </summary>

        //przycisk Kolor tła
        public void backgroundButton_Click(object sender, EventArgs e)
        {

            //zmienia tło, gdzie będzie wyświelany obraz
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = colorDialog1.Color;
        }

        //przycisk Zamknij
        public void closebutton_Click(object sender, EventArgs e)
        {
            //zamyka program
            this.Close();
        }

        //Przycisk Obróć
        public void RotateButtonR_Click(object sender, EventArgs e)
        {
                this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone); ///obraca obraz o 90 stopni
        }

        //Przycisk Obróć
        public void RotateButtonL_Click(object sender, EventArgs e)
        {
             this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone); ///obraca obraz o 270 stopni
        }
        /// <summary>
        /// Jeżeli przycisk Rozciągnij jest wciśnięty, ustawia wartość pictureBoxa na StretchImage,
        /// jeśeli nie jest wciśnięty, zostawia AutoSize.
        /// </summary>
        //Przycisk "Rozciągnij"
        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        /// <summary>
        /// Zaimplementowany został tutaj sposób powiększania i pomniejszania obrazu za pomocą suwaka "trackBar"
        /// za pomocą Bitmap 
        /// </summary>
        Image ZoomPicture(Image img, Size size)
        {

            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width), Convert.ToInt32(img.Height * size.Height));

            Graphics gpu = Graphics.FromImage(bm);
            gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bm;
        }
        /// <summary>
        /// Nadaje ustawienia dla suwaka znajdującego się w flowLayoutPanel1
        /// </summary>

        PictureBox org;
        public void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            trackBar1.Minimum = 1; //minimalna ilość suwaka
            trackBar1.Maximum = 6; //maksymalna ilość suwaka
            trackBar1.LargeChange = 1; 
            trackBar1.SmallChange = 1;
            //wartość przesuwania to 1

            this.DoubleBuffered = true; //włącza funkcje podwójnego buforowania
            org = new PictureBox();
            org.Image = pictureBox1.Image;
        }
        /// <summary>
        /// Reguła dla suwaka
        /// </summary>

        public void trackBar1_Scroll(object sender, EventArgs e)
        {  
            //reguła
            if (trackBar1.Value !=0)
            {
                pictureBox1.Image = null; //nie zmienia nic
                pictureBox1.Image = ZoomPicture(org.Image, new Size(trackBar1.Value, trackBar1.Value)); //używa funkcji ZoomPicture
            }
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
