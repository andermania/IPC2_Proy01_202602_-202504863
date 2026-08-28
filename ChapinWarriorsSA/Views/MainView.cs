using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChapinWarriorsSA.Views
{
    public partial class MainView : Form
    {
        public Controller controller;
        public NavigationController navigationController;

        public MainView(Controller controller, NavigationController navigationController)
        {
            InitializeComponent();
            this.controller = controller;
            this.navigationController = navigationController;
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            controller.ReadCities();
            navigationController.UserQuery();
        }
    }
}
