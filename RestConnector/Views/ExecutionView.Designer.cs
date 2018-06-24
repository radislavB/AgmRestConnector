namespace Hpe.Agm.RestConnector.Views
{
    partial class ExecutionView
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecutionView));
			this.groupBoxHeaders = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtHeaderName = new System.Windows.Forms.TextBox();
			this.txtHeaderValue = new System.Windows.Forms.TextBox();
			this.listHeaders = new System.Windows.Forms.ListView();
			this.txtTenantId = new System.Windows.Forms.TextBox();
			this.btnRemoveHeader = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.btnAddHeader = new System.Windows.Forms.Button();
			this.groupBoxRequest = new System.Windows.Forms.GroupBox();
			this.txtFullUrl = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.richData = new System.Windows.Forms.RichTextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.formatJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbRequestMethod = new System.Windows.Forms.ComboBox();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.lblUrl = new System.Windows.Forms.Label();
			this.btnSend = new System.Windows.Forms.Button();
			this.splitContainerRequest = new System.Windows.Forms.SplitContainer();
			this.m_treeView = new System.Windows.Forms.TreeView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolBtnNewFolder = new System.Windows.Forms.ToolStripButton();
			this.toolBtnNew = new System.Windows.Forms.ToolStripButton();
			this.toolBtnDuplicate = new System.Windows.Forms.ToolStripButton();
			this.toolBtnReload = new System.Windows.Forms.ToolStripButton();
			this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolBtnRemove = new System.Windows.Forms.ToolStripButton();
			this.btnSendAll = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.richConsole = new System.Windows.Forms.RichTextBox();
			this.groupBoxHeaders.SuspendLayout();
			this.groupBoxRequest.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRequest)).BeginInit();
			this.splitContainerRequest.Panel1.SuspendLayout();
			this.splitContainerRequest.Panel2.SuspendLayout();
			this.splitContainerRequest.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxHeaders
			// 
			this.groupBoxHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxHeaders.Controls.Add(this.label9);
			this.groupBoxHeaders.Controls.Add(this.label8);
			this.groupBoxHeaders.Controls.Add(this.txtHeaderName);
			this.groupBoxHeaders.Controls.Add(this.txtHeaderValue);
			this.groupBoxHeaders.Controls.Add(this.listHeaders);
			this.groupBoxHeaders.Controls.Add(this.txtTenantId);
			this.groupBoxHeaders.Controls.Add(this.btnRemoveHeader);
			this.groupBoxHeaders.Controls.Add(this.label5);
			this.groupBoxHeaders.Controls.Add(this.btnAddHeader);
			this.groupBoxHeaders.Location = new System.Drawing.Point(13, 37);
			this.groupBoxHeaders.Name = "groupBoxHeaders";
			this.groupBoxHeaders.Size = new System.Drawing.Size(542, 112);
			this.groupBoxHeaders.TabIndex = 44;
			this.groupBoxHeaders.TabStop = false;
			this.groupBoxHeaders.Text = "Headers";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(245, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 13);
			this.label9.TabIndex = 43;
			this.label9.Text = "Value :";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(245, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 13);
			this.label8.TabIndex = 42;
			this.label8.Text = "Name :";
			// 
			// txtHeaderName
			// 
			this.txtHeaderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHeaderName.AutoCompleteCustomSource.AddRange(new string[] {
            "Accept",
            "Content-Type",
            "User-Agent",
            "X-QC-HIDDEN-SECURITY-ID",
            "HPECLIENTTYPE",
            "ALM_OCTANE_TECH_PREVIEW"});
			this.txtHeaderName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtHeaderName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtHeaderName.Location = new System.Drawing.Point(286, 22);
			this.txtHeaderName.Name = "txtHeaderName";
			this.txtHeaderName.Size = new System.Drawing.Size(188, 20);
			this.txtHeaderName.TabIndex = 39;
			// 
			// txtHeaderValue
			// 
			this.txtHeaderValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHeaderValue.AutoCompleteCustomSource.AddRange(new string[] {
            "application/json",
            "application/xml",
            "HPE_MQM_UI",
            "HPE_REST_API_TECH_PREVIEW"});
			this.txtHeaderValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtHeaderValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtHeaderValue.Location = new System.Drawing.Point(286, 48);
			this.txtHeaderValue.Name = "txtHeaderValue";
			this.txtHeaderValue.Size = new System.Drawing.Size(188, 20);
			this.txtHeaderValue.TabIndex = 40;
			// 
			// listHeaders
			// 
			this.listHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listHeaders.Location = new System.Drawing.Point(16, 21);
			this.listHeaders.Name = "listHeaders";
			this.listHeaders.Size = new System.Drawing.Size(143, 75);
			this.listHeaders.TabIndex = 41;
			this.listHeaders.UseCompatibleStateImageBehavior = false;
			this.listHeaders.View = System.Windows.Forms.View.List;
			this.listHeaders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listHeaders_MouseDoubleClick);
			// 
			// txtTenantId
			// 
			this.txtTenantId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTenantId.Location = new System.Drawing.Point(323, 80);
			this.txtTenantId.Name = "txtTenantId";
			this.txtTenantId.Size = new System.Drawing.Size(213, 20);
			this.txtTenantId.TabIndex = 28;
			this.txtTenantId.TextChanged += new System.EventHandler(this.OnValueChanged);
			// 
			// btnRemoveHeader
			// 
			this.btnRemoveHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveHeader.Location = new System.Drawing.Point(173, 21);
			this.btnRemoveHeader.Name = "btnRemoveHeader";
			this.btnRemoveHeader.Size = new System.Drawing.Size(66, 30);
			this.btnRemoveHeader.TabIndex = 38;
			this.btnRemoveHeader.Text = "Remove";
			this.btnRemoveHeader.UseVisualStyleBackColor = true;
			this.btnRemoveHeader.Click += new System.EventHandler(this.OnRemoveHeaderClick);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(245, 83);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 13);
			this.label5.TabIndex = 27;
			this.label5.Text = "Tenant Id:";
			// 
			// btnAddHeader
			// 
			this.btnAddHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddHeader.Location = new System.Drawing.Point(480, 21);
			this.btnAddHeader.Name = "btnAddHeader";
			this.btnAddHeader.Size = new System.Drawing.Size(56, 47);
			this.btnAddHeader.TabIndex = 37;
			this.btnAddHeader.Text = "Add";
			this.btnAddHeader.UseVisualStyleBackColor = true;
			this.btnAddHeader.Click += new System.EventHandler(this.OnAddHeaderClick);
			// 
			// groupBoxRequest
			// 
			this.groupBoxRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxRequest.Controls.Add(this.txtFullUrl);
			this.groupBoxRequest.Controls.Add(this.label1);
			this.groupBoxRequest.Controls.Add(this.richData);
			this.groupBoxRequest.Controls.Add(this.label10);
			this.groupBoxRequest.Controls.Add(this.cmbRequestMethod);
			this.groupBoxRequest.Controls.Add(this.txtUrl);
			this.groupBoxRequest.Controls.Add(this.lblUrl);
			this.groupBoxRequest.Location = new System.Drawing.Point(13, 149);
			this.groupBoxRequest.Name = "groupBoxRequest";
			this.groupBoxRequest.Size = new System.Drawing.Size(542, 189);
			this.groupBoxRequest.TabIndex = 45;
			this.groupBoxRequest.TabStop = false;
			this.groupBoxRequest.Text = "Request";
			// 
			// txtFullUrl
			// 
			this.txtFullUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFullUrl.Location = new System.Drawing.Point(93, 69);
			this.txtFullUrl.Multiline = true;
			this.txtFullUrl.Name = "txtFullUrl";
			this.txtFullUrl.ReadOnly = true;
			this.txtFullUrl.Size = new System.Drawing.Size(430, 23);
			this.txtFullUrl.TabIndex = 38;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 37;
			this.label1.Text = "Full Url :";
			// 
			// richData
			// 
			this.richData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richData.ContextMenuStrip = this.contextMenuStrip1;
			this.richData.Location = new System.Drawing.Point(94, 105);
			this.richData.Name = "richData";
			this.richData.Size = new System.Drawing.Size(430, 69);
			this.richData.TabIndex = 36;
			this.richData.Text = "";
			this.richData.TextChanged += new System.EventHandler(this.OnValueChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatJsonToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(139, 26);
			// 
			// formatJsonToolStripMenuItem
			// 
			this.formatJsonToolStripMenuItem.Name = "formatJsonToolStripMenuItem";
			this.formatJsonToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.formatJsonToolStripMenuItem.Text = "Format Json";
			this.formatJsonToolStripMenuItem.Click += new System.EventHandler(this.formatJsonToolStripMenuItem_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 96);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(39, 13);
			this.label10.TabIndex = 35;
			this.label10.Text = "Data : ";
			// 
			// cmbRequestMethod
			// 
			this.cmbRequestMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRequestMethod.FormattingEnabled = true;
			this.cmbRequestMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
			this.cmbRequestMethod.Location = new System.Drawing.Point(93, 20);
			this.cmbRequestMethod.Name = "cmbRequestMethod";
			this.cmbRequestMethod.Size = new System.Drawing.Size(74, 21);
			this.cmbRequestMethod.TabIndex = 34;
			this.cmbRequestMethod.SelectedIndexChanged += new System.EventHandler(this.OnValueChanged);
			// 
			// txtUrl
			// 
			this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUrl.Location = new System.Drawing.Point(173, 20);
			this.txtUrl.Multiline = true;
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(351, 43);
			this.txtUrl.TabIndex = 21;
			this.txtUrl.TextChanged += new System.EventHandler(this.OnUrlTextChanged);
			// 
			// lblUrl
			// 
			this.lblUrl.AutoSize = true;
			this.lblUrl.Location = new System.Drawing.Point(6, 23);
			this.lblUrl.Name = "lblUrl";
			this.lblUrl.Size = new System.Drawing.Size(68, 13);
			this.lblUrl.TabIndex = 20;
			this.lblUrl.Text = "Relative Url :";
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Location = new System.Drawing.Point(445, 344);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(110, 27);
			this.btnSend.TabIndex = 22;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.OnSendClick);
			// 
			// splitContainerRequest
			// 
			this.splitContainerRequest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerRequest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerRequest.Location = new System.Drawing.Point(0, 0);
			this.splitContainerRequest.Name = "splitContainerRequest";
			// 
			// splitContainerRequest.Panel1
			// 
			this.splitContainerRequest.Panel1.Controls.Add(this.m_treeView);
			this.splitContainerRequest.Panel1.Controls.Add(this.toolStrip1);
			this.splitContainerRequest.Panel1MinSize = 265;
			// 
			// splitContainerRequest.Panel2
			// 
			this.splitContainerRequest.Panel2.Controls.Add(this.btnSendAll);
			this.splitContainerRequest.Panel2.Controls.Add(this.txtName);
			this.splitContainerRequest.Panel2.Controls.Add(this.lblName);
			this.splitContainerRequest.Panel2.Controls.Add(this.btnSend);
			this.splitContainerRequest.Panel2.Controls.Add(this.groupBoxHeaders);
			this.splitContainerRequest.Panel2.Controls.Add(this.groupBoxRequest);
			this.splitContainerRequest.Size = new System.Drawing.Size(925, 378);
			this.splitContainerRequest.SplitterDistance = 347;
			this.splitContainerRequest.TabIndex = 47;
			// 
			// m_treeView
			// 
			this.m_treeView.BackColor = System.Drawing.SystemColors.Control;
			this.m_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_treeView.Location = new System.Drawing.Point(0, 25);
			this.m_treeView.Name = "m_treeView";
			this.m_treeView.Size = new System.Drawing.Size(343, 349);
			this.m_treeView.TabIndex = 4;
			this.m_treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnNodeMouseDoubleClick);
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
			this.toolStrip1.Size = new System.Drawing.Size(343, 25);
			this.toolStrip1.TabIndex = 3;
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
			// btnSendAll
			// 
			this.btnSendAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSendAll.Location = new System.Drawing.Point(13, 346);
			this.btnSendAll.Name = "btnSendAll";
			this.btnSendAll.Size = new System.Drawing.Size(110, 27);
			this.btnSendAll.TabIndex = 50;
			this.btnSendAll.Text = "Send All";
			this.btnSendAll.UseVisualStyleBackColor = true;
			this.btnSendAll.Click += new System.EventHandler(this.OnSendAllClick);
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(75, 9);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(480, 20);
			this.txtName.TabIndex = 49;
			this.txtName.TextChanged += new System.EventHandler(this.OnValueChanged);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(20, 12);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 48;
			this.lblName.Text = "Name:";
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.splitContainerRequest);
			this.splitContainerMain.Panel1MinSize = 300;
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.richConsole);
			this.splitContainerMain.Size = new System.Drawing.Size(925, 578);
			this.splitContainerMain.SplitterDistance = 378;
			this.splitContainerMain.TabIndex = 48;
			// 
			// richConsole
			// 
			this.richConsole.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richConsole.Location = new System.Drawing.Point(0, 0);
			this.richConsole.Name = "richConsole";
			this.richConsole.ReadOnly = true;
			this.richConsole.Size = new System.Drawing.Size(921, 192);
			this.richConsole.TabIndex = 18;
			this.richConsole.Text = "";
			// 
			// ExecutionView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerMain);
			this.Name = "ExecutionView";
			this.Size = new System.Drawing.Size(925, 578);
			this.groupBoxHeaders.ResumeLayout(false);
			this.groupBoxHeaders.PerformLayout();
			this.groupBoxRequest.ResumeLayout(false);
			this.groupBoxRequest.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.splitContainerRequest.Panel1.ResumeLayout(false);
			this.splitContainerRequest.Panel1.PerformLayout();
			this.splitContainerRequest.Panel2.ResumeLayout(false);
			this.splitContainerRequest.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRequest)).EndInit();
			this.splitContainerRequest.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHeaders;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHeaderName;
        private System.Windows.Forms.TextBox txtHeaderValue;
        private System.Windows.Forms.ListView listHeaders;
        private System.Windows.Forms.Button btnRemoveHeader;
        private System.Windows.Forms.Button btnAddHeader;
        private System.Windows.Forms.GroupBox groupBoxRequest;
        private System.Windows.Forms.RichTextBox richData;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbRequestMethod;
        private System.Windows.Forms.TextBox txtTenantId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.SplitContainer splitContainerRequest;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.RichTextBox richConsole;
        private System.Windows.Forms.TextBox txtFullUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnNewFolder;
        private System.Windows.Forms.ToolStripButton toolBtnNew;
        private System.Windows.Forms.ToolStripButton toolBtnDuplicate;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnRemove;
        private System.Windows.Forms.TreeView m_treeView;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.ToolStripButton toolBtnReload;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formatJsonToolStripMenuItem;

    }
}
