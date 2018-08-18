using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public class CommonPlacesApplication : ApplicationBase
    {
        private readonly String r_MainContainerName = "MainContainer";
        private readonly String r_HeaderContainerName = "HeaderContainer";

        public override void Build(params object[] i_ObjList)
        {
                BuildGrid(r_MainContainerName, r_HeaderContainerName);
                BuildHeader();
                BuildWidgets();
        }

        protected override void BuildHeader(params object[] i_ObjList)
        {
                Header = new Header();
                Header.Dock = DockStyle.Top;
                Grid[r_HeaderContainerName].Controls.Add(Header);
        }

        public override void LogOut()
        {
            base.LogOut();
            Grid[r_MainContainerName].Visible = false;
        }

        public override void AddAppToForm(Control.ControlCollection i_Controls)
        {
            base.AddAppToForm(i_Controls);
            Grid[r_HeaderContainerName].Visible = true;
        }

        protected override void BuildWidgets(params object[] i_ObjList)
        {
            Widgets = new List<Widget>();

            Widget userPlaces = new UserPlaces();
            userPlaces.Dock = DockStyle.Fill;

            Widget commonPlaces = new CommonPlaces();
            commonPlaces.Dock = DockStyle.Bottom;

            Widget friendsList = new FriendsList();
            friendsList.WidgetEvents.Add((userPlaces as UserPlaces).UpdatePlaces);
            friendsList.WidgetEvents.Add((commonPlaces as CommonPlaces).UpdatePlaces);
            friendsList.Dock = DockStyle.Left;

            // The sort of the items is important
            // it effects on they appearance
            Widgets.Add(commonPlaces);
            Widgets.Add(userPlaces);
            Widgets.Add(friendsList);

            // Add All Widgets to Container
            foreach (Widget widget in Widgets)
            {
                Grid[r_MainContainerName].Controls.Add(widget);
            }
        }

        public override void OnLogOutClick(EventHandler fbLogout_Click)
        {
            Header.OnLogoutClick += fbLogout_Click;
        }
    }
}
