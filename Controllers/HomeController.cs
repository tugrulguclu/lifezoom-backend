using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_API.Models;

namespace WEB_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users u)
        {
                       
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {

                //using (testdbEntities2 dc = new testdbEntities2())
                //{
                //    var v = dc.Users.Where(a => a.username.Equals(u.username) && a.password.Equals(u.password)).FirstOrDefault();
                //    if (v != null)
                //    {
                //        Session["LogedUserID"] = v.ID.ToString();
                //        Session["LogedUserFullname"] = v.username.ToString();
                //        return RedirectToAction("AfterLogin");
                //    }
                //}
            }
            return View(u);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
