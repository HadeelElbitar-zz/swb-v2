using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class EventModel
    {
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Event StartDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please Enter Event EndDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EndDate { get; set; }
        public string ShortDescrption { get; set; }
        [Required(ErrorMessage = "Please Enter Event FullDescrption")]
        public string FullDescription { get; set; }
        public string Comments { get; set; }

        public int ID { get; set; }

        public bool State { get; set; }
    }

}