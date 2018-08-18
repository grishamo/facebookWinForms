using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public class ApplicationFactory
    {
        private ApplicationFactory() { }

        public ApplicationBase Build<T>(ApplicationSettings i_appSettings)
            where T : ApplicationBase, new()
        {
            ApplicationBase currentApplication = new T();
            currentApplication.Settings = i_appSettings;
            currentApplication.Build();

            return currentApplication;
        }
    }
}
