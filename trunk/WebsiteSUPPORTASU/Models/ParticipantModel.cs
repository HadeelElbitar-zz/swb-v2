using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class ParticipantModel
    {
        [Required(ErrorMessage="Please Enter Your Fullname")]
        public String FullName { get; set; }
        public int Workshop { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mobile Number")]
        [MinLength(11, ErrorMessage="Invalid Number")]
        [DataType(DataType.PhoneNumber)]
        public String Mobile { get; set; }
        [MinLength(10, ErrorMessage = "Invalid Number")]
        [DataType(DataType.PhoneNumber)]
        public String HomePhone { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        public int College { get; set; }
        public int University { get; set; }
        public int Interview { get; set; }
        public String Comments { get; set; }

        public int EventID { get; set; }

        public int Member { get; set; }
    }

    public class ParticipantsEmailsModel
    {
        public string Subject { get; set; }

        public string body { get; set; }

        public string[] Emails { get; set; }

        public string OurEmail { get; set; }
    }
}