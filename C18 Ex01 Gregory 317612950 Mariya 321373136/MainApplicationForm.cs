using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public partial class MainApplicationForm : Form
    {
        private static ApplicationSettings m_ApplicationSettings = Singelton<ApplicationSettings>.Instance;
        private static NewsApiFactory m_NewsApiFactory = Singelton<NewsApiFactory>.Instance;
        private FacebookModule m_FacebookModule = new FacebookModule(m_ApplicationSettings);
        private INews m_News;

        public MainApplicationForm()
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
                m_FacebookModule.autoLogin();
            }
        }

        private void fetchNewsList()
        {
            List<INewsArticle> news = m_News.GetNewsArticles();
            foreach (INewsArticle newsItem in news)
            {
                NewsList.Items.Add(newsItem.title);
            }
        }

        private void FbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                m_FacebookModule.loginAndInit();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void FbLogout_Click(object sender, EventArgs e)
        {
            m_FacebookModule.Logout(null);
        }
    }
    

}
