using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileTrackingTool.Web.Mvc.Models;
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
            var userResponse = _serviceClientManager.GetCurrentUserInfo(username, password);
            var userStories = _serviceClientManager.GetStoriesByUser(username, password);
            var response = new UserInfo
            {
                FirstName = userResponse.FirstName,
                LastName = userResponse.LastName,
                EmailAddress = userResponse.EmailAddress,
                UserName = userResponse.UserName,
            };
            response.UserStories = new List<UserStoriesDetails>();
            foreach (var story in userStories)
            {
                //response.UserStories.Add((UserStoriesde)story);
            }

            return View(response);
        }
    }
}