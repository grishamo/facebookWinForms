using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    class CommonPlaces : UserPlaces
    {
        List<PlaceCategory> m_CommonPlaces = new List<PlaceCategory>();

        public CommonPlaces()
        {
            WidgetName = "CommonPlaces";
            WidgetTitle = "Common Places";

            WidgetContainer.BorderStyle = BorderStyle.None;
            WidgetContainer.BackColor = Color.White;

            MinimumSize = new Size(0, 230);
            MaximumSize = new Size(0, 230);

            WidgetContainer.AutoScroll = true;
            WidgetContainer.MaximumSize = new Size(1000, 0);
        }

        public override void Update(params object[] args)
        {
            FbUser = Utils.GetParam<User>(args) as User;

            FacebookObjectCollection<User> friends = FbUser.Friends;
            m_CommonPlaces = buildCommonFiendsPlaces(FbUser, friends);

            displayPlaces(m_CommonPlaces);
        }

        public override void UpdatePlaces(object i_FbFriend, object e)
        {
            User friend = i_FbFriend as User;
            ClearWidgetContainer(m_CommonPlaces);
            WidgetTitle = "Common Places With " + friend.FirstName;

            m_CommonPlaces = buildCommonPlaces(FbUser, friend);
            displayPlaces(m_CommonPlaces);
        }

        private List<PlaceCategory> buildCommonFiendsPlaces(User i_FirstUser, FacebookObjectCollection<User> i_FbUsers)
        {
            List<PlaceCategory> commonPlaces = new List<PlaceCategory>();
            FacebookObjectCollection <Checkin> commonCheckins = new FacebookObjectCollection<Checkin>();

            foreach(Checkin userCheckin in i_FirstUser.Checkins)
            {
                bool isCommon = true;

                foreach(User nextUser in i_FbUsers)
                {
                    if(!nextUser.Checkins.Contains(userCheckin))
                    {
                        isCommon = false;
                        break;
                    }
                }

                if(isCommon)
                {
                    commonCheckins.Add(userCheckin);
                }
            }


            commonPlaces = buildCategories(commonCheckins);
            return commonPlaces;
        }

        private List<PlaceCategory> buildCommonPlaces(User i_FirstUser, User i_SecondUser)
        {
            List<PlaceCategory> commonPlaces = new List<PlaceCategory>();
            FacebookObjectCollection<Checkin> commonCheckins = new FacebookObjectCollection<Checkin>();

            foreach (Checkin checkin in i_FirstUser.Checkins)
            {
                if (!i_SecondUser.Checkins.Contains(checkin))
                {
                    commonCheckins.Add(checkin);
                }
            }

            commonPlaces = buildCategories(commonCheckins);
            return commonPlaces;
        }
    }
}
