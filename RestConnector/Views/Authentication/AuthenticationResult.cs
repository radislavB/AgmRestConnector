using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public class AuthenticationResult
    {
        private String lwssoToken;


        private String csrfToken = Guid.NewGuid().ToString();

        public String CsrfToken
        {
            get { return csrfToken; }
            set { csrfToken = value; }
        }
        private Dictionary<string, string> cookies = new Dictionary<string, string>();

        public Dictionary<string, string> Cookies
        {
            get { return cookies; }
            set { cookies = value; }
        }

        public String LwssoToken
        {
            get { return lwssoToken; }
            set { lwssoToken = value; }
        }

    }
}
