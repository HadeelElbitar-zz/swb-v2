using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class PositionModel
    {
        public string Comment { get; set; }
        [Required]
        public string Name { get; set; }

        public int ID { get; set; }
    }
}
