using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChapinWarriorsSA
{
    internal class GameData
    {
        public DynamicList<City> Cities = new DynamicList<City>();
        public DynamicList<Robot> Robots = new DynamicList<Robot>();
        public DynamicList<Mission> Missions = new DynamicList<Mission>();

        public void SaveLists(DynamicList<City> cities, DynamicList<Robot> robots)
        {
            this.Cities = cities;
            this.Robots = robots;
            //ImprimirCiudades(cities);
        }

        public void ImprimirCiudades(DynamicList<City> cities)
        {
            foreach (City city in cities)
            {
                ImprimirCiudad(city);
                Debug.WriteLine("");
            }
        }

        private void ImprimirCiudad(City city)
        {
            Debug.WriteLine("Ciudad: " + city.name);
            Debug.WriteLine("Filas: " + city.rows + "   Columnas: " + city.columns);
            Debug.WriteLine("");

            ImprimirMatriz(city);
        }

        private void ImprimirMatriz(City city)
        {
            // encabezado de columnas
            string encabezado = "    ";
            for (int c = 1; c <= city.columns; c++)
            {
                encabezado += c.ToString().PadLeft(3);
            }
            Debug.WriteLine(encabezado);

            for (int r = 0; r < city.rows; r++)
            {
                string linea = (r + 1).ToString().PadLeft(3) + " ";

                for (int c = 0; c < city.columns; c++)
                {
                    Cell cell = city.mapMatrix[r][c];
                    char simbolo = CellTypeASimbolo(cell.cell);
                    linea += " " + simbolo + " ";
                }

                Debug.WriteLine(linea);
            }
        }

        private char CellTypeASimbolo(CellType tipo)
        {
            switch (tipo)
            {
                case CellType.Blocked: return '*';
                case CellType.Path: return '.';
                case CellType.Entry: return 'E';
                case CellType.Civil: return 'C';
                case CellType.Resource: return 'R';
                case CellType.Military: return 'M';
                default: return '?';
            }
        }

    }
}
