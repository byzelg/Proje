using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//proje sayfasının her alanı ayrı partiallara ayrıldı. Her partial'a ayrı bir view oluşturuldu(.cshtml uzantılı)

namespace Proje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()                 //Use a layout page seçeneği ile view oluşturuldu
        {
            ViewBag.Title = "Narail | 2020";    //_Layout.cshtmldeki title'yi burdan alacaktır
            return View();
        }
        public ActionResult Slider()    //Create as a partial view seçeneği ile
        {
            return View();
        }
        public ActionResult İnfo()      //Create as a partial view seçeneği ile
        {
            return View();
        }
        public ActionResult About()     //Create as a partial view seçeneği ile
        {
            return View();
        }
        public ActionResult Projects()      //Create as a partial view seçeneği ile
        {
            return View();
        }
        public ActionResult Counter()       //Create as a partial view seçeneği ile
        {
            return View();
        }
        public ActionResult Blog()          //Create as a partial view seçeneği ile
        {
            return View();
        }
    }
}