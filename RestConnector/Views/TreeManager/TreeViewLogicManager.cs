using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hpe.Agm.RestConnector.Core;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Hpe.Agm.RestConnector.Views.TreeManager;
using System.Drawing;

namespace Hpe.Agm.RestConnector.Views.TreeManager
{
    public class TreeViewLogicManager<T> where T : DictionaryBasedEntity
    {
        static ImageList s_imageList;

        PersistanceManager m_persistanceManager = PersistanceManager.GetInstance();
        String m_persistencyPath;
        TreeView m_treeView;
        IViewHandler<T> m_viewHandler;
        FolderNodeHandler m_folderNodeHandler = null;
        SettingNodeHandler<T> m_settingNodeHandler = null;

        public TreeViewLogicManager(String persistencyPath, TreeView treeView, IViewHandler<T> viewHandler)
        {
            m_persistencyPath = persistencyPath;
            m_viewHandler = viewHandler;
            m_treeView = treeView;

        }

        public void Init()
        {
            m_folderNodeHandler = new FolderNodeHandler(m_treeView, m_persistencyPath);
            m_settingNodeHandler = new SettingNodeHandler<T>(m_treeView, m_persistencyPath);


            m_treeView.TreeViewNodeSorter = new TreeViewSorter();
            m_treeView.AfterSelect += OnTreeViewAfterSelect;
            m_treeView.BeforeSelect += OnTreeViewBeforeSelect;
            m_treeView.ImageList = GetImageList();

            m_viewHandler.HideAll();
            LoadSettings();
            DefineDragDrop();
            m_viewHandler.EnableButtons();
        }

        #region DragDrop

        private void DefineDragDrop()
        {
            //https://support.microsoft.com/en-us/kb/307968
            m_treeView.AllowDrop = true;
            m_treeView.ItemDrag += OnItemDrag;
            m_treeView.DragEnter += OnDragEnter;
            m_treeView.DragDrop += OnDragDrop;
        }

        private void OnDragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = ((TreeView)sender).GetNodeAt(pt);
                TreeNode sourceNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                TreeNode targetParent = GetParentForAddMethod(targetNode);

                bool isAllowed = !(targetParent == sourceNode.Parent || targetParent == sourceNode);
                if (!isAllowed)
                {
                    return;//no move
                }

                String parentName = targetParent == null ? "Top-level" : targetParent.Text;
                String message = String.Format("Are you sure you want to move <{0}> under <{1}> folder", sourceNode.Name, parentName);
                if (MessageBox.Show(message, "Move", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetNodeHandler(IsLeafSelected()).Move(sourceNode, targetParent);
                }

            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;



        }

        private void OnItemDrag(object sender, ItemDragEventArgs e)
        {
            m_treeView.SelectedNode = (TreeNode)e.Item;
            m_treeView.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        #endregion

        private void OnTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            bool isLeaf = IsLeafSelected();

            if (isLeaf)
            {
                T item = (T)m_treeView.SelectedNode.Tag;
                m_viewHandler.RenderItem(GetSelectedName(), item);
            }
            else
            {
                m_viewHandler.RenderFolder(GetSelectedName());
            }

            m_viewHandler.IsDirty = false;
            m_viewHandler.EnableButtons();
        }

        private void OnTreeViewBeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (!HandleChangesBeforeNewOperation())
            {
                e.Cancel = true;
            }
        }

