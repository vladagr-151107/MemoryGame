using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class EasyLevel : Form
    {
        private List<Image> images = new List<Image>();
        private List<PictureBox> cards = new List<PictureBox>();
        private PictureBox firstCard, secondCard;
        private Timer flipBackTimer, gameTimer, startTimer, removeMatchedTimer;
        private Image cardBack;
        private int timeElapsed = 0;
        private int matchedPairs = 0;
        private int totalPairs = 8;

        private string bestTimeFile = "best_time.txt";
        private SoundPlayer mismatchSound;

        public EasyLevel()
        {
            InitializeComponent();

            LoadImages();
            LoadCardBack();
            LoadSound();
            CreateBoard(4, 4);

            flipBackTimer = new Timer();
            flipBackTimer.Interval = 1000;
            flipBackTimer.Tick += FlipBackTimer_Tick;

            removeMatchedTimer = new Timer();
            removeMatchedTimer.Interval = 2000;
            removeMatchedTimer.Tick += RemoveMatchedTimer_Tick;

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;

            startTimer = new Timer();
            startTimer.Interval = 3000;
            startTimer.Tick += StartTimer_Tick;

            labelTime.Text = "Time: 00:00";
            startTimer.Start();
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

        private void LoadCardBack()
        {
            string basePath = Path.Combine(Application.StartupPath, "Images");
            cardBack = Image.FromFile(Path.Combine(basePath, "backCard.jpg"));
        }

        private void LoadSound()
        {
            string soundPath = Path.Combine(Application.StartupPath, "error.wav");
            if (File.Exists(soundPath))
            {
                mismatchSound = new SoundPlayer(soundPath);
            }
        }

        private void Shuffle(List<Image> list)
        {
            Random rand = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        private void CreateBoard(int rows, int cols)
        {
            int padding = 10;
            int startY = labelTime.Bottom + 10;
            int availableWidth = this.ClientSize.Width - (cols + 1) * padding;
            int availableHeight = this.ClientSize.Height - startY - (rows + 1) * padding;

            int cardSize = Math.Min(availableWidth / cols, availableHeight / rows);
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Width = pb.Height = cardSize;
                    pb.Left = col * (cardSize + padding) + padding;
                    pb.Top = startY + row * (cardSize + padding);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.BorderStyle = BorderStyle.FixedSingle;

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

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            startTimer.Stop();
            HideAllCards();
            gameTimer.Start();
        }

        private void HideAllCards()
        {
            foreach (var card in cards)
            {
                card.Image = cardBack;
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (flipBackTimer.Enabled || removeMatchedTimer.Enabled) return;

            PictureBox clicked = sender as PictureBox;
            if (clicked == null || clicked.Image != cardBack || clicked == firstCard) return;

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
                    removeMatchedTimer.Start();
                }
                else
                {
                    mismatchSound?.Play();
                    flipBackTimer.Start();
                }
            }
        }

        private void FlipBackTimer_Tick(object sender, EventArgs e)
        {
            flipBackTimer.Stop();

            if (firstCard != null) firstCard.Image = cardBack;
            if (secondCard != null) secondCard.Image = cardBack;

            firstCard = secondCard = null;
        }

        private void RemoveMatchedTimer_Tick(object sender, EventArgs e)
        {
            removeMatchedTimer.Stop();

            if (firstCard != null) firstCard.Visible = false;
            if (secondCard != null) secondCard.Visible = false;

            firstCard = secondCard = null;
            matchedPairs++;

            if (matchedPairs == totalPairs)
            {
                gameTimer.Stop();
                CheckAndSaveBestTime();
                MessageBox.Show("You won!", "Victory");
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            labelTime.Text = "Time: " + TimeSpan.FromSeconds(timeElapsed).ToString(@"mm\:ss");
        }

        private void CheckAndSaveBestTime()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, bestTimeFile);
                if (File.Exists(path))
                {
                    int best = int.Parse(File.ReadAllText(path));
                    if (timeElapsed < best)
                    {
                        File.WriteAllText(path, timeElapsed.ToString());
                    }
                }
                else
                {
                    File.WriteAllText(path, timeElapsed.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving best time: " + ex.Message);
            }
        }
    }
}