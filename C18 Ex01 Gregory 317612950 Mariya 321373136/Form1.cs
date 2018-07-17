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
        private ApplicationSettings m_ApplicationSettings = Singelton<ApplicationSettings>.Instance;
        private NewsApiFactory m_NewsApiFactory = Singelton<NewsApiFactory>.Instance;
        private INews m_News;

        public Form1()
        {
            // News api can be from the diffrent provider
            m_News = m_NewsApiFactory.Create("newsapi");
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (m_ApplicationSettings.AutoLogin)
            {
                autoLogin();
            }
        }

        private void autoLogin()
        {
            LoginResult result = FacebookService.Connect(m_ApplicationSettings.AccessToken);
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                m_LoggedInUser = result.LoggedInUser;
            }
        }

        private void loginAndInit()
        {
            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user: 
            /// 229133017717072
            LoginResult result = FacebookService.Login("1450160541956417",
                "public_profile",
                "user_friends",
                "groups_access_member_info",
                "user_likes",
                "user_tagged_places",
                "user_location",
                "user_events"
                );
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference


            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
                m_ApplicationSettings.AccessToken = result.AccessToken;

                List<INewsArticle> news = m_News.GetNewsArticles();
                fetchNewsList(news);
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void fetchNewsList(List<INewsArticle> i_ItemNews)
        {
            foreach(INewsArticle newsItem in i_ItemNews)
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
            FacebookService.Logout(null);
        }
    }
    

}
