using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileServerSystemClient.Models;
using FileServerSystemClient.UserManagementService;
using FileServerSystemClient.Contracts;

namespace FileServerSystemClient.Controllers
{
    public class LoginController : Controller
    {
        private Login _user;
        private IUserControllerClientProxy _UserClientServiceProxy;

        public LoginController()
        {
            _user = new Login();
            _UserClientServiceProxy = new UserControllerClientProxy();
        }

        public LoginController(IUserControllerClientProxy clientProxy, Login user)
        {
            _UserClientServiceProxy = clientProxy;
            _user = user;
        }
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View(_user);
        }

        public ActionResult Validate()
        {
            ViewBag.Message = null;

            if (string.IsNullOrEmpty(_user.Username) || string.IsNullOrEmpty(_user.Password))
            {
                ViewBag.Message = "Sorry, the user name or pass is invalid";
                return View("Index", _user);
            }
            else
            {
                return RedirectToAction("Index", "File");
            }
        }

        public ActionResult CreateNewUser()
        {
            _UserClientServiceProxy.GenerateNewUser(_user.Username, _user.Password);

            return View();
        }

    }
}
