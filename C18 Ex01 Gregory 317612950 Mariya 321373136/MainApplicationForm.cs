using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public partial class MainApplicationForm : Form
    {
        private static ApplicationSettings m_ApplicationSettings = Singelton<ApplicationSettings>.Instance;
        private ApplicationBuilder m_ApplicationBuilder = new ApplicationBuilder(m_ApplicationSettings);
        private FacebookModule m_FacebookModule = new FacebookModule(m_ApplicationSettings);

        public MainApplicationForm()
        {
            InitializeComponent();

            // Initiate Application
            m_ApplicationBuilder.Init();

            // Add grid to form
            Controls.Add(m_ApplicationBuilder.Grid["Main"]);
            Controls.Add(m_ApplicationBuilder.Grid["Header"]);

            //Display Header
            m_ApplicationBuilder.Grid["Header"].Visible = true;

            //Main Text
            MainText.Text = "Find Your Next Place To Visit";

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (m_ApplicationSettings.AutoLogin)
            {
                m_FacebookModule.autoLogin();
            }
        }

        private void FbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                m_FacebookModule.loginAndInit();
                SignIn.Visible = false;
                m_ApplicationBuilder.Display();
                m_ApplicationBuilder.Update(m_FacebookModule.LogedInUser);
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        // TODO: move logout to Header
        private void FbLogout_Click(object sender, EventArgs e)
        {
            m_FacebookModule.Logout(null);
        }

    }
    

}