        //return true to continue the operation and false to cancel the operation
        public bool HandleChangesBeforeNewOperation()
        {
            if (m_viewHandler.IsDirty)
            {
                String message = "You have unsaved changes. Press \"Yes\" if you want to save your changes and  \"No\" otherwise. Press of \"Cancel\" will cancel current operation.";
                DialogResult dr = MessageBox.Show(message, "Save changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                else if (dr == DialogResult.Yes)
                {
                    bool updated = UpdateSelectedInternal();
                    if (!updated)
                    {
                        return false;
                    }

                }
                else//NO
                {
                    m_viewHandler.IsDirty = false;
                }
            }
            return true;
        }

        private NodeHandler GetNodeHandler(bool isSetting)
        {
            if (isSetting)
            {
                return m_settingNodeHandler;
            }
            else
            {
                return m_folderNodeHandler;
            };
        }

        public void LoadSettings()
        {
            if (!HandleChangesBeforeNewOperation())
            {
                return;
            }
            m_treeView.Nodes.Clear();
            Dictionary<String, T> settings = m_persistanceManager.LoadSettings<T>(m_persistencyPath);
            TreeNode root = m_folderNodeHandler.AddNode(null, "Root");
            foreach (String name in settings.Keys)
            {
                String[] pathParths = name.Split(Path.DirectorySeparatorChar);

                TreeNode parent = root;
                for (int i = 0; i < pathParths.Length; i++)
                {
                    String nodeName = pathParths[i];

                    TreeNode node = m_folderNodeHandler.GetChildByName(parent, nodeName);
                    if (node == null)
                    {
                        bool isLeaf = (i == pathParths.Length - 1);
                        if (isLeaf)
                        {
                            T item = settings[name];
                            node = m_settingNodeHandler.AddNode(parent, nodeName, item);
                            UpdateNodeText(node);

                        }
                        else // folder
                        {
                            node = m_folderNodeHandler.AddNode(parent, nodeName);
                        }
                    }
                    parent = node;
                }
            }
            root.Expand();

            m_treeView.Sort();

            if (m_treeView.Nodes.Count > 0)
            {
                m_treeView.SelectedNode = m_treeView.Nodes[0];
            }

        }

        private void UpdateNodeText(TreeNode node)
        {
            String text = m_viewHandler.GetNodeText(node.Name, (T)node.Tag);
            if (text != null)
            {
                node.Text = text;
            }
        }

        public bool UpdateSelected()
        {
            TreeNode selected = m_treeView.SelectedNode;
            bool updated = UpdateSelectedInternal();

            if (updated)
            {
                m_viewHandler.IsDirty = false;
                m_treeView.Sort();
                m_treeView.SelectedNode = selected;
            }

            return updated;
        }

        private bool UpdateSelectedInternal()
        {

            bool updated = false;
            String name = m_viewHandler.GetNameTextBoxValue();
            if (IsLeafSelected())
            {
                updated = m_settingNodeHandler.Update(m_treeView.SelectedNode, name, name, m_viewHandler.BuildNewItem());
                UpdateNodeText(m_treeView.SelectedNode);
            }
            else
            {
                updated = m_folderNodeHandler.Update(m_treeView.SelectedNode, name);
            }
            
            m_viewHandler.IsDirty = false;
            return updated;
        }

        public void AddNewItem()
        {
            if (!HandleChangesBeforeNewOperation())
            {
                return;
            }

            TreeNode parent = GetParentForAddMethod(m_treeView.SelectedNode);
            TreeNode node = m_settingNodeHandler.AddNew(parent);
            m_treeView.Sort();
            m_treeView.SelectedNode = node;


            m_viewHandler.EnableButtons();
        }

        public void AddNewFolder()
        {
            if (!HandleChangesBeforeNewOperation())
            {
                return;
            }

            TreeNode parent = GetParentForAddMethod(m_treeView.SelectedNode);

            TreeNode node = m_folderNodeHandler.AddNew(parent);
            m_treeView.Sort();
            m_treeView.SelectedNode = node;

            m_viewHandler.EnableButtons();
        }

        private TreeNode GetParentForAddMethod(TreeNode node)
        {
            TreeNode parent = null;
            if (node != null)
            {
                if (TreeNodeUtilities.IsFolder(node))
                {
                    parent = node;
                }
                else
                {
                    parent = node.Parent;
                }
            }
            return parent;
        }

        public void DuplicateSelected()
        {
            if (!HandleChangesBeforeNewOperation())
            {
                return;
            }

            TreeNode node = m_settingNodeHandler.Duplicate(m_treeView.SelectedNode);
            m_treeView.Sort();

            UpdateNodeText(node);

            m_treeView.SelectedNode = node;
            m_viewHandler.EnableButtons();
        }

        public TreeNode DeleteSelected()
        {
            TreeNode deleted = null;
            String message = String.Format("Are you sure you want delete <{0}>?", m_treeView.SelectedNode.Name);
            if (MessageBox.Show(message, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_viewHandler.IsDirty = false;

                deleted = m_treeView.SelectedNode;
                GetNodeHandler(IsLeafSelected()).Delete(deleted);

                if (m_treeView.Nodes.Count == 0)
                {
                    m_viewHandler.HideAll();
                }
                m_viewHandler.EnableButtons();
            }

            return deleted;
        }

        public String GetSelectedName()
        {
            if (m_treeView.SelectedNode != null)
            {
                return m_treeView.SelectedNode.Name;
            }
            return null;
        }

        public T GetSelectedItem()
        {
            if (m_treeView.SelectedNode != null)
            {
                return (T)m_treeView.SelectedNode.Tag;
            }
            return null;
        }

        public bool IsLeafSelected()
        {
            return IsLeaf(m_treeView.SelectedNode);
        }

        public bool IsLeaf(TreeNode node)
        {
            if (node != null)
            {
                return TreeNodeUtilities.IsLeaf(node);
            }
            return false;
        }

        public static ImageList GetImageList()
        {
            if (s_imageList == null)
            {
                s_imageList = new ImageList();
                s_imageList.ColorDepth = ColorDepth.Depth32Bit;
                s_imageList.TransparentColor = SystemColors.Control;
                s_imageList.Images.Add(TreeNodeUtilities.IMAGE_KEY_FOLDER, Properties.Resources.HPopenfoldericon);
                s_imageList.Images.Add(TreeNodeUtilities.IMAGE_KEY_DOCUMENT, Properties.Resources.document);
            }
            return s_imageList;
        }
    }
}
