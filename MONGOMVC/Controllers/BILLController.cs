using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MONGOMVC.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using ClosedXML.Excel;
using System.IO;

namespace MONGOMVC.Controllers
{
    public class BILLController : Controller
    {
        public MongoClient client;
        public BILLController()
        {
            client = new MongoClient(System.Configuration.ConfigurationManager.AppSettings["mongo"]);
        }
        [Authorize]
        public JsonResult List_BILL()
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL1>("BILL1");
            var dbResult = collection.Find(f => true).ToList();
            return Json(dbResult, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public JsonResult List_BILL_ITM(string bno)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL>("BILL");
            var dbResult = collection.AsQueryable<BILL>().Where(e => e.BILL_NO.Equals(bno)).ToList();
            return Json(dbResult, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(BILL1 e)
        {
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL1>("BILL1");
            collection.InsertOne(e);
            return RedirectToAction("Create");
        }
        [Authorize]
        public JsonResult dtls(string id)
        {
            List<BILL> STLIST = new List<BILL>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL>("BILL");
            var builder = Builders<BILL>.Filter;
            var filter = builder.Eq("BID", id);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        public JsonResult dtls1(string id)
        {
            List<BILL1> STLIST = new List<BILL1>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL1>("BILL1");
            var builder = Builders<BILL1>.Filter;
            var filter = builder.Eq("BNO", id);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetPtno(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            itms = collection.AsQueryable<TABLE2>().Where(e => e.PART_NO.StartsWith(term)).Select(e => e.PART_NO).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public JsonResult GetParti(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            itms = collection.AsQueryable<TABLE2>().Where(e => e.PARTI.StartsWith(term)).Select(e => e.PARTI).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public JsonResult cstat(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL1>("BILL1");
            itms = collection.AsQueryable<BILL1>().Where(e => e.CUST.StartsWith(term)).Select(e => e.CUST).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public JsonResult snmat(string term)
        {
            List<string> itms;
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL1>("BILL1");
            itms = collection.AsQueryable<BILL1>().Where(e => e.SNAME.StartsWith(term)).Select(e => e.SNAME).ToList();
            return Json(itms, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public JsonResult gdata2(string aData)
        {
            List<TABLE2> STLIST = new List<TABLE2>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var builder = Builders<TABLE2>.Filter;
            var filter = builder.Eq("PART_NO", aData);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        public JsonResult gdata1(string aData)
        {
            List<TABLE2> STLIST = new List<TABLE2>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<TABLE2>("STOCK");
            var builder = Builders<TABLE2>.Filter;
            var filter = builder.Eq("PARTI", aData);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        public JsonResult getct(string aData)
        {
            List<BILL1> STLIST = new List<BILL1>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL1>("BILL1");
            var builder = Builders<BILL1>.Filter;
            var filter = builder.Eq("CUST", aData);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        public JsonResult gtbtot(string aData)
        {
            List<BILL1> STLIST = new List<BILL1>();
            var database = client.GetDatabase("appharbor_9spxvctt");
            var collection = database.GetCollection<BILL1>("BILL1");
            var builder = Builders<BILL1>.Filter;
            var filter = builder.Eq("CUST", aData);
            STLIST = collection.Find(filter).ToList();
            return new JsonResult { Data = STLIST, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        public JsonResult getlrec()
        {
            try
            {
                var database = client.GetDatabase("appharbor_9spxvctt");
                var collection = database.GetCollection<BILL1>("BILL1");
                var max = collection.Find(f => true).Count();
                return new JsonResult { Data = max, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = ex.ToString(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult Save1(BILL1 bill)
        {
            string message = "";
           
            if (ModelState.IsValid)
            {
                try
                {
                  var database = client.GetDatabase("appharbor_9spxvctt");
                    var collection = database.GetCollection<BILL1>("BILL1");
                    collection.InsertOne(bill);
                    message = "Successfully Saved!";
                }
                catch (Exception ex) { message = ex.ToString(); }
            }
            else
            {
                message = "Successfully Saved!";
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
        [Authorize]
        [HttpPost]
        public ActionResult Save(BILL bill)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var database = client.GetDatabase("appharbor_9spxvctt");
                    var collection = database.GetCollection<BILL>("BILL");
                    collection.InsertOne(bill);
                    message = "Successfully Saved!";
                }
                catch (Exception ex) { message = ex.ToString(); }
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
        [Authorize]
        [HttpPost]
        public ActionResult Save_ITM(TABLE2 bill)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var database = client.GetDatabase("appharbor_9spxvctt");
                    var collection = database.GetCollection<TABLE2>("STOCK");
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
        [Authorize]
        [HttpPost]
        public ActionResult STUPD(TABLE2 e)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var database = client.GetDatabase("appharbor_9spxvctt");
                    var collection = database.GetCollection<TABLE2>("STOCK");
                    var builder = Builders<TABLE2>.Filter;
                    var filter = builder.Eq(s => s.RID1, e.RID1);
                    var upd = Builders<TABLE2>.Update
                        .Set("TYPE", e.TYPE)
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
                    message = "Successfully Saved!";
                }
                catch (Exception ex) { message = ex.ToString(); }
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
                return View(e);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult BILLUPD(BILL e)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var database = client.GetDatabase("appharbor_9spxvctt");
                    var collection = database.GetCollection<BILL>("BILL");
                    var builder = Builders<BILL>.Filter;
                    var filter = builder.Eq(s => s.BILLID, e.BILLID);
                    var upd = Builders<BILL>.Update
                        .Set("BILL_NO", e.BILL_NO)
                        .Set("BDATE", e.BDATE)
                        .Set("DNAME", e.DNAME)
                        .Set("CUST", e.CUST)
                        .Set("PART_NO", e.PART_NO)
                        .Set("PARTI", e.PARTI)
                        .Set("QTY", e.QTY)
                        .Set("MRP", e.MRP)
                        .Set("UNIT", e.UNIT)
                        .Set("SSTA", e.SSTA)
                        .Set("SPRICE", e.SPRICE)
                        .Set("TOTAL", e.TOTAL)
                        .Set("TAX", e.TAX)
                        .Set("USER1", e.USER1)
                        .Set("STOT", e.STOT)
                        .Set("CMP", e.CMP)
                        .Set("MODE", e.MODE)
                        .Set("DPCODE", e.DPCODE)
                        .Set("LMODI", e.LMODI)
                        .Set("BAMT", e.BAMT)
                        .Set("AEDT", e.AEDT)
                        .Set("TVAL", e.TVAL);
                    var result = collection.UpdateOne(filter, upd);
                    message = "Successfully Saved!";
                }
                catch (Exception ex) { message = ex.ToString(); }
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
                return View(e);
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult INVUPD(BILL1 e)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var database = client.GetDatabase("appharbor_9spxvctt");
                    var collection = database.GetCollection<BILL1>("BILL1");
                    var builder = Builders<BILL1>.Filter;
                    var filter = builder.Eq(s => s.BID, e.BID);
                    var upd = Builders<BILL1>.Update
                        .Set("BNO", e.BNO)
                        .Set("BDATE", e.BDATE)
                        .Set("SNAME", e.SNAME)
                        .Set("CUST", e.CUST)
                        .Set("GTOT", e.GTOT)
                        .Set("TOTAL", e.TOTAL)
                        .Set("PAYMENT", e.PAYMENT)
                        .Set("SECTOR", e.SECTOR)
                        .Set("ADDRESS", e.ADDRESS)
                        .Set("SSTA", e.SSTA)
                        .Set("ROUND", e.ROUND)
                        .Set("NTOT", e.NTOT)
                        .Set("MODE", e.MODE)
                        .Set("USER1", e.USER1)
                        .Set("VNO", e.VNO)
                        .Set("CBILL", e.CBILL)
                        .Set("BAPAY", e.BAPAY)
                        .Set("BST", e.BST)
                        .Set("LMODI", e.LMODI)
                        .Set("BAMT", e.BAMT)
                        .Set("DPCODE", e.DPCODE)
                        .Set("AEDT", e.AEDT)
                        .Set("TVAL", e.TVAL);
                    var result = collection.UpdateOne(filter, upd);
                    message = "Successfully Saved!";
                }
                catch (Exception ex) { message = ex.ToString(); }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                ViewBag.Message = message;
                return View(e);
            }
        }
        [Authorize]
        [HttpPost]
        public JsonResult DELITEM_BILL(Int64 id)
        {
            string message = "";
            try
            {
                var database = client.GetDatabase("appharbor_9spxvctt");
                var collection = database.GetCollection<BILL>("BILL");
                var builder = Builders<BILL>.Filter;
                var filter = builder.Eq(s => s.BILLID, id);
                var result = collection.DeleteOne(filter);
                message = "Successfully Saved!";
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Authorize]
        public ActionResult PRINTCHALLAN(string BNO, string BDATE, string CUST, string SNAME, string ADDR, string VNO)
        {
            string message = "";
            try
            {
                System.Web.UI.WebControls.GridView gv = new System.Web.UI.WebControls.GridView();
                var database = client.GetDatabase("appharbor_9spxvctt");
                var collection = database.GetCollection<BILL>("BILL");
                var builder = Builders<BILL>.Filter;
                var filter = builder.Eq(s => s.BILL_NO, BNO);
                var totcon = collection.Find(filter).ToList();
                gv.DataSource = totcon;
                gv.DataBind();
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("CHALLAN");
                if (totcon.Count <= 12)
                {
                    ws.Column(1).Width = 5.43;
                    ws.Column(2).Width = 6;
                    ws.Column(3).Width = 6.29;
                    ws.Column(4).Width = 8.43;
                    ws.Column(5).Width = 8.43;
                    ws.Column(6).Width = 17.57;
                    ws.Column(7).Width = 3;
                    ws.Column(8).Width = 7.29;
                    ws.Column(9).Width = 9.5;
                    ws.Column(10).Width = 7.43;
                    ws.Column(11).Width = 10.86;
                    ws.Range("a2", "k2").Merge();
                    ws.Range("a2").Value = "B. & R. ELECTRICAL WORKS";
                    ws.Range("a2").Style.Font.FontName = "Book Antiqua";
                    ws.Range("a2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Range("a2").Style.Font.FontSize = 24;
                    ws.Range("a2").Style.Font.Bold = true;
                    ClosedXML.Excel.IXLRange range = ws.Range("a1", "k5");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Row(6).Height = 3;
                    ws.Cell(7, 1).Value = "CHALLAN NO:-";
                    ws.Cell(7, 10).Value = "DATE:-";
                    ws.Cell(7, 11).Value = BDATE;
                    ws.Range("K7").Style.NumberFormat.SetFormat("dd-MMM-yyyy");
                    ws.Cell(8, 1).Value = "CUSTOMER:-";
                    ws.Cell(10, 1).Value = "VAT NO:-";
                    range = ws.Range("a7", "k10");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Row(11).Height = 3;
                    ws.Cell(12, 1).Value = "SL NO";
                    ws.Cell(12, 2).Value = "PART NO";
                    ws.Cell(12, 4).Value = "PARTICULARS";
                    ws.Cell(12, 9).Value = "MRP";
                    ws.Cell(12, 10).Value = "QTY";
                    ws.Cell(12, 11).Value = "PER";
                    range = ws.Range("a12", "k12");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("a12", "A24");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("d12", "H24");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("j12", "j24");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("k12", "k24");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range("i12", "i24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range("j12", "j24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range("k12", "k24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a13", "k24").Style.Font.FontSize = 9.5;
                    ws.Range("a27", "k27").Style.Font.Bold = true;
                    ws.Range("i24", "k24").Style.Font.Bold = true;
                    ws.Range("i13", "i24").Style.NumberFormat.SetFormat("#.00");
                    ws.PageSetup.Margins.Left = 0.34;
                    ws.PageSetup.Margins.Right = 0.17;
                    ws.PageSetup.Margins.Top = 0.35;
                    ws.PageSetup.Margins.Bottom = 0.02;
                    ws.PageSetup.Margins.Header = 0.02;
                    ws.PageSetup.Margins.Footer = 0.02;
                    ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
                    for (int i = 0; i < gv.Rows.Count; i++)
                    {

                        ws.Cell(i + 13, 1).Value = i + 1;
                        ws.Cell(i + 13, 2).Value = "'" + gv.Rows[i].Cells[6].Text;
                        ws.Cell(i + 13, 4).Value = gv.Rows[i].Cells[7].Text;
                        ws.Cell(i + 13, 9).Value = gv.Rows[i].Cells[9].Text;
                        ws.Cell(i + 13, 10).Value = gv.Rows[i].Cells[8].Text;
                        ws.Cell(i + 13, 11).Value = gv.Rows[i].Cells[16].Text;
                    }
                    System.Text.RegularExpressions.Match Rlst = System.Text.RegularExpressions.Regex.Match(BNO, "\\d+");
                    ws.Cell(7, 3).Value = Rlst.Value;
                    if (SNAME != null)
                    {
                        ws.Cell(8, 3).Value = CUST + "  [SITE: " + SNAME + "]";
                    }
                    else
                    {
                        ws.Cell(8, 3).Value = CUST;
                    }
                    ws.Cell(9, 1).Value = "ADDRESS:-";
                    ws.Cell(9, 3).Value = ADDR;
                    ws.Range("c10", "d10").Merge();
                    ws.Range("c10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    ws.Cell(10, 3).Value = VNO;
                    ws.Range("i27").Value = "For, B & R ELECTRICAL WORKS";
                    ws.Range("i27", "k27").Merge();
                    ws.Range("i27").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    range = ws.Range("a25", "k27");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range("a1", "k1").Merge();
                    ws.Range("a1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a1").Value = "CHALLAN";
                    ws.Range("a1").Style.Font.Underline = XLFontUnderlineValues.Single;
                    ws.Row(32).Height = 3;
                    ws.Range("a3", "k3").Merge();
                    ws.Range("a3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a3").Value = "STALL NO. T/542, NEAR DOOARS BUS STAND, BIDHAN MARKET, SILIGURI - 734001";
                    ws.Range("a4", "k4").Merge();
                    ws.Range("a4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a4").Value = "0353 - 2433269, 2526285";
                    ws.Range("a5", "k5").Merge();
                    ws.Range("a5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a5").Value = "VAT NO: " + "19896290025" + ", CST NO: " + "19896290219" + ", PAN NO: " + "AACFB7969H" + ", S.TAX NO: " + "AACFB7969HST001";
                    ws.Range("b13", "b24").Style.NumberFormat.SetFormat("@");
                    ws.Cell(27, 1).Value = "Signature of Customer";
                    ws.Range("a24").Style.Font.FontName = "Book Antiqua";
                    ws.Range("a24").Style.Font.Bold = true;
                    ws.Range("a13", "a24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a41", "a52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    range = ws.Range("a1", "k27");
                    ws.Cell(30, 1).Value = range;
                    ws.Row(35).Height = 3;
                    ws.Row(40).Height = 3;
                    ws.Range("a28", "k28").Style.Border.BottomBorder = XLBorderStyleValues.SlantDashDot;
                    ws.Row(28).Height = 20;
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    string FL = "CHALLAN " + CUST + "- " + SNAME + "- " + Rlst.Value + ".xlsx";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + FL);
                    message = "Successfully Saved!";
                    string upfile = AppDomain.CurrentDomain.BaseDirectory + "App_Data/UPLOAD1/" + FL;
                    wb.SaveAs(upfile);
                    Response.WriteFile(upfile);
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    ws.Column(1).Width = 5.43;
                    ws.Column(2).Width = 6;
                    ws.Column(3).Width = 6.29;
                    ws.Column(4).Width = 8.43;
                    ws.Column(5).Width = 8.43;
                    ws.Column(6).Width = 17.57;
                    ws.Column(7).Width = 3;
                    ws.Column(8).Width = 7.29;
                    ws.Column(9).Width = 9.5;
                    ws.Column(10).Width = 7.43;
                    ws.Column(11).Width = 10.86;
                    ws.Range("a2", "k2").Merge();
                    ws.Range("a2").Value = "B. & R. ELECTRICAL WORKS";
                    ws.Range("a2").Style.Font.FontName = "Book Antiqua";
                    ws.Range("a2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Range("a2").Style.Font.FontSize = 24;
                    ws.Range("a2").Style.Font.Bold = true;
                    ClosedXML.Excel.IXLRange range;
                    range = ws.Range("a1", "k5");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Row(6).Height = 3;
                    ws.Cell(7, 1).Value = "CHALLAN NO:-";
                    ws.Cell(7, 10).Value = "DATE:-";
                    ws.Cell(7, 11).Value = BDATE;
                    ws.Range("K7").Style.NumberFormat.SetFormat("dd-MMM-yyyy");
                    ws.Cell(8, 1).Value = "CUSTOMER:-";
                    ws.Cell(10, 1).Value = "VAT NO:-";
                    range = ws.Range("a1", "k5");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("a7", "k10");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Row(11).Height = 3;
                    ws.Cell(12, 1).Value = "SL NO";
                    ws.Cell(12, 2).Value = "PART NO";
                    ws.Cell(12, 4).Value = "PARTICULARS";
                    ws.Cell(12, 9).Value = "MRP";
                    ws.Cell(12, 10).Value = "QTY";
                    ws.Cell(12, 11).Value = "PER";
                    range = ws.Range("a12", "k12");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("a12", "A52");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("d12", "H52");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("j12", "j52");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range = ws.Range("k12", "k52");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range("i12", "i52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range("j12", "j52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range("k12", "k52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a13", "k52").Style.Font.FontSize = 9.5;
                    ws.Range("a56", "k56").Style.Font.Bold = true;
                    ws.Range("i13", "i52").Style.NumberFormat.SetFormat("#.00");
                    ws.PageSetup.Margins.Left = 0.35;
                    ws.PageSetup.Margins.Right = 0.17;
                    ws.PageSetup.Margins.Top = 0.15;
                    ws.PageSetup.Margins.Bottom = 0.02;
                    ws.PageSetup.Margins.Header = 0.02;
                    ws.PageSetup.Margins.Footer = 0.02;
                    for (int i = 0; i < gv.Rows.Count; i++)
                    {

                        ws.Cell(i + 13, 1).Value = i + 1;
                        ws.Cell(i + 13, 2).Value = "'" + gv.Rows[i].Cells[6].Text;
                        ws.Cell(i + 13, 4).Value = gv.Rows[i].Cells[7].Text;
                        ws.Cell(i + 13, 9).Value = gv.Rows[i].Cells[9].Text;
                        ws.Cell(i + 13, 10).Value = gv.Rows[i].Cells[8].Text;
                        ws.Cell(i + 13, 11).Value = gv.Rows[i].Cells[16].Text;
                    }
                    System.Text.RegularExpressions.Match Rlst = System.Text.RegularExpressions.Regex.Match(BNO, "\\d+");
                    ws.Cell(7, 3).Value = Rlst.Value;
                    if (SNAME != null)
                    {
                        ws.Cell(8, 3).Value = CUST + "  [SITE: " + SNAME + "]";
                    }
                    else
                    {
                        ws.Cell(8, 3).Value = CUST;
                    }
                    ws.Cell(9, 1).Value = "ADDRESS:-";
                    ws.Cell(9, 3).Value = ADDR;
                    ws.Range("c10", "d10").Merge();
                    ws.Range("c10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    ws.Cell(10, 3).Value = VNO;
                    ws.Range("i56").Value = "For, B & R ELECTRICAL WORKS";
                    ws.Range("i56", "k56").Merge();
                    ws.Range("i56").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    range = ws.Range("a53", "k56");
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range("a1", "k1").Merge();
                    ws.Cell(56, 1).Value = "Signature of Customer";
                    ws.Range("a1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a1").Value = "CHALLAN";
                    ws.Range("a1").Style.Font.Underline = XLFontUnderlineValues.Single;
                    ws.Row(32).Height = 3;
                    ws.Range("a3", "k3").Merge();
                    ws.Range("a3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a3").Value = "STALL NO. T/542, NEAR DOOARS BUS STAND, BIDHAN MARKET, SILIGURI - 734001";
                    ws.Range("a4", "k4").Merge();
                    ws.Range("a4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a4").Value = "0353 - 2433269, 2526285";
                    ws.Range("a5", "k5").Merge();
                    ws.Range("a5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range("a5").Value = "VAT NO: " + "19896290025" + ", CST NO: " + "19896290219" + ", PAN NO: " + "AACFB7969H" + ", S.TAX NO: " + "AACFB7969HST001";
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    string FL = "CHALLAN " + CUST + "- " + SNAME + "- " + Rlst.Value + ".xlsx";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + FL);
                    message = "Successfully Saved!";
                    wb.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "App_Data/UPLOAD1/" + FL);
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch (Exception ex) { message = ex.Message; }
            return Content(message);
        }
    }
}