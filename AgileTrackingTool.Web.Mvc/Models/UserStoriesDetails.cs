using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.Mvc.Models
{
    public class UserStoriesDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AssignedOwner { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        //public IEnumerable<TaskDetails> Tasks { get; set; }
    }
}
