using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VueTOView.RequestData
{
    public class LoginRequest
    {
        public string loginname { get; set; }
        public string password { get; set; }
        public VueTOView.Common.Environment environment { get; set; }

    }
}
