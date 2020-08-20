using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SuisVPK
{
    public partial class Form1 : Form
    {
		Timer timerCheck = new Timer();
        Dictionary<string, DateTime> fileDictionary = new Dictionary<string, DateTime>();
        ContextMenu contexTooltipMenu = new ContextMenu();
        public ConfigFile configFileRef = new ConfigFile();

        public Form1()
        {
            InitializeComponent();
            configFileRef = new ConfigFile();
            updateConfigInformation();

            contexTooltipMenu.MenuItems.Add("Update file list and VPK");
            contexTooltipMenu.MenuItems.Add("Cancel");
            contexTooltipMenu.MenuItems.Add("Exit");
		}

        #region FormEvents
        private void B_devpath_set_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TB_TranslationDir.Text))
            {
                configFileRef.translationDir = TB_TranslationDir.Text;
                configFileRef.saveSettings();
            }
            else
                MessageBox.Show("Selected folder doesn't seem to have vpk.exe in it. Please, choose the correct folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
		private void B_Watch_Click(object sender, EventArgs e)
        {

            if (configFileRef.translationDir != "" && Directory.Exists(configFileRef.translationDir) && configFileRef.translationDir != "")
            {
                fileDictionary.Clear();
                createList();
                this.WindowState = FormWindowState.Minimized;

                timerCheck.Tick += TimerCheck_Tick;
                timerCheck.Interval = 3000;
                timerCheck.Start();
            }
        }
        #region FormBehaviour
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                minizedIcon.Visible = true;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                minizedIcon.Visible = false;
                timerCheck.Stop();
            }
        }

        private void minizedIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void updateFilelistAndVPKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createList();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            if (filesAreDifferent())
            {
                RunCheck();
            }
        }

        private void RunCheck()
        {
            try
            {
                foreach (var file in fileDictionary)
                {
                    string[] lines = File.ReadAllLines(file.Key);
                    for (int lineID = 0; lineID < lines.Length; lineID++)
                    {
                        if (lineID == 0)
                        {
                            continue;
                        }

                        var split = lines[lineID].Split(new char[] { ',' }, 2);
                        var content = split[1];
                        content = content.Trim();
                        if ((content.StartsWith("\"") && !content.EndsWith("\"")) || (!content.StartsWith("\"") && content.EndsWith("\"")))
                            MessageBox.Show(string.Format("{0} contains a line with wrong qutations marks: {1}", file.Key, lineID + 1));
                        else if (content.StartsWith("\"") && content.EndsWith("\""))
                        {
                            //if (content.Contains(","))
                            //MessageBox.Show(string.Format("{0} contains a line with quotation marks, but no commas: {1}", file.Key, lineID + 1));
                        }
                        else
                        {
                            if (content.Contains(","))
                                MessageBox.Show(string.Format("{0} contains comma on line {1}", file.Key, lineID + 1));
                        }
                    }
                }
            }
            catch(FileLoadException f)
            {

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (minizedIcon.Visible)
            {
                minizedIcon.Visible = false;
                minizedIcon.Dispose();
            }
			configFileRef.saveSettings();
		}
        #endregion
        #endregion

        private void createList()
        {
            //Create a tree/list of directories
            string[] Directories = Directory.GetDirectories(configFileRef.translationDir, "*", SearchOption.AllDirectories);

            //Create empty list of files
            List<string> files = new List<string>();

            //Find all files in sub-directories
            foreach (string directory in Directories)
            {
                string[] tempFiles = Directory.GetFiles(directory);
                foreach (string file in tempFiles)
                {
                    files.Add(file);
                }
            }

            //Find all files in root directory
            string[] final_files = Directory.GetFiles(configFileRef.translationDir);
            foreach (string file in final_files)
            {
                files.Add(file);
            }

            //Check modified date for each file and write it into a dictionary struct
            fileDictionary.Clear();
            foreach (string file in files)
            {
				//We don't care about compiled caption files - they will be taken care during VPK build
				if(file.EndsWith(".csv"))
				{
					FileInfo f = new FileInfo(file);
					fileDictionary.Add(file, f.LastWriteTimeUtc);
				}
            }

            RunCheck();
        }

        /// <summary>
        /// Checks if the file has been modified.
        /// </summary>
        /// <returns>True if were modified, false if weren't.</returns>
        private bool filesAreDifferent()
        {
            foreach(string file in fileDictionary.Keys)
            {
                FileInfo f = new FileInfo(file);
                if(!f.Exists)
                {
                    createList();
                    return true;
                }
                else if(f.LastWriteTimeUtc != fileDictionary[file])
                {
                    fileDictionary[file] = f.LastWriteTimeUtc;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Updates displayed information with the ones from ConfigFile class.
        /// </summary>
        private void updateConfigInformation()
        {
            TB_TranslationDir.Text = configFileRef.translationDir;

        }
	}
}
