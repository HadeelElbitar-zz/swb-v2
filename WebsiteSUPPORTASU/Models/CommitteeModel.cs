using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class CommitteeModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ID { get; set; }
    }
}
