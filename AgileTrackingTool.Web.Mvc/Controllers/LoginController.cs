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
                    HttpContext.Session.SetString("UserName", objuserlogin.UserName);
                    HttpContext.Session.SetString("UserPassword", objuserlogin.UserPassword);
                    //var userInfo = _serviceClientManager.GetCurrentUserInfo(objuserlogin.UserName, objuserlogin.UserPassword);

                    //if (userInfo != null)
                    //{
                    //    var viewModel = new UserViewModelBase();
                    //    viewModel.FirstName = userInfo.FirstName;
                    //    viewModel.LastName = userInfo.LastName;
                    //    viewModel.UserName = userInfo.UserName;
                    //}

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