namespace Hpe.Agm.RestConnector.Views
{
    partial class ConnectionsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionsView));
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
            this.radioBtnJenkins = new System.Windows.Forms.RadioButton();
            this.radioBtnALM12_0 = new System.Windows.Forms.RadioButton();
            this.radioBtnALM12_5 = new System.Windows.Forms.RadioButton();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.groupBaseURL = new System.Windows.Forms.GroupBox();
            this.chkCustomBaseURL = new System.Windows.Forms.CheckBox();
            this.txtBaseURL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupSCRF = new System.Windows.Forms.GroupBox();
            this.txtSCRFHeader = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSCRFValue = new System.Windows.Forms.TextBox();
            this.txtSCRFCookie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioBtnNga = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.radioBtnBackOffice = new System.Windows.Forms.RadioButton();
            this.radioBtnAGM = new System.Windows.Forms.RadioButton();
            this.txtLoginUrl = new System.Windows.Forms.TextBox();
            this.lblLabelToken = new System.Windows.Forms.Label();
            this.lblLoginUrl = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.chkPasswordPlain = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.lblServerUrl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBaseURL.SuspendLayout();
            this.groupSCRF.SuspendLayout();
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
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.radioBtnJenkins);
            this.splitContainer1.Panel2.Controls.Add(this.radioBtnALM12_0);
            this.splitContainer1.Panel2.Controls.Add(this.radioBtnALM12_5);
            this.splitContainer1.Panel2.Controls.Add(this.txtToken);
            this.splitContainer1.Panel2.Controls.Add(this.groupBaseURL);
            this.splitContainer1.Panel2.Controls.Add(this.groupSCRF);
            this.splitContainer1.Panel2.Controls.Add(this.radioBtnNga);
            this.splitContainer1.Panel2.Controls.Add(this.txtName);
            this.splitContainer1.Panel2.Controls.Add(this.lblName);
            this.splitContainer1.Panel2.Controls.Add(this.lblPassword);
            this.splitContainer1.Panel2.Controls.Add(this.radioBtnBackOffice);
            this.splitContainer1.Panel2.Controls.Add(this.radioBtnAGM);
            this.splitContainer1.Panel2.Controls.Add(this.txtLoginUrl);
            this.splitContainer1.Panel2.Controls.Add(this.lblLabelToken);
            this.splitContainer1.Panel2.Controls.Add(this.lblLoginUrl);
            this.splitContainer1.Panel2.Controls.Add(this.btnConnect);
            this.splitContainer1.Panel2.Controls.Add(this.chkPasswordPlain);
            this.splitContainer1.Panel2.Controls.Add(this.txtPassword);
            this.splitContainer1.Panel2.Controls.Add(this.txtLoginName);
            this.splitContainer1.Panel2.Controls.Add(this.lblLoginName);
            this.splitContainer1.Panel2.Controls.Add(this.txtServerUrl);
            this.splitContainer1.Panel2.Controls.Add(this.lblServerUrl);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 490);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 33;
            // 
            // m_treeView
            // 
            this.m_treeView.BackColor = System.Drawing.SystemColors.Control;
            this.m_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeView.Location = new System.Drawing.Point(0, 25);
            this.m_treeView.Name = "m_treeView";
            this.m_treeView.Size = new System.Drawing.Size(364, 461);
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
            this.toolStrip1.Size = new System.Drawing.Size(364, 25);
            this.toolStrip1.TabIndex = 5;
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
            this.toolBtnSave.Size = new System.Drawing.Size(51, 22);
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
            // radioBtnJenkins
            // 
            this.radioBtnJenkins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnJenkins.AutoSize = true;
            this.radioBtnJenkins.Location = new System.Drawing.Point(564, 116);
            this.radioBtnJenkins.Name = "radioBtnJenkins";
            this.radioBtnJenkins.Size = new System.Drawing.Size(61, 17);
            this.radioBtnJenkins.TabIndex = 60;
            this.radioBtnJenkins.Text = "Jenkins";
            this.radioBtnJenkins.UseVisualStyleBackColor = true;
            // 
            // radioBtnALM12_0
            // 
            this.radioBtnALM12_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnALM12_0.AutoSize = true;
            this.radioBtnALM12_0.Location = new System.Drawing.Point(491, 116);
            this.radioBtnALM12_0.Name = "radioBtnALM12_0";
            this.radioBtnALM12_0.Size = new System.Drawing.Size(71, 17);
            this.radioBtnALM12_0.TabIndex = 59;
            this.radioBtnALM12_0.Text = "ALM 12.0";
            this.radioBtnALM12_0.UseVisualStyleBackColor = true;
            this.radioBtnALM12_0.CheckedChanged += new System.EventHandler(this.OnRadioBtnCheckedChanged);
            // 
            // radioBtnALM12_5
            // 
            this.radioBtnALM12_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnALM12_5.AutoSize = true;
            this.radioBtnALM12_5.Location = new System.Drawing.Point(409, 116);
            this.radioBtnALM12_5.Name = "radioBtnALM12_5";
            this.radioBtnALM12_5.Size = new System.Drawing.Size(77, 17);
            this.radioBtnALM12_5.TabIndex = 58;
            this.radioBtnALM12_5.Text = "ALM 12.5+";
            this.radioBtnALM12_5.UseVisualStyleBackColor = true;
            this.radioBtnALM12_5.CheckedChanged += new System.EventHandler(this.OnRadioBtnCheckedChanged);
            // 
            // txtToken
            // 
            this.txtToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToken.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtToken.Location = new System.Drawing.Point(104, 181);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.ReadOnly = true;
            this.txtToken.Size = new System.Drawing.Size(519, 26);
            this.txtToken.TabIndex = 57;
            // 
            // groupBaseURL
            // 
            this.groupBaseURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBaseURL.Controls.Add(this.chkCustomBaseURL);
            this.groupBaseURL.Controls.Add(this.txtBaseURL);
            this.groupBaseURL.Controls.Add(this.label6);
            this.groupBaseURL.Location = new System.Drawing.Point(15, 234);
            this.groupBaseURL.Name = "groupBaseURL";
            this.groupBaseURL.Size = new System.Drawing.Size(615, 77);
            this.groupBaseURL.TabIndex = 56;
            this.groupBaseURL.TabStop = false;
            this.groupBaseURL.Text = "Base URL for requests";
            // 
            // chkCustomBaseURL
            // 
            this.chkCustomBaseURL.AutoSize = true;
            this.chkCustomBaseURL.Location = new System.Drawing.Point(26, 19);
            this.chkCustomBaseURL.Name = "chkCustomBaseURL";
            this.chkCustomBaseURL.Size = new System.Drawing.Size(112, 17);
            this.chkCustomBaseURL.TabIndex = 54;
            this.chkCustomBaseURL.Text = "Custom base URL";
            this.chkCustomBaseURL.UseVisualStyleBackColor = true;
            this.chkCustomBaseURL.CheckedChanged += new System.EventHandler(this.OnCustomBaseURLCheckedChanged);
            // 
            // txtBaseURL
            // 
            this.txtBaseURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseURL.Location = new System.Drawing.Point(96, 47);
            this.txtBaseURL.Name = "txtBaseURL";
            this.txtBaseURL.ReadOnly = true;
            this.txtBaseURL.Size = new System.Drawing.Size(512, 20);
            this.txtBaseURL.TabIndex = 53;
            this.txtBaseURL.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Base URL : ";
            // 
            // groupSCRF
            // 
            this.groupSCRF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSCRF.Controls.Add(this.txtSCRFHeader);
            this.groupSCRF.Controls.Add(this.label2);
            this.groupSCRF.Controls.Add(this.txtSCRFValue);
            this.groupSCRF.Controls.Add(this.txtSCRFCookie);
            this.groupSCRF.Controls.Add(this.label3);
            this.groupSCRF.Controls.Add(this.label1);
            this.groupSCRF.Location = new System.Drawing.Point(15, 328);
            this.groupSCRF.Name = "groupSCRF";
            this.groupSCRF.Size = new System.Drawing.Size(615, 106);
            this.groupSCRF.TabIndex = 55;
            this.groupSCRF.TabStop = false;
            this.groupSCRF.Text = "SCRF support";
            // 
            // txtSCRFHeader
            // 
            this.txtSCRFHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSCRFHeader.Location = new System.Drawing.Point(96, 47);
            this.txtSCRFHeader.Name = "txtSCRFHeader";
            this.txtSCRFHeader.ReadOnly = true;
            this.txtSCRFHeader.Size = new System.Drawing.Size(512, 20);
            this.txtSCRFHeader.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "CSRF header : ";
            // 
            // txtSCRFValue
            // 
            this.txtSCRFValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSCRFValue.Location = new System.Drawing.Point(96, 23);
            this.txtSCRFValue.Name = "txtSCRFValue";
            this.txtSCRFValue.ReadOnly = true;
            this.txtSCRFValue.Size = new System.Drawing.Size(512, 20);
            this.txtSCRFValue.TabIndex = 53;
            // 
            // txtSCRFCookie
            // 
            this.txtSCRFCookie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSCRFCookie.Location = new System.Drawing.Point(96, 70);
            this.txtSCRFCookie.Name = "txtSCRFCookie";
            this.txtSCRFCookie.ReadOnly = true;
            this.txtSCRFCookie.Size = new System.Drawing.Size(512, 20);
            this.txtSCRFCookie.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "CSRF cookie : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "CSRF value : ";
            // 
            // radioBtnNga
            // 
            this.radioBtnNga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnNga.AutoSize = true;
            this.radioBtnNga.Location = new System.Drawing.Point(564, 98);
            this.radioBtnNga.Name = "radioBtnNga";
            this.radioBtnNga.Size = new System.Drawing.Size(48, 17);
            this.radioBtnNga.TabIndex = 48;
            this.radioBtnNga.Text = "NGA";
            this.radioBtnNga.UseVisualStyleBackColor = true;
            this.radioBtnNga.CheckedChanged += new System.EventHandler(this.OnRadioBtnCheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(104, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(519, 20);
            this.txtName.TabIndex = 47;
            this.txtName.TextChanged += new System.EventHandler(this.OnTextValueChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(49, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 46;
            this.lblName.Text = "Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(347, 61);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password :";
            // 
            // radioBtnBackOffice
            // 
            this.radioBtnBackOffice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnBackOffice.AutoSize = true;
            this.radioBtnBackOffice.Location = new System.Drawing.Point(410, 98);
            this.radioBtnBackOffice.Name = "radioBtnBackOffice";
            this.radioBtnBackOffice.Size = new System.Drawing.Size(69, 17);
            this.radioBtnBackOffice.TabIndex = 44;
            this.radioBtnBackOffice.Text = "IDM (BO)";
            this.radioBtnBackOffice.UseVisualStyleBackColor = true;
            this.radioBtnBackOffice.CheckedChanged += new System.EventHandler(this.OnRadioBtnCheckedChanged);
            // 
            // radioBtnAGM
            // 
            this.radioBtnAGM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnAGM.AutoSize = true;
            this.radioBtnAGM.Checked = true;
            this.radioBtnAGM.Location = new System.Drawing.Point(491, 98);
            this.radioBtnAGM.Name = "radioBtnAGM";
            this.radioBtnAGM.Size = new System.Drawing.Size(52, 17);
            this.radioBtnAGM.TabIndex = 43;
            this.radioBtnAGM.TabStop = true;
            this.radioBtnAGM.Text = "AGM ";
            this.radioBtnAGM.UseVisualStyleBackColor = true;
            this.radioBtnAGM.CheckedChanged += new System.EventHandler(this.OnRadioBtnCheckedChanged);
            // 
            // txtLoginUrl
            // 
            this.txtLoginUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginUrl.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtLoginUrl.Location = new System.Drawing.Point(104, 139);
            this.txtLoginUrl.Name = "txtLoginUrl";
            this.txtLoginUrl.ReadOnly = true;
            this.txtLoginUrl.Size = new System.Drawing.Size(519, 20);
            this.txtLoginUrl.TabIndex = 42;
            // 
            // lblLabelToken
            // 
            this.lblLabelToken.AutoSize = true;
            this.lblLabelToken.Location = new System.Drawing.Point(40, 184);
            this.lblLabelToken.Name = "lblLabelToken";
            this.lblLabelToken.Size = new System.Drawing.Size(47, 13);
            this.lblLabelToken.TabIndex = 40;
            this.lblLabelToken.Text = "Token : ";
            // 
            // lblLoginUrl
            // 
            this.lblLoginUrl.AutoSize = true;
            this.lblLoginUrl.Location = new System.Drawing.Point(7, 140);
            this.lblLoginUrl.Name = "lblLoginUrl";
            this.lblLoginUrl.Size = new System.Drawing.Size(80, 13);
            this.lblLoginUrl.TabIndex = 39;
            this.lblLoginUrl.Text = "Get Token Url :";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(513, 443);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 26);
            this.btnConnect.TabIndex = 38;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.OnConnectClick);
            // 
            // chkPasswordPlain
            // 
            this.chkPasswordPlain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPasswordPlain.AutoSize = true;
            this.chkPasswordPlain.Location = new System.Drawing.Point(561, 63);
            this.chkPasswordPlain.Name = "chkPasswordPlain";
            this.chkPasswordPlain.Size = new System.Drawing.Size(69, 17);
            this.chkPasswordPlain.TabIndex = 37;
            this.chkPasswordPlain.Text = "Plain text";
            this.chkPasswordPlain.UseVisualStyleBackColor = true;
            this.chkPasswordPlain.CheckedChanged += new System.EventHandler(this.OnChkPasswordPlainCheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(412, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(143, 20);
            this.txtPassword.TabIndex = 36;
            this.txtPassword.TextChanged += new System.EventHandler(this.OnTextValueChanged);
            // 
            // txtLoginName
            // 
            this.txtLoginName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginName.Location = new System.Drawing.Point(104, 61);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(237, 20);
            this.txtLoginName.TabIndex = 35;
            this.txtLoginName.TextChanged += new System.EventHandler(this.OnTextValueChanged);
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Location = new System.Drawing.Point(17, 64);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(70, 13);
            this.lblLoginName.TabIndex = 34;
            this.lblLoginName.Text = "Login Name :";
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerUrl.Location = new System.Drawing.Point(104, 97);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(302, 20);
            this.txtServerUrl.TabIndex = 33;
            this.txtServerUrl.TextChanged += new System.EventHandler(this.OnServerUrlTextChanged);
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.AutoSize = true;
            this.lblServerUrl.Location = new System.Drawing.Point(27, 100);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(60, 13);
            this.lblServerUrl.TabIndex = 32;
            this.lblServerUrl.Text = "Server Url :";
            // 
            // ConnectionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConnectionsView";
            this.Size = new System.Drawing.Size(1014, 490);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBaseURL.ResumeLayout(false);
            this.groupBaseURL.PerformLayout();
            this.groupSCRF.ResumeLayout(false);
            this.groupSCRF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.RadioButton radioBtnBackOffice;
        private System.Windows.Forms.RadioButton radioBtnAGM;
        private System.Windows.Forms.TextBox txtLoginUrl;
        private System.Windows.Forms.Label lblLabelToken;
        private System.Windows.Forms.Label lblLoginUrl;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox chkPasswordPlain;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label lblLoginName;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.Label lblServerUrl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TreeView m_treeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnNewFolder;
        private System.Windows.Forms.ToolStripButton toolBtnNew;
        private System.Windows.Forms.ToolStripButton toolBtnDuplicate;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnRemove;
        private System.Windows.Forms.ToolStripButton toolBtnReload;
        private System.Windows.Forms.RadioButton radioBtnNga;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupSCRF;
        private System.Windows.Forms.TextBox txtSCRFHeader;
        private System.Windows.Forms.TextBox txtSCRFValue;
        private System.Windows.Forms.TextBox txtSCRFCookie;
        private System.Windows.Forms.GroupBox groupBaseURL;
        private System.Windows.Forms.CheckBox chkCustomBaseURL;
        private System.Windows.Forms.TextBox txtBaseURL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.RadioButton radioBtnALM12_5;
        private System.Windows.Forms.RadioButton radioBtnALM12_0;
        private System.Windows.Forms.RadioButton radioBtnJenkins;

    }
}
