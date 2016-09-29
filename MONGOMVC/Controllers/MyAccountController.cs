using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MONGOMVC.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Web.Configuration;
using System.Web.Security;


namespace MONGOMVC.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(USER L, string ReturnUrl = "")
        {
            try
            {
                var client = new MongoClient(System.Configuration.ConfigurationManager.AppSettings["mongo"]);
                var database = client.GetDatabase("appharbor_9spxvctt");
                var collection = database.GetCollection<USER>("USER");
                var builder = Builders<USER>.Filter;
                var filter = builder.Eq("uid", L.uid) & builder.Eq("pass", L.pass);
                var result = collection.Find(filter).FirstOrDefault();
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.fname, false);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("AfterLogin", "Home");
                    }
                }
                else
                {
                    ViewBag.ERR = "Wrong User ID or Password! Please Try Again";
                }
            }
                catch (Exception e)
            {
                ViewBag.ERR = e.ToString();
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(USER um)
        {
            var client = new MongoClient(System.Configuration.ConfigurationManager.AppSettings["mongo"]);
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<USER>("USER");
            collection.InsertOne(um);
            return RedirectToAction("login");
        }
    }
}