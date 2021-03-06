﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace MONGOMVC.Models
{
    public class MAINPOPU
    {
        public ObjectId _id { get; set; }
        [DisplayName("RECORD NO")]
        public Int64 RID { get; set; }
        [DisplayName("RECORD NO")]
        public string RID1 { get; set; }
        [DisplayName("SITE ID")]
        public string SID { get; set; }
        [DisplayName("CUSTOMER NAME")]
        public string CNAME { get; set; }
        [Required]
        [DisplayName("SITE NAME")]
        public string SNAME { get; set; }
        [Required]
        [DisplayName("ENGINE SR. NO")]
        public string ENS { get; set; }
        [DisplayName("ALT. SR. NO")]
        public string ALSN { get; set; }
        [DisplayName("RATING")]
        public string RAT_PH { get; set; }
        public string PHASE { get; set; }
        [DisplayName("ENGINE MODEL NO")]
        public string MODEL { get; set; }
        [DisplayName("BATTERY SR. NO")]
        public string BSN { get; set; }
        [DisplayName("SITE CONTACT PERSON")]
        public string CPN { get; set; }
        [DisplayName("CONTACT NO")]
        public string PHNO { get; set; }
        [DisplayName("SITE ADDRESS")]
        public string ADDR { get; set; }
        [DisplayName("DT. OF COMMISSIONING")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOC { get; set; }
        [DisplayName("TECHNICIAN NAME")]
        public string SPIN { get; set; }
        [DisplayName("DG SET AMC STATUS")]
        public string AMC { get; set; }
        [DisplayName("CURRENT HMR")]
        public string CHMR { get; set; }
        [DisplayName("CURRENT HMR ON DATE")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CHMD { get; set; }
        [DisplayName("LAST SERVICE HMR")]
        public string lhmr { get; set; }
        [DisplayName("LAST SERVICE DATE")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> lsd { get; set; }
        [DisplayName("NEXT SERVICE DATE")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> nsd { get; set; }
        [DisplayName("AVG. HMR")]
        public string ahm { get; set; }
        [DisplayName("DG SET NO")]
        public string DGNO { get; set; }
        [DisplayName("LAST ACTION")]
        public string ACTION { get; set; }
        [DisplayName("DISTRICT NAME")]
        public string DIST { get; set; }
        [DisplayName("STATE NAME")]
        public string STATE { get; set; }
        [DisplayName("ALTERNATOR MAKE")]
        public string AMAKE { get; set; }
        [DisplayName("WARRANTY STATUS")]
        public string WARR { get; set; }
        [DisplayName("OEA NAME")]
        public string OEA { get; set; }
        public string SSTA { get; set; }
        [DisplayName("HMR AGEGING")]
        public string hmage { get; set; }
        [DisplayName("DEALER CODE")]
        public string DPCODE { get; set; }
        public string lmodi { get; set; }
        public string AEDT { get; set; }
        [DisplayName("LLOP MAKE")]
        public string llop { get; set; }
        [DisplayName("SOLENOID MAKE")]
        public string solenoid { get; set; }
        [DisplayName("CHARGING ALT. MAKE")]
        public string chalt { get; set; }
        [DisplayName("STARTER MAKE")]
        public string starter { get; set; }
        [DisplayName("CONTROLLER TYPE")]
        public string cntype { get; set; }
        [DisplayName("CONTROLLER MAKE")]
        public string cnmake { get; set; }
        [DisplayName("SITE AUTOMATION")]
        public string sauto { get; set; }
        [DisplayName("ALTERNATOR FRAME")]
        public string FRAME { get; set; }
        [DisplayName("DG SET STATUS")]
        public string DSTA { get; set; }
    }
}