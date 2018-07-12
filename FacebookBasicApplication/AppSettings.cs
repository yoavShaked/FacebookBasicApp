using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace FacebookBasicApplication
{
    public sealed class AppSettings
    {
        public string LastAccessToken { get; set; }

        public bool RemamberUser { get; set; }

        private AppSettings()
        {
        }

				public static AppSettings LoadFromFile()
				{
					AppSettings appSettings = new AppSettings();

					if (File.Exists(@"C:\Users\user\Documents\AppSettings.xml" ) )
					{
						using (FileStream stream = new FileStream(@"C:\Users\user\Documents\AppSettings.xml", FileMode.Open ) )
						{
							XmlSerializer serializer = new XmlSerializer(typeof(AppSettings) );
							appSettings = serializer.Deserialize(stream ) as AppSettings;
						}
					}

					return appSettings;
				}

				public void SaveToFile()
        {
            using (FileStream stream = new FileStream(@"C:\Users\user\Documents\AppSettings.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }
     }
}
