using ChapinWarriorsSA;
using ChapinWarriorsSA.Views;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace TuProyecto
{
    internal static class Program
    {
                
        public static GameData data = new GameData();
        public static XMLReader xml = new XMLReader();
        public static MakeGraphiz graphviz  = new MakeGraphiz();
        public static Controller controller = new Controller(data, xml);
        public static NavigationController navigationController = new NavigationController(controller, graphviz);

        static void Main()
        {
            Debug.WriteLine("Hola");
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            navigationController.Start();
            Application.Run();
        }
    }
}
