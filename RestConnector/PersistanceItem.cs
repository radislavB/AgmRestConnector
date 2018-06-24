using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgmRestConnector
{
    public class PersistanceItem
    {
        public string loginName;
        public string password;
        public string serverUrl;
        public string serverType;
        public string url;
        public string tenantId;
        public string method;
        public string data;
        public Dictionary<String,String> headers;
    }
}
