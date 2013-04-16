using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteSUPPORTASU.Models
{
    public class HRDroopOff
    {
        public HRDroopOff()
        { }

        public HRDroopOff(string Form)
        {
            knowSupport = Form;
        }

        public HRDroopOff(string PaticipantName, string PaticipantEmail, string PaticipantBarcode, string knowSupport, string HearedAbout, string InterestedIn, string Expectations, string Leave, string OldResult = "")
        {
            // TODO: Complete member initialization
            this.PaticipantName = PaticipantName;
            this.PaticipantEmail = PaticipantEmail;
            this.PaticipantBarcode = PaticipantBarcode;
            this.knowSupport = knowSupport;
            this.HearedAbout = HearedAbout;
            this.InterestedIn = InterestedIn;
            this.Expectations = Expectations;
            this.Leave = Leave;
            this.OldResult = OldResult;
        }
        public string PaticipantName { get; set; }
        public string PaticipantEmail { get; set; }
        public string PaticipantBarcode { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string knowSupport { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string HearedAbout { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string InterestedIn { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string Expectations { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string Leave { get; set; }
        public string Result { get; set; }
        public string OldResult { get; set; }
    }

    public class SeeParticipant
    {
        public string Barcode { get; set; }
    }

    public class UserLogOn
    {

        [Required(ErrorMessage = "Please Enter Your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Barcode")]
        public string Barcode { get; set; }
    }
}