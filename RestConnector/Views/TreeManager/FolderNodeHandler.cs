using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hpe.Agm.RestConnector.Views.TreeManager
{
    public class FolderNodeHandler : NodeHandler
    {

        public FolderNodeHandler(TreeView treeView, String persistencyPath)
            : base(treeView, persistencyPath)
        {

        }

        public TreeNode AddNode(TreeNode parent, String name)
        {
            TreeNode node = GetParentNodes(parent).Add(name, name);

            node.ImageKey = TreeNodeUtilities.IMAGE_KEY_FOLDER;
            node.SelectedImageKey = TreeNodeUtilities.IMAGE_KEY_FOLDER;
            return node;
        }

        public bool Update(TreeNode node, String name)
        {
            TreeNode parent = node.Parent;
            String currentName = node.Name;
            if (name == currentName)
            {
                return true;
            }
            String sourcePath = TreeNodeUtilities.GetFullPathJoined(node.Parent, currentName);
            String targetPath = TreeNodeUtilities.GetFullPathJoined(node.Parent, name);
            m_persistanceManager.MoveFolder(m_persistencyPath, sourcePath, targetPath);

            node.Name = name;
            node.Text = name;
            
            return true;
        }

        public override void Delete(TreeNode treeNode)
        {
            String path = TreeNodeUtilities.GetFullPath(treeNode);
            m_persistanceManager.RemoveFolder(m_persistencyPath, path);

            treeNode.Remove();
        }

        public TreeNode GetChildByName(TreeNode parent, string nodeName)
        {
            return GetParentNodes(parent)[nodeName];
        }

        public TreeNode AddNew(TreeNode parent)
        {
            String newName = FindAvailableName(parent, "Unnamed folder");
            TreeNode node = AddNode(parent, newName);

            String path = TreeNodeUtilities.GetFullPathJoined(node.Parent, newName);
            m_persistanceManager.CreateFolder(m_persistencyPath, path);
            return node;

        }

        public override void Move(TreeNode node, TreeNode newParentNode)
        {
            String sourcePath = TreeNodeUtilities.GetFullPath(node);
            String targetPath = TreeNodeUtilities.GetFullPathJoined(newParentNode, node.Name);
            m_persistanceManager.MoveFolder(m_persistencyPath, sourcePath, targetPath);

            node.Remove();
            GetParentNodes(newParentNode).Add(node);
        }
    }
}
