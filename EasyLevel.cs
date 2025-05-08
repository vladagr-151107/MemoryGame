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
    public partial class EasyLevel : Form
    {
        private List<Image> images = new List<Image>();
        private List<PictureBox> cards = new List<PictureBox>();
        private PictureBox firstCard, secondCard;
        private Timer flipBackTimer;
        private Timer previewTimer;
        private Timer gameTimer;
        private Label timeLabel;
        private Image cardBackImage;
        private int timeElapsed = 0;

        public EasyLevel()
        {
            InitializeComponent();
            LoadImages();
            CreateBoard(4, 4);
            AddTimerLabel();

            flipBackTimer = new Timer();
            flipBackTimer.Interval = 2000; // Для показа совпавшей пары 2 секунды
            flipBackTimer.Tick += FlipBackTimer_Tick;

            previewTimer = new Timer();
            previewTimer.Interval = 3000;
            previewTimer.Tick += PreviewTimer_Tick;

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;

            previewTimer.Start();
        }

        private void LoadImages()
        {
            string basePath = Path.Combine(Application.StartupPath, "Images");
            cardBackImage = Image.FromFile(Path.Combine(basePath, "zooTicket.jpg")); // рубашка карты

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
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        private void CreateBoard(int rows, int columns)
        {
            int cardSize = 130;
            int padding = 10;
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Width = pb.Height = cardSize;
                    pb.Left = col * (cardSize + padding) + padding;
                    pb.Top = row * (cardSize + padding) + padding;
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (index < images.Count)
                    {
                        pb.Image = images[index]; // покажем все картинки сначала
                        pb.Tag = images[index];
                    }

                    pb.Click += Card_Click;
                    this.Controls.Add(pb);
                    cards.Add(pb);
                    index++;
                }
            }
        }

        private void AddTimerLabel()
        {
            timeLabel = new Label();
            timeLabel.Font = new Font("Arial", 16);
            timeLabel.ForeColor = Color.Black;
            timeLabel.Text = "Time: 0";
            timeLabel.AutoSize = true;
            timeLabel.Top = cards.Last().Bottom + 10;
            timeLabel.Left = 10;
            this.Controls.Add(timeLabel);
        }

        private void PreviewTimer_Tick(object sender, EventArgs e)
        {
            previewTimer.Stop();

            // Скрываем все карты (устанавливаем рубашку)
            foreach (var card in cards)
            {
                card.Image = cardBackImage;
            }

            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            timeLabel.Text = "Time: " + timeElapsed;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (flipBackTimer.Enabled || previewTimer.Enabled) return;

            PictureBox clicked = sender as PictureBox;

            // Уже открытая карта — игнорируем
            if (clicked.Image != cardBackImage) return;

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
                    flipBackTimer.Start(); // таймер для удаления пары
                }
                else
                {
                    flipBackTimer.Start(); // таймер для скрытия
                }
            }
        }

        private void FlipBackTimer_Tick(object sender, EventArgs e)
        {
            flipBackTimer.Stop();

            if (firstCard != null && secondCard != null)
            {
                if (firstCard.Tag.Equals(secondCard.Tag))
                {
                    // Совпавшие — убираем с формы
                    this.Controls.Remove(firstCard);
                    this.Controls.Remove(secondCard);
                    cards.Remove(firstCard);
                    cards.Remove(secondCard);
                }
                else
                {
                    // Не совпали — скрываем
                    firstCard.Image = cardBackImage;
                    secondCard.Image = cardBackImage;
                }
            }

            firstCard = secondCard = null;

            if (cards.Count == 0)
            {
                gameTimer.Stop();
                MessageBox.Show("Победа! Время: " + timeElapsed + " сек.");
            }
        }
    }
}
