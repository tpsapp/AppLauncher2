using System;
using System.Windows.Forms;

namespace AppLauncher2
{
    public partial class frmAddEditIns : Form
    {
        int AddEditIns = 0;
        frmOptions frmo;
        int currindex;
        bool dodebug;
        System.IO.StreamWriter swDebug = null;

        private void AddApp()
        {
            if (dodebug) swDebug.WriteLine("    AddApp: Adding name parent node to frmOptions treeview");
            frmo.tvAppList.Nodes.Add(tbAppName.Text);
            if (dodebug) swDebug.WriteLine("    AddApp: Adding path child node frmOptions treeview");
            frmo.tvAppList.Nodes[frmo.tvAppList.Nodes.Count - 1].Nodes.Add(tbAppPath.Text);
            if (dodebug) swDebug.WriteLine("    AddApp: Adding cmdline child node to frmOptions treeview");
            frmo.tvAppList.Nodes[frmo.tvAppList.Nodes.Count - 1].Nodes.Add(tbCmdLine.Text);
            if (dodebug) swDebug.WriteLine("    AddApp: Adding workingdir child node to frmOptions treeview");
            frmo.tvAppList.Nodes[frmo.tvAppList.Nodes.Count - 1].Nodes.Add(tbWorkingDir.Text);
            if (dodebug) swDebug.WriteLine("    AddApp: Adding waitting child node to frmOptions treeview");
            frmo.tvAppList.Nodes[frmo.tvAppList.Nodes.Count - 1].Nodes.Add(nudWaitTime.Value.ToString());
            if (dodebug) swDebug.WriteLine("    AddApp: Adding startmin child node to frmOptions treeview");
            frmo.tvAppList.Nodes[frmo.tvAppList.Nodes.Count - 1].Nodes.Add(cbStartMin.Checked.ToString());
            if (dodebug) swDebug.WriteLine("    AddApp: Autoexpaning all nodes in frmOptions treeview");
            frmo.tvAppList.ExpandAll();
            if (dodebug) swDebug.WriteLine("    AddApp: Closing frmAddEditIns");
            if (dodebug) swDebug.Close();
            this.Close();
        }

