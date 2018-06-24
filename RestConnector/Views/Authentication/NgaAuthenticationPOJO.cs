using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgmRestConnector
{
    public class NgaAuthenticationPOJO
    {
        public string user { get; set; }
        public string password { get; set; }

        public string enable_csrf
        {
            get
            {
                return "true";
            }
        }


        public NgaAuthenticationPOJO()
        {
        }

        public NgaAuthenticationPOJO(String user, string password)
        {
            this.user = user;
            this.password = password;
        }

    }
}
