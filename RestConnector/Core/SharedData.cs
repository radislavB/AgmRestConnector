using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hpe.Agm.RestConnector.Core
{
    public class SharedData
    {
        String m_securityToken;
        String m_connectedUser;
        String m_baseUrl;
        String m_baseUrlLabel;

        String m_scrfHeader;
        String m_scrfCookie;
        String m_scrfValue;

        Dictionary<String, String> m_additionalCookies;

        Dictionary<string, string> m_parameters;

        public event EventHandler OnDataChanged;

        public String BaseUrl
        {
            get { return m_baseUrl; }
            private set
            {
                m_baseUrl = value;


            }
        }

        public String BaseUrlLabel
        {
            get { return m_baseUrlLabel; }
            private set
            {
                m_baseUrlLabel = value;
            }
        }

        public String SecurityToken
        {
            get { return m_securityToken; }
            private set
            {
                m_securityToken = value;

            }
        }

        public String ConnectedUser
        {
            get { return m_connectedUser; }
            private set { m_connectedUser = value; }
        }

        public void InitBaseUrl(String baseUrl, String label)
        {
            BaseUrl = baseUrl;
            BaseUrlLabel = label;
            OnDataChanged(this, EventArgs.Empty);
        }

        public void InitSecurityContext(String connectedUser, String securityToken, Dictionary<String, String> additionalCookies)
        {
            SecurityToken = securityToken;
            ConnectedUser = connectedUser;
            AdditionalCookies = additionalCookies;
            OnDataChanged(this, EventArgs.Empty);
        }

        public Dictionary<String, String> AdditionalCookies
        {
            get { return m_additionalCookies; }
            private set { m_additionalCookies = value; }
        }

        public void UpdateSecurityToken(String securityToken)
        {
            SecurityToken = securityToken;
        }

        public void ClearSecurityContext()
        {
            SecurityToken = null;
            ConnectedUser = null;
            OnDataChanged(this, EventArgs.Empty);
        }

        public Dictionary<string, string> Parameters
        {
            get
            { 
                return m_parameters; 
            }
            set
            {
                m_parameters = value;
            }
        }

        public void FireOnDataChange(){
            OnDataChanged(this, EventArgs.Empty);
        }

        public void SetCSRFContext(String cookieName, String headerName, String value)
        {
            CsrfHeader = headerName;
            CsrfCookie = cookieName;
            CsrfValue = value;
            OnDataChanged(this, EventArgs.Empty);
        }

        public String CsrfValue
        {
            get { return m_scrfValue; }
            private set { m_scrfValue = value; }
        }

        public String CsrfCookie
        {
            get { return m_scrfCookie; }
            private set { m_scrfCookie = value; }
        }


        public String CsrfHeader
        {
            get { return m_scrfHeader; }
            private set { m_scrfHeader = value; }
        }


        
    }
}
