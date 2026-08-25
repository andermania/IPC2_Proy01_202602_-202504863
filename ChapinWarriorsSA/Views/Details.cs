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
    public partial class Details : Form
    {
        public Controller controller;
        public NavigationController navigationController;
        public MakeGraphiz graphviz;

        int CitiesNum;
        int CityNum;
        public Details(Controller controller, NavigationController navigationController, MakeGraphiz graphviz)
        {
            InitializeComponent();
            this.controller = controller;
            this.navigationController = navigationController;
            this.graphviz = graphviz;
        }

        public void SetCityDetails()
        {
            CitiesNum = controller.GetCityCount();
            Title.Text = "Ciudades Escaneadas: " + CitiesNum;
            CityNum = 1;
            ChangeCity();
        }

        private void ChangeCity()
        {
            Number.Text = "Ciudad #" + CityNum;
            Debug.WriteLine("Hola");
            City city = controller.GetCity(CityNum);
            theName.Text = city.name;
            theDimension.Text = city.rows + " x " + city.columns;
            theEntries.Text = city.entries.ToString();
            theMilitary.Text = city.military.ToString();
            theCivilies.Text = city.civilian.ToString();
            theResources.Text = city.resources.ToString();
            string png = graphviz.GenerarMapaCiudad(city);
            Image? imagenAnterior = Graphiz.Image;
            Graphiz.Image = MakeGraphiz.CargarImagen(png);
            imagenAnterior?.Dispose();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            CityNum++;
            Debug.WriteLine(CityNum);
            if (CityNum > CitiesNum)
            {
                CityNum = 1;
            }
            ChangeCity();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            CityNum--;
            if (CityNum < 1)
            {
                CityNum = CitiesNum;
            }
            ChangeCity();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            navigationController.UserQuery();
        }
    }
}
