using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace MONGOMVC.Models
{
    public class USER
    {
        public ObjectId _id { get; set; }
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        [DisplayName("User Name")]
        public string uid { get; set; }
        [Required(ErrorMessage = "Please Provide Password", AllowEmptyStrings = false)]
        [DisplayName("Password")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string pass { get; set; }
        [DisplayName("First Name")]
        public string fname { get; set; }
        [DisplayName("Last Name")]
        public string lname { get; set; }
    }
}