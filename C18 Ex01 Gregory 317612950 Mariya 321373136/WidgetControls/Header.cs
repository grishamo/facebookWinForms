using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        public string Username
        {
            get { return UserName.Text; }
            set { UserName.Text = value; }
        }

        public string UserPic
        {
            set { userPic.Load(value); }
        }

    }
}
