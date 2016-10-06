using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace MONGOMVC.Models
{
    public class PMR
    {
        public ObjectId _id { get; set; }
        public Int64 RECID1 { get; set; }
        [DisplayName("SITE ID")]
        public string SID { get; set; }
        [DisplayName("SITE NAME")]
        public string SNAME { get; set; }
        [DisplayName("ENGINE SR. NO")]
        public string ENGINE_No { get; set; }
        [Required]
        [DisplayName("DATE OF ISSUE")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOS { get; set; }
        [Required]
        [DisplayName("ISSUE TYPE")]
        public string STYPE { get; set; }
        public string HMR { get; set; }
        [DisplayName("REPORT NO")]
        public string Report { get; set; }
        [DisplayName("TECHNICIAN VISITED")]
        public string Technician { get; set; }
        [DisplayName("METERIAL USED")]
        public string METERIAL { get; set; }
        [DisplayName("CUSTOMER NAME")]
        public string CUST { get; set; }
        [DisplayName("RECORD NO")]
        public string recid { get; set; }
        [DisplayName("ISSUE CLOSED DATE")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CDATI { get; set; }
        [DisplayName("DISTRICT")]
        public string DIST { get; set; }
        public string STATE { get; set; }
        [DisplayName("ISSUE CATEGORY")]
        public string CCATE { get; set; }
        [DisplayName("ENGINE MODEL NO")]
        public string MODEL { get; set; }
        [DisplayName("DT. OF COMMISSIONING")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOI { get; set; }
        [DisplayName("DG SET NO")]
        public string DGNO { get; set; }
        [DisplayName("ALTERNATOR MAKE")]
        public string AMAKE { get; set; }
        [DisplayName("ALTERNATOR SR NO")]
        public string ALSN { get; set; }
        [DisplayName("BATTERY SR. NO")]
        public string BSN { get; set; }
        [DisplayName("ISSUE NATURE")]
        public string CNAT { get; set; }
        [DisplayName("SERVERITY")]
        public string SERV { get; set; }
        [DisplayName("REASON OF FAILURE")]
        public string RFAIL { get; set; }
        [Required]
        [DisplayName("ISSUE STATUS")]
        public string STA { get; set; }
        [DisplayName("WARRANTY STATUS")]
        public string WARR { get; set; }
        [DisplayName("ACTION TAKEN")]
        public string ACTION { get; set; }
        [DisplayName("OEA NAME")]
        public string OEA { get; set; }
        [DisplayName("AMC STATUS")]
        public string AMC { get; set; }
        public string TTR { get; set; }
        [DisplayName("SLA STATUS")]
        public string SLA { get; set; }
        [DisplayName("TIME SLOT")]
        public string TSLOT { get; set; }
        [DisplayName("REASON OF SLA")]
        public string RESLA { get; set; }
        public string KVA { get; set; }
        public string SSTA { get; set; }
        [DisplayName("DEALER CODE")]
        public string DPCODE { get; set; }
        public string lmodi { get; set; }
        public string AEDT { get; set; }
        [DisplayName("REMARKS")]
        public string REM { get; set; }
    }
}