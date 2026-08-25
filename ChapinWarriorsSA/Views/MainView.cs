using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
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
            Debug.WriteLine("Hola");
            controller.ReadCities();
            navigationController.UserQuery();
            Debug.WriteLine("Hola2");
        }
    }
}
