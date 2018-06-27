using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Hpe.Agm.RestConnector.Core;

namespace AgmRestConnector
{
    public partial class MainForm : Form
    {


        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        SharedData m_sharedData = new SharedData();
        public MainForm()
        {
            InitializeComponent();
            UpdateFormText();
            OnSharedDataUpdated(null, null);

            m_sharedData.OnDataChanged += new EventHandler(OnSharedDataUpdated);
            connectionsView1.Init(m_sharedData);
            parametersView1.Init(m_sharedData);
            executionView1.Init(m_sharedData);
        }

        private void UpdateFormText()
        {
            Version v = this.GetType().Assembly.GetName().Version;
            this.Text += " " + v.Major + "." + v.Minor + "." + v.Build;
        }

        private void OnSharedDataUpdated(object sender, EventArgs e)
        {
            //CONNECTION 
            String statusText = "Not Connected";
            if (m_sharedData.SecurityToken != null)
            {
                statusText = "Connected as " + m_sharedData.ConnectedUser;
            }
            lblConnectionStatus.Text = statusText;



            //BASE URL
            String baseUrlText = "No base url selected";
            if (!String.IsNullOrEmpty(m_sharedData.BaseUrl))
            {
                if (!String.IsNullOrEmpty(m_sharedData.BaseUrlLabel))
                {
                    baseUrlText = "Base Url : " + m_sharedData.BaseUrlLabel;
                }
                else
                {
                    baseUrlText = "Base Url : " + m_sharedData.BaseUrl;
                }
            }

            lblBaseUrl.Text = baseUrlText;
        }

        private void connectionsView1_Load(object sender, EventArgs e)
        {

        }
    }
}
