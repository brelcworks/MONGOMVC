using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MONGOMVC.Models;

namespace MONGOMVC.Controllers
{
    public class PopController : Controller
    {
        public MongoClient client;
        public PopController()
        {
            client = new MongoClient(System.Configuration.ConfigurationManager.AppSettings["mongo"]);
        }
        [Authorize]
        public ActionResult List()
        {
            return View();
        }
        [Authorize]
        public JsonResult List_POP()
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            var dbResult = collection.Find(f => true).ToList();
            return Json(dbResult, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(MAINPOPU e)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            collection.InsertOne(e);
            return RedirectToAction("List");
        }
    }
}