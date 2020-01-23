using SchoolJournal.DAL;
using SchoolJournal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolJournal.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
                }
                if(user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("JournalPage", "School");
                }
                else
                {
                    ModelState.AddModelError("", "Такого пользователя нет");
                }
            }
            return View(model);
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Name == model.Name);
                }
                if (user == null)
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        db.Users.Add(new User { Name = model.Name, Password = model.Password, RoleId=2 });
                        db.SaveChanges();
                        user = db.Users.Where(u => u.Name == model.Name && u.Password == model.Password).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("JournalPage", "SchoolJournal");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже есть!");
                }
            }
            return View(model);
        }
    }
}