using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    class CommonPlaces : UserPlaces
    {
        List<PlaceCategory> m_CommonPlaces = new List<PlaceCategory>();

        public CommonPlaces()
        {
            WidgetName = "CommonPlaces";
            Title.Text = "Common Visited Places";
            //AutoSize = true;
            WidgetContainer.BorderStyle = BorderStyle.None;
            WidgetContainer.BackColor = Color.White;
            //WidgetContainer.MaximumSize = new Size(1000, 200);

            //AutoSize = true;
            MinimumSize = new Size(0, 230);
            MaximumSize = new Size(0, 230);

            WidgetContainer.AutoScroll = true;
            WidgetContainer.MaximumSize = new Size(1000, 0);
        }

        public override void Update(params object[] args)
        {
            List<User> fbUsers = Utils.GeAllParams<User>(args);

            // Get Common places with a friend
            // UseCase: after clicking on friend list item
            if (fbUsers.Count == 2) 
            {
                User fbUser = fbUsers[0];
                User fbUser2 = fbUsers[1];

                m_CommonPlaces = buildCommonPlaces(fbUser, fbUser2);
            }
            // Get Common places with all your friends
            else if (fbUsers.Count == 1)
            {
                FbUser = fbUsers[0];
                FacebookObjectCollection<User> friends = FbUser.Friends;
                m_CommonPlaces = buildCommonFiendsPlaces(FbUser, friends);
            }

            displayPlaces(m_CommonPlaces);

        }

        public override void UpdatePlaces(object i_FbFriend, object e)
        {
            User friend = i_FbFriend as User;
            ClearWidgetContainer(m_CommonPlaces);

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
