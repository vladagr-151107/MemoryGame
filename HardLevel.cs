using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;

namespace MemoryGame
{
    public partial class HardLevel : Form
    {
        private List<Image> images = new List<Image>();
        private List<PictureBox> cards = new List<PictureBox>();
        private PictureBox firstCard, secondCard;
        private Timer flipBackTimer, gameTimer, startTimer, removeMatchedTimer;
        private Image cardBack;
        private int timeElapsed = 0;
        private int matchedPairs = 0;
        private int totalPairs = 18;
        private Label labelBestTime;

        private string soundDir;
        private string matchSoundPath;
        private string mismatchSoundPath;
        private string winSoundPath;

        private string bestTimeFile = "hard_best_time.txt";

        public HardLevel()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Properties.Settings.Default.BackgroundColor))
            {
                Properties.Settings.Default.BackgroundColor = "AliceBlue";
                Properties.Settings.Default.Save();
            }

            if (!Properties.Settings.Default.VolumeInitialized)
            {
                Properties.Settings.Default.Volume = 0.5f;
                Properties.Settings.Default.VolumeInitialized = true;
                Properties.Settings.Default.Save();
            }
            string bgColor = Properties.Settings.Default.BackgroundColor;
            this.BackColor = Color.FromName(bgColor);

            soundDir = Path.Combine(Application.StartupPath, "Sounds");
            matchSoundPath = Path.Combine(soundDir, "match.wav");
            mismatchSoundPath = Path.Combine(soundDir, "mismatch.wav");
            winSoundPath = Path.Combine(soundDir, "win.wav");

            LoadImages();
            LoadCardBack();
            CreateBoard(6, 6);

            flipBackTimer = new Timer();
            flipBackTimer.Interval = 1000;
            flipBackTimer.Tick += FlipBackTimer_Tick;

            removeMatchedTimer = new Timer();
            removeMatchedTimer.Interval = 1500;
            removeMatchedTimer.Tick += RemoveMatchedTimer_Tick;

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;

            startTimer = new Timer();
            startTimer.Interval = 5000;
            startTimer.Tick += StartTimer_Tick;

            labelTime.Text = "Time: 00:00";
            startTimer.Start();

            labelBestTime = new Label();
            labelBestTime.AutoSize = true;
            labelBestTime.Location = new Point(labelTime.Right + 20, labelTime.Top);
            labelBestTime.Font = labelTime.Font;
            labelBestTime.Text = "Best: 00:00";
            this.Controls.Add(labelBestTime);

            UpdateBestTimeLabel();
            this.BackColor = Color.FromName(Properties.Settings.Default.BackgroundColor);
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
            images.Add(Image.FromFile(Path.Combine(basePath, "shrimps.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "zooTicket.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "bear.PNG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "cat2.PNG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "bee.PNG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "mice.PNG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "frog.PNG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "hummingbird.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "shrimp.JPG")));
            images.Add(Image.FromFile(Path.Combine(basePath, "chick.PNG")));
            images.AddRange(images);
            Shuffle(images);
        }

        private void LoadCardBack()
        {
            string basePath = Path.Combine(Application.StartupPath, "Images");
            cardBack = Image.FromFile(Path.Combine(basePath, "backCard.jpg"));
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
                    PlaySound(matchSoundPath);
                    removeMatchedTimer.Start();
                }
                else
                {
                    PlaySound(mismatchSoundPath);
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
                PlaySound(winSoundPath);
                MessageBox.Show("You won!", "Victory");
                string gameDir = Application.StartupPath;
                string easyPath = Path.Combine(gameDir, "easy_passed.txt");
                string mediumPath = Path.Combine(gameDir, "medium_passed.txt");
                string hardPath = Path.Combine(gameDir, "hard_passed.txt");
                if (!File.Exists(mediumPath))
                    File.WriteAllText(mediumPath, "true");
                bool easyPassed = File.Exists(easyPath);
                bool mediumPassed = File.Exists(mediumPath);
                if (easyPassed && mediumPassed)
                {
                    MessageBox.Show("Thanks, you passed the game!", "End of the game 🎉");
                    Application.Exit();
                }
                else
                {
                    var result = MessageBox.Show("Do you want to keep going?", "Keep going?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (!easyPassed)
                        {
                            EasyLevel easy = new EasyLevel();
                            easy.Show();
                        }
                    else if (!mediumPassed)
                    {
                        MediumLevel medium = new MediumLevel();
                        medium.Show();
                    }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Bye, thanks for the game!");
                        Application.Exit();
                    }
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            labelTime.Text = "Time: " + TimeSpan.FromSeconds(timeElapsed).ToString(@"mm\:ss");
        }

        private void UpdateBestTimeLabel()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, bestTimeFile);
                if (File.Exists(path))
                {
                    int best = int.Parse(File.ReadAllText(path));
                    labelBestTime.Text = "Best: " + TimeSpan.FromSeconds(best).ToString(@"mm\:ss");
                }
            }
            catch
            {
                labelBestTime.Text = "Best: --:--";
            }
        }

        private void CheckAndSaveBestTime()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, bestTimeFile);
                bool isNewBest = false;

                if (File.Exists(path))
                {
                    int best = int.Parse(File.ReadAllText(path));
                    if (timeElapsed < best)
                    {
                        File.WriteAllText(path, timeElapsed.ToString());
                        isNewBest = true;
                    }
                }
                else
                {
                    File.WriteAllText(path, timeElapsed.ToString());
                    isNewBest = true;
                }

                if (isNewBest)
                {
                    UpdateBestTimeLabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving best time: " + ex.Message);
            }
        }

        private void PlaySound(string filePath)
        {
            if (!File.Exists(filePath)) return;

            var reader = new AudioFileReader(filePath);
            var player = new WaveOutEvent();
            player.Init(reader);
            player.Volume = Properties.Settings.Default.Volume;

            player.Play();
            player.PlaybackStopped += (s, e) =>
            {
                player.Dispose();
                reader.Dispose();
            };
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
            base.OnFormClosing(e);
        }
    }
}