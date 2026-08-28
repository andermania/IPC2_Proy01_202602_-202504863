using System;
using System.Diagnostics;
using System.Text;

namespace ChapinWarriorsSA
{
    // Genera una imagen PNG de la malla de una ciudad usando Graphviz.
    // No sabe nada de UI: solo recibe datos (City y, opcionalmente, una ruta)
    // y devuelve la ruta del archivo .png ya generado.
    public class MakeGraphiz
    {
        private static readonly string DotFilePath = Path.Combine(Path.GetTempPath(), "mapa_actual.dot");
        private static readonly string PngFilePath = Path.Combine(Path.GetTempPath(), "mapa_actual.png");

        // Genera el mapa de la ciudad SIN ninguna ruta resaltada.
        public string GenerarMapaCiudad(City city)
        {
            return Generar(city, null);
        }

        // Genera el mapa de la ciudad CON la ruta de una misión resaltada.
        // route: celdas que forman el camino encontrado por el algoritmo (en cualquier orden).
        public string GenerarMapaMision(City city, DynamicList<Cell> route)
        {
            bool[][] routeMask = BuildRouteMask(city, route);
            return Generar(city, routeMask);
        }

        // Carga el PNG generado SIN bloquear el archivo en disco.
        // Image.FromFile(path) deja el archivo abierto mientras el Image exista,
        // lo cual falla la próxima vez que Graphviz intente sobreescribir ese mismo
        // archivo. Leyendo los bytes primero y creando el Image desde memoria,
        // el archivo queda libre en disco inmediatamente.
        public static System.Drawing.Image CargarImagen(string pngPath)
        {
            byte[] bytes = File.ReadAllBytes(pngPath);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private string Generar(City city, bool[][]? routeMask)
        {
            string dot = BuildDot(city, routeMask);
            File.WriteAllText(DotFilePath, dot);
            RunDot(DotFilePath, PngFilePath);
            return PngFilePath;
        }

        // -------------------- CONSTRUCCION DEL .DOT --------------------

        private bool[][] BuildRouteMask(City city, DynamicList<Cell> route)
        {
            bool[][] mask = new bool[city.rows][];
            for (int i = 0; i < city.rows; i++)
            {
                mask[i] = new bool[city.columns];
            }

            if (route != null)
            {
                foreach (Cell cell in route)
                {
                    mask[cell.row - 1][cell.column - 1] = true;
                }
            }

            return mask;
        }

        private string BuildDot(City city, bool[][]? routeMask)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("digraph Mapa {");
            sb.AppendLine("  rankdir=TB;");
            sb.AppendLine("  node [shape=plaintext];");

            sb.AppendLine("  grid [label=<");
            sb.Append(BuildGridTable(city, routeMask));
            sb.AppendLine("  >];");

            sb.AppendLine("}");

            return sb.ToString();
        }

        private string BuildGridTable(City city, bool[][]? routeMask)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    <TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"2\">");

            // fila de encabezado con los numeros de columna
            sb.Append("      <TR><TD></TD>");
            for (int c = 1; c <= city.columns; c++)
            {
                sb.Append("<TD WIDTH=\"18\" HEIGHT=\"18\"><FONT POINT-SIZE=\"8\">" + c + "</FONT></TD>");
            }
            sb.AppendLine("</TR>");

            for (int r = 0; r < city.rows; r++)
            {
                // columna de encabezado con el numero de fila
                sb.Append("      <TR><TD><FONT POINT-SIZE=\"8\">" + (r + 1) + "</FONT></TD>");

                for (int c = 0; c < city.columns; c++)
                {
                    Cell cell = city.mapMatrix[r][c];
                    bool enRuta = routeMask != null && routeMask[r][c];
                    string color = GetColor(cell.cell, enRuta);

                    sb.Append("<TD WIDTH=\"18\" HEIGHT=\"18\" FIXEDSIZE=\"TRUE\" BGCOLOR=\"" + color + "\"></TD>");
                }

                sb.AppendLine("</TR>");
            }

            sb.AppendLine("    </TABLE>");

            return sb.ToString();
        }

        // El color se decide asi:
        // - Si la celda es de tipo Path Y esta en la ruta -> color de ruta (khaki).
        // - En cualquier otro caso -> color fijo segun el tipo de celda
        //   (una unidad militar o civil que este en la ruta conserva su color original,
        //   igual que en las figuras del enunciado).
        private string GetColor(CellType type, bool enRuta)
        {
            if (enRuta && type == CellType.Path)
            {
                return "khaki";
            }

            switch (type)
            {
                case CellType.Blocked: return "black";
                case CellType.Entry: return "green";
                case CellType.Path: return "white";
                case CellType.Civil: return "dodgerblue";
                case CellType.Resource: return "gray";
                case CellType.Military: return "red";
                default: return "white";
            }
        }

        // -------------------- EJECUCION DE GRAPHVIZ --------------------

        private void RunDot(string dotFilePath, string outputPngPath)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "dot"; // requiere que Graphviz este instalado y "dot" este en el PATH
            psi.Arguments = "-Tpng \"" + dotFilePath + "\" -o \"" + outputPngPath + "\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;

            try
            {
                using (Process process = Process.Start(psi)!)
                {
                    string errorOutput = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        throw new Exception("Graphviz devolvio un error al generar la imagen:\n" + errorOutput);
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                throw new Exception("No se encontro 'dot.exe'. Verifica que Graphviz este instalado y que su carpeta 'bin' este agregada al PATH del sistema.");
            }
        }
    }
}
