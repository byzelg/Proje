using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proje.Models;

namespace Proje.Controllers
{
    public class AdminController : Controller
    {
        NarailDBEntities db = new NarailDBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Admin.ToList());     //Yöneticileri listelemeye yarar
        }

        
    }
}