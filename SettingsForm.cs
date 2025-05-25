using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Properties.Settings.Default.BackgroundColor))
            {
                Properties.Settings.Default.BackgroundColor = "AliceBlue";
                Properties.Settings.Default.Save();
            }
            string bgColor = Properties.Settings.Default.BackgroundColor;
            this.BackColor = Color.FromName(bgColor);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            base.OnFormClosing(e);
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            MainPageForm mainPage = new MainPageForm();
            mainPage.Show();
            this.Hide();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            bool needSave = false;

            if (string.IsNullOrEmpty(Properties.Settings.Default.BackgroundColor))
            {
                Properties.Settings.Default.BackgroundColor = "AliceBlue";
                needSave = true;
            }
            if (!Properties.Settings.Default.VolumeInitialized)
            {
                Properties.Settings.Default.Volume = 0.5f; 
                Properties.Settings.Default.VolumeInitialized = true;
                needSave = true;
            }

            if (needSave)
            {
                Properties.Settings.Default.Save();
            }

            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            float volume = Properties.Settings.Default.Volume;
            trackBarVolume.Value = (int)(volume * 100);
            labelVolume.Text = $"Volume: {trackBarVolume.Value}%";
            string savedColor = Properties.Settings.Default.BackgroundColor;
            comboBoxBackground.SelectedItem = savedColor;
            this.BackColor = Color.FromName(savedColor);
        }


        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            float volume = trackBarVolume.Value / 100f;
            Properties.Settings.Default.Volume = volume;
            Properties.Settings.Default.Save();
            labelVolume.Text = $"Volume: {trackBarVolume.Value}%";
        }

        private void comboBoxBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBackground.SelectedItem != null)
            {
                string selectedColorName = comboBoxBackground.SelectedItem.ToString();
                Properties.Settings.Default.BackgroundColor = selectedColorName;
                Properties.Settings.Default.Save();
                this.BackColor = Color.FromName(selectedColorName);
                this.Refresh();
            }
        }

        private void buttonDescription_Click(object sender, EventArgs e)
        {
            string description = "The Memory Match game is a classic logic and memory challenge.\n" +
            "Your goal is to find all matching pairs of hidden pictures on the board.\n" +
            "Click two cards per turn to reveal the images underneath.\n" +
            "If the images match, the pair will disappear.If not, the cards will flip back over.\n\n" +
            "The game continues until all pairs have been found.\n" +
            "Try to remember the positions of the pictures to improve your time.\n\n" +
            "Good luck and have fun!";
            MessageBox.Show(description, "Game Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}