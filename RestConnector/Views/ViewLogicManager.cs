using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hpe.Agm.RestConnector.Core;
using System.Windows.Forms;

namespace Hpe.Agm.RestConnector.Views
{
    public class ViewLogicManager<T> where T : DictionaryBasedEntity
    {
        PersistanceManager m_persistanceManager = PersistanceManager.GetInstance();
        String m_persistencyPath;
        ListBox m_listBox;
        Dictionary<String, T> m_infos;

        public ViewLogicManager(String persistencyPath, ListBox listBox)
        {
            m_persistencyPath = persistencyPath;

            m_listBox = listBox;
            m_listBox.Sorted = true;

            m_infos = new Dictionary<string, T>();

            LoadSettingsToListBox();
        }

        public void LoadSettingsToListBox()
        {
            m_infos = m_persistanceManager.LoadSettings<T>(m_persistencyPath);
            foreach (String name in m_infos.Keys)
            {
                m_listBox.Items.Add(name);
            }

            if (m_infos.Count > 0)
            {
                //m_listBox.SelectedIndex = 0;
            }
        }

        public void SaveCurrent(String name, T newItem)
        {
            String selected = GetSelectedString();
            if (name != selected)//validate overriding
            {
                if (m_infos.ContainsKey(name))
                {
                    String message = String.Format("The item with name <{0}> already exist. Press Yes to override the existing item.", name);
                    DialogResult question = MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (question != DialogResult.Yes)
                    {
                        return;
                    }
                }
            }

            if (selected != null)
            {
                DeleteByKey(selected);
            }
            

            Save(name, newItem);
        }

        private void Save(String name, T newItem)
        {
            m_persistanceManager.SaveSetting<T>(m_persistencyPath, newItem, name);
            bool isOverride = m_infos.ContainsKey(name);
            m_infos[name] = newItem;
            if (!isOverride)
            {
                m_listBox.Items.Add(name);
            }

            m_listBox.SelectedItem = name;
        }

        public void DuplicateCurrent()
        {
            String name = GetSelectedString();

            String duplicatedName = FindAvailableName(name);

            //CREATE NEW ITEM
            T entity = (T)Activator.CreateInstance<T>();
            entity.SetProperties(GetSelectedItem().GetProperties());
            Save(duplicatedName, entity);
        }

        private String FindAvailableName(String name)
        {
            if (!m_infos.ContainsKey(name))
            {
                return name;
            }


            String duplicatedName = null;
            bool foundNewName = false;
            for (int i = 2; !foundNewName; i++)
            {
                duplicatedName = name + " (" + i + ")";
                if (!m_infos.ContainsKey(duplicatedName))
                {
                    foundNewName = true;
                }
            }
            return duplicatedName;
        }

        public void AddNew()
        {
            T newItem = (T)Activator.CreateInstance<T>();
            String newName = FindAvailableName("Unnamed");
            m_infos[newName] = newItem;
            m_listBox.Items.Add(newName);
            m_listBox.SelectedItem = newName;
        }

        public void DeleteSelectedItem()
        {
            int selectedIndex = m_listBox.SelectedIndex;
            String selectedString = GetSelectedString();

            String message = String.Format("Are you sure you want delete <{0}> setting?", selectedString);
            if (MessageBox.Show(message, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteByKey(selectedString);
            }


            if (m_listBox.Items.Count > 0)
            {
                m_listBox.SelectedIndex = m_listBox.Items.Count > selectedIndex ? selectedIndex : m_listBox.Items.Count - 1;
            }
        }

        private void DeleteByKey(String key)
        {
            m_infos.Remove(key);
            m_listBox.Items.Remove(key);
            m_persistanceManager.RemoveSetting(m_persistencyPath, key);
        }

        public T GetSelectedItem()
        {
            if (m_listBox.SelectedIndex == -1)
            {
                return null;
            }
            return m_infos[(String)m_listBox.SelectedItem];
        }

        public String GetSelectedString()
        {
            if (m_listBox.SelectedIndex == -1)
            {
                return null;
            }
            return (String)m_listBox.SelectedItem;
        }
    }
}
