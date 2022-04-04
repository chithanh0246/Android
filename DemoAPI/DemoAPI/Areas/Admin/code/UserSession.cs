using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Areas.Admin.code
{
    [Serializable]
    public class UserSession
    {
        public string Email { set; get; }
    }
}