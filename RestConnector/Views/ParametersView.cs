using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hpe.Agm.RestConnector.Core;
using Hpe.Agm.RestConnector.Views.TreeManager;

namespace Hpe.Agm.RestConnector.Views
{
    public partial class ParametersView : UserControl, IViewHandler<ParameterInfo>
    {
        SharedData m_sharedData;
        TreeViewLogicManager<ParameterInfo> m_treeViewLogicManager;
        bool m_dirty = false;

        Dictionary<String, String> m_parameters = new Dictionary<string,string>();

        #region Ctor + Init

        public ParametersView()
        {
            InitializeComponent();
        }

        public void Init(SharedData sharedData)
        {
            m_sharedData = sharedData;
            m_treeViewLogicManager = new TreeViewLogicManager<ParameterInfo>(PersistanceManager.PARAMETERS_URLS_DIR, m_treeView, this);
            m_treeViewLogicManager.Init();
            m_sharedData.Parameters = m_parameters;
        }

        #endregion

        #region IViewHandler

        public ParameterInfo BuildNewItem()
        {
            return new ParameterInfo(txtValue.Text);
        }

        public void EnableButtons()
        {
            bool isAllRequiredFieldAreFilledForSet = !(String.IsNullOrEmpty(txtValue.Text));
            bool isSelected = m_treeView.SelectedNode != null;
            bool isLeaf = m_treeViewLogicManager.IsLeafSelected();

            toolBtnNew.Enabled = true;
            toolBtnSave.Enabled = IsDirty && !String.IsNullOrEmpty(txtName.Text);
            toolBtnRemove.Enabled = isSelected;
            toolBtnDuplicate.Enabled = isSelected && isLeaf;
        }

        public void RenderItem(String name, ParameterInfo item)
        {
            SetVisibility(true);
            txtName.Text = name;
            txtValue.Text = item.Value;
        }

        public void RenderFolder(String name)
        {
            SetVisibility(false);
            txtName.Text = name;
            SetVisibilityForName(true);
        }

        private void SetVisibility(bool isLeaf)
        {
            txtValue.Visible = isLeaf;
            lblValue.Visible = isLeaf;
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

        public string GetNameTextBoxValue()
        {
            return txtName.Text;
        }
        public string GetNodeText(String nodeName, ParameterInfo item)
        {
            m_parameters[nodeName] = item.Value;
            m_sharedData.FireOnDataChange();
            return nodeName + " : " + item.Value;
        }

        #endregion

        #region Events

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

        private void OnReloadClick(object sender, EventArgs e)
        {
            m_parameters.Clear();
            m_treeViewLogicManager.LoadSettings();
        }

        #endregion

    }
}
