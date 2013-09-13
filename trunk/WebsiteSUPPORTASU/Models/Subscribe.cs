using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebsiteSUPPORTASU.Models
{
    public class Subscribe
    {
        public int id { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Name { set; get; }
 
        public int State { set; get; }

    }
}