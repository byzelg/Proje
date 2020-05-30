using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Proje.Controllers
{
    public class WriteController : Controller
    {
        // GET: Write
        public ActionResult Yazar1()
        {
            return View();
        }

        //[HttpPost]
        //public void Yazar1(string Text)
        //{
        //    Response.Write(Text);
        //}

    }
}