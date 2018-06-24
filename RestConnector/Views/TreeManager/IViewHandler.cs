using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hpe.Agm.RestConnector.Core;

namespace Hpe.Agm.RestConnector.Views.TreeManager
{
    public interface IViewHandler<T> where T : DictionaryBasedEntity
    {
        void RenderItem(String name, T item);

        void RenderFolder(String name);

        void EnableButtons();

        T BuildNewItem();

        bool IsDirty{get;set;}

        String GetNameTextBoxValue();

        String GetNodeText(String nodeName, T item);

        void HideAll();
    }
}
