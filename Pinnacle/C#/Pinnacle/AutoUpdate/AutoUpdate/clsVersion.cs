using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace AutoUpdate
{
    class clsVersion
    {
        public bool checkVersions()
        {
            string msiVersion = returnMSI_Version();
            string localVersion = returnLocalVersion();
            bool blMatch = false;

            if (msiVersion == localVersion)
            {
                blMatch = true;
            }
            else
            {
                blMatch = false;
            }
            return blMatch;
        }

        public void writeVersion()
        {
            string strVersion = returnMSI_Version();
            string strGuid = returnGUID();
            createFile(strVersion, strGuid);

        }

        private string returnMSI_Version()
        {
            string SQL = "SELECT `Value` FROM `Property` WHERE `Property`= 'ProductVersion'";
            return returnMsiInfo(SQL);
        }

        private string returnGUID()
        {
            string SQL = "SELECT `Value` FROM `Property` WHERE `Property`= 'ProductCode'";      
            return returnMsiInfo(SQL);
        }

        private string returnMsiInfo(string SQL)
        {
            Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
            WindowsInstaller.Installer Installer = (WindowsInstaller.Installer)Activator.CreateInstance(type);
            Activator.CreateInstance(type);

            WindowsInstaller.Database db = Installer.OpenDatabase(@"\\iomega-nas\Public1\IT Department\Pinnacle\Deploy\PinnacleSetup.msi", 0);
            WindowsInstaller.View dv = db.OpenView(SQL);
            WindowsInstaller.Record record = null;
            dv.Execute(record);

            record = dv.Fetch();

            return record.get_StringData(1).ToString();
        }

        private string returnLocalVersion()
        {
            string strVersion="";
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            strPath = strPath + "\\HTC\\Pinnacle\\Version.xml";
            bool blExists = File.Exists(strPath);
            
            if (blExists == true)
            {
                strVersion = readXML();   
            }

            return strVersion;
        }

        private string readXML()
        {
            string strValue="";
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            strPath = strPath + "\\HTC\\Pinnacle\\Version.xml";
            XmlReader xmlReader = XmlReader.Create(strPath);
            while (xmlReader.Read())
            {
                string strName = xmlReader.GetAttribute("Name");
                if (strName == "Pinnacle")
                    strValue = xmlReader.GetAttribute("Version");
            }

            xmlReader.Close();
            return strValue;
        }

        private void createFile(string strVersion, string strGuid)
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            strPath = strPath + "\\HTC\\Pinnacle\\Version.xml";

            using (XmlWriter xmlWriter = XmlWriter.Create(strPath))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Programs");
                xmlWriter.WriteStartElement("Program");
                    xmlWriter.WriteAttributeString("Name", "Pinnacle");
                    xmlWriter.WriteAttributeString("Version", strVersion);
                    xmlWriter.WriteAttributeString("Guid", strGuid);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
        }
        
    }
}
