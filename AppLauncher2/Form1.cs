using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace AppLauncher2
{
    public partial class frmMain : Form
    {
        XmlDocument settingsxml = new XmlDocument();
        XmlNodeList appinfonodes = null;
        int currnode = 0;
        string[] args = new string[Environment.GetCommandLineArgs().Length];
        bool dodebug = false;
        bool autostart = false;
        System.IO.StreamWriter swDebug = null;

        private void ReadSettings()
        {
            try
            {
                if (dodebug) swDebug.WriteLine("ReadSettings: Opening settings.xml");
                settingsxml.Load("settings.xml");
                if (dodebug) swDebug.WriteLine("ReadSettings: Reading appinfo nodes");
                appinfonodes = settingsxml.GetElementsByTagName("appinfo");
                if (dodebug) swDebug.WriteLine("ReadSettings: Checking how many nodes there are");
                if (appinfonodes.Count > 0)
                {
                    if (dodebug) swDebug.WriteLine("ReadSettings: Enabling start button");
                    btnStart.Enabled = true;
                    if (dodebug) swDebug.WriteLine("ReadSettings: Setting pbProgress.Maximum to " + appinfonodes.Count.ToString());
                    pbProgress.Maximum = appinfonodes.Count;
                }
                else
                {
                    if (dodebug) swDebug.WriteLine("ReadSettings: Disabling start button");
                    btnStart.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                if (dodebug) swDebug.WriteLine("ReadSettings: An error has occurred while loading settings.xml. " + ex.Message);
                MessageBox.Show("An error has occurred while loading the document.\nError: " + ex.Message);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "/debug":
                        {
                            dodebug = true;
                            swDebug = new System.IO.StreamWriter("aldebug.log", true);
                            swDebug.WriteLine("Debugging started at " + DateTime.Now.ToString());
                        }
                        break;
                    case "/d":
                        {
                            dodebug = true;
                            swDebug = new System.IO.StreamWriter("aldebug.log", true);
                            swDebug.WriteLine("Debugging started at " + DateTime.Now.ToString());
                        }
                        break;
                    case "/autostart":
                        {
                            autostart = true;
                        }
                        break;
                    case "/a":
                        {
                            autostart = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (dodebug) swDebug.WriteLine("frmMain_Load: Execute function ReadSettings()");
            ReadSettings();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (dodebug)
            {
                swDebug.WriteLine("btnExit_Click: Exiting Application");
                swDebug.WriteLine("Debugging stopped at " + DateTime.Now.ToString() + "\n");
                swDebug.Close();
                swDebug = null;
            }
            Application.Exit();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("btnOptions_Click: Loading frmOptions");
            if (dodebug) swDebug.Close();
            frmOptions frmo = new frmOptions(settingsxml, dodebug);
            frmo.ShowDialog(this);
            if (dodebug) swDebug = new System.IO.StreamWriter("aldebug.log", true);
            if (dodebug) swDebug.WriteLine("btnOptions_Click: Executing function ReadSettings()");
            ReadSettings();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("btnStart_Click: Checking btnStart.Text");
            if (btnStart.Text == "&Start")
            {
                if (dodebug) swDebug.WriteLine("btnStart_Click: btnStart.Text = &Start");
                if (dodebug) swDebug.WriteLine("btnStart_Click: Setting pbProgress.Value back to 0");
                pbProgress.Value = 0;
                if (dodebug) swDebug.WriteLine("btnStart_Click: Setting tmrStart.Interval back to 1");
                tmrStart.Interval = 1;
                if (dodebug) swDebug.WriteLine("btnStart_Click: Setting currnode to 0");
                currnode = 0;
                if (dodebug) swDebug.WriteLine("btnStart_Click: Enabling tmrStart");
                tmrStart.Enabled = true;
                if (dodebug) swDebug.WriteLine("btnStart_Click: Setting btnStart.Text to &Stop");
                btnStart.Text = "&Stop";
            }
            else
            {
                if (dodebug) swDebug.WriteLine("btnStart_Click: btnStart.Text = " + btnStart.Text);
                if (dodebug) swDebug.WriteLine("btnStart_Click: Disabling tmrStart");
                tmrStart.Enabled = false;
                if (dodebug) swDebug.WriteLine("btnStart_Click: Setting btnStart.Text to &Start");
                btnStart.Text = "&Start";
            }
        }

        private void tmrStart_Tick(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("tmrStart_Tick: Timer tick");
            if (dodebug) swDebug.WriteLine("tmrStart_Tick: Initialize psiApp");
            ProcessStartInfo psiApp = new ProcessStartInfo();

            try
            {
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Set psiApp.FileName to " + "\"" + appinfonodes[currnode].ChildNodes[0].InnerText + "\"");
                psiApp.FileName = "\"" + appinfonodes[currnode].ChildNodes[0].InnerText + "\"";
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Check for command line arguments");
                if (appinfonodes[currnode].ChildNodes[1].InnerText != "")
                {
                    if (dodebug) swDebug.WriteLine("tmrStart_Tick: Set psiApp.Arguments to " + "\"" + appinfonodes[currnode].ChildNodes[1].InnerText + "\"");
                    psiApp.Arguments = "\"" + appinfonodes[currnode].ChildNodes[1].InnerText + "\"";
                }
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Checking for a Working Directory path");
                if (appinfonodes[currnode].ChildNodes[2].InnerText != "")
                {
                    if (dodebug) swDebug.WriteLine("tmrStart_Tick: Setting psiApp.WorkingDirectory to " + "\"" + appinfonodes[currnode].ChildNodes[2].InnerText + "\"");
                    psiApp.WorkingDirectory = "\"" + appinfonodes[currnode].ChildNodes[2].InnerText + "\"";
                }
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Setting tmrStart.Interval to " + appinfonodes[currnode].ChildNodes[3].InnerText + " * 1000");
                tmrStart.Interval = Convert.ToInt32(appinfonodes[currnode].ChildNodes[3].InnerText) * 1000;
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Checking if Start Minizmized = true");
                if (appinfonodes[currnode].ChildNodes[4].InnerText == "True")
                {
                    if (dodebug) swDebug.WriteLine("tmrStart_Tick: Start Minimized = true");
                    if (dodebug) swDebug.WriteLine("tmrStart_Tick: Setting psiApp.WindowStyle to ProcessWindowStyle.Minimized");
                    psiApp.WindowStyle = ProcessWindowStyle.Minimized;
                }
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Creating and starting psApp process");
                Process psApp = Process.Start(psiApp);
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Setting psApp.WaitForExit to 0");
                psApp.WaitForExit(0);
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Increment pbProgress by 1 step");
                pbProgress.PerformStep();
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Incrementing currnode by 1");
                currnode++;
            }
            catch (Exception ex)
            {
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Increment pbProgress by 1 step");
                pbProgress.PerformStep();
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Incrementing currnode by 1");
                currnode++;
                String sErrorMessage = "Error launching requested application.\nError: " + ex.Message + "\nDetail: " + ex.InnerException + "\nFile: " + psiApp.FileName;
                MessageBox.Show(sErrorMessage, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dodebug) swDebug.WriteLine("tmrStart_Tick: Checking if currnode >= appinfonodes.Count");
            if (currnode >= appinfonodes.Count)
            {
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: currnode >= appinfonodes.Count");
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Disabling tmrStart");
                tmrStart.Enabled = false;
                if (dodebug) swDebug.WriteLine("tmrStart_Tick: Setting btnStart.Text to &Start");
                btnStart.Text = "&Start";
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dodebug) if (swDebug != null) swDebug.WriteLine("frmMain_FormClosed: Exiting Application");
            if (dodebug) if (swDebug != null) swDebug.WriteLine("Debugging stopped at " + DateTime.Now.ToString() + "\n");
            if (dodebug) if (swDebug != null) swDebug.Close();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (autostart)
            {
                btnStart.PerformClick();
            }
        }
    }
}
