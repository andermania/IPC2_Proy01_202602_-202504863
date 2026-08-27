using ChapinWarriorsSA.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChapinWarriorsSA
{
    public class NavigationController
    {
        private Controller controller;
        private MainView mainView;
        private UserQuery userQuery;
        private Details details;
        private MissionPrepare missionPrepare;
        private MakeGraphiz graphviz;
        public NavigationController(Controller controller, MakeGraphiz graphviz)
        {
            this.controller = controller;
            this.graphviz = graphviz;
            mainView = new MainView(controller, this);
            userQuery = new UserQuery(controller, this);
            details = new Details(controller, this, graphviz);
            missionPrepare = new MissionPrepare(controller, this, graphviz);
        }

        public void Start()
        {
            HideAll();
            mainView.Show();
        }

        public void UserQuery() {
            HideAll();
            userQuery.Show();
        }

        public void Details(Entity type, DynamicList<Robot>? filteredRobots = null)
        {
            HideAll();
            details.Setup(type, filteredRobots);
            details.Show();
        }

        public void MissionPrepare()
        {
            HideAll();
            missionPrepare.Setup();
            missionPrepare.Show();
        }

        private void HideAll()
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                form.Hide();
            }
        }
    }
}
