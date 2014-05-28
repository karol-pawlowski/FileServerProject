using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileServerSystemClient.Models;

namespace FileServerSystemClient.Controllers
{
    public class LoginController : Controller
    {
        private Login user;

        public LoginController()
        {
            user = new Login();            
        }
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View(user);
        }

        public ActionResult Validate()
        {
            ViewBag.Message = null;

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                ViewBag.Message = "Sorry gregory nie udało się tym razem";
                return View("Index", user);
            }
            else
            {
                return RedirectToAction("Index", "File");
            }

           
        }

    }
}
