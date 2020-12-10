using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileTrackingTool.Web.Mvc.Models;
using AgileTrackingTool.Web.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgileTrackingTool.Web.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServiceClientManager _serviceClientManager = new ServiceClientManager();
        public IActionResult Index()
        {

            LoginModel obj = new LoginModel();
            return View("/Views/Login/Index.cshtml", obj);

        }
        [HttpPost]

        public ActionResult Index(LoginModel objuserlogin)
        {

            if (ModelState.IsValid)
            {
                var response = _serviceClientManager.IsAuthorizeUser(objuserlogin.UserName, objuserlogin.UserPassword);
                if (response)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ViewBag.Failedcount = "Not valid User";
                }
            }
            return View("/Views/Login/Index.cshtml", objuserlogin);
        }
    }
}