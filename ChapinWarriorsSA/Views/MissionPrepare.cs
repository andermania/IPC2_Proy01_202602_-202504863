using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChapinWarriorsSA.Views
{
    public partial class MissionPrepare : Form
    {
        private Controller controller;
        private NavigationController navigationController;
        private MakeGraphiz graphviz;

        private DynamicList<City> cities = null!;
        private DynamicList<Robot> allRobots = null!;
        private DynamicList<Cell> currentDestinations = null!;

        private int cityIndex;
        private int robotIndex;

        public MissionPrepare(Controller controller, NavigationController navigationController, MakeGraphiz graphviz)
        {
            InitializeComponent();
            this.controller = controller;
            this.navigationController = navigationController;
            this.graphviz = graphviz;
        }

        public void Setup()
        {
            cities = GetAllCities();
            allRobots = controller.GetAllRobotsOrdered();

            cityIndex = 1;
            robotIndex = 1;

            UpdateCity();
            UpdateRobot();
            UpdateDestinationsList();
        }

        // -------------------- DATA --------------------

        private DynamicList<City> GetAllCities()
        {
            DynamicList<City> result = new DynamicList<City>();
            for (int i = 1; i <= controller.GetCityCount(); i++)
            {
                result.Add(controller.GetCity(i));
            }
            return result;
        }

        // -------------------- CITY --------------------

        private void UpdateCity()
        {
            City city = cities.GetElement(cityIndex);
            CityNameLabel.Text = city.name;
            CityCounter.Text = cityIndex + " / " + cities.counter;

            string png = graphviz.GenerarMapaCiudad(city);
            Image? previous = CityImage.Image;
            CityImage.Image = MakeGraphiz.CargarImagen(png);
            previous?.Dispose();

            UpdateDestinationsList();
        }

        private void CityPrev_Click(object? sender, EventArgs e)
        {
            cityIndex--;
            if (cityIndex < 1)
            {
                cityIndex = cities.counter;
            }
            UpdateCity();
        }

        private void CityNext_Click(object? sender, EventArgs e)
        {
            cityIndex++;
            if (cityIndex > cities.counter)
            {
                cityIndex = 1;
            }
            UpdateCity();
        }

        // -------------------- ROBOT --------------------

        private void UpdateRobot()
        {
            Robot robot = allRobots.GetElement(robotIndex);
            RobotNameLabel.Text = robot.name;
            RobotCounter.Text = robotIndex + " / " + allRobots.counter;

            if (robot is ChapinFighter fighter)
            {
                RobotTypeLabel.Text = "Tipo: ChapinFighter";
                RobotCapLabel.Text = "Capacidad: " + fighter.combatCapacity;
                RobotCapLabel.Visible = true;
                RobotImage.Image = Properties.Resources.ChapinFighter;
            }
            else if (robot is ChapinRescue)
            {
                RobotTypeLabel.Text = "Tipo: ChapinRescue";
                RobotCapLabel.Visible = false;
                RobotImage.Image = Properties.Resources.ChapinRescue;
            }

            UpdateDestinationsList();
        }

        private void RobotPrev_Click(object? sender, EventArgs e)
        {
            robotIndex--;
            if (robotIndex < 1)
            {
                robotIndex = allRobots.counter;
            }
            UpdateRobot();
        }

        private void RobotNext_Click(object? sender, EventArgs e)
        {
            robotIndex++;
            if (robotIndex > allRobots.counter)
            {
                robotIndex = 1;
            }
            UpdateRobot();
        }

        // -------------------- DESTINATION --------------------

        private void UpdateDestinationsList()
        {
            City city = cities.GetElement(cityIndex);
            Robot robot = allRobots.GetElement(robotIndex);

            currentDestinations = controller.GetDestinations(city, robot.GetType());

            DestComboBox.Items.Clear();

            if (currentDestinations.counter == 0)
            {
                DestComboBox.Visible = false;
                DestInfoLabel.Visible = false;
                DestInfoLabel2.Visible = false;
                NoDestLabel.Visible = true;
                EjectMission.Enabled = false;
                return;
            }

            NoDestLabel.Visible = false;
            DestComboBox.Visible = true;
            DestInfoLabel.Visible = true;
            DestInfoLabel2.Visible = true;
            EjectMission.Enabled = true;

            for (int i = 1; i <= currentDestinations.counter; i++)
            {
                Cell cell = currentDestinations.GetElement(i);
                string tipo = cell.cell == CellType.Civil ? "Civil" : "Resource";
                DestComboBox.Items.Add("Fila " + cell.row + ", Columna " + cell.column + " (" + tipo + ")");
            }

            DestComboBox.SelectedIndex = 0;
        }

        private void DestComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (DestComboBox.SelectedIndex >= 0)
            {
                // El ComboBox es 0-based, pero DynamicList es 1-based -> sumo 1.
                Cell selected = currentDestinations.GetElement(DestComboBox.SelectedIndex + 1);
                string tipo = selected.cell == CellType.Civil ? "Civil" : "Resource";
                DestInfoLabel.Text = "Seleccionado:";
                DestInfoLabel2.Text = "Fila " + selected.row + ", Columna " + selected.column + " - " + tipo;
            }
        }

        // -------------------- PUBLIC GETTERS --------------------

        public City SelectedCity => cities.GetElement(cityIndex);
        public Robot SelectedRobot => allRobots.GetElement(robotIndex);
        public Cell SelectedDestination
        {
            get
            {
                if (DestComboBox.SelectedIndex >= 0)
                {
                    return currentDestinations.GetElement(DestComboBox.SelectedIndex + 1);
                }
                return null!;
            }
        }

        // -------------------- BUTTONS --------------------

        private void ExitButton_Click(object? sender, EventArgs e)
        {
            navigationController.UserQuery();
        }

        private void EjectMission_Click(object? sender, EventArgs e)
        {
            City city = SelectedCity;
            Robot robot = SelectedRobot;
            Cell destination = SelectedDestination;

            Mission mission = controller.ExecuteMission(city, robot, destination);
            navigationController.FinalReportView(mission);
        }
    }
}
