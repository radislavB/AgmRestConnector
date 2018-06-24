using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hpe.Agm.RestConnector.Core
{

    public class ConnectionInfo : DictionaryBasedEntity
    {
        public static string LOGIN_NAME_FIELD = "loginName";
        public static string PASSWORD_FIELD = "password";
        public static string SERVER_URL_FIELD = "serverUrl";
        public static string SERVER_TYPE_FIELD = "serverType";
        public static string IS_BASE_URL_CUSTOM_FIELD = "isBaseUrlCustom";
        public static string CUSTOM_BASE_URL_FIELD = "customBaseUrl";

        #region Ctors

        public ConnectionInfo()
            : base()
        {
        }

        public ConnectionInfo(IDictionary<string, object> properties)
            : base(properties)
        {
        }

        public ConnectionInfo(String loginName, String password, String serverUrl, ServerType serverType, bool isBaseUrlCustom, String customBaseUrl)
        {
            LoginName = loginName;
            Password = password;
            ServerUrl = serverUrl;
            ServerType = serverType;
            IsBaseUrlCustom = isBaseUrlCustom;
            CustomBaseUrl = customBaseUrl;
        }

        #endregion

        #region Base Properties

        public string LoginName
        {
            get
            {
                return GetStringValue(LOGIN_NAME_FIELD);
            }
            set
            {
                SetValue(LOGIN_NAME_FIELD, value);
            }

        }

        public string Password
        {
            get
            {
                return GetStringValue(PASSWORD_FIELD);
            }
            set
            {
                SetValue(PASSWORD_FIELD, value);
            }

        }

        public string ServerUrl
        {
            get
            {
                return GetStringValue(SERVER_URL_FIELD);
            }
            set
            {
                SetValue(SERVER_URL_FIELD, value);
            }

        }

        public string CustomBaseUrl
        {
            get
            {
                return GetStringValue(CUSTOM_BASE_URL_FIELD);
            }
            set
            {
                SetValue(CUSTOM_BASE_URL_FIELD, value);
            }

        }

        public bool IsBaseUrlCustom
        {
            get
            {
                bool result = false;
                object obj = GetValue(IS_BASE_URL_CUSTOM_FIELD);
                if (obj is bool)
                {
                    result = (bool)obj;
                }


                return result;
            }
            set
            {
                SetValue(IS_BASE_URL_CUSTOM_FIELD, value);
            }

        }

        public ServerType ServerType
        {
            get
            {
                String value = (String)GetValue(SERVER_TYPE_FIELD);
                ServerType parsed;
                if (!Enum.TryParse<ServerType>(value, true, out parsed))
                {
                    parsed = ServerType.BO;
                }
                return parsed;
            }
            set
            {
                SetValue(SERVER_TYPE_FIELD, value.ToString());
            }

        }


        #endregion


    }
}
