using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MemoryGame
{
    //дана форма знаходиться у етапі розробки, тому її перевіряти поки що не треба
    public partial class SettingsForm: Form
    {
        public SettingsForm()
        {
            InitializeComponent();
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
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            float volume = Properties.Settings.Default.Volume;
            trackBarVolume.Value = (int)(volume * 100);
            labelVolume.Text = $"Volume: {trackBarVolume.Value}%";

            comboBoxBackground.Items.AddRange(new string[]
            {
                "AliceBlue", "Gray", "LightBlue", "Blue", "Beige"
            });
            string savedColor = Properties.Settings.Default.BackgroundColor;
            if(comboBoxBackground.Items.Contains(savedColor))
            {
                comboBoxBackground.SelectedItem = savedColor;
            }
            else
            {
                comboBoxBackground.SelectedItem = "AliceBlue";
            }
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
            string selectedColorName = comboBoxBackground.SelectedItem.ToString();
            Properties.Settings.Default.BackgroundColor = selectedColorName;
            Properties.Settings.Default.Save();
            this.BackColor = Color.FromName(selectedColorName);
        }

        private void buttonDescription_Click(object sender, EventArgs e)
        {
            string description = "The Memory Match game is a classic logic and memory challenge.\n" +
            "Your goal is to find all matching pairs of hidden pictures on the board.\\n" +
            "Click two cards per turn to reveal the images underneath.\n" +
            "If the images match, the pair will disappear.If not, the cards will flip back over.\n\n" +
            "The game continues until all pairs have been found.\n" +
            "Try to remember the positions of the pictures to improve your time.\n\n" +
            "Good luck and have fun!";
            MessageBox.Show(description, "Game Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
