using System;
using System.Windows.Forms;
using System.ComponentModel;
using FacebookWrapper;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public partial class MainApplicationForm : Form
    {
        private static ApplicationSettings m_ApplicationSettings = Singelton<ApplicationSettings>.Instance;
        private FacebookModule m_FacebookModule = new FacebookModule(m_ApplicationSettings);
        private ApplicationBuilder m_ApplicationBuilder = new ApplicationBuilder(m_ApplicationSettings);

        public MainApplicationForm()
        {
            InitializeComponent();

            //AppIds
            AppIdComboBox.Items.Add(m_ApplicationSettings.FbAppId);
            AppIdComboBox.Items.Add(m_ApplicationSettings.FbAppIdTest);

            // Initiate Application
            m_ApplicationBuilder.Init(FbLogout_Click);

            // Add grid to form
            Controls.Add(m_ApplicationBuilder.Grid["MainContainer"]);
            Controls.Add(m_ApplicationBuilder.Grid["HeaderContainer"]);

            //Display Header
            m_ApplicationBuilder.Grid["HeaderContainer"].Visible = true;

            //Main Text
            MainText.Text = "Find Your Next Place To Visit";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            m_ApplicationSettings.Save();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (m_ApplicationSettings.AutoLogin)
            {
                try
                {
                    m_FacebookModule.autoLogin();
                    StartApplication();
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    //FbLogin_Click(null, null);
                }
            }
        }

        private void FbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                m_FacebookModule.loginAndInit();
                StartApplication();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void StartApplication()
        {
            SignIn.Visible = false;
            m_ApplicationBuilder.Display();
            m_ApplicationBuilder.Update(m_FacebookModule.LogedInUser);
        }

        // TODO: move logout to Header
        public void FbLogout_Click(object sender, EventArgs e)
        {
            m_FacebookModule.Logout(null);
            m_ApplicationBuilder.LogOut();
            SignIn.Visible = true;
        }

        private void AppIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = AppIdComboBox.SelectedItem;
            m_ApplicationSettings.FbAppId = selectedItem.ToString();
        }
    }
    

}
