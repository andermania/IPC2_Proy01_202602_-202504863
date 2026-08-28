namespace ChapinWarriorsSA
{
    public class Cell
    {
        public int row;
        public int column;
        public CellType cell;
        public int combatCapacity;

        public Cell(int row, int column, CellType cell)
        {
            this.row = row;
            this.column = column;
            this.cell = cell;
            this.combatCapacity = 0;
        }
    }
}
