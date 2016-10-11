using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MONGOMVC.Models;
using System.IO;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

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
                .Set("Technician", e.PMRs.Technician)
                .Set("METERIAL", e.PMRs.METERIAL)
                .Set("CUST", e.PMRs.CUST)
                .Set("CDATI", e.PMRs.CDATI)
                .Set("DIST", e.PMRs.DIST)
                .Set("STATE", e.PMRs.STATE)
                .Set("CCATE", e.PMRs.CCATE)
                .Set("MODEL", e.PMRs.MODEL)
                .Set("DOI", e.PMRs.DOI)
                .Set("DGNO", e.PMRs.DGNO)
                .Set("AMAKE", e.PMRs.AMAKE)
                .Set("ALSN", e.PMRs.ALSN)
                .Set("BSN", e.PMRs.BSN)
                .Set("CNAT", e.PMRs.CNAT)
                .Set("SERV", e.PMRs.SERV)
                .Set("RFAIL", e.PMRs.RFAIL)
                .Set("STA", e.PMRs.STA)
                .Set("WARR", e.PMRs.WARR)
                .Set("ACTION", e.PMRs.ACTION)
                .Set("OEA", e.PMRs.OEA)
                .Set("AMC", e.PMRs.AMC)
                .Set("TTR", e.PMRs.TTR)
                .Set("SLA", e.PMRs.SLA)
                .Set("TSLOT", e.PMRs.TSLOT)
                .Set("RESLA", e.PMRs.RESLA)
                .Set("KVA", e.PMRs.KVA)
                .Set("SSTA", e.PMRs.SSTA)
                .Set("DPCODE", e.PMRs.DPCODE)
                .Set("lmodi", e.PMRs.lmodi)
                .Set("AEDT", e.PMRs.AEDT)
                .Set("REM", e.PMRs.REM)
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
        public JsonResult CUST(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.CNAME.StartsWith(term)).Select(e => e.CNAME).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AMAKE(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.AMAKE.StartsWith(term)).Select(e => e.AMAKE).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult OEA(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.OEA.StartsWith(term)).Select(e => e.OEA).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DIST(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.DIST.StartsWith(term)).Select(e => e.DIST).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult STATE(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.STATE.StartsWith(term)).Select(e => e.STATE).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LLOP(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.llop.StartsWith(term)).Select(e => e.llop).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult STARTER(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.starter.StartsWith(term)).Select(e => e.starter).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CHALT(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.chalt.StartsWith(term)).Select(e => e.chalt).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CNMAKE(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.cnmake.StartsWith(term)).Select(e => e.cnmake).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AMC(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.AMC.StartsWith(term)).Select(e => e.AMC).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WARR(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.WARR.StartsWith(term)).Select(e => e.WARR).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MODEL(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.MODEL.StartsWith(term)).Select(e => e.MODEL).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SPIN(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.SPIN.StartsWith(term)).Select(e => e.SPIN).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DSTA(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.DSTA.StartsWith(term)).Select(e => e.DSTA).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SOLENOID(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            itms = collection.AsQueryable<MAINPOPU>().Where(e => e.solenoid.StartsWith(term)).Select(e => e.solenoid).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ExportData()
        {
            GridView gv = new GridView();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<MAINPOPU>("MAINPOPU");
            var dbResult = collection.Find(f => true).ToList();
            gv.DataSource = dbResult;
            gv.DataBind();
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("POPULATION");
            ws.Cell(1, 1).Value = "SL NO";
            ws.Cell(1, 2).Value = "CUSTOMER";
            ws.Cell(1, 3).Value = "SITE ID";
            ws.Cell(1, 4).Value = "SITE NAME";
            ws.Cell(1, 5).Value = "ENGINE SR. NO";
            ws.Cell(1, 6).Value = "RATING";
            ws.Cell(1, 7).Value = "PHASE";
            ws.Cell(1, 8).Value = "DG SET NO";
            ws.Cell(1, 9).Value = "DT. OF COMMISSIONING";
            ws.Cell(1, 10).Value = "CONTACT PERSON";
            ws.Cell(1, 11).Value = "PH NO";
            ws.Cell(1, 12).Value = "ALT. MAKE";
            ws.Cell(1, 13).Value = "ALT SR. NO";
            ws.Cell(1, 14).Value = "BATTERY SR. NO";
            ws.Cell(1, 15).Value = "AMC STATUS";
            ws.Cell(1, 16).Value = "WARRANTY STATUS";
            ws.Cell(1, 17).Value = "PRESENT HMR";
            ws.Cell(1, 18).Value = "PRESENT HMR ON DATE";
            ws.Cell(1, 19).Value = "LAST SERVICE HMR";
            ws.Cell(1, 20).Value = "LAST SERVICE HMR ON DATE";
            ws.Cell(1, 21).Value = "NEXT SERVICE DATE";
            ws.Cell(1, 22).Value = "OEA";
            ws.Cell(1, 23).Value = "SITE STATUS";
            for (int I = 0; I < gv.Rows.Count; I++)
            {
                ws.Cell(I + 2, 1).Value = Convert.ToInt32(I.ToString()) + 1;
                ws.Cell(I + 2, 2).Value = gv.Rows[I].Cells[3].Text;
                ws.Cell(I + 2, 3).Value = gv.Rows[I].Cells[2].Text;
                ws.Cell(I + 2, 4).Value = gv.Rows[I].Cells[4].Text;
                ws.Cell(I + 2, 5).Value = gv.Rows[I].Cells[5].Text;
                ws.Cell(I + 2, 6).Value = gv.Rows[I].Cells[7].Text;
                ws.Cell(I + 2, 7).Value = gv.Rows[I].Cells[8].Text;
                ws.Cell(I + 2, 8).Value = gv.Rows[I].Cells[23].Text;
                ws.Cell(I + 2, 9).Value = gv.Rows[I].Cells[14].Text;
                ws.Cell(I + 2, 10).Value = gv.Rows[I].Cells[11].Text;
                ws.Cell(I + 2, 11).Value = gv.Rows[I].Cells[12].Text;
                ws.Cell(I + 2, 12).Value = gv.Rows[I].Cells[27].Text;
                ws.Cell(I + 2, 13).Value = gv.Rows[I].Cells[6].Text;
                ws.Cell(I + 2, 14).Value = gv.Rows[I].Cells[10].Text;
                ws.Cell(I + 2, 15).Value = gv.Rows[I].Cells[16].Text;
                ws.Cell(I + 2, 16).Value = gv.Rows[I].Cells[28].Text;
                ws.Cell(I + 2, 17).Value = gv.Rows[I].Cells[17].Text;
                ws.Cell(I + 2, 18).Value = gv.Rows[I].Cells[18].Text;
                ws.Cell(I + 2, 19).Value = gv.Rows[I].Cells[19].Text;
                ws.Cell(I + 2, 20).Value = gv.Rows[I].Cells[20].Text;
                ws.Cell(I + 2, 21).Value = gv.Rows[I].Cells[21].Text;
                ws.Cell(I + 2, 22).Value = gv.Rows[I].Cells[29].Text;
                ws.Cell(I + 2, 23).Value = gv.Rows[I].Cells[43].Text;
            }

            ws.Range("i2", "i" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("r2", "r" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("t2", "u" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("e2", "e" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("#");
            ws.Columns().AdjustToContents();
            ws.SheetView.FreezeRows(1);
            ClosedXML.Excel.IXLRange range = ws.RangeUsed();
            string RCNT = "w" + range.RowCount();
            ws.Range("a1", RCNT).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", "w1").Style.Fill.BackgroundColor = XLColor.Turquoise;
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=POP.xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            return RedirectToAction("List");
        }
        public JsonResult List_rm()
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            var dbResult = collection.Find(f => true).ToList();
            return Json(dbResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List_rm1()
        {
            return View();
        }
       [Authorize]
        public JsonResult gtbtot(string aData)
        {
            List<PMR> STLIST = new List<PMR>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            var builder = Builders<PMR>.Filter;
            var filter = builder.Eq("ENGINE_No", aData);
            STLIST = collection.Find(filter).Sort(Builders<PMR>.Sort.Descending("_id")).ToList();
            var PM = new PMR();
            var rec = STLIST.Count();
            for (int I = 0; I < STLIST.Count; I++)
            {
            	if (rec >= 2)
            		{
            				PM= STLIST[1];
            				break;
            		}
            	else
            		{
            			PM.HMR= "2";
            			PM.DOS=STLIST[0].DOI;
            		}
            }
            return new JsonResult { Data = PM, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        [HttpPost]
        public JsonResult DEL_PMR(Int64 id)
        {
            string message = "";
            try
            {
            	List<PMR> STLIST = new List<PMR>();
                var database = client.GetDatabase("appharbor_9spxvctt");
                var collection = database.GetCollection<PMR>("PMR");
                var builder = Builders<PMR>.Filter;
                var filter = builder.Eq(s => s.RECID1, id);
                var res = collection.Find(filter).FirstOrDefault();
                var ens = res.ENGINE_No.ToString();
                var filter1 = builder.Eq(s => s.ENGINE_No, ens);
                STLIST = collection.Find(filter1).Sort(Builders<PMR>.Sort.Descending("_id")).ToList();
                var rec = STLIST.Count();
                	var collection1 = database.GetCollection<MAINPOPU>("MAINPOPU");
                	var builder1 = Builders<MAINPOPU>.Filter;
                	var filter2 = builder1.Eq(s => s.ENS, ens);
                	var RES1 = collection1.Find(filter2).FirstOrDefault();
                	for (int I = 0; I < STLIST.Count; I++)
            				{
            					if (rec >= 2) {
            						var upd = Builders<MAINPOPU>.Update
            						.Set("CHMR", STLIST[1].HMR)
            						.Set("CHMD",STLIST[1].DOS)
            							.Set("lhmr",STLIST[1].LHMR)
            							.Set("lsd",STLIST[1].LSD)
            							.Set("nsd",STLIST[1].NSD);
            						var result1 = collection1.UpdateOne(filter2,upd);
            						break;
            					}
                			else
                				{
                					var upd = Builders<MAINPOPU>.Update
            						.Set("CHMR", "2")
            						.Set("CHMD",RES1.DOC)
                						.Set("lhmr","")
            							.Set("lsd","")
            							.Set("nsd","");
                					var result1 = collection1.UpdateOne(filter2,upd);
                				}
            				}
                var result = collection.DeleteOne(filter);
                message = "Successfully Saved!";
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult exp1_pmr(string ens)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("PMR");
            ws.Cell(1, 1).Value = "Customer";
            ws.Cell(1, 2).Value = "Issue Type";
            ws.Cell(1, 3).Value = "Issue Open Date";
            ws.Cell(1, 4).Value = "Complaint / Service No";
            ws.Cell(1, 5).Value = "Site Id";
            ws.Cell(1, 6).Value = "Site Name";
            ws.Cell(1, 7).Value = "District";
            ws.Cell(1, 8).Value = "State";
            ws.Cell(1, 9).Value = "Issue Category";
            ws.Cell(1, 10).Value = "Engine No";
            ws.Cell(1, 11).Value = "Model";
            ws.Cell(1, 12).Value = "KVA";
            ws.Cell(1, 13).Value = "DOI";
            ws.Cell(1, 14).Value = "DG SET NO";
            ws.Cell(1, 15).Value = "Alt. Make";
            ws.Cell(1, 16).Value = "Alt. Sr. No";
            ws.Cell(1, 17).Value = "Battery Sr. No";
            ws.Cell(1, 18).Value = "HMR";
            ws.Cell(1, 19).Value = "Issue Nature";
            ws.Cell(1, 20).Value = "Serverity";
            ws.Cell(1, 21).Value = "Failure Reason";
            ws.Cell(1, 22).Value = "Issue Status";
            ws.Cell(1, 23).Value = "Issue Closed Date";
            ws.Cell(1, 24).Value = "Warranty Status";
            ws.Cell(1, 25).Value = "Action Taken";
            ws.Cell(1, 26).Value = "Material Used";
            ws.Cell(1, 27).Value = "Dealer Code";
            ws.Cell(1, 28).Value = "Technician Visited";
            ws.Cell(1, 29).Value = "OEA";
            ws.Cell(1, 30).Value = "AMC Status";
            ws.Cell(1, 31).Value = "TTR";
            ws.Cell(1, 32).Value = "SLA Status";
            ws.Cell(1, 33).Value = "Time Slot";
            ws.Cell(1, 34).Value = "Reason Of SLA";
            ws.Cell(1, 35).Value = "Remarks";
            List<PMR> STLIST = new List<PMR>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            var builder = Builders<PMR>.Filter;
            var filter = builder.Eq("ENGINE_No", ens);
            STLIST = collection.Find(filter).ToList();
            
            GridView gv = new GridView();
            gv.DataSource = STLIST;
            gv.DataBind();
            for (int I = 0; I < gv.Rows.Count; I++)
            {
                ws.Cell(I + 2, 1).Value = gv.Rows[I].Cells[10].Text;
                ws.Cell(I + 2, 2).Value = gv.Rows[I].Cells[5].Text;
                ws.Cell(I + 2, 3).Value = gv.Rows[I].Cells[4].Text;
                ws.Cell(I + 2, 4).Value = gv.Rows[I].Cells[11].Text;
                ws.Cell(I + 2, 5).Value = gv.Rows[I].Cells[1].Text;
                ws.Cell(I + 2, 6).Value = gv.Rows[I].Cells[2].Text;
                ws.Cell(I + 2, 7).Value = gv.Rows[I].Cells[13].Text;
                ws.Cell(I + 2, 8).Value = gv.Rows[I].Cells[14].Text;
                ws.Cell(I + 2, 9).Value = gv.Rows[I].Cells[15].Text;
                ws.Cell(I + 2, 10).Value = gv.Rows[I].Cells[3].Text;
                ws.Cell(I + 2, 11).Value = gv.Rows[I].Cells[16].Text;
                ws.Cell(I + 2, 12).Value = gv.Rows[I].Cells[34].Text;
                ws.Cell(I + 2, 13).Value = gv.Rows[I].Cells[17].Text;
                ws.Cell(I + 2, 14).Value = gv.Rows[I].Cells[18].Text;
                ws.Cell(I + 2, 15).Value = gv.Rows[I].Cells[19].Text;
                ws.Cell(I + 2, 16).Value = gv.Rows[I].Cells[20].Text;
                ws.Cell(I + 2, 17).Value = gv.Rows[I].Cells[21].Text;
                ws.Cell(I + 2, 18).Value = gv.Rows[I].Cells[6].Text;
                ws.Cell(I + 2, 19).Value = gv.Rows[I].Cells[22].Text;
                ws.Cell(I + 2, 20).Value = gv.Rows[I].Cells[23].Text;
                ws.Cell(I + 2, 21).Value = gv.Rows[I].Cells[24].Text;
                ws.Cell(I + 2, 22).Value = gv.Rows[I].Cells[25].Text;
                ws.Cell(I + 2, 23).Value = gv.Rows[I].Cells[12].Text;
                ws.Cell(I + 2, 24).Value = gv.Rows[I].Cells[26].Text;
                ws.Cell(I + 2, 25).Value = gv.Rows[I].Cells[27].Text;
                ws.Cell(I + 2, 26).Value = gv.Rows[I].Cells[9].Text;
                ws.Cell(I + 2, 27).Value = gv.Rows[I].Cells[36].Text;
                ws.Cell(I + 2, 28).Value = gv.Rows[I].Cells[8].Text;
                ws.Cell(I + 2, 29).Value = gv.Rows[I].Cells[28].Text;
                ws.Cell(I + 2, 30).Value = gv.Rows[I].Cells[29].Text;
                ws.Cell(I + 2, 31).Value = gv.Rows[I].Cells[30].Text;
                ws.Cell(I + 2, 32).Value = gv.Rows[I].Cells[31].Text;
                ws.Cell(I + 2, 33).Value = gv.Rows[I].Cells[32].Text;
                ws.Cell(I + 2, 34).Value = gv.Rows[I].Cells[33].Text;
                ws.Cell(I + 2, 35).Value = gv.Rows[I].Cells[39].Text;
            }
            ws.Range("c2", "c" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("m2", "m" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("w2", "w" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("j2", "j" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("#");
            ws.Columns().AdjustToContents();
            ws.SheetView.FreezeRows(1);
            ClosedXML.Excel.IXLRange range = ws.RangeUsed();
            string RCNT = "ai" + range.RowCount();
            ws.Range("a1", RCNT).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", "ai1").Style.Fill.BackgroundColor = XLColor.Turquoise;
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=PMR.xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            return Content("Data added successfully");
        }
        public ActionResult exp_pmr(string sdt, string edt)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("PMR");
            ws.Cell(1, 1).Value = "Customer";
            ws.Cell(1, 2).Value = "Issue Type";
            ws.Cell(1, 3).Value = "Issue Open Date";
            ws.Cell(1, 4).Value = "Complaint / Service No";
            ws.Cell(1, 5).Value = "Site Id";
            ws.Cell(1, 6).Value = "Site Name";
            ws.Cell(1, 7).Value = "District";
            ws.Cell(1, 8).Value = "State";
            ws.Cell(1, 9).Value = "Issue Category";
            ws.Cell(1, 10).Value = "Engine No";
            ws.Cell(1, 11).Value = "Model";
            ws.Cell(1, 12).Value = "KVA";
            ws.Cell(1, 13).Value = "DOI";
            ws.Cell(1, 14).Value = "DG SET NO";
            ws.Cell(1, 15).Value = "Alt. Make";
            ws.Cell(1, 16).Value = "Alt. Sr. No";
            ws.Cell(1, 17).Value = "Battery Sr. No";
            ws.Cell(1, 18).Value = "HMR";
            ws.Cell(1, 19).Value = "Issue Nature";
            ws.Cell(1, 20).Value = "Serverity";
            ws.Cell(1, 21).Value = "Failure Reason";
            ws.Cell(1, 22).Value = "Issue Status";
            ws.Cell(1, 23).Value = "Issue Closed Date";
            ws.Cell(1, 24).Value = "Warranty Status";
            ws.Cell(1, 25).Value = "Action Taken";
            ws.Cell(1, 26).Value = "Material Used";
            ws.Cell(1, 27).Value = "Dealer Code";
            ws.Cell(1, 28).Value = "Technician Visited";
            ws.Cell(1, 29).Value = "OEA";
            ws.Cell(1, 30).Value = "AMC Status";
            ws.Cell(1, 31).Value = "TTR";
            ws.Cell(1, 32).Value = "SLA Status";
            ws.Cell(1, 33).Value = "Time Slot";
            ws.Cell(1, 34).Value = "Reason Of SLA";
            ws.Cell(1, 35).Value = "Remarks";
            if (string.IsNullOrEmpty(edt))
            {
            	var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<PMR>("PMR");
            var dbResult = collection.Find(f => true).ToList();
                GridView gv = new GridView();
                gv.DataSource = dbResult;
                gv.DataBind();
                for (int I = 0; I < gv.Rows.Count; I++)
                {
                    ws.Cell(I + 2, 1).Value = gv.Rows[I].Cells[10].Text;
                    ws.Cell(I + 2, 2).Value = gv.Rows[I].Cells[5].Text;
                    ws.Cell(I + 2, 3).Value = gv.Rows[I].Cells[4].Text;
                    ws.Cell(I + 2, 4).Value = gv.Rows[I].Cells[11].Text;
                    ws.Cell(I + 2, 5).Value = gv.Rows[I].Cells[1].Text;
                    ws.Cell(I + 2, 6).Value = gv.Rows[I].Cells[2].Text;
                    ws.Cell(I + 2, 7).Value = gv.Rows[I].Cells[13].Text;
                    ws.Cell(I + 2, 8).Value = gv.Rows[I].Cells[14].Text;
                    ws.Cell(I + 2, 9).Value = gv.Rows[I].Cells[15].Text;
                    ws.Cell(I + 2, 10).Value = gv.Rows[I].Cells[3].Text;
                    ws.Cell(I + 2, 11).Value = gv.Rows[I].Cells[16].Text;
                    ws.Cell(I + 2, 12).Value = gv.Rows[I].Cells[34].Text;
                    ws.Cell(I + 2, 13).Value = gv.Rows[I].Cells[17].Text;
                    ws.Cell(I + 2, 14).Value = gv.Rows[I].Cells[18].Text;
                    ws.Cell(I + 2, 15).Value = gv.Rows[I].Cells[19].Text;
                    ws.Cell(I + 2, 16).Value = gv.Rows[I].Cells[20].Text;
                    ws.Cell(I + 2, 17).Value = gv.Rows[I].Cells[21].Text;
                    ws.Cell(I + 2, 18).Value = gv.Rows[I].Cells[6].Text;
                    ws.Cell(I + 2, 19).Value = gv.Rows[I].Cells[22].Text;
                    ws.Cell(I + 2, 20).Value = gv.Rows[I].Cells[23].Text;
                    ws.Cell(I + 2, 21).Value = gv.Rows[I].Cells[24].Text;
                    ws.Cell(I + 2, 22).Value = gv.Rows[I].Cells[25].Text;
                    ws.Cell(I + 2, 23).Value = gv.Rows[I].Cells[12].Text;
                    ws.Cell(I + 2, 24).Value = gv.Rows[I].Cells[26].Text;
                    ws.Cell(I + 2, 25).Value = gv.Rows[I].Cells[27].Text;
                    ws.Cell(I + 2, 26).Value = gv.Rows[I].Cells[9].Text;
                    ws.Cell(I + 2, 27).Value = gv.Rows[I].Cells[36].Text;
                    ws.Cell(I + 2, 28).Value = gv.Rows[I].Cells[8].Text;
                    ws.Cell(I + 2, 29).Value = gv.Rows[I].Cells[28].Text;
                    ws.Cell(I + 2, 30).Value = gv.Rows[I].Cells[29].Text;
                    ws.Cell(I + 2, 31).Value = gv.Rows[I].Cells[30].Text;
                    ws.Cell(I + 2, 32).Value = gv.Rows[I].Cells[31].Text;
                    ws.Cell(I + 2, 33).Value = gv.Rows[I].Cells[32].Text;
                    ws.Cell(I + 2, 34).Value = gv.Rows[I].Cells[33].Text;
                    ws.Cell(I + 2, 35).Value = gv.Rows[I].Cells[39].Text;
                }
            }
            else
            {
                List<PMR> STLIST = new List<PMR>();
                DateTime sdt1 = Convert.ToDateTime(sdt);
                DateTime edt1 = Convert.ToDateTime(edt);
                TimeSpan ts = new TimeSpan(23, 59, 59);
                edt1 = edt1.Add(ts);
                var database = client.GetDatabase("appharbor_9spxvctt");
                var collection = database.GetCollection<PMR>("PMR");
                var SD = Convert.ToDateTime(sdt);
                STLIST = collection.AsQueryable<PMR>().Where(A => A.CDATI >= sdt1 && A.CDATI <= SD).ToList();
                GridView gv = new GridView();
                gv.DataSource = STLIST;
                gv.DataBind();
                for (int I = 0; I < gv.Rows.Count; I++)
                {
                    ws.Cell(I + 2, 1).Value = gv.Rows[I].Cells[10].Text;
                    ws.Cell(I + 2, 2).Value = gv.Rows[I].Cells[5].Text;
                    ws.Cell(I + 2, 3).Value = gv.Rows[I].Cells[4].Text;
                    ws.Cell(I + 2, 4).Value = gv.Rows[I].Cells[11].Text;
                    ws.Cell(I + 2, 5).Value = gv.Rows[I].Cells[1].Text;
                    ws.Cell(I + 2, 6).Value = gv.Rows[I].Cells[2].Text;
                    ws.Cell(I + 2, 7).Value = gv.Rows[I].Cells[13].Text;
                    ws.Cell(I + 2, 8).Value = gv.Rows[I].Cells[14].Text;
                    ws.Cell(I + 2, 9).Value = gv.Rows[I].Cells[15].Text;
                    ws.Cell(I + 2, 10).Value = gv.Rows[I].Cells[3].Text;
                    ws.Cell(I + 2, 11).Value = gv.Rows[I].Cells[16].Text;
                    ws.Cell(I + 2, 12).Value = gv.Rows[I].Cells[34].Text;
                    ws.Cell(I + 2, 13).Value = gv.Rows[I].Cells[17].Text;
                    ws.Cell(I + 2, 14).Value = gv.Rows[I].Cells[18].Text;
                    ws.Cell(I + 2, 15).Value = gv.Rows[I].Cells[19].Text;
                    ws.Cell(I + 2, 16).Value = gv.Rows[I].Cells[20].Text;
                    ws.Cell(I + 2, 17).Value = gv.Rows[I].Cells[21].Text;
                    ws.Cell(I + 2, 18).Value = gv.Rows[I].Cells[6].Text;
                    ws.Cell(I + 2, 19).Value = gv.Rows[I].Cells[22].Text;
                    ws.Cell(I + 2, 20).Value = gv.Rows[I].Cells[23].Text;
                    ws.Cell(I + 2, 21).Value = gv.Rows[I].Cells[24].Text;
                    ws.Cell(I + 2, 22).Value = gv.Rows[I].Cells[25].Text;
                    ws.Cell(I + 2, 23).Value = gv.Rows[I].Cells[12].Text;
                    ws.Cell(I + 2, 24).Value = gv.Rows[I].Cells[26].Text;
                    ws.Cell(I + 2, 25).Value = gv.Rows[I].Cells[27].Text;
                    ws.Cell(I + 2, 26).Value = gv.Rows[I].Cells[9].Text;
                    ws.Cell(I + 2, 27).Value = gv.Rows[I].Cells[36].Text;
                    ws.Cell(I + 2, 28).Value = gv.Rows[I].Cells[8].Text;
                    ws.Cell(I + 2, 29).Value = gv.Rows[I].Cells[28].Text;
                    ws.Cell(I + 2, 30).Value = gv.Rows[I].Cells[29].Text;
                    ws.Cell(I + 2, 31).Value = gv.Rows[I].Cells[30].Text;
                    ws.Cell(I + 2, 32).Value = gv.Rows[I].Cells[31].Text;
                    ws.Cell(I + 2, 33).Value = gv.Rows[I].Cells[32].Text;
                    ws.Cell(I + 2, 34).Value = gv.Rows[I].Cells[33].Text;
                    ws.Cell(I + 2, 35).Value = gv.Rows[I].Cells[39].Text;
                }
            }
            ws.Range("c2", "c" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("m2", "m" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("w2", "w" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("dd-MMM-yyyy hh:mm:ss");
            ws.Range("j2", "j" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("#");
            ws.Columns().AdjustToContents();
            ws.SheetView.FreezeRows(1);
            ClosedXML.Excel.IXLRange range = ws.RangeUsed();
            string RCNT = "ai" + range.RowCount();
            ws.Range("a1", RCNT).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", "ai1").Style.Fill.BackgroundColor = XLColor.Turquoise;
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=PMR.xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            return Content("Data added successfully");
        }
    }
}