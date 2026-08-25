namespace ChapinWarriorsSA.Views
{
    partial class Details
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
            Graphiz = new PictureBox();
            Title = new Label();
            CityName = new Label();
            Dimension = new Label();
            theDimension = new Label();
            Entries = new Label();
            theEntries = new Label();
            Military = new Label();
            theMilitary = new Label();
            Civil = new Label();
            theCivilies = new Label();
            Resources = new Label();
            theResources = new Label();
            theName = new Label();
            NextButton = new PictureBox();
            PreviousButton = new PictureBox();
            Number = new Label();
            Exit = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Graphiz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NextButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviousButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Exit).BeginInit();
            SuspendLayout();
            // 
            // Graphiz
            // 
            Graphiz.Location = new Point(46, 85);
            Graphiz.Name = "Graphiz";
            Graphiz.Size = new Size(278, 277);
            Graphiz.SizeMode = PictureBoxSizeMode.Zoom;
            Graphiz.TabIndex = 0;
            Graphiz.TabStop = false;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("SimSun-ExtG", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title.ForeColor = SystemColors.ButtonHighlight;
            Title.Location = new Point(46, 32);
            Title.Name = "Title";
            Title.Size = new Size(89, 19);
            Title.TabIndex = 1;
            Title.Text = "Ciudades";
            // 
            // CityName
            // 
            CityName.AutoSize = true;
            CityName.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CityName.ForeColor = SystemColors.ButtonHighlight;
            CityName.Location = new Point(392, 85);
            CityName.Name = "CityName";
            CityName.Size = new Size(87, 21);
            CityName.TabIndex = 3;
            CityName.Text = "Nombre:";
            // 
            // Dimension
            // 
            Dimension.AutoSize = true;
            Dimension.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Dimension.ForeColor = SystemColors.ButtonHighlight;
            Dimension.Location = new Point(392, 125);
            Dimension.Name = "Dimension";
            Dimension.Size = new Size(118, 21);
            Dimension.TabIndex = 4;
            Dimension.Text = "Dimensión:";
            // 
            // theDimension
            // 
            theDimension.AutoSize = true;
            theDimension.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            theDimension.ForeColor = SystemColors.ButtonHighlight;
            theDimension.Location = new Point(620, 125);
            theDimension.Name = "theDimension";
            theDimension.Size = new Size(98, 21);
            theDimension.TabIndex = 5;
            theDimension.Text = "CityName";
            // 
            // Entries
            // 
            Entries.AutoSize = true;
            Entries.BackColor = Color.Black;
            Entries.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Entries.ForeColor = Color.SpringGreen;
            Entries.Location = new Point(392, 168);
            Entries.Name = "Entries";
            Entries.Size = new Size(208, 21);
            Entries.TabIndex = 6;
            Entries.Text = "Puntos de Entrada:";
            // 
            // theEntries
            // 
            theEntries.AutoSize = true;
            theEntries.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            theEntries.ForeColor = SystemColors.ButtonHighlight;
            theEntries.Location = new Point(620, 168);
            theEntries.Name = "theEntries";
            theEntries.Size = new Size(98, 21);
            theEntries.TabIndex = 7;
            theEntries.Text = "Entradas";
            // 
            // Military
            // 
            Military.AutoSize = true;
            Military.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Military.ForeColor = Color.Red;
            Military.Location = new Point(392, 212);
            Military.Name = "Military";
            Military.Size = new Size(219, 21);
            Military.TabIndex = 8;
            Military.Text = "Unidades Militares:";
            // 
            // theMilitary
            // 
            theMilitary.AutoSize = true;
            theMilitary.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            theMilitary.ForeColor = SystemColors.ButtonHighlight;
            theMilitary.Location = new Point(620, 212);
            theMilitary.Name = "theMilitary";
            theMilitary.Size = new Size(98, 21);
            theMilitary.TabIndex = 9;
            theMilitary.Text = "Entradas";
            // 
            // Civil
            // 
            Civil.AutoSize = true;
            Civil.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Civil.ForeColor = SystemColors.MenuHighlight;
            Civil.Location = new Point(392, 257);
            Civil.Name = "Civil";
            Civil.Size = new Size(197, 21);
            Civil.TabIndex = 10;
            Civil.Text = "Unidades Civiles:";
            // 
            // theCivilies
            // 
            theCivilies.AutoSize = true;
            theCivilies.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            theCivilies.ForeColor = SystemColors.ButtonHighlight;
            theCivilies.Location = new Point(620, 257);
            theCivilies.Name = "theCivilies";
            theCivilies.Size = new Size(98, 21);
            theCivilies.TabIndex = 11;
            theCivilies.Text = "Entradas";
            // 
            // Resources
            // 
            Resources.AutoSize = true;
            Resources.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Resources.ForeColor = SystemColors.ActiveBorder;
            Resources.Location = new Point(392, 302);
            Resources.Name = "Resources";
            Resources.Size = new Size(109, 21);
            Resources.TabIndex = 12;
            Resources.Text = "Recursos:";
            // 
            // theResources
            // 
            theResources.AutoSize = true;
            theResources.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            theResources.ForeColor = SystemColors.ButtonHighlight;
            theResources.Location = new Point(620, 302);
            theResources.Name = "theResources";
            theResources.Size = new Size(98, 21);
            theResources.TabIndex = 13;
            theResources.Text = "Entradas";
            // 
            // theName
            // 
            theName.AutoSize = true;
            theName.Font = new Font("SimSun-ExtG", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            theName.ForeColor = SystemColors.ButtonHighlight;
            theName.Location = new Point(620, 85);
            theName.Name = "theName";
            theName.Size = new Size(98, 21);
            theName.TabIndex = 15;
            theName.Text = "CityName";
            // 
            // NextButton
            // 
            NextButton.Image = Properties.Resources.FlechaNext;
            NextButton.Location = new Point(562, 357);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(106, 60);
            NextButton.SizeMode = PictureBoxSizeMode.Zoom;
            NextButton.TabIndex = 16;
            NextButton.TabStop = false;
            NextButton.Click += NextButton_Click;
            // 
            // PreviousButton
            // 
            PreviousButton.Image = Properties.Resources.FlechaBefore;
            PreviousButton.Location = new Point(461, 357);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(101, 60);
            PreviousButton.SizeMode = PictureBoxSizeMode.Zoom;
            PreviousButton.TabIndex = 17;
            PreviousButton.TabStop = false;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // Number
            // 
            Number.AutoSize = true;
            Number.Font = new Font("SimSun-ExtG", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Number.ForeColor = SystemColors.ButtonHighlight;
            Number.Location = new Point(506, 25);
            Number.Name = "Number";
            Number.Size = new Size(124, 27);
            Number.TabIndex = 18;
            Number.Text = "Ciudades";
            // 
            // Exit
            // 
            Exit.Image = Properties.Resources.salir;
            Exit.Location = new Point(12, 386);
            Exit.Name = "Exit";
            Exit.Size = new Size(65, 52);
            Exit.SizeMode = PictureBoxSizeMode.Zoom;
            Exit.TabIndex = 19;
            Exit.TabStop = false;
            Exit.Click += Exit_Click;
            // 
            // Details
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(Exit);
            Controls.Add(Number);
            Controls.Add(PreviousButton);
            Controls.Add(NextButton);
            Controls.Add(theName);
            Controls.Add(theResources);
            Controls.Add(Resources);
            Controls.Add(theCivilies);
            Controls.Add(Civil);
            Controls.Add(theMilitary);
            Controls.Add(Military);
            Controls.Add(theEntries);
            Controls.Add(Entries);
            Controls.Add(theDimension);
            Controls.Add(Dimension);
            Controls.Add(CityName);
            Controls.Add(Title);
            Controls.Add(Graphiz);
            ForeColor = Color.White;
            Name = "Details";
            Text = "Details";
            ((System.ComponentModel.ISupportInitialize)Graphiz).EndInit();
            ((System.ComponentModel.ISupportInitialize)NextButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviousButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)Exit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Graphiz;
        private Label Title;
        private Label CityName;
        private Label Dimension;
        private Label theDimension;
        private Label Entries;
        private Label theEntries;
        private Label Military;
        private Label theMilitary;
        private Label Civil;
        private Label theCivilies;
        private Label Resources;
        private Label theResources;
        private Label theName;
        private PictureBox NextButton;
        private PictureBox PreviousButton;
        private Label Number;
        private PictureBox Exit;
    }
}