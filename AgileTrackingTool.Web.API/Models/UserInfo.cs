using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTrackingTool.Web.API.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}