using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hpe.Agm.RestConnector.Core;
using System.Net;
using AgmRestConnector;
using System.Web.Script.Serialization;
using System.IO;
using Hpe.Agm.RestConnector.Views.TreeManager;
using Hpe.Agm.RestConnector.Views.Authentication;

namespace Hpe.Agm.RestConnector.Views
{
    public partial class ConnectionsView : UserControl, IViewHandler<ConnectionInfo>
    {
        SharedData m_sharedData;
        TreeViewLogicManager<ConnectionInfo> m_treeViewLogicManager;
        bool m_dirty = false;

        Dictionary<ServerType, BaseAuthenticationStrategy> authenticationStrategies = new Dictionary<ServerType, BaseAuthenticationStrategy>();

        #region Ctor+ Init

        public ConnectionsView()
        {
            InitializeComponent();
        }

        public void Init(SharedData sharedData)
        {
            authenticationStrategies.Add(ServerType.AGM, new AgmAuthenticationStrategy());
            authenticationStrategies.Add(ServerType.NGA, new NgaAuthenticationStrategy());
            authenticationStrategies.Add(ServerType.BO, new BoAuthenticationStrategy());
            authenticationStrategies.Add(ServerType.ALM12_5, new Alm12_5AuthenticationStrategy());
            authenticationStrategies.Add(ServerType.ALM12_0, new Alm12_0AuthenticationStrategy());
            authenticationStrategies.Add(ServerType.Jenkins, new JenkinsAuthenticationStrategy());

            m_sharedData = sharedData;
            m_treeViewLogicManager = new TreeViewLogicManager<ConnectionInfo>(PersistanceManager.CONNECTIONS_DIR, m_treeView, this);
            m_treeViewLogicManager.Init();
            UpdateGetTokenUrl();
            UpdatePasswordPlainText();


        }

        #endregion

        #region Logics

        private void UpdateGetTokenUrl()
        {
            txtSCRFCookie.Text = "";
            txtSCRFHeader.Text = "";
            txtSCRFValue.Text = "";

            String temp = txtServerUrl.Text.Trim(new char[] { '/', ' ' });
            BaseAuthenticationStrategy authenticationStrategy = GetAuthenticationStrategy();
            txtLoginUrl.Text = temp + authenticationStrategy.GetAuthenticationSuffixUrl();
            txtSCRFCookie.Text = authenticationStrategy.GetSCRFCookieName();
            txtSCRFHeader.Text = authenticationStrategy.GetSCRFHeaderName();
        }

        private void UpdatePasswordPlainText()
        {
            txtPassword.UseSystemPasswordChar = !chkPasswordPlain.Checked;
            txtPassword.Focus();
            txtPassword.SelectionStart = txtPassword.Text.Length;
        }


        private void Login()
        {
            
      
            String timeNow = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " : ";
            try
            {
                BaseAuthenticationStrategy baseAuthentication = GetAuthenticationStrategy();
                AuthenticationResult authenticationResult = baseAuthentication.Authenticate(txtBaseURL.Text, txtLoginName.Text, txtPassword.Text);
                
                if (authenticationResult.LwssoToken != null)
                {
                    txtToken.Text = timeNow + "Token received successfully to " + txtLoginName.Text;
                    txtToken.ForeColor = Color.Green;
                    txtSCRFValue.Text = authenticationResult.CsrfToken;

                    txtSCRFCookie.Text = GetAuthenticationStrategy().GetSCRFCookieName();
                    txtSCRFHeader.Text = GetAuthenticationStrategy().GetSCRFHeaderName();

                    m_sharedData.InitSecurityContext(txtLoginName.Text, authenticationResult.LwssoToken, authenticationResult.Cookies);
                    m_sharedData.InitBaseUrl(txtBaseURL.Text, txtBaseURL.Text);
                    m_sharedData.SetCSRFContext(txtSCRFCookie.Text, txtSCRFHeader.Text, txtSCRFValue.Text);
                }
                else
                {
                    txtToken.Text = timeNow + "Received null instead of token";
                    txtToken.ForeColor = Color.Red;
                    m_sharedData.ClearSecurityContext();
                }

            }
            catch (Exception ex)
            {
                txtToken.Text = timeNow + "Failed to get token : " + ex.Message;
                txtToken.ForeColor = Color.Red;
                m_sharedData.ClearSecurityContext(); ;
            }
        }

