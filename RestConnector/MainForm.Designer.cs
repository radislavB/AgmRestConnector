namespace AgmRestConnector
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBaseUrl = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPageExecution = new System.Windows.Forms.TabPage();
            this.tabParameters = new System.Windows.Forms.TabPage();
            this.tabPageAuthentication = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.connectionsView1 = new Hpe.Agm.RestConnector.Views.ConnectionsView();
            this.parametersView1 = new Hpe.Agm.RestConnector.Views.ParametersView();
            this.executionView1 = new Hpe.Agm.RestConnector.Views.ExecutionView();
            this.statusStrip1.SuspendLayout();
            this.tabPageExecution.SuspendLayout();
            this.tabParameters.SuspendLayout();
            this.tabPageAuthentication.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionStatus,
            this.lblBaseUrl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(948, 24);
            this.statusStrip1.TabIndex = 45;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(88, 19);
            this.lblConnectionStatus.Text = "Not Connected";
            this.lblConnectionStatus.ToolTipText = "Connection status";
            // 
            // lblBaseUrl
            // 
            this.lblBaseUrl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblBaseUrl.Name = "lblBaseUrl";
            this.lblBaseUrl.Size = new System.Drawing.Size(117, 19);
            this.lblBaseUrl.Text = "No base url selected";
            this.lblBaseUrl.ToolTipText = "Base Url";
            // 
            // tabPageExecution
            // 
            this.tabPageExecution.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageExecution.Controls.Add(this.executionView1);
            this.tabPageExecution.Location = new System.Drawing.Point(4, 22);
            this.tabPageExecution.Name = "tabPageExecution";
            this.tabPageExecution.Size = new System.Drawing.Size(940, 513);
            this.tabPageExecution.TabIndex = 3;
            this.tabPageExecution.Text = "Request and Response";
            // 
            // tabParameters
            // 
            this.tabParameters.Controls.Add(this.parametersView1);
            this.tabParameters.Location = new System.Drawing.Point(4, 22);
            this.tabParameters.Name = "tabParameters";
            this.tabParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabParameters.Size = new System.Drawing.Size(940, 513);
            this.tabParameters.TabIndex = 5;
            this.tabParameters.Text = "Parameters";
            this.tabParameters.UseVisualStyleBackColor = true;
            // 
            // tabPageAuthentication
            // 
            this.tabPageAuthentication.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAuthentication.Controls.Add(this.connectionsView1);
            this.tabPageAuthentication.Location = new System.Drawing.Point(4, 22);
            this.tabPageAuthentication.Name = "tabPageAuthentication";
            this.tabPageAuthentication.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuthentication.Size = new System.Drawing.Size(940, 513);
            this.tabPageAuthentication.TabIndex = 0;
            this.tabPageAuthentication.Text = "Authentication";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAuthentication);
            this.tabControl1.Controls.Add(this.tabParameters);
            this.tabControl1.Controls.Add(this.tabPageExecution);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(948, 539);
            this.tabControl1.TabIndex = 44;
            // 
            // connectionsView1
            // 
            this.connectionsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionsView1.IsDirty = false;
            this.connectionsView1.Location = new System.Drawing.Point(3, 3);
            this.connectionsView1.Name = "connectionsView1";
            this.connectionsView1.Size = new System.Drawing.Size(934, 507);
            this.connectionsView1.TabIndex = 0;
            this.connectionsView1.Load += new System.EventHandler(this.connectionsView1_Load);
            // 
            // parametersView1
            // 
            this.parametersView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersView1.IsDirty = false;
            this.parametersView1.Location = new System.Drawing.Point(3, 3);
            this.parametersView1.Name = "parametersView1";
            this.parametersView1.Size = new System.Drawing.Size(934, 507);
            this.parametersView1.TabIndex = 0;
            // 
            // executionView1
            // 
            this.executionView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executionView1.IsDirty = false;
            this.executionView1.Location = new System.Drawing.Point(0, 0);
            this.executionView1.Name = "executionView1";
            this.executionView1.Size = new System.Drawing.Size(940, 513);
            this.executionView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 563);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Alm Rest Connector";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPageExecution.ResumeLayout(false);
            this.tabParameters.ResumeLayout(false);
            this.tabPageAuthentication.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblBaseUrl;
        private System.Windows.Forms.TabPage tabPageExecution;
        private System.Windows.Forms.TabPage tabParameters;
        private System.Windows.Forms.TabPage tabPageAuthentication;
        private System.Windows.Forms.TabControl tabControl1;
        private Hpe.Agm.RestConnector.Views.ExecutionView executionView1;
        private Hpe.Agm.RestConnector.Views.ParametersView parametersView1;
        private Hpe.Agm.RestConnector.Views.ConnectionsView connectionsView1;

    }
}

