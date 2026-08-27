using System;
using System.Collections.Generic;
using System.Text;

namespace ChapinWarriorsSA
{
    public class Controller
    {
        internal GameData data;
        internal XMLReader xml;

        internal Controller(GameData data, XMLReader xml)
        {
            this.data = data;
            this.xml = xml;
        }
        internal void ReadCities()
        {
            String path = "C:\\Users\\kevin\\source\\repos\\ChapinWarriorsSA\\ChapinWarriorsSA\\XMLdocument.xml";
            DynamicList<City> cities = xml.ReadCities(path);
            DynamicList<Robot> robots = xml.ReadRobots(path);
            data.SaveLists(cities, robots); 
        }

        internal int GetCityCount() => data.Cities.counter;
        internal int GetRobotCount() => data.Robots.counter;
        internal int GetMissionCount() => data.Missions.counter;
        internal City GetCity(int index) => data.Cities.GetElement(index);
        internal Robot GetRobot(int index) => data.Robots.GetElement(index);

        internal DynamicList<Robot> GetFilteredRobots(Type robotType)
        {
            DynamicList<Robot> filtered = new DynamicList<Robot>();
            foreach (Robot r in data.Robots)
            {
                if (r.GetType() == robotType)
                {
                    filtered.Add(r);
                }
            }
            return filtered;
        }

        internal DynamicList<Robot> GetAllRobotsOrdered()
        {
            DynamicList<Robot> ordered = new DynamicList<Robot>();
            foreach (Robot r in data.Robots)
            {
                if (r is ChapinRescue)
                {
                    ordered.Add(r);
                }
            }
            foreach (Robot r in data.Robots)
            {
                if (r is ChapinFighter)
                {
                    ordered.Add(r);
                }
            }
            return ordered;
        }

        internal DynamicList<Cell> GetDestinations(City city, Type robotType)
        {
            DynamicList<Cell> destinations = new DynamicList<Cell>();
            for (int r = 0; r < city.rows; r++)
            {
                for (int c = 0; c < city.columns; c++)
                {
                    Cell cell = city.mapMatrix[r][c];
                    if (robotType == typeof(ChapinRescue) && cell.cell == CellType.Civil)
                    {
                        destinations.Add(cell);
                    }
                    else if (robotType == typeof(ChapinFighter) && cell.cell == CellType.Resource)
                    {
                        destinations.Add(cell);
                    }
                }
            }
            return destinations;
        }
    }
}  
