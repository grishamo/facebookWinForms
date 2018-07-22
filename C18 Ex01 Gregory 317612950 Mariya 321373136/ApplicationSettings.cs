using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public class ApplicationSettings
    {
        private static readonly string sr_FileName;

        static ApplicationSettings()
        {
            sr_FileName = Application.ExecutablePath + ".settings.xml";
        }

        /// <summary>
        ///  private CTOR as part as the singltone pattern
        /// </summary>
        private ApplicationSettings(){
            try
            {
                FromFileOrDefault();
            }
            catch(Exception e)
            {
                
            }
        }

        /// C# 3.0 feature: Automatic Properties
        public bool AutoLogin { get; set; }
        public string FbAppId { get; set; }
        public string FbAppIdTest { get; set; }
        public Size LastWindowSize { get; set; }
        public FormWindowState LastWindowState { get; set; }
        public Point LastWindowLocation { get; set; }
        public string AccessToken { get; set; }

        public void Save()
        {
            using (FileStream stream = new FileStream(sr_FileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));
                serializer.Serialize(stream, this);
            }
        }

        private void FromFileOrDefault()
        {
            ApplicationSettings loadedThis = null;

            if (File.Exists(sr_FileName))
            {
                using (FileStream stream = new FileStream(sr_FileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));
                    loadedThis = (ApplicationSettings)serializer.Deserialize(stream);
                }
            }

            AutoLogin = loadedThis != null && loadedThis.AccessToken != null;
            AccessToken = loadedThis != null && loadedThis.AccessToken != null ? loadedThis.AccessToken : null;
            LastWindowSize = loadedThis != null ?  loadedThis.LastWindowSize : new Size(870, 740);
            LastWindowState = loadedThis != null ? loadedThis.LastWindowState : FormWindowState.Normal;
            FbAppId = "1450160541956417";  //Desig Patter         
            FbAppIdTest = "229133017717072";  //  Gri@Mash    
        }   
    }
}
