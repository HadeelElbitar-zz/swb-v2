using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class ContactUS
    {
        [Required(ErrorMessage ="Please enter your Name ")]
        public string FullName { set; get; }

        [Required(ErrorMessage = "Please enter your Email ")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Please enter your Subject ")]
        public string Subject { set; get; }

        [Required(ErrorMessage = "Please enter your Message ")]
        public string Message { set; get; }
 

    }
}