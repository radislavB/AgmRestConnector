using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public class Alm12_0AuthenticationStrategy : BaseAuthenticationStrategy
    {
        public override AuthenticationResult Authenticate(string baseUrl, string loginName, string password)
        {
            AuthenticationResult authenticationResult = new AuthenticationResult();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(GetAuthenticationFullUrl(baseUrl));
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
            String[] values = httpResponse.Headers.GetValues("Set-Cookie");
            authenticationResult.LwssoToken = ExtractCookieValueFromCookieString(values, "LWSSO_COOKIE_KEY");

            //CREATE session
            var sessionRequest = (HttpWebRequest)WebRequest.Create(baseUrl + "/rest/site-session");
            sessionRequest.Method = "POST";

            String host = httpWebRequest.RequestUri.Host;
            Cookie lwssoCookie = new Cookie("LWSSO_COOKIE_KEY", authenticationResult.LwssoToken) { Domain = host };
            sessionRequest.CookieContainer = new CookieContainer();
            sessionRequest.CookieContainer.Add(lwssoCookie);

            httpResponse = (HttpWebResponse)sessionRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            //LWSSO_COOKIE_KEY
            values = httpResponse.Headers.GetValues("Set-Cookie");
            authenticationResult.CsrfToken = ExtractCookieValueFromCookieString(values, "XSRF-TOKEN");
            String qcSession = ExtractCookieValueFromCookieString(values, "QCSession");
            authenticationResult.Cookies.Add("QCSession", qcSession);

            String almUser = ExtractCookieValueFromCookieString(values, "ALM_USER");
            authenticationResult.Cookies.Add("ALM_USER", almUser);

            return authenticationResult;
        }

        public override string GetAuthenticationSuffixUrl()
        {
            return "/authentication-point/alm-authenticate";
        }


        public override string GetSCRFCookieName()
        {
            return "XSRF-TOKEN";
        }

    }
}
