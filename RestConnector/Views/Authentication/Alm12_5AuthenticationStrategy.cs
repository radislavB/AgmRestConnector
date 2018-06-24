using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public class Alm12_5AuthenticationStrategy : BaseAuthenticationStrategy
    {
        public override AuthenticationResult Authenticate(string host, string loginName, string password)
        {
            AuthenticationResult authenticationResult = new AuthenticationResult();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(GetAuthenticationFullUrl(host));
            httpWebRequest.Method = "POST";

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(loginName + ":" + password));
            httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            //LWSSO_COOKIE_KEY
            String[] values = httpResponse.Headers.GetValues("Set-Cookie");
            authenticationResult.LwssoToken = ExtractCookieValueFromCookieString(values, "LWSSO_COOKIE_KEY");
            authenticationResult.CsrfToken = ExtractCookieValueFromCookieString(values, "XSRF-TOKEN");
            String qcSession = ExtractCookieValueFromCookieString(values, "QCSession");
            authenticationResult.Cookies.Add("QCSession", qcSession);

            String almUser = ExtractCookieValueFromCookieString(values, "ALM_USER");
            authenticationResult.Cookies.Add("ALM_USER", almUser);

            return authenticationResult;

        }

        public override string GetAuthenticationSuffixUrl()
        {
            return "/api/authentication/sign-in";
        }

        public override string GetSCRFCookieName()
        {
            return "XSRF-TOKEN";
        }


    }
}
