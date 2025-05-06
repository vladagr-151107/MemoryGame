namespace MemoryGame
{
    partial class LevelChoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backToMenuButton = new System.Windows.Forms.Button();
            this.easyLevelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mediumLevelButton = new System.Windows.Forms.Button();
            this.hardLevelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.BackColor = System.Drawing.Color.SkyBlue;
            this.backToMenuButton.Location = new System.Drawing.Point(12, 12);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Size = new System.Drawing.Size(127, 48);
            this.backToMenuButton.TabIndex = 0;
            this.backToMenuButton.Text = "Back to menu";
            this.backToMenuButton.UseVisualStyleBackColor = false;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenuButton_Click);
            // 
            // easyLevelButton
            // 
            this.easyLevelButton.BackColor = System.Drawing.Color.LightBlue;
            this.easyLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.easyLevelButton.Location = new System.Drawing.Point(328, 81);
            this.easyLevelButton.Name = "easyLevelButton";
            this.easyLevelButton.Size = new System.Drawing.Size(144, 70);
            this.easyLevelButton.TabIndex = 1;
            this.easyLevelButton.Text = "Easy";
            this.easyLevelButton.UseVisualStyleBackColor = false;
            this.easyLevelButton.Click += new System.EventHandler(this.easyLevelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(252, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose the level of the game";
            // 
            // mediumLevelButton
            // 
            this.mediumLevelButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.mediumLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mediumLevelButton.Location = new System.Drawing.Point(328, 190);
            this.mediumLevelButton.Name = "mediumLevelButton";
            this.mediumLevelButton.Size = new System.Drawing.Size(144, 70);
            this.mediumLevelButton.TabIndex = 3;
            this.mediumLevelButton.Text = "Medium";
            this.mediumLevelButton.UseVisualStyleBackColor = false;
            this.mediumLevelButton.Click += new System.EventHandler(this.mediumLevelButton_Click);
            // 
            // hardLevelButton
            // 
            this.hardLevelButton.BackColor = System.Drawing.Color.Blue;
            this.hardLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hardLevelButton.Location = new System.Drawing.Point(328, 308);
            this.hardLevelButton.Name = "hardLevelButton";
            this.hardLevelButton.Size = new System.Drawing.Size(144, 70);
            this.hardLevelButton.TabIndex = 4;
            this.hardLevelButton.Text = "Hard";
            this.hardLevelButton.UseVisualStyleBackColor = false;
            this.hardLevelButton.Click += new System.EventHandler(this.hardLevelButton_Click);
            // 
            // LevelChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hardLevelButton);
            this.Controls.Add(this.mediumLevelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.easyLevelButton);
            this.Controls.Add(this.backToMenuButton);
            this.Name = "LevelChoiceForm";
            this.Text = "LevelChoiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backToMenuButton;
        private System.Windows.Forms.Button easyLevelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mediumLevelButton;
        private System.Windows.Forms.Button hardLevelButton;
    }
}