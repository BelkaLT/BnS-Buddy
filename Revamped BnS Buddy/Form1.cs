﻿using FastColoredTextBoxNS;
using Ionic.Zlib;
using Microsoft.Win32;
using Mono.Math;
using Revamped_BnS_Buddy.Properties;
using SharpCompress;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml;

namespace Revamped_BnS_Buddy
{
    // Things marked with "HEY!" and "here!" Are unfinished and to be completed :)
    public unsafe partial class Form1 : MetroFramework.Forms.MetroForm
    {
        // static form
        public static Form1 CurrentForm;

        //
        public string LauncherPath = "\\bin";

        public string LauncherPath64 = "\\bin64";
        public string regionIDValue = "";
        public string TempPath = Path.GetTempPath();
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
        public string mine = Process.GetCurrentProcess().Id.ToString();
        public string IP = "0.0.0.0";
        public string FinalToken = "";
        public string regionID = "0";
        public string languageID = "English";
        public string LaunchPath = "";
        public string NoTextureStreaming = "";
        public string Unattended = "";
        public string ms = " ms";
        public string s = "";
        public int ping = 0;
        public string FullPath = "";
        public string DataPath = "";
        public string FullBackupPath = "";
        public string DatPath = "";
        public string RegPath = "";
        public string RegPathlol = "";
        public string GamePath = "";
        public string defaultclient = "";
        public string TaiwanPath = "";
        public string CustomGamePath = "";
        public string CustomClientPath = "";
        public string DefaultValues = "unattended = false" + Environment.NewLine + "notexturestreaming = false" + Environment.NewLine + "savelogs = false" + Environment.NewLine + "showlogs = true" + Environment.NewLine + "variables = false" + Environment.NewLine + "tooltips = true" + Environment.NewLine + "customgame = false" + Environment.NewLine + "customclient = false" + Environment.NewLine + "admincheck = true" + Environment.NewLine + "ncsoftlogin = false" + Environment.NewLine + "showdonate = true" + Environment.NewLine + "minimize = true" + Environment.NewLine + "launcherlogs = false" + Environment.NewLine + "modmanlogs = false" + Environment.NewLine + "customclientpath = " + Environment.NewLine + "customgamepath = " + Environment.NewLine + "updatechecker = true" + Environment.NewLine + "pingchecker = true" + Environment.NewLine + "gamekiller = true" + Environment.NewLine + "useallcores = false" + Environment.NewLine + "arguements = " + Environment.NewLine + "prtime = 500" + Environment.NewLine + "autoupdate = true" + Environment.NewLine + "firsttime = true" + Environment.NewLine + "default = " + Environment.NewLine + "defaultset = false" + Environment.NewLine + "defaultclient = " + Environment.NewLine + "priority = Normal" + Environment.NewLine + "modfolder = " + Environment.NewLine + "modfolderset = false" + Environment.NewLine + "rememberme = false" + Environment.NewLine + "automemorycleanup = false" + Environment.NewLine + "langset = false" + Environment.NewLine + "langpath = " + Environment.NewLine + "boostprocess = true" + Environment.NewLine + "cleanint = OFF" + Environment.NewLine + "uniquepass = " + Environment.NewLine + "gcdshow = false" + Environment.NewLine + "igpshow = false" + Environment.NewLine + "autologin = false" + Environment.NewLine + "usercountcheck = true" + Environment.NewLine + "showcount = true" + Environment.NewLine + "customclientname = " + Environment.NewLine + "buddycolor = Blue" + Environment.NewLine + "lastserver = ";
        public string ActiveDataFile = "";
        public string XmlSavePath = "";
        public string NewDat = "";
        public string UseAllCores = "";
        public string LoadingSplash = "";
        public string langremembered = "";
        public bool UseToken = false;
        public bool Backup = false;
        public bool PathFound = true;
        public bool logs_active = true;
        public bool GameStarted = false;
        public bool SaveLogs = false;
        public bool LauncherLogs = false;
        public bool ModManLogs = false;
        public bool AdminCheck = true;
        public bool AllowMinimize = true;
        public bool ShowLogs = true;
        public bool CustomGameSet = false;
        public bool CustomClientSet = false;
        public bool GameKiller = true;
        public bool UpdateChecker = true;
        public bool PingChecker = true;
        public bool nonmodded = false;
        public bool AutoUpdate = true;
        public bool FirstTime = true;
        public bool readyclient = false;
        public bool MultipleInstallationFound = false;
        public bool AutoClean = false;
        public bool KoreanTestInstalled = false;
        public string online = "";
        public string offline = "";
        public int bad = Convert.ToInt32("120");
        public int medium = Convert.ToInt32("65");
        public int good = Convert.ToInt32("1");
        public int wakeywakey = 500;
        public int appuniqueid = 0;
        public BackgroundWorker bw1;
        public BackgroundWorker bw2;
        public BackgroundWorker bw3;
        public BackgroundWorker bwcount;
        public BackgroundWorker bnsdat;
        public BackgroundWorker bnsdatc;
        public Form2 s2;

        // Seperator
        public Form1()
        {
            /* Set Private AppPath */
            Prompt.AppPath = AppPath;
            /* Static Form */
            CurrentForm = this;
            /* Initialize Form */
            InitializeComponent();
            /* Set Unhandled Exception Handler */
            Unhandler();
            /* Check Security */
            ValidateBuddy();
            /* Generate Unique Key for Special Feature! */
            SetUniqueKey();
            /* Check Settings Tab */
            CheckTab();
            /* First time user setting */
            FirstTimeUse();
            /* Splash to hide loading */
            SplashScreen();
            /* Kill Game if running */
            KillGame();
            //////////////////
            //  Seperator   //
            // Launcher Tab //
            //////////////////
            // 1: Check Registry for Dir(Game) | 2: Auto browser and Set Path to CookedPC | 3: Set Global Variables
            try
            {
                if (CustomGameSet == false)
                {
                    BnSFolder();
                }
            }
            catch (Exception e) { Prompt.Popup(e.ToString()); }
            // Check backup for Loading Screen
            CheckBackup();
            // 1: Check Registry for Dir(Client) | 2: Auto ini reader to Path | 3: Set Global Variables
            try
            {
                if (CustomClientSet == false)
                {
                    CheckServer();
                }
            }
            catch (Exception e) { Prompt.Popup(e.ToString()); }
            VerifySettings();
            ///////////////////////
            //     Seperator     //
            // Splash Screen Tab //
            ///////////////////////
            GetPaths();
            Verify();
            InitializeSplash();
            /////////////////////
            //    Seperator    //
            // Mod Manager Tab //
            /////////////////////
            InitializeManager();
            GetPath();
            JsonManager();
            PopulateTreeView(FullModPathMan);
            VerifyUsage();
            ////////////////////
            //    Seperator   //
            // Dat Editor Tab //
            ////////////////////
            CleanMess(); /* Skip Cleaning */
            CleanOtherMess(); /* Skip Cleaning */
            DefaultDatValues();
            CreateDatPaths();
            ////////////////////
            //    Seperator   //
            //   Addons Tab   //
            ////////////////////
            InitializeAddons();
            ///////////////
            // Seperator //
            //   MISCS   //
            ///////////////
            // Launching Details
            Details();
            // Fix .Dat Sizes
            FixSizes();
            // Form Ready!
            Task.Delay(1000);
            EnableForm1();
        }

        private void metroButton35_Click(object sender, EventArgs e)
        {
            //metroTabControl1.TabPages.RemoveAt(9);
            metroTabControl1.SelectTab(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Ads OnClick
            Process.Start("https://www.exitlag.com/refer/443658");
        }

        private void Unhandler()
        {
            // Ignore when debugging with VS
            if (!AppDomain.CurrentDomain.FriendlyName.Contains("vshost.exe"))
            {
                // UI Graphical Issues.
                Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);
                // Add the event handler for handling non-UI thread exceptions to the event.
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string removeuser = ex.Message.Replace(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "[censored]");
                Prompt.Popup("An application error occurred. Please contact Endless and report this error!" + Environment.NewLine + "Error: " + removeuser);
            }
            catch (Exception exc)
            {
                try
                {
                    string removeuser = exc.Message.Replace(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "[censored]");
                    Prompt.Popup("Fatal Non-UI Error, can't proceed." + Environment.NewLine + "Reason: " + removeuser);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                string removeuser = t.Exception.ToString().Replace(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "[censored]");
                Prompt.Popup("Report this error to Endless along with a screenshot, thank you!" + Environment.NewLine + removeuser);
            }
            catch
            {
                try
                {
                    Prompt.Popup("Fatal Windows Forms Error, can't proceed.");
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PerformClose();
        }

        private void ConfigureContext()
        {
            // Ini Context
            ContextMenu = new System.Windows.Forms.ContextMenu();
            // Ini Items
            System.Windows.Forms.MenuItem menuItem1 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem2 = new System.Windows.Forms.MenuItem();
            // Add Item to Context
            ContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1, menuItem2 });
            // Configure Items
            menuItem1.Index = 1;
            menuItem1.Text = "Exit BnS Buddy";
            menuItem1.Click += new EventHandler(metroButton14_Click);
            menuItem2.Index = 0;
            menuItem2.Text = "Restore BnS Buddy";
            menuItem2.Click += new EventHandler(NotifAction_Mask);
            // Apply Context Menu
            notifyIcon1.ContextMenu = ContextMenu;
        }

        private void NotifAction_Mask(object sender, EventArgs e)
        {
            NotifAction();
        }

        public void StartupBuddy()
        {
            Process BnSBuddy = new Process();
            BnSBuddy.StartInfo.FileName = AppPath + "\\BnS Buddy.exe";
            BnSBuddy.Start();
            // Kill current app
            KillApp();
        }

        private bool UserCountCheck = true;
        private bool manualcount = false;

        private void Get_Count()
        {
            // Manual Refresh
            if (manualcount)
            {
                string isitshown = "false";
                if (!UserCountCheck)
                {
                    isitshown = "true";
                }
                // Check, Validate & Notify
                using (WebClient client = new WebClient())
                {
                    // Check
                    try
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        client.Headers.Add("User-Agent", "BnSBuddy");
                        string str = client.DownloadString("https://bnsbuddy.com/count/usercount.php?hidden=" + isitshown);
                        if (str.All(System.Char.IsDigit))
                        {
                            metroLabel94.Text = str;
                        }
                        else
                        {
                            metroLabel94.Text = "Offline";
                        }
                    }
                    catch
                    {
                        metroLabel94.Text = "Error";
                    }
                }
                manualcount = false;
            }
            // Run auto check
            bwcount = new BackgroundWorker();
            bwcount.WorkerSupportsCancellation = true;
            bwcount.WorkerReportsProgress = true;
            bwcount.DoWork += new DoWorkEventHandler(bwcount_dowork);
            if (!bwcount.IsBusy)
            {
                bwcount.RunWorkerAsync();
            }
        }

        public void bwcount_dowork(object Sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            BackgroundWorker worker = (BackgroundWorker)Sender;
            while (!worker.CancellationPending)
            {
                // Loop Progress
                worker.ReportProgress(0);
                Thread.Sleep(300000);
                string isitshown = "false";
                if (!UserCountCheck)
                {
                    isitshown = "true";
                }
                // Check, Validate & Notify
                using (WebClient client = new WebClient())
                {
                    // Check
                    try
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        client.Headers.Add("User-Agent", "BnSBuddy");
                        string str = client.DownloadString("https://bnsbuddy.com/count/usercount.php?hidden=" + isitshown);
                        if (str.All(System.Char.IsDigit))
                        {
                            metroLabel94.Text = str;
                        }
                        else
                        {
                            metroLabel94.Text = "Offline";
                        }
                    }
                    catch
                    {
                        metroLabel94.Text = "Error";
                    }
                }
            }
        }

        private void Form1_Gained(object e, EventArgs a)
        {
            /*
            if (AppStarted) {
                Themer.Style = MetroFramework.MetroColorStyle.Default;
            }
            */
        }

        private void Form1_Lost(object e, EventArgs a)
        {
            //Themer.Style = MetroFramework.MetroColorStyle.Orange;
        }

        private void ValidateBuddy()
        {
            // Get BnS Buddy's Unique Serial Number
            X509Certificate certificate = null;
            try
            {
                certificate = X509Certificate2.CreateFromSignedFile(Application.ExecutablePath);
                int tmp = certificate.GetHashCode();
                if (tmp.ToString() != "1307602086") { Prompt.Popup("BnS Buddy signature does not match! Please Delete and get a fresh copy."); KillApp(); }
            }
            catch { Prompt.Popup("BnS Buddy is not signed! Please Delete and get a fresh copy."); KillApp(); }
        }

        public void KillApp()
        {
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }

