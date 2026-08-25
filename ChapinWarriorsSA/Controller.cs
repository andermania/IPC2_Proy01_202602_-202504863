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
    }
}  
