using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public class AgmAuthenticationStrategy : BaseAuthenticationStrategy
    {
        public override AuthenticationResult Authenticate(string host, string loginName, string password)
        {
            AuthenticationResult authenticationResult = new AuthenticationResult();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(GetAuthenticationFullUrl(host));
            httpWebRequest.ContentType = "application/xml";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string dataFormat = "<alm-authentication><user>{0}</user><password>{1}</password></alm-authentication>";
                string data = String.Format(dataFormat, loginName, password);
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            //LWSSO_COOKIE_KEY
            string setCookieValue = httpResponse.Headers.Get("Set-Cookie");
            String[] values = setCookieValue.Split(';', '=');
            authenticationResult.LwssoToken = values[1];
            if (authenticationResult.LwssoToken == null)
            {
                Dictionary<string, object> a = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(result);
                authenticationResult.LwssoToken = (string)a["token"];
                if (authenticationResult.LwssoToken == "null")
                {
                    authenticationResult.LwssoToken = null;
                }
            }

            return authenticationResult;
        }

        public override string GetAuthenticationSuffixUrl()
        {
            return "/agm/authentication-point/alm-authenticate";
        }

        public override string GetSCRFCookieName()
        {
            return "AGM_STATE";
        }
        public override string GetSCRFHeaderName()
        {
            return "INTERNAL_DATA";
        }

    }
}
