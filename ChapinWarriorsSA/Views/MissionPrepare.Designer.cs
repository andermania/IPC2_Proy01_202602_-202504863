namespace ChapinWarriorsSA.Views
{
    partial class MissionPrepare
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
            FormTitle = new Label();
            CityNameLabel = new Label();
            CityImage = new PictureBox();
            CityPrev = new PictureBox();
            CityCounter = new Label();
            CityNext = new PictureBox();
            RobotNameLabel = new Label();
            RobotTypeLabel = new Label();
            RobotCapLabel = new Label();
            RobotImage = new PictureBox();
            RobotPrev = new PictureBox();
            RobotCounter = new Label();
            RobotNext = new PictureBox();
            DestTitleLabel = new Label();
            DestComboBox = new ComboBox();
            DestInfoLabel = new Label();
            NoDestLabel = new Label();
            ExitButton = new PictureBox();
            EjectMission = new PictureBox();
            DestInfoLabel2 = new Label();
            ((System.ComponentModel.ISupportInitialize)CityImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CityPrev).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CityNext).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RobotImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RobotPrev).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RobotNext).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EjectMission).BeginInit();
            SuspendLayout();
            // 
            // FormTitle
            // 
            FormTitle.AutoSize = true;
            FormTitle.Font = new Font("SimSun-ExtG", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormTitle.ForeColor = SystemColors.ButtonHighlight;
            FormTitle.Location = new Point(244, 23);
            FormTitle.Name = "FormTitle";
            FormTitle.Size = new Size(344, 24);
            FormTitle.TabIndex = 0;
            FormTitle.Text = "Preparación para la Misión";
            // 
            // CityNameLabel
            // 
            CityNameLabel.AutoSize = true;
            CityNameLabel.Font = new Font("SimSun-ExtG", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CityNameLabel.ForeColor = Color.MediumSpringGreen;
            CityNameLabel.Location = new Point(86, 104);
            CityNameLabel.Name = "CityNameLabel";
            CityNameLabel.Size = new Size(75, 19);
            CityNameLabel.TabIndex = 1;
            CityNameLabel.Text = "Ciudad";
            // 
            // CityImage
            // 
            CityImage.Location = new Point(45, 130);
            CityImage.Name = "CityImage";
            CityImage.Size = new Size(261, 213);
            CityImage.SizeMode = PictureBoxSizeMode.Zoom;
            CityImage.TabIndex = 2;
            CityImage.TabStop = false;
            // 
            // CityPrev
            // 
            CityPrev.Image = Properties.Resources.FlechaBefore;
            CityPrev.Location = new Point(86, 370);
            CityPrev.Name = "CityPrev";
            CityPrev.Size = new Size(40, 30);
            CityPrev.SizeMode = PictureBoxSizeMode.Zoom;
            CityPrev.TabIndex = 3;
            CityPrev.TabStop = false;
            CityPrev.Click += CityPrev_Click;
            // 
            // CityCounter
            // 
            CityCounter.AutoSize = true;
            CityCounter.Font = new Font("SimSun-ExtG", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CityCounter.ForeColor = SystemColors.ButtonHighlight;
            CityCounter.Location = new Point(151, 376);
            CityCounter.Name = "CityCounter";
            CityCounter.Size = new Size(47, 16);
            CityCounter.TabIndex = 4;
            CityCounter.Text = "1 / 2";
            // 
            // CityNext
            // 
            CityNext.Image = Properties.Resources.FlechaNext;
            CityNext.Location = new Point(216, 370);
            CityNext.Name = "CityNext";
            CityNext.Size = new Size(40, 30);
            CityNext.SizeMode = PictureBoxSizeMode.Zoom;
            CityNext.TabIndex = 5;
            CityNext.TabStop = false;
            CityNext.Click += CityNext_Click;
            // 
            // RobotNameLabel
            // 
            RobotNameLabel.AutoSize = true;
            RobotNameLabel.Font = new Font("SimSun-ExtG", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RobotNameLabel.ForeColor = Color.DodgerBlue;
            RobotNameLabel.Location = new Point(402, 104);
            RobotNameLabel.Name = "RobotNameLabel";
            RobotNameLabel.Size = new Size(64, 19);
            RobotNameLabel.TabIndex = 6;
            RobotNameLabel.Text = "Robot";
            // 
            // RobotTypeLabel
            // 
            RobotTypeLabel.AutoSize = true;
            RobotTypeLabel.Font = new Font("SimSun-ExtG", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RobotTypeLabel.ForeColor = SystemColors.ButtonHighlight;
            RobotTypeLabel.Location = new Point(402, 129);
            RobotTypeLabel.Name = "RobotTypeLabel";
            RobotTypeLabel.Size = new Size(47, 15);
            RobotTypeLabel.TabIndex = 7;
            RobotTypeLabel.Text = "Tipo:";
            // 
            // RobotCapLabel
            // 
            RobotCapLabel.AutoSize = true;
            RobotCapLabel.Font = new Font("SimSun-ExtG", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RobotCapLabel.ForeColor = Color.Red;
            RobotCapLabel.Location = new Point(402, 149);
            RobotCapLabel.Name = "RobotCapLabel";
            RobotCapLabel.Size = new Size(87, 15);
            RobotCapLabel.TabIndex = 8;
            RobotCapLabel.Text = "Capacidad:";
            RobotCapLabel.Visible = false;
            // 
            // RobotImage
            // 
            RobotImage.Location = new Point(402, 175);
            RobotImage.Name = "RobotImage";
            RobotImage.Size = new Size(150, 150);
            RobotImage.SizeMode = PictureBoxSizeMode.Zoom;
            RobotImage.TabIndex = 9;
            RobotImage.TabStop = false;
            // 
            // RobotPrev
            // 
            RobotPrev.Image = Properties.Resources.FlechaBefore;
            RobotPrev.Location = new Point(401, 370);
            RobotPrev.Name = "RobotPrev";
            RobotPrev.Size = new Size(40, 30);
            RobotPrev.SizeMode = PictureBoxSizeMode.Zoom;
            RobotPrev.TabIndex = 10;
            RobotPrev.TabStop = false;
            RobotPrev.Click += RobotPrev_Click;
            // 
            // RobotCounter
            // 
            RobotCounter.AutoSize = true;
            RobotCounter.Font = new Font("SimSun-ExtG", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RobotCounter.ForeColor = SystemColors.ButtonHighlight;
            RobotCounter.Location = new Point(466, 376);
            RobotCounter.Name = "RobotCounter";
            RobotCounter.Size = new Size(47, 16);
            RobotCounter.TabIndex = 11;
            RobotCounter.Text = "1 / 5";
            // 
            // RobotNext
            // 
            RobotNext.Image = Properties.Resources.FlechaNext;
            RobotNext.Location = new Point(521, 370);
            RobotNext.Name = "RobotNext";
            RobotNext.Size = new Size(40, 30);
            RobotNext.SizeMode = PictureBoxSizeMode.Zoom;
            RobotNext.TabIndex = 12;
            RobotNext.TabStop = false;
            RobotNext.Click += RobotNext_Click;
            // 
            // DestTitleLabel
            // 
            DestTitleLabel.AutoSize = true;
            DestTitleLabel.Font = new Font("SimSun-ExtG", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DestTitleLabel.ForeColor = Color.MediumSpringGreen;
            DestTitleLabel.Location = new Point(643, 105);
            DestTitleLabel.Name = "DestTitleLabel";
            DestTitleLabel.Size = new Size(218, 18);
            DestTitleLabel.TabIndex = 13;
            DestTitleLabel.Text = "Destinos disponibles:";
            // 
            // DestComboBox
            // 
            DestComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DestComboBox.FlatStyle = FlatStyle.Flat;
            DestComboBox.Font = new Font("SimSun-ExtG", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DestComboBox.FormattingEnabled = true;
            DestComboBox.Location = new Point(638, 135);
            DestComboBox.Name = "DestComboBox";
            DestComboBox.Size = new Size(210, 23);
            DestComboBox.TabIndex = 14;
            DestComboBox.SelectedIndexChanged += DestComboBox_SelectedIndexChanged;
            // 
            // DestInfoLabel
            // 
            DestInfoLabel.AutoSize = true;
            DestInfoLabel.Font = new Font("SimSun-ExtG", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DestInfoLabel.ForeColor = SystemColors.ButtonHighlight;
            DestInfoLabel.Location = new Point(638, 186);
            DestInfoLabel.Name = "DestInfoLabel";
            DestInfoLabel.Size = new Size(111, 15);
            DestInfoLabel.TabIndex = 15;
            DestInfoLabel.Text = "Seleccionado:";
            // 
            // NoDestLabel
            // 
            NoDestLabel.AutoSize = true;
            NoDestLabel.Font = new Font("SimSun-ExtG", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoDestLabel.ForeColor = Color.Red;
            NoDestLabel.Location = new Point(638, 161);
            NoDestLabel.Name = "NoDestLabel";
            NoDestLabel.Size = new Size(223, 16);
            NoDestLabel.TabIndex = 16;
            NoDestLabel.Text = "Sin destinos disponibles";
            NoDestLabel.Visible = false;
            // 
            // ExitButton
            // 
            ExitButton.Image = Properties.Resources.salir;
            ExitButton.Location = new Point(12, 453);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(65, 52);
            ExitButton.SizeMode = PictureBoxSizeMode.Zoom;
            ExitButton.TabIndex = 17;
            ExitButton.TabStop = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // EjectMission
            // 
            EjectMission.Image = Properties.Resources.EjectMission;
            EjectMission.Location = new Point(678, 411);
            EjectMission.Name = "EjectMission";
            EjectMission.Size = new Size(206, 94);
            EjectMission.SizeMode = PictureBoxSizeMode.Zoom;
            EjectMission.TabIndex = 18;
            EjectMission.TabStop = false;
            EjectMission.Click += EjectMission_Click;
            // 
            // DestInfoLabel2
            // 
            DestInfoLabel2.AutoSize = true;
            DestInfoLabel2.Font = new Font("SimSun-ExtG", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DestInfoLabel2.ForeColor = SystemColors.ButtonHighlight;
            DestInfoLabel2.Location = new Point(638, 211);
            DestInfoLabel2.Name = "DestInfoLabel2";
            DestInfoLabel2.Size = new Size(111, 15);
            DestInfoLabel2.TabIndex = 19;
            DestInfoLabel2.Text = "Seleccionado:";
            // 
            // MissionPrepare
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(896, 517);
            Controls.Add(DestInfoLabel2);
            Controls.Add(EjectMission);
            Controls.Add(ExitButton);
            Controls.Add(NoDestLabel);
            Controls.Add(DestInfoLabel);
            Controls.Add(DestComboBox);
            Controls.Add(DestTitleLabel);
            Controls.Add(RobotNext);
            Controls.Add(RobotCounter);
            Controls.Add(RobotPrev);
            Controls.Add(RobotImage);
            Controls.Add(RobotCapLabel);
            Controls.Add(RobotTypeLabel);
            Controls.Add(RobotNameLabel);
            Controls.Add(CityNext);
            Controls.Add(CityCounter);
            Controls.Add(CityPrev);
            Controls.Add(CityImage);
            Controls.Add(CityNameLabel);
            Controls.Add(FormTitle);
            ForeColor = Color.White;
            Name = "MissionPrepare";
            Text = "MissionPrepare";
            ((System.ComponentModel.ISupportInitialize)CityImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)CityPrev).EndInit();
            ((System.ComponentModel.ISupportInitialize)CityNext).EndInit();
            ((System.ComponentModel.ISupportInitialize)RobotImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)RobotPrev).EndInit();
            ((System.ComponentModel.ISupportInitialize)RobotNext).EndInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)EjectMission).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FormTitle;
        private Label CityNameLabel;
        private PictureBox CityImage;
        private PictureBox CityPrev;
        private Label CityCounter;
        private PictureBox CityNext;
        private Label RobotNameLabel;
        private Label RobotTypeLabel;
        private Label RobotCapLabel;
        private PictureBox RobotImage;
        private PictureBox RobotPrev;
        private Label RobotCounter;
        private PictureBox RobotNext;
        private Label DestTitleLabel;
        private ComboBox DestComboBox;
        private Label DestInfoLabel;
        private Label NoDestLabel;
        private PictureBox ExitButton;
        private PictureBox EjectMission;
        private Label DestInfoLabel2;
    }
}
