using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileTrackingTool.Web.Mvc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileTrackingTool.Web.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IServiceClientManager _serviceClientManager = new ServiceClientManager();

        public IActionResult Index()
        {
            // Project details 
            var username = HttpContext.Session.GetString("UserName");
            var password = HttpContext.Session.GetString("UserPassword");
            var response = _serviceClientManager.GetCurrentUserInfo(username, password);
            return View(response);
        }
    }
}