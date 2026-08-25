using System;
using System.Collections.Generic;
using System.Text;

namespace ChapinWarriorsSA
{
    internal class Mission
    {
        public City? city = null;
        public Robot? robot = null;
        public Cell? destination = null;
        public DynamicList<Cell>? route = null;
    }
}
