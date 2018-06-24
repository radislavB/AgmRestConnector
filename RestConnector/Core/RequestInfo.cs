using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hpe.Agm.RestConnector.Core
{
    public class RequestInfo : DictionaryBasedEntity
    {
        public static string URL_FIELD = "url";
        public static string TENANT_ID_FIELD = "tenantId";
        public static string METHOD_FIELD = "method";
        public static string DATA_FIELD = "data";
        public static string HEADERS_FIELD = "headers";

        #region Ctors

        public RequestInfo()
            : base()
        {

        }

        public RequestInfo(IDictionary<string, object> properties)
            : base(properties)
        {
        }

        public RequestInfo(String url, String tenantId, String method, String data, Dictionary<String, String> headers)
        {
            Url = url;
            TenantId = tenantId;
            Method = method;
            Data = data;
            Headers = headers;

        }

        #endregion

        #region Properties

        public string Url
        {
            get
            {
                return GetStringValue(URL_FIELD);
            }
            set
            {
                SetValue(URL_FIELD, value);
            }

        }

        public string Data
        {
            get
            {
                return GetStringValue(DATA_FIELD);
            }
            set
            {
                SetValue(DATA_FIELD, value);
            }

        }

        public string TenantId
        {
            get
            {
                return GetStringValue(TENANT_ID_FIELD);
            }
            set
            {
                SetValue(TENANT_ID_FIELD, value);
            }

        }

        public string Method
        {
            get
            {
                String method = GetStringValue(METHOD_FIELD);
                return String.IsNullOrEmpty(method) ? "GET" : method;
            }
            set
            {
                SetValue(METHOD_FIELD, value);
            }

        }

        public Dictionary<String, String> Headers
        {
            get
            {
                Dictionary<String, String> temp = (Dictionary<String, String>)GetValue(HEADERS_FIELD);
                if (temp == null)
                {
                    temp = Headers = new Dictionary<string, string>();
                }
                return temp;
            }
            set
            {
                SetValue(HEADERS_FIELD, value);
            }

        }

        public override void SetProperties(IDictionary<string, object> properties)
        {
            base.SetProperties(properties);
            if (this.m_properties.ContainsKey(HEADERS_FIELD))
            {
                object map = m_properties[HEADERS_FIELD];
                if (map is Dictionary<string, object>)
                {
                    Dictionary<string, object> dictionary = (Dictionary<string, object>)map;
                    Dictionary<string, string> newDictionary = new Dictionary<string, string>();
                    foreach (string str in dictionary.Keys)
                    {
                        newDictionary[str] = (string)dictionary[str];
                    }

                    m_properties[HEADERS_FIELD] = newDictionary;

                }
            }
        }

        #endregion

    }
}
