using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public partial class Form1 : Form
    {
        private User m_LoggedInUser;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (ApplicationSettings.Instance.AutoLogin)
            {
                autoLogin();
            }
        }

        private void autoLogin()
        {
            LoginResult result = FacebookService.Connect(ApplicationSettings.Instance.AccessToken);
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                m_LoggedInUser = result.LoggedInUser;
            }
        }

        private void loginAndInit()
        {
            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:
            LoginResult result = FacebookService.Login("229133017717072",
                "public_profile",
                "user_friends",
                "groups_access_member_info",
                "user_likes",
                "user_location"
                );
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference


            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
                ApplicationSettings.Instance.AccessToken = result.AccessToken;

                List<Article> news = NewsApi.Instance.GetNewsContent();
                fetchNewsList(news);
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void fetchNewsList(List<Article> i_ItemNews)
        {
            foreach(Article newsItem in i_ItemNews)
            {
                NewsList.Items.Add(newsItem.title);
            }
        }

        private void FbLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void FbLogout_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(LogoutCallback);
        }


        public Action LogoutCallback { get; private set; }
    }
    

}
