using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class FileCheck : Form
    {
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
        public FileCheck()
        {
            // File Check
            if (!File.Exists(AppPath + "\\MetroFramework.dll"))
            {
                MessageBox.Show("Error: MetroFramework.dll is missing!" + Environment.NewLine + "Did you forget to put/extract it in the same folder?");
                Application.Exit();
            }
            else
            {
                // Run Form1
                Application.Run(new Form1());
            }
            Dispose();
        }
    }
}
