using System.Drawing;
using System.Text;

namespace ChapinWarriorsSA
{
    // Resultado del renderizado de una misión: todos los valores calculados que un
    // Form (FinalReport o History) debe asignar a sus controles, para no duplicar
    // la lógica de presentación.
    public class MissionRenderData
    {
        public string title = "";
        public Color titleColor = Color.White;
        public string cityName = "---";
        public string start = "---";
        public string end = "---";
        public string mapPng = "";
        public string robotName = "---";
        public string robotType = "Tipo: ---";
        public Bitmap? robotImage = null;
        public string capInit = "";
        public bool capInitVisible = false;
        public string report = "";
        public string capFinal = "";
        public bool capFinalVisible = false;
    }

    // Centraliza la lógica de presentación compartida entre FinalReport y History.
    public static class MissionRenderer
    {
        public static MissionRenderData Render(Mission mission, MakeGraphiz gridv)
        {
            MissionRenderData d = new MissionRenderData();

            // ---------- TITULO ----------
            if (mission.success)
            {
                d.title = "MISIÓN EXITOSA";
                d.titleColor = Color.SpringGreen;
            }
            else
            {
                d.title = "MISIÓN IMPOSIBLE";
                d.titleColor = Color.Red;
            }

            // ---------- CIUDAD ----------
            d.cityName = mission.city?.name ?? "---";
            d.start = mission.startCell != null
                ? "(" + mission.startCell.row + ", " + mission.startCell.column + ")"
                : "---";
            d.end = mission.destination != null
                ? "(" + mission.destination.row + ", " + mission.destination.column + ")"
                : "---";

            // ---------- MAPA (con ruta si hay) ----------
            bool isFighter = mission.robot is ChapinFighter;
            if (mission.success && mission.route != null && mission.route.counter > 0)
            {
                d.mapPng = gridv.GenerarMapaMision(mission.city!, mission.route);
            }
            else
            {
                d.mapPng = gridv.GenerarMapaCiudad(mission.city!);
            }

            // ---------- ROBOT ----------
            d.robotName = mission.robot?.name ?? "---";
            d.robotType = isFighter ? "Tipo: ChapinFighter" : "Tipo: ChapinRescue";
            d.robotImage = isFighter
                ? Properties.Resources.ChapinFighter
                : Properties.Resources.ChapinRescue;

            // ---------- REPORTE DE COMBATE (solo fighter) ----------
            if (isFighter)
            {
                d.capInitVisible = true;
                d.capInit = "Capacidad inicial: " + mission.robotInitialHealth;

                StringBuilder report = new StringBuilder();
                foreach (BaseBattleRecord battle in mission.battles)
                {
                    report.AppendLine("Base (" + battle.row + "x" + battle.column + "): " +
                        (battle.destroyed ? "Destruida" : "No Destruida") +
                        "     Daño: " + battle.damage);
                    report.AppendLine();
                }
                d.report = report.ToString();

                d.capFinalVisible = true;
                d.capFinal = "Capacidad de combate final: " + mission.robotFinalHealth;
            }

            return d;
        }
    }
}
