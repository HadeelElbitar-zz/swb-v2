using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class CollegeModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public string Comments { get; set; }

        public int ID { get; set; }
    }
}
