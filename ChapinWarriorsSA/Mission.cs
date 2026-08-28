using System;
using System.Collections.Generic;
using System.Text;

namespace ChapinWarriorsSA
{
    public class BaseBattleRecord
    {
        public int row;
        public int column;
        public int baseCapacity;
        public bool destroyed;
        public int damage;
    }

    public class Mission
    {
        public City? city = null;
        public Robot? robot = null;
        public Cell? destination = null;
        public DynamicList<Cell>? route = null;
        public Cell? startCell = null;
        public bool success = false;
        public int robotInitialHealth = 0;
        public int robotFinalHealth = 0;
        public DynamicList<BaseBattleRecord> battles = new DynamicList<BaseBattleRecord>();
    }
}
