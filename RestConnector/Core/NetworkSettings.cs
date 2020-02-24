

using System.Net;

namespace Hpe.Agm.RestConnector.Core
{
    public static class NetworkSettings
    {
        public static void EnableAllSecurityProtocols()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Use it if you need to work with HTTPS while server has improper sertificates
        /// </summary>
        public static void IgnoreServerCertificateValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

    }
}
