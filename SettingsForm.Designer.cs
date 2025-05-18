namespace MemoryGame
{
    partial class SettingsForm
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
            this.labelVolume = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelBackgroundColor = new System.Windows.Forms.Label();
            this.buttonDescription = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.backToMenuButton = new System.Windows.Forms.Button();
            this.comboBoxBackground = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVolume.Location = new System.Drawing.Point(303, 44);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(63, 20);
            this.labelVolume.TabIndex = 0;
            this.labelVolume.Text = "Volume";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(271, 86);
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(121, 45);
            this.trackBarVolume.TabIndex = 1;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // labelBackgroundColor
            // 
            this.labelBackgroundColor.AutoSize = true;
            this.labelBackgroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBackgroundColor.Location = new System.Drawing.Point(267, 168);
            this.labelBackgroundColor.Name = "labelBackgroundColor";
            this.labelBackgroundColor.Size = new System.Drawing.Size(133, 20);
            this.labelBackgroundColor.TabIndex = 2;
            this.labelBackgroundColor.Text = "Background color";
            // 
            // buttonDescription
            // 
            this.buttonDescription.BackColor = System.Drawing.Color.PowderBlue;
            this.buttonDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDescription.Location = new System.Drawing.Point(252, 330);
            this.buttonDescription.Name = "buttonDescription";
            this.buttonDescription.Size = new System.Drawing.Size(155, 61);
            this.buttonDescription.TabIndex = 7;
            this.buttonDescription.Text = "Read it";
            this.buttonDescription.UseVisualStyleBackColor = false;
            this.buttonDescription.Click += new System.EventHandler(this.buttonDescription_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.Location = new System.Drawing.Point(248, 288);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(178, 20);
            this.labelDescription.TabIndex = 8;
            this.labelDescription.Text = "Description of the game";
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.BackColor = System.Drawing.Color.SkyBlue;
            this.backToMenuButton.Location = new System.Drawing.Point(12, 16);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Size = new System.Drawing.Size(127, 48);
            this.backToMenuButton.TabIndex = 10;
            this.backToMenuButton.Text = "Back to menu";
            this.backToMenuButton.UseVisualStyleBackColor = false;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenuButton_Click);
            // 
            // comboBoxBackground
            // 
            this.comboBoxBackground.FormattingEnabled = true;
            this.comboBoxBackground.Items.AddRange(new object[] {
            "Gray",
            "LightBlue",
            "AliceBlue",
            "Blue",
            "Beige"});
            this.comboBoxBackground.Location = new System.Drawing.Point(271, 213);
            this.comboBoxBackground.Name = "comboBoxBackground";
            this.comboBoxBackground.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBackground.TabIndex = 11;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(691, 450);
            this.Controls.Add(this.comboBoxBackground);
            this.Controls.Add(this.backToMenuButton);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.buttonDescription);
            this.Controls.Add(this.labelBackgroundColor);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.labelVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelBackgroundColor;
        private System.Windows.Forms.Button buttonDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button backToMenuButton;
        private System.Windows.Forms.ComboBox comboBoxBackground;
    }
}