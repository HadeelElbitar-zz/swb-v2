using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class MemberModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public int CommitteeID { get; set; }
        
        public string Mobile { get; set; }
        public string HomePhone { get; set; }
        
        public string Email { get; set; }
        [Required]
        public int PositionID{ get; set; }
        [Required]
        public int CollegeID { get; set; }
        [Required]
        public int UniversityID { get; set; }
        
        public string state { get; set; }
        
        public string Address { get; set; }
        [Required]
        public DateTime HireYear { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public string ProfilePicture{ get; set; }
        public string Comments { get; set; }

        public int ID { get; set; }
    }
}
