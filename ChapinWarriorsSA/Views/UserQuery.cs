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
    }
}
