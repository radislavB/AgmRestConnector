using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hpe.Agm.RestConnector.Views.TreeManager
{
    public static class TreeNodeUtilities
    {
        public static String IMAGE_KEY_FOLDER = "folderExpanded";
        //public static String IMAGE_KEY_FOLDER_CLOSED = "folderClosed";
        public static String IMAGE_KEY_DOCUMENT = "document";

        public static bool IsLeaf(TreeNode node)
        {
            return node != null && node.Tag != null;

        }

        public static bool IsFolder(TreeNode node)
        {
            return node != null && node.Tag == null;

        }

        public static String GetFullPath(TreeNode node)
        {
            if (node == null || node.Name == "Root")
            {
                return "";
            }

            TreeNode temp = node;
            String path = temp.Name;
            while (temp.Parent != null && temp.Parent.Name != "Root")
            {
                path = temp.Parent.Name + Path.AltDirectorySeparatorChar + path;
                temp = temp.Parent;
            }
            return path;
        }

        public static string GetFullPathJoined(TreeNode treeNode, string name)
        {
            if (treeNode == null || treeNode.Name == "Root")
            {
                return name;
            }
            return GetFullPath(treeNode) + Path.AltDirectorySeparatorChar + name;
        }



    }
}
