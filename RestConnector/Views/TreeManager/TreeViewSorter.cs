using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hpe.Agm.RestConnector.Views.TreeManager
{
    public class TreeViewSorter : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = (TreeNode)x;
            TreeNode ty = (TreeNode)y;
            bool txIsLeaf = TreeNodeUtilities.IsLeaf(tx);
            bool tyIsLeaf = TreeNodeUtilities.IsLeaf(ty);
            int value = 0;
            if (txIsLeaf == tyIsLeaf)
            {
                value = tx.Text.CompareTo(ty.Text);
            }
            else
            {
                value = txIsLeaf ? 1 : -1;
            }
            return value;

        }
    }
}
