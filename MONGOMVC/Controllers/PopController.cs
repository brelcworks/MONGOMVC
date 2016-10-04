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
        [Authorize]
        public ActionResult Details(Int64 id = 0)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            var builder = Builders<MAINPOPU>.Filter;
            var filter = builder.Eq("RID", id);
            var result = collection.Find(filter).FirstOrDefault();
            return PartialView("Details_P", result);
        }

        public ActionResult delete_conf(Int64 id)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            var builder = Builders<MAINPOPU>.Filter;
            var filter = builder.Eq(s => s.RID, id);
            var result = collection.DeleteOne(filter);
            return RedirectToAction("List");
        }
        [Authorize]
        public ActionResult Add_Pmr(Int64 id = 0)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            var builder = Builders<MAINPOPU>.Filter;
            var filter = builder.Eq("RID", id);
            var result = collection.Find(filter).FirstOrDefault();
            return View(new PMRMODEL { PMRs = new PMR(), MAINPOP = result });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add_Pmr(PMRMODEL e)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            collection.InsertOne(e.PMRs);

            return RedirectToAction("List");
        }
        public JsonResult gdata2(string aData)
        {
            List<MAINPOPU> STLIST = new List<MAINPOPU>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            var builder = Builders<MAINPOPU>.Filter;
            var filter = builder.Eq("ENS", aData);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        public ActionResult View_PMR(string id)
        {
            List<PMR> STLIST = new List<PMR>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            var builder = Builders<PMR>.Filter;
            var filter = builder.Eq("ENGINE_No", id);
            STLIST = collection.Find(filter).ToList();
            return PartialView("View_PMR", STLIST);
        }
        [Authorize]
        public ActionResult PMR_Dtls(Int64 ens)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            var builder = Builders<PMR>.Filter;
            var filter = builder.Eq("RECID1", ens);
            var result = collection.Find(filter).FirstOrDefault();
            return PartialView("PMR_Dtls", result);
        }
        public JsonResult stype(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            itms = collection.AsQueryable<PMR>().Where(e => e.STYPE.StartsWith(term)).Select(e => e.STYPE).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }

        public JsonResult tech(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            itms = collection.AsQueryable<PMR>().Where(e => e.Technician.StartsWith(term)).Select(e => e.Technician).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
    }
}