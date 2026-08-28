namespace ChapinWarriorsSA.Views
{
    partial class FinalReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            TitleLabel = new Label();
            CityTitle = new Label();
            CityNameValue = new Label();
            StartTitle = new Label();
            StartValue = new Label();
            EndTitle = new Label();
            EndValue = new Label();
            CityMapImage = new PictureBox();
            RobotTitle = new Label();
            RobotNameValue = new Label();
            RobotTypeValue = new Label();
            RobotCapInitValue = new Label();
            ReportLabel = new Label();
            RobotFinalCapValue = new Label();
            RobotImage = new PictureBox();
            ExitButton = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CityMapImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RobotImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).BeginInit();
            SuspendLayout();
            //
            // TitleLabel
            //
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("SimSun-ExtG", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = Color.SpringGreen;
            TitleLabel.Location = new Point(260, 15);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(300, 29);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "MISIÓN EXITOSA";
            //
            // CityTitle
            //
            CityTitle.AutoSize = true;
            CityTitle.Font = new Font("SimSun-ExtG", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CityTitle.ForeColor = Color.MediumSpringGreen;
            CityTitle.Location = new Point(45, 60);
            CityTitle.Name = "CityTitle";
            CityTitle.Size = new Size(70, 19);
            CityTitle.TabIndex = 1;
            CityTitle.Text = "Ciudad:";
            //
            // CityNameValue
            //
            CityNameValue.AutoSize = true;
            CityNameValue.Font = new Font("SimSun-ExtG", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CityNameValue.ForeColor = SystemColors.ButtonHighlight;
            CityNameValue.Location = new Point(140, 60);
            CityNameValue.Name = "CityNameValue";
            CityNameValue.Size = new Size(100, 19);
            CityNameValue.TabIndex = 2;
            CityNameValue.Text = "---";
            //
            // StartTitle
            //
            StartTitle.AutoSize = true;
            StartTitle.Font = new Font("SimSun-ExtG", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartTitle.ForeColor = SystemColors.ButtonHighlight;
            StartTitle.Location = new Point(45, 90);
            StartTitle.Name = "StartTitle";
            StartTitle.Size = new Size(110, 16);
            StartTitle.TabIndex = 3;
            StartTitle.Text = "Punto de salida:";
            //
            // StartValue
            //
            StartValue.AutoSize = true;
            StartValue.Font = new Font("SimSun-ExtG", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartValue.ForeColor = SystemColors.ButtonHighlight;
            StartValue.Location = new Point(175, 90);
            StartValue.Name = "StartValue";
            StartValue.Size = new Size(60, 16);
            StartValue.TabIndex = 4;
            StartValue.Text = "---";
            //
            // EndTitle
            //
            EndTitle.AutoSize = true;
            EndTitle.Font = new Font("SimSun-ExtG", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndTitle.ForeColor = SystemColors.ButtonHighlight;
            EndTitle.Location = new Point(45, 115);
            EndTitle.Name = "EndTitle";
            EndTitle.Size = new Size(110, 16);
            EndTitle.TabIndex = 5;
            EndTitle.Text = "Punto final:";
            //
            // EndValue
            //
            EndValue.AutoSize = true;
            EndValue.Font = new Font("SimSun-ExtG", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndValue.ForeColor = SystemColors.ButtonHighlight;
            EndValue.Location = new Point(175, 115);
            EndValue.Name = "EndValue";
            EndValue.Size = new Size(60, 16);
            EndValue.TabIndex = 6;
            EndValue.Text = "---";
            //
            // CityMapImage
            //
            CityMapImage.Location = new Point(45, 145);
            CityMapImage.Name = "CityMapImage";
            CityMapImage.Size = new Size(400, 300);
            CityMapImage.SizeMode = PictureBoxSizeMode.Zoom;
            CityMapImage.TabIndex = 7;
            CityMapImage.TabStop = false;
            //
            // RobotTitle
            //
            RobotTitle.AutoSize = true;
            RobotTitle.Font = new Font("SimSun-ExtG", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RobotTitle.ForeColor = Color.DodgerBlue;
            RobotTitle.Location = new Point(500, 60);
            RobotTitle.Name = "RobotTitle";
            RobotTitle.Size = new Size(65, 19);
            RobotTitle.TabIndex = 8;
            RobotTitle.Text = "Robot:";
            //
            // RobotNameValue
            //
            RobotNameValue.AutoSize = true;
            RobotNameValue.Font = new Font("SimSun-ExtG", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RobotNameValue.ForeColor = SystemColors.ButtonHighlight;
            RobotNameValue.Location = new Point(595, 60);
            RobotNameValue.Name = "RobotNameValue";
            RobotNameValue.Size = new Size(100, 19);
            RobotNameValue.TabIndex = 9;
            RobotNameValue.Text = "---";
            //
            // RobotTypeValue
            //
            RobotTypeValue.AutoSize = true;
            RobotTypeValue.Font = new Font("SimSun-ExtG", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RobotTypeValue.ForeColor = SystemColors.ButtonHighlight;
            RobotTypeValue.Location = new Point(500, 90);
            RobotTypeValue.Name = "RobotTypeValue";
            RobotTypeValue.Size = new Size(120, 16);
            RobotTypeValue.TabIndex = 10;
            RobotTypeValue.Text = "Tipo: ---";
            //
            // RobotCapInitValue
            //
            RobotCapInitValue.AutoSize = true;
            RobotCapInitValue.Font = new Font("SimSun-ExtG", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RobotCapInitValue.ForeColor = SystemColors.ButtonHighlight;
            RobotCapInitValue.Location = new Point(500, 115);
            RobotCapInitValue.Name = "RobotCapInitValue";
            RobotCapInitValue.Size = new Size(150, 16);
            RobotCapInitValue.TabIndex = 11;
            RobotCapInitValue.Text = "Capacidad inicial: ---";
            RobotCapInitValue.Visible = false;
            //
            // ReportLabel
            //
            ReportLabel.AutoSize = true;
            ReportLabel.Font = new Font("SimSun-ExtG", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReportLabel.ForeColor = SystemColors.ButtonHighlight;
            ReportLabel.Location = new Point(500, 145);
            ReportLabel.MaximumSize = new Size(360, 0);
            ReportLabel.Name = "ReportLabel";
            ReportLabel.Size = new Size(360, 0);
            ReportLabel.TabIndex = 12;
            ReportLabel.Text = "";
            //
            // RobotFinalCapValue
            //
            RobotFinalCapValue.AutoSize = true;
            RobotFinalCapValue.Font = new Font("SimSun-ExtG", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RobotFinalCapValue.ForeColor = Color.Orange;
            RobotFinalCapValue.Location = new Point(500, 350);
            RobotFinalCapValue.Name = "RobotFinalCapValue";
            RobotFinalCapValue.Size = new Size(200, 16);
            RobotFinalCapValue.TabIndex = 13;
            RobotFinalCapValue.Text = "Capacidad de combate final: ---";
            RobotFinalCapValue.Visible = false;
            //
            // RobotImage
            //
            RobotImage.Location = new Point(595, 380);
            RobotImage.Name = "RobotImage";
            RobotImage.Size = new Size(150, 100);
            RobotImage.SizeMode = PictureBoxSizeMode.Zoom;
            RobotImage.TabIndex = 14;
            RobotImage.TabStop = false;
            //
            // ExitButton
            //
            ExitButton.Image = Properties.Resources.salir;
            ExitButton.Location = new Point(12, 440);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(65, 52);
            ExitButton.SizeMode = PictureBoxSizeMode.Zoom;
            ExitButton.TabIndex = 15;
            ExitButton.TabStop = false;
            ExitButton.Click += ExitButton_Click;
            //
            // FinalReport
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(896, 517);
            Controls.Add(ExitButton);
            Controls.Add(RobotImage);
            Controls.Add(RobotFinalCapValue);
            Controls.Add(ReportLabel);
            Controls.Add(RobotCapInitValue);
            Controls.Add(RobotTypeValue);
            Controls.Add(RobotNameValue);
            Controls.Add(RobotTitle);
            Controls.Add(CityMapImage);
            Controls.Add(EndValue);
            Controls.Add(EndTitle);
            Controls.Add(StartValue);
            Controls.Add(StartTitle);
            Controls.Add(CityNameValue);
            Controls.Add(CityTitle);
            Controls.Add(TitleLabel);
            ForeColor = Color.White;
            Name = "FinalReport";
            Text = "FinalReport";
            ((System.ComponentModel.ISupportInitialize)CityMapImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)RobotImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)ExitButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label CityTitle;
        private Label CityNameValue;
        private Label StartTitle;
        private Label StartValue;
        private Label EndTitle;
        private Label EndValue;
        private PictureBox CityMapImage;
        private Label RobotTitle;
        private Label RobotNameValue;
        private Label RobotTypeValue;
        private Label RobotCapInitValue;
        private Label ReportLabel;
        private Label RobotFinalCapValue;
        private PictureBox RobotImage;
        private PictureBox ExitButton;
    }
}
