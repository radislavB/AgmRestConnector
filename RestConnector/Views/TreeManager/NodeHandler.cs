using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hpe.Agm.RestConnector.Core;

namespace Hpe.Agm.RestConnector.Views.TreeManager
{
    public abstract class NodeHandler
    {
        protected TreeView m_treeView;
        protected String m_persistencyPath;
        protected PersistanceManager m_persistanceManager = PersistanceManager.GetInstance();

        public NodeHandler(TreeView treeView, String persistencyPath)
        {
            m_treeView = treeView;
            m_persistencyPath = persistencyPath;
        }

        public TreeNodeCollection GetParentNodes(TreeNode parent)
        {
            return parent == null ? m_treeView.Nodes : parent.Nodes;
        }

        public String FindAvailableName(TreeNode parent, String name)
        {
            TreeNodeCollection nodes = GetParentNodes(parent);

            if (!nodes.ContainsKey(name))
            {
                return name;
            }


            String duplicatedName = null;
            bool foundNewName = false;
            for (int i = 2; !foundNewName; i++)
            {
                duplicatedName = name + " (" + i + ")";
                if (!nodes.ContainsKey(duplicatedName))
                {
                    foundNewName = true;
                }
            }
            return duplicatedName;

        }

        public abstract void Delete(TreeNode treeNode);

        public abstract void Move(TreeNode node, TreeNode newParentNode);
    }
}
