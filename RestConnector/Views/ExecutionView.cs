using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Hpe.Agm.RestConnector.Core;
using Hpe.Agm.RestConnector.Views.TreeManager;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace Hpe.Agm.RestConnector.Views
{
    public partial class ExecutionView : UserControl, IViewHandler<RequestInfo>
    {
        SharedData m_sharedData;
        TreeViewLogicManager<RequestInfo> m_treeViewLogicManager;

        bool m_dirty = false;

        Dictionary<string, string> m_headers = new Dictionary<string, string>();

        String CONTENT_TYPE_HEADER = "Content-Type";
        String ACCEPT_HEADER = "Accept";
        String USER_AGENT_HEADER = "User-Agent";
        String HOST_HEADER = "Host";
        String CONNECTION_HEADER = "Connection";
        String PUT_METHOD = "PUT";
        String POST_METHOD = "POST";
        bool ignoreNotConnected;
        Regex parametersRegex = new Regex("{(.*?)}");
        #region Ctor + Init

        public ExecutionView()
        {
            InitializeComponent();
        }

        public void Init(SharedData sharedData)
        {
            SetVisibilityForName(false);

            m_sharedData = sharedData;
            m_sharedData.OnDataChanged += new EventHandler(OnSharedDataChanged);
            m_treeViewLogicManager = new TreeViewLogicManager<RequestInfo>(PersistanceManager.REQUESTS_URLS_DIR, m_treeView, this);
            m_treeViewLogicManager.Init();

            cmbRequestMethod.SelectedIndex = 0;

            m_dirty = false;
        }

        #endregion

        #region Logics

        private void FillListViewHeader()
        {
            listHeaders.Items.Clear();
            foreach (KeyValuePair<string, string> entry in m_headers)
            {
                String valueWithReplaceParameters = replaceParameters(entry.Value);
                String nodeText = entry.Key + ":" + entry.Value;
                if (!valueWithReplaceParameters.Equals(entry.Value))
                {
                    nodeText = entry.Key + ":" + valueWithReplaceParameters + "              (" + entry.Value + ")";
                }

                listHeaders.Items.Add(entry.Key, nodeText, null);
            }
        }

        /*
         * Return true if request was successful
         */
        private bool SendAndOutput(String url, String method, String data, String tenantId, Dictionary<string, string> headers)
        {

            Dictionary<string, string> newHeaders = new Dictionary<string, string>();
            List<String> keys = new List<String>(headers.Keys);
            foreach (String key in keys)
            {
                newHeaders[key] = replaceParameters(headers[key]);
            }

            HttpWebResponse response = null;
            String output;
            String outputStatus;

            try
            {
                response = Send(url, tenantId, method, data, newHeaders);
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    output = streamReader.ReadToEnd();
                }

                outputStatus = response.StatusCode.ToString();
                SetOutput(outputStatus, output);

            }
            catch (WebException ex)
            {


                output = ex.Message;
                outputStatus = "Failed";
                SetOutput(outputStatus, output);


                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        String errorMessage = reader.ReadToEnd();
                        richConsole.AppendText("\n");
                        richConsole.AppendText(errorMessage);
                    }
                }

            }

            PersistanceManager.GetInstance().SaveToLog(m_sharedData.ConnectedUser, tenantId, url, method, m_headers, data, outputStatus, output);
            return outputStatus != "Failed"; ;
        }

        private HttpWebResponse Send(string url, string tenantId, string method, string data, Dictionary<string, string> headers)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = method;
            httpWebRequest.Timeout = (int)TimeSpan.FromMinutes(90).TotalMilliseconds;//default is 100 sec


            if (headers != null && headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> keyValue in headers)
                {
                    String keyLowerCase = keyValue.Key.ToLower();
                    if (keyLowerCase.Equals(CONTENT_TYPE_HEADER.ToLower()))
                    {
                        httpWebRequest.ContentType = keyValue.Value;
                    }
                    else if (keyLowerCase.Equals(ACCEPT_HEADER.ToLower()))
                    {
                        httpWebRequest.Accept = keyValue.Value;
                    }
                    else if (keyLowerCase.Equals(USER_AGENT_HEADER.ToLower()))
                    {
                        httpWebRequest.UserAgent = keyValue.Value;
                    }
                    else if (keyLowerCase.Equals(HOST_HEADER.ToLower()))
                    {
                        httpWebRequest.Host = keyValue.Value;
                    }
                    else if (keyLowerCase.Equals(CONNECTION_HEADER.ToLower()))
                    {
                        httpWebRequest.Connection = keyValue.Value;
                    }
                    else
                    {
                        httpWebRequest.Headers.Add(keyValue.Key, keyValue.Value);
                    }
                }
            }


            String host = httpWebRequest.RequestUri.Host;
            httpWebRequest.CookieContainer = new CookieContainer();
            if (!String.IsNullOrEmpty(m_sharedData.SecurityToken))
            {
                Cookie lwssoCookie = new Cookie("LWSSO_COOKIE_KEY", m_sharedData.SecurityToken) { Domain = host };
                httpWebRequest.CookieContainer.Add(lwssoCookie);
            }

            if (m_sharedData.AdditionalCookies != null)
            {
                foreach (var keyValuPair in m_sharedData.AdditionalCookies)
                {
                    Cookie cookie = new Cookie(keyValuPair.Key, keyValuPair.Value) { Domain = host };
                    httpWebRequest.CookieContainer.Add(cookie);
                }

            }

            if (!String.IsNullOrEmpty(tenantId))
            {
                Cookie tenantCookie = new Cookie("TENANT_ID_COOKIE", tenantId) { Domain = host }; ;
                httpWebRequest.CookieContainer.Add(tenantCookie);
            }



            //set csrf
            if (!String.IsNullOrEmpty(m_sharedData.CsrfValue))
            {
                if (!String.IsNullOrEmpty(m_sharedData.CsrfCookie))
                {
                    Cookie csrfCookie = new Cookie(m_sharedData.CsrfCookie, m_sharedData.CsrfValue) { Domain = host };
                    httpWebRequest.CookieContainer.Add(csrfCookie);
                }

                if (!String.IsNullOrEmpty(m_sharedData.CsrfHeader))
                {
                    httpWebRequest.Headers.Add(m_sharedData.CsrfHeader, m_sharedData.CsrfValue);
                }
            }

            if (!String.IsNullOrEmpty(data))
            {
                method = method.ToUpper();
                if ((POST_METHOD.Equals(method) || PUT_METHOD.Equals(method)))
                {
                    byte[] byteData = Encoding.UTF8.GetBytes(data);
                    httpWebRequest.ContentLength = byteData.Length;
                    using (Stream postStream = httpWebRequest.GetRequestStream())
                    {
                        postStream.Write(byteData, 0, byteData.Length);
                    }
                }
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //update security token if it was modified
            String setCookieAll = httpResponse.GetResponseHeader("Set-Cookie");
            String[] setCookies = setCookieAll.Split(';');
            foreach (String setCookie in setCookies)
            {
                if (setCookie.StartsWith("LWSSO_COOKIE_KEY"))
                {
                    String[] setCookiesParts = setCookie.Split('=');
                    String token = setCookiesParts[1];
                    m_sharedData.UpdateSecurityToken(token);
                }
            }

            //update security token if it was modified
            /*Cookie updatedLwssoCookie = httpResponse.Cookies["LWSSO_COOKIE_KEY"];
            if (updatedLwssoCookie != null)
            {
                String updateSecurityToken = updatedLwssoCookie.Value;
                if (!String.IsNullOrEmpty(updateSecurityToken) && !updateSecurityToken.Equals(m_sharedData.SecurityToken))
                {
                    m_sharedData.UpdateSecurityToken(updateSecurityToken);
                }
            }*/

            return httpResponse;

        }

        #endregion

        #region Events

        private void OnSharedDataChanged(object sender, EventArgs e)
        {
            OnUrlTextChanged(null, null);
            IsDirty = false;
        }

        private void OnAddHeaderClick(object sender, EventArgs e)
        {
            if (txtHeaderName.Text.Trim().Length > 0)
            {
                String key = txtHeaderName.Text.Trim();
                String value = txtHeaderValue.Text.Trim();
                m_headers.Remove(key);
                m_headers.Add(key, value);

                txtHeaderName.Text = "";
                txtHeaderValue.Text = "";

                FillListViewHeader();
                OnValueChanged(null, null);
            }
        }

        private void OnRemoveHeaderClick(object sender, EventArgs e)
        {
            if (listHeaders.SelectedItems.Count > 0)
            {
                ListViewItem item = listHeaders.SelectedItems[0];
                m_headers.Remove(item.Name);
                listHeaders.Items.Remove(item);
                OnValueChanged(null, null);
            }
        }

        private void OnSendClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(m_sharedData.SecurityToken))
            {
                if (!ignoreNotConnected && MessageBox.Show("You are still not connected. Are you sure you want to send the request ?", "Question", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                ignoreNotConnected = true;
            }

            String url = txtFullUrl.Text;
            String method = cmbRequestMethod.SelectedItem.ToString();
            String data = richData.Text;
            String tenantId = txtTenantId.Text;

            ClearOutput();
            SetOutput(null, "Sending request : " + url);
            SendAndOutput(url, method, data, tenantId, m_headers);
        }

        private void OnSendAllClick(object sender, EventArgs e)
        {
            String message = String.Format("Are you sure you want to send all requests of <{0}>?", m_treeView.SelectedNode.Name);
            if (MessageBox.Show(message, "Send All", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (String.IsNullOrEmpty(m_sharedData.SecurityToken))
            {
                if (MessageBox.Show("You are still not connected. Are you sure you want to continue ?", "Question", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            ClearOutput();
            bool continueSending = true;
            foreach (TreeNode node in m_treeView.SelectedNode.Nodes)
            {

                if (!m_treeViewLogicManager.IsLeaf(node))
                {
                    continue;
                }

                RequestInfo request = (RequestInfo)node.Tag;

                String url = m_sharedData.BaseUrl + request.Url;
                SetOutput(null, String.Format("{0}. {1}: {2}", node.Index + 1, node.Name, url));
                continueSending = SendAndOutput(url, request.Method, request.Data, request.TenantId, request.Headers);

                if (!continueSending)
                {
                    break;
                }
            }
        }

        private void ClearOutput()
        {
            richConsole.Clear();
        }

        private void SetOutput(String statusCode, String text)
        {
            //RAW
            richConsole.AppendText(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
            if (!String.IsNullOrEmpty(statusCode))
            {
                richConsole.AppendText("\nResponse status : " + statusCode);
            }

            richConsole.AppendText("\n");
            richConsole.AppendText(text);
            richConsole.AppendText("\n\n");

            richConsole.SelectionStart = richConsole.Text.Length;
            richConsole.ScrollToCaret();
            Application.DoEvents();
        }

        private void OnUrlTextChanged(object sender, EventArgs e)
        {
            if (!txtUrl.Text.ToLower().StartsWith("http"))
            {
                txtFullUrl.Text = m_sharedData.BaseUrl + txtUrl.Text;
            }

            txtFullUrl.Text = replaceParameters(txtFullUrl.Text);

            OnValueChanged(null, null);

        }

        private String replaceParameters(String value)
        {
            MatchCollection matches = parametersRegex.Matches(value);
            List<String> keys = new List<string>();
            foreach (Match match in matches)
            {
                string key = match.Groups[1].Value;
                keys.Add(key);
            }

            //replace keys with values
            foreach (var key in keys)
            {
                if (m_sharedData.Parameters.ContainsKey(key))
                {
                    value = value.Replace("{" + key + "}", m_sharedData.Parameters[key]);
                }
            }
            return value;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            IsDirty = true;
            EnableButtons();
        }

        private void OnNewItemClick(object sender, EventArgs e)
        {
            m_treeViewLogicManager.AddNewItem();
        }

        private void OnReloadClick(object sender, EventArgs e)
        {
            m_treeViewLogicManager.LoadSettings();
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
                //btnSend.PerformClick();
            }
        }
        #endregion

        #region IViewHandler

        public RequestInfo BuildNewItem()
        {
            RequestInfo info = new RequestInfo(txtUrl.Text, txtTenantId.Text, (String)cmbRequestMethod.SelectedItem, richData.Text, new Dictionary<string, string>(m_headers));
            return info;
        }

        public void RenderItem(String name, RequestInfo item)
        {
            SetVisibility(true);

            txtName.Text = name;
            txtUrl.Text = item.Url;
            txtTenantId.Text = item.TenantId;
            richData.Text = item.Data;
            cmbRequestMethod.SelectedItem = item.Method;
            m_headers = item.Headers;

            FillListViewHeader();
        }

        public void RenderFolder(String name)
        {
            SetVisibility(false);
            txtName.Text = name;
        }

        private void SetVisibility(bool isLeaf)
        {
            groupBoxHeaders.Visible = isLeaf;
            groupBoxRequest.Visible = isLeaf;

            btnSend.Visible = isLeaf;
            btnSendAll.Visible = !isLeaf;

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

            bool isAllRequiredFieldAreFilledForSet = !(String.IsNullOrEmpty(txtUrl.Text));
            bool isSelected = m_treeView.SelectedNode != null;
            bool isLeaf = m_treeViewLogicManager.IsLeafSelected();

            btnSend.Enabled = isSelected && isLeaf && isAllRequiredFieldAreFilledForSet;
            toolBtnNew.Enabled = true;
            toolBtnSave.Enabled = IsDirty && !String.IsNullOrEmpty(txtName.Text);
            toolBtnRemove.Enabled = isSelected;
            toolBtnDuplicate.Enabled = isSelected && isLeaf;
        }

        public string GetNameTextBoxValue()
        {
            return txtName.Text;
        }
        public string GetNodeText(String nodeName, RequestInfo item)
        {
            return null;
        }

        #endregion

        private void formatJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String data = richData.Text;
            var serializer = new JavaScriptSerializer();
            Dictionary<String, Object> d = (Dictionary<String, Object>)serializer.Deserialize(data, typeof(Dictionary<String, Object>));
            String s = serializer.Serialize(d);
            richData.Text = s;

        }


        private void listHeaders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listHeaders.SelectedItems.Count > 0)
            {
                ListViewItem item = listHeaders.SelectedItems[0];
                String[] arr = item.Text.Split(':');
                if (arr.Length >= 2)
                {
                    txtHeaderName.Text = arr[0];
                    txtHeaderValue.Text = arr[1];
                }

            }
        }

    }
}
