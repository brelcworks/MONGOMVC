using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace MONGOMVC.Models
{
    public class BILL
    {
        public ObjectId _id { get; set; }
        public Int64 BILLID { get; set; }
        public string BID { get; set; }
        public string BILL_NO { get; set; }
        public Nullable<System.DateTime> BDATE { get; set; }
        public string DNAME { get; set; }
        public string CUST { get; set; }
        [Required]
        public string PART_NO { get; set; }
        [Required]
        public string PARTI { get; set; }
        [Required]
        public string QTY { get; set; }
        public string MRP { get; set; }
        public string SPRICE { get; set; }
        public string TOTAL { get; set; }
        public string TAX { get; set; }
        public string TVAL { get; set; }
        public string STOT { get; set; }
        public string CMP { get; set; }
        public string UNIT { get; set; }
        public string USER1 { get; set; }
        public string MODE { get; set; }
        public string SSTA { get; set; }
        public string DPCODE { get; set; }
        public string LMODI { get; set; }
        public string AEDT { get; set; }
        public Nullable<decimal> BAMT { get; set; }
    }
}