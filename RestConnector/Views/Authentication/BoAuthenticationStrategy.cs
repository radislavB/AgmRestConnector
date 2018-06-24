using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public class BoAuthenticationStrategy : BaseAuthenticationStrategy
    {
        public override AuthenticationResult Authenticate(string host, string loginName, string password)
        {
            AuthenticationResult authenticationResult = new AuthenticationResult();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(GetAuthenticationFullUrl(host));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                BoAuthenticationPOJO auth = new BoAuthenticationPOJO(loginName, password);
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                String json = jsSerializer.Serialize(auth);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                authenticationResult.LwssoToken = streamReader.ReadToEnd();
            }

            return authenticationResult;
        }


        public override string GetAuthenticationSuffixUrl()
        {
            return "/internal-portal/openservice/v1/lwsso/getToken";
        }

    }
}
