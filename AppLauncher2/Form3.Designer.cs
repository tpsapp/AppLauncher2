namespace AppLauncher2
{
    partial class frmAddEditIns
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditIns));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAppName = new System.Windows.Forms.TextBox();
            this.tbAppPath = new System.Windows.Forms.TextBox();
            this.tbCmdLine = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudWaitTime = new System.Windows.Forms.NumericUpDown();
            this.cbStartMin = new System.Windows.Forms.CheckBox();
            this.ofdAppPath = new System.Windows.Forms.OpenFileDialog();
            this.btnAppPath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWorkingDir = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaitTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Command Line:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wait Time:";
            // 
            // tbAppName
            // 
            this.tbAppName.Location = new System.Drawing.Point(12, 25);
            this.tbAppName.Name = "tbAppName";
            this.tbAppName.Size = new System.Drawing.Size(200, 20);
            this.tbAppName.TabIndex = 0;
            // 
            // tbAppPath
            // 
            this.tbAppPath.Location = new System.Drawing.Point(12, 64);
            this.tbAppPath.Name = "tbAppPath";
            this.tbAppPath.Size = new System.Drawing.Size(200, 20);
            this.tbAppPath.TabIndex = 1;
            // 
            // tbCmdLine
            // 
            this.tbCmdLine.Location = new System.Drawing.Point(12, 103);
            this.tbCmdLine.Name = "tbCmdLine";
            this.tbCmdLine.Size = new System.Drawing.Size(200, 20);
            this.tbCmdLine.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(56, 205);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudWaitTime
            // 
            this.nudWaitTime.Location = new System.Drawing.Point(15, 181);
            this.nudWaitTime.Name = "nudWaitTime";
            this.nudWaitTime.Size = new System.Drawing.Size(94, 20);
            this.nudWaitTime.TabIndex = 3;
            this.nudWaitTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbStartMin
            // 
            this.cbStartMin.AutoSize = true;
            this.cbStartMin.Checked = true;
            this.cbStartMin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStartMin.Location = new System.Drawing.Point(115, 182);
            this.cbStartMin.Name = "cbStartMin";
            this.cbStartMin.Size = new System.Drawing.Size(97, 17);
            this.cbStartMin.TabIndex = 4;
            this.cbStartMin.Text = "Start Minimized";
            this.cbStartMin.UseVisualStyleBackColor = true;
            // 
            // ofdAppPath
            // 
            this.ofdAppPath.DefaultExt = "exe";
            this.ofdAppPath.Filter = "Executable Files|*.exe|Batch Files|*.bat|COM Files|*.com|All Files|*.*";
            this.ofdAppPath.InitialDirectory = "C:\\";
            this.ofdAppPath.Title = "Select an application...";
            // 
            // btnAppPath
            // 
            this.btnAppPath.Image = ((System.Drawing.Image)(resources.GetObject("btnAppPath.Image")));
            this.btnAppPath.Location = new System.Drawing.Point(12, 205);
            this.btnAppPath.Name = "btnAppPath";
            this.btnAppPath.Size = new System.Drawing.Size(38, 23);
            this.btnAppPath.TabIndex = 5;
            this.btnAppPath.UseVisualStyleBackColor = true;
            this.btnAppPath.Click += new System.EventHandler(this.btnAppPath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Working Directory:";
            // 
            // tbWorkingDir
            // 
            this.tbWorkingDir.Location = new System.Drawing.Point(12, 142);
            this.tbWorkingDir.Name = "tbWorkingDir";
            this.tbWorkingDir.Size = new System.Drawing.Size(200, 20);
            this.tbWorkingDir.TabIndex = 9;
            // 
            // frmAddEditIns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 238);
            this.Controls.Add(this.tbWorkingDir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAppPath);
            this.Controls.Add(this.cbStartMin);
            this.Controls.Add(this.nudWaitTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbCmdLine);
            this.Controls.Add(this.tbAppPath);
            this.Controls.Add(this.tbAppName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditIns";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Application...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddEditIns_FormClosed);
            this.Load += new System.EventHandler(this.frmAddEditIns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWaitTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAppName;
        private System.Windows.Forms.TextBox tbAppPath;
        private System.Windows.Forms.TextBox tbCmdLine;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudWaitTime;
        private System.Windows.Forms.CheckBox cbStartMin;
        private System.Windows.Forms.OpenFileDialog ofdAppPath;
        private System.Windows.Forms.Button btnAppPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbWorkingDir;
    }
}