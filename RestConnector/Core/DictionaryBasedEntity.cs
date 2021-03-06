﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hpe.Agm.RestConnector.Core
{
    public class DictionaryBasedEntity
    {
        protected IDictionary<string, object> m_properties;

        #region Ctors

        public DictionaryBasedEntity()
        {
            this.m_properties = new Dictionary<string, object>();
        }

        public DictionaryBasedEntity(IDictionary<string, object> properties)
        {
            this.m_properties = new Dictionary<string, object>(properties);
        }

        #endregion

        public void SetValue(String propertyName, Object value)
        {
            m_properties[propertyName] = value; ;
        }

        public Object GetValue(String propertyName)
        {
            if (Contains(propertyName))
            {
                return m_properties[propertyName];
            }
            return null;
        }

        public String GetStringValue(String propertyName)
        {
            return (String)GetValue(propertyName);

        }

        public IDictionary<string, object> GetProperties()
        {
            return m_properties;
        }

        public virtual void SetProperties(IDictionary<string, object> properties)
        {
            this.m_properties = new Dictionary<string, object>(properties);
        }

        public bool Contains(string property)
        {
            return m_properties.ContainsKey(property);
        }

        public override string ToString()
        {
            return m_properties == null ? "No properties" : String.Format("{0} properties", m_properties.Count);
        }

    }
}