        public void FirstTimeUse()
        {
            if (FirstTime == true)
            {
                DialogResult dialogResult = Prompt.FirstTimeUse();
                if (dialogResult == DialogResult.Yes)
                {
                    var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                    fileContents = fileContents.Replace("firsttime = true", "firsttime = false");
                    System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = false"))
                    {
                        fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("autoupdate = false", "autoupdate = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                    fileContents = fileContents.Replace("firsttime = true", "firsttime = false");
                    System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = true"))
                    {
                        fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("autoupdate = true", "autoupdate = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                }
                else { /* skip */ }
            }
        }

        private bool Reg64 = false;
        private Dictionary<string, string> Installs = new Dictionary<string, string>();

        public void GetRegDir()
        {
            // Step 1
            // Get Dir
            AddTextLog("Reading Registry...");
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\Wow6432Node\NCWest\BnS\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Reg64 = true;
                    Installs.Add("NA/EU", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\NCWest\BnS\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Installs.Add("NA/EU", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\NCTaiwan\TWBNS22\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Installs.Add("Taiwan", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\Wow6432Node\NCTaiwan\TWBNS22\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Reg64 = true;
                    Installs.Add("Taiwan", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\PlayNC\BNS_JPN\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Installs.Add("Japanese", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\Wow6432Node\PlayNC\BNS_JPN\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Reg64 = true;
                    Installs.Add("Japanese", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\plaync\BNS_KOR\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Installs.Add("Korean", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\plaync\BNS_KOR_TEST\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Installs.Add("Korean Test", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\Wow6432Node\plaync\BNS_KOR\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Reg64 = true;
                    Installs.Add("Korean", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\Wow6432Node\plaync\BNS_KOR_TEST\");
                if (regKey != null)
                {
                    string unique = regKey.GetValue("BaseDir").ToString();
                    if (workedREG == false)
                    {
                        RegPath = regKey.GetValue("BaseDir").ToString();
                    }
                    AddTextLog(unique);
                    AddTextLog("Reg Key Valid!");
                    workedREG = true;
                    Reg64 = true;
                    Installs.Add("Korean Test", unique);
                }
            }
            catch { AddTextLog("Null Value of RegKey"); }

            if (workedREG == false)
            {
                RegPath = null;
                AddTextLog("Error: RegKey = " + RegPath);
            }
            if (Installs.Count > 1)
            {
                string promptValue = "";
                if (MultipleInstallationFound == false)
                {
                    AddTextLog("Multiple Installations Found!");
                    promptValue = Prompt.MultipleInstallation("Multiple installations of BnS has been found!" + Environment.NewLine + "Which version would you like to use?", "Warning!", Installs);
                    RegPath = promptValue;
                    SaveDefault(promptValue);
                    Prompt.Popup("Notice: You can always remove the default installation in settings.");
                }
                if (promptValue != "" && Installs.ContainsKey("Korean Test"))
                {
                    if (promptValue == Installs["Korean Test"])
                    {
                        KoreanTestInstalled = true;
                    }
                    else
                    {
                        KoreanTestInstalled = false;
                    }
                }
            }
        }

        public void SaveDefaultClient(string val)
        {
            try
            {
                // Do defaultclient = type
                lineChanger("defaultclient = " + val, @AppPath + "\\Settings.ini", 27);
                // Change val
                metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact(val);
                // Done
            }
            catch { AddTextLog("Error: Could not save default client!"); }
        }

        public void SaveDefault(string val)
        {
            try
            {
                // Do defaultset = true
                var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                fileContents = fileContents.Replace("defaultset = false", "defaultset = true");
                System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                // Do default = path
                lineChanger("default = " + val, @AppPath + "\\Settings.ini", 25);
                // Change label val
                metroLabel48.Text = val;
                // Done
            }
            catch { AddTextLog("Error: Could not save default installation!"); }
        }

        public static class Prompt
        {
            public static string AppPath { get; internal set; }

            public static string MultipleLang(string Description, string Title, Dictionary<int, string> languages)
            {
                // Get Color
                string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(43).Take(1).First().Replace("buddycolor = ", "");
                // Continue
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = Title,
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Left = 5, Top = 20, Text = Description, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroComboBox combobox = new MetroFramework.Controls.MetroComboBox() { Left = 5, Top = 70, Width = 270, Theme = MetroFramework.MetroThemeStyle.Dark, ImeMode = ImeMode.NoControl };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "Ok", Left = 5, Width = 100, Top = 100, DialogResult = DialogResult.OK, Theme = MetroFramework.MetroThemeStyle.Dark };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                combobox.Text = "Choose Game Language";
                // add default if none chosen
                combobox.Items.Add("Choose Game Language");
                combobox.SelectedIndex = 0;
                // continue generation
                for (int i = 0; languages.Count > i; i++)
                {
                    combobox.Items.Add(languages[i]);
                }
                prompt.Controls.Add(combobox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                // Set style
                if (line == "Black")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (line == "Red")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Red;
                }
                else if (line == "Purple")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Purple;
                }
                else if (line == "Pink")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Pink;
                }
                else if (line == "Orange")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (line == "Magenta")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Magenta;
                }
                else if (line == "Lime")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Lime;
                }
                else if (line == "Green")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Green;
                }
                else if (line == "Default")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Default;
                }
                else if (line == "Brown")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Brown;
                }
                else if (line == "Blue")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else if (line == "Silver")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Silver;
                }
                else if (line == "Teal")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Teal;
                }
                else if (line == "White")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.White;
                }
                else if (line == "Yellow")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Yellow;
                }
                // Prompt
                prompt.ShowDialog();
                if (combobox.SelectedItem.ToString() == "Choose Game Language")
                {
                    combobox.SelectedIndex = 1;
                }
                return combobox.SelectedItem.ToString();
            }

            public static string MultipleInstallation(string Description, string Title, Dictionary<string, string> installs)
            {
                // Get Color
                string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(43).Take(1).First().Replace("buddycolor = ", "");
                // Continue
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = Title,
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Left = 5, Top = 20, Text = Description, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroComboBox combobox = new MetroFramework.Controls.MetroComboBox() { Left = 5, Top = 70, Width = 270, Theme = MetroFramework.MetroThemeStyle.Dark, ImeMode = ImeMode.NoControl };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "Ok", Left = 5, Width = 100, Top = 100, DialogResult = DialogResult.OK, Theme = MetroFramework.MetroThemeStyle.Dark };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                combobox.Text = "Choose Default Installation";
                if (installs.ContainsKey("NA/EU"))
                {
                    if (installs["NA/EU"].ToString().Length > 1)
                    {
                        combobox.Items.Add("NA/EU");
                    }
                }
                if (installs.ContainsKey("Taiwan"))
                {
                    if (installs["Taiwan"].ToString().Length > 1)
                    {
                        combobox.Items.Add("Taiwan");
                    }
                }
                if (installs.ContainsKey("Japanese"))
                {
                    if (installs["Japanese"].ToString().Length > 1)
                    {
                        combobox.Items.Add("Japanese");
                    }
                }
                if (installs.ContainsKey("Korean"))
                {
                    if (installs["Korean"].ToString().Length > 1)
                    {
                        combobox.Items.Add("Korean");
                    }
                }
                if (installs.ContainsKey("Korean Test"))
                {
                    if (installs["Korean Test"].ToString().Length > 1)
                    {
                        combobox.Items.Add("Korean Test");
                    }
                }
                prompt.Controls.Add(combobox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                // Set style
                if (line == "Black")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (line == "Red")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Red;
                }
                else if (line == "Purple")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Purple;
                }
                else if (line == "Pink")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Pink;
                }
                else if (line == "Orange")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (line == "Magenta")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Magenta;
                }
                else if (line == "Lime")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Lime;
                }
                else if (line == "Green")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Green;
                }
                else if (line == "Default")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Default;
                }
                else if (line == "Brown")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Brown;
                }
                else if (line == "Blue")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else if (line == "Silver")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Silver;
                }
                else if (line == "Teal")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Teal;
                }
                else if (line == "White")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.White;
                }
                else if (line == "Yellow")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Yellow;
                }
                // Prompt
                prompt.ShowDialog();
                if (combobox.SelectedItem.ToString() == "Choose Default Installation")
                {
                    combobox.SelectedIndex = 1;
                }
                return installs[combobox.SelectedItem.ToString()].ToString();
            }

            public static void Popup(string Message)
            {
                // Get Color
                string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(43).Take(1).First().Replace("buddycolor = ", "");
                // Continue
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    Style = MetroFramework.MetroColorStyle.Black,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { AutoSize = true, Left = 5, Top = 20, Text = Message, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "Ok", Left = 5, Width = 100, Top = 130, DialogResult = DialogResult.OK, Theme = MetroFramework.MetroThemeStyle.Dark };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                // Set style
                if (line == "Black")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (line == "Red")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Red;
                }
                else if (line == "Purple")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Purple;
                }
                else if (line == "Pink")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Pink;
                }
                else if (line == "Orange")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (line == "Magenta")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Magenta;
                }
                else if (line == "Lime")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Lime;
                }
                else if (line == "Green")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Green;
                }
                else if (line == "Default")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Default;
                }
                else if (line == "Brown")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Brown;
                }
                else if (line == "Blue")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else if (line == "Silver")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Silver;
                }
                else if (line == "Teal")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Teal;
                }
                else if (line == "White")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.White;
                }
                else if (line == "Yellow")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Yellow;
                }
                // Prompt
                prompt.ShowDialog();
            }

            public static DialogResult FirstTimeUse()
            {
                // Get Color
                string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(43).Take(1).First().Replace("buddycolor = ", "");
                // Continue
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Text = "Would you like to run automatic updates for each run?", AutoSize = true, Left = 5, Top = 20, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "Yes", Left = 5, Width = 100, Top = 100, DialogResult = DialogResult.Yes, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton nobutton = new MetroFramework.Controls.MetroButton() { Text = "No", Left = 125, Width = 100, Top = 100, DialogResult = DialogResult.No, Theme = MetroFramework.MetroThemeStyle.Dark };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(nobutton);
                prompt.AcceptButton = confirmation;
                prompt.AcceptButton = nobutton;
                // Set style
                if (line == "Black")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (line == "Red")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Red;
                }
                else if (line == "Purple")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Purple;
                }
                else if (line == "Pink")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Pink;
                }
                else if (line == "Orange")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (line == "Magenta")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Magenta;
                }
                else if (line == "Lime")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Lime;
                }
                else if (line == "Green")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Green;
                }
                else if (line == "Default")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Default;
                }
                else if (line == "Brown")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Brown;
                }
                else if (line == "Blue")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else if (line == "Silver")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Silver;
                }
                else if (line == "Teal")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Teal;
                }
                else if (line == "White")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.White;
                }
                else if (line == "Yellow")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Yellow;
                }
                // Prompt
                DialogResult test = prompt.ShowDialog();
                return test;
            }

            public static DialogResult RestoreConfigAsk()
            {
                // Get Color
                string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(43).Take(1).First().Replace("buddycolor = ", "");
                // Continue
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Text = "You are about to restore configuration files back to normal" + Environment.NewLine + "Please make sure the files are dated from this patch." + Environment.NewLine + "Are you willing to continue?", AutoSize = true, Left = 5, Top = 20, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "Yes", Left = 5, Width = 100, Top = 100, DialogResult = DialogResult.Yes, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton nobutton = new MetroFramework.Controls.MetroButton() { Text = "No", Left = 125, Width = 100, Top = 100, DialogResult = DialogResult.No, Theme = MetroFramework.MetroThemeStyle.Dark };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(nobutton);
                prompt.AcceptButton = confirmation;
                prompt.AcceptButton = nobutton;
                // Set style
                if (line == "Black")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (line == "Red")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Red;
                }
                else if (line == "Purple")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Purple;
                }
                else if (line == "Pink")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Pink;
                }
                else if (line == "Orange")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (line == "Magenta")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Magenta;
                }
                else if (line == "Lime")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Lime;
                }
                else if (line == "Green")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Green;
                }
                else if (line == "Default")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Default;
                }
                else if (line == "Brown")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Brown;
                }
                else if (line == "Blue")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else if (line == "Silver")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Silver;
                }
                else if (line == "Teal")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Teal;
                }
                else if (line == "White")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.White;
                }
                else if (line == "Yellow")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Yellow;
                }
                // Prompt
                DialogResult test = prompt.ShowDialog();
                return test;
            }

            public static DialogResult MultipleClient()
            {
                // Get Color
                string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(43).Take(1).First().Replace("buddycolor = ", "");
                // Continue
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Text = "32bit and 64bit clients were found. Which would you like to use by default?", AutoSize = true, Left = 5, Top = 20, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "32 bit", Left = 5, Width = 100, Top = 100, DialogResult = DialogResult.Yes, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton nobutton = new MetroFramework.Controls.MetroButton() { Text = "64 bit", Left = 125, Width = 100, Top = 100, DialogResult = DialogResult.No, Theme = MetroFramework.MetroThemeStyle.Dark };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(nobutton);
                prompt.AcceptButton = confirmation;
                prompt.AcceptButton = nobutton;
                // Set style
                if (line == "Black")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (line == "Red")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Red;
                }
                else if (line == "Purple")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Purple;
                }
                else if (line == "Pink")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Pink;
                }
                else if (line == "Orange")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (line == "Magenta")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Magenta;
                }
                else if (line == "Lime")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Lime;
                }
                else if (line == "Green")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Green;
                }
                else if (line == "Default")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Default;
                }
                else if (line == "Brown")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Brown;
                }
                else if (line == "Blue")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else if (line == "Silver")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Silver;
                }
                else if (line == "Teal")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Teal;
                }
                else if (line == "White")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.White;
                }
                else if (line == "Yellow")
                {
                    prompt.Style = MetroFramework.MetroColorStyle.Yellow;
                }
                // Prompt
                DialogResult test = prompt.ShowDialog();
                return test;
            }
        }

        private void metroComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox5.SelectedItem.ToString() == "English")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("English");
            }
            else
            if (metroComboBox5.SelectedItem.ToString() == "French")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("French");
            }
            else
            if (metroComboBox5.SelectedItem.ToString() == "German")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("German");
            }
            else
            if (metroComboBox5.SelectedItem.ToString() == "Taiwan")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Taiwan");
            }
            else
            if (metroComboBox5.SelectedItem.ToString() == "Japanese")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Japanese");
            }
            else
            if (metroComboBox5.SelectedItem.ToString() == "Portuguese")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Portuguese");
            }
            else
            if (metroComboBox5.SelectedItem.ToString() == "Korean")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Korean");
            }
            else
            {
                metroComboBox2.SelectedItem = metroComboBox5.SelectedItem;
            }
            // Change default
            SetDefaultLanguage(metroComboBox5.SelectedItem.ToString());
        }

        private string autofinder = "";
        private string autocook = "";
        private bool Korean = false;
        private bool MultipleLangFound = false;
        private Dictionary<int, string> LangDictionary = new Dictionary<int, string>();

        public void AutoDirFinder()
        {
            // Step 2
            string AutoFoundModPath = "";
            if (Directory.Exists(RegPath + "\\contents\\Local"))
            {
                DirectoryInfo path = new DirectoryInfo(RegPath + "\\contents\\Local");
                foreach (DirectoryInfo subdir in path.GetDirectories())
                {
                    string subbeddir = Path.GetFileName(subdir.ToString());
                    if (Directory.Exists(RegPath + "\\contents\\Local\\" + subbeddir + "\\data"))
                    {
                        autofinder = subbeddir;
                        DirectoryInfo path2 = new DirectoryInfo(RegPath + "\\contents\\Local\\" + autofinder);
                        int ild = 0;
                        foreach (DirectoryInfo subdir2 in path2.GetDirectories())
                        {
                            string subbeddir2 = Path.GetFileName(subdir2.ToString());
                            if (Path.GetFileName(subbeddir2) != "korean")
                            {
                                if (Directory.Exists(RegPath + "\\contents\\Local\\" + autofinder + "\\" + subbeddir2 + "\\CookedPC"))
                                {
                                    if (MultipleLangFound == false)
                                    {
                                        // Add Lang to Dictionary
                                        if (!LangDictionary.ContainsValue(subbeddir2) && !LangDictionary.ContainsKey(ild))
                                        {
                                            LangDictionary.Add(ild, subbeddir2);
                                            // Increase int
                                            ild++;
                                        }
                                        // Set value for found path
                                        autocook = subbeddir2;
                                    }
                                }
                            }
                            else { autocook = subbeddir2; }
                        }
                    }
                }

                // Ignore if custom changed
                //if (!ignorechange)
                //{
                // Check for multiple lang
                if (LangDictionary.Count > 1 && MultipleLangFound == false)
                {
                    bool defaultlangisset = false;
                    // Add langs to settings page 3
                    for (int i = 0; LangDictionary.Count > i; i++)
                    {
                        metroComboBox5.Items.Add(LangDictionary[i]);
                    }
                    // Check if default value is set
                    for (int iop = 0; metroComboBox5.Items.Count > iop; iop++)
                    {
                        if (metroComboBox5.Items[iop].ToString() == langremembered)
                        {
                            defaultlangisset = true;
                            autocook = langremembered;
                            metroComboBox5.SelectedIndex = metroComboBox5.FindString(langremembered);
                            MultipleLangFound = true;
                        }
                    }
                    // Continue if not set
                    if (defaultlangisset == false)
                    {
                        string promptValue = Prompt.MultipleLang("Multiple languages of BnS has been found!" + Environment.NewLine + "Which language would you like to use?", "Warning!", LangDictionary);
                        autocook = promptValue;
                        SetDefaultLanguage(promptValue);
                        MultipleLangFound = true;
                        // since we got a new default, let's make sure it's set on true
                        if (File.ReadAllText(@AppPath + "\\Settings.ini").Contains("langset = false"))
                        {
                            var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                            fileContents2 = fileContents2.Replace("langset = false", "langset = true");
                            System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
                        }
                    }
                    metroLabel56.Text = RegPath;
                }
                // } ignorechange = false;
                // Check for korean
                if (autocook != "Korean" && autofinder != "NCSoft")
                {
                    AutoFoundModPath = RegPath + "\\contents\\Local\\" + autofinder + "\\" + autocook + "\\CookedPC";
                    // FIX PATH
                    AutoFoundModPath = AutoFoundModPath.Replace(@"\\", @"\");
                    // CONTINUE
                }
                else
                {
                    if (autocook == "")
                    {
                        autocook = "Korean";
                    }
                    AutoFoundModPath = RegPath + "\\contents\\Local\\" + autofinder + "\\" + autocook + "\\";
                    // FIX PATH
                    AutoFoundModPath = AutoFoundModPath.Replace(@"\\", @"\");
                    // CONTINUE
                }
            }

            if (Directory.Exists(AutoFoundModPath))
            {
                // Permanent
                string langpath = "";
                // Temporary
                string orig = "";
                string tmp = "";
                // Default
                GamePath = AutoFoundModPath;
                try
                {
                    //////////////////////////
                    AddTextLog("Path Found!");
                    //////////////////////////
                    //   Find Lang of game  //
                    //////////////////////////
                    // FIX PATH
                    GamePath = GamePath.Replace(@"\\", @"\");
                    // CONTINUE
                    orig = GamePath;
                    if (!orig.ToString().Contains("korean"))
                    {
                        tmp = Path.GetFileName(orig.Replace("\\CookedPC", "")).ToString();
                    }
                    else
                    {
                        tmp = Path.GetFileName(orig.ToString());
                    }
                    langpath = tmp;
                    //////////////////////////
                    AddTextLog("Lang Found!");
                    //////////////////////////
                    //    Set after Found   //
                    //////////////////////////
                }
                catch (Exception e) { Prompt.Popup("Error: Couldnt find game Language & it's container." + Environment.NewLine + e.ToString()); }
                if (langpath == "ENGLISH")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("English");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (langpath == "FRENCH")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("French");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (langpath == "GERMAN")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("German");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (langpath == "CHINESET")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Taiwan");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (langpath == "JAPANESE")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Japanese");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (langpath == "BPORTUGUESE")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Portuguese");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (langpath == "korean" || autocook == "korean")
                {
                    if (!Korean)
                    {
                        FullPath = GamePath;
                        // Fix path aka go back 3 folder
                        var tmppath = "";
                        tmppath = Directory.GetParent(FullPath).ToString();
                        tmppath = Directory.GetParent(tmppath).ToString();
                        tmppath = Directory.GetParent(tmppath).ToString();
                        tmppath = Directory.GetParent(tmppath).ToString() + "\\bns\\CookedPC";
                        FullPath = tmppath.ToString();
                    }
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Korean");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = true;
                }
                else
                {
                    Korean = false;
                    FullPath = GamePath;
                    AddTextLog("Lang/Path Unknown!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    // Add custom option since we don't know what it is.
                    if (langpath.Length > 0)
                    {
                        metroComboBox2.Items.Add(langpath);
                        metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact(langpath);
                    }
                    else
                    {
                        metroComboBox2.Items.Add(autocook);
                        metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact(autocook);
                    }
                    // End adding
                }
                if (PathFound == true)
                {
                    FullBackupPath = GamePath.Replace("\\" + langpath + "\\CookedPC", "\\data\\backup");
                    if (!Directory.Exists(FullBackupPath)) { Directory.CreateDirectory(FullBackupPath); }
                }
            }
            else
            {
                PathFound = false;
                AddTextLog("Error: Path Not Found!");
                Prompt.Popup("Please select the BnS folder name in your Blade and Soul installation!");
                AddTextLog("Opening Dialog...");
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.Description = "Select BnS folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(dlg.SelectedPath + "\\bin\\Client.exe") || File.Exists(dlg.SelectedPath + "\\bin64\\Client.exe"))
                        {
                            RegPath = dlg.SelectedPath;
                            AddTextLog("Path Inputed Found!");
                            // Auto Dir Finder
                            AutoDirFinder();
                            metroButton1.Enabled = true;
                            PathFound = true;
                            metroToggle1.Enabled = true;
                        }
                        else
                        {
                            AddTextLog("BnS Folder Not Found!");
                        }
                    }
                    else
                    {
                        Prompt.Popup("Error: Cancelled operation!");
                        KillApp();
                    }
                }
            }
        }

        private void SetDefaultLanguage(string promptValue)
        {
            lineChanger("langpath = " + promptValue, @AppPath + "\\Settings.ini", 34);
            autocook = promptValue;
        }

        public void SetBnSFolder()
        {
            // Step 3
            if (autocook != "")
            {
                if (!autocook.Contains("korean") && !autocook.Contains("Korean"))
                {
                    DataPath = FullPath.Replace("\\" + autocook + "\\CookedPC", "\\data");
                }
                else
                {
                    if (FullPath.Contains("\\bns\\CookedPC") || FullPath.EndsWith("\\bns\\CookedPC")) // usually
                    {
                        DataPath = FullPath.Replace("\\bns\\CookedPC", "\\local\\NCSoft\\data");
                    }
                    else if (FullPath.Contains("\\NCSoft\\Korean") || FullPath.EndsWith("\\NCSoft\\Korean")) // hotfix
                    {
                        DataPath = FullPath.Replace("\\NCSoft\\Korean", "\\NCSoft\\data");
                    }
                    else // universal failsafe
                    {
                        DataPath = FullPath.Replace("\\" + autocook + "\\CookedPC", "\\data");
                    }
                }
                if (!Directory.Exists(DataPath)) { Prompt.Popup("Error: Invalid Data Path!" + Environment.NewLine + "Path: " + DataPath); }
            }
            else
            {
                AddTextLog("Could not set DataPath!");
            }
        }

        public bool AppStarted = false;

        public void EnableForm1()
        {
            CheckForIllegalCrossThreadCalls = false;
            Enabled = true;
            bw3.CancelAsync();
            bw3.Dispose();
            Show();
            // Check for updates
            UpdateCheck();
            // Check if MultiClient is applied
            MultiCheck();
            // Make sure app shows after load
            TopMost = true;
            TopMost = false;
            // Fix tab order
            //default tab bools
            bool i0 = false;
            bool i1 = false;
            bool i2 = false;
            bool i3 = false;
            bool i4 = false;
            bool i5 = false;
            bool i6 = false;
            bool i7 = false;
            bool i8 = false;
            bool i9 = false;

            foreach (TabPage tmp in metroTabControl1.TabPages)
            {
                if (tmp.Text == "Launcher" && i0 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(0, tmp);
                    i0 = true;
                }
                else
                if (tmp.Text == "Dat Editor" && i1 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(1, tmp);
                    i1 = true;
                }
                else
                if (tmp.Text == "Mod Manager" && i2 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(2, tmp);
                    i2 = true;
                }
                else
                if (tmp.Text == "Splash Changer" && i4 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(4, tmp);
                    i4 = true;
                }
                else
                if (tmp.Text == "Addons" && i3 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(3, tmp);
                    i3 = true;
                }
                else
                if (tmp.Text == "Settings" && i5 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(5, tmp);
                    i5 = true;
                }
                else
                if (tmp.Text == "About" && i7 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(7, tmp);
                    i7 = true;
                }
                else
                if (tmp.Text == "Donators" && i6 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(6, tmp);
                    i6 = true;
                }
                else
                if (tmp.Text == "Extras" && i8 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(8, tmp);
                    i8 = true;
                }
                else
                if (tmp.Text == "Ads" && i9 == false)
                {
                    metroTabControl1.TabPages.Remove(tmp);
                    metroTabControl1.TabPages.Insert(9, tmp);
                    i9 = true;
                }
            }

            bool o0 = false;
            bool o1 = false;
            bool o2 = false;

            foreach (TabPage tmp in metroTabControl2.TabPages)
            {
                if (tmp.Text == "Page 1" && o0 == false)
                {
                    metroTabControl2.TabPages.Remove(tmp);
                    metroTabControl2.TabPages.Insert(0, tmp);
                    o0 = true;
                }
                else
                if (tmp.Text == "Page 2" && o1 == false)
                {
                    metroTabControl2.TabPages.Remove(tmp);
                    metroTabControl2.TabPages.Insert(1, tmp);
                    o1 = true;
                }
                else
                if (tmp.Text == "Page 3" && o2 == false)
                {
                    metroTabControl2.TabPages.Remove(tmp);
                    metroTabControl2.TabPages.Insert(2, tmp);
                    o2 = true;
                }
                // Fix cursor of metrotextbox6
                metroTextBox6.Cursor = Cursors.Arrow;
            }

            // Switch tab to Launcher/ADS
            metroTabControl1.SelectTab(9);
            //Prompt.Popup("Count: " + metroTabControl1.TabCount.ToString() + Environment.NewLine + "Index: " + metroTabControl1.TabIndex + Environment.NewLine + "TabPage Count: " + metroTabControl1.TabPages.Count);
            // Switch Settings tab to Page 1
            metroTabControl2.SelectTab(0);
            // Set Ping to Server
            SetPing();
            // Fix Combobox null element
            if (metroComboBox9.Items.Count > 0)
            {
                metroComboBox9.Items.Remove(metroComboBox9.Items[0]);
            }
            // Activate form
            AppStarted = true;
            // Read default Client
            if (readyclient == true)
            {
                string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(26).Take(1).First().Replace("defaultclient = ", "");
                metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact(line);
                defaultclient = line;
            }
            // Get online user count + little delay
            manualcount = true;
            Task.Delay(1000).ContinueWith(t => Get_Count());
        }

        private void MultiCheck()
        {
            bool MultiExists = false;
            if (Directory.Exists(RegPath + LauncherPath))
            {
                if (File.Exists(RegPath + LauncherPath + "\\winmm.dll"))
                {
                    metroLabel81.Text = "Active";
                    MultiExists = true;
                }
                else { metroLabel81.Text = "Inactive"; }
            }
            else { metroLabel81.Text = "-"; }
            if (Directory.Exists(RegPath + LauncherPath64))
            {
                if (File.Exists(RegPath + LauncherPath64 + "\\winmm.dll"))
                {
                    metroLabel82.Text = "Active";
                    MultiExists = true;
                }
                else { metroLabel82.Text = "Inactive"; }
            }
            else { metroLabel82.Text = "-"; }

            if (MultiExists == true)
            {
                metroToggle22.Checked = true;
                // Disable Auto Login
                if (metroLabel81.Text == "Active" || metroLabel82.Text == "Active")
                {
                    metroToggle25.Enabled = false;
                }
            }
        }

        public void SplashScreen()
        {
            CheckForIllegalCrossThreadCalls = false;
            Hide();
            bw3 = new BackgroundWorker();
            bw3.WorkerSupportsCancellation = true;
            bw3.WorkerReportsProgress = true;
            bw3.DoWork += new DoWorkEventHandler(bw3_DoWork);
            bw3.Disposed += new EventHandler(bw3_Dispoed);
            bw3.RunWorkerAsync();
        }

        public void bw3_Dispoed(object Sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (s2 != null)
            {
                s2.Close();
            }
        }

        public void bw3_DoWork(object Sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            s2 = new Form2();
            s2.ShowDialog();
        }

        public void FixSizes()
        {
            // Global Form
            this.Size = new Size(697, 422);
            metroTextBox1.Size = new Size(229, 267);
            // Dat editor
            metroPanel2.Size = new Size(450, 318);
            fastColoredTextBox1.Location = new Point(0, 24);
            fastColoredTextBox1.Size = new Size(450, 294);
            toolStrip2.Size = new Size(450, 25);
            treeView2.Size = new Size(392, 214);
            // Launcher
            Launcher.Size = new Size(687, 318);
            // Global Tabs
            metroTabControl1.Size = new Size(695, 357);
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            metroButton22.Visible = false;
            metroButton22.Enabled = false;
            metroButton23.Visible = true;
            metroButton23.Enabled = true;
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            metroButton22.Visible = true;
            metroButton22.Enabled = true;
            metroButton23.Visible = false;
            metroButton23.Enabled = false;
        }

        public void metroTabControl1_TabChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(metroTabControl1.SelectedTab.ToString());
            //MessageBox.Show(metroTabControl1.TabIndex.ToString());
            // results ex: {Splash Changer} & index ex: 0
            if (AppStarted)
            {
                if (metroTabControl1.SelectedTab.ToString().Contains("Dat Editor"))
                {
                    Resizable = true;
                    FixSizes();
                    metroButton22.Enabled = true;
                    metroButton22.Visible = true;
                }
                else
                {
                    // Restore windows state
                    this.WindowState = FormWindowState.Normal;
                    // Fix size of global form
                    Size = new Size(697, 422);
                    // Disable resize buttons
                    metroButton22.Enabled = false;
                    metroButton22.Visible = false;
                    metroButton23.Enabled = false;
                    metroButton23.Visible = false;
                    // Fix sizes
                    FixSizes();
                    // Fix size of global form x2
                    Size = new Size(697, 422);
                    // Make it unresizable
                    Resizable = false;
                }
                metroTabControl1.Refresh();
                foreach (TabPage page in metroTabControl1.TabPages)
                {
                    page.Refresh();
                    if (Debugging)
                        MessageBox.Show("Refreshed: " + page.Text);
                }
            }
        }

        private void metroTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroTabControl2.Refresh();
            foreach (TabPage page in metroTabControl2.TabPages)
            {
                page.Refresh();
                if (Debugging)
                    MessageBox.Show("Refreshed: " + page.Text);
            }
        }

        public void CheckTab()
        {
            // Check settings <3
            try
            {
                // Create if missing
                if (!File.Exists(AppPath + "\\Settings.ini")) { File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues); }
                // Check if updated.
                if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains("buddycolor"))
                {
                    // Save current settings
                    if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains("customlang"))
                    {
                        string[] currentsettings = File.ReadAllLines(AppPath + "\\Settings.ini");
                        // Create new file
                        File.Delete(AppPath + "\\Settings.ini");
                        File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                        // Start saving old settings
                        int i = 0;
                        foreach (string line in currentsettings)
                        {
                            i++;
                            lineChanger(line, AppPath + "\\Settings.ini", i);
                        }
                    }
                    else /* Fix Bug caused by previous versions */
                    {
                        File.Delete(AppPath + "\\Settings.ini");
                        File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                    }
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("savelogs = true"))
                {
                    metroToggle2.Checked = true;
                    groupBox7.Enabled = true;
                    SaveLogs = true;
                    groupBox7.Enabled = true;
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("launcherlogs = true"))
                    {
                        metroToggle13.Checked = true;
                        LauncherLogs = true;
                    }
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("modmanlogs = true"))
                    {
                        metroToggle12.Checked = true;
                        ModManLogs = true;
                    }
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("tooltips = false"))
                {
                    metroToggle6.Checked = false;
                    metroToolTip1.Active = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("variables = true"))
                {
                    metroToggle7.Checked = true;
                    metroLabel22.Visible = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("admincheck = false"))
                {
                    metroToggle8.Checked = false;
                    AdminCheck = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("showdonate = false"))
                {
                    metroToggle10.Checked = false;
                    metroButton12.Visible = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("minimize = false"))
                {
                    metroToggle11.Checked = false;
                    AllowMinimize = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("showlogs = false"))
                {
                    metroToggle5.Checked = false;
                    ShowLogs = false;
                }
                if (File.ReadAllText(@AppPath + "\\Settings.ini").Contains("langset = true"))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(33).Take(1).First().Replace("langpath = ", "");
                    langremembered = line;
                }
                if (File.ReadAllText(@AppPath + "\\Settings.ini").Contains("customclientname = "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(42).Take(1).First().Replace("customclientname = ", "");
                    if (line.Length >= 1)
                    {
                        customclientname = line;
                        metroTextBox9.Text = customclientname;
                    }
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("customgame = true"))
                {
                    metroTextBox3.Enabled = true;
                    metroButton15.Enabled = true;
                    metroButton20.Enabled = true;
                    metroButton17.Enabled = true;
                    metroToggle3.Checked = true;
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(15).Take(1).First();
                    RegPath = line.Replace("customgamepath = ", "");
                    workedREG = true;
                    BnSFolder();
                    metroTextBox3.Text = RegPath;
                    CustomGameSet = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("customclient = true"))
                {
                    metroTextBox4.Enabled = true;
                    metroButton16.Enabled = true;
                    metroButton19.Enabled = true;
                    metroButton18.Enabled = true;
                    metroToggle4.Checked = true;
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(14).Take(1).First();
                    RegPathlol = line.Replace("customclientpath = ", "");
                    workedSRV = true;
                    CheckServer();
                    metroTextBox4.Text = RegPathlol;
                    CustomClientSet = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("gamekiller = false"))
                {
                    GameKiller = false;
                    metroToggle15.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("boostprocess = false"))
                {
                    metroToggle20.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("updatechecker = false"))
                {
                    UpdateChecker = false;
                    metroToggle16.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("pingchecker = false"))
                {
                    PingChecker = false;
                    metroToggle14.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains(@"arguements = "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(20).Take(1).First().Replace("arguements = ", "");
                    metroTextBox5.Text = line;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("automemorycleanup = true"))
                {
                    metroToggle18.Checked = true;
                    AutoClean = true;
                    metroButton30.Visible = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains(@"prtime = "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(21).Take(1).First().Replace("prtime = ", "");
                    metroLabel47.Text = line;
                    metroLabel47.Refresh();
                    metroTrackBar1.Value = Convert.ToInt32(line);
                    metroTrackBar1.Refresh();
                    wakeywakey = Convert.ToInt32(line);
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains(@"uniquepass = "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(36).Take(1).First().Replace("uniquepass = ", "");
                    metroTextBox8.Text = line;
                    metroTextBox8.Refresh();
                }
                if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains(@"cleanint = OFF"))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(35).Take(1).First().Replace("cleanint = ", "");
                    metroComboBox7.SelectedIndex = metroComboBox7.FindStringExact(line);
                    metroComboBox7.Refresh();
                    if (line != "OFF")
                    {
                        CleanerVal = Convert.ToInt32(line);
                    }
                }
                else { metroComboBox7.SelectedIndex = 0; }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultset = true"))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(24).Take(1).First().Replace("default = ", "");
                    metroLabel48.Text = line; //lineChanger
                    RegPath = line;
                    workedREG = true;
                    MultipleInstallationFound = true;
                    GetRegDir();
                    BnSFolder();
                }
                if ((File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultclient = 64bit")) || (File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultclient = 32bit")))
                {
                    readyclient = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("usercountcheck = false"))
                {
                    UserCountCheck = false;
                    metroToggle26.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("showcount = false"))
                {
                    metroLabel93.Visible = false;
                    metroLabel94.Visible = false;
                    metroToggle27.Checked = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = false"))
                {
                    AutoUpdate = false;
                    metroToggle17.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("rememberme = true"))
                {
                    metroToggle28.Checked = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains(@"priority = "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(27).Take(1).First().Replace("priority = ", "");
                    if (line == "RealTime")
                    {
                        metroComboBox6.SelectedIndex = 0;
                    }
                    if (line == "High")
                    {
                        metroComboBox6.SelectedIndex = 1;
                    }
                    if (line == "AboveNormal")
                    {
                        metroComboBox6.SelectedIndex = 2;
                    }
                    if (line == "Normal")
                    {
                        metroComboBox6.SelectedIndex = 3;
                    }
                    if (line == "BelowNormal")
                    {
                        metroComboBox6.SelectedIndex = 4;
                    }
                    if (line == "Idle")
                    {
                        metroComboBox6.SelectedIndex = 5;
                    }
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains(@"buddycolor = "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(43).Take(1).First().Replace("buddycolor = ", "");
                    if (line == "Black")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Black;
                    }
                    else if (line == "Red")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Red;
                    }
                    else if (line == "Purple")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Purple;
                    }
                    else if (line == "Pink")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Pink;
                    }
                    else if (line == "Orange")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Orange;
                    }
                    else if (line == "Magenta")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Magenta;
                    }
                    else if (line == "Lime")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Lime;
                    }
                    else if (line == "Green")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Green;
                    }
                    else if (line == "Default")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Default;
                    }
                    else if (line == "Brown")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Brown;
                    }
                    else if (line == "Blue")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Blue;
                    }
                    else if (line == "Silver")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Silver;
                    }
                    else if (line == "Teal")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Teal;
                    }
                    else if (line == "White")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.White;
                    }
                    else if (line == "Yellow")
                    {
                        Themer.Style = MetroFramework.MetroColorStyle.Yellow;
                    }
                    metroComboBox11.SelectedIndex = metroComboBox11.FindStringExact(Themer.Style.ToString());
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("firsttime = false"))
                {
                    FirstTime = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("modfolderset = true"))
                {
                    // set custom as true to not overwrite custom values
                    CustomModSet = true;
                    // Grab value
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(28).Take(1).First().Replace("modfolder = ", "");
                    metroToggle19.Checked = true;
                    metroTextBox7.Text = line;
                    // set custom values
                    backupFolderPath = metroTextBox7.Text + "\\CookedPC_Backup";
                    FullModPathMan = metroTextBox7.Text + "\\CookedPC_Mod";
                    // configure paths
                    GetPath();
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("gcdshow = true"))
                {
                    metroToggle21.Checked = true;
                    metroLabel72.Visible = true;
                    metroLabel73.Visible = true;
                    metroLabel72.Refresh();
                    metroLabel73.Refresh();
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("igpshow = true"))
                {
                    metroToggle24.Checked = true;
                    metroLabel70.Visible = true;
                    metroLabel71.Visible = true;
                    metroLabel70.Refresh();
                    metroLabel71.Refresh();
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autologin = true"))
                {
                    metroToggle25.Checked = true;
                }
            }
            catch
            {
                //
            }
        }

        private ProcessPriorityClass Priority = ProcessPriorityClass.Normal;

        private void metroComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox6.SelectedItem.ToString() == "Realtime")
            {
                Priority = ProcessPriorityClass.RealTime;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "High")
            {
                Priority = ProcessPriorityClass.High;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "Above normal")
            {
                Priority = ProcessPriorityClass.AboveNormal;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "Normal")
            {
                Priority = ProcessPriorityClass.Normal;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "Below normal")
            {
                Priority = ProcessPriorityClass.BelowNormal;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "Low")
            {
                Priority = ProcessPriorityClass.Idle;
            }
            else
            {
                Priority = ProcessPriorityClass.Normal;
            }
            if (GameStarted)
            {
                foreach (var process in Process.GetProcessesByName("Client"))
                {
                    Prompt.Popup("Threads: " + process.Threads.ToString() + Environment.NewLine + "Physical Memory(bytes): " + process.WorkingSet64 + Environment.NewLine + "Virtual Memory(bytes): " + process.VirtualMemorySize64 + Environment.NewLine + "Title: " + process.MainWindowTitle);
                    process.PriorityClass = Priority;
                    AddTextLog("Changed Priority.");
                }
                if (customclientname != "")
                {
                    string tmp = customclientname.Replace(".exe", "");
                    foreach (var process in Process.GetProcessesByName(tmp))
                    {
                        Prompt.Popup(process.ProcessName.ToString());
                        process.PriorityClass = Priority;
                        AddTextLog("Changed Priority.");
                    }
                }
            }
            if (AppStarted)
            {
                // Get
                string tracker = File.ReadLines(@AppPath + "\\Settings.ini").Skip(27).Take(1).First().Replace("priority = ", "");
                // Set, replace , write
                var fileContents2 = File.ReadAllText(@AppPath + "\\Settings.ini");
                var newfileContents2 = fileContents2.Replace(tracker, Priority.ToString());
                File.WriteAllText(@AppPath + "\\Settings.ini", newfileContents2);
            }
        }

        public void Details()
        {
            metroLabel22.Text = "Language: " + languageID + " | Region: " + regionID;
            metroLabel47.Text = metroTrackBar1.Value.ToString();
            metroLabel47.Refresh();
        }

        public void VerifySettings()
        {
            // Check settings <3
            if (PathFound == true)
            {
                try
                {
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("unattended = true"))
                    {
                        metroCheckBox1.Checked = true;
                        Unattended = "-UNATTENDED";
                    }
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("notexturestreaming = true"))
                    {
                        metroCheckBox2.Checked = true;
                        NoTextureStreaming = "-NOTEXTURESTREAMING";
                    }
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("useallcores = true"))
                    {
                        metroCheckBox3.Checked = true;
                        UseAllCores = "-USEALLAVAILABLECORES";
                    }
                }
                catch
                {
                    AddTextLog("Run as admin.");
                }
            }
            else
            {
                AddTextLog("Could not load Pre-Settings");
            }
        }

        private void metroComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            LauncherInfo();
            // Server login
            if (regions.Count != 0)
            {
                RegionCB.DataSource = regions;
            }
            Details();
        }

        public void REDO_PATHS()
        {
            //////////////////
            //  Seperator   //
            // Launcher Tab //
            //////////////////
            try
            {
                workedREG = true;
                BnSFolder();
            }
            catch (Exception e) { Prompt.Popup(e.ToString()); }
            // Check backup for Loading Screen
            CheckBackup();
            VerifySettings();
            ///////////////////////
            //     Seperator     //
            // Splash Screen Tab //
            ///////////////////////
            GetPaths();
            Verify();
            InitializeSplash();
            /////////////////////
            //    Seperator    //
            // Mod Manager Tab //
            /////////////////////
            InitializeManager();
            GetPath();
            JsonManager();
            PopulateTreeView(FullModPathMan);
            VerifyUsage();
            ////////////////////
            //    Seperator   //
            // Dat Editor Tab //
            ////////////////////
            CleanMess(); /* Skip Cleaning */
            CleanOtherMess(); /* Skip Cleaning */
            DefaultDatValues();
            CreateDatPaths();
            ////////////////////
            //    Seperator   //
            //   Addons Tab   //
            ////////////////////
            InitializeAddons();
            Details();
            FixSizes();
        }

        public void CLEAR_PREVIOUS()
        {
            // Clear Dat Editor
            if (metroComboBox3.Items.Count > 0)
            {
                metroComboBox3.Items.Clear();
            }
            // Clear Addons
            if (treeView3.Nodes.Count > 0)
            {
                treeView3.Nodes.Clear();
            }
            // Clear Mod Manager
            if (treeView2.Nodes.Count > 0)
            {
                treeView2.Nodes.Clear();
            }
            // Clear Default Languages
            if (metroComboBox5.Items.Count > 0)
            {
                metroComboBox5.Items.Clear();
            }
            // Clear List of Splahes
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            // Clear old languages
            if (LangDictionary.Count > 0)
            {
                LangDictionary.Clear();
            }
        }

        private string PreviousServer = "";

        public void PreSavedPaths(string region)
        {
            if (AppStarted)
            {
                bool changed = false;
                if ((region == "North America" || region == "Europe") && Installs.ContainsKey("NA/EU"))
                {
                    RegPath = Installs["NA/EU"].ToString();
                    changed = true;
                }
                else
                if (region == "Japanese" && Installs.ContainsKey(region))
                {
                    RegPath = Installs[region].ToString();
                    changed = true;
                }
                else
                if (region == "Taiwan" && Installs.ContainsKey(region))
                {
                    RegPath = Installs[region].ToString();
                    changed = true;
                }
                else
                if (region == "Korean" && Installs.ContainsKey(region))
                {
                    RegPath = Installs[region].ToString();
                    changed = true;
                }
                if (changed)
                {
                    // Check Multilang
                    bool wasiton = false;
                    if (MultipleLangFound == true)
                    {
                        wasiton = true;
                        MultipleLangFound = false;
                    }
                    // Continue
                    if ((!(PreviousServer == "North America" && region == "Europe") && !(PreviousServer == "Europe" && region == "North America")) && (PreviousServer != region))  //* to Any from Any */ | (PreviousServer != "North America" && region == "Europe") /* to EU from other */ || (PreviousServer != "Europe" && region == "North America")/* to NA from other */)
                    {
                        CLEAR_PREVIOUS();
                        REDO_PATHS();
                        REPOPULATE();
                    }
                    // Revert multilang(if needed)
                    if (wasiton)
                    {
                        MultipleLangFound = true;
                    }
                    // Update last used server
                    PreviousServer = region;
                }
            }
        }

        private void REPOPULATE()
        {
            // Splash
            SplashPopulater();
            // Mod Manager
            ReFreshMods();
            // Dat Editor
            DefaultDatValues();
            // Addons
            RefreshAddons();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroComboBox8.Visible = false;
            // Check Server & IP
            if (metroComboBox1.SelectedItem.ToString() == "Europe")
            {
                IP = "18.194.180.254";
                regionID = "1";
                AddTextLog("Changed RegionID to EU!");
                regionID = "1";
                metroButton1.Text = "Play!";
                PreSavedPaths("Europe");
                LauncherInfo();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "North America")
            {
                IP = "64.25.37.236";
                regionID = "0";
                AddTextLog("Changed RegionID to NA!");
                regionID = "0";
                metroButton1.Text = "Play!";
                PreSavedPaths("North America");
                LauncherInfo();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Taiwan")
            {
                IP = "210.68.144.12";
                regionID = "15";
                AddTextLog("Changed RegionID to Taiwan!");
                regionID = "15";
                metroButton1.Text = "Play!";
                PreSavedPaths("Taiwan");
                LauncherInfo();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Japanese")
            {
                IP = "111.87.18.30";
                regionID = "0";
                AddTextLog("Changed RegionID to Japanese!");
                regionID = "0";
                metroButton1.Text = "Patch!";
                PreSavedPaths("Japanese");
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Korean")
            {
                IP = "112.175.209.114";
                regionID = "0";
                AddTextLog("Changed RegionID to Korean!");
                regionID = "0";
                metroButton1.Text = "Play!";
                PreSavedPaths("Korean");
                metroComboBox8.Visible = true;
                metroComboBox8.SelectedIndex = 0;
            }
            else
            {
                IP = "0";
            }
            // Server login
            if (regions.Count != 0)
            {
                RegionCB.DataSource = regions;
            }
            Details();
            // Refresh PreviousServer
            PreviousServer = metroComboBox1.SelectedItem.ToString();
            // Set new active server
            if (Installs.ContainsKey(PreviousServer) || (Installs.ContainsKey("NA/EU") && (PreviousServer == "Europe" || PreviousServer == "North America")))
            {
                if (PreviousServer != "Europe" && PreviousServer != "North America")
                {
                    SaveDefault(Installs[PreviousServer]);
                }
                else
                {
                    SaveDefault(Installs["NA/EU"]);
                }
            }
        }

        private bool Conflict = false;
        private bool workedSRV = false;

        public void CheckServer()
        {
            // Check Server Usage
            // NA/EU
            if (workedREG == true)
            {
                AddTextLog("Reading Registry...");
                if (Installs.ContainsKey("NA/EU"))
                {
                    if (Installs["NA/EU"].ToString() == RegPath && Reg64 == true)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\Wow6432Node\NCWest\NCLauncher\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                    else if (Installs["NA/EU"].ToString() == RegPath && Reg64 == false)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\NCWest\NCLauncher\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                }
                if (Installs.ContainsKey("Taiwan"))
                {
                    if (Installs["Taiwan"].ToString() == RegPath && Reg64 == true)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\Wow6432Node\plaync\NCLauncherS\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;

                                    // Check conflict
                                    regKeylol = Registry.LocalMachine;
                                    regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\Wow6432Node\plaync\MXM\");
                                    if (regKeylol != null)
                                    {
                                        Conflict = true;
                                    }
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                    else if (Installs["Taiwan"].ToString() == RegPath && Reg64 == false)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\plaync\NCLauncherS\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;

                                    // Check conflict
                                    regKeylol = Registry.LocalMachine;
                                    regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\plaync\MXM\");
                                    if (regKeylol != null)
                                    {
                                        Conflict = true;
                                    }
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                }
                if (Installs.ContainsKey("Japanese"))
                {
                    if (Installs["Japanese"].ToString() == RegPath && Reg64 == true)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\Wow6432Node\NCJapan\NCLauncher\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                    else if (Installs["Japanese"].ToString() == RegPath && Reg64 == false)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\NCJapan\NCLauncher\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                }
                if (Installs.ContainsKey("Korean"))
                {
                    if (Installs["Korean"].ToString() == RegPath && Reg64 == true)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\WOW6432Node\plaync\NCLauncherS\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;

                                    // Check conflict
                                    regKeylol = Registry.LocalMachine;
                                    regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\Wow6432Node\plaync\MXM\");
                                    if (regKeylol != null)
                                    {
                                        Conflict = true;
                                    }
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                    else if (Installs["Korean"].ToString() == RegPath && Reg64 == false)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\plaync\NCLauncherS\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;

                                    // Check conflict
                                    regKeylol = Registry.LocalMachine;
                                    regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\plaync\MXM\");
                                    if (regKeylol != null)
                                    {
                                        Conflict = true;
                                    }
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                }
                // Conflict error message
                if (Conflict)
                {
                    metroLabel65.Visible = true;
                }
            }

            if (workedSRV == false)
            {
                RegPathlol = null;
                AddTextLog("Error: RegKey = " + RegPathlol);
            }

            if (workedSRV == true)
            {
                try
                {
                    if (File.Exists(RegPathlol + "\\NCLauncher.ini"))
                    {
                        string nc_content = File.ReadAllText(RegPathlol + "\\NCLauncher.ini");
                        if ((nc_content.Contains("Game_Region=North America") || nc_content.Contains("Game_Region=Nordamerika") || nc_content.Contains("du Nord") || !nc_content.Contains("Game_Region")) && !nc_content.Contains("Update_ja") && !nc_content.Contains("TWBNS22"))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                        }
                        else if ((nc_content.Contains("Game_Region=Europe") || nc_content.Contains("Game_Region=Europa") || nc_content.Contains("Game_Region=L'Europe")))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Europe");
                        }
                        else if (nc_content.Contains("Game_Locale=ja"))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Japanese");
                        }
                        else if (nc_content.Contains("up4svr.plaync.com.tw") && !nc_content.Contains("MXM"))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                        }
                        else if (nc_content.Contains("up4web.plaync.co.kr") || nc_content.Contains("up4web.nclauncher.ncsoft.com") && !nc_content.Contains("MXM"))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Korean");
                            if (KoreanTestInstalled)
                            {
                                metroComboBox8.SelectedIndex = metroComboBox8.FindStringExact("Test");
                            }
                        }
                        if (Conflict == true && metroComboBox2.SelectedItem.ToString() == "Korean")
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Korean");
                            if (KoreanTestInstalled)
                            {
                                metroComboBox8.SelectedIndex = metroComboBox8.FindStringExact("Test");
                            }
                        }
                        else if (Conflict == true && metroComboBox2.SelectedItem.ToString() == "Taiwan")
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                        }
                    }
                }
                catch (Exception a)
                {
                    AddTextLog("Error: Could Not Find NCLauncher.ini" + Environment.NewLine + a.ToString());
                }
            }
            else
            {
                AddTextLog("Error: Could Not Find NCLauncher Path!");
            }
        }

        public string checkMD5(string filename)
        {
            // MD5 File Check
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToLower();
                }
            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox2.SelectedItem.ToString() == "English")
            {
                languageID = "English";
                AddTextLog("languageID = English");
            }
            else
            if (metroComboBox2.SelectedItem.ToString() == "French")
            {
                languageID = "French";
                AddTextLog("languageID = French");
            }
            else
            if (metroComboBox2.SelectedItem.ToString() == "German")
            {
                languageID = "German";
                AddTextLog("languageID = German");
            }
            else
            if (metroComboBox2.SelectedItem.ToString() == "Taiwan")
            {
                languageID = "CHINESET";
                AddTextLog("languageID = Chineset");
            }
            else
            if (metroComboBox2.SelectedItem.ToString() == "Japanese")
            {
                languageID = "JAPANESE";
                AddTextLog("languageID = Japanese");
            }
            else
            if (metroComboBox2.SelectedItem.ToString() == "Portuguese")
            {
                languageID = "BPORTUGUESE";
                AddTextLog("languageID = Portuguese");
            }
            else
            if (metroComboBox2.SelectedItem.ToString() == "Korean")
            {
                languageID = "korean";
                AddTextLog("languageID = Korean");
            }
            else
            {
                languageID = metroComboBox2.SelectedItem.ToString();
                AddTextLog("languageID = " + languageID + " (unknown)");
            }
            Details();
        }

        public void CheckBackup()
        {
            // Backup Checks
            AddTextLog("Checking For Backups");
            // bool for check
            bool runninglyn = false;
            bool loadingpkg = false;
            // Create backup if it doesn't exist
            string BackupPath = FullPath + "\\backup";
            if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }
            else
            {
                int worked = -1;
                if (File.Exists(FullPath + "\\backup\\00009368.bak"))
                {
                    if (worked == -1)
                        worked++;
                    if (File.Exists(FullPath + "\\00009368.upk"))
                    {
                        try
                        {
                            // Fix interference
                            File.Delete(FullPath + "\\00009368.upk");
                            AddTextLog("Fixed: Loading Screen Backup! (1)");
                            worked++;
                        }
                        catch
                        {
                            AddTextLog("Error: Could Not Fix Loading Screen Backup! (1)");
                        }
                    }
                }
                if (File.Exists(FullPath + "\\backup\\loading.bak"))
                {
                    if (worked == -1)
                        worked++;
                    if (File.Exists(FullPath + "\\Loading.pkg"))
                    {
                        try
                        {
                            // Fix interference
                            File.Delete(FullPath + "\\Loading.pkg");
                            AddTextLog("Fixed: Loading Screen Backup! (2)");
                            worked++;
                        }
                        catch
                        {
                            AddTextLog("Error: Could Not Fix Loading Screen Backup! (2)");
                        }
                    }
                }
                if (worked == 2)
                {
                    AddTextLog("Log: Automatically reapplied Loading Screen Fix");
                }
            }
            // Check if No Loading Screen is Enabled or not and set value if it is.
            if (File.Exists(FullPath + "\\Loading.pkg") && File.Exists(FullPath + "\\00009368.upk"))
            {
                metroToggle1.CheckState = CheckState.Unchecked;
                metroToggle1.Refresh();
            }
            else
            {
                // Find the ones removed from previous session
                if (File.Exists(FullPath + "\\Loading.pkg"))
                {
                    loadingpkg = true;
                }
                if (File.Exists(FullPath + "\\00009368.upk"))
                {
                    runninglyn = true;
                }

                // remove runninglyn if found
                if (runninglyn == true)
                {
                    try
                    {
                        // Fix interference
                        File.Delete(FullPath + "\\backup\\00009368.bak");
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                        AddTextLog("Fixed: Loading Screen Backup!(2)");
                    }
                    catch
                    {
                        AddTextLog("Error: Could Not Fix Loading Screen Backup!(2)");
                    }
                }

                // remove loadingpkg if found
                if (loadingpkg == true)
                {
                    try
                    {
                        // Fix interference
                        File.Delete(FullPath + "\\backup\\loading.bak");
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                        AddTextLog("Fixed: Loading Screen Backup!(1)");
                    }
                    catch
                    {
                        AddTextLog("Error: Could Not Fix Loading Screen Backup!(1)");
                    }
                }

                metroToggle1.CheckState = CheckState.Checked;
                metroToggle1.Refresh();
                AddTextLog("Loading Screen Backup Found!");
            }
            CheckConfigBackup();
        }

        private void metroLabel39_TextChanged(object sender, EventArgs e)
        {
            metroLabel63.Text = metroLabel39.Text;
            metroLabel63.Refresh();
        }

        public void CleanOtherMess()
        {
            string localvar = "";
            try
            {
                AddTextLog("Cleaning Mess");
                DirectoryInfo path = new DirectoryInfo(DataPath);
                foreach (DirectoryInfo subdir in path.GetDirectories())
                {
                    string subbeddir = Path.GetDirectoryName(subdir.ToString());
                    if (subbeddir.Length > 0)
                    {
                        if (subbeddir.EndsWith(".dat.files") && subbeddir.Contains(".dat.files"))
                        {
                            localvar = subbeddir;
                            Array.ForEach(Directory.GetFiles(@DataPath + "\\" + localvar + "\\"), File.Delete);
                            AddTextLog("Cleaned Files, now removing folder");
                            Directory.Delete(DataPath + "\\" + localvar + "\\", true);
                            AddTextLog("Cleaned " + localvar);
                        }
                    }
                    else
                    {
                        if (subdir.ToString().EndsWith(".dat.files") && subdir.ToString().Contains(".dat.files"))
                        {
                            localvar = subdir.ToString();
                            Array.ForEach(Directory.GetFiles(@DataPath + "\\" + localvar + "\\"), File.Delete);
                            AddTextLog("Cleaned Files, now removing folder");
                            Directory.Delete(DataPath + "\\" + localvar + "\\", true);
                            AddTextLog("Cleaned " + localvar);
                        }
                    }
                }
            }
            catch { AddTextLog("Could not remove folder -> " + DataPath + "\\" + localvar + "\\"); }
        }

        public void DoBackupCheck()
        {
            try
            {
                isModded = false;
                AddTextLog("Extracted");
                AddTextLog("Checking system.config2.xml if modded");
                metroButton2.Enabled = true;
                string String = @"<option name=""use-web-launching"" value=""false"" />";
                if (File.ReadAllText(DataPath + "\\" + usedfile + ".files\\system.config2.xml").Contains(String))
                {
                    AddTextLog(usedfile + " is Modded");
                    metroLabel14.Text = "Patched!"; metroButton2.Enabled = true; metroLabel14.Refresh(); metroButton1.Text = "Play!";
                    isModded = true;
                }
                else
                {
                    AddTextLog(usedfile + " is Clean");
                    metroLabel14.Text = "Clean"; metroLabel14.Refresh(); metroButton2.Enabled = false;
                    metroButton2.Enabled = false;
                }
            }
            catch { AddTextLog("Error: Could not verify system.config2.xml (" + usedfile + " in use)"); }
        }

        public string usedfile = "";
        public string usedfilepath = "";
        public string usedfilepathonly = "";
        public bool BNSis64 = false;
        public bool isModded = false;
        private AutoResetEvent waitbw = new AutoResetEvent(false);

        public void CheckConfigBackup()
        {
            DirectoryInfo configfolder = new DirectoryInfo(DataPath);
            FileInfo[] configfiles = configfolder.GetFiles("*.dat");
            foreach (FileInfo configfile in configfiles)
            {
                usedfile = "";
                if ((!configfile.ToString().Contains("xml")) && (configfile.ToString().Contains("config"))) // Skipping xml.dat as it is too large and not needed
                {
                    usedfile = configfile.ToString();
                    usedfilepath = DataPath + "\\" + usedfile;
                    AddTextLog("Extracting " + usedfile + " for verification");
                    metroButton2.Enabled = true;
                    // Start new patching routine!
                    try
                    {
                        Extractor(usedfile);
                        DoBackupCheck();
                    }
                    catch (Exception e) { Prompt.Popup(e.ToString()); }
                }
            }
            if (isModded)
            {
                metroButton2.Enabled = true;
                metroLabel14.Text = "Patched!";
            }
        }

        public void Compiler(string qwerty)
        {
            ToolTipsFix(false);
            if (qwerty != null)
            {
                // Check if 64bit or 32bit
                if (qwerty.Contains("64"))
                {
                    BNSis64 = true;
                }
                else { BNSis64 = false; }
                // Go to task
                bnsdatc = new BackgroundWorker();
                bnsdatc.WorkerSupportsCancellation = true;
                bnsdatc.WorkerReportsProgress = true;
                bnsdatc.DoWork += new DoWorkEventHandler(bnsdatc_DoWork);
                bnsdatc.RunWorkerAsync();
                // Wait until task is complete
                waitbw.WaitOne();
                waitbw.Reset();
            }
            if (metroToggle6.Checked)
            {
                ToolTipsFix(true);
            }
        }

        private void bnsdatc_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (Directory.Exists(usedfilepathonly))
            {
                BNSDat.BNSDat BnsDat = new BNSDat.BNSDat();
                BnsDat.Compress(usedfilepathonly, BNSis64);
                // set task as completed
                waitbw.Set();
            }
            else
            {
                Prompt.Popup("Folder: " + usedfilepathonly + " Does not exist!");
                // set task as completed
                waitbw.Set();
            }
        }

        public void ToolTipsFix(bool option)
        {
            if (option)
            {
                metroToolTip1.Active = true;
            }
            else
            {
                metroToolTip1.Active = false;
            }
        }

        public void Extractor(string qwerty)
        {
            ToolTipsFix(false);
            if (qwerty != null)
            {
                // Check if 64bit or 32bit
                if (qwerty.Contains("64"))
                {
                    BNSis64 = true;
                }
                else { BNSis64 = false; }
                // Go to task
                bnsdat = new BackgroundWorker();
                bnsdat.WorkerSupportsCancellation = true;
                bnsdat.WorkerReportsProgress = true;
                bnsdat.DoWork += new DoWorkEventHandler(bnsdat_DoWork);
                bnsdat.RunWorkerAsync();
                // Wait until task is complete
                waitbw.WaitOne();
                waitbw.Reset();
            }
            if (metroToggle6.Checked)
            {
                ToolTipsFix(true);
            }
        }

        private void bnsdat_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (File.Exists(usedfilepath))
            {
                BNSDat.BNSDat BnsDat = new BNSDat.BNSDat();
                BnsDat.Extract(usedfilepath, BNSis64);
                // set task as completed
                waitbw.Set();
            }
            else
            {
                Prompt.Popup("File: " + usedfilepath + " Does not exist!");
                // set task as completed
                waitbw.Set();
            }
        }

        public bool workedREG = false;

        public void BnSFolder()
        {
            // Check if ain't already in settings
            if (workedREG == false)
            {
                // Run if not
                GetRegDir();
            }
            // Recursively find path
            try
            {
                AutoDirFinder();
                SetBnSFolder();
            }
            catch (Exception e) { Prompt.Popup("Error: " + e.ToString()); }
        }

        private static int BinaryMatch(byte[] input, byte[] pattern)
        {
            int sLen = input.Length - pattern.Length + 1;
            for (int i = 0; i < sLen; ++i)
            {
                bool match = true;
                for (int j = 0; j < pattern.Length; ++j)
                {
                    if (input[i + j] != pattern[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateCheck()
        {
            if (UpdateChecker == true)
            {
                // Check, Validate & Notify
                // Check
                try
                {
                    if (ValidateDomain() == true)
                    {
                        try
                        {
                            // Get BnS Buddy's Unique Serial Number
                            X509Certificate certificate1;
                            try
                            {
                                certificate1 = X509Certificate2.CreateFromSignedFile(Application.ExecutablePath);
                                string BnSBuddySerial = certificate1.GetCertHashString();
                            }
                            catch { Prompt.Popup("BnS Buddy is not signed! Please Delete and get a fresh copy."); KillApp(); }
                            string server = "updates.xxzer0modzxx.net";
                            TcpClient clientVAR = new TcpClient(server, 443);
                            var DomainCert = new RemoteCertificateValidationCallback(delegate (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors)
                            {
                                return true; //Accept every certificate, even if it's invalid
                                });
                            using (SslStream sslStream = new SslStream(clientVAR.GetStream(), false, DomainCert))
                            {
                                string result = "";
                                sslStream.AuthenticateAsClient(server);
                                clientVAR.SendTimeout = 500;
                                clientVAR.ReceiveTimeout = 1000;
                                // Send request headers
                                var builder = new StringBuilder();
                                builder.AppendLine("GET /BuddyVersion.txt HTTP/1.1");
                                builder.AppendLine("Host: updates.xxzer0modzxx.net");
                                builder.AppendLine("User-Agent: BnSBuddy/" + Application.ProductVersion + " (compatible;)");
                                builder.AppendLine("Connection: close");
                                builder.AppendLine();
                                var header = Encoding.ASCII.GetBytes(builder.ToString());
                                sslStream.WriteAsync(header, 0, header.Length);
                                // receive data
                                using (var memory = new MemoryStream())
                                {
                                    sslStream.CopyTo(memory);
                                    memory.Position = 0;
                                    var data = memory.ToArray();

                                    var index = BinaryMatch(data, Encoding.ASCII.GetBytes("\r\n\r\n")) + 4;
                                    var headers = Encoding.ASCII.GetString(data, 0, index);
                                    memory.Position = index;

                                    if (headers.IndexOf("Content-Encoding: gzip") > 0)
                                    {
                                        using (GZipStream decompressionStream = new GZipStream(memory, CompressionMode.Decompress))
                                        using (var decompressedMemory = new MemoryStream())
                                        {
                                            decompressionStream.CopyTo(decompressedMemory);
                                            decompressedMemory.Position = 0;
                                            result = Encoding.UTF8.GetString(decompressedMemory.ToArray());
                                        }
                                    }
                                    else
                                    {
                                        result = Encoding.UTF8.GetString(data, index, data.Length - index);
                                    }
                                }
                                s = result;
                            }
                            clientVAR.Close();
                        }
                        catch (Exception e) { AddTextLog("Could not connect"); s = "Error"; Prompt.Popup(e.ToString()); }
                        AddTextLog("Grabbed: " + s);
                    }
                    else
                    {
                        AddTextLog("Domain Invalid");
                        s = "Error";
                    }
                }
                catch (Exception e)
                {
                    AddTextLog("Could not connect.");
                    s = "Error";
                    Prompt.Popup(e.ToString());
                }
                //}
                // Validate
                metroLabel6.Text = s;
                metroLabel3.Text = Application.ProductVersion;
                online = s.Replace(".", "");
                offline = Application.ProductVersion.ToString().Replace(".", "");
                // Notify
                if (online != "Error")
                {
                    if (Convert.ToInt32(online) > Convert.ToInt32(offline))
                    {
                        if (s != "Error")
                        {
                            /*
                            metroButton3.Enabled = true;
                            */
                            AddTextLog("Update available.");

                            if (AutoUpdate == true)
                            {
                                startDownload();
                            }
                            else
                            {
                                metroButton3.Visible = true;
                            }
                        }
                        else if (online == "Error")
                        {
                            // If update check is off
                            AddTextLog("Error checking update.");
                        }
                    }
                    else
                    {
                        AddTextLog("Up to date.");
                    }
                }
                else { AddTextLog("Error checking update."); }
            }
            else
            {
                metroLabel6.Text = "Offline";
                metroLabel3.Text = Application.ProductVersion;
            }
        }

        private bool ValidateDomain()
        {
            string BnSBuddySerial = "";
            string BnSServerCert = "";
            // Get BnS Buddy's Unique Serial Number
            try
            {
                var certificate = X509Certificate2.CreateFromSignedFile(Application.ExecutablePath);
                BnSBuddySerial = certificate.GetHashCode().ToString();
                if (BnSBuddySerial != "1307602086") { Prompt.Popup("BnS Buddy signature does not match! Please Delete and get a fresh copy."); KillApp(); }
            }
            catch { Prompt.Popup("BnS Buddy is not signed! Please Delete and get a fresh copy."); KillApp(); }
            // Get Domain's Unique Serial Number
            if (BnSBuddySerial.Length > 0)
            {
                X509Certificate2 cert = null;
                try
                {
                    var Client = new TcpClient("updates.xxzer0modzxx.net", 443);
                    var DomainCert = new RemoteCertificateValidationCallback(delegate (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors)
                    {
                        return true; //Accept every certificate, even if it's invalid
                    });
                    using (var sslStream = new SslStream(Client.GetStream(), true, DomainCert))
                    {
                        sslStream.AuthenticateAsClient("updates.xxzer0modzxx.net");
                        var serverCertificate = sslStream.RemoteCertificate;
                        cert = new X509Certificate2(serverCertificate);
                    }
                }
                catch { AddTextLog("Could not connect securely to update server"); return false; }
                if (!(cert == null))
                {
                    BnSServerCert = cert.GetHashCode().ToString();
                }
                // Verify if Hash Code Matches
                if (Debugging)
                {
                    Prompt.Popup("BnS Buddy Hash: " + BnSBuddySerial + Environment.NewLine + "BnSBuddy's Server Hash: " + BnSServerCert);
                }
                if (BnSBuddySerial == BnSServerCert && BnSBuddySerial == "1307602086")
                {
                    AddTextLog("Domain validated");
                    return true;
                }
            }
            return false;
        }

        public void KillGame()
        {
            if (GameKiller == true)
            {
                try
                {
                    // Kill game process
                    foreach (var process in Process.GetProcessesByName("Client"))
                    {
                        process.Kill();
                        AddTextLog("Killed Game Process.");
                    }
                    if (customclientname != "")
                    {
                        string tmp = customclientname.Replace(".exe", "");
                        foreach (var process in Process.GetProcessesByName(tmp))
                        {
                            process.Kill();
                            AddTextLog("Killed Game Process.");
                        }
                    }
                }
                catch { AddTextLog("Could Not Kill Game Process."); }
            }
        }

        public void AddTextLog(string text)
        {
            // Append text to log
            if (ShowLogs == true)
            {
                metroTextBox1.AppendText(text + Environment.NewLine);
                metroTextBox1.Refresh();
            }
            // Settings log checker
            if (SaveLogs == true)
            {
                if (LauncherLogs == true)
                {
                    File.WriteAllText(AppPath + "\\Launcher_logs.txt", metroTextBox1.Text);
                }
            }
            // End Checker
        }

        public void AddTextBoxLog(string text)
        {
            // Append text to log
            if (ShowLogs == true)
            {
                metroTextBox2.AppendText(text);
            }
            // Settings log checker
            if (SaveLogs == true)
            {
                if (ModManLogs == true)
                {
                    File.WriteAllText(AppPath + "\\ModManager_logs.txt", metroTextBox2.Text);
                }
            }
            // End Checker
        }

        private AutoResetEvent _responcov = new AutoResetEvent(true);

        public void bw1_DoWork(object Sender, DoWorkEventArgs e)
        {
            // Global sock & watch

            // Set ping
            AddTextLog("Getting Ping From Server...");
            try
            {
                if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("North America") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Europe"))
                {
                    var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sock.Blocking = true;
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    sock.Connect(IP, 10100);
                    stopwatch.Stop();
                    int ms = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
                    sock.Close();
                    ping = ms;
                }
                else
                {
                    ping = Convert.ToInt32(new Ping().Send(IP).RoundtripTime.ToString());
                }
            }
            catch { ping = 0; }
            if (Regex.IsMatch(ping.ToString(), @"^\d+$") == true)
            {
                if (ping != 0)
                {
                    metroLabel11.Text = ping + ms;
                    // round n continue
                    int IngameMS = Convert.ToInt32(Math.Round(ping * 2.833333333333333));
                    int GCDMS = Convert.ToInt32(Math.Round(IngameMS * 1.666666666666667));
                    metroLabel70.Text = IngameMS + ms;
                    metroLabel72.Text = GCDMS + ms;
                    AddTextLog("Got Ping.");
                }
                else
                {
                    metroLabel11.Text = "Offline";
                    metroLabel70.Text = "Offline";
                    metroLabel72.Text = "Offline";
                    AddTextLog("No Ping.");
                }
            }
            else
            {
                metroLabel11.Text = "Offline";
                metroLabel70.Text = "Offline";
                metroLabel72.Text = "Offline";
                AddTextLog("No Ping.");
            }
            BackgroundWorker worker = (BackgroundWorker)Sender;
            while (!worker.CancellationPending)
            {
                if (metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("North America") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Europe"))
                {
                    // Loop Progress
                    worker.ReportProgress(0);
                }
                // Input Ping Into Label
                Thread.Sleep(wakeywakey);
                try
                {
                    if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("North America") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Europe"))
                    {
                        //_responcov.WaitOne();
                        //_responcov.Reset();
                        var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        sock.Blocking = true;
                        var stopwatch = new Stopwatch();
                        if (!sock.Connected)
                        {
                            stopwatch.Start();
                            sock.Connect(IP, 10100);
                            stopwatch.Stop();
                            int ms = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
                            ping = ms;
                            //_responcov.Set();
                        }
                        if (sock.Connected)
                        {
                            sock.Close();
                            worker.ReportProgress(0);
                        }
                    }
                    else
                    {
                        ping = Convert.ToInt32(new Ping().Send(IP).RoundtripTime.ToString());
                    }
                }
                catch { ping = 0; }
            }
        }

        public void bw1_ProgressChanged(object Sender, ProgressChangedEventArgs e)
        {
            if (Regex.IsMatch(ping.ToString(), @"^\d+$") == true)
            {
                if (ping != 0)
                {
                    metroLabel11.Text = ping + ms;
                    // round n continue
                    int IngameMS = Convert.ToInt32(Math.Round(ping * 2.833333333333333));
                    int GCDMS = Convert.ToInt32(Math.Round(IngameMS * 1.666666666666667));
                    metroLabel70.Text = IngameMS + ms;
                    metroLabel72.Text = GCDMS + ms;
                }
                else
                {
                    metroLabel11.Text = "Offline";
                    metroLabel70.Text = "Offline";
                    metroLabel72.Text = "Offline";
                }
            }
            else
            {
                metroLabel11.Text = "Offline";
                metroLabel70.Text = "Offline";
                metroLabel72.Text = "Offline";
            }
        }

        public void SetPing()
        {
            bw1 = new BackgroundWorker();
            bw1.WorkerSupportsCancellation = true;
            bw1.WorkerReportsProgress = true;
            bw1.DoWork += new DoWorkEventHandler(bw1_DoWork);
            bw1.ProgressChanged += new ProgressChangedEventHandler(bw1_ProgressChanged);

            if (PingChecker == true)
            {
                bw1.RunWorkerAsync();
            }
        }

        private bool ProcessExists(int iProcessID)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.Id == iProcessID)
                {
                    return true;
                }
            }
            return false;
        }

        private bool prioboost = false;
        private Dictionary<string, string> ClearClient = new Dictionary<string, string>();

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Check Client.exe in background
            if (GameStarted == true)
            {
                GameStarted = false;
                // MultiClient
                foreach (string name in ClientHandler.Keys)
                {
                    if (ProcessExists(ClientHandler[name]) == false)
                    {
                        // Remove from MultiClient Lib
                        metroComboBox9.SelectedIndex = -1;
                        metroComboBox9.Items.Remove(name);
                        ClearClient.Add(name, name);
                        // Select the one available (if any)
                        if (metroComboBox9.Items.Count > 1)
                        {
                            metroComboBox9.SelectedIndex = 1;
                        }
                        else
                        {
                            metroComboBox9.SelectedIndex = -1;
                            metroPanel6.Visible = false;
                        }
                        AddTextLog(name + "'s Game Process Died");
                    }
                }
                foreach (string name in ClearClient.Keys)
                {
                    ClientHandler.Remove(name);
                }
                // Clear ClearClient Dictionary itself
                ClearClient = new Dictionary<string, string>();
                // Resume
                string tmpclientname = "";
                if (customclientname != "")
                {
                    tmpclientname = customclientname.Replace(".exe", "");
                }
                else
                {
                    tmpclientname = "Client";
                }
                foreach (var process in Process.GetProcessesByName(tmpclientname))
                {
                    metroLabel57.Text = "Running";
                    // fix priority based on settings live edit
                    try
                    {
                        // Priority
                        if (metroComboBox6.SelectedItem != null)
                        {
                            if (process.PriorityClass != Priority)
                            {
                                process.PriorityClass = Priority;
                                AddTextLog("Changed Priority.");
                            }
                        }
                        metroLabel60.Text = process.PriorityClass.ToString();
                        // Process focus boost
                        if ((metroToggle20.Checked == true) && (prioboost == false))
                        {
                            prioboost = true;
                            process.PriorityBoostEnabled = true;
                            AddTextLog("Priority Boost Enabled.");
                        }
                    }
                    catch {/* ignore */}
                    GameStarted = true;
                    metroButton1.Enabled = true;
                    metroButton1.Text = "Kill Game";
                }
                if (GameStarted == false)
                {
                    foreach (var process in Process.GetProcessesByName("Client"))
                    {
                        GameStarted = true;
                    }
                    if (customclientname != "")
                    {
                        string tmp = customclientname.Replace(".exe", "");
                        foreach (var process in Process.GetProcessesByName(tmp))
                        {
                            GameStarted = true;
                        }
                    }
                    if (GameStarted)
                    {
                        // MultiClient
                        foreach (string name in ClientHandler.Keys)
                        {
                            if (ProcessExists(ClientHandler[name]) == false)
                            {
                                // Remove from MultiClient Lib
                                metroComboBox9.SelectedIndex = -1;
                                metroComboBox9.Items.Remove(name);
                                ClearClient.Add(name, name);
                                // Select the one available (if any)
                                if (metroComboBox9.Items.Count > 1)
                                {
                                    metroComboBox9.SelectedIndex = 1;
                                }
                                else
                                {
                                    metroComboBox9.SelectedIndex = -1;
                                    metroPanel6.Visible = false;
                                }
                                AddTextLog(name + "'s Game Process Died");
                            }
                        }
                        foreach (string name in ClearClient.Keys)
                        {
                            ClientHandler.Remove(name);
                        }
                        // Clear ClearClient Dictionary itself
                        ClearClient = new Dictionary<string, string>();
                    }

                    if (!GameStarted)
                    {
                        metroLabel57.Text = "Closed";
                        metroLabel60.Text = "-";
                        // Verify mod manager
                        foreach (TreeNode nodes in treeView2.Nodes)
                        {
                            if (nodes != null)
                            {
                                RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                                if (Directory.Exists(RealModPath))
                                {
                                    checkButtons(true);
                                }
                                else
                                {
                                    nodes.Remove();
                                }
                            }
                        }
                        //
                        metroButton1.Enabled = true;
                        metroButton1.Text = "Play!";
                        Show(); // Shows the program on taskbar
                        this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                        notifyIcon1.Visible = false; // Hides tray icon again
                        AddTextLog("Game Closed!");
                        AddTextLog("Restored UI!");
                        if (!metroLabel14.Text.Contains("Clean"))
                        {
                            metroButton2.Enabled = true;
                        }
                        CClock.Stop();
                        // Enable mod man buttons
                        enableButtons();
                    }
                }
            }
            //End Check
        }

        private void metroLabel11_TextChanged(object sender, EventArgs e)
        {
            // Ping Status
            int pinger = 0;
            try
            {
                if (ping.ToString() == null || ping.ToString() == "")
                    ping = 0;
                pinger = Convert.ToInt32(ping);
            }
            catch { /* ignore me */ }
            if (pinger >= bad)
            {
                metroLabel12.Text = "Bad";
                metroLabel12.CustomForeColor = true;
                metroLabel12.ForeColor = Color.Red;
            }
            else
            {
                if ((pinger >= medium) && (pinger < bad))
                {
                    metroLabel12.Text = "Playable";
                    metroLabel12.CustomForeColor = true;
                    metroLabel12.ForeColor = Color.Yellow;
                }
                else
                {
                    if ((pinger >= good) && (pinger < medium))
                    {
                        metroLabel12.Text = "Good";
                        metroLabel12.CustomForeColor = true;
                        metroLabel12.ForeColor = Color.Green;
                    }
                    else
                    {
                        metroLabel12.Text = "Error";
                        metroLabel12.CustomForeColor = false;
                    }
                }
            }
        }

        private void metroToggle1_Click(object sender, EventArgs e)
        {
            // Show status and Disable buttons
            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Refresh();
            metroToggle1.Enabled = false;
            metroButton1.Enabled = false;
            // Proceed to remove
            if (metroToggle1.Checked == true)
            {
                bool loadingpkg = false;
                bool runninglyn = false;
                try
                {
                    if (!File.Exists(FullPath + "\\backup\\loading.bak"))
                    {
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                    }
                    else
                    {
                        File.Delete(FullPath + "\\backup\\loading.bak");
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                    }
                    loadingpkg = true;
                }
                catch
                {
                    AddTextLog("Could Not Remove Loading.pkg!");
                }

                try
                {
                    if (!File.Exists(FullPath + "\\backup\\00009368.bak"))
                    {
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                    }
                    else
                    {
                        File.Delete(FullPath + "\\backup\\00009368.bak");
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                    }
                    runninglyn = true;
                }
                catch
                {
                    AddTextLog("Could Not Remove 00009368.upk!");
                }

                if (runninglyn == true && loadingpkg == true)
                {
                    AddTextLog("Applied Loading Screen Fix!");
                }
                else if (runninglyn == false && loadingpkg == false)
                {
                    metroToggle1.CheckState = CheckState.Checked;
                }
                else
                {
                    metroToggle1.CheckState = CheckState.Unchecked;
                    if (runninglyn == true)
                    {
                        File.Move(FullPath + "\\backup\\00009368.bak", FullPath + "\\00009368.upk");
                    }
                    if (loadingpkg == true)
                    {
                        File.Move(FullPath + "\\backup\\loading.bak", FullPath + "\\Loading.pkg");
                    }
                }
            }
            else
            {
                bool loadingpkg = false;
                bool runninglyn = false;
                try
                {
                    if (File.Exists(FullPath + "\\backup\\loading.bak"))
                    {
                        File.Move(FullPath + "\\backup\\loading.bak", FullPath + "\\Loading.pkg");
                    }
                    loadingpkg = true;
                }
                catch
                {
                    AddTextLog("Could Not Restore Loading.pkg!");
                }

                try
                {
                    if (File.Exists(FullPath + "\\backup\\00009368.bak"))
                    {
                        File.Move(FullPath + "\\backup\\00009368.bak", FullPath + "\\00009368.upk");
                    }
                    runninglyn = true;
                }
                catch
                {
                    AddTextLog("Could Not Restore 00009368.upk!");
                }

                if (runninglyn == true && loadingpkg == true)
                {
                    AddTextLog("Restored Loading Screen!");
                }
                else if (runninglyn == false && loadingpkg == false)
                {
                    metroToggle1.CheckState = CheckState.Unchecked;
                }
                else
                {
                    metroToggle1.CheckState = CheckState.Checked;
                    if (runninglyn == true)
                    {
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                    }
                    if (loadingpkg == true)
                    {
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                    }
                }
            }

            metroToggle1.Enabled = true;
            if (PathFound == true)
            {
                metroButton1.Enabled = true;
            }
            metroToggle1.Refresh();
            metroButton1.Refresh();
            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Refresh();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroCheckBox1.Checked == true)
                {
                    Unattended = "-UNATTENDED";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("unattended = false", "unattended = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    Unattended = "";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("unattended = true", "unattended = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroCheckBox3.Checked == true)
                {
                    UseAllCores = "-USEALLAVAILABLECORES";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("useallcores = false", "useallcores = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    UseAllCores = "";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("useallcores = true", "useallcores = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroCheckBox2.Checked == true)
                {
                    NoTextureStreaming = "-NOTEXTURESTREAMING";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("notexturestreaming = false", "notexturestreaming = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    NoTextureStreaming = "";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("notexturestreaming = true", "notexturestreaming = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            startDownload();
        }

        private void startDownload()
        {
            // Extract updater if needed.
            if (!File.Exists(AppPath + "\\BnS Buddy Updater.exe"))
            {
                File.WriteAllBytes(AppPath + "\\BnS Buddy Updater.exe", Resources.BnS_Buddy_Updater);
            }
            else
            {
                File.Delete(AppPath + "\\BnS Buddy Updater.exe");
                File.WriteAllBytes(AppPath + "\\BnS Buddy Updater.exe", Resources.BnS_Buddy_Updater);
            }
            // Run updater
            Process BnSBuddyUpdater = new Process();
            BnSBuddyUpdater.StartInfo.FileName = AppPath + "\\BnS Buddy Updater.exe";
            BnSBuddyUpdater.Start();
            // Kill current app
            KillApp();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            RestoreConfigFiles();
            metroButton2.Enabled = false;
        }

        private string datbackup = "";

        public void RestoreConfigFiles()
        {
            DirectoryInfo configfolder = new DirectoryInfo(DataPath);
            FileInfo[] configfiles = configfolder.GetFiles("*.dat");
            foreach (FileInfo configfile in configfiles)
            {
                datbackup = configfile.ToString();
                try
                {
                    if ((!configfile.ToString().Contains("xml")) && (configfile.ToString().Contains("config")))
                    {
                        //
                        AddTextLog("Extracting " + datbackup);
                        usedfile = datbackup;
                        usedfilepath = DataPath + "\\" + datbackup;
                        Extractor(usedfile);
                        DoRestoreProcess();
                    }
                }
                catch (Exception e) { Prompt.Popup(e.ToString()); }
            }
        }

        public void DoRestoreProcess()
        {
            try
            {
                AddTextLog("Extracted " + datbackup);
                AddTextLog("Checking string");
                string String = @"<option name=""use-web-launching"" value=""false"" />";
                if (File.ReadAllText(DataPath + "\\" + datbackup + ".files\\system.config2.xml").Contains(String))
                {
                    try
                    {
                        AddTextLog("Replacing values");
                        var filecontent = File.ReadAllText(DataPath + "\\" + datbackup + ".files\\system.config2.xml").Replace(@"<option name=""use-web-launching"" value=""false"" />", @"<option name=""use-web-launching"" value=""true"" />");
                        File.WriteAllText(DataPath + "\\" + datbackup + ".files\\system.config2.xml", filecontent);
                        AddTextLog("Replaced");
                        RepackRestoredConfig();
                    }
                    catch { AddTextLog("Could not modify & save system.config2.xml"); }
                }
            }
            catch { AddTextLog("Could not open system.config2.xml"); }
        }

        public void RepackRestoredConfig()
        {
            AddTextLog("Repacking " + datbackup);
            try
            {
                string PathtoDat = myDictionary[datbackup];
                usedfile = datbackup;
                usedfilepathonly = PathtoDat + "\\" + datbackup + ".files";
                Compiler(usedfile);
                DoRepackProcessR();
            }
            catch (Exception e) { Prompt.Popup(e.ToString()); }
        }

        public void DoRepackProcessR()
        {
            try
            {
                AddTextLog("Repacked & Replaced");
                metroLabel14.Text = "Clean";
                AddTextLog("Restored " + datbackup + "!");
            }
            catch { AddTextLog("Error: Could Not Copy Restored Client!"); }
        }

        private void metroButton30_Click(object sender, EventArgs e)
        {
            CleanMem();
        }

        public void CleanMem()
        {
            if (GameStarted == true)
            {
                AddTextLog("Cleaning Memory...");
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;
                long before = GC.GetTotalMemory(false);
                AddTextLog("Before: " + before / 1024 + " MB");
                GC.AddMemoryPressure(before);
                GC.Collect(2, GCCollectionMode.Optimized, false);
                long after = GC.GetTotalMemory(false);
                GC.RemoveMemoryPressure(after);
                AddTextLog("After: " + after / 1024 + " MB");
                AddTextLog("Freed: " + (before - after) / 1024 + " MB");
                AddTextLog("Memory Cleaned");
            }
            else
            {
                AddTextLog("Cleaning Memory...");
                GCSettings.LatencyMode = GCLatencyMode.Interactive;
                long before = GC.GetTotalMemory(true);
                AddTextLog("Before: " + before / 1024 + " MB");
                GC.AddMemoryPressure(before);
                GC.Collect(2, GCCollectionMode.Forced, false);
                long after = GC.GetTotalMemory(true);
                GC.RemoveMemoryPressure(after);
                AddTextLog("After: " + after / 1024 + " MB");
                AddTextLog("Freed: " + (before - after) / 1024 + " MB");
                AddTextLog("Memory Cleaned");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        private Dictionary<string, int> ClientHandler = new Dictionary<string, int>();

        private void PlayGame()
        {
            bool isitnew = false;
            if (metroComboBox9.SelectedItem != null)
            {
                if (metroComboBox9.SelectedItem.ToString() == "New Instance")
                {
                    isitnew = true;
                }
                else
                {
                    isitnew = false;
                }
            }
            if (GameStarted && !isitnew)
            {
                string tmp = "";
                try
                {
                    if (metroToggle22.Checked == true)
                    {
                        tmp = metroComboBox9.SelectedItem.ToString();
                        foreach (string name in ClientHandler.Keys)
                        {
                            if (tmp == name)
                            {
                                // Kill process
                                Process.GetProcessById(ClientHandler[name]).Kill();
                                // Remove from MultiClient Lib
                                metroComboBox9.SelectedIndex = -1;
                                metroComboBox9.Items.Remove(tmp);
                                ClearClient.Add(name, name);
                                // Select the one available (if any)
                                if (metroComboBox9.Items.Count > 1)
                                {
                                    metroComboBox9.SelectedIndex = 1;
                                }
                                else
                                {
                                    metroComboBox9.SelectedIndex = -1;
                                    metroPanel6.Visible = false;
                                }
                                AddTextLog("Killed Game Process");
                            }
                        }
                        //Clearing junk
                        foreach (string name in ClearClient.Keys)
                        {
                            ClientHandler.Remove(name);
                        }
                        // Clear ClearClient Dictionary itself
                        ClearClient = new Dictionary<string, string>();
                    }
                    else
                    {
                        bool killed = false;
                        string tmpclientname = "";
                        if (customclientname != "")
                        {
                            tmpclientname = customclientname.Replace(".exe", "");
                        }
                        else
                        {
                            tmpclientname = "Client";
                        }
                        foreach (var process in Process.GetProcessesByName(tmpclientname))
                        {
                            if (!killed)
                            {
                                if (process.Id == appuniqueid)
                                {
                                    killed = true;
                                    process.Kill();
                                    AddTextLog("Killed Game Process");
                                    appuniqueid = 0;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    if (tmp != "")
                    {
                        Prompt.Popup("Error: Could not kill process owned by " + tmp + "!");
                    }
                    else { Prompt.Popup("Error: Process not found!"); }
                    metroComboBox9.SelectedIndex = -1;
                    metroComboBox9.Items.Remove(tmp);
                    if (metroComboBox9.Items.Count > 1)
                    {
                        metroComboBox9.SelectedIndex = 1;
                    }
                }
            }
            else
            {
                // Patch & Play!
                AddTextLog("Using vars...");
                metroButton1.Enabled = false;
                // Patch client launcher!
                if (metroLabel14.Text == "Clean" && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("North America") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Europe") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Korean") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Taiwan"))
                {
                    AddTextLog("Patching...");
                    patchConfigDat();
                }
                else
                {
                    AddTextLog("Skipped Patching!");
                    LaunchGame();
                }
            }
        }

        private void patchConfigDat()
        {
            // Patch Config
            AddTextLog("Getting Patch...");
            try
            {
                patchDownloaded();
            }
            catch
            {
                AddTextLog("Error: Unable To Retrieve Patch!");
            }
        }

        public void DoPatchingProcess()
        {
            try
            {
                AddTextLog("Extracted " + datverifier);
                AddTextLog("Checking string");
                string String = @"<option name=""use-web-launching"" value=""true"" />";
                if (File.ReadAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml").Contains(String))
                {
                    try
                    {
                        AddTextLog("Backing up");
                        File.Copy(DataPath + "\\" + datverifier + "", DataPath + "\\backup\\" + datverifier + "", true);
                        AddTextLog("Backup made");
                    }
                    catch { AddTextLog("Could not copy " + datverifier + " to backup folder"); }
                }
                try
                {
                    AddTextLog("Replacing values");
                    var filecontent = File.ReadAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml").Replace(@"<option name=""use-web-launching"" value=""true"" />", @"<option name=""use-web-launching"" value=""false"" />");
                    File.WriteAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml", filecontent);
                    AddTextLog("Replaced");
                    RepackPatchedConfig();
                }
                catch { AddTextLog("Could not modify & save system.config2.xml"); }
            }
            catch { AddTextLog("Could not open system.config2.xml"); }
        }

        private string datverifier = "";

        public void InternalPatcherAndVerifier()
        {
            DirectoryInfo configfolder = new DirectoryInfo(DataPath);
            FileInfo[] configfiles = configfolder.GetFiles("*.dat");
            foreach (FileInfo configfile in configfiles)
            {
                datverifier = configfile.ToString();
                try
                {
                    if ((!configfile.ToString().Contains("xml")) && (configfile.ToString().Contains("config")))
                    {
                        //
                        AddTextLog("Extracting " + datverifier);
                        usedfile = datverifier;
                        usedfilepath = DataPath + "\\" + datverifier;
                        Extractor(usedfile);
                        DoPatchingProcess();
                    }
                }
                catch (Exception e) { Prompt.Popup(e.ToString()); }
            }
        }

        public void DoRepackProcess()
        {
            try
            {
                AddTextLog("Repacked & Replaced");
                metroLabel14.Text = "Patched";
                AddTextLog("Patched " + datverifier + "!");
            }
            catch { AddTextLog("Error: Could Not Copy Patched Client!"); }
        }

        public void RepackPatchedConfig()
        {
            AddTextLog("Repacking " + datverifier);
            try
            {
                string PathtoDat = myDictionary[datverifier];
                usedfile = datverifier;
                usedfilepathonly = PathtoDat + "\\" + datverifier + ".files";
                Compiler(usedfile);
                DoRepackProcess();
            }
            catch (Exception e) { Prompt.Popup(e.ToString()); }
        }

        private void patchDownloaded()
        {
            nonmodded = true;
            // Patch Downloaded then proceed
            AddTextLog("Patching Launcher...");
            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Refresh();
            try
            {
                if (UseToken == false)
                {
                    InternalPatcherAndVerifier();
                }
                CleanOtherMess();  // Skip Cleaning
                LaunchGame();
            }
            catch
            {
                AddTextLog("Error: Could Not Patch Client!");
                metroButton1.Enabled = true;
            }
            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Refresh();
        }

        private int CleanerVal = 0;

        private void AutoCleaner()
        {
            // Check the setting
            if (metroComboBox7.Text.ToString() != "OFF")
            {
                // Multiply by value used
                int tmp = Convert.ToInt32(metroComboBox7.Text.ToString()); // minutes
                CleanerVal = tmp * 60000; // x times 60000 ms in 1 minute
                AutoCleanerStart();
            }
        }

        private void AutoCleanerStart()
        {
            CClock.Interval = CleanerVal;
            CClock.Start();
        }

        private void CClock_Tick(object sender, EventArgs e)
        {
            CleanMem();
        }

        private bool Maintenance = false;
        private bool LoginOccured = false;

        private void LaunchGame()
        {
            // Disable mod window
            metroButton8.Enabled = false;
            metroButton9.Enabled = false;
            metroButton10.Enabled = false;
            metroButton11.Enabled = false;
            // Start Client.exe
            string clienttofind = "";
            string clientname = "";
            if (customclientname != "")
            {
                clienttofind = ".\\" + customclientname;
                clientname = customclientname;
            }
            else
            {
                clienttofind = ".\\Client.exe";
                clientname = "Client.exe";
            }
            AddTextLog("Finding Client.exe...");
            int i = 0;
            Dictionary<string, string> clients = new Dictionary<string, string>();
            if (Directory.Exists(RegPath + LauncherPath) || Directory.Exists(RegPath + LauncherPath64))
            {
                if (Directory.Exists(RegPath + LauncherPath))
                {
                    LaunchPath = RegPath + LauncherPath + clienttofind;
                    AddTextLog("Found! (32 bit)");
                    clients.Add("32bit", LauncherPath);
                    i++;
                }
                if (Directory.Exists(RegPath + LauncherPath64))
                {
                    LaunchPath = RegPath + LauncherPath64 + clienttofind;
                    AddTextLog("Found! (64 bit)");
                    clients.Add("64bit", LauncherPath64);
                    i++;
                }
            }
            else
            {
                AddTextLog("Error: Path to " + clienttofind + " not found!");
                return;
            }
            if (defaultclient != "")
            {
                LaunchPath = RegPath + clients[defaultclient].ToString() + clienttofind;
                AddTextLog("Using: " + defaultclient + " " + clientname);
            }
            else if (i > 1)
            {
                DialogResult dialogResult = Prompt.MultipleClient();
                if (dialogResult == DialogResult.Yes)
                {
                    LaunchPath = RegPath + LauncherPath + clienttofind;
                    AddTextLog("Using 32bit " + clientname);
                    SaveDefaultClient("32bit");
                }
                else
                if (dialogResult == DialogResult.No)
                {
                    LaunchPath = RegPath + LauncherPath64 + clienttofind;
                    AddTextLog("Using 64bit " + clientname);
                    SaveDefaultClient("64bit");
                }
                else
                {
                    AddTextLog("Skipping default launcher!");
                }
            }
            // Check if any addons are enabled
            bool AEDetected = false;
            foreach (TreeNode node in treeView3.Nodes)
            {
                if (node != null)
                {
                    if (node.Checked)
                    {
                        AEDetected = true;
                    }
                }
            }
            if (AEDetected == true)
            {
                AddTextLog("Applying Addons...");
                StartGameAddons();
            }
            AddTextLog("Starting Auth...");
            // Default values
            // /GarenaToken:token --publisher:garena /GameRegion:thailand /TextLang:th // Thailand
            // /LaunchByLauncher /Sesskey /SessKey:"" /CompanyID:"14" /ChannelGroupIndex:"-1" // Japanese
            // /launchbylauncher -lang:english /CompanyID:"12" /ChannelGroupIndex:"-1" -lang:English -lite:2 -region:0 /* NA VARS */
            // -lite:2 /sesskey /LaunchByLauncher /ServiceRegion:"15" /AuthProviderCode:"np" /ServiceNetwork:"live" /NPServerAddr:"210.64.136.126:6600" /PresenceId:"TWBNS22" /* TAIWAN VARS */
            // AuthnToken:"mytoken"

            if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("North America") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Europe") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Korean") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Taiwan"))
            {
                if (metroLabel14.Text != "Clean" && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Korean"))
                {
                    RestoreConfigFiles();
                }
                GetLogin();
                if (LoginOccured && !Maintenance)
                {
                    GrabToken();
                }
                else
                {
                    metroButton1.Enabled = true;
                    if (Maintenance)
                    {
                        // Recheck for n00b friendly users
                        LauncherInfo();
                        // Continue onwards
                        if (Maintenance)
                        {
                            AddTextLog("Server in Maintenance");
                            AddTextLog("Cancelled");
                        }
                        else
                        {
                            GrabToken();
                        }
                    }
                    else
                    {
                        AddTextLog("Login Failed");
                        AddTextLog("Cancelled");
                    }
                }
            }
            else if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Japanese"))
            {
                AddTextLog("Starting Client!");
                Process proc = new Process();
                proc.StartInfo.FileName = LaunchPath;
                proc.StartInfo.Arguments = "/LaunchByLauncher /Sesskey /SessKey:\"\" /CompanyID:\"14\" /ChannelGroupIndex:\"-1\"" + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = false;
                //proc.StandardError reader += ;
                bool gameworked = false;
                try
                {
                    // Clean memory if true
                    if (AutoClean == true)
                    {
                        CleanMem();
                    }
                }
                catch
                {
                    AddTextBoxLog("Notice: Could not clear any memory!");
                }
                try
                {
                    proc.Start();
                    string tmpclientname = "Client.exe";
                    if (customclientname != "")
                    {
                        tmpclientname = customclientname;
                    }
                    AddTextLog("Started " + tmpclientname + "!");
                    // Set the ID of the process
                    appuniqueid = proc.Id;
                    // Continue
                    GameStarted = true;
                    gameworked = true;
                    // MultiClient notice
                    AddTextBoxLog("Notice: BnS Buddy does directly support Multiclient for Japanese server!");
                    // Resume
                    this.WindowState = FormWindowState.Minimized;
                }
                catch
                {
                    Show();
                    notifyIcon1.Visible = false;
                    metroButton1.Enabled = true;
                    // Verify mod manager
                    foreach (TreeNode nodes in treeView2.Nodes)
                    {
                        if (nodes != null)
                        {
                            RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                            if (Directory.Exists(RealModPath))
                            {
                                checkButtons(true);
                            }
                            else
                            {
                                nodes.Remove();
                            }
                        }
                    }
                    //
                    AddTextLog("Error: Could Not Start Client.exe!");
                }
                if (gameworked == true)
                {
                    try
                    {
                        AutoCleaner();
                    }
                    catch { AddTextLog("Error: Could not clean memory with autocleaner!"); }
                }
            }
            else
            {
                AddTextLog("Starting Client!");
                Process proc = new Process();
                proc.StartInfo.FileName = LaunchPath;
                proc.StartInfo.Arguments = "-lang:" + languageID + " -lite:2 -region:" + regionID + " /sesskey /launchbylauncher  /CompanyID:12 /ChannelGroupIndex:-1 " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = false;
                bool gameworked = false;
                try
                {
                    // Clean memory if true
                    if (AutoClean == true)
                    {
                        CleanMem();
                    }
                }
                catch
                {
                    AddTextBoxLog("Notice: Could not clear any memory!");
                }
                try
                {
                    proc.Start();
                    string tmpclientname = "Client.exe";
                    if (customclientname != "")
                    {
                        tmpclientname = customclientname;
                    }
                    AddTextLog("Started " + tmpclientname + "!");
                    // Set the ID of the process
                    appuniqueid = proc.Id;
                    // Continue
                    GameStarted = true;
                    gameworked = true;
                    // MultiClient notice
                    AddTextBoxLog("Notice: BnS Buddy does directly support Multiclient for this server!");
                    // Resume
                    this.WindowState = FormWindowState.Minimized;
                }
                catch
                {
                    Show();
                    notifyIcon1.Visible = false;
                    metroButton1.Enabled = true;
                    // Verify mod manager
                    foreach (TreeNode nodes in treeView2.Nodes)
                    {
                        if (nodes != null)
                        {
                            RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                            if (Directory.Exists(RealModPath))
                            {
                                checkButtons(true);
                            }
                            else
                            {
                                nodes.Remove();
                            }
                        }
                    }
                    //
                    AddTextLog("Error: Could Not Start Client.exe!");
                }
                if (gameworked == true)
                {
                    try
                    {
                        AutoCleaner();
                    }
                    catch { AddTextLog("Error: Could not clean memory!"); }
                }
            }
        }

        private void GetLogin()
        {
            Hide();
            Splash1 s1 = new Splash1();
            s1.Visible = false;
            s1.ShowDialog();
            username = @s1.username.ToString().ToLower();
            password = @s1.password.ToString();
            if (username.Length > 1 && password.Length > 1)
            {
                if (!metroComboBox9.Items.Contains(username))
                {
                    LoginOccured = true;
                }
                else
                {
                    AddTextLog("This user is already logged in!");
                }
            }
            //
            if (Debugging)
                Prompt.Popup("Username used: " + username + Environment.NewLine + "Password used: " + password);
            //
            UseToken = true;
            Show();
            this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NotifAction();
        }

        public void NotifAction()
        {
            // Dispose ContextMenu
            if (ContextMenu.IsParent && ContextMenu != null)
            {
                ContextMenu.Dispose();
            }
            // Continue
            Show(); // Shows the program on taskbar
            if (WindowState != FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
            }
            if (notifyIcon1.Visible == true)
            {
                notifyIcon1.Visible = false; // Hides tray icon again
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (AllowMinimize == true)
            {
                if (this.WindowState == FormWindowState.Minimized)//this code gets fired on every resize
                {
                    // Generate ContextMenu
                    ConfigureContext();
                    // Continue
                    this.Hide();//hides the program on the taskbar
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(50, "BnS Buddy", "Minimized to tray.", ToolTipIcon.Info);
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private string RegPathSplash = "";
        private string FullPathSplash = "";
        private string FullBackupPathSplash = ""; // old
        private string NewFullBackupPathSplash = ""; // new
        private string workingPathSplash = "";
        private string ModPathSplash = ""; // old
        private string NewModPathSplash = ""; // new
        private string NewSplash = "";
        private string ExtensionSplash = "";

        public void InitializeSplash()
        {
            if (PathFound == true)
            {
                // List Splash Images
                try
                {
                    DirectoryInfo dinfo2 = new DirectoryInfo(@NewModPathSplash + "\\");
                    FileInfo[] Files2 = dinfo2.GetFiles("*.bmp");
                    foreach (FileInfo file2 in Files2)
                    {
                        listBox1.Items.Add(file2.Name);
                    }
                    if (listBox1.Items.Count != 0)
                    {
                        listBox1.SelectedIndex = 0;
                        pictureBox1.Image = System.Drawing.Image.FromFile(NewModPathSplash + "\\" + listBox1.SelectedItem.ToString());
                    }
                    else
                    {
                        listBox1.SelectedIndex = -1;
                    }
                }
                catch
                {
                    if (Directory.GetFileSystemEntries(NewModPathSplash).Length == 0)
                    {
                        if (Directory.GetFileSystemEntries(NewFullBackupPathSplash).Length == 0)
                        {
                            metroButton4.Enabled = true;
                            metroButton5.Enabled = false;
                            metroButton6.Enabled = true;
                        }
                        return;
                    }
                    if (Directory.GetFileSystemEntries(NewModPathSplash).Length != 0)
                    {
                        if (Directory.GetFileSystemEntries(NewFullBackupPathSplash).Length != 0)
                        {
                            metroButton4.Enabled = false;
                            metroButton5.Enabled = true;
                            metroButton6.Enabled = true;
                        }
                        else
                        {
                            metroButton4.Enabled = true;
                            metroButton5.Enabled = false;
                            metroButton6.Enabled = true;
                        }
                        return;
                    }
                    else
                    {
                        AddTextLog("Error: Was Not Able to Populate!");
                    }
                }
            }
        }

        private void CreatePaths(string PathName)
        {
            // Create the missing path
            Directory.CreateDirectory(PathName);
        }

        public void Verify()
        {
            // Verify Backup
            if (File.Exists(NewFullBackupPathSplash + "\\Splash.bmp"))
            {
                // Normal Path MD5
                bool moddedsplash = false;
                string md51 = checkMD5(FullPathSplash + "\\Splash.bmp");
                string md52 = "";
                // Compare to all modded MD5
                foreach (string file in Directory.GetFiles(NewModPathSplash))
                {
                    if (file.Length > 0)
                    {
                        md52 = checkMD5(file);
                        if (md52 == md51)
                        {
                            moddedsplash = true;
                        }
                    }
                }
                // DO ETTTT
                if (moddedsplash)
                {
                    metroLabel17.Text = "Modded";
                    metroButton4.Enabled = false;
                    metroButton5.Enabled = true;
                }
                else
                {
                    metroLabel17.Text = "Original"; metroButton5.Enabled = false; metroButton4.Enabled = true;
                }
            }
            else
            {
                metroButton5.Enabled = false;
                metroButton4.Enabled = true;
                metroLabel17.Text = "Original";
            }
            // Check if already modded or not.
        }

        public void GetPaths()
        {
            // Grab Path to Splash
            if (PathFound == true)
            {
                RegPathSplash = RegPath;
                if (Korean == false)
                {
                    ExtensionSplash = "\\contents\\Local\\" + autofinder;
                    FullPathSplash = RegPathSplash + ExtensionSplash + "\\" + autocook + "\\Splash";
                }
                else
                {
                    ExtensionSplash = "\\contents\\bns";
                    FullPathSplash = RegPathSplash + ExtensionSplash + "\\Splash";
                }
                workingPathSplash = FullPathSplash;
                // Get Backup Path & Mods Path then create if missing
                FullBackupPathSplash = FullPathSplash + "\\backup";
                // Create new splash path
                Directory.CreateDirectory(AppPath + "\\Splashes\\backup"); // new backup path
                Directory.CreateDirectory(AppPath + "\\Splashes\\mods"); // new mods path
                NewModPathSplash = AppPath + "\\Splashes\\mods";
                NewFullBackupPathSplash = AppPath + "\\Splashes\\backup";
                // Continue with old
                ModPathSplash = FullPathSplash + "\\mods";
                // FIX PATHS
                FullBackupPathSplash = FullBackupPathSplash.Replace(@"\\", @"\");
                ModPathSplash = ModPathSplash.Replace(@"\\", @"\");
                // Move existing backup splashe from old to new dir
                if (Directory.Exists(FullBackupPathSplash))
                {
                    // Move backup
                    if (File.Exists(FullBackupPathSplash + "\\Splash.bmp"))
                    {
                        File.Move(FullBackupPathSplash + "\\Splash.bmp", NewFullBackupPathSplash + "\\Splash.bmp");
                    }
                    // Clear any files
                    foreach (string file in Directory.GetFiles(FullBackupPathSplash))
                    {
                        if (file.Length > 0)
                        {
                            File.Delete(file);
                        }
                    }
                    // Delete the dir
                    Directory.Delete(FullBackupPathSplash);
                }
                // Move existing modded splashes from old to new dir
                if (Directory.Exists(ModPathSplash))
                {
                    foreach (string file in Directory.GetFiles(ModPathSplash))
                    {
                        string tmp = Path.GetFileName(file);
                        if (file.Length > 0)
                        {
                            File.Move(file, NewModPathSplash + "\\" + tmp);
                        }
                    }
                    // Delete the dir
                    Directory.Delete(ModPathSplash);
                }
            }
            else
            {
                metroButton5.Enabled = false;
                metroButton4.Enabled = false;
                metroButton6.Enabled = false;
                listBox1.Enabled = false;
                pictureBox1.Enabled = false;
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            // Browse folder
            if (FullPathSplash.Contains(@"\\")) { FullPathSplash = FullPathSplash.Replace(@"\\", @"\"); }
            Process.Start("explorer.exe", NewModPathSplash);
        }

        private void metroLabel17_TextChanged(object sender, EventArgs e)
        {
            // Set Status & Buttons
            if (metroLabel17.Text == "Original")
            {
                metroButton5.Enabled = false;
                metroButton4.Enabled = true;
            }
            if (metroLabel17.Text == "Modded")
            {
                metroButton4.Enabled = false;
            }
        }

        private void metroButton34_Click(object sender, EventArgs e)
        {
            Process.Start(NewSplash);
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            if (listBox1.SelectedItem != null)
            {
                NewSplash = NewModPathSplash + "\\" + listBox1.SelectedItem.ToString();
                if (File.Exists(NewSplash))
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(NewSplash);
                    // Enable preview button
                    metroButton34.Enabled = true;
                }
                else
                {
                    listBox1.ClearSelected();
                    listBox1.Items.Remove(listBox1.SelectedItem.ToString());
                    // Disable preview button
                    metroButton34.Enabled = false;
                }
            }
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                try
                {
                    // Backup
                    if (File.Exists(NewFullBackupPathSplash + "\\Splash.bmp")) { File.Delete(NewFullBackupPathSplash + "\\Splash.bmp"); }
                    File.Move(FullPathSplash + "\\Splash.bmp", NewFullBackupPathSplash + "\\Splash.bmp");
                    // Add new
                    File.Copy(NewSplash, FullPathSplash + "\\Splash.bmp", true);
                    metroLabel17.Text = "Modded";
                    metroButton4.Enabled = false;
                    metroButton5.Enabled = true;
                }
                catch
                {
                    Prompt.Popup("Error: Could not replace image!");
                }
                pictureBox1.Image = System.Drawing.Image.FromFile(NewModPathSplash + "\\" + listBox1.SelectedItem.ToString());
            }
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            try
            {
                // Destroy modded
                File.Delete(FullPathSplash + "\\Splash.bmp");
                // Restore
                File.Move(NewFullBackupPathSplash + "\\Splash.bmp", FullPathSplash + "\\Splash.bmp");
                metroLabel17.Text = "Original";
                metroButton5.Enabled = false;
                metroButton4.Enabled = true;
            }
            catch
            {
                Prompt.Popup("Error: Could not replace image!");
            }
            pictureBox1.Image = System.Drawing.Image.FromFile(NewModPathSplash + "\\" + listBox1.SelectedItem.ToString());
        }

        private void metroButton7_Click_1(object sender, EventArgs e)
        {
            SplashPopulater();
        }

        public void SplashPopulater()
        {
            try
            {
                // Fail-safe
                metroButton34.Enabled = false;
                // Deselect
                listBox1.SelectedIndex = -1;
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                // Continue
                DirectoryInfo dinfo2 = new DirectoryInfo(@NewModPathSplash + "\\");
                FileInfo[] Files2 = dinfo2.GetFiles("*.bmp");
                // Remove invalid files
                foreach (string file1 in listBox1.Items)
                {
                    if (!File.Exists(NewModPathSplash + "\\" + file1))
                    {
                        listBox1.Items.Remove(file1);
                    }
                }
                // Add new files
                foreach (FileInfo file2 in Files2)
                {
                    if (!listBox1.Items.Contains(file2.Name))
                    {
                        listBox1.Items.Add(file2.Name);
                    }
                }
                //pictureBox1.Image = System.Drawing.Image.FromFile(FullPathSplash + "\\mods\\" + listBox1.SelectedItem.ToString());
            }
            catch
            {
                if (Directory.GetFileSystemEntries(NewModPathSplash).Length == 0)
                {
                    metroButton4.Enabled = false;
                    metroButton5.Enabled = false;
                    metroButton6.Enabled = true;
                    return;
                }
                if (Directory.GetFileSystemEntries(NewModPathSplash).Length != 0)
                {
                    metroButton4.Enabled = true;
                    metroButton5.Enabled = true;
                    metroButton6.Enabled = true;
                    return;
                }
                else
                {
                    AddTextLog("Error: Was Not Able to Populate!");
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        //Imported
        public BackgroundWorker bw;

        private string backupFolderPath = "";
        private string modFolderPath = "";
        private string modsFolderPath = "";
        private string workingPath = "";
        public string originalFolderPath = "";
        public string bnsExeFolderPath = "";
        public string ncsoftExeFolderPath = "";
        public bool bnsFolderIsSet = true;
        public bool ncsoftFolderIsSet = true;
        public bool installFlag = true;

        //Imported
        private string tmpdir = "";

        private string NewPath = "";
        private string FullModPathMan = "";
        private string FullModsPathMan = "";
        private string FullSettingsPathMan = "";
        private string RealModPath = "";

        public void InitializeManager()
        {
            // Fix FullPath before using it
            FullPath = FullPath.Replace(@"\\", @"\");
            // Proceed
            tmpdir = FullPath;
            NewPath = tmpdir.Replace("\\CookedPC", "").Replace(@"\\", @"\");
            workingPath = NewPath + "\\CookedPC_Settings";
            modsFolderPath = FullPath + "\\mod";
            if (!CustomModSet)
            {
                modFolderPath = NewPath + "\\CookedPC_Mod";
                backupFolderPath = NewPath + "\\CookedPC_Backup";
            }
            else
            {
                modFolderPath = metroTextBox7.Text + "\\CookedPC_Mod";
                backupFolderPath = metroTextBox7.Text + "\\CookedPC_Backup";
            }
            // FIX BROKEN PATHS
            workingPath = workingPath.Replace(@"\\", @"\");
            modFolderPath = modFolderPath.Replace(@"\\", @"\");
            modsFolderPath = modsFolderPath.Replace(@"\\", @"\");
            backupFolderPath = backupFolderPath.Replace(@"\\", @"\");
        }

        private void VerifyUsage()
        {
            try
            {
                isBnsFolderSet();
            }
            catch (Exception ex) { Prompt.Popup("Error: " + ex.ToString()); }
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    if (Directory.Exists(RealModPath))
                    {
                        checkButtons(true);
                    }
                    else
                    {
                        nodes.Remove();
                    }
                }
            }
        }

        private bool isBnsFolderSet(bool outputMessage = false)
        {
            originalFolderPath = FullPath;
            // Grab the client.exe location
            string tmp = originalFolderPath;
            tmp = tmp.Replace("\\contents\\Local\\" + autofinder + "\\" + autocook + "\\CookedPC", ""); // Remove the path to CookedPC
            bnsExeFolderPath = tmp + "\\bin";
            bnsFolderIsSet = true;
            return true;
        }

        private void checkButtons(bool output = false)
        {
            // Check how many upk files there are in the mods folder.
            int i = 0;
            int j = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(RealModPath);
            foreach (var file in dirInfo.GetFiles("*.*"))
            {
                if (!file.Name.Contains(".txt"))
                {
                    i++;
                }
            }
            // Check how many upk files there are in the backup folder
            dirInfo = new DirectoryInfo(backupFolderPath);
            foreach (var file in dirInfo.GetFiles("*.*"))
            {
                if (!file.Name.Contains(".txt"))
                {
                    j++;
                }
            }
            // Are there files in the backups folder?
            if (j == 0)
            {
                // How about the mods folder?
                if (i == 0)
                {
                    if (output)
                    {
                        // No .upk files anywhere, start panicking!
                        AddTextBoxLog(Environment.NewLine);
                        if (!RealModPath.Contains("(Installed)"))
                        {
                            AddTextBoxLog("[Notice] " + "No modded files detected in the \"" + Path.GetFileName(RealModPath) + "\" folder. Press Mod Folder" + " Then drag the files in there then press Refresh button.");
                        }
                        else
                        {
                            AddTextBoxLog("[Notice] " + Path.GetFileName(RealModPath) + " mod is already installed");
                        }
                    }
                }
                else
                {
                    if (output)
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] " + "Found " + i.ToString() + " game files in the " + Path.GetFileName(RealModPath) + " folder.");
                    }
                }
            }
            if (j != 0)
            {
                // "Found files in the "backups" folder, this takes priority as they are original files
                if (output)
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Log] " + "Found " + j.ToString() + " game files in the \"CookedPC_Backup\" folder.");
                }
            }
            // Determine whether the install or deinstall button should be enabled
            metroButton9.Enabled = true;
            metroButton11.Enabled = true;

            // Check if the BnS directory is set
            if (!bnsFolderIsSet)
            {
                metroButton11.Enabled = false;
                metroButton9.Enabled = false;
            }
        }

        private void checkLegacy()
        {
            // If we are indeed running it for the first time (firstEverRun was not set
            // to false by the imported JSON, or it didn't exist in the first place)

            // Check how many upk files there are in the mods folder.
            int i = 0;
            int j = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(RealModPath);
            foreach (var file in dirInfo.GetFiles("*.*"))
            {
                if (!file.Name.Contains(".txt"))
                {
                    i++;
                }
            }
            // Check how many upk files there are in the backup folder
            dirInfo = new DirectoryInfo(backupFolderPath);
            foreach (var file in dirInfo.GetFiles("*.*"))
            {
                if (!file.Name.Contains(".txt"))
                {
                    j++;
                }
            }
        }

        public void JsonManager()
        {
            // Determine the install flag from the legacy way of checking things
            if (File.Exists(workingPath + "\\database.json")) { File.Delete(workingPath + "\\database.json"); }

            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    checkLegacy();
                }
            }
            bw = new BackgroundWorker();
            isBnsFolderSet(true);
        }

        private void GetPath()
        {
            if (PathFound == true)
            {
                FullModsPathMan = FullPath + "\\mod";
                // FIX PATH
                FullModsPathMan = FullModsPathMan.Replace(@"\\", @"\");
                // CONTINUE
                if (FullPath.Length > 0)
                {
                    if (!Directory.Exists(FullModsPathMan)) { CreatePaths(FullModsPathMan); }
                }
                if (CustomModSet == true)
                {
                    if (!Directory.Exists(backupFolderPath)) { CreatePaths(backupFolderPath); }
                    if (!Directory.Exists(FullModPathMan)) { CreatePaths(FullModPathMan); }
                }
                else
                {
                    backupFolderPath = NewPath + "\\CookedPC_Backup";
                    // FIX PATH
                    backupFolderPath = backupFolderPath.Replace(@"\\", @"\");
                    // CONTINUE
                    if (!Directory.Exists(backupFolderPath)) { CreatePaths(backupFolderPath); }
                    FullModPathMan = NewPath + "\\CookedPC_Mod";
                    // FIX PATH
                    FullModPathMan = FullModPathMan.Replace(@"\\", @"\");
                    // CONTINUE
                    if (!Directory.Exists(FullModPathMan)) { CreatePaths(FullModPathMan); }
                }
                FullSettingsPathMan = NewPath + "\\CookedPC_Settings";
                // FIX PATH
                FullSettingsPathMan = FullSettingsPathMan.Replace(@"\\", @"\");
                // CONTINUE
                if (Directory.Exists(FullSettingsPathMan)) { if (Directory.GetFiles(FullSettingsPathMan).Length == 0) { Directory.Delete(FullSettingsPathMan); } else { File.Delete(FullSettingsPathMan + "\\database.json"); Directory.Delete(FullSettingsPathMan); ; } }
            }
        }

        private void disableButtons()
        {
            metroButton8.Enabled = false;
            metroButton9.Enabled = false;
            metroButton10.Enabled = false;
            metroButton11.Enabled = false;
            metroButton14.Enabled = false;
        }

        private void enableButtons()
        {
            metroButton8.Enabled = true;
            metroButton9.Enabled = true;
            metroButton10.Enabled = true;
            metroButton11.Enabled = true;
            metroButton14.Enabled = true;
            treeView2.Refresh();
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    if (Directory.Exists(RealModPath))
                    {
                        checkButtons();
                    }
                    else
                    {
                        nodes.Remove();
                    }
                }
            }
        }

        private async void doFileSwap(string obj)
        {
            // Path to modded folder selected
            RealModPath = obj;
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            // Disable all the buttons
            disableButtons();

            // If the background worker is not busy, which it shouldn't be
            if (!bw.IsBusy)
            {
                // If the background worker is not busy, lets get this thing started
                bw.RunWorkerAsync(obj);
            }
        }

        public string newbackuppath = "";
        public string tmpnode = "";

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string path_exact = e.Argument.ToString();
            string file_exact = Path.GetFileName(path_exact);
            string mod_path = new DirectoryInfo(path_exact).Name;

            //if (_workerCompleted.Set() == false) {
            if ((installFlag == true) && (!file_exact.Contains("(Installed)"))) //catcher
            {
                RealModPath = @path_exact.ToString();
                tmpnode = @file_exact.ToString();
                newbackuppath = @backupFolderPath + "\\" + tmpnode;
                DirectoryInfo dirInfo = new DirectoryInfo(RealModPath);
                BackgroundWorker worker = sender as BackgroundWorker;
                string message = string.Empty;
                int fileCounter = 0;
                int i = 0;
                int max = dirInfo.GetFiles("*.upk").Count();
                max += dirInfo.GetFiles("*.umap").Count();
                int curPercent = 0;

                if (max != 0)
                {
                    foreach (string fileName in Directory.GetFiles(RealModPath))
                    {
                        string realfileName = fileName.Split(Path.DirectorySeparatorChar).Last();
                        if (realfileName != "description.txt" && (realfileName.EndsWith(".upk") || realfileName.EndsWith(".umap"))) // only install proper files tweak
                        {
                            CheckForIllegalCrossThreadCalls = false;
                            AddTextBoxLog(Environment.NewLine);
                            /*
                            try
                            {
                                // Create original files backup directory of the mod applied
                                if (!Directory.Exists(backupFolderPath + "\\" + tmpnode))
                                {
                                    CreatePaths(backupFolderPath + "\\" + tmpnode);
                                    newbackuppath = backupFolderPath + "\\" + tmpnode;
                                }
                                // Set folder path for the original files to go to

                                // Check if the file we're about to install, exists in CookedPC or not.
                                // If yes, move it away
                                if (File.Exists(originalFolderPath + "\\" + realfileName))
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " [original] to CookedPC_Backup");
                                    File.Copy(originalFolderPath + "\\" + realfileName, newbackuppath + "\\" + realfileName, true);
                                    AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " [original] to CookedPC_Backup" + "/" + tmpnode);
                                    AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [original] from CookedPC");
                                    File.Delete(originalFolderPath + "\\" + realfileName);
                                    AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [original] from CookedPC");
                                }
                                else
                                {
                                    try
                                    {
                                        AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " (unique) [modded] to CookedPC_Mod");
                                        string val = realfileName;
                                        string tmp = "";
                                        if (val.Contains(".upk"))
                                        {
                                            tmp = val.Replace(".upk", " (unique).upk");
                                        }
                                        else if (val.Contains(".umap"))
                                        {
                                            tmp = val.Replace(".umap", " (unique).umap");
                                        }
                                        else
                                        {
                                            // failsafe
                                            tmp = val.Replace(".upk", " (unique).upk");
                                        }
                                        File.Copy(RealModPath + "\\" + realfileName, newbackuppath + "\\" + tmp, true);
                                        AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " (unique) [modded] to CookedPC_Mod");
                                    }
                                    catch
                                    {
                                        AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " (unique) couldn't be copied to CookedPC_Mod");
                                    }
                                }
                            }
                            catch
                            {
                                // Message error
                                AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                            } */
                            try
                            {
                                // Now move over the mod to the CookedPC folder
                                if (File.Exists(RealModPath + "\\" + realfileName))
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " [modded] to CookedPC/mod");
                                    if (!Directory.Exists(modsFolderPath + "\\" + mod_path)) { Directory.CreateDirectory(modsFolderPath + "\\" + mod_path); }
                                    File.Copy(RealModPath + "\\" + realfileName, modsFolderPath + "\\" + mod_path + "\\" + realfileName, true);
                                    AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " [modded] to CookedPC/mod");
                                    /*
                                    AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [modded] from CookedPC_Mod");
                                    File.Delete(RealModPath + "\\" + realfileName);
                                    AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [modded] from CookedPC_Mod");
                                    */
                                }
                            }
                            catch
                            {
                                // Message error
                                AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                            }
                            fileCounter++;
                            // Increment & update stats as well as progress bar
                            i++;
                            // This operating will only get to 50%, and the file transfer will be the other 50%
                            curPercent = ((i * 100) / max);

                            // Update the UI
                            if ((worker.CancellationPending == true))
                            {
                                e.Cancel = true;
                                break;
                            }
                            else
                            {
                                // Perform a time consuming operation and report progress.
                                Thread.Sleep(50);
                                worker.ReportProgress(curPercent);
                            }
                        }
                    }

                    // Show how many files we moved
                    if (fileCounter > 0)
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Done! " + fileCounter + " files were moved.");
                    }
                    else
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Done! No files were moved.");
                    }
                    try
                    {
                        // Rename folder to installed
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Creating new folder.");
                        if (!Directory.Exists(FullModPathMan + "\\" + tmpnode + " (Installed)"))
                        {
                            string originalcopy = FullModPathMan + "\\" + tmpnode;
                            string altererdcopy = FullModPathMan + "\\" + tmpnode + " (Installed)";
                            Directory.Move(originalcopy, altererdcopy);
                            AddTextBoxLog(Environment.NewLine);
                            AddTextBoxLog("[Log] Created.");
                            _workerCompleted.Set();
                        }
                        else
                        {
                            AddTextBoxLog(Environment.NewLine);
                            AddTextBoxLog("[Log] Skipped Creation.");
                        }
                        AddTextBoxLog(Environment.NewLine);
                    }
                    catch (Exception a) { Prompt.Popup("Error: " + a.Message); }
                }
                else { AddTextBoxLog(Environment.NewLine); AddTextBoxLog("[Notice] Can't install an empty mod folder"); _workerCompleted.Set(); }
            }
            else if ((installFlag == false) && (file_exact.Contains("(Installed)"))) //catcher
            {
                bool OLDMETHOD = false;
                int max = 0;
                RealModPath = @path_exact.ToString();
                tmpnode = @file_exact.ToString();
                newbackuppath = @backupFolderPath + "\\" + tmpnode.Replace(" (Installed)", "");
                if (Directory.Exists(newbackuppath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(newbackuppath);
                    max = dirInfo.GetFiles("*.upk").Count();
                    max += dirInfo.GetFiles("*.umap").Count();
                    OLDMETHOD = true;
                }
                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(RealModPath);
                    max = dirInfo.GetFiles("*.upk").Count();
                    max += dirInfo.GetFiles("*.umap").Count();
                }
                BackgroundWorker worker = sender as BackgroundWorker;
                string message = string.Empty;
                int fileCounter = 0;
                int i = 0;
                int curPercent = 0;

                // NEW METHOD
                if (!OLDMETHOD)
                {
                    foreach (string filename in Directory.GetFiles(RealModPath))
                    {
                        string realfileName = filename.Split(Path.DirectorySeparatorChar).Last();
                        string tmp_anew = mod_path.Replace(" (Installed)", "");
                        CheckForIllegalCrossThreadCalls = false;
                        AddTextBoxLog(Environment.NewLine);

                        try
                        {
                            //Prompt.Popup("File: " + modsFolderPath + "\\" + tmp_anew + "\\" + realfileName + " Count: " + Directory.GetFiles(modsFolderPath + "\\" + tmp_anew).Length.ToString());

                            // Check the file type
                            if (realfileName.Contains(".upk") || realfileName.Contains(".umap"))
                            {
                                // Delete Mod from /CookedPC/mod (NEW)
                                if (File.Exists(modsFolderPath + "\\" + tmp_anew + "\\" + realfileName))
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Removing] " + realfileName + " [modded] from CookedPC/mod"); //
                                    File.Delete(modsFolderPath + "\\" + tmp_anew + "\\" + realfileName);
                                    if (Directory.GetFiles(modsFolderPath + "\\" + tmp_anew).Length == 0)
                                    {
                                        Directory.Delete(modsFolderPath + "\\" + tmp_anew);
                                    }
                                    AddTextBoxLog(Environment.NewLine + "[Removed] " + realfileName + " [modded] from CookedPC/mod"); //
                                }

                                fileCounter++;
                                // Increment & update stats as well as progress bar
                                i++;

                                // This operating will only get to 50%, and the file transfer will be the other 50%
                                curPercent = ((i * 100) / max);

                                // Update the UI
                                if ((worker.CancellationPending == true))
                                {
                                    e.Cancel = true;
                                    break;
                                }
                                else
                                {
                                    // Perform a time consuming operation and report progress.
                                    Thread.Sleep(50);
                                    worker.ReportProgress(curPercent);
                                }
                            }
                        }
                        catch
                        {
                            AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                        }
                    }
                }

                // OLD METHOD
                if (OLDMETHOD)
                {
                    foreach (string fileName in Directory.GetFiles(newbackuppath))
                    {
                        string realfileName = fileName.Split(Path.DirectorySeparatorChar).Last();
                        CheckForIllegalCrossThreadCalls = false;
                        AddTextBoxLog(Environment.NewLine);

                        try
                        {
                            // Move the mod file back into the mods folder (OLD)
                            if (File.Exists(modsFolderPath + "\\" + realfileName))
                            {
                                AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " [modded] to CookedPC_Mod"); //
                                File.Copy(modsFolderPath + "\\" + realfileName, RealModPath + "\\" + realfileName, true);
                                AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " [modded] to CookedPC_Mod"); //
                                AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [modded] from CookedPC/mod"); //
                                File.Delete(modsFolderPath + "\\" + realfileName);
                                AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [modded] from CookedPC/mod"); //
                            }
                        }
                        catch
                        {
                            AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                        }
                        try
                        {
                            // Check if the mod file we just uninstalled has a backup in the backup folder.
                            // If yes, move that back as the original (OLD Method only)
                            if (File.Exists(newbackuppath + "\\" + realfileName) && !realfileName.Contains("(unique)"))
                            {
                                AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " [original] to CookedPC"); //
                                File.Copy(newbackuppath + "\\" + realfileName, originalFolderPath + "\\" + realfileName, true);
                                AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " [original] to CookedPC"); //
                                AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [original] from CookedPC_Backup"); //
                                File.Delete(newbackuppath + "\\" + realfileName);
                                AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [original] from CookedPC_Backup"); //
                            }
                            else // (OLD Method only)
                            {
                                try
                                {
                                    string val = realfileName;
                                    string tmp = val.Replace(" (unique)", "");
                                    AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [modded] from CookedPC_Mod");
                                    File.Copy(newbackuppath + "\\" + realfileName, RealModPath + "\\" + tmp, true);
                                    File.Delete(newbackuppath + "\\" + realfileName);
                                    File.Delete(modsFolderPath + "\\" + tmp);
                                    AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [modded] from CookedPC_Mod");
                                }
                                catch
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " (unique) couldn't be copied/deleted from CookedPC_Mod");
                                }
                            }
                        }
                        catch
                        {
                            AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                        }

                        fileCounter++;

                        // Increment & update stats as well as progress bar
                        i++;
                        // This operating will only get to 50%, and the file transfer will be the other 50%
                        curPercent = ((i * 100) / max);

                        // Update the UI
                        if ((worker.CancellationPending == true))
                        {
                            e.Cancel = true;
                            break;
                        }
                        else
                        {
                            // Perform a time consuming operation and report progress.
                            Thread.Sleep(50);
                            worker.ReportProgress(curPercent);
                        }
                    }
                }

                if (Directory.Exists(newbackuppath) && Directory.GetFiles(newbackuppath).Length == 0)
                {
                    Directory.Delete(newbackuppath);
                }
                else
                {
                    if (OLDMETHOD)
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Error: Restoring did not complete.");
                    }
                }

                // Show how many files we moved
                if (fileCounter > 0)
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Log] Done! " + fileCounter + " files were removed.");
                }
                else
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Log] Done! No files were removed.");
                }
                // Rename folder to uninstalled
                try
                {
                    string originalcopy = FullModPathMan + "\\" + tmpnode;
                    string altererdcopy = FullModPathMan + "\\" + tmpnode.Replace(" (Installed)", "");
                    Directory.Move(originalcopy, altererdcopy);
                    _workerCompleted.Set();
                }
                catch (Exception a) { Prompt.Popup(a.Message); }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            metroProgressBar2.Maximum = 100;
            this.metroProgressBar2.Value = e.ProgressPercentage;
            this.metroProgressBar2.Refresh();
        }

        private AutoResetEvent _workerCompleted = new AutoResetEvent(false);

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                AddTextBoxLog(Convert.ToString(e.Cancelled));
            }
            else if (!(e.Error == null))
            {
                AddTextBoxLog(Convert.ToString(e.Error));
            }
            else
            {
                // Done enable buttons and set the progressbar to 100%
                //this.metroProgressBar2.Value = 100;
                this.metroProgressBar2.Refresh();
                // Enable the buttons again
                enableButtons();
            }
            _workerCompleted.Set();
        }

        public bool checkNode(string s)
        {
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    if (nodes.FullPath.ToString() == s)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void addnew()
        {
            // Add new ones
            foreach (string directories in Directory.GetDirectories(FullModPathMan))
            {
                string directory = directories.Split(Path.DirectorySeparatorChar).Last();
                if (directories.Length != 0)
                {
                    if (checkNode(directory) == true)
                    {
                        treeView2.Nodes.Add(new TreeNode(directory));
                    }
                }
            }
        }

        public void removebad()
        {
            // Validate Paths and remove bad ones
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    if (Directory.Exists(RealModPath))
                    {
                        checkButtons(true);
                    }
                    else
                    {
                        nodes.Remove();
                    }
                }
            }
            treeView2.Sort();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            ReFreshMods();
        }

        public void ReFreshMods()
        {
            // Check Folder, add new ones and check for clones
            AddTextBoxLog(Environment.NewLine);
            AddTextBoxLog("[Log] Checking Mods Folder...");

            addnew();
            removebad();

            AddTextBoxLog(Environment.NewLine);
            AddTextBoxLog("[Log] Done Checking");
        }

        private AutoResetEvent completemodding = new AutoResetEvent(false);
        private Dictionary<int, string> Donewith = new Dictionary<int, string>();
        public string catcher = "";

        private async void metroButton9_Click(object sender, EventArgs e)
        {
            catcher = "";
            metroProgressBar2.Visible = true;
            metroProgressBar2.Refresh();
            // Restore files
            installFlag = false;
            try
            {
                Donewith = new Dictionary<int, string>();
                int total = treeView2.Nodes.Count - 1;
                int finalee = total + 2;
                for (int iop = 0; finalee > iop; iop++)
                {
                    if (treeView2.Nodes[iop] != null)
                    {
                        catcher = treeView2.Nodes[iop].FullPath.ToString();
                        if (!Donewith.ContainsValue(catcher))
                        {
                            if ((treeView2.Nodes[iop].Checked) && (catcher.Contains("(Installed)")))
                            {
                                Donewith.Add(iop, catcher);
                                _workerCompleted.Reset();
                                doFileSwap(FullModPathMan + "\\" + catcher);
                                _workerCompleted.WaitOne();
                            }
                            if ((treeView2.Nodes[iop].Checked) && (!catcher.Contains("(Installed)")))
                            {
                                AddTextBoxLog(Environment.NewLine + "Skipping: " + catcher + " (Not Installed)");
                            }
                        }
                    }
                    if (iop == total)
                    {
                        addnew();
                        removebad();
                        iop++;
                    }
                }
            }
            catch
            {
                AddTextBoxLog(Environment.NewLine + "Error: Could not open " + catcher + " mod");
            }
            metroProgressBar2.Visible = false;
            metroProgressBar2.Refresh();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            catcher = "";
            metroProgressBar2.Visible = true;
            metroProgressBar2.Refresh();
            // Switch files
            installFlag = true;
            try
            {
                Donewith = new Dictionary<int, string>();
                int total = treeView2.Nodes.Count - 1;
                int finalee = total + 2;
                for (int iop = 0; finalee > iop; iop++)
                {
                    if (treeView2.Nodes[iop] != null)
                    {
                        catcher = treeView2.Nodes[iop].FullPath.ToString();
                        if (!Donewith.ContainsValue(catcher))
                        {
                            if ((treeView2.Nodes[iop].Checked) && (!catcher.Contains("(Installed)")))
                            {
                                Donewith.Add(iop, catcher);
                                _workerCompleted.Reset();
                                doFileSwap(FullModPathMan + "\\" + catcher);
                                _workerCompleted.WaitOne();
                            }
                            if ((treeView2.Nodes[iop].Checked) && (catcher.Contains("(Installed)")))
                            {
                                AddTextBoxLog(Environment.NewLine + "Skipping: " + catcher + " (Already Installed)");
                            }
                        }
                    }
                    if (iop == total)
                    {
                        addnew();
                        removebad();
                        iop++;
                    }
                }
            }
            catch
            {
                AddTextBoxLog(Environment.NewLine + "Error: Could not open " + catcher + " mod");
            }
            metroProgressBar2.Visible = false;
            metroProgressBar2.Refresh();
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string description = File.ReadAllText(FullModPathMan + "\\" + e.Node.FullPath.ToString() + "\\description.txt").ToString();
                metroLabel40.Text = description;
            }
            catch { metroLabel40.Text = "No description provided!"; }
        }

        private void PopulateTreeView(string dir)
        {
            string folder = string.Empty;
            try
            {
                foreach (string directories in Directory.GetDirectories(dir))
                {
                    if (directories.Length != 0)
                    {
                        treeView2.Nodes.Add(directories.Split(Path.DirectorySeparatorChar).Last());
                        Directory.GetFiles(directories);
                        Thread.Sleep(50);
                        PopulateTreeView(directories);
                    }
                }
            }
            catch (Exception e)
            {
                Prompt.Popup(e.ToString());
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void metroButton10_Click(object sender, EventArgs e)
        {
            if (FullModPathMan.Contains(@"\\")) { FullModPathMan = FullModPathMan.Replace(@"\\", @"\"); }
            Process.Start("explorer.exe", FullModPathMan);
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            PerformClose();
        }

        public void PerformClose()
        {
            // Prevent closing if running and close if not
            if (bw.IsBusy)
            {
                Prompt.Popup("Please do not close this application while it's installing or uninstalling mods!");
                return;
            }
            else
            {
                CleanMess();
                CleanOtherMess();
                KillApp();
            }
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/nebulahosts");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void metroToggle20_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle20.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("boostprocess = false", "boostprocess = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("boostprocess = true", "boostprocess = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle2.Checked == true)
                {
                    SaveLogs = true;
                    groupBox7.Enabled = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("savelogs = false", "savelogs = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    SaveLogs = false;
                    groupBox7.Enabled = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("savelogs = true", "savelogs = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle5_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle5.Checked == true)
                {
                    ShowLogs = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("showlogs = false", "showlogs = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    ShowLogs = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("showlogs = true", "showlogs = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle13_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle13.Checked == true)
                {
                    LauncherLogs = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("launcherlogs = false", "launcherlogs = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    LauncherLogs = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("launcherlogs = true", "launcherlogs = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle12_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle13.Checked == true)
                {
                    ModManLogs = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("modmanlogs = false", "modmanlogs = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    ModManLogs = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("modmanlogs = true", "modmanlogs = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle18_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle18.Checked == true)
                {
                    AutoClean = true;
                    metroButton30.Visible = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("automemorycleanup = false", "automemorycleanup = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    AutoClean = false;
                    metroButton30.Visible = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("automemorycleanup = true", "automemorycleanup = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle6_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle6.Checked == true)
                {
                    metroToolTip1.Active = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("tooltips = false", "tooltips = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    metroToolTip1.Active = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("tooltips = true", "tooltips = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle7_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle7.Checked == true)
                {
                    metroLabel22.Visible = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("variables = false", "variables = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    metroLabel22.Visible = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("variables = true", "variables = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle8_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle8.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("admincheck = false", "admincheck = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("admincheck = true", "admincheck = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle9_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle9.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("ncsoftlogin = false", "ncsoftlogin = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("ncsoftlogin = true", "ncsoftlogin = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle10_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle10.Checked == true)
                {
                    metroButton12.Visible = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("showdonate = false", "showdonate = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    metroButton12.Visible = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("showdonate = true", "showdonate = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle15_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle15.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("gamekiller = false", "gamekiller = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("gamekiller = true", "gamekiller = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle14_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle14.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("pingchecker = false", "pingchecker = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                        // Resume worker
                        bw1.RunWorkerAsync();
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("pingchecker = true", "pingchecker = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                        // Pause worker
                        bw1.CancelAsync();
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle17_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle17.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("autoupdate = false", "autoupdate = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("autoupdate = true", "autoupdate = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle16_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle16.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("updatechecker = false", "updatechecker = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("updatechecker = true", "updatechecker = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle11_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle11.Checked == true)
                {
                    AllowMinimize = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("minimize = false", "minimize = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    AllowMinimize = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("minimize = true", "minimize = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle3.Checked == true)
                {
                    // Check Settings
                    metroButton15.Enabled = true;
                    metroButton20.Enabled = true;
                    metroButton17.Enabled = true;
                    metroTextBox3.Enabled = true;
                }
                else
                {
                    // Check Settings
                    metroButton15.Enabled = false;
                    metroButton20.Enabled = false;
                    metroButton17.Enabled = false;
                    metroTextBox3.Enabled = false;
                }
            }
        }

        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle4.Checked == true)
                {
                    // Check Settings
                    metroButton16.Enabled = true;
                    metroButton19.Enabled = true;
                    metroButton18.Enabled = true;
                    metroTextBox4.Enabled = true;
                }
                else
                {
                    // Check Settings
                    metroButton16.Enabled = false;
                    metroButton19.Enabled = false;
                    metroButton18.Enabled = false;
                    metroTextBox4.Enabled = false;
                }
            }
        }

        private void metroButton24_Click(object sender, EventArgs e)
        {
            lineChanger("arguements = " + metroTextBox5.Text, @AppPath + "\\Settings.ini", 21);
        }

        private static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            CustomGameSet = true;
            // Replace current line with new one
            lineChanger("customgamepath = " + metroTextBox3.Text, @AppPath + "\\Settings.ini", 16);
            // Write Setting to ini
            var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("customgame = false", "customgame = true");
            System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
            // Set values
            RegPath = metroTextBox3.Text;
            // Auto Get Dir
            AutoDirFinder();
            // Continue
            metroButton1.Enabled = true;
            PathFound = true;
            metroToggle1.Enabled = true;
            Prompt.Popup("Please Restart App If Done Configurating");
        }

        private bool CustomModSet = false;

        private void metroButton33_Click(object sender, EventArgs e)
        {
            if (metroTextBox7.Text.Length < 1)
            {
                Prompt.Popup("Path is incorrect");
            }
            else
            {
                CustomModSet = true;
                // Replace current line with new one
                lineChanger("modfolder = " + metroTextBox7.Text, @AppPath + "\\Settings.ini", 29);
                // Write Setting to ini
                var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                fileContents2 = fileContents2.Replace("modfolderset = false", "modfolderset = true");
                System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
                // Set new path
                backupFolderPath = metroTextBox7.Text + "\\CookedPC_Backup";
                FullModPathMan = metroTextBox7.Text + "\\CookedPC_Mod";
                // Reset found paths
                GetPath();
                Prompt.Popup("Please Restart App If Done Configurating");
            }
        }

        private void metroButton31_Click(object sender, EventArgs e)
        {
            metroToggle19.Checked = false;
            metroTextBox7.Text = "";
            CustomModSet = false;
            GetPath();
            // restore settings.ini
            // Write Setting to ini
            var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("modfolderset = true", "modfolderset = false");
            System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
        }

        private void metroToggle19_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle19.Checked == true)
            {
                metroButton33.Enabled = true;
                metroButton31.Enabled = true;
                metroTextBox7.Enabled = true;
                metroButton29.Enabled = true;
            }
            else
            {
                metroButton33.Enabled = false;
                metroButton31.Enabled = false;
                metroTextBox7.Enabled = false;
                metroButton29.Enabled = false;
            }
        }

        private void metroButton29_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result.ToString() == "OK")
            {
                if (Directory.Exists(fbd.SelectedPath + "\\"))
                {
                    metroTextBox7.Text = fbd.SelectedPath;
                }
                else
                {
                    Prompt.Popup("Error: Invalid Path! Browse for a custom Mods folder." + " | Path: " + fbd.SelectedPath);
                }
            }
            else
            {
                Prompt.Popup("Error: Cancelled operation!");
                KillApp();
            }
        }

        private void RestoreGamePath()
        {
            CustomGameSet = false;
            // Remove custom values
            metroTextBox3.Text = "";
            // Revert Settings.ini
            lineChanger("customgamepath = ", @AppPath + "\\Settings.ini", 16);
            // Write Setting to ini
            var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("customgame = true", "customgame = false");
            System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
            // Launcher Default
            BnSFolder();
            CheckBackup();
            if (CustomClientSet == false)
            {
                CheckServer();
            }
            VerifySettings();
            // Splash Screen Default
            GetPaths();
            Verify();
            InitializeSplash();
            // Mod Manager Default
            InitializeManager();
            GetPath();
            JsonManager();
            VerifyUsage();
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            RestoreGamePath();
        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result.ToString() == "OK")
            {
                if (Directory.Exists(fbd.SelectedPath + "\\contents"))
                {
                    metroTextBox3.Text = fbd.SelectedPath;
                }
                else
                {
                    Prompt.Popup("Error: Invalid Path! Browse for BnS Folder." + " | Path: " + fbd.SelectedPath);
                }
            }
            else
            {
                Prompt.Popup("Error: Cancelled operation!");
                KillApp();
            }
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            CustomClientSet = true;
            // Rewrite settings to ini
            lineChanger("customclientpath = " + metroTextBox4.Text, @AppPath + "\\Settings.ini", 15);
            // Write Setting to ini
            var fileContents2 = File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("customclient = false", "customclient = true");
            System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
            // Set values
            RegPathlol = metroTextBox4.Text;
            try
            {
                if (File.Exists(RegPathlol + "\\NCLauncher.ini"))
                {
                    string nc_content = File.ReadAllText(RegPathlol + "\\NCLauncher.ini");
                    if (nc_content.Contains("Game_Region=North America") || nc_content.Contains("Game_Region=Nordamerika") || nc_content.Contains("du Nord"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                    }
                    else if (nc_content.Contains("Game_Region=Europe") || nc_content.Contains("Game_Region=Europa") || nc_content.Contains("Game_Region=L'Europe"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Europe");
                    }
                    else if (nc_content.Contains("Game_Locale=ja"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Japanese");
                    }
                    else if (nc_content.Contains("up4svr.plaync.com.tw") && !nc_content.Contains("MXM"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                    }
                    else if (nc_content.Contains("up4web.plaync.co.kr") || nc_content.Contains("up4web.nclauncher.ncsoft.com") && !nc_content.Contains("MXM"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Korean");
                    }
                    if (Conflict == true && metroComboBox2.SelectedItem.ToString() == "Korean")
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Korean");
                        if (KoreanTestInstalled)
                        {
                            metroComboBox8.SelectedIndex = metroComboBox8.FindStringExact("Test");
                        }
                    }
                    else if (Conflict == true && metroComboBox2.SelectedItem.ToString() == "Taiwan")
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                    }
                }
                Prompt.Popup("Please Restart App If Done Configurating");
            }
            catch (Exception a)
            {
                AddTextLog("Error: Could Not Find NCLauncher.ini" + Environment.NewLine + a.ToString());
            }
        }

        private void RestoreClientPath()
        {
            CustomClientSet = false;
            // Remove custom values
            metroTextBox4.Text = "";
            // Revert Settings.ini
            lineChanger("customclientpath = ", @AppPath + "\\Settings.ini", 15);
            // Write Setting to ini
            var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("customclient = true", "customclient = false");
            File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
            // Launcher Default
            if (CustomClientSet == false)
            {
                CheckServer();
            }
            VerifySettings();
            // Splash Screen Default
            GetPaths();
            Verify();
            InitializeSplash();
            // Mod Manager Default
            InitializeManager();
            GetPath();
            JsonManager();
            VerifyUsage();
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            RestoreClientPath();
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result.ToString() == "OK")
            {
                if (Directory.Exists(fbd.SelectedPath + "\\Download"))
                {
                    metroTextBox4.Text = fbd.SelectedPath;
                }
                else
                {
                    Prompt.Popup("Error: Invalid Path! Browse for NCLauncher Folder." + " | Path: " + fbd.SelectedPath);
                }
            }
            else
            {
                Prompt.Popup("Error: Operation cancelled!");
                KillApp();
            }
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            try
            {
                // Create if exists
                if (File.Exists(AppPath + "\\Settings.ini")) { File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues); }
                // Create if missing
                if (!File.Exists(AppPath + "\\Settings.ini")) { File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues); }
                // Quick Restart
                StartupBuddy();
            }
            catch
            {
                Prompt.Popup("Error: Could Not Restore Settings.ini!");
            }
        }

        private void metroLabel46_Click(object sender, EventArgs e)
        {
            Process.Start("https://udn.epicgames.com/Three/CommandLineArguments.html");
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (AppStarted == true)
            {
                // Get
                string tracker = File.ReadLines(@AppPath + "\\Settings.ini").Skip(21).Take(1).First().Replace("prtime = ", "");
                // Set, replace , write
                lineChanger("prtime = " + metroTrackBar1.Value.ToString(), @AppPath + "\\Settings.ini", 22);
                // Actualise
                wakeywakey = metroTrackBar1.Value;
                metroLabel47.Text = metroTrackBar1.Value.ToString();
                metroLabel47.Refresh();
            }
        }

        private void metroComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AppStarted == true)
            {
                // Get
                string tracker = File.ReadLines(@AppPath + "\\Settings.ini").Skip(35).Take(1).First().Replace("cleanint = ", "");
                // Set, replace , write
                lineChanger("cleanint = " + metroComboBox7.Text.ToString(), @AppPath + "\\Settings.ini", 36);
                // Actualise
                if (metroComboBox7.Text.ToString() != "OFF")
                {
                    CleanerVal = Convert.ToInt32(metroComboBox7.Text.ToString());
                }
            }
        }

        private void metroComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            defaultclient = metroComboBox4.SelectedItem.ToString();
            if ((defaultclient == "64bit" && Directory.Exists(RegPath + LauncherPath64)) || (defaultclient == "32bit" && Directory.Exists(RegPath + LauncherPath)))
            {
                lineChanger("defaultclient = " + defaultclient, @AppPath + "\\Settings.ini", 27);
            }
            else
            {
                if (AppStarted)
                {
                    Prompt.Popup("Error: Path to " + defaultclient + " does not exist.");
                }
                if (defaultclient == "32bit")
                {
                    metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact("64bit");
                    metroComboBox4.Items.Remove("32bit");
                    defaultclient = "";
                }
                else
                {
                    metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact("32bit");
                    metroComboBox4.Items.Remove("64bit");
                    defaultclient = "";
                }
            }
            // Default Bitness for addons
            if (metroComboBox4.SelectedIndex == metroComboBox4.FindStringExact("64bit"))
            {
                metroRadioButton1.Checked = false;
                metroRadioButton2.Checked = true;
            }
            else
            {
                metroRadioButton2.Checked = false;
                metroRadioButton1.Checked = true;
            }
        }

        public void RestoreDefault()
        {
            if (metroLabel48.Text != "None")
            {
                try
                {
                    // Do defaultset = true
                    var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                    fileContents = fileContents.Replace("defaultset = true", "defaultset = false");
                    System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    // Do default = path
                    lineChanger("default = ", @AppPath + "\\Settings.ini", 25);
                    // Change label val
                    metroLabel48.Text = "None";
                    // Done
                    MultipleInstallationFound = false;
                }
                catch { AddTextLog("Error: Could not restore default to none!"); }
            }
        }

        private void metroLabel48_Click(object sender, EventArgs e)
        {
            if (metroLabel48.Text != "None")
                RestoreDefault();
            // Quick Restart
            StartupBuddy();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public string FullAddonPath = "";

        public void InitializeAddons()
        {
            AddonPaths();
            GenerateAddons();
            treeView3.Sort();
        }

        public void RestoreAddons()
        {
            treeView3.Visible = false;
            metroLabel63.Visible = true;
            metroLabel64.Visible = true;
            metroLabel53.Visible = true;
            // Reset Dictionary
            AddonFiles = new Dictionary<int, string>();
            AddonModded = new Dictionary<string, bool>();
            // Do modifications
            foreach (TreeNode addons in treeView3.Nodes)
            {
                if (addons != null)
                {
                    if (addons.Checked)
                    {
                        UndoPatching(addons.FullPath + ".patch");
                    }
                }
            }
            // Compile completed work.
            int afdef = AddonFiles.Count + 1;
            for (int af = 1; afdef > af; af++)
            {
                if (AddonFiles.ContainsKey(af))
                {
                    string tmp = AddonFiles[af].Replace(".files", "");
                    if (AddonModded.ContainsKey(tmp) == true)
                    {
                        if (AddonModded[tmp] == true)
                        {
                            AddTextLog("Compiling " + tmp);
                            File.Delete(DataPath + "\\" + tmp);
                            usedfilepathonly = DataPath + "\\" + AddonFiles[af];
                            Compiler(tmp);
                            AddTextLog("Compiled.");
                            AddonFiles.Remove(af);
                        }
                        else
                        {
                            AddTextLog("Skipped " + tmp);
                        }
                    }
                }
            }
            // Untick tasks in addons
            foreach (TreeNode node in treeView3.Nodes)
            {
                if (node != null)
                {
                    if (node.Checked)
                    {
                        node.Checked = false;
                    }
                }
            }
            treeView3.Visible = true;
            metroLabel53.Visible = false;
            metroLabel63.Visible = false;
            metroLabel64.Visible = false;
        }

        public void AddonPaths()
        {
            // New Addon path
            FullAddonPath = AppPath + "\\addons\\";
            // Old Addon path
            string OLDAddonPath = DataPath + "\\addons\\";
            if (!Directory.Exists(FullAddonPath)) { CreatePaths(FullAddonPath); }
            if (Directory.Exists(OLDAddonPath))
            {
                try
                {
                    // Move any files from old path to new path
                    foreach (string files in Directory.GetFiles(OLDAddonPath))
                    {
                        string nameoffilestomove = files.Split(Path.DirectorySeparatorChar).Last();
                        if (files.Length != 0)
                        {
                            if (File.Exists(FullAddonPath + "\\" + nameoffilestomove)) { File.Delete(FullAddonPath + "\\" + nameoffilestomove); }
                            File.Move(files, FullAddonPath + "\\" + nameoffilestomove);
                        }
                    }
                }
                catch { Prompt.Popup("Error: Could not transfer addons to new path!"); }
                try
                {
                    // Delete old path once done
                    if (Directory.GetFiles(OLDAddonPath).Length != 0)
                    {
                        Directory.Delete(OLDAddonPath);
                    }
                }
                catch { Prompt.Popup("Error: Could not delete old addon path!"); }
            }
        }

        public void GenerateAddons()
        {
            foreach (string files in Directory.GetFiles(FullAddonPath))
            {
                string directory = files.Split(Path.DirectorySeparatorChar).Last();
                if (files.Length != 0)
                {
                    if (directory.EndsWith(".patch"))
                    {
                        string tmp = directory.Replace(".patch", "");
                        if (checkNode3(tmp) == true)
                        {
                            TreeNode tmpadder = new TreeNode(tmp);
                            treeView3.Nodes.Add(tmpadder);
                        }
                    }
                }
            }
        }

        private Dictionary<string, bool> AddonModded = new Dictionary<string, bool>();
        private Dictionary<int, string> AddonFiles = new Dictionary<int, string>();

        public void StartGameAddons()
        {
            // Reset Dictionary
            AddonFiles = new Dictionary<int, string>();
            AddonModded = new Dictionary<string, bool>();
            // Do modifications
            foreach (TreeNode addons in treeView3.Nodes)
            {
                if (addons != null)
                {
                    if (addons.Checked)
                    {
                        StartPatching(addons.FullPath + ".patch");
                    }
                }
            }
            // Compile completed work.
            int afdef = AddonFiles.Count + 1;
            for (int af = 1; afdef > af; af++)
            {
                if (AddonFiles.ContainsKey(af))
                {
                    string tmp = AddonFiles[af].Replace(".files", "");
                    if (AddonModded.ContainsKey(tmp) == true)
                    {
                        if (AddonModded[tmp] == true)
                        {
                            AddTextLog("Compiling " + tmp);
                            File.Delete(DataPath + "\\" + tmp);
                            usedfilepathonly = DataPath + "\\" + AddonFiles[af];
                            Compiler(tmp);
                            AddTextLog("Compiled.");
                            AddonFiles.Remove(af);
                        }
                        else
                        {
                            AddTextLog("Skipped " + tmp);
                        }
                    }
                }
            }
            // Untick tasks in addons
            foreach (TreeNode node in treeView3.Nodes)
            {
                if (node != null)
                {
                    if (node.Checked)
                    {
                        node.Checked = false;
                    }
                }
            }
        }

        public bool checkNode3(string s)
        {
            foreach (TreeNode nodes in treeView3.Nodes)
            {
                if (nodes != null)
                {
                    if (nodes.FullPath.ToString() == s)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 f3 = new Form3();
            f3.Visible = false;
            f3.ShowDialog();
            Show();
            this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
        }

        private void metroButton28_Click(object sender, EventArgs e)
        {
            RestoreAddons();
        }

        public void UndoPatching(string filename)
        {
            // Bitness Check
            bool SkipFile = false;
            // Reset Search and Replace Dictionarys
            Search = new Dictionary<int, string>();
            Replace = new Dictionary<int, string>();
            // Go on...
            int linecount = File.ReadAllLines(FullAddonPath + "\\" + filename).Count();
            if (Debugging)
                Prompt.Popup(linecount.ToString());
            if (linecount == 4)
            {
                string ToFile = File.ReadLines(FullAddonPath + "\\" + filename).Skip(0).Take(1).First().Replace("FileName = ", "");
                if (Debugging)
                    Prompt.Popup("File to patch: " + ToFile);
                // Fix file name for unpacking
                string prev_ToFile = Path.GetDirectoryName(ToFile);
                string to_ToFile = prev_ToFile.Replace(".files", "");
                // Bitness Check
                if (to_ToFile.Contains("[bit]"))
                {
                    if (metroRadioButton1.Checked == true)
                    {
                        string ancestor = to_ToFile; // before change
                        to_ToFile = to_ToFile.Replace("[bit]", ""); // after change
                        prev_ToFile = prev_ToFile.Replace(ancestor, to_ToFile); // update change
                        ToFile = ToFile.Replace(ancestor, to_ToFile); // update general
                    }
                    else if (metroRadioButton2.Checked == true)
                    {
                        string ancestor = to_ToFile; // before change
                        to_ToFile = to_ToFile.Replace("[bit]", "64"); // after change
                        prev_ToFile = prev_ToFile.Replace(ancestor, to_ToFile); // update change
                        ToFile = ToFile.Replace(ancestor, to_ToFile); // update general
                    }
                    else
                    {
                        SkipFile = true;
                        AddTextLog("Skipped addon: " + filename.Replace(".patch", "") + " because no bitness was selected");
                    }
                }
                if (SkipFile == false)
                {
                    // Add dat file to list of addons to mod
                    if (!AddonModded.ContainsKey(to_ToFile))
                    {
                        AddonModded.Add(to_ToFile, false);
                    }
                    // Proceed to unpacking if not existing already
                    if (!Directory.Exists(DataPath + "\\" + prev_ToFile))
                    {
                        // Add to dictionary
                        int tmpaf = AddonFiles.Count + 1;
                        // Cut String to get filename
                        string ToFileFolder = Path.GetDirectoryName(ToFile);
                        if (!AddonFiles.ContainsKey(tmpaf) && !AddonFiles.ContainsValue(ToFileFolder))
                        {
                            AddonFiles.Add(tmpaf, ToFileFolder);
                        }
                        // Continue...
                        AddTextLog("Decompiling " + to_ToFile);
                        usedfilepath = DataPath + "\\" + to_ToFile;
                        Extractor(to_ToFile);
                        AddTextLog("Decompiled.");
                    }
                    else
                    {
                        // Add to dictionary
                        int tmpaf = AddonFiles.Count + 1;
                        string ToFileFolder = Path.GetDirectoryName(ToFile);
                        if (!AddonFiles.ContainsKey(tmpaf) && !AddonFiles.ContainsValue(ToFileFolder))
                        {
                            AddonFiles.Add(tmpaf, ToFileFolder);
                        }
                        AddTextLog("File: " + ToFileFolder + " already decompiled");
                    }
                    // Continue work
                    string Searcher = File.ReadLines(FullAddonPath + "\\" + filename).Skip(1).Take(1).First().Replace("Search = ", "");
                    if (Debugging)
                        Prompt.Popup("String to search: " + Searcher);
                    string Replacer = File.ReadLines(FullAddonPath + "\\" + filename).Skip(2).Take(1).First().Replace("Replace = ", "");
                    if (Debugging)
                        Prompt.Popup("String to replace: " + Replacer);
                    if (File.Exists(DataPath + "\\" + ToFile))
                    {
                        string ToText = File.ReadAllText(DataPath + "\\" + ToFile);
                        if (Debugging)
                            Prompt.Popup(ToText.ToString());
                        if (ToText.ToString().Contains(Replacer.ToString()))
                        {
                            ToText = ToText.Replace(Replacer, Searcher);
                            File.WriteAllText(DataPath + "\\" + ToFile, ToText);
                            AddTextLog("Reverted Addon: " + filename.Replace(".patch", ""));
                            // Change addon check to true
                            if (AddonModded.ContainsKey(to_ToFile))
                            {
                                AddonModded[to_ToFile] = true;
                            }
                        }
                        else
                        {
                            AddTextLog("Addon: " + filename.Replace(".patch", "") + " couldn't be applied!");
                            AddTextLog("Maybe already reverted?");
                        }
                    }
                    else { Prompt.Popup("File: " + DataPath + "\\" + ToFile + " Does not exist!  Please check your patches"); }
                }
            }
            else if (linecount > 4)
            {
                string ToFile = File.ReadLines(FullAddonPath + "\\" + filename).Skip(0).Take(1).First().Replace("FileName = ", "");
                // Fix file name for unpacking
                string prev_ToFile = Path.GetDirectoryName(ToFile);
                string to_ToFile = prev_ToFile.Replace(".files", "");
                // Bitness Check
                if (to_ToFile.Contains("[bit]"))
                {
                    if (metroRadioButton1.Checked == true)
                    {
                        string ancestor = to_ToFile; // before change
                        to_ToFile = to_ToFile.Replace("[bit]", ""); // after change
                        prev_ToFile = prev_ToFile.Replace(ancestor, to_ToFile); // update change
                        ToFile = ToFile.Replace(ancestor, to_ToFile); // update general
                    }
                    else if (metroRadioButton2.Checked == true)
                    {
                        string ancestor = to_ToFile; // before change
                        to_ToFile = to_ToFile.Replace("[bit]", "64"); // after change
                        prev_ToFile = prev_ToFile.Replace(ancestor, to_ToFile); // update change
                        ToFile = ToFile.Replace(ancestor, to_ToFile); // update general
                    }
                    else
                    {
                        SkipFile = true;
                        AddTextLog("Skipped addon: " + filename.Replace(".patch", "") + " because no bitness was selected");
                    }
                }
                if (SkipFile == false)
                {
                    // Add dat file to list of addons to mod
                    if (!AddonModded.ContainsKey(to_ToFile))
                    {
                        AddonModded.Add(to_ToFile, false);
                    }
                    // Proceed to unpacking if not existing already
                    if (!Directory.Exists(DataPath + "\\" + prev_ToFile))
                    {
                        // Add to dictionary
                        int tmpaf = AddonFiles.Count + 1;
                        string ToFileFolder = Path.GetDirectoryName(ToFile);
                        if (!AddonFiles.ContainsKey(tmpaf) && !AddonFiles.ContainsValue(ToFileFolder))
                        {
                            AddonFiles.Add(tmpaf, ToFileFolder);
                        }
                        // Continue...
                        AddTextLog("Decompiling " + to_ToFile);
                        usedfilepath = DataPath + "\\" + to_ToFile;
                        Extractor(to_ToFile);
                        AddTextLog("Decompiled.");
                    }
                    else
                    {
                        // Add to dictionary
                        int tmpaf = AddonFiles.Count + 1;
                        string ToFileFolder = Path.GetDirectoryName(ToFile);
                        if (!AddonFiles.ContainsKey(tmpaf) && !AddonFiles.ContainsValue(ToFileFolder))
                        {
                            AddonFiles.Add(tmpaf, ToFileFolder);
                        }
                        AddTextLog("File: " + ToFileFolder + " already decompiled");
                    }
                    // Continue work
                    int i = 0;
                    int o = 0;
                    IEnumerable<string> WholeText = File.ReadLines(FullAddonPath + "\\" + filename);

                    foreach (string text in WholeText)
                    {
                        if (text.Contains("Search = "))
                        {
                            string line = text;
                            string inline = line.Replace("Search = ", "");
                            Replace.Add(i, inline);
                            i++;
                        }
                    }
                    foreach (string text in WholeText)
                    {
                        if (text.Contains("Replace = "))
                        {
                            string line = text;
                            string inline = line.Replace("Replace = ", "");
                            Search.Add(o, inline);
                            o++;
                        }
                    }
                    if (i == o)
                    {
                        if (File.Exists(DataPath + "\\" + ToFile))
                        {
                            string ToText = File.ReadAllText(DataPath + "\\" + ToFile);
                            if (Debugging)
                                Prompt.Popup("Full Text: " + ToText);
                            for (int io = 0; i > io; io++)
                            {
                                if (Debugging)
                                    Prompt.Popup("Before: " + ToText);
                                if (Search.ContainsKey(io))
                                {
                                    if (ToText.Contains(Search[io]))
                                    {
                                        ToText = ToText.Replace(Search[io], Replace[io]);
                                        AddTextLog("Patched: " + (io + 1) + "/" + Replace.Count);
                                        // Prepare for compiling after all done
                                        if (AddonModded.ContainsKey(to_ToFile))
                                        {
                                            if (AddonModded[to_ToFile] == false)
                                            {
                                                AddonModded[to_ToFile] = true;
                                            }
                                        }

                                        if (Debugging)
                                            Prompt.Popup("After: " + ToText);
                                    }
                                    else
                                    {
                                        AddTextLog("Error: Could not find " + (io + 1) + "/" + Replace.Count);
                                        AddTextLog("Maybe already reverted?");
                                    }
                                }
                            }
                            File.WriteAllText(DataPath + "\\" + ToFile, ToText);
                            AddTextLog("Reverted Addon: " + filename.Replace(".patch", ""));
                        }
                        else { Prompt.Popup("File: " + DataPath + "\\" + ToFile + " Does not exist!  Please check your patches"); }
                    }
                    else if (i > o)
                    {
                        Prompt.Popup("Missing Replacements found. Please check your patches");
                    }
                    else if (i < o)
                    {
                        Prompt.Popup("Missing Finds found. Please check your patches");
                    }
                }
                else
                {
                    Prompt.Popup("Error: The following patch " + filename + " does not meet the requirements.");
                }
            }
        }

        private Dictionary<int, string> Search = new Dictionary<int, string>();
        private Dictionary<int, string> Replace = new Dictionary<int, string>();

        public void StartPatching(string filename)
        {
            // Bitness Check
            bool SkipFile = false;
            // Reset Search and Replace Dictionarys
            Search = new Dictionary<int, string>();
            Replace = new Dictionary<int, string>();
            // Go on...
            int linecount = File.ReadAllLines(FullAddonPath + "\\" + filename).Count();
            if (Debugging)
                Prompt.Popup(linecount.ToString());
            if (linecount == 4)
            {
                string ToFile = File.ReadLines(FullAddonPath + "\\" + filename).Skip(0).Take(1).First().Replace("FileName = ", "");
                if (Debugging)
                    Prompt.Popup("File to patch: " + ToFile);
                // Fix file name for unpacking
                string prev_ToFile = Path.GetDirectoryName(ToFile);
                if (prev_ToFile.Contains("\\"))
                {
                    prev_ToFile = prev_ToFile.Remove(prev_ToFile.IndexOf("\\"));
                }
                string to_ToFile = prev_ToFile.Replace(".files", "");
                // Bitness Check
                if (to_ToFile.Contains("[bit]"))
                {
                    if (metroRadioButton1.Checked == true)
                    {
                        string ancestor = to_ToFile; // before change
                        to_ToFile = to_ToFile.Replace("[bit]", ""); // after change
                        prev_ToFile = prev_ToFile.Replace(ancestor, to_ToFile); // update change
                        ToFile = ToFile.Replace(ancestor, to_ToFile); // update general
                    }
                    else if (metroRadioButton2.Checked == true)
                    {
                        string ancestor = to_ToFile; // before change
                        to_ToFile = to_ToFile.Replace("[bit]", "64"); // after change
                        prev_ToFile = prev_ToFile.Replace(ancestor, to_ToFile); // update change
                        ToFile = ToFile.Replace(ancestor, to_ToFile); // update general
                    }
                    else
                    {
                        SkipFile = true;
                        AddTextLog("Skipped addon: " + filename.Replace(".patch", "") + " because no bitness was selected");
                    }
                }
                if (SkipFile == false)
                {
                    // Add dat file to list of addons to mod
                    if (!AddonModded.ContainsKey(to_ToFile))
                    {
                        AddonModded.Add(to_ToFile, false);
                    }
                    // Proceed to unpacking if not existing already
                    if (!Directory.Exists(DataPath + "\\" + prev_ToFile))
                    {
                        // Add to dictionary
                        int tmpaf = AddonFiles.Count + 1;
                        // Cut String to get filename
                        string ToFileFolder = Path.GetDirectoryName(ToFile);
                        if (!AddonFiles.ContainsKey(tmpaf) && !AddonFiles.ContainsValue(ToFileFolder))
                        {
                            AddonFiles.Add(tmpaf, ToFileFolder);
                        }
                        // Continue...
                        AddTextLog("Decompiling " + to_ToFile);
                        usedfilepath = DataPath + "\\" + to_ToFile;
                        Extractor(to_ToFile);
                        AddTextLog("Decompiled.");
                    }
                    else
                    {
                        // Add to dictionary
                        int tmpaf = AddonFiles.Count + 1;
                        string ToFileFolder = Path.GetDirectoryName(ToFile);
                        if (!AddonFiles.ContainsKey(tmpaf) && !AddonFiles.ContainsValue(ToFileFolder))
                        {
                            AddonFiles.Add(tmpaf, ToFileFolder);
                        }
                        AddTextLog("File: " + ToFileFolder + " already decompiled");
                    }
                    // Continue work
                    string Searcher = File.ReadLines(FullAddonPath + "\\" + filename).Skip(1).Take(1).First().Replace("Search = ", "");
                    if (Debugging)
                        Prompt.Popup("String to search: " + Searcher);
                    string Replacer = File.ReadLines(FullAddonPath + "\\" + filename).Skip(2).Take(1).First().Replace("Replace = ", "");
                    if (Debugging)
                        Prompt.Popup("String to replace: " + Replacer);
                    if (File.Exists(DataPath + "\\" + ToFile))
                    {
                        string ToText = File.ReadAllText(DataPath + "\\" + ToFile);
                        if (Debugging)
                            Prompt.Popup(ToText.ToString());
                        if (ToText.ToString().Contains(Searcher.ToString()))
                        {
                            ToText = ToText.Replace(Searcher, Replacer);
                            File.WriteAllText(DataPath + "\\" + ToFile, ToText);
                            AddTextLog("Applied Addon: " + filename.Replace(".patch", ""));
                            // Change addon check to true
                            if (AddonModded.ContainsKey(to_ToFile))
                            {
                                AddonModded[to_ToFile] = true;
                            }
                        }
                        else
                        {
                            AddTextLog("Addon: " + filename.Replace(".patch", "") + " couldn't be applied!");
                            AddTextLog("Maybe already patched?");
                        }
                    }
                    else { Prompt.Popup("File: " + DataPath + "\\" + ToFile + " Does not exist!  Please check your patches"); }
                }
            }
            else if (linecount > 4)
            {
                string ToFile = File.ReadLines(FullAddonPath + "\\" + filename).Skip(0).Take(1).First().Replace("FileName = ", "");
                // Fix file name for unpacking
                string prev_ToFile = Path.GetDirectoryName(ToFile);
                if (prev_ToFile.Contains("\\"))
                {
                    prev_ToFile = prev_ToFile.Remove(prev_ToFile.IndexOf("\\"));
                }
                string to_ToFile = prev_ToFile.Replace(".files", "");
                // Bitness Check
                if (to_ToFile.Contains("[bit]"))
                {
                    if (metroRadioButton1.Checked == true)
                    {
                        string ancestor = to_ToFile; // before change
                        to_ToFile = to_ToFile.Replace("[bit]", ""); // after change
                        prev_ToFile = prev_ToFile.Replace(ancestor, to_ToFile); // update change
                        ToFile = ToFile.Replace(ancestor, to_ToFile); // update general
                    }
                    else if (metroRadioButton2.Checked == true)
                    {
                        string ancestor = to_ToFile; // before change
                        to_ToFile = to_ToFile.Replace("[bit]", "64"); // after change
                        prev_ToFile = prev_ToFile.Replace(ancestor, to_ToFile); // update change
                        ToFile = ToFile.Replace(ancestor, to_ToFile); // update general
                    }
                    else
                    {
                        SkipFile = true;
                        AddTextLog("Skipped addon: " + filename.Replace(".patch", "") + " because no bitness was selected");
                    }
                }
                if (SkipFile == false)
                {
                    // Add dat file to list of addons to mod
                    if (!AddonModded.ContainsKey(to_ToFile))
                    {
                        AddonModded.Add(to_ToFile, false);
                    }
                    // Proceed to unpacking if not existing already
                    if (!Directory.Exists(DataPath + "\\" + prev_ToFile))
                    {
                        // Add to dictionary
                        int tmpaf = AddonFiles.Count + 1;
                        string ToFileFolder = Path.GetDirectoryName(ToFile);
                        if (!AddonFiles.ContainsKey(tmpaf) && !AddonFiles.ContainsValue(ToFileFolder))
                        {
                            AddonFiles.Add(tmpaf, ToFileFolder);
                        }
                        // Continue...
                        AddTextLog("Decompiling " + to_ToFile);
                        usedfilepath = DataPath + "\\" + to_ToFile;
                        Extractor(to_ToFile);
                        AddTextLog("Decompiled.");
                    }
                    else
                    {
                        // Add to dictionary
                        int tmpaf = AddonFiles.Count + 1;
                        string ToFileFolder = Path.GetDirectoryName(ToFile);
                        if (!AddonFiles.ContainsKey(tmpaf) && !AddonFiles.ContainsValue(ToFileFolder))
                        {
                            AddonFiles.Add(tmpaf, ToFileFolder);
                        }
                        AddTextLog("File: " + ToFileFolder + " already decompiled");
                    }
                    // Continue work
                    int i = 0;
                    int o = 0;
                    IEnumerable<string> WholeText = File.ReadLines(FullAddonPath + "\\" + filename);

                    foreach (string text in WholeText)
                    {
                        if (text.Contains("Search = "))
                        {
                            string line = text;
                            string inline = line.Replace("Search = ", "");
                            Search.Add(i, inline);
                            i++;
                        }
                    }
                    foreach (string text in WholeText)
                    {
                        if (text.Contains("Replace = "))
                        {
                            string line = text;
                            string inline = line.Replace("Replace = ", "");
                            Replace.Add(o, inline);
                            o++;
                        }
                    }
                    if (i == o)
                    {
                        if (File.Exists(DataPath + "\\" + ToFile))
                        {
                            string ToText = File.ReadAllText(DataPath + "\\" + ToFile);
                            if (Debugging)
                                Prompt.Popup("Full Text: " + ToText);
                            for (int io = 0; i > io; io++)
                            {
                                if (Debugging)
                                    Prompt.Popup("Before: " + ToText);
                                if (Search.ContainsKey(io))
                                {
                                    if (ToText.Contains(Search[io]))
                                    {
                                        ToText = ToText.Replace(Search[io], Replace[io]);
                                        AddTextLog("Patched: " + (io + 1) + "/" + Replace.Count);
                                        // Prepare for compiling after all done
                                        if (AddonModded.ContainsKey(to_ToFile))
                                        {
                                            if (AddonModded[to_ToFile] == false)
                                            {
                                                AddonModded[to_ToFile] = true;
                                            }
                                        }

                                        if (Debugging)
                                            Prompt.Popup("After: " + ToText);
                                    }
                                    else
                                    {
                                        AddTextLog("Error: Could not find " + (io + 1) + "/" + Replace.Count);
                                        AddTextLog("Maybe already done?");
                                    }
                                }
                            }
                            File.WriteAllText(DataPath + "\\" + ToFile, ToText);
                            AddTextLog("Applied Addon: " + filename.Replace(".patch", ""));
                        }
                        else { Prompt.Popup("File: " + DataPath + "\\" + ToFile + " Does not exist!  Please check your patches"); }
                    }
                    else if (i > o)
                    {
                        Prompt.Popup("Missing Replacements found. Please check your patches");
                    }
                    else if (i < o)
                    {
                        Prompt.Popup("Missing Finds found. Please check your patches");
                    }
                }
            }
            else
            {
                Prompt.Popup("Error: The following patch " + filename + " does not meet the requirements.");
            }
        }

        public void RefreshAddons()
        {
            GenerateAddons();
            CheckAddonsPaths();
            treeView3.Sort();
        }

        public void CheckAddonsPaths()
        {
            ClearCV3 = true;
            treeView3.SelectedNode = null;
            int iniTV = treeView3.Nodes.Count;
            int countTV = 0;
            foreach (TreeNode tv3 in treeView3.Nodes)
            {
                if (tv3 != null)
                {
                    string file = tv3.FullPath + ".patch";
                    if (!File.Exists(FullAddonPath + "\\" + file))
                    {
                        tv3.Remove();
                    }
                }
            }
            countTV = treeView3.Nodes.Count;
            ClearCV3 = false;
            if (iniTV != countTV)
            {
                CheckAddonsPaths();
            }
        }

        private void metroButton25_Click(object sender, EventArgs e)
        {
            if (FullAddonPath.Contains(@"\\")) { FullAddonPath = FullAddonPath.Replace(@"\\", @"\"); }
            Process.Start("explorer.exe", FullAddonPath);
        }

        private void metroButton26_Click(object sender, EventArgs e)
        {
            RefreshAddons();
        }

        private bool ClearCV3 = false;

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (ClearCV3 == false)
                {
                    string description = "";
                    string filename = e.Node.FullPath.ToString() + ".patch";
                    IEnumerable<string> WholeText = File.ReadLines(FullAddonPath + "\\" + filename);
                    foreach (string text in WholeText)
                    {
                        if (text.Contains("Description = "))
                        {
                            string line = text;
                            description = line.Replace("Description = ", "");
                        }
                    }
                    if (description.Length > 0)
                    {
                        metroTextBox6.Text = description;
                    }
                    else
                    {
                        metroTextBox6.Text = "No description provided!";
                    }
                }
            }
            catch { metroTextBox6.Text = "No description provided!"; }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private Style BlueStyle = new TextStyle(Brushes.DarkCyan, null, FontStyle.Bold);
        private Style RedStyle = new TextStyle(Brushes.OrangeRed, null, FontStyle.Regular);
        private Style MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        private Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        public string CustomDatFile = "";

        public void CreateDatPaths()
        {
            if (!Directory.Exists(DataPath + "\\editing\\backup"))
            {
                CreatePaths(DataPath + "\\editing\\backup");
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Name.EndsWith(".xml"))
                {
                    metroLabel39.Text = "Loading...";
                    metroLabel39.Refresh();
                    // Clear text
                    this.fastColoredTextBox1.Clear();
                    // Load text
                    StreamReader reader = new StreamReader(e.Node.Name);
                    this.fastColoredTextBox1.Text = reader.ReadToEnd();
                    // Close
                    reader.Close();
                    metroLabel39.Text = "Done!";
                    metroLabel39.Refresh();
                }
            }
            catch
            {
                metroLabel39.Text = "Error: Could not open file";
            }
        }

        public string directoryPath = "";
        public string filePath = "";

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString().Contains(".dat")) && (myDictionary[metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString()].Length > 0))
            {
                ActiveDataFile = metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString();
                string PathAutoFinder = myDictionary[ActiveDataFile];
                treeView1.Nodes.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(PathAutoFinder + ".\\editing\\" + ActiveDataFile + ".files\\");
                if (directoryInfo.Exists)
                {
                    treeView1.AfterSelect += treeView1_AfterSelect;
                    BuildTree(directoryInfo, treeView1.Nodes);
                    treeView1.Nodes[0].Expand();
                }
            }
        }

        private void fctb_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //highlight only visible area of text
            HTMLSyntaxHighlight(fastColoredTextBox1.VisibleRange);
        }

        private void fctb_VisibilityChanged(object sender, EventArgs e)
        {
            //highlight only visible area of text
            HTMLSyntaxHighlight(fastColoredTextBox1.VisibleRange);
        }

        private void HTMLSyntaxHighlight(Range range)
        {
            //clear style of changed range
            range.ClearStyle(BlueStyle, MaroonStyle, RedStyle, GreenStyle);
            //tag brackets highlighting
            range.SetStyle(MaroonStyle, @"<|/>|</|>");
            //tag name
            range.SetStyle(MaroonStyle, @"<(?<range>[!\w]+)");
            //end of tag
            range.SetStyle(MaroonStyle, @"</(?<range>\w+)>");
            //attributes
            range.SetStyle(RedStyle, @"(?<range>\S+?)='[^']*'|(?<range>\S+)=""[^""]*""|(?<range>\S+)=\S+");
            //attribute values
            range.SetStyle(BlueStyle, @"\S+?=(?<range>'[^']*')|\S+=(?<range>""[^""]*"")|\S+=(?<range>\S+)");
            //comment values
            range.SetStyle(GreenStyle, @"<!--(?<range>\S+?)-->");
        }

        private void findCTRLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void findReplaceCTRLRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        public void bw2_Save(object Sender, DoWorkEventArgs e)
        {
            if (treeView1.SelectedNode.FullPath.ToString().Contains(".dat"))
            {
                try
                {
                    XmlSavePath = DataPath + "\\editing\\" + treeView1.SelectedNode.FullPath.ToString();
                    try
                    {
                        File.WriteAllText(XmlSavePath, fastColoredTextBox1.Text);
                        metroLabel39.Text = ("Saved!");
                    }
                    catch
                    {
                        metroLabel39.Text = ("Failed to save file!");
                    }
                }
                catch { metroLabel39.Text = ("No file opened in editor!"); }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            // Save Edited File
            bw2 = new BackgroundWorker();
            bw2.WorkerSupportsCancellation = true;
            bw2.WorkerReportsProgress = true;
            bw2.DoWork += new DoWorkEventHandler(bw2_Save);
            if (!bw2.IsBusy)
            {
                bw2.RunWorkerAsync();
            }
            else { Prompt.Popup("Please wait until saving is finished."); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Backup the data files
                DirectoryInfo configfolder = new DirectoryInfo(DataPath);
                FileInfo[] configfiles = configfolder.GetFiles("*.dat");
                foreach (FileInfo configfile in configfiles)
                {
                    if ((configfile.ToString().EndsWith(".dat")) && (myDictionary[configfile.ToString()].Length > 0))
                    {
                        string tobackup = configfile.ToString();
                        string topath = myDictionary[tobackup];
                        File.Copy(topath + "\\" + tobackup, topath + "\\editing\\backup\\" + tobackup, true);
                        metroLabel39.Text = "Backed Up Data Files";
                    }
                }
            }
            catch { Prompt.Popup("Error: Could not backup!"); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!GameStarted)
            {
                metroLabel39.Text = "Decompiling data file...";
                if ((ActiveDataFile != "") && (myDictionary[ActiveDataFile].Length > 0))
                {
                    string PathtoDat = myDictionary[ActiveDataFile];
                    usedfile = ActiveDataFile;
                    usedfilepath = PathtoDat + "\\" + ActiveDataFile;
                    Extractor(usedfile);
                    // SortOutputHandler -> updates text for progress
                    treeView1.Nodes.Clear();
                    // Seperator
                    if (Directory.Exists(PathtoDat + "\\" + ActiveDataFile + ".files"))
                    {
                        if (!Directory.Exists(PathtoDat + "\\editing\\" + ActiveDataFile + ".files"))
                        {
                            Directory.Move(PathtoDat + "\\" + ActiveDataFile + ".files", PathtoDat + "\\editing\\" + ActiveDataFile + ".files");
                        }
                        else
                        {
                            string source = PathtoDat + "\\" + ActiveDataFile + ".files";
                            string target = PathtoDat + "\\editing\\" + ActiveDataFile + ".files";
                            foreach (var file in Directory.EnumerateFiles(source))
                            {
                                var dest = Path.Combine(target, Path.GetFileName(file));
                                File.Copy(file, dest, true);
                                File.Delete(file);
                            }
                            foreach (var dir in Directory.EnumerateDirectories(source))
                            {
                                var dest = Path.Combine(target, Path.GetFileName(dir));
                                Directory.Move(dir, dest);
                            }
                            Directory.Delete(source);
                        }
                        DirectoryInfo directoryInfo = new DirectoryInfo(@PathtoDat + "\\editing\\" + ActiveDataFile + ".files\\");
                        if (directoryInfo.Exists)
                        {
                            treeView1.AfterSelect += treeView1_AfterSelect;
                            BuildTree(directoryInfo, treeView1.Nodes);
                            treeView1.Nodes[0].Expand();
                        }
                        else { metroLabel39.Text = "Error: could not move folder!"; }
                    }
                    else { metroLabel39.Text = "Error: " + ActiveDataFile + " could not be extracted!"; }
                }
            }
            else
            {
                Prompt.Popup("Game is Running! Operation Cancelled.");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!GameStarted)
            {
                metroLabel39.Text = "Compiling data file...";
                if ((ActiveDataFile != "") && (myDictionary[ActiveDataFile].Length > 0))
                {
                    string PathtoDat = myDictionary[ActiveDataFile];
                    usedfile = ActiveDataFile;
                    usedfilepathonly = PathtoDat + "\\editing\\" + ActiveDataFile + ".files";
                    Compiler(usedfile);
                }
            }
            else
            {
                Prompt.Popup("Game is Running! Operation Cancelled.");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if ((ActiveDataFile != "") && (myDictionary[ActiveDataFile].Length > 0))
            {
                string PathtoDat = myDictionary[ActiveDataFile];
                if (File.Exists(PathtoDat + "\\editing\\" + ActiveDataFile + ""))
                {
                    NewDat = PathtoDat + "\\editing\\" + ActiveDataFile + "";
                    try
                    {
                        File.Copy(NewDat, PathtoDat + "\\" + ActiveDataFile + "", true);
                        metroLabel39.Text = "Patched " + ActiveDataFile + "";
                    }
                    catch
                    {
                        Prompt.Popup("Error: Could not apply patch!");
                    }
                }
                else { Prompt.Popup("Please Compile"); }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DialogResult ASKER = Prompt.RestoreConfigAsk();
            if (ASKER == DialogResult.Yes)
            {
                if ((ActiveDataFile != "") && (myDictionary[ActiveDataFile].Length > 0))
                {
                    string PathtoDat = myDictionary[ActiveDataFile];
                    try
                    {
                        File.Copy(PathtoDat + "\\editing\\backup\\" + ActiveDataFile + "", PathtoDat + "\\" + ActiveDataFile + "", true);
                        metroLabel39.Text = "Restored " + ActiveDataFile + "";
                    }
                    catch
                    {
                        metroLabel39.Text = ("Error: Could not restore " + ActiveDataFile + "!");
                    }
                }
            }
        }

        private Dictionary<string, string> myDictionary = new Dictionary<string, string>();

        private void DefaultDatValues()
        {
            // Empty if filled
            if (metroComboBox3.Items.Count > 0)
            {
                metroComboBox3.Items.Clear();
            }
            // Reset dictionary
            if (myDictionary.Count > 0)
            {
                myDictionary = new Dictionary<string, string>();
            }
            // Generate members
            string filesource = "";
            string filesourcepath = "";
            DirectoryInfo configfolder = new DirectoryInfo(DataPath);
            FileInfo[] configfiles = configfolder.GetFiles("*.dat");
            foreach (FileInfo configfile in configfiles)
            {
                filesource = configfile.ToString();
                filesourcepath = Path.GetDirectoryName(configfile.FullName);
                myDictionary.Add(configfile.Name, filesourcepath);
                metroComboBox3.Items.Add(filesource);
            }
            // Select default after compiling
            if (metroComboBox3.Items.Count > 0)
            {
                metroComboBox3.SelectedIndex = 0;
            }
            // Activate Keyboard shortcuts for dat editor
            KeyPreview = true;
        }

        public void SortOutputHandler(string value)
        {
            metroLabel39.Text = value;
            metroLabel39.Refresh();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Prompt.Popup("1: Backup your config files by pressing \"Backup\"" + Environment.NewLine + "2: Select your file to work on then press \"Decompile\" to extract the .dat file" + Environment.NewLine + "3: Select the file to edit in the tree then modify it with the TextBox on the right" + Environment.NewLine + "4: Save the modifications made by pressing \"Save\"" + Environment.NewLine + "5: Compile it all by pressing \"Compile\"" + Environment.NewLine + "6: Apply changes to change from your games untouched config files to the modified ones by pressing \"Apply\"" + Environment.NewLine + "Tip: Restoring your config files can be done by pressing \"Restore\"");
        }

        public void CleanMess()
        {
            string localvar = "";
            try
            {
                if (Directory.Exists(DataPath + "\\editing"))
                {
                    AddTextLog("Cleaning Mess");
                    DirectoryInfo path = new DirectoryInfo(DataPath + "\\editing");
                    foreach (DirectoryInfo subdir in path.GetDirectories())
                    {
                        string subbeddir = Path.GetDirectoryName(subdir.ToString());
                        if (!subbeddir.Contains("backup"))
                        {
                            localvar = subbeddir;
                            if (Directory.GetFiles(DataPath + "\\editing\\" + localvar).Length > 0)
                            {
                                Array.ForEach(Directory.GetFiles(@DataPath + "\\editing\\" + localvar), File.Delete);
                            }
                            Directory.Delete(DataPath + "\\editing\\" + localvar, true);
                            AddTextLog("Cleaned " + localvar);
                        }
                    }
                    try
                    {
                        if (Directory.Exists(@DataPath + "\\editing\\"))
                        {
                            Array.ForEach(Directory.GetFiles(@DataPath + "\\editing\\"), File.Delete);
                            AddTextLog("Cleaned up editing folder");
                        }
                    }
                    catch (Exception x) { AddTextLog("Could not remove file -> " + x.ToString()); }
                }
                else { AddTextLog("Mess Already Cleaned"); }
            }
            catch { AddTextLog("Could not remove folder -> " + DataPath + "\\editing\\" + localvar); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!     ||     TokenGrabber
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private bool Debugging = false;
        private BackgroundWorker worker;
        private string username, password, epoch, pid, localIP;
        private string args = "{0}", token;
        private string LoginId, LoginIp, LoginProgramid;
        private int LoginPort, counter;
        private string LoginAppid;
        private BNSXorEncryption xor;
        private List<region> regions = new List<region>();
        private string currentAppId, currentValue;

        public static BigInteger N = new BigInteger("E306EBC02F1DC69F5B437683FE3851FD9AAA6E97F4CBD42FC06C72053CBCED68EC570E6666F529C58518CF7B299B5582495DB169ADF48ECEB6D65461B4D7C75DD1DA89601D5C498EE48BB950E2D8D5E0E0C692D613483B38D381EA9674DF74D67665259C4C31A29E0B3CFF7587617260E8C58FFA0AF8339CD68DB3ADB90AAFEE");
        public static BigInteger P = new BigInteger("7A39FF57BCBFAA521DCE9C7DEFAB520640AC493E1B6024B95A28390E8F05787D");
        public static byte[] staticKey = Conversions.HexStr2Bytes("AC34F3070DC0E52302C2E8DA0E3F7B3E63223697555DF54E7122A14DBC99A3E8");
        public static BigInteger Two = new BigInteger(2);

        private BigInteger privateKey;
        private BigInteger exchangeKey = Two;
        private BigInteger exchangeKeyServer, session, validate;

        private SHA256 sha = SHA256.Create();
        private byte[] key;
        private TcpClient LoginServer;

        public void GrabToken() // Login action
        {
            bool naeu = false;
            // Change Region based
            if (metroComboBox1.SelectedItem != null)
            {
                // Attempt fix
                if (regions.Count != 0 && RegionCB.Items.Count == 0)
                {
                    AddTextLog("Attempting to fix server selection");
                    RegionCB.DataSource = regions;
                    // If attempt didnt work, manually add
                    if (RegionCB.Items.Count == 0)
                    {
                        AddTextLog("Failed");
                        AddTextLog("Attempting a second method");
                        for (int ini = 0; regions.Count > ini; ini++)
                            RegionCB.Items.Add(regions[ini]);
                    }
                    AddTextLog("Proceeding...");
                    // Should be good to go!
                }
                // Go!
                string tmp0 = metroComboBox1.SelectedItem.ToString();
                if (tmp0 == "North America" || tmp0 == "Europe")
                {
                    if (RegionCB.Items.Count > 1) // Automatically select the server selected
                    {
                        if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("North America"))
                        {
                            RegionCB.SelectedIndex = RegionCB.FindStringExact("North America");
                            if (Debugging)
                                Prompt.Popup("Using North America");
                        }
                        else
                        {
                            RegionCB.SelectedIndex = RegionCB.FindStringExact("Europe");
                            if (Debugging)
                                Prompt.Popup("Using Europe");
                        }
                    }
                    else if (RegionCB.Items.Count == 1) // Select the only server available if other is blocked
                    {
                        RegionCB.SelectedIndex = 0;
                        if (Debugging)
                            Prompt.Popup("Using " + RegionCB.SelectedItem.ToString());
                    }
                    else // Popup message if none is available
                    {
                        Prompt.Popup("Error: No available servers were found for NA/EU!");
                        naeu = true;
                    }
                }
            }
            // End region based

            if (worker != null && worker.IsBusy)
            {
                LoginServer.Close();
                worker.CancelAsync();
            }
            if (!naeu)
            {
                if (metroComboBox1.SelectedItem != null)
                {
                    string tmp = metroComboBox1.SelectedItem.ToString();
                    // NA/EU
                    if (tmp == "North America" || tmp == "Europe")
                    {
                        currentAppId = ((region)RegionCB.SelectedValue).appId;
                        currentValue = ((region)RegionCB.SelectedValue).value;
                    }
                    // KOREA
                    else
                    if (tmp == "Korean")
                    {
                        if (metroComboBox8.SelectedItem.ToString() == "Live")
                        {
                            currentAppId = "B0D42105-0CB6-BC9F-3CB2-BE28A0662340";
                        }
                        else { currentAppId = "18A2B067-7A7E-DA99-CDF1-3BBE3BE93F68"; }
                    }
                    // TAIWAN
                    else
                    if (tmp == "Taiwan")
                    {
                        currentAppId = "33BC338F-2651-8ECD-9E2A-444843707997";
                    }
                }
                else // additional check to make sure it's not nulled
                {
                    metroComboBox1.SelectedIndex = 0;
                    // Reset App Id
                    string tmp = metroComboBox1.SelectedItem.ToString();
                    // NA/EU
                    if (tmp == "North America" || tmp == "Europe")
                    {
                        currentAppId = ((region)RegionCB.SelectedValue).appId;
                        currentValue = ((region)RegionCB.SelectedValue).value;
                    }
                    // KOREA
                    else
                    if (tmp == "Korean")
                    {
                        if (metroComboBox8.SelectedItem.ToString() == "Live")
                        {
                            currentAppId = "B0D42105-0CB6-BC9F-3CB2-BE28A0662340";
                        }
                        else { currentAppId = "18A2B067-7A7E-DA99-CDF1-3BBE3BE93F68"; }
                    }
                    // TAIWAN
                    else
                    if (tmp == "Taiwan")
                    {
                        currentAppId = "33BC338F-2651-8ECD-9E2A-444843707997";
                    }
                }
                try
                {
                    //Set some variables that are going to be used
                    epoch = ((long)(DateTime.UtcNow - new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString();
                    //username = metroTextBox1.Text;
                    //password = metroTextBox2.Text;
                    pid = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
                    privateKey = new BigInteger(sha.ComputeHash(BigInteger.genRandom(6).getBytes()));
                    exchangeKey = Two;
                    counter = 0;
                }
                catch { Prompt.Popup("Error: Could not create Session Key!"); }

                worker = new BackgroundWorker();
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += Try_Connection;
                worker.RunWorkerAsync();
            }
            else
            {
                AddTextLog("Error: Login Failed, servers are not reachable!");
            }
        }

        private bool LauncherInfo()
        {
            metroButton1.Enabled = false;

            // Set values
            string tmp = metroComboBox1.SelectedItem.ToString();
            string patch_server = "";
            string game_id = "";
            // KOREAN
            if (tmp == "Korean")
            {
                patch_server = "up4svr.plaync.co.kr";
                game_id = "ncLauncherS"; // BNS_KOR
            }
            // NA/EU
            else
            if (tmp == "North America" || tmp == "Europe")
            {
                patch_server = "updater.nclauncher.ncsoft.com";
                game_id = "BnS";
            }
            // TAIWAN
            else
            if (tmp == "Taiwan")
            {
                patch_server = "up4svr.plaync.com.tw";
                game_id = "ncLauncherS";
            }
            // if all else fails
            else
            {
                patch_server = "updater.nclauncher.ncsoft.com";
                game_id = "BnS";
            }
            // Check that BnS isn't in Maintenance
            try
            {
                #region Check Game Online

                int port = 27500;
                MemoryStream ms = new MemoryStream();
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write((short)0);//place holder for length
                bw.Write((short)4);//packet identifer, in this case game status information
                bw.Write((byte)10);//seperator character
                bw.Write((byte)game_id.Length);//write length of string
                bw.Write(Encoding.ASCII.GetBytes(game_id));//write string
                bw.BaseStream.Position = 0;//go back to start to update length
                bw.Write((short)ms.Length);

                TcpClient client = new TcpClient(patch_server, port);
                NetworkStream ns = client.GetStream();
                ns.Write(ms.ToArray(), 0, (int)ms.Length);
                bw.Close();
                ms.Close();
                bw = null;

                ms = new MemoryStream();
                BinaryReader br = new BinaryReader(ms);
                byte[] buffer = new byte[1024];
                int bytesRec = 0;

                //Read data sent back from patch server;
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);

                //Read Login Info
                ms.Position = 9; //skip to length of string sent back
                br.ReadBytes(br.ReadByte() + 1); //read string + next byte
                bool serverIsOnline = br.ReadBoolean();
                ns.Close();
                br.Close();
                ms.Close();

                #endregion Check Game Online

                if (!serverIsOnline && !Debugging)
                {
                    Prompt.Popup("The Game Server is currently in maintenance, please try again later.");
                    Maintenance = true;
                    metroButton1.Enabled = true;
                    return false;
                }
                else
                {
                    Maintenance = false;
                }
            }
            catch (Exception ex)
            {
                Prompt.Popup("There was an error connecting to the Login Server, please make sure your ip isn't blocked.");
                if (Debugging)
                {
                    Prompt.Popup(ex.ToString());
                }
                metroButton1.Enabled = true;
                return false;
            }
            // Login to play game
            AddTextLog("Adding available servers...");
            //Get login server for BNS Info
            try
            {
                #region Get Login Server Info

                // continue
                int port = 27500; // 27500
                MemoryStream ms = new MemoryStream();
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write((short)0);//place holder for length
                bw.Write((short)8);//packet identifer, in this case login server information // was 8
                bw.Write((byte)10);//seperator character
                bw.Write((byte)game_id.Length);//write length of string
                bw.Write(Encoding.ASCII.GetBytes(game_id));//write string
                bw.BaseStream.Position = 0;//go back to start to update length
                bw.Write((short)ms.Length);

                TcpClient client = new TcpClient(patch_server, port);

                localIP = ((IPEndPoint)client.Client.LocalEndPoint).Address.ToString();
                NetworkStream ns = client.GetStream();
                ns.Write(ms.ToArray(), 0, (int)ms.Length);
                bw.Close();
                ms.Close();
                bw = null;

                ms = new MemoryStream();
                BinaryReader br = new BinaryReader(ms);
                byte[] buffer = new byte[1024];
                int bytesRec = 0;

                //Read data sent back from patch server;
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);

                //Read Login Info
                ms.Position = 9; //skip to length of string sent back
                br.ReadBytes(br.ReadByte() + 1); //read string + next byte
                string xml = Encoding.UTF8.GetString(br.ReadBytes(br.ReadByte() + (128 * (br.ReadByte() - 1))));
                ns.Close();
                br.Close();
                ms.Close();

                #endregion Get Login Server Info

                xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<Settings>" + xml.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "").Replace("  ", "\r\n") + "\r\n</Settings>";
                LoginId = Regex.Match(xml, "id=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                LoginIp = Regex.Match(xml, "ip=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                LoginPort = Int32.Parse(Regex.Match(xml, "port=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value);
                LoginProgramid = Regex.Match(xml, "programid=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                // test
                if (tmp != "North America" && tmp != "Europe")
                {
                    LoginAppid = Regex.Match(xml, "appid=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                }

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);

                if (tmp == "North America" || tmp == "Europe")
                {
                    foreach (XmlElement regionEle in xmldoc.SelectNodes("//region"))
                    {
                        regions.Add(new region(regionEle.Attributes["name"].Value, regionEle.Attributes["value"].Value, regionEle.Attributes["appid"].Value));
                    }
                }

                //Prompt.Popup(String.Format("IP: {0}\nPort: {1}\nProgramID: {2}\nAppID: {3}", LoginIp, LoginPort, LoginProgramid/*, LoginAppid */));
            }
            catch (Exception ex)
            {
                Prompt.Popup("There was an error connecting to the Login Server, please make sure there isn't a maintenance.");
                if (Debugging)
                {
                    Prompt.Popup(ex.ToString());
                }
                metroButton1.Enabled = true;
                return false;
            }
            metroButton1.Enabled = true;
            AddTextLog("Added");
            return true;
        }

        public class BNSXorEncryption
        {
            private byte[] encKey, decKey;
            private int encCounter, decCounter, encSum, decSum;
            private byte[] key;

            public BNSXorEncryption(byte[] keyInt)
            {
                key = keyInt;
            }

            public byte[] Encrypt(byte[] src, int offset, int len)
            {
                if (encKey == null)
                {
                    if (key != null)
                    {
                        encKey = new byte[key.Length];
                        key.CopyTo(encKey, 0);
                        encCounter = 0;
                    }
                    else
                        return null;
                }
                return BlockEncrypt(src, encKey, ref encCounter, ref encSum);
            }

            public byte[] Decrypt(byte[] src, int offset, int len)
            {
                if (decKey == null)
                {
                    if (key != null)
                    {
                        decKey = new byte[key.Length];
                        key.CopyTo(decKey, 0);
                        decCounter = 0;
                    }
                    else
                        return null;
                }
                return BlockEncrypt(src, decKey, ref decCounter, ref decSum);
            }

            private byte[] BlockEncrypt(byte[] src, byte[] key, ref int counter, ref int sum)
            {
                for (int i = 0; i < src.Length; i++)
                {
                    int index = (counter + 1) & 0xFF;
                    counter = index;
                    int v11 = (sum + key[index]) & 0xFF;
                    sum = v11;
                    int v12 = key[index];
                    key[index] = key[v11];
                    key[v11] = (byte)v12;
                    src[i] = (byte)(src[i] ^ key[(key[sum] + key[counter]) & 0xFF]);
                }
                return src;
            }
        }

        private class region
        {
            public string name;
            public string value;
            public string appId;

            public region(string n, string v, string a)
            {
                name = n;
                value = v;
                appId = a;
            }

            public override string ToString()
            {
                return name;
            }
        }

        private void SetUniqueKey()
        {
            if (uniquekeyset == false)
            {
                string tmp = StringToHex(Environment.GetEnvironmentVariable("COMPUTERNAME").ToString());
                string tmp2 = StringToHex(NetworkInterface.GetAllNetworkInterfaces().Where(nic => nic.OperationalStatus == OperationalStatus.Up).Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault().ToString());
                uniquekey = tmp + tmp2;
                uniquekeyset = true;
            }
        }

        private string StringToHex(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char t in s)
            {
                sb.Append(Convert.ToInt32(t).ToString("x"));
            }
            return sb.ToString();
        }

        private bool uniquekeyset = false;
        private string uniquekey = "";

        private void metroTextBox8_Click(object sender, EventArgs e)
        {
            if (AppStarted == true)
            {
                // Get
                string tracker = File.ReadLines(@AppPath + "\\Settings.ini").Skip(36).Take(1).First().Replace("uniquepass = ", "");
                // Set, replace , write
                var fileContents2 = File.ReadAllText(@AppPath + "\\Settings.ini");
                if (tracker.Length > 0)
                {
                    var newfileContents2 = fileContents2.Replace(tracker, metroTextBox8.Text);
                    File.WriteAllText(@AppPath + "\\Settings.ini", newfileContents2);
                }
                else
                {
                    lineChanger("uniquepass = " + metroTextBox8.Text, @AppPath + "\\Settings.ini", 37);
                }
                // Actualise
                metroTextBox8.Refresh();
            }
            if (metroTextBox8.Text == uniquekey)
            {
                metroTile1.Visible = false;
            }
            else
            {
                metroTile1.Visible = true;
            }
        }

        private void metroComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox9.SelectedItem != null)
            {
                if (metroComboBox9.SelectedItem.ToString() == "New Instance")
                {
                    PlayGame();
                }
            }
        }

        private void metroToggle22_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (metroToggle22.Checked)
                {
                    if (Directory.Exists(RegPath + LauncherPath))
                    {
                        try
                        {
                            File.WriteAllBytes(RegPath + LauncherPath + "\\winmm.dll", Resources.winmm_32_);
                            metroLabel81.Text = "Active";
                        }
                        catch { Prompt.Popup("Error: Could not apply winmm.dll to \"" + RegPath + LauncherPath + "\"!"); }
                    }
                    else { metroLabel81.Text = "-"; }
                    if (Directory.Exists(RegPath + LauncherPath64))
                    {
                        try
                        {
                            File.WriteAllBytes(RegPath + LauncherPath64 + "\\winmm.dll", Resources.winmm_64_);
                            metroLabel82.Text = "Active";
                        }
                        catch { Prompt.Popup("Error: Could not apply winmm.dll to \"" + RegPath + LauncherPath64 + "\"!"); }
                    }
                    else { metroLabel82.Text = "-"; }
                    // Disable Auto Login
                    if (metroLabel81.Text == "Active" || metroLabel82.Text == "Active")
                    {
                        metroToggle25.Enabled = false;
                    }
                }
                else
                {
                    if (metroLabel81.Text == "Active")
                    {
                        try
                        {
                            File.Delete(RegPath + LauncherPath + "\\winmm.dll");
                            metroLabel81.Text = "Inactive";
                        }
                        catch { Prompt.Popup("Error: Could not remove winmm.dll from \"" + RegPath + LauncherPath + "\"!"); }
                    }
                    if (metroLabel82.Text == "Active")
                    {
                        try
                        {
                            File.Delete(RegPath + LauncherPath64 + "\\winmm.dll");
                            metroLabel82.Text = "Inactive";
                        }
                        catch { Prompt.Popup("Error: Could not remove winmm.dll from \"" + RegPath + LauncherPath64 + "\"!"); }
                    }
                    if (metroLabel81.Text == "Inactive" && metroLabel82.Text == "Inactive")
                    {
                        metroToggle25.Enabled = true;
                    }
                }
            }
        }

        private void metroToggle21_CheckedChanged(object sender, EventArgs e)
        {
            groupBox17.Enabled = false;
            if (AppStarted)
            {
                if (metroToggle21.Checked == true)
                {
                    lineChanger("gcdshow = true", @AppPath + "\\Settings.ini", 38);
                    metroLabel72.Visible = true;
                    metroLabel73.Visible = true;
                }
                else
                {
                    lineChanger("gcdshow = false", @AppPath + "\\Settings.ini", 38);
                    metroLabel72.Visible = false;
                    metroLabel73.Visible = false;
                }
                metroLabel72.Refresh();
                metroLabel73.Refresh();
            }
            groupBox17.Enabled = true;
        }

        private void metroToggle24_CheckedChanged(object sender, EventArgs e)
        {
            groupBox17.Enabled = false;
            if (AppStarted)
            {
                if (metroToggle24.Checked == true)
                {
                    lineChanger("igpshow = true", @AppPath + "\\Settings.ini", 39);
                    metroLabel70.Visible = true;
                    metroLabel71.Visible = true;
                }
                else
                {
                    lineChanger("igpshow = false", @AppPath + "\\Settings.ini", 39);
                    metroLabel70.Visible = false;
                    metroLabel71.Visible = false;
                }
                metroLabel70.Refresh();
                metroLabel71.Refresh();
            }
            groupBox17.Enabled = true;
        }

        private void metroToggle25_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (metroToggle25.Checked == true)
                {
                    lineChanger("autologin = true", @AppPath + "\\Settings.ini", 40);
                }
                else
                {
                    lineChanger("autologin = false", @AppPath + "\\Settings.ini", 40);
                }
            }
        }

        private void metroToggle28_Click(object sender, EventArgs e)
        {
            if (metroToggle28.Checked)
            {
                lineChanger("rememberme = true", @AppPath + "\\Settings.ini", 31);
            }
            else
            {
                lineChanger("rememberme = false", @AppPath + "\\Settings.ini", 31);
            }
        }

        private string customclientname = "";

        private void metroTextBox9_Click(object sender, EventArgs e)
        {
            customclientname = metroTextBox9.Text;
            lineChanger("customclientname = " + metroTextBox9.Text, @AppPath + "\\Settings.ini", 43);
        }

        private void metroToggle26_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle26.Checked)
            {
                lineChanger("usercountcheck = true", @AppPath + "\\Settings.ini", 41);
                UserCountCheck = true;
                manualcount = true;
                Task.Delay(500).ContinueWith(t => Get_Count());
            }
            else
            {
                lineChanger("usercountcheck = false", @AppPath + "\\Settings.ini", 41);
                UserCountCheck = false;
                manualcount = true;
                Task.Delay(500).ContinueWith(t => Get_Count());
            }
        }

        private void metroToggle27_CheckedChanged(object sender, EventArgs e)
        {
            if (!metroToggle27.Checked)
            {
                lineChanger("showcount = true", @AppPath + "\\Settings.ini", 42);
                metroLabel94.Visible = true;
                metroLabel93.Visible = true;
            }
            else
            {
                lineChanger("showcount = false", @AppPath + "\\Settings.ini", 42);
                metroLabel94.Visible = false;
                metroLabel93.Visible = false;
            }
        }

        private System.Windows.Forms.Timer cooldown = new System.Windows.Forms.Timer();

        private void metroLabel94_Click(object sender, EventArgs e)
        {
            manualcount = true;
            if (!cooldown.Enabled)
            {
                cooldown.Enabled = true;
                // Set cooldown for 5 seconds
                cooldown.Interval = 5000;
                cooldown.Tick += Cooldown_Tick;
                // Continue
                Task.Delay(500).ContinueWith(t => Get_Count());
                AddTextLog("[LOG] Refreshed Count");
            }
            else
            {
                AddTextLog("[LOG] On Cooldown");
            }
        }

        private void Cooldown_Tick(object sender, EventArgs e)
        {
            cooldown.Enabled = false;
        }

        private void metroComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (metroComboBox11.SelectedItem.ToString() == "Black")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Black;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Red")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Red;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Purple")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Purple;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Pink")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Pink;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Orange")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Magenta")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Magenta;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Lime")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Lime;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Green")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Green;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Default")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Default;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Brown")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Brown;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Blue")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Silver")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Silver;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Teal")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Teal;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.White;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Yellow")
                {
                    Themer.Style = MetroFramework.MetroColorStyle.Yellow;
                }
                lineChanger("buddycolor = " + Themer.Style.ToString(), @AppPath + "\\Settings.ini", 44);
            }
        }

        private BigInteger GetKeyExchange()
        {
            if (exchangeKey == Two)
                exchangeKey = Two.modPow(privateKey, N);
            return exchangeKey;
        }

        private BigInteger SHA256Hash2ArrayInverse(byte[] tmp1, byte[] tmp2)
        {
            BigInteger hash;
            byte[] combine = new byte[tmp1.Length + tmp2.Length];
            tmp1.CopyTo(combine, 0);
            tmp2.CopyTo(combine, tmp1.Length);
            byte[] buf = sha.ComputeHash(combine);
            byte[] res = IntegerReverse(buf);
            hash = new BigInteger(res);
            return hash;
        }

        private byte[] IntegerReverse(byte[] buf)
        {
            byte[] res = new byte[buf.Length];
            for (int i = 0; i < res.Length / 4; i++)
            {
                fixed (byte* ptr = buf)
                {
                    fixed (byte* ptr2 = res)
                    {
                        int* src = (int*)ptr;
                        int* dst = (int*)ptr2;
                        dst[i] = src[res.Length / 4 - 1 - i];
                    }
                }
            }

            return res;
        }

        private byte[] GenerateEncryptionKeyRoot(byte[] src)
        {
            int firstSize = src.Length;
            int startIndex = 0;
            byte[] half;
            byte[] dst = new byte[64];
            if (src.Length > 4)
            {
                do
                {
                    if (src[startIndex] == 0)
                        break;
                    firstSize--;
                    startIndex++;
                } while (firstSize > 4);
            }
            int size = firstSize >> 1;
            half = new byte[size];
            if (size > 0)
            {
                int index = startIndex + firstSize - 1;
                for (int i = 0; i < size; i++)
                {
                    half[i] = src[index];
                    index -= 2;
                }
            }
            byte[] hash = sha.ComputeHash(half, 0, size);
            for (int i = 0; i < 32; i++)
            {
                dst[2 * i] = hash[i];
            }
            if (size > 0)
            {
                int index = startIndex + firstSize - 2;
                for (int i = 0; i < size; i++)
                {
                    half[i] = src[index];
                    index -= 2;
                }
            }
            hash = sha.ComputeHash(half, 0, size);
            for (int i = 0; i < 32; i++)
            {
                dst[2 * i + 1] = hash[i];
            }
            return dst;
        }

        private byte[] CombineBuffers(params byte[][] buffers)
        {
            int len = 0;
            foreach (byte[] i in buffers)
            {
                len += i.Length;
            }
            byte[] res = new byte[len];
            int index = 0;
            foreach (byte[] i in buffers)
            {
                i.CopyTo(res, index);
                index += i.Length;
            }
            return res;
        }

        private byte[] Generate256BytesKey(byte[] src)
        {
            int v7 = 1;
            byte[] res = new byte[256];
            for (int i = 0; i < 256; i++)
                res[i] = (byte)i;
            int v6 = 0;
            int counter = 0;
            for (int i = 64; i > 0; i--)
            {
                int v9 = (v6 + src[counter] + res[v7 - 1]) & 0xFF;
                int v10 = res[v7 - 1];
                res[v7 - 1] = res[v9];
                int v8 = counter + 1;
                res[v9] = (byte)v10;
                if (v8 == src.Length)
                    v8 = 0;
                int v13 = v9 + src[v8];
                int v11 = v8 + 1;
                int v14 = v13 + res[v7];
                v13 = res[v7];
                int v12 = (byte)v14;
                res[v7] = res[v12];
                res[v12] = (byte)v13;
                if (v11 == src.Length)
                    v11 = 0;
                int v16 = (v12 + src[v11] + res[v7 + 1]) & 0xFF;
                int v17 = res[v7 + 1];
                res[v7 + 1] = res[v16];
                int v15 = v11 + 1;
                res[v16] = (byte)v17;
                if (v15 == src.Length)
                    v15 = 0;
                int v18 = v16 + src[v15];
                int v19 = res[v7 + 2];
                v6 = (v18 + res[v7 + 2]) & 0xFF;
                counter = v15 + 1;
                res[v7 + 2] = res[v6];
                res[v6] = (byte)v19;
                if (counter == src.Length)
                    counter = 0;
                v7 += 4;
            }
            return res;
        }

        private string Builder(string nameSpace, string function)
        {
            counter++;
            switch (nameSpace)
            {
                case "Sts":
                    {
                        switch (function)
                        {
                            case "Connect":
                                {
                                    string data = String.Format(
                                        "<Connect>\n" +
                                        "<ConnType>400</ConnType>\n" +
                                        "<Address>{0}</Address>\n" +
                                        "<ProductType>0</ProductType>\n" +
                                        "<AppIndex>1</AppIndex>\n" +
                                        "<Epoch>{1}</Epoch>\n" +
                                        "<Program>{2}</Program>\n" +
                                        "<Build>1001</Build>\n" +
                                        "<Process>{3}</Process>\n" +
                                        "</Connect>\n",
                                        localIP,
                                        epoch,
                                        LoginProgramid,
                                        pid);
                                    return string.Format("POST /Sts/Connect STS/1.0\r\nl:{0}\r\n\r\n{1}", data.Length, data);
                                }
                                break;

                            case "Ping":
                                {
                                    return "POST /Sts/Ping STS/1.0\r\nl:0\r\n\r\n";
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    break;

                case "Auth":
                    {
                        switch (function)
                        {
                            case "LoginStart":
                                {
                                    string data = String.Format(
                                        "<Request>\n" +
                                        "<LoginName>{0}</LoginName>\n" +
                                        "</Request>\n",
                                        username
                                        );

                                    return string.Format("POST /Auth/LoginStart STS/1.0\r\ns:{4}\r\np:*{0} 0 1 0 {1}\r\nl:{2}\r\n\r\n{3}", localIP, epoch, data.Length, data, counter);
                                }
                                break;

                            case "KeyData":
                                {
                                    byte[][] values = GenerateKeyClient(exchangeKeyServer);
                                    MemoryStream ms = new MemoryStream();
                                    BinaryWriter bw = new BinaryWriter(ms);

                                    bw.Write(exchangeKey.getBytes().Length);
                                    bw.Write(exchangeKey.getBytes());
                                    bw.Write(values[0].Length);
                                    bw.Write(values[0]);

                                    validate = new BigInteger(values[1]);

                                    string data = String.Format(
                                        "<Request>\n" +
                                        "<KeyData>{0}</KeyData>\n" +
                                        "</Request>\n",
                                        Convert.ToBase64String(ms.ToArray())
                                        );

                                    bw.Close();
                                    ms.Close();

                                    return string.Format("POST /Auth/KeyData STS/1.0\r\ns:{4}\r\np:*{0} 0 1 0 {1}\r\nl:{2}\r\n\r\n{3}", localIP, epoch, data.Length, data, counter);
                                }
                                break;

                            case "LoginFinish":
                                {
                                    string data = "<Request>\n<Language>1</Language>\n</Request>\n";
                                    return string.Format("POST /Auth/LoginFinish STS/1.0\r\ns:{2}\r\nl:{0}\r\n\r\n{1}", data.Length, data, counter);
                                }
                                break;

                            case "RequestToken":
                                {
                                    string data = String.Format(
                                        "<Request>\n" +
                                        "<AppId>{0}</AppId>\n" +
                                        "</Request>\n",
                                         currentAppId);
                                    return string.Format("POST /Auth/RequestToken STS/1.0\r\ns:{2}\r\nl:{0}\r\n\r\n{1}", data.Length, data, counter);
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }

            return null;
        }

        public void SlowPrompt(object sender, EventArgs e)
        {
            countdown.Stop();
            Prompt.Popup("You may need to close BnS Buddy then login on NCSoft Launcher to validate your ip and/or check your connection.");
        }

        private System.Windows.Forms.Timer countdown = new System.Windows.Forms.Timer();

        public void Try_Connection(object sender, DoWorkEventArgs e)
        {
            try
            {
                // start timer
                countdown.Interval = 8000;
                countdown.Tick += new EventHandler(SlowPrompt);
                countdown.Start();
                //
                LoginServer = new TcpClient(LoginIp, LoginPort);
                LoginServer.ReceiveBufferSize = 1024;
                NetworkStream ns = LoginServer.GetStream();
                ns.ReadTimeout = 60000;
                ns.ReadTimeout = 60000;

                DateTime lastSent = DateTime.Now;
                int pingInterval = 30;

                string packet = Builder("Sts", "Connect");
                ns.Write(Encoding.ASCII.GetBytes(packet), 0, packet.Length);

                if (Debugging)
                    Prompt.Popup("Sent Sts request to connect");

                packet = Builder("Auth", "LoginStart");
                ns.Write(Encoding.ASCII.GetBytes(packet), 0, packet.Length);

                if (Debugging)
                    Prompt.Popup("Sent Auth request to start login");

                MemoryStream ms = new MemoryStream();
                byte[] buffer = new byte[1024];
                int bytesRec = 0;

                //Read data sent back from login server
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);
                string reply = Encoding.ASCII.GetString(ms.ToArray());
                reply = reply.Split('\r')[0].Split(' ')[2];

                if (Debugging)
                    Prompt.Popup("Server Reply: " + reply);

                switch (reply)
                {
                    case "OK":
                        break;

                    case "ErrAccountNotFound":
                        Prompt.Popup("The provided email address wasn't found");
                        metroButton1.Enabled = true;
                        Show(); // Shows the program on taskbar
                                // Stop useless countdown
                        countdown.Stop();
                        this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                        return;

                    default:
                        if (username.Length > 0 && password.Length > 0)
                        {
                            Prompt.Popup("Invalidly formated email");
                        }
                        else { AddTextLog("Cancelled"); }
                        metroButton1.Enabled = true;
                        Show(); // Shows the program on taskbar
                                // Stop useless countdown
                        countdown.Stop();
                        this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                        this.TopMost = true;
                        this.TopMost = false;
                        return;
                }
                ms.Close();

                try
                {
                    ms = new MemoryStream();
                    do
                    {
                        bytesRec = ns.Read(buffer, 0, buffer.Length);

                        if (bytesRec > 0)
                        {
                            ms.Write(buffer, 0, bytesRec);
                        }
                    }
                    while (bytesRec == buffer.Length);
                }
                catch
                {
                    Prompt.Popup("Please verify your new ip to NCSoft's website(whitelist via security settings) or NCSoft Launcher via pin confirmation.");
                    foreach (var process in Process.GetProcessesByName("Client"))
                    {
                        if (process.Id == appuniqueid)
                        {
                            process.Kill();
                            appuniqueid = 0;
                        }
                    }
                    if (customclientname != "")
                    {
                        string tmp = customclientname.Replace(".exe", "");
                        foreach (var process in Process.GetProcessesByName(tmp))
                        {
                            if (process.Id == appuniqueid)
                            {
                                process.Kill();
                                appuniqueid = 0;
                            }
                        }
                    }
                    metroButton1.Enabled = true;
                    Show(); // Shows the program on taskbar
                    this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                    // Stop useless countdown
                    countdown.Stop();
                    return;
                }

                reply = Encoding.ASCII.GetString(ms.ToArray());
                ms.Close();
                reply = Regex.Match(reply, "<KeyData>([^<]*)</KeyData>", RegexOptions.IgnoreCase).Groups[1].Value;
                ms = new MemoryStream(Convert.FromBase64String(reply));

                BinaryReader br = new BinaryReader(ms);
                session = new BigInteger(br.ReadBytes(br.ReadInt32()));
                exchangeKeyServer = new BigInteger(br.ReadBytes(br.ReadInt32()));
                br.Close();
                ms.Close();

                if (Debugging)
                    Prompt.Popup("Server Reply 1: " + session);
                if (Debugging)
                    Prompt.Popup("Server Reply 2: " + exchangeKeyServer);

                packet = Builder("Auth", "KeyData");
                ns.Write(Encoding.ASCII.GetBytes(packet), 0, packet.Length);

                //Read data sent back from login server
                ms = new MemoryStream();
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);
                reply = Encoding.ASCII.GetString(ms.ToArray());
                reply = reply.Split('\r')[0].Split(' ')[2];
                switch (reply)
                {
                    case "OK":
                        break;

                    case "ErrBadPasswd":
                        Prompt.Popup("Wrong Password or Email");
                        metroButton1.Enabled = true;
                        Show(); // Shows the program on taskbar
                                // Stop useless countdown
                        countdown.Stop();
                        this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                        return;

                    case "ErrRiskMgmtDeclined":
                        Prompt.Popup("You have exceeded the number of attempts allowed.\r\nFor security reasons, login is temporarily disabled.\r\nPlease try again later.");
                        metroButton1.Enabled = true;
                        Show(); // Shows the program on taskbar
                                // Stop useless countdown
                        countdown.Stop();
                        this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                        return;

                    default:
                        Prompt.Popup("Unknown Error: " + reply);
                        metroButton1.Enabled = true;
                        Show(); // Shows the program on taskbar
                                // Stop useless countdown
                        countdown.Stop();
                        this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                        return;
                }
                ms.Close();
                ms = new MemoryStream();
                do
                {
                    bytesRec = ns.Read(buffer, 0, buffer.Length);

                    if (bytesRec > 0)
                    {
                        ms.Write(buffer, 0, bytesRec);
                    }
                }
                while (bytesRec == buffer.Length);

                reply = Encoding.ASCII.GetString(ms.ToArray());
                ms.Close();
                reply = Regex.Match(reply, "<KeyData>([^<]*)</KeyData>", RegexOptions.IgnoreCase).Groups[1].Value;
                ms = new MemoryStream(Convert.FromBase64String(reply));
                br = new BinaryReader(ms);
                buffer = br.ReadBytes(br.ReadInt32());

                if (new BigInteger(buffer) == validate)
                {
                    var xor = new BNSXorEncryption(key);

                    packet = Builder("Auth", "LoginFinish");
                    buffer = Encoding.ASCII.GetBytes(packet);
                    buffer = xor.Encrypt(buffer, 0, buffer.Length);
                    ns.Write(buffer, 0, buffer.Length);

                    buffer = new byte[1024];
                    ms = new MemoryStream();
                    do
                    {
                        bytesRec = ns.Read(buffer, 0, buffer.Length);

                        if (bytesRec > 0)
                        {
                            ms.Write(buffer, 0, bytesRec);
                        }
                    }
                    while (bytesRec == buffer.Length);
                    buffer = ms.ToArray();
                    buffer = xor.Decrypt(buffer, 0, buffer.Length);
                    ms.Close();

                    buffer = new byte[1024];
                    ms = new MemoryStream();
                    try
                    {
                        do
                        {
                            bytesRec = ns.Read(buffer, 0, buffer.Length);

                            if (bytesRec > 0)
                            {
                                ms.Write(buffer, 0, bytesRec);
                            }
                        }
                        while (bytesRec == buffer.Length);
                    }
                    catch
                    {
                        Prompt.Popup("Please verify your new ip to NCSoft's website(whitelist via security settings) or NCSoft Launcher via pin confirmation.");
                        foreach (var process in Process.GetProcessesByName("Client"))
                        {
                            if (process.Id == appuniqueid)
                            {
                                process.Kill();
                                appuniqueid = 0;
                            }
                        }
                        if (customclientname != "")
                        {
                            string tmp = customclientname.Replace(".exe", "");
                            foreach (var process in Process.GetProcessesByName(tmp))
                            {
                                if (process.Id == appuniqueid)
                                {
                                    process.Kill();
                                    appuniqueid = 0;
                                }
                            }
                        }
                        metroButton1.Enabled = true;
                        // Stop useless countdown
                        countdown.Stop();
                        Show(); // Shows the program on taskbar
                        this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                        return;
                    }
                    buffer = ms.ToArray();
                    buffer = xor.Decrypt(buffer, 0, buffer.Length);
                    packet = Encoding.ASCII.GetString(buffer);

                    if (Debugging)
                        Prompt.Popup("Debug: 0" + packet.ToString());

                    if (packet.Contains("<AuthType>8</AuthType>"))
                    {
                        Prompt.Popup("This launcher doesn't support IP Verification, please do so on the website or official launcher then try again");
                        Show();
                        // Stop useless countdown
                        countdown.Stop();
                        metroButton1.Enabled = true;
                        this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                        return;
                    }
                    ms.Close();

                    packet = Builder("Auth", "RequestToken");
                    buffer = Encoding.ASCII.GetBytes(packet);
                    buffer = xor.Encrypt(buffer, 0, buffer.Length);
                    ns.Write(buffer, 0, buffer.Length);

                    buffer = new byte[1024];
                    ms = new MemoryStream();
                    do
                    {
                        bytesRec = ns.Read(buffer, 0, buffer.Length);

                        if (bytesRec > 0)
                        {
                            ms.Write(buffer, 0, bytesRec);
                        }
                    }
                    while (bytesRec == buffer.Length);
                    buffer = ms.ToArray();
                    buffer = xor.Decrypt(buffer, 0, buffer.Length);
                    if (Debugging)
                        Prompt.Popup(Encoding.ASCII.GetString(buffer));
                    ms.Close();

                    reply = Encoding.ASCII.GetString(buffer);
                    token = Regex.Match(reply, "<AuthnToken>([^<]*)</AuthnToken>", RegexOptions.IgnoreCase).Groups[1].Value;
                    Action<bool> update = login_enable;
                    Invoke(update, true);
                    // Stop useless countdown
                    countdown.Stop();
                }
                else
                {
                    Prompt.Popup("Negotiation Failed, please try again.");
                    key = null;
                }

                while (LoginServer.Connected)
                {
                    if (DateTime.Now >= lastSent.AddSeconds(pingInterval))
                    {
                        packet = Builder("Sts", "Ping");
                        buffer = Encoding.ASCII.GetBytes(packet);
                        if (key != null && buffer != null && xor != null)
                        {
                            buffer = xor.Encrypt(buffer, 0, buffer.Length);
                        }
                        ns.Write(buffer, 0, buffer.Length);
                        lastSent = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                if (GameStarted == false)
                {
                    if (Debugging)
                        Prompt.Popup(ex.ToString());
                }
            }
        }

        private void login_enable(bool yes)
        {
            AddTextLog("Login successful!");
            if (!metroLabel14.Text.Contains("Clean"))
            {
                RestoreConfigFiles();
            }
            // Return token
            string tmp = String.Format(args, token);
            FinalToken = tmp;
            AddTextLog("Starting Client!");
            Process proc = new Process();
            proc.StartInfo.FileName = LaunchPath;
            string temp = metroComboBox1.SelectedItem.ToString();
            if (temp == "North America" || temp == "Europe") // NA/EU
            {
                proc.StartInfo.Arguments = "-lang:" + languageID + " -lite:2 -region:" + regionID + " /AuthnToken:\"" + FinalToken + "\" /AuthProviderCode:\"np\" /sesskey /launchbylauncher  /CompanyID:12 /ChannelGroupIndex:-1 " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
            }
            else if (temp == "Korean") // KR
            {
                if (metroComboBox8.SelectedItem.ToString() == "Live")
                {
                    proc.StartInfo.Arguments = "/LaunchByLauncher /AuthnToken:" + FinalToken + " /SessKey:" + FinalToken + " /ServiceRegion:" + LoginId + " /AuthProviderCode:np /ServiceNetwork:live /NPServerAddr:" + LoginIp + ":" + LoginPort + " -lite:8 /PresenceId:BNS_KOR " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                }
                else
                {
                    proc.StartInfo.Arguments = "/LaunchByLauncher /AuthnToken:" + FinalToken + " /SessKey:" + FinalToken + " /ServiceRegion:" + LoginId + " /AuthProviderCode:np /ServiceNetwork:live /NPServerAddr:" + LoginIp + ":" + LoginPort + " -lite:8 /PresenceId:BNS_KOR_TEST " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                }
            }
            else if (temp == "Taiwan") // TW
            {
                proc.StartInfo.Arguments = "/LaunchByLauncher /SessKey:" + FinalToken + " /ServiceRegion:15 /ChannelGroupIndex:-1 /PresenceId:TWBNS22 " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
            }
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            bool gameworked = false;
            try
            {
                // Clean memory if true
                if (AutoClean == true)
                {
                    CleanMem();
                }
            }
            catch
            {
                AddTextBoxLog("Notice: Could not clear any memory!");
            }
            try
            {
                proc.Start();
                string tmpclientname = "Client.exe";
                if (customclientname != "")
                {
                    tmpclientname = customclientname;
                }
                AddTextLog("Started " + tmpclientname + "!");
                // Set the ID of the process
                appuniqueid = proc.Id;
                // Continue
                GameStarted = true;
                gameworked = true;
                // Add to Multi Client Lib if MultiClient is enabled in Extra
                if (metroToggle22.Checked == true)
                {
                    if (!ClientHandler.ContainsKey(username) || !metroComboBox9.Items.Contains(username))
                    {
                        if (!ClientHandler.ContainsValue(proc.Id))
                        {
                            ClientHandler.Add(username, proc.Id);
                            metroComboBox9.Items.Add(username);
                            metroComboBox9.SelectedIndex = metroComboBox9.FindStringExact(username);
                            metroPanel6.Visible = true;
                        }
                        else
                        {
                            AddTextBoxLog("Error: Somehow this process ID is already taken!");
                        }
                    }
                    else
                    {
                        AddTextBoxLog("Error: You can't login to an account that's already connected!");
                        proc.Kill();
                    }
                }
                // Resume
                this.WindowState = FormWindowState.Minimized;
            }
            catch
            {
                Show();
                notifyIcon1.Visible = false;
                metroButton1.Enabled = true;
                // Verify mod manager
                foreach (TreeNode nodes in treeView2.Nodes)
                {
                    if (nodes != null)
                    {
                        RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                        if (Directory.Exists(RealModPath))
                        {
                            checkButtons(true);
                        }
                        else
                        {
                            nodes.Remove();
                        }
                    }
                }
                //
                string tmpname = "Client.exe";
                if (customclientname != "")
                {
                    tmpname = customclientname;
                }
                AddTextLog("Error: Could Not Start " + tmpname + "!");
            }
            if (gameworked == true)
            {
                try
                {
                    AutoCleaner();
                }
                catch { AddTextLog("Error: Could not clean memory!"); }
            }
        }

        public byte[][] GenerateKeyClient(BigInteger exchangeKey)
        {
            byte[] passwordHash = sha.ComputeHash(Encoding.ASCII.GetBytes(username + ":" + password)); // ASCII

            BigInteger hash1 = SHA256Hash2ArrayInverse(this.GetKeyExchange().getBytes(), exchangeKey.getBytes());

            BigInteger hash2 = SHA256Hash2ArrayInverse(session.getBytes(), passwordHash);

            BigInteger v27 = new BigInteger(exchangeKey.getBytes());
            BigInteger v25 = Two.modPow(hash2, N);
            v25 = (v25 * P) % N;
            while (v27 < v25)
                v27 += N;
            v27 -= v25;

            BigInteger v24 = ((hash1 * hash2) + privateKey) % N;
            BigInteger v21 = v27.modPow(v24, N);

            key = GenerateEncryptionKeyRoot(v21.getBytes());
            byte[] chash1 = sha.ComputeHash(CombineBuffers(staticKey, sha.ComputeHash(Encoding.ASCII.GetBytes(username)), session.getBytes(), this.GetKeyExchange().getBytes(), exchangeKey.getBytes(), key));
            byte[] chash2 = sha.ComputeHash(CombineBuffers(this.GetKeyExchange().getBytes(), chash1, key));
            key = Generate256BytesKey(key);

            return new byte[][] { chash1, chash2 };
        }
    }
}

///////////////////////////////////////////////////////////////////////////////////////////////
// Seperator!     ||     Dat Decrypter/Encrypter
///////////////////////////////////////////////////////////////////////////////////////////////

namespace BNSDat
{
    internal enum BXML_TYPE
    {
        BXML_PLAIN,
        BXML_BINARY,
        BXML_UNKNOWN
    };

    internal class BPKG_FTE
    {
        public int FilePathLength;
        public string FilePath;
        public byte Unknown_001;
        public bool IsCompressed;
        public bool IsEncrypted;
        public byte Unknown_002;
        public int FileDataSizeUnpacked;
        public int FileDataSizeSheared; // without padding for AES
        public int FileDataSizeStored;
        public int FileDataOffset; // (relative) offset
        public byte[] Padding;
    }

    public class BNSDat
    {
        public string AES_KEY = "bns_obt_kr_2014#"; // bns_fgt_cb_2010!  bns_obt_kr_2014#  *PlayBNS(c)2014*   Comment all Xor Functions For OLD CBT2

        public byte[] XOR_KEY = new byte[16] { 164, 159, 216, 179, 246, 142, 57, 194, 45, 224, 97, 117, 92, 75, 26, 7 };

        private byte[] Decrypt(byte[] buffer, int size)
        {
            // AES requires buffer to consist of blocks with 16 bytes (each)
            // expand last block by padding zeros if required...
            // -> the encrypted data in BnS seems already to be aligned to blocks
            int AES_BLOCK_SIZE = AES_KEY.Length;
            int sizePadded = size + AES_BLOCK_SIZE;
            byte[] output = new byte[sizePadded];
            byte[] tmp = new byte[sizePadded];
            buffer.CopyTo(tmp, 0);
            buffer = null;

            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            ICryptoTransform decrypt = aes.CreateDecryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]);
            decrypt.TransformBlock(tmp, 0, sizePadded, output, 0);
            tmp = output;
            output = new byte[size];
            Array.Copy(tmp, 0, output, 0, size);
            tmp = null;

            return output;
        }

        private byte[] Deflate(byte[] buffer, int sizeCompressed, int sizeDecompressed)
        {
            byte[] tmp = Ionic.Zlib.ZlibStream.UncompressBuffer(buffer);

            if (tmp.Length != sizeDecompressed)
            {
                byte[] tmp2 = new byte[sizeDecompressed];

                if (tmp.Length > sizeDecompressed)
                    Array.Copy(tmp, 0, tmp2, 0, sizeDecompressed);
                else
                    Array.Copy(tmp, 0, tmp2, 0, tmp.Length);
                tmp = tmp2;
                tmp2 = null;
            }
            return tmp;
        }

        private byte[] Unpack(byte[] buffer, int sizeStored, int sizeSheared, int sizeUnpacked, bool isEncrypted, bool isCompressed)
        {
            byte[] output = buffer;

            if (isEncrypted)
            {
                output = Decrypt(output, sizeStored);
            }

            if (isCompressed)
            {
                output = Deflate(output, sizeSheared, sizeUnpacked);
            }

            // neither encrypted, nor compressed -> raw copy
            if (output == buffer)
            {
                output = new byte[sizeUnpacked];
                if (sizeSheared < sizeUnpacked)
                {
                    Array.Copy(buffer, 0, output, 0, sizeSheared);
                }
                else
                {
                    Array.Copy(buffer, 0, output, 0, sizeUnpacked);
                }
            }

            return output;
        }

        private byte[] Inflate(byte[] buffer, int sizeDecompressed, out int sizeCompressed, int compressionLevel)
        {
            MemoryStream output = new MemoryStream();
            Ionic.Zlib.ZlibStream zs = new Ionic.Zlib.ZlibStream(output, Ionic.Zlib.CompressionMode.Compress, (Ionic.Zlib.CompressionLevel)compressionLevel, true);
            zs.Write(buffer, 0, sizeDecompressed);
            zs.Flush();
            zs.Close();
            sizeCompressed = (int)output.Length;
            return output.ToArray();
        }

        private byte[] Encrypt(byte[] buffer, int size, out int sizePadded)
        {
            int AES_BLOCK_SIZE = AES_KEY.Length;
            sizePadded = size + (AES_BLOCK_SIZE - (size % AES_BLOCK_SIZE));
            byte[] output = new byte[sizePadded];
            byte[] temp = new byte[sizePadded];
            Array.Copy(buffer, 0, temp, 0, buffer.Length);
            buffer = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;

            ICryptoTransform encrypt = aes.CreateEncryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]);
            encrypt.TransformBlock(temp, 0, sizePadded, output, 0);
            temp = null;
            return output;
        }

        private byte[] Pack(byte[] buffer, int sizeUnpacked, out int sizeSheared, out int sizeStored, bool encrypt, bool compress, int compressionLevel)
        {
            byte[] output = buffer;
            buffer = null;
            sizeSheared = sizeUnpacked;
            sizeStored = sizeSheared;

            if (compress)
            {
                byte[] tmp = Inflate(output, sizeUnpacked, out sizeSheared, compressionLevel);
                sizeStored = sizeSheared;
                output = tmp;
                tmp = null;
            }

            if (encrypt)
            {
                byte[] tmp = Encrypt(output, sizeSheared, out sizeStored);
                output = tmp;
                tmp = null;
            }
            return output;
        }

        public void Extract(string FileName, bool is64 = false)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            string file_path;
            byte[] buffer_packed;
            byte[] buffer_unpacked;

            byte[] Signature = br.ReadBytes(8);
            uint Version = br.ReadUInt32();

            byte[] Unknown_001 = br.ReadBytes(5);
            int FileDataSizePacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            int FileCount = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            bool IsCompressed = br.ReadByte() == 1;
            bool IsEncrypted = br.ReadByte() == 1;
            byte[] Unknown_002 = br.ReadBytes(62);
            int FileTableSizePacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            int FileTableSizeUnpacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();

            buffer_packed = br.ReadBytes(FileTableSizePacked);
            int OffsetGlobal = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            OffsetGlobal = (int)br.BaseStream.Position; // don't trust value, read current stream location.

            byte[] FileTableUnpacked = Unpack(buffer_packed, FileTableSizePacked, FileTableSizePacked, FileTableSizeUnpacked, IsEncrypted, IsCompressed);
            buffer_packed = null;
            MemoryStream ms = new MemoryStream(FileTableUnpacked);
            BinaryReader br2 = new BinaryReader(ms);

            for (int i = 0; i < FileCount; i++)
            {
                BPKG_FTE FileTableEntry = new BPKG_FTE();
                FileTableEntry.FilePathLength = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                FileTableEntry.FilePath = Encoding.Unicode.GetString(br2.ReadBytes(FileTableEntry.FilePathLength * 2));
                FileTableEntry.Unknown_001 = br2.ReadByte();
                FileTableEntry.IsCompressed = br2.ReadByte() == 1;
                FileTableEntry.IsEncrypted = br2.ReadByte() == 1;
                FileTableEntry.Unknown_002 = br2.ReadByte();
                FileTableEntry.FileDataSizeUnpacked = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                FileTableEntry.FileDataSizeSheared = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                FileTableEntry.FileDataSizeStored = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                FileTableEntry.FileDataOffset = (is64 ? (int)br2.ReadInt64() : br2.ReadInt32()) + OffsetGlobal;
                FileTableEntry.Padding = br2.ReadBytes(60);

                file_path = String.Format("{0}.files\\{1}", FileName, FileTableEntry.FilePath);
                if (!Directory.Exists((new FileInfo(file_path)).DirectoryName))
                    Directory.CreateDirectory((new FileInfo(file_path)).DirectoryName);

                br.BaseStream.Position = FileTableEntry.FileDataOffset;
                buffer_packed = br.ReadBytes(FileTableEntry.FileDataSizeStored);
                buffer_unpacked = Unpack(buffer_packed, FileTableEntry.FileDataSizeStored, FileTableEntry.FileDataSizeSheared, FileTableEntry.FileDataSizeUnpacked, FileTableEntry.IsEncrypted, FileTableEntry.IsCompressed);
                buffer_packed = null;
                FileTableEntry = null;

                if (file_path.EndsWith("xml") || file_path.EndsWith("x16"))
                {
                    // decode bxml
                    MemoryStream temp = new MemoryStream();
                    MemoryStream temp2 = new MemoryStream(buffer_unpacked);
                    BXML bns_xml = new BXML(XOR_KEY);
                    Convert(temp2, bns_xml.DetectType(temp2), temp, BXML_TYPE.BXML_PLAIN);
                    temp2.Close();
                    File.WriteAllBytes(file_path, temp.ToArray());
                    temp.Close();
                    buffer_unpacked = null;
                }
                else
                {
                    // extract raw
                    File.WriteAllBytes(file_path, buffer_unpacked);
                    buffer_unpacked = null;
                }

                // Report progress
                string whattosend = "Extracting: " + i.ToString() + "/" + FileCount.ToString();
                Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler(whattosend);
                // End report progress
            }

            // Report job done
            Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler("Done!");
            // End report

            br2.Close();
            ms.Close();
            br2 = null;
            ms = null;
            br.Close();
            fs.Close();
            br = null;
            fs = null;
        }

        public void Compress(string Folder, bool is64 = false, int compression = 9)
        {
            string file_path;
            byte[] buffer_packed;
            byte[] buffer_unpacked;

            string[] files = Directory.EnumerateFiles(Folder, "*", SearchOption.AllDirectories).ToArray();

            int FileCount = files.Count();

            BPKG_FTE FileTableEntry = new BPKG_FTE();
            MemoryStream mosTablems = new MemoryStream();
            BinaryWriter mosTable = new BinaryWriter(mosTablems);
            MemoryStream mosFilesms = new MemoryStream();
            BinaryWriter mosFiles = new BinaryWriter(mosFilesms);

            for (int i = 0; i < FileCount; i++)
            {
                file_path = files[i].Replace(Folder, "").TrimStart('\\');
                FileTableEntry.FilePathLength = file_path.Length;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FilePathLength);
                else
                    mosTable.Write(FileTableEntry.FilePathLength);

                FileTableEntry.FilePath = file_path;
                mosTable.Write(Encoding.Unicode.GetBytes(FileTableEntry.FilePath));
                FileTableEntry.Unknown_001 = 2;
                mosTable.Write(FileTableEntry.Unknown_001);
                FileTableEntry.IsCompressed = true;
                mosTable.Write(FileTableEntry.IsCompressed);
                FileTableEntry.IsEncrypted = true;
                mosTable.Write(FileTableEntry.IsEncrypted);
                FileTableEntry.Unknown_002 = 0;
                mosTable.Write(FileTableEntry.Unknown_002);

                FileStream fis = new FileStream(files[i], FileMode.Open);
                MemoryStream tmp = new MemoryStream();

                if (file_path.EndsWith(".xml") || file_path.EndsWith(".x16"))
                {
                    // encode bxml
                    BXML bxml = new BXML(XOR_KEY);
                    Convert(fis, bxml.DetectType(fis), tmp, BXML_TYPE.BXML_BINARY);
                }
                else
                {
                    // compress raw
                    fis.CopyTo(tmp);
                }
                fis.Close();
                fis = null;

                FileTableEntry.FileDataOffset = (int)mosFiles.BaseStream.Position;
                FileTableEntry.FileDataSizeUnpacked = (int)tmp.Length;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeUnpacked);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeUnpacked);

                buffer_unpacked = tmp.ToArray();
                tmp.Close();
                tmp = null;
                buffer_packed = Pack(buffer_unpacked, FileTableEntry.FileDataSizeUnpacked, out FileTableEntry.FileDataSizeSheared, out FileTableEntry.FileDataSizeStored, FileTableEntry.IsEncrypted, FileTableEntry.IsCompressed, compression);
                buffer_unpacked = null;
                mosFiles.Write(buffer_packed);
                buffer_packed = null;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeSheared);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeSheared);

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeStored);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeStored);

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataOffset);
                else
                    mosTable.Write(FileTableEntry.FileDataOffset);

                FileTableEntry.Padding = new byte[60];
                mosTable.Write(FileTableEntry.Padding);

                // Report progress
                string whattosend = "Compiling: " + i.ToString() + "/" + FileCount.ToString();
                Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler(whattosend);
                // End report progress
            }

            // Report job done
            Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler("Packing!");
            // End report

            MemoryStream output = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(output);
            byte[] Signature = new byte[8] { (byte)'U', (byte)'O', (byte)'S', (byte)'E', (byte)'D', (byte)'A', (byte)'L', (byte)'B' };
            bw.Write(Signature);
            int Version = 2;
            bw.Write(Version);
            byte[] Unknown_001 = new byte[5] { 0, 0, 0, 0, 0 };
            bw.Write(Unknown_001);
            int FileDataSizePacked = (int)mosFiles.BaseStream.Length;

            if (is64)
            {
                bw.Write((long)FileDataSizePacked);
                bw.Write((long)FileCount);
            }
            else
            {
                bw.Write(FileDataSizePacked);
                bw.Write(FileCount);
            }

            bool IsCompressed = true;
            bw.Write(IsCompressed);
            bool IsEncrypted = true;
            bw.Write(IsEncrypted);
            byte[] Unknown_002 = new byte[62];
            bw.Write(Unknown_002);

            int FileTableSizeUnpacked = (int)mosTable.BaseStream.Length;
            int FileTableSizeSheared = FileTableSizeUnpacked;
            int FileTableSizePacked = FileTableSizeUnpacked;
            buffer_unpacked = mosTablems.ToArray();
            mosTable.Close();
            mosTablems.Close();
            mosTable = null;
            mosTablems = null;
            buffer_packed = Pack(buffer_unpacked, FileTableSizeUnpacked, out FileTableSizeSheared, out FileTableSizePacked, IsEncrypted, IsCompressed, compression);
            buffer_unpacked = null;

            if (is64)
                bw.Write((long)FileTableSizePacked);
            else
                bw.Write(FileTableSizePacked);

            if (is64)
                bw.Write((long)FileTableSizeUnpacked);
            else
                bw.Write(FileTableSizeUnpacked);

            bw.Write(buffer_packed);
            buffer_packed = null;

            int OffsetGlobal = (int)output.Position + (is64 ? 8 : 4);

            if (is64)
                bw.Write((long)OffsetGlobal);
            else
                bw.Write(OffsetGlobal);

            buffer_packed = mosFilesms.ToArray();
            mosFiles.Close();
            mosFilesms.Close();
            mosFiles = null;
            mosFilesms = null;
            bw.Write(buffer_packed);
            buffer_packed = null;
            File.WriteAllBytes(Folder.Replace(".files", ""), output.ToArray());
            bw.Close();
            output.Close();
            bw = null;
            output = null;

            // Report job done
            Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler("Done!");
            // End report
        }

        private void Convert(Stream iStream, BXML_TYPE iType, Stream oStream, BXML_TYPE oType)
        {
            if ((iType == BXML_TYPE.BXML_PLAIN && oType == BXML_TYPE.BXML_BINARY) || (iType == BXML_TYPE.BXML_BINARY && oType == BXML_TYPE.BXML_PLAIN))
            {
                BXML bns_xml = new BXML(XOR_KEY);
                bns_xml.Load(iStream, iType);
                bns_xml.Save(oStream, oType);
            }
            else
            {
                iStream.CopyTo(oStream);
            }
        }
    }

    internal class BXML_CONTENT
    {
        public byte[] XOR_KEY;

        private void Xor(byte[] buffer, int size)
        {
            for (int i = 0; i < size; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ XOR_KEY[i % XOR_KEY.Length]);
            }
        }

        private bool Keep_XML_WhiteSpace = true;

        public void Read(Stream iStream, BXML_TYPE iType)
        {
            if (iType == BXML_TYPE.BXML_PLAIN)
            {
                Signature = new byte[8] { (byte)'L', (byte)'M', (byte)'X', (byte)'B', (byte)'O', (byte)'S', (byte)'L', (byte)'B' };
                Version = 3;
                FileSize = 85;
                Padding = new byte[64];
                Unknown = true;
                OriginalPathLength = 0;

                // NOTE: keep whitespace text nodes (to be compliant with the whitespace TEXT_NODES in bns xml)
                // no we don't keep them, we remove them because it is cleaner
                Nodes.PreserveWhitespace = Keep_XML_WhiteSpace;
                Nodes.Load(iStream);

                // get original path from first comment node
                XmlNode node = Nodes.DocumentElement.ChildNodes.OfType<XmlComment>().First();
                if (node != null && node.NodeType == XmlNodeType.Comment)
                {
                    string Text = node.InnerText;
                    OriginalPathLength = Text.Length;
                    OriginalPath = Encoding.Unicode.GetBytes(Text);
                    Xor(OriginalPath, 2 * OriginalPathLength);
                    if (Nodes.PreserveWhitespace && node.NextSibling.NodeType == XmlNodeType.Whitespace)
                        Nodes.DocumentElement.RemoveChild(node.NextSibling);
                }
                else
                {
                    OriginalPath = new byte[2 * OriginalPathLength];
                }
            }

            if (iType == BXML_TYPE.BXML_BINARY)
            {
                Signature = new byte[8];
                BinaryReader br = new BinaryReader(iStream);
                br.BaseStream.Position = 0;
                Signature = br.ReadBytes(8);
                Version = br.ReadInt32();
                FileSize = br.ReadInt32();
                Padding = br.ReadBytes(64);
                Unknown = br.ReadByte() == 1;
                OriginalPathLength = br.ReadInt32();
                OriginalPath = br.ReadBytes(2 * OriginalPathLength);
                AutoID = 1;
                ReadNode(iStream);

                // add original path as first comment node
                byte[] Path = OriginalPath;
                Xor(Path, 2 * OriginalPathLength);
                XmlComment node = Nodes.CreateComment(Encoding.Unicode.GetString(Path));
                Nodes.DocumentElement.PrependChild(node);
                XmlNode docNode = Nodes.CreateXmlDeclaration("1.0", "utf-8", null);
                Nodes.PrependChild(docNode);
                if (FileSize != iStream.Position)
                {
                    throw new Exception(String.Format("Filesize Mismatch, expected size was {0} while actual size was {1}.", FileSize, iStream.Position));
                }
            }
        }

        public void Write(Stream oStream, BXML_TYPE oType)
        {
            if (oType == BXML_TYPE.BXML_PLAIN)
            {
                Nodes.Save(oStream);
            }
            if (oType == BXML_TYPE.BXML_BINARY)
            {
                BinaryWriter bw = new BinaryWriter(oStream);
                bw.Write(Signature);
                bw.Write(Version);
                bw.Write(FileSize);
                bw.Write(Padding);
                bw.Write(Unknown);
                bw.Write(OriginalPathLength);
                bw.Write(OriginalPath);

                AutoID = 1;
                WriteNode(oStream);

                FileSize = (int)oStream.Position;
                oStream.Position = 12;
                bw.Write(FileSize);
            }
        }

        private void ReadNode(Stream iStream, XmlNode parent = null)
        {
            XmlNode node = null;
            BinaryReader br = new BinaryReader(iStream);
            int Type = 1;
            if (parent != null)
            {
                Type = br.ReadInt32();
            }

            if (Type == 1)
            {
                node = Nodes.CreateElement("Text");

                int ParameterCount = br.ReadInt32();
                for (int i = 0; i < ParameterCount; i++)
                {
                    int NameLength = br.ReadInt32();
                    byte[] Name = br.ReadBytes(2 * NameLength);
                    Xor(Name, 2 * NameLength);

                    int ValueLength = br.ReadInt32();
                    byte[] Value = br.ReadBytes(2 * ValueLength);
                    Xor(Value, 2 * ValueLength);

                    ((XmlElement)node).SetAttribute(Encoding.Unicode.GetString(Name), Encoding.Unicode.GetString(Value));
                }
            }

            if (Type == 2)
            {
                node = Nodes.CreateTextNode("");

                int TextLength = br.ReadInt32();
                byte[] Text = br.ReadBytes(TextLength * 2);
                Xor(Text, 2 * TextLength);

                ((XmlText)node).Value = Encoding.Unicode.GetString(Text);
            }

            if (Type > 2)
            {
                throw new Exception("Unknown XML Node Type");
            }

            bool Closed = br.ReadByte() == 1;
            int TagLength = br.ReadInt32();
            byte[] Tag = br.ReadBytes(2 * TagLength);
            Xor(Tag, 2 * TagLength);
            if (Type == 1)
            {
                node = RenameNode(node, Encoding.Unicode.GetString(Tag));
            }

            int ChildCount = br.ReadInt32();
            AutoID = br.ReadInt32();
            AutoID++;

            for (int i = 0; i < ChildCount; i++)
            {
                ReadNode(iStream, node);
            }

            if (parent != null)
            {
                if (Keep_XML_WhiteSpace || Type != 2 || !String.IsNullOrWhiteSpace(node.Value))
                {
                    parent.AppendChild(node);
                }
            }
            else
            {
                Nodes.AppendChild(node);
            }
        }

        public static XmlNode RenameNode(XmlNode node, string Name)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                XmlElement oldElement = (XmlElement)node;
                XmlElement newElement =
                node.OwnerDocument.CreateElement(Name);

                while (oldElement.HasAttributes)
                {
                    newElement.SetAttributeNode(oldElement.RemoveAttributeNode(oldElement.Attributes[0]));
                }

                while (oldElement.HasChildNodes)
                {
                    newElement.AppendChild(oldElement.FirstChild);
                }

                if (oldElement.ParentNode != null)
                {
                    oldElement.ParentNode.ReplaceChild(newElement, oldElement);
                }

                return newElement;
            }
            else
                return node;
        }

        private bool WriteNode(Stream oStream, XmlNode parent = null)
        {
            BinaryWriter bw = new BinaryWriter(oStream);
            XmlNode node = null;

            int Type = 1;
            if (parent != null)
            {
                node = parent;
                if (node.NodeType == XmlNodeType.Element)
                {
                    Type = 1;
                }
                if (node.NodeType == XmlNodeType.Text || node.NodeType == XmlNodeType.Whitespace)
                {
                    Type = 2;
                }
                if (node.NodeType == XmlNodeType.Comment)
                {
                    return false;
                }
                bw.Write(Type);
            }
            else
            {
                node = Nodes.DocumentElement;
            }

            if (Type == 1)
            {
                int OffsetAttributeCount = (int)oStream.Position;
                int AttributeCount = 0;
                bw.Write(AttributeCount);

                foreach (XmlAttribute attribute in node.Attributes)
                {
                    string Name = attribute.Name;
                    int NameLength = Name.Length;
                    bw.Write(NameLength);
                    byte[] NameBuffer = Encoding.Unicode.GetBytes(Name);
                    Xor(NameBuffer, 2 * NameLength);
                    bw.Write(NameBuffer);

                    String Value = attribute.Value;
                    int ValueLength = Value.Length;
                    bw.Write(ValueLength);
                    byte[] ValueBuffer = Encoding.Unicode.GetBytes(Value);
                    Xor(ValueBuffer, 2 * ValueLength);
                    bw.Write(ValueBuffer);
                    AttributeCount++;
                }

                int OffsetCurrent = (int)oStream.Position;
                oStream.Position = OffsetAttributeCount;
                bw.Write(AttributeCount);
                oStream.Position = OffsetCurrent;
            }

            if (Type == 2)
            {
                string Text = node.Value;
                int TextLength = Text.Length;
                bw.Write(TextLength);
                byte[] TextBuffer = Encoding.Unicode.GetBytes(Text);
                Xor(TextBuffer, 2 * TextLength);
                bw.Write(TextBuffer);
            }

            if (Type > 2)
            {
                throw new Exception(String.Format("ERROR: XML NODE TYPE [{0}] UNKNOWN", node.NodeType.ToString()));
            }

            bool Closed = true;
            bw.Write(Closed);
            string Tag = node.Name;
            int TagLength = Tag.Length;
            bw.Write(TagLength);
            byte[] TagBuffer = Encoding.Unicode.GetBytes(Tag);
            Xor(TagBuffer, 2 * TagLength);
            bw.Write(TagBuffer);

            int OffsetChildCount = (int)oStream.Position;
            int ChildCount = 0;
            bw.Write(ChildCount);
            bw.Write(AutoID);
            AutoID++;

            foreach (XmlNode child in node.ChildNodes)
            {
                if (WriteNode(oStream, child))
                {
                    ChildCount++;
                }
            }

            int OffsetCurrent2 = (int)oStream.Position;
            oStream.Position = OffsetChildCount;
            bw.Write(ChildCount);
            oStream.Position = OffsetCurrent2;
            return true;
        }

        private byte[] Signature;                  // 8 byte
        private int Version;                   // 4 byte
        private int FileSize;                  // 4 byte
        private byte[] Padding;                    // 64 byte
        private bool Unknown;                       // 1 byte

        // TODO: add to CDATA ?
        private int OriginalPathLength;        // 4 byte

        private byte[] OriginalPath;               // 2*OriginalPathLength bytes

        private int AutoID;
        private XmlDocument Nodes = new XmlDocument();
    }

    internal class BXML
    {
        private BXML_CONTENT _content = new BXML_CONTENT();

        private byte[] XOR_KEY { get { return _content.XOR_KEY; } set { _content.XOR_KEY = value; } }

        public BXML(byte[] xor)
        {
            XOR_KEY = xor;
        }

        public void Load(Stream iStream, BXML_TYPE iType)
        {
            _content.Read(iStream, iType);
        }

        public void Save(Stream oStream, BXML_TYPE oType)
        {
            _content.Write(oStream, oType);
        }

        public BXML_TYPE DetectType(Stream iStream)
        {
            int offset = (int)iStream.Position;
            iStream.Position = 0;
            byte[] Signature = new byte[13];
            iStream.Read(Signature, 0, 13);
            iStream.Position = offset;

            BXML_TYPE result = BXML_TYPE.BXML_UNKNOWN;

            if (
                BitConverter.ToString(Signature).Replace("-", "").Replace("00", "").Contains(BitConverter.ToString(new byte[] { (byte)'<', (byte)'?', (byte)'x', (byte)'m', (byte)'l' }).Replace("-", ""))
            )
            {
                result = BXML_TYPE.BXML_PLAIN;
            }

            if (
                Signature[7] == 'B' &&
                Signature[6] == 'L' &&
                Signature[5] == 'S' &&
                Signature[4] == 'O' &&
                Signature[3] == 'B' &&
                Signature[2] == 'X' &&
                Signature[1] == 'M' &&
                Signature[0] == 'L'
            )
            {
                result = BXML_TYPE.BXML_BINARY;
            }

            return result;
        }
    }
}