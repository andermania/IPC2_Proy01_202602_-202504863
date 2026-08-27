using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChapinWarriorsSA.Views
{
    public partial class UserQuery : Form
    {
        public Controller controller;
        public NavigationController navigationController;
        public UserQuery(Controller controller, NavigationController navigationController)
        {
            InitializeComponent();
            this.controller = controller;
            this.navigationController = navigationController;
        }

        private void exitGame_Click(object sender, EventArgs e)
        {
            navigationController.Start();
        }

        private void ciudades_Click(object sender, EventArgs e)
        {
            navigationController.Details(Entity.City);
        }

        private void chapinRescue_Click(object sender, EventArgs e)
        {
            DynamicList<Robot> rescueRobots = controller.GetFilteredRobots(typeof(ChapinRescue));
            navigationController.Details(Entity.Robot, rescueRobots);
        }

        private void chapinFighter_Click(object sender, EventArgs e)
        {
            DynamicList<Robot> fighterRobots = controller.GetFilteredRobots(typeof(ChapinFighter));
            navigationController.Details(Entity.Robot, fighterRobots);
        }

        private void mission_Click(object sender, EventArgs e)
        {
            navigationController.MissionPrepare();
        }
    }
}
