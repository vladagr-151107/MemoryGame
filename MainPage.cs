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
