using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI.WebControls;
using MONGOMVC.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using ClosedXML.Excel;

namespace MONGOMVC.Controllers
{
    public class StockController : Controller
    {
        public MongoClient client;
        public StockController()
            {
           client = new MongoClient(System.Configuration.ConfigurationManager.AppSettings["mongo"]);
        }
        [Authorize]
        public ActionResult List()
        {
            return View();
        }
        [Authorize]
        public JsonResult List_SC()
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var dbResult = collection.Find(f => true).ToList();
            return Json(dbResult, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(TABLE2 e)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            collection.InsertOne(e);
            return RedirectToAction("List");
        }
        [Authorize]
        public ActionResult Edit(Int64 id)
        {
            try
            {
                var database = client.GetDatabase("appharbor_9spxvctt");
                var collection = database.GetCollection<TABLE2>("STOCK");
                var builder = Builders<TABLE2>.Filter;
                var filter = builder.Eq("RID1", id);
                var result = collection.Find(filter).FirstOrDefault();
                return PartialView("Edit", result);
            }
            catch (Exception e)
            {
                ViewBag.ERR = e.ToString();
                return RedirectToAction("List");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(TABLE2 e)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var builder = Builders<TABLE2>.Filter;
            var filter = builder.Eq(s => s.RID1, e.RID1);
            var upd = Builders<TABLE2>.Update
                .Set("TYPE",e.TYPE)
                .Set("MRP", e.MRP)
                .Set("QTY", e.QTY)
                .Set("TOTAL", e.TOTAL)
                .Set("TAX", e.TAX)
                .Set("TVAL", e.TVAL)
                .Set("STOTAL", e.STOTAL)
                .Set("PPRICE", e.PPRICE)
                .Set("UNIT", e.UNIT)
                .Set("SSTA", e.SSTA)
                .Set("SPRICE", e.SPRICE)
                .Set("EOR", e.EOR)
                .Set("lmodi", e.lmodi)
                .Set("USER1", e.USER1)
                .Set("RACKNO", e.RACKNO);
            var result = collection.UpdateOne(filter, upd);
            return RedirectToAction("List");
        }

        public ActionResult delete_conf(Int64 id)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var builder = Builders<TABLE2>.Filter;
            var filter = builder.Eq(s => s.RID1, id);
            var result = collection.DeleteOne(filter);
            return RedirectToAction("List");
        }

