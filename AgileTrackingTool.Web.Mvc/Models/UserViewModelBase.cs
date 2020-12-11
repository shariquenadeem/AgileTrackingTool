using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgileTrackingTool.Web.Mvc.Models
{
    public abstract  class UserViewModelBase
    {
        public string UserName { get; set; }
    }
}
