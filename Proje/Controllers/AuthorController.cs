using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using Proje.Models;

namespace Proje.Controllers
{
    public class AuthorController : Controller
    {
        NarailDBEntities db = new NarailDBEntities();
        public ActionResult Index()
        {
            return View(db.Author.ToList());        //yazar listeleme işlemi - yazarlar Index viewden çekilecek
        }

        public ActionResult Delete(int? Id)         //int? demek değişken tipinin int ya da null olabileceği ihtimalini taşır
        {
            if (Id == null)
            {
                return HttpNotFound();          
            }

            Author author = db.Author.Find(Id);
            db.Author.Remove(author);               //yazar silme işlemi
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()                    //yazar ekleme-get ile
        {
            return View();                                   
        }

        [HttpPost]                                        //yazar ekleme-post ile
        public ActionResult Create(Author author, HttpPostedFileBase File)
        {
            var authorExist = db.Author.Any(m => m.Email == author.Email);  //author var mı diye kontrol edelim, mail varsa author vardır

            if (authorExist == false)
            {
                author.AddedDate = DateTime.Now;
                author.AddedBy = "Yeni Kayıt";

                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();     //resme otomatik isim atansın=Guid ve stringe dnüştürülsün, extension kısmı jpeg,png ne ise onu belirtecek. en son küçük harfe dnüştürüyouz tüm uzantiyi.
                    img.Resize(225,180,false,false);  //vesikalık için ideal resim boyutuna ayarladım, herhangi bir kırpma olmasın diye false,false yazdım
                    string tamyol = "~/images/users/" + uzanti; //vt ye benim klasörüme kaydedileceği yolları belirtmem gerek.
                    img.Save(Server.MapPath(tamyol)); //resmim servera eklendi

                    author.Image = "/images/users/" + uzanti;  //resim vt ye eklendi
                }
                db.Author.Add(author);
                db.SaveChanges();           //tüm bilgiler vt ye kaydedilecek
            }
            return RedirectToAction("Index");                   //kaydettikten sonra ındex'e döndürmek gerek
        }


        public ActionResult Details(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            Author author = db.Author.Find(Id); //hangi yazarsa onu bulmayı sağlayacak
            return PartialView(author);
        }               //Detaylı Gör sekmesi için

        public ActionResult Edit(int? Id)                       //Düzenle sekmesi için
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            Author author = db.Author.Find(Id); //hangi yazarsa onu bulmayı sağlayacak
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author, HttpPostedFileBase File)                    
        {
            if (author != null)     //yazar null değilse değişiklikleri kaydedecek
            {
                db.Entry(author).State = System.Data.Entity.EntityState.Modified;
                db.Entry(author).Property(m => m.AddedBy).IsModified = false;   //AddedBy değiştirilemesin
                db.Entry(author).Property(m => m.AddedDate).IsModified = false;   //AddedDate değiştirilemesin

                if (File != null)       //resim için olan kodu 'public Create'den aynen aldım
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();    
                    string tamyol = "~/images/users/" + uzanti; 
                    img.Save(Server.MapPath(tamyol)); 

                    author.Image = "/images/users/" + uzanti;
                }
                else        //resim eklenmeyecekse(nullsa) değişiklik olmasın
                {
                    db.Entry(author).Property(m => m.Image).IsModified = false;
                }
                author.ModifyBy = "Güncelleme";
                author.ModifyDate = DateTime.Now;
            }
            db.SaveChanges();
            return RedirectToAction("Index","Author");
        }

    }
}