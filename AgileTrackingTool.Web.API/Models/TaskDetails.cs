using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTrackingTool.Web.API.Models
{
    public class TaskDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Status { get; set; }
    }
}