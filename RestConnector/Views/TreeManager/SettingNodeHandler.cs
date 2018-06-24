using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hpe.Agm.RestConnector.Core;

namespace Hpe.Agm.RestConnector.Views.TreeManager
{
    public class SettingNodeHandler<T> : NodeHandler
        where T : DictionaryBasedEntity
    {

        public SettingNodeHandler(TreeView treeView, String persistencyPath)
            : base(treeView, persistencyPath)
        {

        }

        public TreeNode AddNode(TreeNode parent, String name, T item)
        {
            TreeNode node = GetParentNodes(parent).Add(name, name);
            node.Tag = item;
            node.ImageKey = TreeNodeUtilities.IMAGE_KEY_DOCUMENT;
            node.SelectedImageKey = TreeNodeUtilities.IMAGE_KEY_DOCUMENT;
            return node;
        }

        public bool Update(TreeNode node, String newName, String text, T newItem)
        {
            TreeNode parent = node.Parent;
            String currentName = node.Name;
            String sourcePath = TreeNodeUtilities.GetFullPathJoined(node.Parent, currentName);
            String targetPath = TreeNodeUtilities.GetFullPathJoined(node.Parent, newName);
            if (newName != currentName)//name changed, validate overriding
            {
                bool isNameExist = GetParentNodes(parent).ContainsKey(newName);
                if (isNameExist)
                {
                    String message = String.Format("The item with name <{0}> already exist. Press Yes to override the existing item.", newName);
                    DialogResult question = MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (question != DialogResult.Yes)
                    {
                        return false;
                    }
                }


                m_persistanceManager.MoveSetting(m_persistencyPath, sourcePath, targetPath);
            }

            m_persistanceManager.SaveSetting<T>(m_persistencyPath, newItem, targetPath);
            node.Name = newName;
            node.Tag = newItem;
            node.Text = text;
            

            return true;
        }

        public TreeNode AddNew(TreeNode parent)
        {
            String newName = FindAvailableName(parent, "Unnamed");
            T newItem = (T)Activator.CreateInstance<T>();
            TreeNode node = AddNode(parent, newName, newItem);

            String path = TreeNodeUtilities.GetFullPathJoined(node.Parent, newName);
            m_persistanceManager.SaveSetting<T>(m_persistencyPath, newItem, path);

            return node;

        }

        public TreeNode Duplicate(TreeNode node)
        {
            String duplicatedName = FindAvailableName(node.Parent, node.Name);

            T entity = (T)Activator.CreateInstance<T>();
            entity.SetProperties(((T)node.Tag).GetProperties());
            TreeNode duplicatedNode = AddNode(node.Parent, duplicatedName, entity);

            String path = TreeNodeUtilities.GetFullPathJoined(duplicatedNode.Parent, duplicatedName);
            m_persistanceManager.SaveSetting<T>(m_persistencyPath, entity, path);

            return duplicatedNode;
        }

        public override void Delete(TreeNode treeNode)
        {
            String path = TreeNodeUtilities.GetFullPath(treeNode);
            m_persistanceManager.RemoveSetting(m_persistencyPath, path);
            treeNode.Remove();
        }

        public override void Move(TreeNode node, TreeNode newParentNode)
        {
            String sourcePath = TreeNodeUtilities.GetFullPath(node);
            String targetPath = TreeNodeUtilities.GetFullPathJoined(newParentNode, node.Name);
            m_persistanceManager.MoveSetting(m_persistencyPath, sourcePath, targetPath);

            node.Remove();
            GetParentNodes(newParentNode).Add(node);
        }
    }
}
