using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje.Models;
using Proje.Models.Login;

namespace Proje.Controllers
{
    public class LoginController : Controller
    {
        NarailDBEntities db = new NarailDBEntities();
        public ActionResult Index()
        {
            return View(db.Admin.ToList());
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username , string password)
        {
            if (new LoginState().IsLoginSucces(username,password))
            {
                return RedirectToAction("Index", "Author");
            }
            return RedirectToAction("Index","Login");
        }
    }
}