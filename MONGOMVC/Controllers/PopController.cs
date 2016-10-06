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
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Details(MAINPOPU e)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            var builder = Builders<MAINPOPU>.Filter;
            var filter = builder.Eq(s => s.RID, e.RID);
            var upd = Builders<MAINPOPU>.Update
                .Set("SID", e.SID)
                .Set("CNAME", e.CNAME)
                .Set("SNAME", e.SNAME)
                .Set("ENS", e.ENS)
                .Set("ALSN", e.ALSN)
                .Set("RAT_PH", e.RAT_PH)
                .Set("PHASE", e.PHASE)
                .Set("MODEL", e.MODEL)
                .Set("BSN", e.BSN)
                .Set("CPN", e.CPN)
                .Set("PHNO", e.PHNO)
                .Set("ADDR", e.ADDR)
                .Set("DOC", e.DOC)
                .Set("SPIN", e.SPIN)
                .Set("CHMR", e.CHMR)
                .Set("CHMD", e.CHMD)
                .Set("lhmr", e.lhmr)
                .Set("lsd", e.lsd)
                .Set("nsd", e.nsd)
                .Set("ahm", e.ahm)
                .Set("DGNO", e.DGNO)
                .Set("ACTION", e.ACTION)
                .Set("DIST", e.DIST)
                .Set("STATE", e.STATE)
                .Set("AMAKE", e.AMAKE)
                .Set("WARR", e.WARR)
                .Set("OEA", e.OEA)
                .Set("SSTA", e.SSTA)
                .Set("hmage", e.hmage)
                .Set("DPCODE", e.DPCODE)
                .Set("lmodi", e.lmodi)
                .Set("AEDT", e.AEDT)
                .Set("llop", e.llop)
                .Set("solenoid", e.solenoid)
                .Set("chalt", e.chalt)
                .Set("starter", e.starter)
                .Set("cntype", e.cntype)
                .Set("cnmake", e.cnmake)
                .Set("sauto", e.sauto)
                .Set("FRAME", e.FRAME)
                .Set("DSTA", e.DSTA)
                .Set("AMC", e.AMC);
            var result = collection.UpdateOne(filter, upd);
            return RedirectToAction("List");
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
            var collection1 = database.GetCollection<MAINPOPU>("MAINPOPU");
            var builder = Builders<MAINPOPU>.Filter;
            var filter = builder.Eq(s => s.RID, e.MAINPOP.RID);
            var upd = Builders<MAINPOPU>.Update
                .Set("SID", e.MAINPOP.SID)
                .Set("CNAME", e.MAINPOP.CNAME)
                .Set("SNAME", e.MAINPOP.SNAME)
                .Set("ENS", e.MAINPOP.ENS)
                .Set("ALSN", e.MAINPOP.ALSN)
                .Set("RAT_PH", e.MAINPOP.RAT_PH)
                .Set("PHASE", e.MAINPOP.PHASE)
                .Set("MODEL", e.MAINPOP.MODEL)
                .Set("BSN", e.MAINPOP.BSN)
                .Set("CPN", e.MAINPOP.CPN)
                .Set("PHNO", e.MAINPOP.PHNO)
                .Set("ADDR", e.MAINPOP.ADDR)
                .Set("DOC", e.MAINPOP.DOC)
                .Set("SPIN", e.MAINPOP.SPIN)
                .Set("CHMR", e.MAINPOP.CHMR)
                .Set("CHMD", e.MAINPOP.CHMD)
                .Set("lhmr", e.MAINPOP.lhmr)
                .Set("lsd", e.MAINPOP.lsd)
                .Set("nsd", e.MAINPOP.nsd)
                .Set("ahm", e.MAINPOP.ahm)
                .Set("DGNO", e.MAINPOP.DGNO)
                .Set("ACTION", e.MAINPOP.ACTION)
                .Set("DIST", e.MAINPOP.DIST)
                .Set("STATE", e.MAINPOP.STATE)
                .Set("AMAKE", e.MAINPOP.AMAKE)
                .Set("WARR", e.MAINPOP.WARR)
                .Set("OEA", e.MAINPOP.OEA)
                .Set("SSTA", e.MAINPOP.SSTA)
                .Set("hmage", e.MAINPOP.hmage)
                .Set("DPCODE", e.MAINPOP.DPCODE)
                .Set("lmodi", e.MAINPOP.lmodi)
                .Set("AEDT", e.MAINPOP.AEDT)
                .Set("llop", e.MAINPOP.llop)
                .Set("solenoid", e.MAINPOP.solenoid)
                .Set("chalt", e.MAINPOP.chalt)
                .Set("starter", e.MAINPOP.starter)
                .Set("cntype", e.MAINPOP.cntype)
                .Set("cnmake", e.MAINPOP.cnmake)
                .Set("sauto", e.MAINPOP.sauto)
                .Set("FRAME", e.MAINPOP.FRAME)
                .Set("DSTA", e.MAINPOP.DSTA)
                .Set("AMC", e.MAINPOP.AMC);
            var result = collection1.UpdateOne(filter, upd);
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
            var ENO = result.ENGINE_No.ToString();
            var collection1 = database.GetCollection<MAINPOPU>("MAINPOPU");
            var builder1 = Builders<MAINPOPU>.Filter;
            var filter1 = builder1.Eq("ENS", ENO);
            var result1 = collection1.Find(filter1).FirstOrDefault();
            return PartialView("PMR_Dtls", new PMRMODEL { PMRs = result, MAINPOP = result1 });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult PMR_Dtls(PMRMODEL e)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            var builder1 = Builders<PMR>.Filter;
            var filter1 = builder1.Eq(s => s.RECID1, e.PMRs.RECID1);
            var upd1 = Builders<PMR>.Update
                .Set("SID", e.PMRs.SID)
                .Set("ENGINE_No", e.PMRs.ENGINE_No)
                .Set("DOS", e.PMRs.DOS)
                .Set("STYPE", e.PMRs.STYPE)
                .Set("HMR", e.PMRs.HMR)
                .Set("Report", e.PMRs.Report)
                .Set("SNAME", e.PMRs.SNAME);
            var result1 = collection.UpdateOne(filter1, upd1);
            var collection1 = database.GetCollection<MAINPOPU>("MAINPOPU");
            var builder = Builders<MAINPOPU>.Filter;
            var filter = builder.Eq(s => s.RID, e.MAINPOP.RID);
            var upd = Builders<MAINPOPU>.Update
                .Set("SID", e.MAINPOP.SID)
                .Set("CNAME", e.MAINPOP.CNAME)
                .Set("SNAME", e.MAINPOP.SNAME)
                .Set("ENS", e.MAINPOP.ENS)
                .Set("ALSN", e.MAINPOP.ALSN)
                .Set("RAT_PH", e.MAINPOP.RAT_PH)
                .Set("PHASE", e.MAINPOP.PHASE)
                .Set("MODEL", e.MAINPOP.MODEL)
                .Set("BSN", e.MAINPOP.BSN)
                .Set("CPN", e.MAINPOP.CPN)
                .Set("PHNO", e.MAINPOP.PHNO)
                .Set("ADDR", e.MAINPOP.ADDR)
                .Set("DOC", e.MAINPOP.DOC)
                .Set("SPIN", e.MAINPOP.SPIN)
                .Set("CHMR", e.MAINPOP.CHMR)
                .Set("CHMD", e.MAINPOP.CHMD)
                .Set("lhmr", e.MAINPOP.lhmr)
                .Set("lsd", e.MAINPOP.lsd)
                .Set("nsd", e.MAINPOP.nsd)
                .Set("ahm", e.MAINPOP.ahm)
                .Set("DGNO", e.MAINPOP.DGNO)
                .Set("ACTION", e.MAINPOP.ACTION)
                .Set("DIST", e.MAINPOP.DIST)
                .Set("STATE", e.MAINPOP.STATE)
                .Set("AMAKE", e.MAINPOP.AMAKE)
                .Set("WARR", e.MAINPOP.WARR)
                .Set("OEA", e.MAINPOP.OEA)
                .Set("SSTA", e.MAINPOP.SSTA)
                .Set("hmage", e.MAINPOP.hmage)
                .Set("DPCODE", e.MAINPOP.DPCODE)
                .Set("lmodi", e.MAINPOP.lmodi)
                .Set("AEDT", e.MAINPOP.AEDT)
                .Set("llop", e.MAINPOP.llop)
                .Set("solenoid", e.MAINPOP.solenoid)
                .Set("chalt", e.MAINPOP.chalt)
                .Set("starter", e.MAINPOP.starter)
                .Set("cntype", e.MAINPOP.cntype)
                .Set("cnmake", e.MAINPOP.cnmake)
                .Set("sauto", e.MAINPOP.sauto)
                .Set("FRAME", e.MAINPOP.FRAME)
                .Set("DSTA", e.MAINPOP.DSTA)
                .Set("AMC", e.MAINPOP.AMC);
            var result = collection1.UpdateOne(filter, upd);
            return RedirectToAction("List");
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