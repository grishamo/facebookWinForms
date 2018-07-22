using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public class ApplicationBuilder
    {
        private ApplicationSettings m_ApplicationSettings;

        public Header Header { get; set; }
        public List<Widget> Widgets { get; set; }
        public Dictionary<string, Control> Grid { get; set; }

        public ApplicationBuilder(ApplicationSettings i_ApplicationSettings)
        {
            m_ApplicationSettings = i_ApplicationSettings;
        }

        public void Init()
        {
            Grid = BuildGrid("MainContainer", "HeaderContainer");
            BuildHeader(Grid["HeaderContainer"]);
            BuildWidgets(Grid["MainContainer"]);
        }

        public void Update(User i_LogedInUser)
        {
            UpdateHeader(i_LogedInUser);
            UpdateWidgets(i_LogedInUser);
        }

        public void Display()
        {
            foreach (KeyValuePair<string, Control> control in Grid)
            {
                control.Value.Visible = true;
            }
        }

        private void UpdateWidgets(User i_LogedInUser)
        {
            foreach(Widget widget in Widgets)
            {
                widget.Update(i_LogedInUser);
            }

        }

        private void BuildHeader(Control i_Container)
        {
            Header = new Header();
            Header.Dock = DockStyle.Top;
            i_Container.Controls.Add(Header);
        }

        private void BuildWidgets(Control i_Container)
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
                i_Container.Controls.Add(widget);
            }
        }

        private Dictionary<string, Control> BuildGrid(string i_Main, string i_Header)
        {
            Dictionary<string, Control> grid = new Dictionary<string, Control>();
            Panel headerContainer = new Panel();
            Panel mainConatainer = new Panel();

            headerContainer.AutoSize = true;
            headerContainer.Dock = DockStyle.Top;
            headerContainer.Visible = false;

            mainConatainer.AutoSize = true;
            mainConatainer.Dock = DockStyle.Fill;
            mainConatainer.Visible = false;
            mainConatainer.Padding = new Padding(0, 20, 0, 0);

            grid.Add(i_Main, mainConatainer);
            grid.Add(i_Header, headerContainer);

            return grid;
        }

        private void UpdateHeader(User i_LogedInUser)
        {
            User FbUser = i_LogedInUser;
            Header.Username = FbUser.Name;
            Header.UserPic = FbUser.PictureSqaureURL;
        }
    }
}
