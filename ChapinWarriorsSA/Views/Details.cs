using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChapinWarriorsSA.Views
{
    public partial class Details : Form
    {
        public Controller controller;
        public NavigationController navigationController;
        public MakeGraphiz graphviz;

        private Entity CurrentType;
        private int currentIndex;
        private int currentCount;
        private DynamicList<Robot>? filteredRobots;

        public Details(Controller controller, NavigationController navigationController, MakeGraphiz graphviz)
        {
            InitializeComponent();
            this.controller = controller;
            this.navigationController = navigationController;
            this.graphviz = graphviz;
        }

        public void Setup(Entity type, DynamicList<Robot>? filteredRobots)
        {
            CurrentType = type;

            switch (type)
            {
                case Entity.City:
                    filteredRobots = null;
                    currentCount = controller.GetCityCount();
                    currentIndex = 1;
                    SetupCity(controller.GetCity(currentIndex));
                    break;

                case Entity.Robot:
                    this.filteredRobots = filteredRobots;
                    currentCount = filteredRobots?.counter ?? controller.GetRobotCount();
                    currentIndex = 1;
                    SetupRobot(GetCurrentRobot());
                    break;
            }
        }

        // -------------------- CITY --------------------

        private void SetupCity(City city)
        {
            Title.Text = "Ciudades Escaneadas: " + currentCount;
            Number.Text = "Ciudad #" + currentIndex;

            string png = graphviz.GenerarMapaCiudad(city);
            Image? imagenAnterior = ItemImage.Image;
            ItemImage.Image = MakeGraphiz.CargarImagen(png);
            imagenAnterior?.Dispose();

            SetField(1, "Nombre:", city.name);
            SetField(2, "Dimensión:", city.rows + " x " + city.columns);
            SetField(3, "Entradas:", city.entries.ToString());
            SetField(4, "Militares:", city.military.ToString());
            SetField(5, "Civiles:", city.civilian.ToString());
            SetField(6, "Recursos:", city.resources.ToString());

            ShowFields(6);
        }

        // -------------------- ROBOT --------------------

        private void SetupRobot(Robot robot)
        {
            Title.Text = "Robots Escaneados: " + currentCount;
            Number.Text = "Robot #" + currentIndex;

            if (robot is ChapinFighter fighter)
            {
                ItemImage.Image = Properties.Resources.ChapinFighter;
                SetField(1, "Nombre:", fighter.name);
                SetField(2, "Tipo:", "ChapinFighter");
                SetField(3, "Capacidad:", fighter.combatCapacity.ToString());
                ShowFields(3);
            }
            else if (robot is ChapinRescue rescue)
            {
                ItemImage.Image = Properties.Resources.ChapinRescue;
                SetField(1, "Nombre:", rescue.name);
                SetField(2, "Tipo:", "ChapinRescue");
                ShowFields(2);
            }
        }

        // -------------------- HELPERS --------------------

        private void SetField(int num, string labelText, string valueText)
        {
            switch (num)
            {
                case 1: FieldName1.Text = labelText; FieldValue1.Text = valueText; break;
                case 2: FieldName2.Text = labelText; FieldValue2.Text = valueText; break;
                case 3: FieldName3.Text = labelText; FieldValue3.Text = valueText; break;
                case 4: FieldName4.Text = labelText; FieldValue4.Text = valueText; break;
                case 5: FieldName5.Text = labelText; FieldValue5.Text = valueText; break;
                case 6: FieldName6.Text = labelText; FieldValue6.Text = valueText; break;
            }
        }

        private void ShowFields(int count)
        {
            FieldName1.Visible = count >= 1; FieldValue1.Visible = count >= 1;
            FieldName2.Visible = count >= 2; FieldValue2.Visible = count >= 2;
            FieldName3.Visible = count >= 3; FieldValue3.Visible = count >= 3;
            FieldName4.Visible = count >= 4; FieldValue4.Visible = count >= 4;
            FieldName5.Visible = count >= 5; FieldValue5.Visible = count >= 5;
            FieldName6.Visible = count >= 6; FieldValue6.Visible = count >= 6;
        }

        private void ChangeItem()
        {
            switch (CurrentType)
            {
                case Entity.City:
                    SetupCity(controller.GetCity(currentIndex));
                    break;
                case Entity.Robot:
                    SetupRobot(GetCurrentRobot());
                    break;
            }
        }

        private Robot GetCurrentRobot()
        {
            if (filteredRobots != null)
            {
                return filteredRobots.GetElement(currentIndex);
            }
            return controller.GetRobot(currentIndex);
        }

        // -------------------- NAVIGATION --------------------

        private void NextButton_Click(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex > currentCount)
            {
                currentIndex = 1;
            }
            ChangeItem();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 1)
            {
                currentIndex = currentCount;
            }
            ChangeItem();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            navigationController.UserQuery();
        }
    }
}
