namespace ChapinWarriorsSA.Views
{
    partial class MainView
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
            pictureBox1 = new PictureBox();
            FirstButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ChatGPT_Image_Aug_19__2026__09_36_14_PM;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(398, 395);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // FirstButton
            // 
            FirstButton.BackColor = SystemColors.ActiveCaptionText;
            FirstButton.Font = new Font("SimSun-ExtG", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FirstButton.ForeColor = SystemColors.ButtonHighlight;
            FirstButton.Location = new Point(118, 409);
            FirstButton.Name = "FirstButton";
            FirstButton.Size = new Size(159, 48);
            FirstButton.TabIndex = 1;
            FirstButton.Text = "Cargar XML";
            FirstButton.UseVisualStyleBackColor = false;
            FirstButton.Click += FirstButton_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(397, 487);
            Controls.Add(FirstButton);
            Controls.Add(pictureBox1);
            Name = "MainView";
            Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button FirstButton;
    }
}