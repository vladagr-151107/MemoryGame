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
    public partial class LevelChoiceForm: Form
    {
        public LevelChoiceForm()
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

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            MainPageForm mainPage = new MainPageForm();
            mainPage.Show();
            this.Hide();
        }

        private void easyLevelButton_Click(object sender, EventArgs e)
        {
            EasyLevel easy = new EasyLevel();
            easy.Show();
            this.Hide();
        }

        private void mediumLevelButton_Click(object sender, EventArgs e)
        {
            MediumLevel medium = new MediumLevel();
            medium.Show();
            this.Hide();
        }

        private void hardLevelButton_Click(object sender, EventArgs e)
        {
            HardLevel hard = new HardLevel();
            hard.Show();
            this.Hide();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
            base.OnFormClosing(e);
        }
    }
}
