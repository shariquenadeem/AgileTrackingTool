using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTrackingTool.Web.API.Models
{
    public class UserStoriesDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AssignedOwner { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IEnumerable<TaskDetails> Tasks { get; set; }
    }
}