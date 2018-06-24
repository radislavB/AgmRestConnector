using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public abstract class BaseAuthenticationStrategy
    {
        public abstract AuthenticationResult Authenticate(string host, string loginName, string password);

        protected String ExtractCookieValueFromCookieString(String[] cookies, String cookieName)
        {
            String result = null;
            foreach (String value in cookies)
            {
                if (value != null && value.StartsWith(cookieName))
                {
                    String[] parts = value.Split('=', ';');
                    result = parts[1];
                    break;
                }
            }
            return result;
        }

        protected String GetAuthenticationFullUrl(String baseUrl)
        {
            return baseUrl + GetAuthenticationSuffixUrl();
        }

        public abstract String GetAuthenticationSuffixUrl();

        public virtual String GetSCRFCookieName()
        {
            return "";
        }

        public virtual String GetSCRFHeaderName()
        {
            return "";
        }
    }
}
