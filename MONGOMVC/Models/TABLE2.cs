﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace MONGOMVC.Models
{
    public class TABLE2
    {
        public ObjectId _id { get; set; }
        public Int64 RID1 { get; set; }
        [DisplayName("RECORD NO")]
        public string RID { get; set; }
        [DisplayName("ITEM TYPE")]
        public string TYPE { get; set; }
        [Required(ErrorMessage = "Please Fill The Record!", AllowEmptyStrings = false)]
        [DisplayName("PART NO")]
        public string PART_NO { get; set; }
        [Required(ErrorMessage = "Please Fill The Record!", AllowEmptyStrings = false)]
        [DisplayName("PART NAME")]
        public string PARTI { get; set; }
        [Required(ErrorMessage = "Please Fill The Record!", AllowEmptyStrings = false)]
        public string MRP { get; set; }
        [Required(ErrorMessage = "Please Fill The Record!", AllowEmptyStrings = false)]
        public string QTY { get; set; }
        [DisplayName("ITEM TOTAL")]
        public string TOTAL { get; set; }
        [DisplayName("RACK NO")]
        public string RACKNO { get; set; }
        [DisplayName("TAX RATE")]
        public string TAX { get; set; }
        [DisplayName("TAX VALUE")]
        public string TVAL { get; set; }
        [DisplayName("SELL PRICE TOTAL")]
        public string STOTAL { get; set; }
        [DisplayName("PURCAHSE PRICE")]
        public string PPRICE { get; set; }
        public string UNIT { get; set; }
        [DisplayName("SELL PRICE")]
        public string SPRICE { get; set; }
        public string SSTA { get; set; }
        public string EOR { get; set; }
        [DisplayName("DEALER CODE")]
        public string DPCODE { get; set; }
        public string lmodi { get; set; }
        [DisplayName("ITEM GROUP")]
        public string grop { get; set; }
        public string AEDT { get; set; }
        [DisplayName("USER NAME")]
        public string USER1 { get; set; }
    }
}