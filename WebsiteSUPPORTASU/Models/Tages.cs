using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{

    public class EventUniversityModel
    {
        public int EventID { get; set; }
        [Required]
        public List<string> Universities { get; set; }
    }

    public class EventSponsorModel
    {
        public int EventID { get; set; }
        [Required]
        public List<string> Sponsors { get; set; }
    }

    public class UniversityCollegeModel
    {
        public int UniversityID { get; set; }
        [Required]
        public List<string> Colleges { get; set; }
    }

    public class MemberEventModel
    {
        public int MemberID { get; set; }
        [Required]
        public List<string> Events { get; set; }
    }
}