namespace Hpe.Agm.RestConnector.Views
{
    partial class ParametersView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametersView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_treeView = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtnNewFolder = new System.Windows.Forms.ToolStripButton();
            this.toolBtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDuplicate = new System.Windows.Forms.ToolStripButton();
            this.toolBtnReload = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnRemove = new System.Windows.Forms.ToolStripButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_treeView);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1MinSize = 265;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtName);
            this.splitContainer1.Panel2.Controls.Add(this.lblName);
            this.splitContainer1.Panel2.Controls.Add(this.txtValue);
            this.splitContainer1.Panel2.Controls.Add(this.lblValue);
            this.splitContainer1.Size = new System.Drawing.Size(726, 411);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_treeView
            // 
            this.m_treeView.BackColor = System.Drawing.SystemColors.Control;
            this.m_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeView.Location = new System.Drawing.Point(0, 25);
            this.m_treeView.Name = "m_treeView";
            this.m_treeView.Size = new System.Drawing.Size(351, 382);
            this.m_treeView.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnNewFolder,
            this.toolBtnNew,
            this.toolBtnDuplicate,
            this.toolBtnReload,
            this.toolBtnSave,
            this.toolStripSeparator1,
            this.toolBtnRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(351, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnNewFolder
            // 
            this.toolBtnNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnNewFolder.Image")));
            this.toolBtnNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnNewFolder.Name = "toolBtnNewFolder";
            this.toolBtnNewFolder.Size = new System.Drawing.Size(85, 22);
            this.toolBtnNewFolder.Text = "New folder";
            this.toolBtnNewFolder.Click += new System.EventHandler(this.OnNewFolderClick);
            // 
            // toolBtnNew
            // 
            this.toolBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnNew.Image")));
            this.toolBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnNew.Name = "toolBtnNew";
            this.toolBtnNew.Size = new System.Drawing.Size(51, 22);
            this.toolBtnNew.Text = "New";
            this.toolBtnNew.Click += new System.EventHandler(this.OnNewItemClick);
            // 
            // toolBtnDuplicate
            // 
            this.toolBtnDuplicate.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnDuplicate.Image")));
            this.toolBtnDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDuplicate.Name = "toolBtnDuplicate";
            this.toolBtnDuplicate.Size = new System.Drawing.Size(77, 22);
            this.toolBtnDuplicate.Text = "Duplicate";
            this.toolBtnDuplicate.Click += new System.EventHandler(this.OnDuplicateClick);
            // 
            // toolBtnReload
            // 
            this.toolBtnReload.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnReload.Image")));
            this.toolBtnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnReload.Name = "toolBtnReload";
            this.toolBtnReload.Size = new System.Drawing.Size(80, 22);
            this.toolBtnReload.Text = "Reload All";
            this.toolBtnReload.Click += new System.EventHandler(this.OnReloadClick);
            // 
            // toolBtnSave
            // 
            this.toolBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnSave.Image")));
            this.toolBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Size = new System.Drawing.Size(51, 20);
            this.toolBtnSave.Text = "Save";
            this.toolBtnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBtnRemove
            // 
            this.toolBtnRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnRemove.Image")));
            this.toolBtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRemove.Name = "toolBtnRemove";
            this.toolBtnRemove.Size = new System.Drawing.Size(70, 20);
            this.toolBtnRemove.Text = "Remove";
            this.toolBtnRemove.Click += new System.EventHandler(this.OnRemoveClick);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(95, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(239, 20);
            this.txtName.TabIndex = 49;
            this.txtName.TextChanged += new System.EventHandler(this.OnTextValueChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(44, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 48;
            this.lblName.Text = "Name:";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(95, 52);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(239, 20);
            this.txtValue.TabIndex = 35;
            this.txtValue.TextChanged += new System.EventHandler(this.OnTextValueChanged);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(37, 55);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(40, 13);
            this.lblValue.TabIndex = 34;
            this.lblValue.Text = "Value :";
            // 
            // ParametersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ParametersView";
            this.Size = new System.Drawing.Size(726, 411);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnNew;
        private System.Windows.Forms.ToolStripButton toolBtnDuplicate;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnRemove;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TreeView m_treeView;
        private System.Windows.Forms.ToolStripButton toolBtnNewFolder;
        private System.Windows.Forms.ToolStripButton toolBtnReload;
    }
}
