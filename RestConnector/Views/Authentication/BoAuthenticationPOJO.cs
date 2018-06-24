using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hpe.Agm.RestConnector.Views.Authentication
{
    public class BoAuthenticationPOJO
    {
        public string loginName { get; set; }
        public string password { get; set; }

        public BoAuthenticationPOJO()
        {
        }

        public BoAuthenticationPOJO(String loginName, string password)
        {
            this.loginName = loginName;
            this.password = password;
        }

    }
}
