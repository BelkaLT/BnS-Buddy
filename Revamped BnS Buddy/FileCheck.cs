﻿using Revamped_BnS_Buddy.Properties;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class FileCheck : Form
    {
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
        public bool AdminCheck = true;

        public FileCheck()
        {
            // Do File check and attempt creating if missing
            if (!File.Exists(AppPath + "\\MetroFramework.dll"))
            {
                try
                {
                    // Generate missing dependency & run
                    File.WriteAllBytes(AppPath + "\\MetroFramework.dll", Resources.MetroFramework);
                }
                catch { MessageBox.Show("Failed to generate MetroFramework.dll, try running as admin."); KillApp(); }
            }
            // Get settings and check if needed by BnS Buddy
            if (File.Exists(AppPath + "\\Settings.ini"))
            {
                // Check Quick Settings.ini
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("admincheck = false"))
                {
                    AdminCheck = false;
                }
            }
            // Run admin check only if needed
            if (IsAdministrator() == false && AdminCheck == true)
            {
                MessageBox.Show("Please run as Admin", "Error: Not admin", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                KillApp();
            }
            else // Skip trough check OR continue if valid
            {
                // Run
                Application.Run(new Form1());
            }
            Dispose();
        }

        public static bool IsAdministrator()
        {
            // Direct admin check
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void KillApp()
        {
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }
    }
}