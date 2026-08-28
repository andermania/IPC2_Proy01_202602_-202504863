using System;
using System.Collections.Generic;

namespace ChapinWarriorsSA
{
    internal static class MissionEngine
    {
        // Estado durante el BFS: nodo + salud acumulada del robot.
        private class SearchState
        {
            public OrthogonalNode node;
            public int health;

            public SearchState(OrthogonalNode node, int health)
            {
                this.node = node;
                this.health = health;
            }
        }

        // Ejecuta la misión buscando un camino desde la entrada más cercana
        // hasta el destino, aplicando las reglas de combate según el tipo de robot.
        public static Mission Execute(City city, Robot robot, Cell destination)
        {
            Mission mission = new Mission();
            mission.city = city;
            mission.robot = robot;
            mission.destination = destination;

            bool isFighter = robot is ChapinFighter;
            int robotHealth = isFighter ? ((ChapinFighter)robot).combatCapacity : 0;
            mission.robotInitialHealth = robotHealth;

            // Rescue no puede combatir -> bases militares son muros.
            // Fighter puede combatir   -> bases se consideran durante el BFS.
            OrthogonalGrid grid = OrthogonalGrid.BuildFromCity(city, allowCombat: isFighter);

            mission.startCell = null;
            mission.success = false;
            mission.battles = new DynamicList<BaseBattleRecord>();
            mission.route = null;

            // ---------- BFS multi-fuente desde todas las entradas ----------
            List<SearchState> queue = new List<SearchState>();
            ClearVisited(grid);

            // bestHealth[row][col] registra la mejor salud con la que se llegó a cada nodo.
            int[][] bestHealth = new int[city.rows][];
            for (int r = 0; r < city.rows; r++)
            {
                bestHealth[r] = new int[city.columns];
            }

            foreach (Cell entry in grid.entries)
            {
                OrthogonalNode? startNode = grid.GetNode(entry.row, entry.column);
                if (startNode != null && !startNode.visited)
                {
                    startNode.visited = true;
                    startNode.parent = null;
                    bestHealth[startNode.row - 1][startNode.column - 1] = robotHealth;
                    queue.Add(new SearchState(startNode, robotHealth));
                    if (mission.startCell == null)
                    {
                        mission.startCell = entry;
                    }
                }
            }

            bool reached = false;
            OrthogonalNode? targetNode = null;

            while (queue.Count > 0)
            {
                SearchState current = queue[0];
                queue.RemoveAt(0);

                if (current.node.row == destination.row && current.node.column == destination.column)
                {
                    reached = true;
                    targetNode = current.node;
                    break;
                }

                TryExpand(queue, current, current.node.up, destination, bestHealth, isFighter, ref reached, ref targetNode);
                if (reached) break;
                TryExpand(queue, current, current.node.down, destination, bestHealth, isFighter, ref reached, ref targetNode);
                if (reached) break;
                TryExpand(queue, current, current.node.left, destination, bestHealth, isFighter, ref reached, ref targetNode);
                if (reached) break;
                TryExpand(queue, current, current.node.right, destination, bestHealth, isFighter, ref reached, ref targetNode);
                if (reached) break;
            }

            // ---------- Se alcanzó el destino: construir resultado ----------
            if (reached && targetNode != null)
            {
                return BuildResult(mission, targetNode, grid, robotHealth, isFighter);
            }

            // ---------- No se alcanzó el destino: misión imposible ----------
            if (!reached)
            {
                mission.success = false;
                mission.route = null;
                mission.robotFinalHealth = robotHealth;

                if (isFighter)
                {
                    SimulateFailedFighter(mission, grid, city, robotHealth);
                }

                return mission;
            }

            return mission;
        }

