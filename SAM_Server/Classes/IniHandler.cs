using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SAM_Server
{
    class IniHandler
    {
        string defaultIniLocation;
        string iniFileName;
        List<string> defaultSettings;
        public IniHandler()
        {
            defaultIniLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/SAM/";
            iniFileName = "settings.ini";
            defaultSettings = new List<string>();
            #region Default Ini Settings
            defaultSettings.Add("socketPort: 8888");
            #endregion
        }

        public int GetSocketPort()
        {
            string fieldName = "socketPort: ";
            string str = IniReader(fieldName);
            int port = 8888;
            int.TryParse(str.Replace(fieldName, ""), out port);
            return port;
        }

        private bool IsIniThere()
        {
            if (Directory.Exists(defaultIniLocation))
                if (File.Exists(defaultIniLocation + iniFileName))
                    return true;
            return false;
        }

        private string IniReader(string lineContains)
        {
            if (IsIniThere())
            {
                StreamReader reader = new StreamReader(defaultIniLocation + iniFileName);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains(lineContains))
                    {
                        return line;
                    }
                }
            }
            else
            {
                CreateDefaultIni();
            }
            return null;
        }

        private void CreateDefaultIni()
        {
            if (!Directory.Exists(defaultIniLocation))
                Directory.CreateDirectory(defaultIniLocation);

            StreamWriter writer = new StreamWriter(defaultIniLocation + iniFileName);
            foreach(string defaultSetting in defaultSettings)
            {
                writer.WriteLine(defaultSetting);
            }
            writer.Close();
        }
    }
}