        private BaseAuthenticationStrategy GetAuthenticationStrategy()
        {
            ServerType serverType;
            if (radioBtnAGM.Checked)
            {
                serverType = ServerType.AGM;
            }
            else if (radioBtnALM12_5.Checked)
            {
                serverType = ServerType.ALM12_5;
            }
            else if (radioBtnALM12_0.Checked)
            {
                serverType = ServerType.ALM12_0;
            }
            else if (radioBtnBackOffice.Checked)
            {
                serverType = ServerType.BO;
            }
            else if (radioBtnJenkins.Checked)
            {
                serverType = ServerType.Jenkins;
            }
            else
            {
                serverType = ServerType.NGA;
            }

            BaseAuthenticationStrategy baseAuthentication = authenticationStrategies[serverType];
            return baseAuthentication;
        }



        #endregion

        #region Events

        private void OnReloadClick(object sender, EventArgs e)
        {
            m_treeViewLogicManager.LoadSettings();

        }

        private void OnRadioBtnCheckedChanged(object sender, EventArgs e)
        {
            IsDirty = true;
            UpdateGetTokenUrl();
            EnableButtons();
        }

        private void OnServerUrlTextChanged(object sender, EventArgs e)
        {
            UpdateGetTokenUrl();
            UpdateBaseUrl();
            OnTextValueChanged(sender, e);
        }

        private void OnChkPasswordPlainCheckedChanged(object sender, EventArgs e)
        {
            UpdatePasswordPlainText();
        }

        private void OnConnectClick(object sender, EventArgs e)
        {
            Login();

        }

        private void OnTextValueChanged(object sender, EventArgs e)
        {
            IsDirty = true;
            EnableButtons();
        }

        private void OnNewItemClick(object sender, EventArgs e)
        {
            m_treeViewLogicManager.AddNewItem();
        }

        private void OnNewFolderClick(object sender, EventArgs e)
        {
            m_treeViewLogicManager.AddNewFolder();
        }

        private void OnDuplicateClick(object sender, EventArgs e)
        {
            m_treeViewLogicManager.DuplicateSelected();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            m_treeViewLogicManager.UpdateSelected();
        }

        private void OnRemoveClick(object sender, EventArgs e)
        {
            m_treeViewLogicManager.DeleteSelected();
        }

        private void OnNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (m_treeViewLogicManager.IsLeafSelected())
            {
                btnConnect.PerformClick();
            }
        }

        #endregion

        #region IViewHandler

        public ConnectionInfo BuildNewItem()
        {

            ServerType serverType = ServerType.NGA;
            if(radioBtnAGM.Checked){
                serverType = ServerType.AGM;
            }
            else if (radioBtnBackOffice.Checked)
            {
                serverType = ServerType.BO;
            }
            else if (radioBtnALM12_5.Checked)
            {
                serverType = ServerType.ALM12_5;
            }
            else if (radioBtnALM12_0.Checked)
            {
                serverType = ServerType.ALM12_0;
            }
            else if (radioBtnJenkins.Checked)
            {
                serverType = ServerType.Jenkins;
            }

            ConnectionInfo newConnection = new ConnectionInfo(txtLoginName.Text, txtPassword.Text, txtServerUrl.Text, serverType, chkCustomBaseURL.Checked, txtBaseURL.Text);
            return newConnection;
        }

