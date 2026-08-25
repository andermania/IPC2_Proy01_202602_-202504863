using System;
using System.Collections.Generic;
using System.Text;

namespace ChapinWarriorsSA
{
    public class City
    {
        public String name;
        public int rows;
        public int columns;
        public int entries;
        public int military;
        public int civilian;
        public int resources;
        public Cell[][] mapMatrix;

        public City(string name, int rows, int columns, int entries, int military, int civilian, int resources, Cell[][] mapMatrix)
        {
            this.name = name;
            this.rows = rows;
            this.columns = columns;
            this.entries = entries;
            this.military = military;
            this.civilian = civilian;
            this.resources = resources;
            this.mapMatrix = mapMatrix;
        }
    }
}