        // Intenta encolar un vecino respetando las reglas de combate.
        private static void TryExpand(List<SearchState> queue, SearchState current, OrthogonalNode? neighbor,
            Cell destination, int[][] bestHealth, bool isFighter, ref bool reached, ref OrthogonalNode? targetNode)
        {
            if (neighbor == null)
            {
                return;
            }

            int currentHealth = current.health;
            int newHealth = currentHealth;

            // Si la celda es una base militar, solo el fighter puede cruzarla,
            // y solo si su salud actual supera la capacidad de la base.
            if (neighbor.cell.cell == CellType.Military)
            {
                if (!isFighter)
                {
                    return; // rescue nunca cruza bases (no deberían estar enlazadas)
                }
                if (currentHealth <= neighbor.cell.combatCapacity)
                {
                    return; // no puede superar esta base -> es un muro para este estado
                }
                newHealth = currentHealth - neighbor.cell.combatCapacity;
            }

            // Aceptar solo si es la primera vez, o si llegamos con mejor (mayor) salud.
            bool accepted = false;
            if (!neighbor.visited)
            {
                accepted = true;
                neighbor.visited = true;
            }
            else if (newHealth > bestHealth[neighbor.row - 1][neighbor.column - 1])
            {
                accepted = true;
            }

            if (accepted)
            {
                bestHealth[neighbor.row - 1][neighbor.column - 1] = newHealth;
                neighbor.parent = current.node;
                queue.Add(new SearchState(neighbor, newHealth));

                if (neighbor.row == destination.row && neighbor.column == destination.column)
                {
                    reached = true;
                    targetNode = neighbor;
                }
            }
        }

        // Reconstruye la ruta y aplica el combate sobre las bases del camino.
        private static Mission BuildResult(Mission mission, OrthogonalNode targetNode,
            OrthogonalGrid grid, int robotHealth, bool isFighter)
        {
            // Reconstruir ruta desde la entrada hasta el destino (en orden).
            DynamicList<Cell> route = new DynamicList<Cell>();
            Stack<Cell> stack = new Stack<Cell>();
            OrthogonalNode? walk = targetNode;
            while (walk != null)
            {
                stack.Push(walk.cell);
                walk = walk.parent;
            }
            while (stack.Count > 0)
            {
                route.Add(stack.Pop());
            }
            mission.route = route;

            // ---- Aplicar combate por cada base de la ruta ----
            if (isFighter)
            {
                int runningHealth = mission.robotInitialHealth;
                foreach (Cell cell in route)
                {
                    if (cell.cell == CellType.Military)
                    {
                        // Por construcción del BFS, aquí siempre runningHealth > base.capacity.
                        int damage = cell.combatCapacity;
                        runningHealth -= damage;

                        BaseBattleRecord record = new BaseBattleRecord();
                        record.row = cell.row;
                        record.column = cell.column;
                        record.baseCapacity = cell.combatCapacity;
                        record.destroyed = true;
                        record.damage = damage;
                        mission.battles.Add(record);
                    }
                }
                mission.robotFinalHealth = runningHealth;
                mission.success = true;
            }
            else
            {
                // Rescue no combate.
                mission.robotFinalHealth = 0;
                mission.success = true;
            }

            return mission;
        }

        private static DynamicList<Cell> CollectMilitaryCells(City city)
        {
            DynamicList<Cell> result = new DynamicList<Cell>();
            for (int r = 0; r < city.rows; r++)
            {
                for (int c = 0; c < city.columns; c++)
                {
                    if (city.mapMatrix[r][c].cell == CellType.Military)
                    {
                        result.Add(city.mapMatrix[r][c]);
                    }
                }
            }
            return result;
        }

        private static void ClearVisited(OrthogonalGrid grid)
        {
            for (int r = 0; r < grid.nodes.Length; r++)
            {
                for (int c = 0; c < grid.nodes[r].Length; c++)
                {
                    if (grid.nodes[r][c] != null)
                    {
                        grid.nodes[r][c]!.visited = false;
                        grid.nodes[r][c]!.parent = null;
                    }
                }
            }
        }

