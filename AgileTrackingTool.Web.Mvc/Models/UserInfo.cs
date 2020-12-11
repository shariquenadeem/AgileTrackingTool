using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.Mvc.Models
{
    public class UserInfo : UserViewModelBase
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserStoriesDetails> UserStories { get; set; }
    }
}
