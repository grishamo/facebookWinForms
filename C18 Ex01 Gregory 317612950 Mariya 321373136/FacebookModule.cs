using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public class FacebookModule
    {
        private ApplicationSettings m_ApplicationSettings;
        private User m_LoggedInUser;
        private string m_AppId = "1450160541956417"; //229133017717072
        private string m_Permissions = string.Format(
@"public_profile, 
user_friends,
groups_access_member_info,
user_likes, 
user_tagged_places, 
user_location, 
user_events");

        public FacebookModule(ApplicationSettings i_ApplicationSettings)
        {
            m_ApplicationSettings = i_ApplicationSettings;
        }

        public void autoLogin()
        {
            LoginResult result = FacebookService.Connect(m_ApplicationSettings.AccessToken);
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                m_LoggedInUser = result.LoggedInUser;
            }

        }

        public void loginAndInit()
        {
            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user: 
            LoginResult result = FacebookService.Login(m_AppId, m_Permissions);
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference


            if (string.IsNullOrEmpty(result.AccessToken))
            {
                throw new Exception(result.ErrorMessage);
            }


            m_LoggedInUser = result.LoggedInUser;
            m_ApplicationSettings.AccessToken = result.AccessToken;

        }

        public void Logout(Action i_Callback)
        {
            FacebookService.Logout(i_Callback);
        }

    }
}