        public void RenderItem(String name, ConnectionInfo item)
        {
            SetVisibility(true);

            txtName.Text = name;
            txtLoginName.Text = item.LoginName;
            txtPassword.Text = item.Password;
            txtServerUrl.Text = item.ServerUrl;
            if (item.ServerType == ServerType.AGM)
            {
                radioBtnAGM.Checked = true;
            }
            else if (item.ServerType == ServerType.BO)
            {
                radioBtnBackOffice.Checked = true;
            }
            else if (item.ServerType == ServerType.ALM12_5)
            {
                radioBtnALM12_5.Checked = true;
            }
            else if (item.ServerType == ServerType.ALM12_0)
            {
                radioBtnALM12_0.Checked = true;
            }
            else if (item.ServerType == ServerType.NGA)
            {
                radioBtnNga.Checked = true;
            }
            else if (item.ServerType == ServerType.Jenkins)
            {
                radioBtnJenkins.Checked = true;
            }
            else
            {
                radioBtnNga.Checked = true;
            }

            if (item.IsBaseUrlCustom)
            {
                chkCustomBaseURL.Checked = true;
                txtBaseURL.Text = item.CustomBaseUrl;
            }
            else
            {
                chkCustomBaseURL.Checked = false;
            }

            UpdateGetTokenUrl();
            UpdateBaseUrl();

        }

        public void RenderFolder(String name)
        {
            SetVisibility(false);
            txtName.Text = name;
        }

        private void SetVisibility(bool isLeaf)
        {
            txtLoginName.Visible = isLeaf;
            lblLoginName.Visible = isLeaf;

            txtPassword.Visible = isLeaf;
            lblPassword.Visible = isLeaf;
            chkPasswordPlain.Visible = isLeaf;

            txtServerUrl.Visible = isLeaf;
            lblServerUrl.Visible = isLeaf;
            radioBtnAGM.Visible = isLeaf;
            radioBtnBackOffice.Visible = isLeaf;
            radioBtnNga.Visible = isLeaf;
            radioBtnALM12_5.Visible = isLeaf;
            radioBtnALM12_0.Visible = isLeaf;
            radioBtnJenkins.Visible = isLeaf;

            txtLoginUrl.Visible = isLeaf;
            lblLoginUrl.Visible = isLeaf;

            txtToken.Visible = isLeaf;
            lblLabelToken.Visible = isLeaf;

            btnConnect.Visible = isLeaf;
            groupSCRF.Visible = isLeaf;
            groupBaseURL.Visible = isLeaf;

            SetVisibilityForName(true);
        }

        private void SetVisibilityForName(bool visible)
        {
            txtName.Visible = visible;
            lblName.Visible = visible;
        }

        public void HideAll()
        {
            SetVisibility(false);
            SetVisibilityForName(false);
        }

        public bool IsDirty
        {
            get { return m_dirty; }
            set { m_dirty = value; }
        }

        public void EnableButtons()
        {

            bool isAllRequiredFieldAreFilledForSet = !(String.IsNullOrEmpty(txtLoginName.Text)) || radioBtnJenkins.Checked;
            bool isSelected = m_treeView.SelectedNode != null;
            bool isLeaf = m_treeViewLogicManager.IsLeafSelected();

            btnConnect.Enabled = isSelected && isLeaf && isAllRequiredFieldAreFilledForSet;
            toolBtnNew.Enabled = true;
            toolBtnSave.Enabled = IsDirty && !String.IsNullOrEmpty(txtName.Text);
            toolBtnRemove.Enabled = isSelected;
            toolBtnDuplicate.Enabled = isSelected && isLeaf;

        }

        public string GetNameTextBoxValue()
        {
            return txtName.Text;
        }
        public string GetNodeText(String nodeName, ConnectionInfo item)
        {
            return null;
        }


        #endregion

        private void OnCustomBaseURLCheckedChanged(object sender, EventArgs e)
        {
            OnTextValueChanged(sender, e);
            txtBaseURL.ReadOnly = !chkCustomBaseURL.Checked;
            UpdateBaseUrl();
        }

        private void UpdateBaseUrl()
        {
            if (!chkCustomBaseURL.Checked)
            {
                txtBaseURL.Text = txtServerUrl.Text;
            }

        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (chkCustomBaseURL.Checked)
            {
                OnTextValueChanged(sender, e);
            }

        }

        private void radioBtnALM_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
