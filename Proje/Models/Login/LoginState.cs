using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proje.Models.Login
{
    public class LoginState
    {
        NarailDBEntities db = new NarailDBEntities();
        
        public bool IsLoginSucces(string user, string pass)
        {
            Admin resultUser = db.Admin.Where(x => x.Kullanadi.Equals(user) && x.Password.Equals(pass)).FirstOrDefault();
            if (resultUser != null)
            {
                db.Entry(resultUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool IsLoginSuccess2(string user, string pass)
        {
            Author resulttUser = db.Author.Where(x => x.NameSurname.Equals(user) && x.Password.Equals(pass)).FirstOrDefault();
            if (resulttUser != null)
            {
                db.Entry(resulttUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}