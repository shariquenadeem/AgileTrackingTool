using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AgileTrackingTool.Web.Mvc.Models;
using AgileTrackingTool.Web.Mvc.Services;
using Microsoft.AspNetCore.Http;

namespace AgileTrackingTool.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceClientManager _serviceClientManager = new ServiceClientManager();
        public UserViewModelBase UserViewModelBase { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Project details 
            var username = HttpContext.Session.GetString("UserName");
            var password = HttpContext.Session.GetString("UserPassword");
            var projectName = "Sales ART - Team Calypso";
            var projectResponse = _serviceClientManager.GetProjectDetails(username, password, projectName);
            var response = new ProjectDetails
            {
                TotalIteration = projectResponse.TotalIteration,
                TotalUserStories = projectResponse.TotalUserStories,
                TotalUsers = projectResponse.TotalUsers,
                TotalDefects = projectResponse.TotalDefects,
                UserName = HttpContext.Session.GetString("UserName")
            };

            return View(response);
        }



        public IActionResult ProjectDetails()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
