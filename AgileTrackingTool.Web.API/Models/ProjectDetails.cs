using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTrackingTool.Web.API.Models
{
    public class ProjectDetails
    {
        public int TotalIteration { get; set; }
        public int TotalUsers { get; set; }
        public int TotalUserStories { get; set; }
        public int TotalDefects { get; set; }
        public int TotalTasks { get; set; }
    }
}