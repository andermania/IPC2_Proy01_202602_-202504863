using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChapinWarriorsSA.Views
{
    public partial class FinalReport : Form
    {
        private Controller controller;
        private NavigationController navigationController;
        private MakeGraphiz graphviz;

        public FinalReport(Controller controller, NavigationController navigationController, MakeGraphiz graphviz)
        {
            InitializeComponent();
            this.controller = controller;
            this.navigationController = navigationController;
            this.graphviz = graphviz;
        }

        public void Setup(Mission mission)
        {
            // ---------- TITULO ----------
            if (mission.success)
            {
                TitleLabel.Text = "MISIÓN EXITOSA";
                TitleLabel.ForeColor = Color.SpringGreen;
            }
            else
            {
                TitleLabel.Text = "MISIÓN IMPOSIBLE";
                TitleLabel.ForeColor = Color.Red;
            }

            // ---------- CIUDAD ----------
            CityNameValue.Text = mission.city?.name ?? "---";

            if (mission.startCell != null)
            {
                StartValue.Text = "(" + mission.startCell.row + ", " + mission.startCell.column + ")";
            }
            else
            {
                StartValue.Text = "---";
            }

            if (mission.destination != null)
            {
                EndValue.Text = "(" + mission.destination.row + ", " + mission.destination.column + ")";
            }
            else
            {
                EndValue.Text = "---";
            }

            // Mapa de la ciudad con ruta (si hay) o sin ella.
            string png;
            if (mission.success && mission.route != null && mission.route.counter > 0)
            {
                string[] infoLines = new string[] { };
                png = graphviz.GenerarMapaMision(mission.city!, mission.route, infoLines);
            }
            else
            {
                png = graphviz.GenerarMapaCiudad(mission.city!);
            }

            Image? previous = CityMapImage.Image;
            CityMapImage.Image = MakeGraphiz.CargarImagen(png);
            previous?.Dispose();

            FitMapImage();

            // ---------- ROBOT ----------
            RobotNameValue.Text = mission.robot?.name ?? "---";
            RobotTypeValue.Text = mission.robot is ChapinFighter ? "Tipo: ChapinFighter" : "Tipo: ChapinRescue";
            RobotImage.Image = mission.robot is ChapinFighter
                ? Properties.Resources.ChapinFighter
                : Properties.Resources.ChapinRescue;

            // ---------- REPORTE DE COMBATE (solo fighter) ----------
            if (mission.robot is ChapinFighter)
            {
                RobotCapInitValue.Visible = true;
                RobotCapInitValue.Text = "Capacidad inicial: " + mission.robotInitialHealth;

                StringBuilder report = new StringBuilder();
                foreach (BaseBattleRecord battle in mission.battles)
                {
                    report.AppendLine("Base (" + battle.row + "x" + battle.column + "): " +
                        (battle.destroyed ? "Destruida" : "No Destruida") +
                        (battle.destroyed ? "     Daño: " + battle.damage : ""));
                    report.AppendLine();
                }
                ReportLabel.Text = report.ToString();

                RobotFinalCapValue.Visible = true;
                RobotFinalCapValue.Text = "Capacidad de combate final: " + mission.robotFinalHealth;
            }
            else
            {
                RobotCapInitValue.Visible = false;
                ReportLabel.Text = "";
                RobotFinalCapValue.Visible = false;
            }
        }

        // Ajusta el tamaño del PictureBox del mapa para que la imagen cuadre al area
        // destinada (a la izquierda, junto a la columna del robot), manteniendo la
        // proporcion original y sin recortar ni deformar.
        private void FitMapImage()
        {
            if (CityMapImage.Image == null)
            {
                return;
            }

            Image img = CityMapImage.Image;
            CityMapImage.SuspendLayout();

            // Espacio maximo disponible para el mapa dentro del form.
            int maxW = 430;
            int maxH = 280;

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

            // Centrar el mapa en el area disponible (izquierda, junto a la columna del robot).
            int areaLeft = 45;
            int areaTop = 145;
            int areaW = 400;
            int areaH = 300;
            int posX = areaLeft + (areaW - newW) / 2;
            int posY = areaTop + (areaH - newH) / 2;
            if (posX < areaLeft) posX = areaLeft;
            if (posY < areaTop) posY = areaTop;
            CityMapImage.Location = new Point(posX, posY);
            CityMapImage.ResumeLayout();
        }

        private void ExitButton_Click(object? sender, EventArgs e)
        {
            navigationController.UserQuery();
        }
    }
}
