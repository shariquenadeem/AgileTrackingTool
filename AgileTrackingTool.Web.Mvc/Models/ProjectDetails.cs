using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.Mvc.Models
{
    public class ProjectDetails : UserViewModelBase
    {
        public int TotalIteration { get; set; }
        public int TotalUsers { get; set; }
        public int TotalUserStories { get; set; }
        public int TotalDefects { get; set; }
        public int TotalTasks { get; set; }
    }
}
