using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace WebsiteSUPPORTASU.Models
{
    public class GalleryModel
    {
        public int ID { set; get; }
        [Required]
        public string name { set; get; }
        [Required]
        public string type { set; get; }
        [Required]
        public string location { set; get; }
        [Required]
        public int eventID { set; get; }
        public string comments { set; get; }
         
    }
}