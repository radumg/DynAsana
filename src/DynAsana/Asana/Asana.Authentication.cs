using System;
using System.IO;
using System.Xml;
using DynamoServices;

namespace Asana
{
    public static class Authentication
    {
        public static string DefaultXMLPath => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "keys.xml"));
        public static string APIKEY { get; private set; }

        public static bool GetKeyFromXMLFile(string filePath)
        {
            XmlDocument xml = new XmlDocument();

            if(string.IsNullOrEmpty(filePath) || string.IsNullOrWhiteSpace(filePath)) throw new FileNotFoundException("Supplied filepath is empty or null.");
            if (!File.Exists(filePath)) throw new FileNotFoundException("Could not locate settings file to read API key.");

            try
            {
                xml.Load(filePath);
                APIKEY = xml.SelectSingleNode("Asana/token").InnerText;
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Could not locate the token in the XML file. Make sure it is under <Asana>" +
                    "   <token>TOKEN HERE</token>" +
                    "</Asana>");
            }
        }
    }
}
