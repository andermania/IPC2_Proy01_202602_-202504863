using System;

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
        }
    }
}
