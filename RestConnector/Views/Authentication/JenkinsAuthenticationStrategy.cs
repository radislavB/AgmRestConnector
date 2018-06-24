using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public class JenkinsAuthenticationStrategy : BaseAuthenticationStrategy
    {
        private string scrfHeaderName = "";
        public override AuthenticationResult Authenticate(string host, string loginName, string password)
        {

            AuthenticationResult authenticationResult = new AuthenticationResult();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(host);
            //httpWebRequest.ContentType = "application/xml";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            String version = httpResponse.Headers.Get("X-Jenkins");
            if (String.IsNullOrEmpty(version))
            {
                throw new Exception("Not jenkins url");
            }

            authenticationResult.LwssoToken = "";

            //try get crumb
            try
            {
                String url = host + "/crumbIssuer/api/json";
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    String crumbJson = streamReader.ReadToEnd();
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    Dictionary<String, String> crumbMap = jss.Deserialize<Dictionary<String, String>>(crumbJson);
                    authenticationResult.CsrfToken = crumbMap["crumb"];
                    scrfHeaderName = crumbMap["crumbRequestField"];
                }
            }
            catch (Exception e)
            {

            }

            return authenticationResult;
        }



        public override string GetAuthenticationSuffixUrl()
        {
            return "";
        }

        public override string GetSCRFCookieName()
        {
            return "";
        }
        public override string GetSCRFHeaderName()
        {
            return scrfHeaderName;
        }

        private void exampleToLogin()
        {
            string password = "admin";  
            string userName = "admin";      

            var webClient = new System.Net.WebClient();

            string basicAuthToken = Convert.ToBase64String(Encoding.Default.GetBytes(userName + ":" + password));
            webClient.Headers["Authorization"] = "Basic " + basicAuthToken;

            
        }

    }
}
