using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuisVPK
{
    public class ConfigFile
    {
        const string settingsFile = "confg.cfg";
        public string translationDir { get; set; }


		public ConfigFile()
        {
            if (File.Exists(settingsFile))
                loadSettings();
        }


        #region SaveLoad
        private void loadSettings()
        {
            StreamReader SR = new StreamReader(settingsFile);
            string line = "";
            while ((line = SR.ReadLine()) != null)
            {
                if (line.StartsWith("TranslationDir:"))
                {
                    line = line.Split(new char[] { ':' }, 2)[1];
                    translationDir = line;
                }
			}
            SR.Close();
            SR.Dispose();
        }

        private bool parseBool(string text, bool defaultValue = false)
        {
            bool val = defaultValue;
            if(bool.TryParse(text, out val))
            {
                return val;
            }
            else
                return defaultValue;
        }

        public void saveSettings()
        {
			File.WriteAllText(settingsFile, "TranslationDir:" + translationDir);
        }
        #endregion
    }
}
