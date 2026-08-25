using System.Xml;

namespace ChapinWarriorsSA
{
    public class XMLReader
    {
        public DynamicList<City> ReadCities(string path)
        {
            DynamicList<City> result = new DynamicList<City>();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode? configNode = doc.SelectSingleNode("configuracion");
            if (configNode == null)
            {
                throw new Exception("El archivo XML no tiene la etiqueta raiz <configuracion>.");
            }

            XmlNode? listaCiudadesNode = configNode.SelectSingleNode("listaCiudades");
            if (listaCiudadesNode != null)
            {
                foreach (XmlNode ciudadNode in listaCiudadesNode.ChildNodes)
                {
                    if (ciudadNode.NodeType == XmlNodeType.Element && ciudadNode.Name == "ciudad")
                    {
                        result.Add(ReadCity(ciudadNode));
                    }
                }
            }

            return result;
        }

        public DynamicList<Robot> ReadRobots(string path)
        {
            DynamicList<Robot> result = new DynamicList<Robot>();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode? configNode = doc.SelectSingleNode("configuracion");
            if (configNode == null)
            {
                throw new Exception("El archivo XML no tiene la etiqueta raiz <configuracion>.");
            }

            XmlNode? robotsNode = configNode.SelectSingleNode("robots");
            if (robotsNode != null)
            {
                foreach (XmlNode robotNode in robotsNode.ChildNodes)
                {
                    if (robotNode.NodeType == XmlNodeType.Element && robotNode.Name == "robot")
                    {
                        result.Add(ReadRobot(robotNode));
                    }
                }
            }

            return result;
        }

        // -------------------- CIUDADES --------------------

        private City ReadCity(XmlNode ciudadNode)
        {
            string name = "";
            int rows = 0;
            int columns = 0;
            Cell[][]? mapMatrix = null;

            // Primera pasada: leer <nombre> para saber filas/columnas y poder crear la matriz
            foreach (XmlNode child in ciudadNode.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element && child.Name == "nombre")
                {
                    name = child.InnerText.Trim();
                    rows = int.Parse(child.Attributes!["filas"]!.Value!);
                    columns = int.Parse(child.Attributes!["columnas"]!.Value!);

                    mapMatrix = new Cell[rows][];
                    for (int i = 0; i < rows; i++)
                    {
                        mapMatrix[i] = new Cell[columns];
                    }
                }
            }

            if (mapMatrix == null)
            {
                throw new Exception("La ciudad no tiene etiqueta <nombre> con filas/columnas.");
            }

            int entries = 0;
            int military = 0;
            int civilian = 0;
            int resources = 0;

            // Segunda pasada: <fila> y <unidadMilitar>
            foreach (XmlNode child in ciudadNode.ChildNodes)
            {
                if (child.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                if (child.Name == "fila")
                {
                    int rowNumber = int.Parse(child.Attributes!["numero"]!.Value!);
                    string rowContent = StripQuotes(child.InnerText);

                    if (rowContent.Length != columns)
                    {
                        throw new Exception("La fila " + rowNumber + " no tiene " + columns + " columnas (tiene " + rowContent.Length + ").");
                    }

                    for (int col = 0; col < rowContent.Length && col < columns; col++)
                    {
                        char c = rowContent[col];
                        CellType type = CharToCellType(c);
                        mapMatrix[rowNumber - 1][col] = new Cell(rowNumber, col + 1, type);

                        switch (type)
                        {
                            case CellType.Entry: entries++; break;
                            case CellType.Civil: civilian++; break;
                            case CellType.Resource: resources++; break;
                        }
                    }
                }
                else if (child.Name == "unidadMilitar")
                {
                    int fila = int.Parse(child.Attributes!["fila"]!.Value!);
                    int columna = int.Parse(child.Attributes!["columna"]!.Value!);
                    int capacidad = int.Parse(child.InnerText.Trim());

                    Cell militaryCell = mapMatrix[fila - 1][columna - 1];
                    militaryCell.cell = CellType.Military;
                    militaryCell.combatCapacity = capacidad;
                    military++;
                }
            }

            return new City(name, rows, columns, entries, military, civilian, resources, mapMatrix);
        }

        // El contenido de <fila> viene delimitado por comillas literales, ej: "*E      **"
        // Aqui se quitan esas comillas (si existen) para quedarnos solo con las m columnas.
        private string StripQuotes(string text)
        {
            if (text.Length >= 2 && text[0] == '"' && text[text.Length - 1] == '"')
            {
                return text.Substring(1, text.Length - 2);
            }
            return text;
        }

        private CellType CharToCellType(char c)
        {
            switch (c)
            {
                case '*': return CellType.Blocked;
                case ' ': return CellType.Path;
                case 'E': return CellType.Entry;
                case 'C': return CellType.Civil;
                case 'R': return CellType.Resource;
                default:
                    throw new Exception("Caracter invalido en la malla de la ciudad: '" + c + "'");
            }
        }

        // -------------------- ROBOTS --------------------

        private Robot ReadRobot(XmlNode robotNode)
        {
            foreach (XmlNode child in robotNode.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element && child.Name == "nombre")
                {
                    string tipo = child.Attributes!["tipo"]!.Value!;
                    string nombre = child.InnerText.Trim();

                    if (tipo == "ChapinFighter")
                    {
                        int capacidad = int.Parse(child.Attributes["capacidad"]!.Value!);
                        ChapinFighter fighter = new ChapinFighter();
                        fighter.name = nombre;
                        fighter.combatCapacity = capacidad;
                        return fighter;
                    }
                    else if (tipo == "ChapinRescue")
                    {
                        ChapinRescue rescue = new ChapinRescue();
                        rescue.name = nombre;
                        return rescue;
                    }
                    else
                    {
                        throw new Exception("Tipo de robot desconocido: " + tipo);
                    }
                }
            }

            throw new Exception("El robot no tiene etiqueta <nombre>.");
        }
    }
}