        private void EditApp()
        {
            if (dodebug) swDebug.WriteLine("    EditApp: Changing name parent node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Text = tbAppName.Text;
            if (dodebug) swDebug.WriteLine("    EditApp: Changing path child node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes[0].Text = tbAppPath.Text;
            if (dodebug) swDebug.WriteLine("    EditApp: Changing cmdline child node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes[1].Text = tbCmdLine.Text;
            if (dodebug) swDebug.WriteLine("    EditApp: Changing workingdir child node to frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes[2].Text = tbWorkingDir.Text;
            if (dodebug) swDebug.WriteLine("    EditApp: Changing waittime child node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes[3].Text = nudWaitTime.Value.ToString();
            if (dodebug) swDebug.WriteLine("    EditApp: Changing startmin child node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes[4].Text = cbStartMin.Checked.ToString();
            if (dodebug) swDebug.WriteLine("    EditApp: Autoexpanding all nodes in frmOptions treeview");
            frmo.tvAppList.ExpandAll();
            if (dodebug) swDebug.WriteLine("    EditApp: Closing frmAddEditIns");
            if (dodebug) swDebug.Close();
            this.Close();
        }

        private void InsertApp()
        {
            if (dodebug) swDebug.WriteLine("    InsertApp: Inserting name parent node in frmOptions treeview");
            frmo.tvAppList.Nodes.Insert(currindex, tbAppName.Text);
            if (dodebug) swDebug.WriteLine("    InsertApp: Inserting path child node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes.Add(tbAppPath.Text);
            if (dodebug) swDebug.WriteLine("    InsertApp: Inserting cmdline child node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes.Add(tbCmdLine.Text);
            if (dodebug) swDebug.WriteLine("    InsertApp: Adding workingdir child node to frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes.Add(tbWorkingDir.Text);
            if (dodebug) swDebug.WriteLine("    InsertApp: Inserting waittime child node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes.Add(nudWaitTime.Value.ToString());
            if (dodebug) swDebug.WriteLine("    InsertApp: Inserting startmin child node in frmOptions treeview");
            frmo.tvAppList.Nodes[currindex].Nodes.Add(cbStartMin.Checked.ToString());
            if (dodebug) swDebug.WriteLine("    InsertApp: Autoexpanding all nodes in frmOptions treeview");
            frmo.tvAppList.ExpandAll();
            if (dodebug) swDebug.WriteLine("    InsertApp: Closing frmAddEditIns");
            if (dodebug) swDebug.Close();
            this.Close();
        }

        public frmAddEditIns(int aei, frmOptions frm, bool dbg)
        {
            if (dbg)
            {
                dodebug = dbg;
                swDebug = new System.IO.StreamWriter("aldebug.log", true);
            }
            InitializeComponent();
            if (dodebug) swDebug.WriteLine("    frmAddEditIns: setting AddEditIns to aei");
            AddEditIns = aei;
            if (dodebug) swDebug.WriteLine("    frmAddEditIns: setting frmo to frm");
            frmo = frm;
        }

        private void frmAddEditIns_Load(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Executing switch on AddEditIns variable");
            switch (AddEditIns)
            {
                case 1:
                    {
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: AddEditIns = 1");
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Setting btnAdd.Text to &Add");
                        btnAdd.Text = "&Add";
                    }
                    break;
                case 2:
                    {
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: AddEditIns = 2");
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Setting BtnAdd.Text to &Save");
                        btnAdd.Text = "&Save";
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Checking if frmOptions treeview selected node = child node");
                        if (frmo.tvAppList.SelectedNode.Parent != null)
                        {
                            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: frmOptions treeview selected node = child node");
                            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Setting frmOptions treeview selected node to parent node");
                            frmo.tvAppList.SelectedNode = frmo.tvAppList.SelectedNode.Parent;
                        }
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Setting currindex to frmOptions treeview selected node index");
                        currindex = frmo.tvAppList.SelectedNode.Index;
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Getting App Name from frmOptions treeview");
                        tbAppName.Text = frmo.tvAppList.SelectedNode.Text;
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Getting path from frmOptions treeview");
                        tbAppPath.Text = frmo.tvAppList.SelectedNode.Nodes[0].Text;
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Getting cmdline from frmOptions treeview");
                        tbCmdLine.Text = frmo.tvAppList.SelectedNode.Nodes[1].Text;
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Getting workingdir from frmOptions treeview");
                        tbWorkingDir.Text = frmo.tvAppList.SelectedNode.Nodes[2].Text;
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Getting waittime from frmOptions treeview");
                        nudWaitTime.Value = Convert.ToInt32(frmo.tvAppList.SelectedNode.Nodes[3].Text);
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Checking if startmin is set to true");
                        if (frmo.tvAppList.SelectedNode.Nodes[4].Text == "True")
                        {
                            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: startmin = true");
                            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Enabling cbStartMin");
                            cbStartMin.Checked = true;
                        }
                        else
                        {
                            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: startmin = false");
                            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Disabling cbStartMin");
                            cbStartMin.Checked = false;
                        }
                    }
                    break;
                case 3:
                    {
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: AddEditIns = 3");
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Checking if frmOptions treeview selected node is a child node");
                        if (frmo.tvAppList.SelectedNode.Parent != null)
                        {
                            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: frmOptions treeview selected node is a child node");
                            if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Setting frmOptions treeview selected node to parent node");
                            frmo.tvAppList.SelectedNode = frmo.tvAppList.SelectedNode.Parent;
                        }
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Setting currindex to frmOptions treeview selected node index");
                        currindex = frmo.tvAppList.SelectedNode.Index;
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Setting btnStart.Text to &Insert");
                        btnAdd.Text = "&Insert";
                    }
                    break;
                default:
                    {
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: AddEditIns = " + AddEditIns.ToString());
                        if (dodebug) swDebug.WriteLine("    frmAddEditIns_Load: Setting btnStart.Text to &Add");
                        btnAdd.Text = "&Add";
                    }
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("    btnAdd_Click: Checking that tbAppName.Text and tbAppPath.Text are not blank");
            if ((tbAppName.Text != "") && (tbAppPath.Text != ""))
            {
                if (dodebug) swDebug.WriteLine("    btnAdd_Click: tbAppName.Text and tbAppPath.Text are not blank");
                if (dodebug) swDebug.WriteLine("    btnAdd_Click: tbAppName.Text = " + tbAppName.Text + " and tbAppPath.Text = " + tbAppPath.Text);
                if (dodebug) swDebug.WriteLine("    btnAdd_Click: Executing switch on AddEditIns");
                switch (AddEditIns)
                {
                    case 1:
                        {
                            if (dodebug) swDebug.WriteLine("    btnAdd_Click: AddEditIns = 1");
                            if (dodebug) swDebug.WriteLine("    btnAdd_Click: Executing function AddApp()");
                            AddApp();
                        }
                        break;
                    case 2:
                        {
                            if (dodebug) swDebug.WriteLine("    btnAdd_Click: AddEditIns = 2");
                            if (dodebug) swDebug.WriteLine("    btnAdd_Click: Executing function EditApp()");
                            EditApp();
                        }
                        break;
                    case 3:
                        {
                            if (dodebug) swDebug.WriteLine("    btnAdd_Click: AddEditIns = 3");
                            if (dodebug) swDebug.WriteLine("    btnAdd_Click: Executing function InsertApp()");
                            InsertApp();
                        }
                        break;
                    default:
                        {
                            if (dodebug) swDebug.WriteLine("    btnAdd_Click: AddEditIns = " + AddEditIns.ToString());
                            if (dodebug) swDebug.WriteLine("    btnAdd_Click: Executing function AddApp()");
                            AddApp();
                        }
                        break;
                }
            }
            else
            {
                if (dodebug) swDebug.WriteLine("    btnAdd_Click: tbAppName.Text = " + tbAppName.Text + " and tbAppPath.Text = " + tbAppPath.Text);
                if (dodebug) swDebug.WriteLine("    btnAdd_Click: Showing MessageBox asking using to fill in Name and Path fields");
                MessageBox.Show("Please fill in the Name and Path fields.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("    btnCancel_Click: Closing frmAddEditIns");
            if (dodebug) swDebug.Close();
            this.Close();
        }

        private void btnAppPath_Click(object sender, EventArgs e)
        {
            if (dodebug) swDebug.WriteLine("    btnAppPath_Click: Showing Open File Dialog ofdAppPath");
            ofdAppPath.ShowDialog();
            if (dodebug) swDebug.WriteLine("    btnAppPath_Click: Setting temp string sfn to ofdAppPath.SafeFileName");
            string sfn = ofdAppPath.SafeFileName;
            if (dodebug) swDebug.WriteLine("    btnAppPath_Click: Removing file extension from filename");
            sfn = sfn.Remove(sfn.Length - 4);
            if (dodebug) swDebug.WriteLine("    btnAppPath_Click: Setting tbAppName.Text to temp string sfn");
            tbAppName.Text = sfn;
            if (dodebug) swDebug.WriteLine("    btnAppPath_Click: Setting tbAppPath.Text to ofdAppPath.FileName");
            tbAppPath.Text = ofdAppPath.FileName;
            if (dodebug) swDebug.WriteLine("    btnAppPath_Click: Setting temp string wd to ofdAppPath.FileName");
            string wd = ofdAppPath.FileName;
            if (dodebug) swDebug.WriteLine("    btnAppPath_Click: Removing filename from file path");
            wd = wd.Remove(wd.Length - (ofdAppPath.SafeFileName.Length));
            if (dodebug) swDebug.WriteLine("    btnAppPath_Click: Setting tbWorkingDire.Text to temp string wd");
            tbWorkingDir.Text = wd;
        }

        private void frmAddEditIns_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dodebug) if (swDebug != null) swDebug.Close();
        }
    }
}
