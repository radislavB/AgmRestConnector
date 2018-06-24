using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using AgmRestConnector;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public class NgaAuthenticationStrategy : BaseAuthenticationStrategy
    {
        public override AuthenticationResult Authenticate(string host, string loginName, string password)
        {
            AuthenticationResult authenticationResult = new AuthenticationResult();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(GetAuthenticationFullUrl(host));

            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.CookieContainer = new CookieContainer();
            //string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(loginName + ":" + password));
            //httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                NgaAuthenticationPOJO auth = new NgaAuthenticationPOJO(loginName, password);
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                String json = jsSerializer.Serialize(auth);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            bool tokenInCookies = httpResponse.Cookies["LWSSO_COOKIE_KEY"] != null;
            if (tokenInCookies)
            {
                authenticationResult.LwssoToken = httpResponse.Cookies["LWSSO_COOKIE_KEY"].Value;

                if (httpResponse.Cookies["HPSSO_COOKIE_CSRF"] != null)
                {
                    authenticationResult.CsrfToken = httpResponse.Cookies["HPSSO_COOKIE_CSRF"].Value;
                }
            }
            else // check set-cookie
            {
                String[] values = httpResponse.Headers.GetValues("Set-Cookie");
                authenticationResult.LwssoToken = ExtractCookieValueFromCookieString(values, "LWSSO_COOKIE_KEY");
                authenticationResult.CsrfToken = ExtractCookieValueFromCookieString(values, "HPSSO_COOKIE_CSRF");
            }




            return authenticationResult;
        }

        public override string GetAuthenticationSuffixUrl()
        {
            return "/authentication/sign_in";
        }

        public override string GetSCRFCookieName()
        {
            return "HPSSO_COOKIE_CSRF";
        }

        public override string GetSCRFHeaderName()
        {
            return "HPSSO-HEADER-CSRF";
        }

    }
}
