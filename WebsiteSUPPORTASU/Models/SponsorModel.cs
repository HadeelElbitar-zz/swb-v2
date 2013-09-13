using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class SponsorModel
    {
        [Required(ErrorMessage = "Please Enter Sponser Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Please Enter Sponser ID")]
        public int ID { set; get; }
        [Required(ErrorMessage = "Please Enter Sponser Website")]
        public string Website { set; get;}
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter Sponser Email")]
        public string Email { set; get;}
        [Required(ErrorMessage = "Please Enter Sponser Mobile")]
        public string Mobile { set; get;}
        [Required(ErrorMessage="Add Type Of Sponsor")]
        public string Type { get; set; }
    }
}