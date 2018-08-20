using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public class ApplicationFactory
    {
        private List<ApplicationBase> m_AllApplications = new List<ApplicationBase>();

        private ApplicationFactory() { }

        public ApplicationBase Create<T>(ApplicationSettings i_appSettings)
            where T : ApplicationBase, new()
        {
            ApplicationBase currentApplication = new T();
            currentApplication.Settings = i_appSettings;
            currentApplication.Build();

            m_AllApplications.Add(currentApplication);

            return currentApplication;
        }
    }
}
