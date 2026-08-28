using System;
using System.Collections.Generic;
using System.Text;

namespace ChapinWarriorsSA
{
    // Nodo del grafo ortogonal: representa una celda transitable de la ciudad
    // y apunta a sus 4 vecinos (arriba, abajo, izquierda, derecha).
    public class OrthogonalNode
    {
        public Cell cell;
        public int row;
        public int column;
        public OrthogonalNode? up;
        public OrthogonalNode? down;
        public OrthogonalNode? left;
        public OrthogonalNode? right;

        // Estado temporal para BFS
        public bool visited;
        public OrthogonalNode? parent;

        public OrthogonalNode(Cell cell, int row, int column)
        {
            this.cell = cell;
            this.row = row;
            this.column = column;
        }
    }

    // Grafo ortogonal construido a partir de la matriz Cell[][] de una ciudad.
    // Se construye bajo demanda para el pathfinding, sin alterar la matriz original.
    public class OrthogonalGrid
    {
        public OrthogonalNode?[][] nodes = null!;
        public DynamicList<Cell> entries = new DynamicList<Cell>();
        public City city = null!;

        // allowCombat = true (ChapinFighter): las bases militares se enlazan normalmente
        //                 y se decide transitar/combatir durante el BFS.
        // allowCombat = false (ChapinRescue): las bases militares son muros (no se enlazan).
        public static OrthogonalGrid BuildFromCity(City city, bool allowCombat)
        {
            OrthogonalGrid grid = new OrthogonalGrid();
            grid.city = city;
            grid.nodes = new OrthogonalNode[city.rows][];

            // Crear nodos por cada celda no bloqueada
            for (int r = 0; r < city.rows; r++)
            {
                grid.nodes[r] = new OrthogonalNode[city.columns];
                for (int c = 0; c < city.columns; c++)
                {
                    Cell cell = city.mapMatrix[r][c];

                    if (cell.cell == CellType.Blocked)
                    {
                        grid.nodes[r][c] = null;
                        continue;
                    }

                    // Rescue: nunca puede ocupar una base militar (es muro).
                    if (!allowCombat && cell.cell == CellType.Military)
                    {
                        grid.nodes[r][c] = null;
                        continue;
                    }

                    grid.nodes[r][c] = new OrthogonalNode(cell, r + 1, c + 1);

                    if (cell.cell == CellType.Entry)
                    {
                        grid.entries.Add(cell);
                    }
                }
            }

            // Enlazar los 4 vecinos ortogonales
            for (int r = 0; r < city.rows; r++)
            {
                for (int c = 0; c < city.columns; c++)
                {
                    OrthogonalNode? node = grid.nodes[r][c];
                    if (node == null)
                    {
                        continue;
                    }

                    if (r > 0 && grid.nodes[r - 1][c] != null)
                        node.up = grid.nodes[r - 1][c];
                    if (r < city.rows - 1 && grid.nodes[r + 1][c] != null)
                        node.down = grid.nodes[r + 1][c];
                    if (c > 0 && grid.nodes[r][c - 1] != null)
                        node.left = grid.nodes[r][c - 1];
                    if (c < city.columns - 1 && grid.nodes[r][c + 1] != null)
                        node.right = grid.nodes[r][c + 1];
                }
            }

            return grid;
        }

        public OrthogonalNode? GetNode(int row, int column)
        {
            if (row < 1 || row > nodes.Length || column < 1 || column > nodes[0].Length)
            {
                return null;
            }
            return nodes[row - 1][column - 1];
        }
    }
}
