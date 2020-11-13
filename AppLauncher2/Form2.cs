using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AppLauncher2
{
    public partial class frmOptions : Form
    {
        XmlDocument settingsxml = new XmlDocument();
        XmlNodeList appinfonodes = null;
        bool dodebug = false;
        StreamWriter swDebug = null;

        private void ReadInfo()
        {
            if (dodebug) swDebug.WriteLine("  ReadInfo: Setting nodecount to 0");
            int nodecount = 0;
            if (dodebug) swDebug.WriteLine("  ReadInfo: Looping through appinfonodes");
            for (int i = 0; i < appinfonodes.Count; i++)
            {
                if (dodebug) swDebug.WriteLine("  ReadInfo: Setting xmlattr to appinfonodes[1].Attributes");
                XmlAttributeCollection xmlattr = appinfonodes[i].Attributes;
                if (dodebug) swDebug.WriteLine("  ReadInfo: Adding parrent node containing Name value to treeview");
                tvAppList.Nodes.Add(xmlattr[0].Value);
                if (dodebug) swDebug.WriteLine("  ReadInfo: Loop through child nodes");
                for (int x = 0; x < appinfonodes[i].ChildNodes.Count; x++)
                {
                    if (dodebug) swDebug.WriteLine("  ReadInfo: Add child node" + appinfonodes[i].ChildNodes[x].Value + " to treeview");
                    tvAppList.Nodes[nodecount].Nodes.Add(appinfonodes[i].ChildNodes[x].InnerText);
                }
                if (dodebug) swDebug.WriteLine("  ReadInfo: Incrementing nodecount by 1");
                nodecount++;
            }
            if (dodebug) swDebug.WriteLine("  ReadInfo: Auto expanding all nodes in treeview");
            tvAppList.ExpandAll();
        }

        private void SaveInfo()
        {
            if (dodebug) swDebug.WriteLine("  SaveInfo: Opening settings.xml");
            StreamWriter sw = new StreamWriter("settings.xml", false, System.Text.Encoding.UTF8);
            if (dodebug) swDebug.WriteLine("  SaveInfo: Writing xml doc header");
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            if (dodebug) swDebug.WriteLine("  SaveInfo: Writing <applications> start tag");
            sw.WriteLine("<applications>");
            if (dodebug) swDebug.WriteLine("  SaveInfo: Looping through treeview nodes");
            for (int i = 0; i < tvAppList.Nodes.Count; i++)
            {
                if (dodebug) swDebug.WriteLine("  SaveInfo: Writing <appinfo> begin tag");
                sw.WriteLine("  <appinfo name=\"" + tvAppList.Nodes[i].Text + "\">");
                if (dodebug) swDebug.WriteLine("  SaveInfo: Writing <path></path> info");
                sw.WriteLine("    <path>" + tvAppList.Nodes[i].Nodes[0].Text + "</path>");
                if (dodebug) swDebug.WriteLine("  SaveInfo: Writing <cmdline></cmdline> info");
                sw.WriteLine("    <cmdline>" + tvAppList.Nodes[i].Nodes[1].Text + "</cmdline>");
                if (dodebug) swDebug.WriteLine("  SaveInfo: Writing <workingdir></workingdir> info");
                sw.WriteLine("    <workingdir>" + tvAppList.Nodes[i].Nodes[2].Text + "</workingdir>");
                if (dodebug) swDebug.WriteLine("  SaveInfo: Writing <wait></wait> info");
                sw.WriteLine("    <wait>" + tvAppList.Nodes[i].Nodes[3].Text + "</wait>");
                if (dodebug) swDebug.WriteLine("  SaveInfo: Writing <startmin></startmin> info");
                sw.WriteLine("    <startmin>" + tvAppList.Nodes[i].Nodes[4].Text + "</startmin>");
                if (dodebug) swDebug.WriteLine("  SaveInfo: Writing </appinfo> end tag");
                sw.WriteLine("  </appinfo>");
            }
            if (dodebug) swDebug.WriteLine("  SaveInfo: Writing </applications> end tag");
            sw.WriteLine("</applications>");
            if (dodebug) swDebug.WriteLine("  SaveInfo: Closing settings.xml");
            sw.Close();
        }

        public frmOptions(XmlDocument xmldoc, bool dbg)
        {
            if (dbg)
            {
                dodebug = dbg;
                swDebug = new StreamWriter("aldebug.log", true);
            }
            if (dodebug) swDebug.WriteLine("  frmOptions: InitializeComponent()");
            InitializeComponent();
            if (dodebug) swDebug.WriteLine("  frmoptions: Setting settingsxml to xmldoc");
            settingsxml = xmldoc;
            if (dodebug) swDebug.WriteLine("  frmOptions: Loading appinfo nodes");
            appinfonodes = settingsxml.GetElementsByTagName("appinfo");
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("  frmOptions_Load: Executing function ReadInfo()");
            ReadInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("  btnCancel_Click: Executing function SaveInfo()");
            SaveInfo();
            if (dodebug) swDebug.WriteLine("  btnCancel_Click: Closing frmOptions");
            if (dodebug) swDebug.Close();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("  btnAdd_Click: Opening frmAddEditIns for adding");
            if (dodebug) swDebug.Close();
            frmAddEditIns frmaei = new frmAddEditIns(1, this, dodebug);
            frmaei.ShowDialog(this);
            if (dodebug) swDebug = new System.IO.StreamWriter("aldebug.log", true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("  btnEdit_Click: Check to see if anything is selected in tvAppList");
            if (tvAppList.SelectedNode != null)
            {
                if (dodebug) swDebug.WriteLine("  btnEdit_Click: tvAppList.SelectedNode = " + tvAppList.SelectedNode.ToString());
                if (dodebug) swDebug.WriteLine("  btnEdit_Click: Opening frmAddEditIns for Editing");
                if (dodebug) swDebug.Close();
                frmAddEditIns frmaei = new frmAddEditIns(2, this, dodebug);
                frmaei.ShowDialog(this);
                if (dodebug) swDebug = new System.IO.StreamWriter("aldebug.log", true);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("  btnInsert_Click: Check to see if anything is selected in tvAppList");
            if (tvAppList.SelectedNode != null)
            {
                if (dodebug) swDebug.WriteLine("  btnInsert_Click: tvAppList.SelectedNode = " + tvAppList.SelectedNode.ToString());
                if (dodebug) swDebug.WriteLine("  btnInsert_Click: Opening frmAddEditIns for inserting");
                if (dodebug) swDebug.Close();
                frmAddEditIns frmaei = new frmAddEditIns(3, this, dodebug);
                frmaei.ShowDialog(this);
                if (dodebug) swDebug = new System.IO.StreamWriter("aldebug.log", true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("  btnDelete_Click: Check to see if anything is selected in tvAppList");
            if (tvAppList.SelectedNode != null)
            {
                if (dodebug) swDebug.WriteLine("  btnDelete_Click: tvAppList.SelectedNode = " + tvAppList.SelectedNode.ToString());
                if (dodebug) swDebug.WriteLine("  btnDelete_Click: Checking if treeview selected node = child node");
                if (tvAppList.SelectedNode.Parent != null)
                {
                    if (dodebug) swDebug.WriteLine("  btnDelete_Click: treeview selected node = child node");
                    if (dodebug) swDebug.WriteLine("  btnDelete_Click: setting treeview selected node to parent of child");
                    tvAppList.SelectedNode = tvAppList.SelectedNode.Parent;
                }
                if (dodebug) swDebug.WriteLine("  btnDelete_Click: Removing selected node");
                tvAppList.SelectedNode.Remove();
            }
        }

        private void frmOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dodebug) if (swDebug != null) swDebug.Close();
        }
    }
}
