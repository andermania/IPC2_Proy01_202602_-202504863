using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChapinWarriorsSA.Views
{
    public partial class History : Form
    {
        private Controller controller;
        private NavigationController navigationController;
        private MakeGraphiz graphviz;

        private int currentIndex;
        private int currentCount;

        public History(Controller controller, NavigationController navigationController, MakeGraphiz graphviz)
        {
            InitializeComponent();
            this.controller = controller;
            this.navigationController = navigationController;
            this.graphviz = graphviz;
        }

        public void Setup()
        {
            currentCount = controller.GetMissionCount();

            if (currentCount == 0)
            {
                TitleLabel.Text = "SIN MISIONES";
                TitleLabel.ForeColor = Color.Red;
                MissionNumberLabel.Text = "Misión #0";
                CityNameValue.Text = "---";
                StartValue.Text = "---";
                EndValue.Text = "---";
                RobotNameValue.Text = "---";
                RobotTypeValue.Text = "Tipo: ---";
                RobotCapInitValue.Visible = false;
                ReportLabel.Text = "";
                RobotFinalCapValue.Visible = false;

                if (CityMapImage.Image != null)
                {
                    Image old = CityMapImage.Image;
                    CityMapImage.Image = null;
                    old.Dispose();
                }
                RobotImage.Image = null;
                PreviousButton.Enabled = false;
                NextButton.Enabled = false;
                return;
            }

            currentIndex = 1;
            PreviousButton.Enabled = true;
            NextButton.Enabled = true;
            ShowCurrentMission();
        }

        private void ShowCurrentMission()
        {
            Mission mission = controller.GetMission(currentIndex);
            MissionRenderData d = MissionRenderer.Render(mission, graphviz);

            MissionNumberLabel.Text = "Misión #" + currentIndex;
            TitleLabel.Text = d.title;
            TitleLabel.ForeColor = d.titleColor;

            CityNameValue.Text = d.cityName;
            StartValue.Text = d.start;
            EndValue.Text = d.end;

            Image? previous = CityMapImage.Image;
            CityMapImage.Image = MakeGraphiz.CargarImagen(d.mapPng);
            previous?.Dispose();

            FitMapImage();

            RobotNameValue.Text = d.robotName;
            RobotTypeValue.Text = d.robotType;
            RobotImage.Image = d.robotImage;

            RobotCapInitValue.Visible = d.capInitVisible;
            RobotCapInitValue.Text = d.capInit;
            ReportLabel.Text = d.report;
            RobotFinalCapValue.Visible = d.capFinalVisible;
            RobotFinalCapValue.Text = d.capFinal;
        }

        // Ajusta el tamaño del PictureBox del mapa para que la imagen cuadre al area
        // destinada, manteniendo la proporcion original y sin recortar ni deformar.
        private void FitMapImage()
        {
            if (CityMapImage.Image == null)
            {
                return;
            }

            Image img = CityMapImage.Image;
            CityMapImage.SuspendLayout();

            int maxW = 300;
            int maxH = 150;

            int imgW = img.Width;
            int imgH = img.Height;
            if (imgW < 1 || imgH < 1)
            {
                CityMapImage.Size = new Size(maxW, maxH);
                CityMapImage.ResumeLayout();
                return;
            }

            float scale = Math.Min((float)maxW / imgW, (float)maxH / imgH);
            int newW = (int)Math.Round(imgW * scale);
            int newH = (int)Math.Round(imgH * scale);
            if (newW < 1) newW = 1;
            if (newH < 1) newH = 1;

            CityMapImage.SizeMode = PictureBoxSizeMode.Zoom;
            CityMapImage.Size = new Size(newW, newH);

            int areaLeft = 45;
            int areaTop = 145;
            int areaW = 300;
            int areaH = 150;
            int posX = areaLeft + (areaW - newW) / 2;
            int posY = areaTop + (areaH - newH) / 2;
            if (posX < areaLeft) posX = areaLeft;
            if (posY < areaTop) posY = areaTop;
            CityMapImage.Location = new Point(posX, posY);
            CityMapImage.ResumeLayout();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (currentCount == 0)
            {
                return;
            }
            currentIndex++;
            if (currentIndex > currentCount)
            {
                currentIndex = 1;
            }
            ShowCurrentMission();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (currentCount == 0)
            {
                return;
            }
            currentIndex--;
            if (currentIndex < 1)
            {
                currentIndex = currentCount;
            }
            ShowCurrentMission();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            navigationController.UserQuery();
        }
    }
}
