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
        List<string> settings;
        public IniHandler()
        {
            defaultIniLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/SAM/";
            iniFileName = "settings.ini";
            settings = new List<string>();
            #region Default Ini Settings
            settings.Add("socketPort: 8888");
            #endregion
        }

        public int GetIntSetting(string setting)
        {
            string parseValue = "";
            int integer = 0;
            ReloadIni();
            foreach (string s in settings)
            {
                if (s.Contains(setting))
                {
                    parseValue = s;
                }
            }

            if (parseValue != "")
            {
                int.TryParse(parseValue.Replace(setting, "").Replace(": ", ""), out integer);
            }
            return integer;
        }

        public string GetStringSetting(string setting)
        {
            string parseValue = "";
            string value = "";
            ReloadIni();
            foreach (string s in settings)
            {
                if (s.Contains(setting))
                {
                    parseValue = s;
                }
            }

            if(parseValue != "")
            {
                value = parseValue.Replace(setting, "").Replace(": ", "");
            }
            return value;
        }

        public void ChangeSetting(string setting, string replaceValue)
        {
            int i = 0;
            foreach (string s in settings)
            {
                if(s.Contains(setting))
                {
                    settings[i] = setting + ": " + replaceValue;
                }
                i++;
            }
        }

        private bool IsIniThere()
        {
            if (Directory.Exists(defaultIniLocation))
                if (File.Exists(defaultIniLocation + iniFileName))
                    return true;
            return false;
        }

        private void ReloadIni()
        {
            if (IsIniThere())
            {
                StreamReader reader = new StreamReader(defaultIniLocation + iniFileName);
                settings.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    settings.Add(line);
                }
            }
            else
            {
                CreateDefaultIni();
            }
        }

        private void CreateDefaultIni()
        {
            if (!Directory.Exists(defaultIniLocation))
                Directory.CreateDirectory(defaultIniLocation);

            StreamWriter writer = new StreamWriter(defaultIniLocation + iniFileName);
            foreach(string defaultSetting in settings)
            {
                writer.WriteLine(defaultSetting);
            }
            writer.Close();
        }

        private void CreateIni()
        {
            File.Delete(defaultIniLocation + iniFileName);
            StreamWriter writer = new StreamWriter(defaultIniLocation + iniFileName);
            foreach (string defaultSetting in settings)
            {
                writer.WriteLine(defaultSetting);
            }
            writer.Close();
        }
    }
}