        // Simula el combate en el peor caso: cuando no hay ruta hasta el destino, un
        // fighter recorre el corredor de bases en serie; derrota las que puede y se
        // detiene en la primera que no puede vencer. Reporta Destruida/No Destruida.
        private static void SimulateFailedFighter(Mission mission, OrthogonalGrid grid, City city,
            int robotHealth)
        {
            DynamicList<Cell> allMilitary = CollectMilitaryCells(city);
            if (allMilitary.counter == 0)
            {
                return;
            }

            // Calcular la distancia (orden de avance) de cada base desde las entradas,
            // permitiendo cruzar bases ya derrotadas para alcanzar las siguientes.
            List<(Cell cell, int dist)> bases = new List<(Cell, int)>();
            foreach (Cell baseCell in allMilitary)
            {
                int dist = DistFromAnyEntry(grid, baseCell, robotHealth);
                if (dist >= 0)
                {
                    bases.Add((baseCell, dist));
                }
            }

            // Ordenar por distancia creciente para simular el recorrido en serie.
            bases.Sort((a, b) => a.dist.CompareTo(b.dist));

            int currentHealth = robotHealth;
            for (int i = 0; i < bases.Count; i++)
            {
                Cell baseCell = bases[i].cell;
                BaseBattleRecord record = new BaseBattleRecord();
                record.row = baseCell.row;
                record.column = baseCell.column;
                record.baseCapacity = baseCell.combatCapacity;

                if (baseCell.combatCapacity < currentHealth)
                {
                    // La derrota: resta su capacidad al daño acumulado del robot.
                    record.destroyed = true;
                    record.damage = baseCell.combatCapacity;
                    currentHealth -= baseCell.combatCapacity;
                }
                else
                {
                    // Primera base que no puede vencer: bloquea la ruta restante.
                    record.destroyed = false;
                    record.damage = 0;
                }
                mission.battles.Add(record);

                // Una vez bloqueado, las bases más lejanas ya no se alcanzan.
                if (!record.destroyed)
                {
                    break;
                }
            }

            mission.robotFinalHealth = currentHealth;
        }

        // Distancia BFS desde cualquier entrada hasta la base, permitiendo viajar por
        // celdas de camino y bases derrotables, pero SIN cruzar bases insuperables.
        // La base objetivo recibe su distancia aunque sea bloqueante (no se expande).
        // Retorna -1 si es inalcanzable (las bases la aíslan del resto).
        private static int DistFromAnyEntry(OrthogonalGrid grid, Cell baseCell, int robotHealth)
        {
            List<OrthogonalNode> queue = new List<OrthogonalNode>();
            Dictionary<(int, int), int> dist = new Dictionary<(int, int), int>();

            foreach (Cell entry in grid.entries)
            {
                OrthogonalNode? entryNode = grid.GetNode(entry.row, entry.column);
                if (entryNode == null) continue;
                var k = (entryNode.row, entryNode.column);
                if (!dist.ContainsKey(k))
                {
                    dist[k] = 0;
                    queue.Add(entryNode);
                }
            }

            while (queue.Count > 0)
            {
                OrthogonalNode current = queue[0];
                queue.RemoveAt(0);
                var ck = (current.row, current.column);

                if (current.row == baseCell.row && current.column == baseCell.column)
                {
                    return dist[ck];
                }

                foreach (OrthogonalNode? nb in new OrthogonalNode?[] { current.up, current.down, current.left, current.right })
                {
                    if (nb == null) continue;
                    var nk = (nb.row, nb.column);
                    if (dist.ContainsKey(nk)) continue;

                    Cell cell = grid.city.mapMatrix[nb.row - 1][nb.column - 1];
                    dist[nk] = dist[ck] + 1;

                    // Si este vecino es la base objetivo, su distancia ya es correcta.
                    if (nb.row == baseCell.row && nb.column == baseCell.column)
                    {
                        return dist[nk];
                    }

                    // No se expanden bases insuperables (no se atraviesan).
                    if (cell.cell == CellType.Military && cell.combatCapacity >= robotHealth)
                    {
                        continue;
                    }
                    queue.Add(nb);
                }
            }

            return -1;
        }
    }
}
