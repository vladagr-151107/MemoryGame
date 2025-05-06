using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class EasyLevel: Form
    {
        private List<Image> images = new List<Image>();
        private List<PictureBox> cards = new List<PictureBox>();
        private PictureBox firstCard, secondCard;
        private Timer flipBackTimer;
        public EasyLevel()
        {
            InitializeComponent();
            LoadImages();
            CreateBoard(4, 4);
            flipBackTimer = new Timer();
            flipBackTimer.Interval = 1000;
            flipBackTimer.Tick += FlipBackTimer_Tick;
        }
        private void LoadImages()
        {
            string basePath = Path.Combine(Application.StartupPath, "Images");
            images.Clear();
            images.Add(Image.FromFile(Path.Combine(basePath, "bet.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "cat.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "elephant.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "mouse.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "panda.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "paws.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "polarBear.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "rabbit.JPG")));

            images.AddRange(images);
            Shuffle(images);
        }
        private void Shuffle(List<Image> list)
        {
            Random random = new Random();
            for(int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temporary = list[i];
                list[i] = list[j];
                list[j] = temporary;
            }
        }
        private void CreateBoard(int rows, int columns)
        {
            int cardSize = 130;
            int padding = 10;
            int index = 0;
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < columns; col++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Width = pb.Height = cardSize;
                    pb.Left = col * (cardSize + padding) + padding;
                    pb.Top = row * (cardSize + padding) + padding;
                    pb.BackColor = Color.AliceBlue;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (index < images.Count)
                    {
                        pb.Image = images[index];
                        pb.Tag = images[index];
                    }
                    pb.Click += Card_Click;
                    this.Controls.Add(pb);
                    cards.Add(pb);
                    index++;
                }
            }
        }
        private void Card_Click(object sender, EventArgs e)
        {
            if (flipBackTimer.Enabled) return;

            PictureBox clicked = sender as PictureBox;

            if (clicked.Image != null) return;

            clicked.Image = (Image)clicked.Tag;

            if (firstCard == null)
            {
                firstCard = clicked;
            }
            else
            {
                secondCard = clicked;

                if (firstCard.Tag.Equals(secondCard.Tag))
                {
                    firstCard = secondCard = null; 
                }
                else
                {
                    flipBackTimer.Interval = 3000; // 3 seconds
                    flipBackTimer.Start();
                }
            }
        }

        private void FlipBackTimer_Tick(object sender, EventArgs e)
        {
            flipBackTimer.Stop();

            if (firstCard != null)
            {
                firstCard.Image = null;
                firstCard.BackColor = Color.LightGray; 
            }
            if (secondCard != null)
            {
                secondCard.Image = null;
                secondCard.BackColor = Color.LightGray;
            }

            firstCard = secondCard = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
