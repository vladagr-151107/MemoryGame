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
    //дана форма знаходиться у етапі розробки, тому її перевіряти поки що не треба
    public partial class SettingsForm: Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
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
            trackBarVolume.Value = (int)(GameSettings.Volume * 100);
            labelVolume.Text = $"Volume: {trackBarVolume.Value}%";

            comboBoxBackground.Items.AddRange(new string[]
            {
                "Gray", "LightBlue", "AliceBlue", "Blue", "Beige"
            });
            comboBoxBackground.SelectedItem = GameSettings.BackgroundColor.Name;
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            GameSettings.Volume = trackBarVolume.Value / 100f;
            labelVolume.Text = $"Volume: {trackBarVolume.Value}%";
        }

        private void comboBoxBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColorName = comboBoxBackground.SelectedItem.ToString();
            GameSettings.BackgroundColor = Color.FromName(selectedColorName);
            this.BackColor = GameSettings.BackgroundColor;
        }
    }
}
