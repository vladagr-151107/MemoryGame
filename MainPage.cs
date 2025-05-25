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
    public partial class MainPageForm: Form
    {
        public MainPageForm()
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

        private void playButton_Click(object sender, EventArgs e)
        {
            LevelChoiceForm levelChoice= new LevelChoiceForm();
            levelChoice.Show();
            this.Hide();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
            base.OnFormClosing(e);
        }
    }
}
