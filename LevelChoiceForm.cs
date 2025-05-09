﻿using System;
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
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            MainPageForm mainPage = new MainPageForm();
            mainPage.Show();
            this.Close();
        }

        private void easyLevelButton_Click(object sender, EventArgs e)
        {
            EasyLevel easy = new EasyLevel();
            easy.Show();
            this.Close();
        }

        private void mediumLevelButton_Click(object sender, EventArgs e)
        {

        }

        private void hardLevelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
