using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class AboutUs
    {
        [Required]
        public string Text { set; get; }

        [Required]
        public int ID { set; get; }
    }
}