        public JsonResult gmid(string aData)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var STLIST = DateTime.Now.ToString("ddMMyyyyhhmmssfff");
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult gmid1(string aData)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<SHEET1>("SHEET1");
            var STLIST = DateTime.Now.ToString("ddMMyyyyhhmmssfff");
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        [HttpPost]
        public ActionResult Save_ITM1(SHEET1 bill)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var database = client.GetDatabase("appharbor_9spxvctt");
                    var collection = database.GetCollection<SHEET1>("SHEET1");
                    collection.InsertOne(bill);
                    message = "Successfully Saved!";
                }
                catch (Exception ex) { ex.ToString(); }
            }
            else
            {
                message = "Please provide required fields value.";
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                ViewBag.Message = message;
                return View(bill);
            }
        }
        public JsonResult GetPtno(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<SHEET1>("SHEET1");
            itms  = collection.AsQueryable<SHEET1>().Where(e => e.PART_NO.StartsWith(term)).Select(e => e.PART_NO).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetParti(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<SHEET1>("SHEET1");
            itms = collection.AsQueryable<SHEET1>().Where(e => e.PARTI.StartsWith(term)).Select(e => e.PARTI).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        public JsonResult gdata2(string aData)
        {
            List<SHEET1> STLIST = new List<SHEET1>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<SHEET1>("SHEET1");
            var builder = Builders<SHEET1>.Filter;
            var filter = builder.Eq("PART_NO", aData);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult gdata1(string aData)
        {
            List<SHEET1> STLIST = new List<SHEET1>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<SHEET1>("SHEET1");
            var builder = Builders<SHEET1>.Filter;
            var filter = builder.Eq("PARTI", aData);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public int dpl(string aData)
        {
            int msg;
            List<TABLE2> STLIST1 = new List<TABLE2>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var builder = Builders<TABLE2>.Filter;
            var filter = builder.Eq("PART_NO", aData);
            STLIST1 = collection.Find(filter).ToList();
            var cn = STLIST1.Count();
            msg = cn;
            return msg;
        }
        public int dpl1(string aData)
        {
            int msg;
            List<TABLE2> STLIST1 = new List<TABLE2>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var builder = Builders<TABLE2>.Filter;
            var filter = builder.Eq("PARTI", aData);
            STLIST1 = collection.Find(filter).ToList();
            var cn = STLIST1.Count();
            msg = cn;
            return msg;
        }

        [Authorize]
        public ActionResult List_Pr1()
        {
            return View();
        }
        public JsonResult List_Pr(int page, int rows, string sidx, string sord)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<SHEET1>("SHEET1");
            var dbResult =collection.AsQueryable<SHEET1>().Select(
                a => new
                {
                    a.RID,
                    a.PART_NO,
                    a.PARTI,
                    a.MRP,
                    a.GROP,
                    a.CATE,
                    a.TRATE,
                    a.unit
                });
            int totalRecords = dbResult.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                dbResult = dbResult.OrderByDescending(s => s.PARTI);
                dbResult = dbResult.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                dbResult = dbResult.OrderBy(s => s.PARTI);
                dbResult = dbResult.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var JsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = dbResult
            };
            return Json(JsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string crt(SHEET1 objPMR)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    var database = client.GetDatabase("appharbor_9spxvctt");
                    var collection = database.GetCollection<SHEET1>("SHEET1");
                    collection.InsertOne(objPMR);
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation Failed";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        public string edt(SHEET1 objPMR)
        {
            string msg;
            try
            {
                var database = client.GetDatabase("appharbor_9spxvctt");
                var collection = database.GetCollection<SHEET1>("SHEET1");
                var builder = Builders<SHEET1>.Filter;
                var filter = builder.Eq(s => s.RID, objPMR.RID);
                var upd = Builders<SHEET1>.Update
                    .Set("TYPE", objPMR.PART_NO)
                    .Set("MRP", objPMR.MRP)
                    .Set("QTY", objPMR.PARTI)
                    .Set("TOTAL", objPMR.GROP)
                    .Set("TAX", objPMR.CATE)
                    .Set("TVAL", objPMR.DPCODE)
                    .Set("STOTAL", objPMR.lmodi)
                    .Set("PPRICE", objPMR.TRATE)
                    .Set("UNIT", objPMR.rid1)
                    .Set("SSTA", objPMR.unit)
                    .Set("SPRICE", objPMR.AEDT);
                var result = collection.UpdateOne(filter, upd);
                msg = "Saved Successfully";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        public string dlt(Int64 id)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<SHEET1>("SHEET1");
            var builder = Builders<SHEET1>.Filter;
            var filter = builder.Eq(s => s.RID, id);
            var result = collection.DeleteOne(filter);
            return "Deleted Successfully!";
        }
        [Authorize]
        public ActionResult ExportData()
        {
            GridView gv = new GridView();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var dbResult = collection.Find(f => true).ToList();
            gv.DataSource = dbResult;
            gv.DataBind();
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("STOCK");
            ws.Cell(1, 1).Value = "SL. NO.";
            ws.Cell(1, 2).Value = "PART NAME";
            ws.Cell(1, 3).Value = "PART NO";
            ws.Cell(1, 4).Value = "QTY";
            ws.Cell(1, 5).Value = "MRP";
            ws.Cell(1, 6).Value = "SELL PRICE";
            ws.Cell(1, 7).Value = "UNIT";
            ws.Cell(1, 8).Value = "RACK NO";
            ws.Cell(1, 9).Value = "MRP TOTAL";
            ws.Cell(1, 10).Value = "SELL PRICE TOTAL";
            for (int I = 0; I < gv.Rows.Count; I++)
            {
                ws.Cell(I + 2, 1).Value = Convert.ToInt32(I.ToString()) + 1;
                ws.Cell(I + 2, 2).Value = gv.Rows[I].Cells[4].Text;
                ws.Cell(I + 2, 3).Value = gv.Rows[I].Cells[3].Text;
                ws.Cell(I + 2, 4).Value = gv.Rows[I].Cells[6].Text;
                ws.Cell(I + 2, 5).Value = gv.Rows[I].Cells[5].Text;
                ws.Cell(I + 2, 6).Value = gv.Rows[I].Cells[14].Text;
                ws.Cell(I + 2, 7).Value = gv.Rows[I].Cells[13].Text;
                ws.Cell(I + 2, 8).Value = gv.Rows[I].Cells[8].Text;
                ws.Cell(I + 2, 9).Value = gv.Rows[I].Cells[7].Text;
                ws.Cell(I + 2, 10).Value = gv.Rows[I].Cells[11].Text;
            }
            ws.Range("I2", "J" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("#.##");
            ws.Range("e2", "f" + ws.RangeUsed().RowCount()).Style.NumberFormat.SetFormat("#.##");
            ws.Columns().AdjustToContents();
            ws.SheetView.FreezeRows(1);
            ClosedXML.Excel.IXLRange range = ws.RangeUsed();
            string RCNT = "J" + range.RowCount();
            ws.Range("a1", RCNT).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", RCNT).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("a1", "J1").Style.Fill.BackgroundColor = XLColor.Turquoise;
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=STOCK.xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            return RedirectToAction("List");
        }
    }
}