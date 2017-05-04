using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Asana
{
    public static class Authentication
    {
        public static readonly string xmlSettingsFile = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\..\\DynAsana\\keys.xml"));
        public static string APIKEY
        {
            get
            {
                XmlDocument xml = new XmlDocument();

                if (File.Exists(xmlSettingsFile))
                {
                    xml.Load(xmlSettingsFile);
                    return xml.SelectSingleNode("Asana/token").InnerText;
                }
                else throw new FileNotFoundException("Could not locate settings file to read API key.");
            }
        }
    }
}
